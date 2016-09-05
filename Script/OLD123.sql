select 
		RowNum = ROW_NUMBER() OVER(ORDER BY PaymentOrders.Order_ID)
	--RowNum = COUNT(DISTINCT PaymentOrders.Order_ID)
	 ,PaymentOrders.Order_ID, SUM(PaymentOrders.PaymentAmount) as PaymentAmount
	INTO #Temp_PaymentOrders
from  dbo.tbl_PaymentOrders PaymentOrders
where PaymentOrders.PaymentOrderDate  Between '2014-07-15' and '2014-08-18'
group by PaymentOrders.Order_ID
---------------------------------------------------------------------------
DECLARE @MaxRownum INT
SET @MaxRownum = (SELECT MAX(RowNum) FROM #Temp_PaymentOrders)
DECLARE @Iter INT
SET @Iter = (SELECT MIN(RowNum) FROM #Temp_PaymentOrders)


