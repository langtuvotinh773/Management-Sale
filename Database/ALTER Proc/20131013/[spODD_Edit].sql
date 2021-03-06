USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spODD_Edit]    Script Date: 10/13/2013 13:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   Proc [dbo].[spODD_Edit]
@OrderDetail_ID int,
@Order_ID Int, 
@Product_ID Int, 
@Quantity Int, 
@QuantityPromotion Int, 
@DisCount SmallInt,
@PercentDiscount SmallInt, 
@Price Decimal(15,5),
@Form NVARCHAR(30),
@Price_Import Decimal(15,5)

AS
BEGIN
-- LẤy ra % mà nhân viên dc ăn đối  với mặt hàng này
 Declare @PercentSalary Smallint
----- Lấy số Lượng, SLKM có hóa đơn củ
 Declare @oldQty int, @oldQtyPromotion int
 select @oldQty = Quantity, @oldQtyPromotion = QuantityPromotion from tbl_OrderDetails where OrderDetail_ID = @OrderDetail_ID
 --------------------------------------------------------------------
 Select @PercentSalary = Percents
 From tbl_SalaryPercents 
 Where Emp_ID in (SElect Emp_ID From tbl_Orders where Order_ID = @Order_ID) And Product_ID=@Product_ID 
 --------------------------------------------------------------------
 -- tính Thành Tiền
 Declare @strThanhTien Decimal
  set @strThanhTien = (@Quantity * @Price) - ((@Quantity * @Price) * (@DisCount + @PercentDiscount))/100

-- Tính Tiền Lời
 Declare @strTienLoi Decimal
 set @strTienLoi = @strThanhTien - ((@strThanhTien * @PercentSalary)/100)
 -- Tính Tiền Nhap Hang
 Declare @strTienNhapHang Decimal
 set @strTienNhapHang = (@Quantity * @Price_Import)
 -- xem lai nguoi dung co cap nhat lai gia ban khi nhap hay khong ?
  --+ Neu chi co 1 gia thi cap nhat lai gia luon
  Declare @de_Price Decimal
  --Declare @int_CountPrice int
  --select @int_CountPrice = count(*) from dbo.tbl_ProductPrices 
  --where Product_ID = @Product_ID and SecondPrice = @Price
  --and PriceActual_Import = @Price_Import
  
 --if(@int_CountPrice = 1)
  begin
  --select @de_Price = Price from dbo.tbl_ProductPrices where Product_ID = @Product_ID
  set @de_Price = (select top 1 PriceSell from dbo.tbl_PriceHistory where Product_ID = @Product_ID order by PriceHistory_ID desc)
  -- cập nhật lại số lượng trong hóa đơn xuất có thêm giá bán ra
  

  UPDATE  tbl_OrderDetails 
  SET Quantity = @Quantity, QuantityPromotion = @QuantityPromotion,Discount = @DisCount, 
  PercentPromotion =@PercentDiscount, Price=@de_Price,PercentSalary=@PercentSalary,Form=@Form
  ,Price_Import=@Price_Import,ThanhTien = @strThanhTien,TienLoi = @strTienLoi,TienNhapHang = @strTienNhapHang
  where OrderDetail_ID = @OrderDetail_ID
  --------------------------------------------------------------------
  end
 --else 
 -- begin 
 -- -- cập nhật lại số lượng trong hóa đơn xuất
 -- UPDATE  tbl_OrderDetails 
 -- SET Quantity = @Quantity, QuantityPromotion = @QuantityPromotion,Discount = @DisCount, 
 -- PercentPromotion =@PercentDiscount, Price=@Price,PercentSalary=@PercentSalary,Form=@Form
 -- ,Price_Import=@Price_Import,ThanhTien = @strThanhTien,TienLoi = @strTienLoi,TienNhapHang = @strTienNhapHang
 -- where OrderDetail_ID = @OrderDetail_ID
 -- --------------------------------------------------------------------
 -- end
-- Cập Nhật lại số lượng có trong tbl_ProductPrices
 if @Quantity > @oldQty 
 begin
 -- nếu như số lượng sửa Lớn hơn số lượng củ thì 
 -- @QtyCurrent = @Quantity - @oldQty
  --- trừ thêm vào do số lượng sửa lớn hơn số lượng củ
  Update tbl_ProductPrices 
  set Quantity = Quantity - ((@Quantity - @oldQty) + @QuantityPromotion)
  Where Product_ID=@Product_ID And Price =@Price and PriceActual_Import = @Price_Import
  
 end
 else 
 begin
  -- nếu như số lượng sửa nhỏ hơn số lượng củ thì 
  --@QtyCurrent = @oldQty - @Quantity
  --- cộng thêm vào do số lượng sửa nhỏ hơn số lượng củ
  Update tbl_ProductPrices 
  set Quantity = Quantity + ((@oldQty - @Quantity)+ @QuantityPromotion)
  Where Product_ID=@Product_ID And Price =@Price and PriceActual_Import = @Price_Import
 end

 
 
 -- Cập nhật lại số tiền mà KH đã trả
 Declare @de_PaymentAmount Decimal
 Declare @de_TotalAmount_Order Decimal
 select @de_PaymentAmount = SUm(PaymentAmount) from tbl_PaymentOrders where Order_ID = @Order_ID
 select @de_TotalAmount_Order = Sum(ThanhTien) from tbl_OrderDetails where Order_ID = @Order_ID
 if @de_PaymentAmount > @de_TotalAmount_Order
 begin
 delete tbl_PaymentOrders where Order_ID = @Order_ID
 insert into tbl_PaymentOrders(Order_ID,PaymentOrderDate,PaymentAmount,Note) values (@Order_ID,GetDate(),@de_TotalAmount_Order,N'Do thay đổi giá bán ra')

 end
 
 EXEC spCheckLockOrder @Order_ID
END
