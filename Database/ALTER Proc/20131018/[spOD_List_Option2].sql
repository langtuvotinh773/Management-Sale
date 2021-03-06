USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spOD_List_Option2]    Script Date: 10/18/2013 16:58:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   Proc [dbo].[spOD_List_Option2] --'2012-04-01','2012-04-01']
	@Begin DateTime,
	@End	DateTime
AS
BEGIN

Select Order_ID,OrderDate,IsLock,Sum(TotalAmount) as TotalAmount,PaymentAmount as TotalPayment, 
			EmpName, CustName,CastPromotion,
			((Sum(TotalAmount) -PaymentAmount ) - ISNULL(CastPromotion,'0')) As TotalPay
From (
	Select od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName
				,SUM(odd.ThanhTien) as TotalAmount, dbo.func_PaymentOutAmount(od.Order_ID) as PaymentAmount
			 ,od.CastPromotion
	From tbl_Orders od, tbl_OrderDetails odd,
			tbl_Customers cust, tbl_Employees emp
	Where od.OrderDate		Between @Begin And @End
	And 	od.Order_ID			=	odd.Order_ID
	
	And	od.Cust_ID			=	cust.Cust_ID
	And 	od.Emp_ID			=	emp.Emp_ID
	and od.TypeOption = 0
	Group by od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName,odd.Form ,od.CastPromotion
	) XXX
	Group by Order_ID,OrderDate,IsLock,EmpName, CustName,PaymentAmount,CastPromotion
	Order By OrderDate desc

END
