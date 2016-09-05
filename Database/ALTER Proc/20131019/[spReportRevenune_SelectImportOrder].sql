USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spReportRevenune_SelectImportOrder]    Script Date: 10/19/2013 11:25:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spReportRevenune_SelectImportOrder]
@FromDate datetime,
@ToDate datetime
as
begin
SELECT Company_ID,CompanyName,SUM(TienDuocTang) as TienDuocTang,SUM(SoLuongNhap) as SoLuongNhap,SUM(SoLuongKM) as SoLuongKM,(SUM(TongTienNhapHang) - SUM(TienDuocTang)) as TongTienNhapHang
FROM(
	select IOD.Company_ID ,com.CompanyName 
	,ISNULL(IOD.CastPromotion,'0')  as TienDuocTang
	, SUM( IODT.Quantity )as SoLuongNhap, SUM( IODT.QuantityPromotion )as SoLuongKM
	, SUM((IODT.Quantity * IODT .Price) -(((IODT.Quantity * IODT .Price) * (IODT.PercentPromotion + IODT.Discount))/100)) as TongTienNhapHang

	from tbl_ImportOrders IOD Left Join tbl_ImportOrderDetails IODT 
		on IOD.ImportOrder_ID = IODT .ImportOrder_ID 
		left join  tbl_Companies com
		on  IOD .Company_ID = com.Company_ID 
	where  IOD.ImportOrderDate Between @FromDate and @ToDate
	group by IOD.Company_ID ,com.CompanyName ,IOD.CastPromotion
	)XX
	Group by  Company_ID,CompanyName
end
