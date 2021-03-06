USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIO_List_Com]    Script Date: 10/15/2013 23:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER     Proc [dbo].[spIO_List_Com] --'2012-02-08','2012-02-10'
	@BeginDate DateTime,
	@EndDate DateTime,
	@Company Int
As
BEGIN
Select ImportOrder_ID, CompanyName, ImportOrderDate, IsLock, OrderCompany_ID, 
		 TotalAmount, PaymentAmount, (TotalAmount-PaymentAmount) as Paymount,CastPromotion
From (
			SElect [io].ImportOrder_ID , com.CompanyName, [io].ImportOrderDate,[io].OrderCompany_ID,
					 [io].IsLock,  Sum((iod.Quantity * iod.Price)-((iod.Quantity * iod.Price) * (iod.Discount + iod.PercentPromotion)/100.00)) -[io].CastPromotion  as TotalAmount,
					  dbo.func_PaymentAmount([io].ImportOrder_ID) as PaymentAmount,[io].CastPromotion
					 
			From tbl_ImportOrders [io], tbl_Companies com, tbl_Products pro,
					tbl_ImportOrderDetails iod--, tbl_PaymentIntputs [pi]
			Where [io].ImportOrderDate Between @BeginDate And @EndDate
			And 	com.Company_ID			=	@Company
			And 	[io].ImportOrder_ID	=	[iod].ImportOrder_ID
			And	[iod].Product_ID		=	pro.Product_ID
			--And	[io].ImportOrder_ID	=	[pi].ImportOrder_ID
			And	[io].Company_ID		=	com.Company_ID
			And 	[io].TypeImportOrder = 1
			Group by [io].ImportOrder_ID , com.CompanyName, [io].ImportOrderDate,[io].OrderCompany_ID,
						[io].IsLock,[io].CastPromotion
		) XXX
Order By ImportOrder_ID DESC
END

