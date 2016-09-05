 select OD.Order_ID, ODT.Company_ID,comp.CompanyName,
  ODT.Product_ID,
SUM(ODT.Quantity ) as SoLuongBanRa, SUM(ODT.QuantityPromotion) as SoLuongKM
,SUM(ODT.ThanhTien) as TongTienDaXuatHang, SUM(ODT.ThanhTien - ODT.TienLoi ) as TongTienPhaiTraChoNV
,SUM(ODT.TienNhapHang) as TongTienDaNhapHang, SUM(ODT.TienLoi - ODT.TienNhapHang ) as TienLoiThucTe
from tbl_OrderDetails ODT, tbl_Orders OD, tbl_Companies comp , dbo.tbl_PaymentOrders PaymentOrders
 where 
	 PaymentOrders.PaymentOrderDate Between '2013-10-20' and '2013-11-22'
 And PaymentOrders.Order_ID = OD.Order_ID 
 and OD.Order_ID = ODT .Order_ID 
 and ODT .Company_ID = comp .Company_ID 
 and OD.IsLock = 1
 group by ODT.Company_ID,comp.CompanyName, ODT.Product_ID,OD.Order_ID