USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spDoanhThuEmp]    Script Date: 10/19/2013 00:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spDoanhThuEmp]
@Emp_ID int,
--@Cust_ID int,
@FromDate datetime,
@ToDate datetime
as
begin
	select Orders.IsLock,Orders.Order_ID,Orders.Cust_ID,Cust.CustName,Orders.Emp_ID,Emp.EmpName
	--, OrdersDetail.Product_ID
	,(SUm(OrdersDetail.ThanhTien) - ISNULL(Orders.CastPromotion,'0')) as TotalMoney_NotSalary 
	,(SUm(OrdersDetail.TienLoi) - ISNULL(Orders.CastPromotion,'0')) as TotalMoney_Salary,
	((SUm(OrdersDetail.ThanhTien) - ISNULL(Orders.CastPromotion,'0'))
		 - (SUm(OrdersDetail.TienLoi) - ISNULL(Orders.CastPromotion,'0'))) as TotalSalaryEmp
	, ISNULL((SELECT  SUM(Salaries.TotalSalary) from dbo.tbl_Salaries Salaries where Salaries.Order_ID =  Orders.Order_ID ),'0') as SalaryOfOrder
	,ISNULL(Orders.CastPromotion,'0')
from tbl_Orders Orders
	LEFT JOIN tbl_OrderDetails OrdersDetail
	ON Orders.Order_ID = OrdersDetail.Order_ID
	LEFT JOIN tbl_Employees Emp
	ON Orders.Emp_ID = Emp.Emp_ID 
	LEFT JOIN tbl_Customers Cust
	ON Orders.Cust_ID = Cust.Cust_ID
where  Orders.OrderDate between @FromDate and @ToDate
		and Orders.Emp_ID = @Emp_ID
		--and Orders.IsLock =1 -- True
group by Orders.IsLock,Orders.Order_ID,Orders.Cust_ID,Orders.Emp_ID,Cust.CustName,Emp.EmpName,Orders.CastPromotion
End

-- spDoanhThuEmp 50,'2013-09-19','2013-10-19'