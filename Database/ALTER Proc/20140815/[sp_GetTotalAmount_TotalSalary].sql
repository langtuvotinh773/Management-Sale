USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalAmount_TotalSalary]    Script Date: 08/30/2014 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetTotalAmount_TotalSalary]
	@Order_ID INT,
	@Total_ThanhTien Decimal(15,2) OUTPUT,
	@Total_TienLoi Decimal(15,2) OUTPUT,
	@_CastPromotion Decimal(15,2) OUTPUT,
	@_PercentDiscount Decimal(5,2) OUTPUT,
	@_TotalSalary Decimal(15,2) OUTPUT
	
AS
BEGIN
select @Total_ThanhTien = SUM(odt.ThanhTien) 
		,@Total_TienLoi =  SUM(odt.TienLoi) 
		,@_CastPromotion= ISNULL(od.CastPromotion,'0') 
		,@_PercentDiscount = ISNULL(od.PercentDiscount,'0') 
 from tbl_Orders od, tbl_OrderDetails odt 
 where od.Order_ID	= @Order_ID 
 AND od.Order_ID	=odt.Order_ID
 group by od.CastPromotion,od.PercentDiscount
 -- Tong thanh tien tru cho tang tien cho HD
 DECLARE  @Total_ThanhTien_Old decimal(15,2)
 SET @Total_ThanhTien_Old = @Total_ThanhTien
	SET @Total_ThanhTien = @Total_ThanhTien - @_CastPromotion 
	SET @Total_ThanhTien = @Total_ThanhTien - ((@Total_ThanhTien * @_PercentDiscount)/100)
	
	DECLARE  @_SoTienPhaiTruKhiCoKM decimal(15,2)
	select @_SoTienPhaiTruKhiCoKM = (@Total_ThanhTien_Old - @Total_ThanhTien) /SUM(Quantity)
	from tbl_OrderDetails  where Order_ID	= @Order_ID  
	------ Tien Loi
	select @Total_TienLoi = SUM(((Price - @_SoTienPhaiTruKhiCoKM) * Quantity) - (((Price - @_SoTienPhaiTruKhiCoKM) * Quantity)*PercentSalary/100))
	from tbl_OrderDetails  where Order_ID	= @Order_ID  
	--------------------------------------------------------------------
	----DECLARE  @_TotalSalaryOrder decimal(15,2)
	----select @_TotalSalaryOrder = SUM((((Quantity * (Price - @_SoTienPhaiTruKhiCoKM)) * PercentSalary)/100))
	----from tbl_OrderDetails  where Order_ID	= @Order_ID  
	----SET @_TotalSalary = @_TotalSalaryOrder
	DECLARE  @_TotalQuantity_Order decimal(15,2)
	DECLARE  @_TrungBinhGia_Order decimal(15,2)
	DECLARE  @_TotalSalaryOrder decimal(15,2)
	
	select @_TotalQuantity_Order = SUM(Quantity)
	from tbl_OrderDetails  where Order_ID	= @Order_ID  
	
	select @_TrungBinhGia_Order =  (@Total_ThanhTien / SUM(Quantity))
	from tbl_OrderDetails  where Order_ID	= @Order_ID 
	
	select @_TotalSalaryOrder = SUM((((Quantity * @_TrungBinhGia_Order) * PercentSalary)/100))
	from tbl_OrderDetails  where Order_ID	= @Order_ID  
	SET @_TotalSalary = @_TotalSalaryOrder
END