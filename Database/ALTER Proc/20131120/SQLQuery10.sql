select 
		--RowNum = COUNT(DISTINCT PaymentOrders.Order_ID)
		RowNum = ROW_NUMBER() OVER(ORDER BY PaymentOrders.Order_ID)
	 ,PaymentOrders.Order_ID, SUM(PaymentOrders.PaymentAmount) as PaymentAmount
from  dbo.tbl_PaymentOrders PaymentOrders
where PaymentOrders.PaymentOrderDate  Between '2013-10-20' and '2013-11-21'
group by PaymentOrders.Order_ID