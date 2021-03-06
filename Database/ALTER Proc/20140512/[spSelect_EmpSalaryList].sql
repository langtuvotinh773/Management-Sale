USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spSelect_EmpSalaryList]    Script Date: 05/12/2014 09:37:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*==================================================================
							NguyenQuoc_tnt
==================================================================*/

ALTER   Proc [dbo].[spSelect_EmpSalaryList]
	@Emp_ID int,
	@Company_ID int,
	@ProductName Nvarchar(200)
AS
BEGIN
IF @Company_ID = 0
BEGIN
select SalaryPercents.SalaryPercent_ID,SalaryPercents.Emp_ID,SalaryPercents.Product_ID,SalaryPercents.Percents,SalaryPercents.Note
		,tbl_Products.ProductName, Companies.CompanyName
from tbl_SalaryPercents SalaryPercents, tbl_Products tbl_Products, tbl_Companies Companies
where tbl_Products.Product_ID = SalaryPercents.Product_ID
		AND SalaryPercents.Emp_ID = @Emp_ID
		AND tbl_Products.Company_ID = Companies.Company_ID
		AND tbl_Products.ProductName like '%' + @ProductName + '%'
END
ELSE
BEGIN
select SalaryPercents.SalaryPercent_ID,SalaryPercents.Emp_ID,SalaryPercents.Product_ID,SalaryPercents.Percents,SalaryPercents.Note
		,tbl_Products.ProductName, Companies.CompanyName
from tbl_SalaryPercents SalaryPercents, tbl_Products tbl_Products, tbl_Companies Companies
where tbl_Products.Product_ID = SalaryPercents.Product_ID
		AND SalaryPercents.Emp_ID = @Emp_ID
		AND tbl_Products.Company_ID = @Company_ID
		AND tbl_Products.Company_ID = Companies.Company_ID
		AND tbl_Products.ProductName like '%' + @ProductName + '%'
END
END
