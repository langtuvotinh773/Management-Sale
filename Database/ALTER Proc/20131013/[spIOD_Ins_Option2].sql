USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIOD_Ins_Option2]    Script Date: 10/13/2013 14:29:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER      Proc [dbo].[spIOD_Ins_Option2] 
	@ImportOrder_ID Int,
	@Company_ID Int,
	@ProductName NVarchar(300),
	@Quantity Int,	
	@QuantityPromotion Int,
	@PercentPromotion SmallInt,
	@Discount SmallInt,
	@Price Decimal(15,5),
	@PriceSell Decimal(15,5)
AS
BEGIN
	Declare @Product_ID Int
		Declare @PriceActual Decimal(15,2)
	-- tinh gia nhap that su 
	Set @PriceActual = @Price - ((@Price * (@PercentPromotion + @Discount))/100)
	Select @Product_ID = Product_ID From tbl_Products where Company_ID=@Company_ID and ProductName=@ProductName
	
-- IOD_option2
	--Insert Into tbl_ImportOrderDetails (ImportOrder_ID, Product_ID,Quantity,QuantityPromotion , PercentPromotion, Discount, Price ,PriceSell,PriceActual)
 --	Values (@ImportOrder_ID, @Product_ID,0,0 , 0, 0,0,0 ,0)


Insert Into tbl_ImportOrderDetails_Option2 (ImportOrder_ID, Product_ID,Quantity,QuantityPromotion , PercentPromotion, Discount, Price ,PriceSell,PriceActual)
 	Values (@ImportOrder_ID, @Product_ID,@Quantity,@QuantityPromotion , @PercentPromotion, @Discount,@Price,@PriceSell ,@PriceActual)
-- trả tiền cho Hóa Đơn
declare @TotalAmount decimal(15,2) 
SET @TotalAmount = @Quantity * @PriceActual
INSERT INTO dbo.tbl_PaymentIntputs values(GETDATE(),@ImportOrder_ID,N'Hóa Đơn Đổi Trả',@TotalAmount)

-- insert 
Insert Into tbl_ImportOrderDetails (ImportOrder_ID, Product_ID,Quantity,QuantityPromotion , PercentPromotion, Discount, Price ,PriceSell,PriceActual)
 	Values (@ImportOrder_ID, @Product_ID,@Quantity,@QuantityPromotion , @PercentPromotion, @Discount,@Price,@PriceSell ,@PriceActual)
	
	
--update tbl_ImportOrder
update tbl_ImportOrders set IsLock = 1 where ImportOrder_ID =  @ImportOrder_ID

--Update ProductPrices
--Nếu như giá của sản phẩm này chưa có giá nào như giá nhập vào thì insert thêm 1 dòng mới
	if not exists(SElect Price From tbl_ProductPrices 
					where Product_ID=@Product_ID And Price=@PriceSell  and PriceActual_Import = @PriceActual
				) 
	Begin	
		Insert Into tbl_ProductPrices (Product_ID , Price , Quantity , QuantityPromotion ,DateEdit ,PriceActual_Import)
		Values (@Product_ID ,@PriceSell, @Quantity , @QuantityPromotion ,GETDATE(),@PriceActual)
		--Delete giá Defaul
		delete tbl_ProductPrices where Product_ID=@Product_ID And Price <1 
	End
	Else Begin -- Nếu có giá đó rồi thì cập nhật lại số lượng
		Update tbl_ProductPrices  
		Set Quantity= Quantity + (@Quantity +@QuantityPromotion)
		--,QuantityPromotion= QuantityPromotion + @QuantityPromotion
		Where Product_ID=@Product_ID
		And Price=@PriceSell 
		and PriceActual_Import = @PriceActual
	End

END


