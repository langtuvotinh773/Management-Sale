USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spGetQuantityOrdered]    Script Date: 10/16/2013 22:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spGetQuantityOrdered]
@Product_ID int,
@Price decimal(15,5),
@Price_Import decimal(15,5),
@OrderDate datetime
as 
begin
	select  SUM(OrderDetails.Quantity) as totalQuantity,SUM(OrderDetails.QuantityPromotion) as totalQuantityPromotion
	from dbo.tbl_OrderDetails OrderDetails,dbo.tbl_Orders Orders
	where OrderDetails.Product_ID = @Product_ID
		and OrderDetails.Price =@Price
		and OrderDetails.Price_Import  =@Price_Import
		and Orders.OrderDate >= @OrderDate
	group by OrderDetails.Product_ID,Orders.OrderDate
End
