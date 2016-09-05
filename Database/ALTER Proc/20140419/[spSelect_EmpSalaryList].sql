USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spCust_Update]    Script Date: 04/19/2014 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*==================================================================
							NguyenQuoc_tnt
==================================================================*/

Create   Proc [dbo].[spSelect_EmpSalaryList]
	@Emp_ID int,
	@Company_ID int,
	@ProductName Nvarchar(200)
AS
BEGIN
select SalaryPercents.SalaryPercent_ID,SalaryPercents.Emp_ID,SalaryPercents.Product_ID,SalaryPercents.Percents,SalaryPercents.Note
		,tbl_Products.ProductName
from tbl_SalaryPercents SalaryPercents, tbl_Products tbl_Products
where tbl_Products.Product_ID = SalaryPercents.Product_ID
		AND SalaryPercents.Emp_ID = @Emp_ID
		AND tbl_Products.Company_ID = @Company_ID
		AND tbl_Products.ProductName like '%' + @ProductName + '%'

END
