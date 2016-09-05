USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spgetQuantity_Promotion]    Script Date: 12/21/2013 16:44:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER Proc [dbo].[spgetQuantity_Promotion]
	@Product_ID Int,
	@Price Decimal(15,5),
	@PriceActual_Import Decimal(15,2)
AS
BEGIN
Select Number_buy,Number_Promotions
From tbl_Promotions 
Where Product_ID=@Product_ID
And Price=@Price
And PriceActual_Import	= @PriceActual_Import
END

