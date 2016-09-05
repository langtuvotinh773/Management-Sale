declare @_TrungBinhGiaBan decimal(15,2)
SET @_TrungBinhGiaBan = 54087.91
select OD.Order_ID
		,ODT.Company_ID,comp.CompanyName
		,SUM(ODT.Quantity ), SUM(ODT.QuantityPromotion)
		,SUM(ODT.Quantity * @_TrungBinhGiaBan) as ThanhTien
		, SUM(ODT.Quantity *@_TrungBinhGiaBan) -  SUM((ODT.Quantity *@_TrungBinhGiaBan) - (((ODT.Quantity *@_TrungBinhGiaBan)*ODT.PercentSalary)/100) ) as TongTienPhaiTraChoNV
		,SUM(ODT.TienNhapHang) as TienNhapHang
		,SUM(ODT.Quantity *@_TrungBinhGiaBan) - SUM(((ODT.Quantity *@_TrungBinhGiaBan)*ODT.PercentSalary)/100) - SUM(ODT.TienNhapHang)
		,'0'
   from tbl_OrderDetails ODT, tbl_Orders OD, tbl_Companies comp 
   Where
	 OD.Order_ID = 167
	 and OD.Order_ID = ODT .Order_ID 
	 and ODT .Company_ID = comp .Company_ID 
	-- and OD.IsLock = 1
	group by OD.Order_ID,ODT.Company_ID,comp.CompanyName
	
	--  select * from dbo.tbl_OrderDetails where  Order_ID = 167