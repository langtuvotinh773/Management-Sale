ALTER proc spGetTongTienDaNhapHang
@CompanyID int,
@FromDate datetime,
@ToDate datetime 
as
Begin
-- Start tong tien nhap hang
select  SUM(TienNhapHang) as TongTienDaNhapHang
from tbl_Orders orders, tbl_OrderDetails orderDetail
where 
orders.OrderDate  Between @FromDate and @ToDate
AND orderDetail.Company_ID = @CompanyID
AND orders.Order_ID = orderDetail.Order_ID

-- End tong tien nhap hang
END