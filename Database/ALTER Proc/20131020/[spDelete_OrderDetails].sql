USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spDelete_OrderDetails]    Script Date: 10/20/2013 18:37:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   Proc [dbo].[spDelete_OrderDetails]
@OrderID int,
@OrderDetail_ID int,
@Product_ID int,
@PriceImport decimal(15,2),
@Price decimal(15,5),
@Quantily	int,
@QuantilyPromotion	int

AS
BEGIN
---- Xoa chi Tiet hoa don
delete from tbl_OrderDetails where OrderDetail_ID = @OrderDetail_ID

---Declare @cDelete int
--select @cDelete = COUNT(*) from tbl_OrderDetails where Order_ID = @OrderID
--if @cDelete = 0
--delete from tbl_Orders where Order_ID = @OrderID
---Update lai so luong cho bang ProductPrice
Update tbl_ProductPrices 
Set Quantity =  Quantity + (@Quantily + @QuantilyPromotion), 
	--QuantityPromotion = QuantityPromotion + @QuantilyPromotion, 
	DateEdit = GETDATE()
Where Product_ID = @Product_ID and Price =@Price and PriceActual_Import = @PriceImport

END

