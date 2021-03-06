USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[sp_Liabilities]    Script Date: 05/12/2014 09:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[sp_Liabilities]
	@Emp_ID int
As
BEGIN
IF(@Emp_ID = 0)
	BEGIN
		Select CustName,Address,((SUM(ThanhTien) - ISNULL(CastPromotion,'0')) - SUM(PaymentAmount)) as TotalPayment, CastPromotion
		from
		(
			select Orders.Order_ID,Orders.Cust_ID,Orders.Emp_ID ,Customers.CustName,Customers.Address
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
			group by Orders.Order_ID,Orders.Cust_ID,Customers.CustName,Customers.Address,Orders.CastPromotion,Orders.Emp_ID
		)XX
		Group By  CustName,Address,CastPromotion
	END
	ELSE
	BEGIN
		Select CustName,Address,((SUM(ThanhTien) - ISNULL(CastPromotion,'0')) - SUM(PaymentAmount)) as TotalPayment, CastPromotion
		from
		(
			select Orders.Order_ID,Orders.Cust_ID,Orders.Emp_ID ,Customers.CustName,Customers.Address
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
			AND Orders.Emp_ID = @Emp_ID
			AND Orders.TypeOption= 1
			and Orders.Order_ID = OrderDetails.Order_ID
			and Orders.Cust_ID = Customers.Cust_ID
			group by Orders.Order_ID,Orders.Cust_ID,Customers.CustName,Customers.Address,Orders.CastPromotion,Orders.Emp_ID
		)XX
		Group By  CustName,Address,CastPromotion
	END
	


END

