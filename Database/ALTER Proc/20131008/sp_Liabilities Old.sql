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
	SElect Cust_ID,CustName, [Address],(Sum(TotalAmount)-PaymentAmount) as TotalPayment
	From (
		SElect cust.Cust_ID,cust.CustName , cust.[Address] ,
				Case odd.Form When N'GIẢM GIÁ' THen
 				Sum(Convert(Float,(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount + odd.PercentPromotion)/100.00)))
 				Else Sum(Convert(Float,(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount )/100.00))) End   as TotalAmount,
				dbo.func_PaymentOutAmount(od.Order_ID) as PaymentAmount
		From tbl_Customers cust, tbl_Orders od, tbl_OrderDetails odd
		Where cust.Cust_ID=od.Cust_ID 
		And od.Order_ID =odd.Order_ID 
		And od.IsLock=0
		AND od.TypeOption= 1
		Group by cust.Cust_ID, cust.CustName , cust.[Address], odd.Form ,od.Order_ID
		)XX
	Group By  Cust_ID,CustName, [Address],PaymentAmount
END

