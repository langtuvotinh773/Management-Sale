USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spOD_List_Emp]    Script Date: 06/21/2014 11:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER     Proc [dbo].[spOD_List_Emp]
	@Begin DateTime,
	@End	DateTime,
	@Emp_ID Int
AS
BEGIN

Select Order_ID,OrderDate,IsLock,Sum(TotalAmount) as TotalAmount,PaymentAmount as TotalPayment, 
			EmpName, CustName,Address,CastPromotion,
			((Sum(TotalAmount) -PaymentAmount ) - ISNULL(CastPromotion,'0')) As TotalPay
From (
	Select od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName,cust.Address
			,SUM(odd.ThanhTien) as TotalAmount, dbo.func_PaymentOutAmount(od.Order_ID) as PaymentAmount
			 ,od.CastPromotion
	From tbl_Orders od, tbl_OrderDetails odd, 
			tbl_Customers cust, tbl_Employees emp
	Where od.OrderDate		Between @Begin And @End
	And   od.Emp_ID			=	@Emp_ID
	And 	od.Order_ID			=	odd.Order_ID
	
	And	od.Cust_ID			=	cust.Cust_ID
	And 	od.Emp_ID			=	emp.Emp_ID
	and od.TypeOption = 1
	Group by od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName,cust.Address,odd.Form ,od.CastPromotion
	) XXX
	Group by Order_ID,OrderDate,IsLock,EmpName, CustName,Address,PaymentAmount,CastPromotion
	Order By OrderDate

END


-- spOD_List_CustEmp '2013-09-18', '2013-10-19', 129,50
