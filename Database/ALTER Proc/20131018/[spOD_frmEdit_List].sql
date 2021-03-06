USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spOD_frmEdit_List]    Script Date: 10/18/2013 15:17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER Proc [dbo].[spOD_frmEdit_List]
	@Order_ID int
AS
BEGIN
Select Order_ID,OrderDate,IsLock,TotalAmount,PaymentAmount as TotalPayment, 
			EmpName, CustName, Address,CastPromotion
			,((TotalAmount-PaymentAmount ) - ISNULL(CastPromotion,'0')) As TotalPay
From (
	Select od.Order_ID, Convert(Varchar(10),od.OrderDate,21) as OrderDate , od.IsLock,emp.EmpName
	, cust.CustName,cust.Address,SUM(odd.ThanhTien) as TotalAmount
	,od.CastPromotion,dbo.func_PaymentOutAmount(od.Order_ID) as PaymentAmount
	From tbl_Orders od, tbl_OrderDetails odd,
			tbl_Customers cust, tbl_Employees emp
	Where od.Order_ID		=@Order_ID
		And od.Order_ID			=	odd.Order_ID
		And	od.Cust_ID			=	cust.Cust_ID
		And od.Emp_ID			=	emp.Emp_ID
	Group by od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName,cust.Address
	,odd.Form,od.CastPromotion
	) XXX
END
