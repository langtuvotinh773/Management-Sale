USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_Liabilities]    Script Date: 10/08/2013 20:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[sp_Liabilities]
As
BEGIN
	Select CustName,Address,(SUM(ThanhTien) - SUM(PaymentAmount)) as TotalPayment
from
(
	select Orders.Order_ID,Orders.Cust_ID,Customers.CustName,Customers.Address
	,SUM(OrderDetails.Quantity) as Quantity,SUM(OrderDetails.QuantityPromotion) as QuantityPromotion
	,SUM(OrderDetails.ThanhTien) as ThanhTien
	,ISNULL((
				select SUM(PaymentOrders.PaymentAmount) 
				from dbo.tbl_PaymentOrders PaymentOrders 
				where PaymentOrders.Order_ID = Orders.Order_ID
			),0) as PaymentAmount
	from dbo.tbl_Orders Orders,dbo.tbl_OrderDetails OrderDetails
	, dbo.tbl_Customers Customers
	where 
	Orders.IsLock = 0
	AND Orders.TypeOption= 1
	and Orders.Order_ID = OrderDetails.Order_ID
	and Orders.Cust_ID = Customers.Cust_ID
	group by Orders.Order_ID,Orders.Cust_ID,Customers.CustName,Customers.Address
)XX
Group By  CustName,Address
END

