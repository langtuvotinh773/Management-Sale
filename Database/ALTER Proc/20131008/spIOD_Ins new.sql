USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIOD_Ins]    Script Date: 10/08/2013 23:46:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER      Proc [dbo].[spIOD_Ins] 
	@ImportOrder_ID Int,
	@Company_ID Int,
	@ProductName NVarchar(300),
	@Quantity Int,	
	@QuantityPromotion Int,
	@PercentPromotion SmallInt,
	@Discount Decimal(5,2),
	@PriceActual Decimal(15,2),
	@Price Decimal(15,5),
	@PriceSell Decimal(15,5)
AS
BEGIN
	Declare @Product_ID Int
	Select @Product_ID = Product_ID From tbl_Products where Company_ID=@Company_ID and ProductName=@ProductName
-- IOD
	Insert Into tbl_ImportOrderDetails (ImportOrder_ID, Product_ID,Quantity,QuantityPromotion , PercentPromotion, Discount, Price ,PriceSell,PriceActual)

 	Values (@ImportOrder_ID, @Product_ID,@Quantity,@QuantityPromotion , @PercentPromotion, @Discount,@Price,@PriceSell,@PriceActual )

--Update ProductPrices
--Nếu như giá của sản phẩm này chưa có giá nào như giá nhập vào thì insert thêm 1 dòng mới
	if not exists(SElect Price From tbl_ProductPrices where Product_ID=@Product_ID And Price=@PriceSell  and PriceActual_Import = @PriceActual) 
	Begin
	--Delete giá Defaul
		delete tbl_ProductPrices where Product_ID=@Product_ID And Price <1
		Insert Into tbl_PriceHistory(Product_ID,PriceActual,PriceSell) values (@Product_ID,@PriceActual,@PriceSell)
		Insert Into tbl_ProductPrices (Product_ID , Price , Quantity , QuantityPromotion ,DateEdit ,PriceActual_Import)
		Values (@Product_ID ,@PriceSell, @Quantity , @QuantityPromotion ,GETDATE(),@PriceActual)
		-- insert vao bang PriceHistory
		Insert Into tbl_PriceHistory(Product_ID,PriceActual,PriceSell) values (@Product_ID,@PriceActual,@PriceSell)
		 
	End
	Else Begin -- Nếu có giá đó rồi thì cập nhật lại số lượng
		Update tbl_ProductPrices  
		Set Quantity= Quantity + @Quantity,
			 QuantityPromotion= QuantityPromotion + @QuantityPromotion
		Where Product_ID=@Product_ID
		And Price=@PriceSell 
		and PriceActual_Import = @PriceActual
	End

END
