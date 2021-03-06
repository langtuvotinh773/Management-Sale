USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalAmount]    Script Date: 08/17/2014 12:41:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetTotalAmount]
	@Order_ID INT,
	@Total_ThanhTien Decimal OUTPUT,
	@_CastPromotion Decimal OUTPUT,
	@_PercentDiscount Decimal OUTPUT
AS
BEGIN
select @Total_ThanhTien = SUM(odt.ThanhTien) ,@_CastPromotion= ISNULL(od.CastPromotion,'0') ,@_PercentDiscount = ISNULL(od.PercentDiscount,'0') 
 from tbl_Orders od, tbl_OrderDetails odt 
 where od.Order_ID	= @Order_ID 
 AND od.Order_ID	=odt.Order_ID
 group by od.CastPromotion,od.PercentDiscount
 -- Tong thanh tien tru cho tang tien cho HD
	SET @Total_ThanhTien = @Total_ThanhTien - @_CastPromotion 
	SET @Total_ThanhTien = @Total_ThanhTien - ((@Total_ThanhTien * @_PercentDiscount)/100)
END