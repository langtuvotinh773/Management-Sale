USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalAmount_TotalSalary]    Script Date: 08/25/2014 20:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetSoTienPhaiTruKhiCoKM] --
	@Order_ID INT,
	@_SoTienPhaiTruKhiCoKM Decimal(20,2)OUTPUT
	
AS
BEGIN
Declare @Total_ThanhTien Decimal(20,2)
Declare @Total_ThanhTien_Old Decimal(20,2) 
Declare @_CastPromotion Decimal(20,2)
Declare @_PercentDiscount Decimal(20,2)
Declare @_TotalQuantity_Order Decimal(20,2)

select @Total_ThanhTien = SUM(odt.ThanhTien)
		,@_TotalQuantity_Order = SUM(odt.Quantity) 
		,@_CastPromotion = ISNULL(od.CastPromotion,'0') 
		,@_PercentDiscount = ISNULL(od.PercentDiscount,'0') 
 from tbl_Orders od, tbl_OrderDetails odt 
 where od.Order_ID	= @Order_ID  AND od.Order_ID	=odt.Order_ID
  group by od.CastPromotion,od.PercentDiscount
  
 SET @Total_ThanhTien_Old = @Total_ThanhTien
 -- Tong thanh tien tru cho tang tien cho HD
	SET @Total_ThanhTien = @Total_ThanhTien - @_CastPromotion 
	SET @Total_ThanhTien = @Total_ThanhTien - ((@Total_ThanhTien * @_PercentDiscount)/100)
	SET @_SoTienPhaiTruKhiCoKM = (@Total_ThanhTien_Old-@Total_ThanhTien)/@_TotalQuantity_Order
END