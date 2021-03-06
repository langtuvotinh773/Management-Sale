USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIOD_Edit]    Script Date: 10/15/2013 22:34:06 ******/
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
	@PriceActual Decimal(15,2),
	@Price Decimal(15,1),
	@PriceSell Decimal(15,1),
	@iTypeActionEdit int
	
AS
--//iTypeActionEdit = 0; ko thay doi thong tin gi het
--//iTypeActionEdit = 1; chi edit giá nhập và giá bán
--//iTypeActionEdit = 2; Thay doi so luong va discount
BEGIN
DECLARE @TotalQuantity Decimal(15,2)
	-- tinh gia nhap that su 
	Declare @QuantityEdit Int,@QuantityPromotionEdit int,@PriceSell_Old  Decimal(15,1),@PriceActual_Old Decimal(15,2)
	
	--
	SElect @QuantityEdit =Quantity,@QuantityPromotionEdit = QuantityPromotion, @PriceSell_Old=PriceSell
		,@PriceActual_Old = PriceActual
	From tbl_ImportOrderDetails 
	Where ImportOrderDetail_ID=@ImportOrderDetail_ID
	
	
	Declare @ProductPriceID_Old int,@CountProductPrice_Flag int
	
	select @ProductPriceID_Old = ProductPrices.ProductPrice_ID 
	from tbl_ProductPrices  ProductPrices
	where Product_ID = @Product_ID
		AND	Price = @PriceSell_Old 
		and PriceActual_Import = @PriceActual_Old
	
					 		
	-- Kiem tra xem co thay doi gia ban haj gia nhap gi khong ?
	if @iTypeActionEdit = 1 -- cập nhật lại giá
		Begin
			delete from tbl_PriceHistory  where Product_ID =@Product_ID 
												and  PriceSell = @PriceSell_Old 
												and PriceActual = @PriceActual_Old
			Insert Into tbl_PriceHistory(Product_ID,PriceActual,PriceSell) values (@Product_ID,@PriceActual,@PriceSell)
			-- Cập nhật lại giá 
			-- select * from tbl_PriceHistory order by priceHistory_ID desc
			--  select * from tbl_ProductPrices order by productPrice_ID desc
			Update tbl_ProductPrices 
					Set	Price = @PriceSell,
						PriceActual_Import = @PriceActual
			Where ProductPrice_ID = @ProductPriceID_Old
		end
	Else IF @iTypeActionEdit = 2 -- cập nhật lại số lượng và giá
		Begin
		-- check data có trong bảng tbl_ProductPrices hay chưa nếu có rồi thì ko insert
		--select * from tbl_ProductPrices 
		select @CountProductPrice_Flag = count(*) 
		from tbl_ProductPrices 
		where  ProductPrice_ID =@ProductPriceID_Old 
		if(@CountProductPrice_Flag = 0)
		begin
			Insert Into tbl_PriceHistory(Product_ID,PriceActual,PriceSell) values (@Product_ID,@PriceActual,@PriceSell)
		end
			-- cap nhat lai gia va so luong
			Update tbl_ProductPrices 
			Set	Price=@PriceSell ,
				PriceActual_Import = @PriceActual,
				Quantity =  (Quantity - (@QuantityEdit + @QuantityPromotionEdit)) + (@Quantity + @QuantityPromotion)
				--,QuantityPromotion= (QuantityPromotion - @QuantityPromotionEdit) +@QuantityPromotionNew
			Where ProductPrice_ID =@ProductPriceID_Old
		end
	-- cap nhat lai chi tiet hoa don nhap 	select * from tbl_ImportOrderDetails
	Update  tbl_ImportOrderDetails 
	Set 	Quantity			=@Quantity,
			QuantityPromotion= @QuantityPromotion, 
			PercentPromotion= @PercentPromotion, 
			Discount 		=@Discount,
			Price			=@Price ,
			PriceSell		=@PriceSell,
			PriceActual = @PriceActual
	Where ImportOrderDetail_ID=@ImportOrderDetail_ID
	

	
	
END
