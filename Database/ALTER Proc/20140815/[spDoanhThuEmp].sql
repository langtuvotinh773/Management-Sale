USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spDoanhThuEmp]    Script Date: 08/17/2014 21:57:24 ******/
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

-- create table Temp
DECLARE  @spDoanhThuEmp TABLE ( 
	IsLock bit,
    Order_ID int,
    Cust_ID int,
    CustName nvarchar(50),
    Emp_ID int,
    EmpName nvarchar(50),
    TotalMoney_NotSalary decimal(15,1),
    TotalMoney_Salary decimal(15,1),
    TotalSalaryEmp decimal(15,1),
	SalaryOfOrder decimal(15,1),
	CastPromotion decimal(15,1),
	PercentDiscount decimal(4,1)
  ) 
  insert into @spDoanhThuEmp 
  ---- START VALUE INSERT INTO @spDoanhThuEmp 
	select Orders.IsLock,Orders.Order_ID,Orders.Cust_ID,Cust.CustName,Orders.Emp_ID,Emp.EmpName
	--, OrdersDetail.Product_ID
	,(SUm(OrdersDetail.ThanhTien) - ISNULL(Orders.CastPromotion,'0')) as TotalMoney_NotSalary ---
	,(SUm(OrdersDetail.TienLoi) - ISNULL(Orders.CastPromotion,'0')) as TotalMoney_Salary
	--,((SUm(OrdersDetail.ThanhTien) - ISNULL(Orders.CastPromotion,'0'))
	--	 - (SUm(OrdersDetail.TienLoi) - ISNULL(Orders.CastPromotion,'0'))) as TotalSalaryEmp
	, 0 as TotalSalaryEmp
	, ISNULL((SELECT  SUM(Salaries.TotalSalary) from dbo.tbl_Salaries Salaries where Salaries.Order_ID =  Orders.Order_ID ),'0') as SalaryOfOrder
	,ISNULL(Orders.CastPromotion,'0') as CastPromotion , ISNULL(Orders.PercentDiscount,'0') as PercentDiscount
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
group by Orders.IsLock,Orders.Order_ID,Orders.Cust_ID,Orders.Emp_ID,Cust.CustName,Emp.EmpName,Orders.CastPromotion,Orders.PercentDiscount
  ---- END VALUE INSERT INTO @spDoanhThuEmp 
  select	IsLock,
			Order_ID ,
			Cust_ID ,
			CustName ,
			Emp_ID ,
			EmpName ,
			TotalMoney_NotSalary -  ((TotalMoney_NotSalary *PercentDiscount)/100) as TotalMoney_NotSalary,
			TotalMoney_Salary -  ((TotalMoney_Salary *PercentDiscount)/100) as TotalMoney_Salary,
			
			TotalMoney_NotSalary -  ((TotalMoney_NotSalary *PercentDiscount)/100)
			- TotalMoney_Salary -  ((TotalMoney_Salary *PercentDiscount)/100)
			as TotalSalaryEmp,
			
			SalaryOfOrder ,
			CastPromotion ,
			PercentDiscount 
from @spDoanhThuEmp 
End

-- spDoanhThuEmp 50,'2014-07-17','2014-08-17'