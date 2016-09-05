ALTER PROCEDURE sp_GetTotalAmount
	@Order_ID INT,
	@Total_ThanhTien Decimal OUTPUT,
	@_CastPromotion Decimal OUTPUT,
	@_PercentDiscount Decimal OUTPUT
AS
BEGIN
select @Total_ThanhTien = SUM(odt.ThanhTien) ,@_CastPromotion= od.CastPromotion,@_PercentDiscount = od.PercentDiscount
 from tbl_Orders od, tbl_OrderDetails odt 
 where od.Order_ID	= @Order_ID 
 AND od.Order_ID	=odt.Order_ID
 group by od.CastPromotion,od.PercentDiscount
 -- Tong thanh tien tru cho tang tien cho HD
	SET @Total_ThanhTien = @Total_ThanhTien - @_CastPromotion 
	-- tong tien tinh chiet suat
	SET @Total_ThanhTien = @Total_ThanhTien - ((@Total_ThanhTien * @_PercentDiscount)/100)
END