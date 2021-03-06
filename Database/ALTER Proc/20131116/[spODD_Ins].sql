USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spODD_Ins]    Script Date: 11/17/2013 00:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   Proc [dbo].[spODD_Ins]

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
	-- insert them campany_ID
	Declare @parCompany_ID Int
	select @parCompany_ID = IOD.Company_ID from tbl_ImportOrderDetails IODL, tbl_ImportOrders IOD where Product_ID = @Product_ID and IOD.ImportOrder_ID = IODL .ImportOrder_ID 

	-- LẤy ra % mà nhân viên dc ăn đối  với mặt hàng này
	Declare @PercentSalary Smallint

	Select @PercentSalary = Percents
	From tbl_SalaryPercents 
	Where Emp_ID in (SElect Emp_ID From tbl_Orders where Order_ID = @Order_ID) And Product_ID=@Product_ID 
	IF(@PercentSalary is null)
	begin
		SET @PercentSalary = 0
	end
-- tính Thành Tiền
	Declare @strThanhTien Decimal
		set	@strThanhTien = (@Quantity * @Price) - ((@Quantity * @Price) * (@DisCount + @PercentDiscount))/100

-- Tính Tiền Lời
	Declare @strTienLoi Decimal
	set @strTienLoi = @strThanhTien - ((@strThanhTien * @PercentSalary)/100)
	
-- Tính Tiền Nhap Hang //@sumDiscount là % Chiet Khấu khi nhập
	Declare @strTienNhapHang Decimal
	set @strTienNhapHang = ((@Quantity + @QuantityPromotion) * @Price_Import)
	
	
	Insert into tbl_OrderDetails 
	(Order_ID, Product_ID, Quantity, QuantityPromotion,Discount, PercentPromotion, Price,PercentSalary
	,Form,Price_Import,ThanhTien,TienLoi,TienNhapHang,Company_ID)
	Values 								
	(@Order_ID, @Product_ID, @Quantity, @QuantityPromotion,@DisCount, @PercentDiscount, @Price,@PercentSalary
	,@Form,@Price_Import,@strThanhTien,@strTienLoi,@strTienNhapHang,@parCompany_ID)
											
	-- Trừ đi số lượng trong bảng Products
	Update tbl_ProductPrices 
	set Quantity = Quantity - (@Quantity + @QuantityPromotion)
	-- Thay doi yeu cau khong tinh QuantityPromotion nua
	--,QuantityPromotion=	QuantityPromotion - @QuantityPromotion
	Where Product_ID=@Product_ID
	And Price =@Price and PriceActual_Import = @Price_Import
	
END
