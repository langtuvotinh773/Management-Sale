USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spReportRevenune_SelectOrder]    Script Date: 08/25/2014 20:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spReportRevenune_SelectOrder]
@FromDate datetime,
@ToDate datetime
as
begin
select 
		RowNum = ROW_NUMBER() OVER(ORDER BY PaymentOrders.Order_ID)
	--RowNum = COUNT(DISTINCT PaymentOrders.Order_ID)
	 ,PaymentOrders.Order_ID, SUM(PaymentOrders.PaymentAmount) as PaymentAmount
	INTO #Temp_PaymentOrders
from  dbo.tbl_PaymentOrders PaymentOrders
where PaymentOrders.PaymentOrderDate  Between @FromDate and @ToDate
group by PaymentOrders.Order_ID
---------------------------------------------------------------------------
DECLARE @MaxRownum INT
SET @MaxRownum = (SELECT MAX(RowNum) FROM #Temp_PaymentOrders)
DECLARE @Iter INT
SET @Iter = (SELECT MIN(RowNum) FROM #Temp_PaymentOrders)
---- START Declare ALL parameter
DECLARE  @tblTemp_DoanhThu_SELECT TABLE(
		Id int identity(1,1) primary key,
		Order_ID int,
		Company_ID int,
		CompanyName nvarchar(300),
		SoLuongBanRa Decimal(20,2),
		SoLuongKM Decimal(20,2),
		TongTienDaXuatHang Decimal(20,2),
		TongTienPhaiTraChoNV Decimal(20,2),
		TongTienDaNhapHang Decimal(20,2),
		LoiTrenPhanTramMaKHDaTra Decimal(20,2),
		PaymentAmount  Decimal(20,2)
		)		
---END Declare ALL parameter
WHILE @Iter <= @MaxRownum
BEGIN
	-- Start Set Data
	Declare @paOrder_ID int
	Declare @paPaymentAmount Decimal(15,2)
    SELECT @paOrder_ID = PaymentOrders.Order_ID,@paPaymentAmount = PaymentOrders.PaymentAmount
    FROM #Temp_PaymentOrders  PaymentOrders
    WHERE RowNum = @Iter
   -- End set data
---------------------------------------
Declare @_SoTienPhaiTruKhiCoKM Decimal(20,2)
-- SoTienPhaiTruKhiCoKM
exec [sp_GetSoTienPhaiTruKhiCoKM] @Order_ID =@paOrder_ID
	, @_SoTienPhaiTruKhiCoKM = @_SoTienPhaiTruKhiCoKM output
	

declare @iStatus bit 
select @iStatus = IsLock from dbo.tbl_Orders where Order_ID = @paOrder_ID

if @iStatus = 1
BEGIN
-- Insert DAT 
Insert into @tblTemp_DoanhThu_SELECT (Order_ID,Company_ID,CompanyName,SoLuongBanRa,SoLuongKM,TongTienDaXuatHang,TongTienPhaiTraChoNV,TongTienDaNhapHang,LoiTrenPhanTramMaKHDaTra)
select 
		OD.Order_ID as Order_ID
		,ODT.Company_ID as Company_ID
		,comp.CompanyName as CompanyName
		,SUM(ODT.Quantity ) as SoLuongBanRa
		, SUM(ODT.QuantityPromotion) as SoLuongKM
		,SUM(ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) as TongTienDaXuatHang
		, (SUM(ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) -  SUM((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) - (((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM))*ODT.PercentSalary)/100) )) as TongTienPhaiTraChoNV
		,SUM(ODT.TienNhapHang) as TongTienDaNhapHang
		, (SUM(((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) - (((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM))*ODT.PercentSalary)/100) ) - ODT.TienNhapHang )) as LoiTrenPhanTramMaKHDaTra
		--, SUM(ODT.Quantity ) * @LoiTrenTungSP as LoiTrenPhanTramMaKHDaTra
   from tbl_OrderDetails ODT, tbl_Orders OD, tbl_Companies comp 
   Where
	 OD.Order_ID = @paOrder_ID
	 and OD.Order_ID = ODT .Order_ID 
	 and ODT .Company_ID = comp .Company_ID 
	-- and OD.IsLock = 1
	group by ODT.Company_ID,comp.CompanyName,OD.Order_ID
END
ELSE
BEGIN
-- SET DATA
--------------------------------------	
-- Tong so luong ban cho 1 hoa don
declare @TotalQuantity_Order int
select @TotalQuantity_Order = SUM(ODT.Quantity)  from tbl_OrderDetails ODT where Order_ID = @paOrder_ID
-- Thanh tien cua 1 hoa don
declare @ThanhTienOrder decimal(15,2)
select @ThanhTienOrder = (SUM(ODT.ThanhTien) - OD.CastPromotion) - (((SUM(ODT.ThanhTien) - OD.CastPromotion)*PercentDiscount)/100)
from tbl_Orders OD, tbl_OrderDetails ODT 
where ODT.Order_ID = @paOrder_ID AND OD.Order_ID = ODT.Order_ID
group by OD.CastPromotion,OD.PercentDiscount
-- % tien loi ma khach hang da tra cho HD
Declare @PhanTramTienLoiThucTe decimal(15,2) = 0
SET @PhanTramTienLoiThucTe = (@paPaymentAmount * 100)/@ThanhTienOrder
---------------
declare @iTienLoiThucTeChoHDTraTienDu decimal(15,2)
select @iTienLoiThucTeChoHDTraTienDu = (SUM(((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) - (((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM))*ODT.PercentSalary)/100) ) - ODT.TienNhapHang )) from tbl_OrderDetails ODT where Order_ID = @paOrder_ID
Declare @TienLoiThucTe decimal(20,2) = 0
SET @TienLoiThucTe = ((@iTienLoiThucTeChoHDTraTienDu*@PhanTramTienLoiThucTe)/100)
--------------------
declare @LoiTrenTungSP decimal(20,2)
SET @LoiTrenTungSP = @TienLoiThucTe/@TotalQuantity_Order

-- Insert DAT 
Insert into @tblTemp_DoanhThu_SELECT (Order_ID,Company_ID,CompanyName,SoLuongBanRa,SoLuongKM,TongTienDaXuatHang,TongTienPhaiTraChoNV,TongTienDaNhapHang,LoiTrenPhanTramMaKHDaTra)
--SELECT DATA--
	SELECT
		OD.Order_ID as Order_ID
		,ODT.Company_ID as Company_ID
		,comp.CompanyName as CompanyName
		,SUM(ODT.Quantity ) as SoLuongBanRa
		, SUM(ODT.QuantityPromotion) as SoLuongKM
		,SUM(ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) as TongTienDaXuatHang
		, (SUM(ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) -  SUM((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) - (((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM))*ODT.PercentSalary)/100) )) as TongTienPhaiTraChoNV
		,SUM(ODT.TienNhapHang) as TongTienDaNhapHang
		--, (SUM(((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM)) - (((ODT.Quantity *(ODT.Price - @_SoTienPhaiTruKhiCoKM))*ODT.PercentSalary)/100) ) - ODT.TienNhapHang )) as LoiTrenPhanTramMaKHDaTra
		, SUM(ODT.Quantity ) * @LoiTrenTungSP as LoiTrenPhanTramMaKHDaTra
   from tbl_OrderDetails ODT, tbl_Orders OD, tbl_Companies comp 
   Where
	 OD.Order_ID = @paOrder_ID
	 and OD.Order_ID = ODT .Order_ID 
	 and ODT .Company_ID = comp .Company_ID 
	-- and OD.IsLock = 1
	group by ODT.Company_ID,comp.CompanyName,OD.Order_ID
END
   --
    SET @Iter = @Iter + 1
END

DROP TABLE #Temp_PaymentOrders

select Company_ID,CompanyName
		,SUM(SoLuongBanRa) as SoLuongBanRa 
		,SUM(SoLuongKM) as SoLuongKM
		,SUM(TongTienDaXuatHang) as TongTienDaXuatHang
		,SUM(TongTienPhaiTraChoNV) as TongTienPhaiTraChoNV
		,SUM(TongTienDaNhapHang) as TongTienDaNhapHang
		,SUM(LoiTrenPhanTramMaKHDaTra) as LoiTrenPhanTramMaKHDaTra
		--, SUM(PaymentAmount) as PaymentAmount
		--,SUM(TienLoiThucTe) as TienLoiThucTe
from @tblTemp_DoanhThu_SELECT DoanhThu
group by Company_ID,CompanyName



end

-- spReportRevenune_SelectOrder '2013-10-20', '2013-11-21'
-- select * from dbo.tbl_PaymentOrders PaymentOrders

--469200.00
--147058.65