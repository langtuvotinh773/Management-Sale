USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spReportRevenune_SelectOrder]    Script Date: 08/18/2014 20:42:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spReportRevenune_SelectOrder]
@FromDate datetime,
@ToDate datetime
as
begin
---- select OD.Order_ID, ODT.Company_ID,comp.CompanyName,
----  ODT.Product_ID,
----SUM(ODT.Quantity ) as SoLuongBanRa, SUM(ODT.QuantityPromotion) as SoLuongKM
----,SUM(ODT.ThanhTien) as TongTienDaXuatHang, SUM(ODT.ThanhTien - ODT.TienLoi ) as TongTienPhaiTraChoNV
----,SUM(ODT.TienNhapHang) as TongTienDaNhapHang, SUM(ODT.TienLoi - ODT.TienNhapHang ) as TienLoiThucTe
----from tbl_OrderDetails ODT, tbl_Orders OD, tbl_Companies comp , dbo.tbl_PaymentOrders PaymentOrders
---- where 
----	 PaymentOrders.PaymentOrderDate Between @FromDate and @ToDate
---- And PaymentOrders.Order_ID = OD.Order_ID 
---- and OD.Order_ID = ODT .Order_ID 
---- and ODT .Company_ID = comp .Company_ID 
---- and OD.IsLock = 1
---- group by ODT.Company_ID,comp.CompanyName, ODT.Product_ID,OD.Order_ID

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
DECLARE  @tblTemp_DoanhThu TABLE(
		Id int identity(1,1) primary key,
		Order_ID int,
		Cust_ID nvarchar(300),
		Emp_ID nvarchar(300),
		SoLuongBanRa Decimal(20,2),
		SoLuongKM Decimal(20,2),
		TongTienDaXuatHang Decimal(20,2),
		TongTienPhaiTraChoNV Decimal(20,2),
		TongTienDaNhapHang Decimal(20,2),
		TienLoiThucTeChoHDTraTienDu Decimal(20,2),
		PaymentAmount  Decimal(20,2),
		TienLoiThucTe Decimal(20,2)
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
	  ---- START Declare ALL parameter
			Declare @iTotalPaymentAmount Decimal(20,2) = 0
			Declare @iOrder_ID int
			Declare @iCust_ID nvarchar(300)
			Declare @iEmp_ID nvarchar(300)
			Declare @iSoLuongBanRa Decimal(20,2) = 0
			Declare @iSoLuongKM Decimal(20,2) = 0
			Declare @iTongTienDaXuatHang Decimal(20,2) = 0
			Declare @iTongTienPhaiTraChoNV Decimal(20,2) = 0
			Declare @iTongTienDaNhapHang Decimal(20,2) = 0
			Declare @iTienLoiThucTeChoHDTraTienDu Decimal(20,2) = 0
	---END Declare ALL parameter
---------------------------------------
Declare @Total_ThanhTien Decimal 
Declare @_CastPromotion Decimal
Declare @_PercentDiscount Decimal
Declare @_TotalSalary Decimal
Declare @Total_TienLoi Decimal
Declare @_TrungBinhGiaBan Decimal
-- Load Tong thanh tien
exec sp_GetTotalAmount_TotalSalary @Order_ID =@paOrder_ID
	, @Total_ThanhTien = @Total_ThanhTien output
	,@Total_TienLoi = @Total_TienLoi output
	,@_CastPromotion = @_CastPromotion output
	,@_PercentDiscount =@_PercentDiscount output
	,@_TotalSalary = @_TotalSalary output
	,@_TrungBinhGiaBan = @_TrungBinhGiaBan output
--------------------------------------	
   select 
		@iOrder_ID =OD.Order_ID
		,@iCust_ID = convert(varchar, OD.Cust_ID)  + ' ' + cus.CustName
		,@iEmp_ID = convert(varchar, OD.Emp_ID)  + ' ' + emp.EmpName
		,@iSoLuongBanRa = SUM(ODT.Quantity ), @iSoLuongKM = SUM(ODT.QuantityPromotion)
		,@iTongTienDaXuatHang = SUM(ODT.Quantity *@_TrungBinhGiaBan)
		, @iTongTienPhaiTraChoNV = SUM(ODT.Quantity *@_TrungBinhGiaBan) -  SUM((ODT.Quantity *@_TrungBinhGiaBan) - (((ODT.Quantity *@_TrungBinhGiaBan)*ODT.PercentSalary)/100) )
		,@iTongTienDaNhapHang = SUM(ODT.TienNhapHang)
		, @iTienLoiThucTeChoHDTraTienDu =  SUM(ODT.Quantity *@_TrungBinhGiaBan) - SUM(((ODT.Quantity *@_TrungBinhGiaBan)*ODT.PercentSalary)/100) - SUM(ODT.TienNhapHang)
   from tbl_OrderDetails ODT, tbl_Orders OD,tbl_Employees emp,tbl_Customers cus
   Where
	 OD.Order_ID = @paOrder_ID
	 and OD.Order_ID = ODT .Order_ID 
	-- and OD.IsLock = 1
	group by OD.Order_ID,OD.Cust_ID,cus.CustName,OD.Emp_ID,emp.EmpName
    -- run your operation here
   -----SET Value---------------------------------------
   Declare @PhanTramTienLoiThucTe decimal(15,2) = 0
	SET @PhanTramTienLoiThucTe = (@paPaymentAmount * 100)/@iTongTienDaXuatHang
	Declare @TienLoiThucTe decimal(20,2) = 0
	SET @TienLoiThucTe = ((@iTienLoiThucTeChoHDTraTienDu*@PhanTramTienLoiThucTe)/100)
   Insert into @tblTemp_DoanhThu (Order_ID,Cust_ID,Emp_ID,SoLuongBanRa,SoLuongKM,TongTienDaXuatHang,TongTienPhaiTraChoNV,TongTienDaNhapHang,TienLoiThucTeChoHDTraTienDu,PaymentAmount,TienLoiThucTe)
   values						(@iOrder_ID,@iCust_ID,@iEmp_ID,@iSoLuongBanRa,@iSoLuongKM,@iTongTienDaXuatHang,@iTongTienPhaiTraChoNV,@iTongTienDaNhapHang,@iTienLoiThucTeChoHDTraTienDu,@paPaymentAmount,@TienLoiThucTe)
  
   --
    SET @Iter = @Iter + 1
END

DROP TABLE #Temp_PaymentOrders

select Order_ID,Cust_ID,Emp_ID
		,SUM(SoLuongBanRa) as SoLuongBanRa ,SUM(SoLuongKM) as SoLuongKM,SUM(TongTienDaXuatHang) as TongTienDaXuatHang
		,SUM(TongTienPhaiTraChoNV) as TongTienPhaiTraChoNV, SUM(TongTienDaNhapHang) as TongTienDaNhapHang
		,SUM(TienLoiThucTeChoHDTraTienDu) as TienLoiThucTeChoHDTraTienDu, SUM(PaymentAmount) as PaymentAmount,SUM(TienLoiThucTe) as TienLoiThucTe
from @tblTemp_DoanhThu DoanhThu
group by Order_ID,Cust_ID,Emp_ID
end

-- spReportRevenune_SelectOrder '2013-10-20', '2013-11-21'
-- select * from dbo.tbl_PaymentOrders PaymentOrders

--469200.00
--147058.65