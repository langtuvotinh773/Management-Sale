USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spOD_Ins]    Script Date: 08/15/2014 21:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  Proc [dbo].[spOD_Ins]
	@Cust_ID Int,
	@Emp_Id Int,
	@TypeOption int,
	@CastPromotion decimal (12,2),
	@Order_ID Int output,
	@PercentDiscount decimal(4,1)
As
BEGIN
	Insert Into tbl_Orders (Cust_ID, Emp_ID, OrderDate, Note, IsLock,TypeOption,CastPromotion,PercentDiscount)
	Values (@Cust_ID,@Emp_ID, Convert(Varchar(10),GetDate(),21),'', 0,@TypeOption,@CastPromotion,@PercentDiscount)
	SElect @Order_ID = @@IDentity
END

