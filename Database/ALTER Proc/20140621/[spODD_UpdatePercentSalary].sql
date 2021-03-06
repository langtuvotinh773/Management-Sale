USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spODD_Edit]    Script Date: 06/21/2014 12:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   Proc [dbo].[spODD_UpdatePercentSalary]
@Order_ID Int 
AS
BEGIN
--for table dbo.tbl_OrderDetails
 SELECT 
    RowNum = ROW_NUMBER() OVER(ORDER BY OrderDetail_ID)
    ,*
INTO #Temp_OrderDetails
FROM dbo.tbl_OrderDetails where Order_ID = @Order_ID

DECLARE @MaxRownum INT
SET @MaxRownum = (SELECT MAX(RowNum) FROM #Temp_OrderDetails)

DECLARE @Iter INT
SET @Iter = (SELECT MIN(RowNum) FROM #Temp_OrderDetails)

WHILE @Iter <= @MaxRownum
BEGIN

Declare @iOrderDetail_ID int
Declare @iProduct_ID Int
Declare @iQuantity Int
Declare @iQuantityPromotion Int
Declare @iDisCount SmallInt
Declare @iPercentPromotion SmallInt
Declare @iPrice Decimal(15,5)
Declare @iForm NVARCHAR(30)
Declare @iPrice_Import Decimal(15,5)

    SELECT @iOrderDetail_ID = OrderDetail_ID, @iProduct_ID =Product_ID,@iQuantity =Quantity
    ,@iQuantityPromotion = QuantityPromotion
    ,@iDisCount=Discount,@iPercentPromotion=PercentPromotion,@iPrice=Price
    ,@iForm = Form,@iPrice_Import =Price_Import
    FROM #Temp_OrderDetails
    WHERE RowNum = @Iter
    --- Update Data tbl_OrderDetails
    -- LẤy ra % mà nhân viên dc ăn đối  với mặt hàng này
 Declare @iPercentSalary Smallint
----- Lấy số Lượng, SLKM có hóa đơn củ
 Declare @oldQty int, @oldQtyPromotion int
 select @oldQty = Quantity, @oldQtyPromotion = QuantityPromotion from tbl_OrderDetails where OrderDetail_ID = @iOrderDetail_ID
 --------------------------------------------------------------------
 Select @iPercentSalary = Percents
 From tbl_SalaryPercents 
 Where Emp_ID in (SElect Emp_ID From tbl_Orders where Order_ID = @Order_ID) And Product_ID=@iProduct_ID 
 --------------------------------------------------------------------
 -- tính Thành Tiền
 Declare @strThanhTien Decimal
  set @strThanhTien = (@iQuantity * @iPrice) - ((@iQuantity * @iPrice) * (@iDisCount + @iPercentPromotion))/100
-- Tính Tiền Lời
 Declare @strTienLoi Decimal
 set @strTienLoi = @strThanhTien - ((@strThanhTien * @iPercentSalary)/100)
 -- Tính Tiền Nhap Hang
 Declare @strTienNhapHang Decimal
 set @strTienNhapHang = ((@iQuantity + @iQuantityPromotion) * @iPrice_Import)

  -- cập nhật lại số lượng trong hóa đơn xuất có thêm giá bán ra
  UPDATE  tbl_OrderDetails 
  SET Quantity = @iQuantity, QuantityPromotion = @iQuantityPromotion,Discount = @iDisCount, 
  PercentPromotion =@iPercentPromotion, Price=@iPrice,PercentSalary=@iPercentSalary,Form=@iForm
  ,Price_Import=@iPrice_Import,ThanhTien = @strThanhTien,TienLoi = @strTienLoi,TienNhapHang = @strTienNhapHang
  where OrderDetail_ID = @iOrderDetail_ID
    --------------------------------------------------------------------
    -- run your operation here
    SET @Iter = @Iter + 1
END
-- End For
END
