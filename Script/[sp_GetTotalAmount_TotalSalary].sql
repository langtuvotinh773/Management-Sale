Declare @Total_ThanhTien Decimal(15,2) 
Declare @_CastPromotion Decimal(15,2)
Declare @_PercentDiscount Decimal(15,2)
Declare @_TotalSalary Decimal(15,2)
Declare @Total_TienLoi Decimal(15,2)
declare @_TrungBinhGiaBan Decimal(15,2)
-- Load Tong thanh tien
exec sp_GetTotalAmount_TotalSalary @Order_ID =167, @Total_ThanhTien = @Total_ThanhTien output,@Total_TienLoi = @Total_TienLoi output
	,@_CastPromotion = @_CastPromotion output,@_PercentDiscount =@_PercentDiscount output
	,@_TotalSalary = @_TotalSalary output,@_TrungBinhGiaBan = @_TrungBinhGiaBan output
 -- select DATA
 select @Total_ThanhTien,@Total_TienLoi,@_CastPromotion
	,@_PercentDiscount,@_TotalSalary,@_TrungBinhGiaBan
 