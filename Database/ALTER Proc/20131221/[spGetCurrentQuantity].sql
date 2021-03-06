USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spGetCurrentQuantity]    Script Date: 12/21/2013 16:44:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER Proc [dbo].[spGetCurrentQuantity]
	@Product_ID Int,
	@Price Decimal(15,5),
	@PriceActual_Import Decimal(15,2)
AS
BEGIN
Select Quantity
From tbl_ProductPrices 
Where Product_ID=@Product_ID
And Price=@Price
And PriceActual_Import	= @PriceActual_Import
END

