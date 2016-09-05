USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteImportOrder]    Script Date: 10/19/2013 10:47:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[spDeleteImportOrder]
	@Ordert_ID int
AS
BEGIN
Declare @check_Delete Int
	if(select COUNT(*) as check_Delete from tbl_ImportOrderDetails where ImportOrder_ID = @Ordert_ID) < 1
	begin
		Delete From dbo.tbl_PaymentIntputs where ImportOrder_ID = @Ordert_ID
		Delete From tbl_ImportOrderDetails where ImportOrder_ID = @Ordert_ID
		Delete From tbl_ImportOrders where ImportOrder_ID = @Ordert_ID
	end	
END

