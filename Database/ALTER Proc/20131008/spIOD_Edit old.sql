USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIOD_Edit]    Script Date: 10/09/2013 00:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER        Proc [dbo].[spIOD_Edit] 
	@ImportOrderDetail_ID Int,
	@Company_ID Int,
	@Product_ID int,
	@Quantity Int,	
	@QuantityPromotion Int,
	@PercentPromotion SmallInt,
	@Discount SmallInt,
	@Price Decimal(15,1),
	@PriceSell Decimal(15,1),
	@iTypeActionEdit int
	
AS


	
-- spIOD_Edit 457, 35,'MUN BOC',650,0,0,0,16310,29000,1
--//iTypeActionEdit = 0; ko thay doi thong tin gi het
--//iTypeActionEdit = 1; chi edit giá nhập và giá bán
--//iTypeActionEdit = 2; Thay doi so luong va discount
BEGIN
Declare @PriceActual_New Decimal(15,1)
	-- tinh gia nhap that su 
	Set @PriceActual_New = @Price - ((@Price * (@PercentPromotion + @Discount))/100)
	
	Declare @QuantityEdit Int, @QuantityPromotionEdit Int,@PriceSell_Old  Decimal(15,1),@PriceActual_Old Decimal(15,1), @OrderDetailProductID Int
	
	--
	SElect @OrderDetailProductID = Product_ID,@QuantityEdit =Quantity, @PriceSell_Old=PriceSell
		,@QuantityPromotionEdit=QuantityPromotion 
		,@PriceActual_Old = PriceActual
	From tbl_ImportOrderDetails 
	Where ImportOrderDetail_ID=@ImportOrderDetail_ID
	
	
	Declare @Id_ProductPrices int,@CountProductPrice_Flag int
	
	select @Id_ProductPrices = ProductPrice_ID 
	from tbl_ProductPrices 
	where Product_ID = @OrderDetailProductID
		AND	Price = @PriceSell_Old 
		and PriceActual_Import = @PriceActual_Old
	
	-- kiem tra so luong cu va so luong moi co = nhau hay ko ?
	 Declare @QuantityNew int,@QuantityPromotionNew int
	 if @Quantity > @QuantityEdit
		 begin
			SET @QuantityNew = @Quantity - @QuantityEdit
		 end
	 else  if @Quantity < @QuantityEdit
		 begin
			SET @QuantityNew = @QuantityEdit - @Quantity
		 end
	else
		begin
			SET @QuantityNew = @Quantity
		 end
	if(@QuantityPromotion > @QuantityPromotionEdit)
		 begin
			SET @QuantityPromotionNew = @QuantityPromotion - @QuantityPromotionEdit
		 end
	 else if @QuantityPromotion < @QuantityPromotionEdit
		 begin
			SET @QuantityPromotionNew = @QuantityPromotionEdit - @QuantityPromotion
		 end
	else
		begin
			SET @QuantityPromotionNew = @QuantityPromotion
		end	 
					 		
	-- Kiem tra xem co thay doi gia ban haj gia nhap gi khong ?
	if @iTypeActionEdit = 1 -- cập nhật lại giá
		Begin
			delete from tbl_PriceHistory  where Product_ID =@Product_ID 
												and  PriceSell = @PriceSell_Old 
												and PriceActual = @PriceActual_Old
			Insert Into tbl_PriceHistory(Product_ID,PriceActual,PriceSell) values (@Product_ID,@PriceActual_New,@PriceSell)
			-- Cập nhật lại giá 
			-- select * from tbl_PriceHistory order by priceHistory_ID desc
			--  select * from tbl_ProductPrices order by productPrice_ID desc
			Update tbl_ProductPrices 
					Set	Price = @PriceSell,
						PriceActual_Import = @PriceActual_New
			Where ProductPrice_ID = @Id_ProductPrices
		end
	Else IF @iTypeActionEdit = 2 -- cập nhật lại số lượng và giá
		Begin
		-- check data có trong bảng tbl_ProductPrices hay chưa nếu có rồi thì ko insert
		--select * from tbl_ProductPrices 
		select @CountProductPrice_Flag = count(*) 
		from tbl_ProductPrices 
		where  ProductPrice_ID =@Id_ProductPrices 
		if(@CountProductPrice_Flag = 0)
		begin
			Insert Into tbl_PriceHistory(Product_ID,PriceActual,PriceSell) values (@Product_ID,@PriceActual_New,@PriceSell)
		end
			-- cap nhat lai gia va so luong
			Update tbl_ProductPrices 
			Set	Price=@PriceSell ,
				PriceActual_Import = @PriceActual_New,
				Quantity= (Quantity - @QuantityEdit) + @QuantityNew,
				QuantityPromotion= (QuantityPromotion - @QuantityPromotionEdit) +@QuantityPromotionNew
			Where ProductPrice_ID =@Id_ProductPrices
		end
	-- cap nhat lai chi tiet hoa don nhap 	select * from tbl_ImportOrderDetails
	Update  tbl_ImportOrderDetails 
	Set 	Quantity			=@Quantity,
			QuantityPromotion= @QuantityPromotion, 
			PercentPromotion= @PercentPromotion, 
			Discount 		=@Discount,
			Price			=@Price ,
			PriceSell		=@PriceSell,
			PriceActual = @PriceActual_New
	Where ImportOrderDetail_ID=@ImportOrderDetail_ID
	

	
	
END
