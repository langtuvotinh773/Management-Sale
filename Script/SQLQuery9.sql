select PaymentOrders.Order_ID
from  dbo.tbl_PaymentOrders PaymentOrders
where PaymentOrders.PaymentOrderDate  Between '2014-07-15' and '2014-08-18'
group by PaymentOrders.Order_ID
--'2013-10-20', '2013-11-21'