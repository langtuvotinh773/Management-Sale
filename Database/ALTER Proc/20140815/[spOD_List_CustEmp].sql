ALTER     Proc [dbo].[spOD_List_CustEmp]
	@Begin DateTime,
	@End	DateTime,
	@Emp_ID Int,
	@Cust_ID int
AS
BEGIN
-- create table Temp
DECLARE  @SelectlistDATA TABLE ( 
    Order_ID int,
    OrderDate datetime,
    IsLock bit,
    TotalAmount decimal(15,1),
    TotalPayment decimal(15,1),
    EmpName nvarchar(300),
    CustName nvarchar(300),
    Address nvarchar(300),
	CastPromotion decimal(15,1),
	PercentDiscount decimal(15,1),
	TotalPay decimal(15,1)
  ) 
insert into @SelectlistDATA (Order_ID,OrderDate,IsLock
			,TotalAmount
			,TotalPayment
			,EmpName,CustName,Address
			,CastPromotion,PercentDiscount
			,TotalPay) 
---- START VALUE INSERT INTO #SelectlistDATA
Select Order_ID,OrderDate,IsLock,Sum(TotalAmount) as TotalAmount,PaymentAmount as TotalPayment, 
			EmpName, CustName,Address,CastPromotion,PercentDiscount,
			((Sum(TotalAmount) -PaymentAmount ) - ISNULL(CastPromotion,'0')) As TotalPay
From (
	Select od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName,cust.Address
				,SUM(odd.ThanhTien) as TotalAmount,od.CastPromotion,od.PercentDiscount
			 ,dbo.func_PaymentOutAmount(od.Order_ID) as PaymentAmount
	From tbl_Orders od, tbl_OrderDetails odd,
			tbl_Customers cust, tbl_Employees emp
	Where od.OrderDate		Between @Begin And @End
			And od.Emp_ID			=	@Emp_ID
			And od.Cust_ID			=	@Cust_ID
			And od.Order_ID			=	odd.Order_ID
			And	od.Cust_ID			=	cust.Cust_ID
			And od.Emp_ID			=	emp.Emp_ID
			and od.TypeOption = 1
	Group by od.Order_ID, od.OrderDate, od.IsLock,emp.EmpName, cust.CustName,cust.Address,odd.Form ,od.CastPromotion,od.PercentDiscount
	) XXX
	Group by Order_ID,OrderDate,IsLock,EmpName, CustName,Address,PaymentAmount ,CastPromotion,PercentDiscount
	Order By OrderDate desc
---- END VALUE INSERT INTO #SelectlistDATA
select Order_ID,OrderDate,IsLock
			,(ISNULL(TotalAmount,'0') - ISNULL(CastPromotion,'0')) - (((TotalAmount - ISNULL(CastPromotion,'0'))*ISNULL(PercentDiscount,'0'))/100)  as TotalAmount
			,ISNULL(TotalPayment,'0') as TotalPayment
			,EmpName,CustName,Address
			,ISNULL(CastPromotion,'0') as CastPromotion,ISNULL(PercentDiscount,'0') as PercentDiscount
			,(ISNULL(TotalAmount,'0') - ISNULL(CastPromotion,'0')) - (((TotalAmount - ISNULL(CastPromotion,'0'))*ISNULL(PercentDiscount,'0'))/100) - ISNULL(TotalPayment,'0')  as TotalPay
from @SelectlistDATA

END

