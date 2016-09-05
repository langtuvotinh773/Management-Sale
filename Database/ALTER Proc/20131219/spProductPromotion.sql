USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spSalPer_List]    Script Date: 12/18/2013 20:21:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER Proc [dbo].[spProductPromotion]
AS
BEGIN
SElect distinct com.CompanyName,pro.Product_ID,pro.ProductName,pro_price.Price,pro_price.PriceActual_Import
,Promotions.Number_buy,Promotions.Number_Promotions,Promotions.Note
From tbl_Products pro Inner join tbl_Companies com
	on pro.Company_ID=com.Company_ID
	Inner Join tbl_ProductPrices pro_price
	on pro_price.Product_ID = pro.Product_ID
	Left Join tbl_Promotions Promotions
	on pro.Product_ID = Promotions.Product_ID
Where pro_price.Price > 0
and pro_price.Quantity > 0
order by pro.ProductName
END



