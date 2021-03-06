USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_Liabilities]    Script Date: 10/19/2013 00:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[sp_Liabilities]
As
BEGIN
	Select CustName,Address,((SUM(ThanhTien) - ISNULL(CastPromotion,'0')) - SUM(PaymentAmount)) as TotalPayment, CastPromotion
from
(
	select Orders.Order_ID,Orders.Cust_ID,Customers.CustName,Customers.Address
	,SUM(OrderDetails.Quantity) as Quantity,SUM(OrderDetails.QuantityPromotion) as QuantityPromotion
	,SUM(OrderDetails.ThanhTien) as ThanhTien, Orders.CastPromotion as CastPromotion
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
	group by Orders.Order_ID,Orders.Cust_ID,Customers.CustName,Customers.Address,Orders.CastPromotion
)XX
Group By  CustName,Address,CastPromotion
END

