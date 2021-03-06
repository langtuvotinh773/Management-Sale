USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIO_ListDetail_OrderNo]    Script Date: 10/15/2013 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   Proc [dbo].[spIO_ListDetail_OrderNo] --'2012-02-05','2012-02-11'
	@OrderNo NVarchar(100)
As
BEGIN

			SElect [io].ImportOrder_ID , iod.ImportOrderDetail_ID, pro.ProductName, [io].IsLock,iod.PriceActual,iod.Price,
					  iod.Quantity, iod.QuantityPromotion,iod.Discount, iod.PercentPromotion,
					(iod.Quantity * iod.Price)-((iod.Quantity * iod.Price) * (iod.Discount + iod.PercentPromotion)/100.00) as Amount
					 
					 
			From tbl_ImportOrders [io],  tbl_Products pro, tbl_ImportOrderDetails iod
			Where [io].OrderCompany_ID =@OrderNo 
			And 	[io].ImportOrder_ID	=	[iod].ImportOrder_ID
			And	[iod].Product_ID		=	pro.Product_ID
			And 	[io].TypeImportOrder = 1
			Order by iod.ImportOrderDetail_ID desc
			
		

END

