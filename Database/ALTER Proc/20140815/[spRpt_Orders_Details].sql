USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spRpt_Orders_Details]    Script Date: 08/17/2014 19:22:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[spRpt_Orders_Details] 
		@Order_ID Int
AS
BEGIN

Declare @Total_ThanhTien Decimal 
Declare @_CastPromotion Decimal
Declare @_PercentDiscount Decimal
-- Load Tong thanh tien
exec sp_GetTotalAmount @Order_ID =@Order_ID, @Total_ThanhTien = @Total_ThanhTien output
	,@_CastPromotion = @_CastPromotion output,@_PercentDiscount =@_PercentDiscount output
 -- select DATA
Select Sup.SupplierName as ABVSupplierName,emp.EmpName as TenNV,emp.Address as DCNV, emp.Phone SDTNV,od.Order_ID,cust.CustName,cust.Address, cust.Phone, emp.EmpName,
		Convert(Varchar(10),od.OrderDate,105) as DateOrder,od.Note ,ISNULL(CastPromotion,'0') as CastPromotion,ISNULL(PercentDiscount,'0') as PercentDiscount,
		pro.ProductName, odt.Quantity,odt.QuantityPromotion, odt.Discount, 
		Convert(Float,odt.Price) as Price,
 		odt.ThanhTien as Amount,
 		@Total_ThanhTien  as TotalAmount
From tbl_Supplier AS Sup,tbl_Employees emp, tbl_Customers cust,
tbl_Orders od, tbl_OrderDetails odt, tbl_Products pro
Where od.Emp_ID	=emp.Emp_ID
And od.Order_ID	=@Order_ID
And 	od.Cust_ID 	=cust.Cust_ID
And 	od.Order_ID	=odt.Order_ID
And 	odt.Product_ID=pro.Product_ID
End
