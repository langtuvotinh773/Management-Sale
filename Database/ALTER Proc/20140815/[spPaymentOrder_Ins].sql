USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spPaymentOrder_Ins]    Script Date: 08/23/2014 22:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER  Proc [dbo].[spPaymentOrder_Ins]
 @Order_ID int,
 @OrderDate DAtetime,
 @Amount Decimal(15,5),
 @Note NVARCHAR(100),
 @CheckInsertSalaries int
AS
BEGIN
-- Update lai Table dbo.tbl_OrderDetails
EXEC [spODD_UpdatePercentSalary] @Order_ID

-- Lấy ra tổng tiền và tổng lương được ăn của hóa đơn
 Declare @TotalAmount Decimal(15,5)
 Declare @TotalSalary Decimal(15,5)
 Declare @intEmp_ID int
 Declare @TotalSalaryEmp Decimal(17,3), @iExist int
 select @intEmp_ID = Emp_ID from tbl_Orders where Order_ID = @Order_ID
 --get tổng số lượng đã bán và số tiền được tặng
---------------------------------------
Declare @Total_ThanhTien Decimal 
Declare @_CastPromotion Decimal
Declare @_PercentDiscount Decimal
Declare @_TotalSalary Decimal
Declare @Total_TienLoi Decimal
-- Load Tong thanh tien
exec sp_GetTotalAmount_TotalSalary @Order_ID =@Order_ID
	, @Total_ThanhTien = @Total_ThanhTien output
	,@Total_TienLoi = @Total_TienLoi output
	,@_CastPromotion = @_CastPromotion output
	,@_PercentDiscount =@_PercentDiscount output
	,@_TotalSalary = @_TotalSalary output

 -- select DATA
 	SET @TotalAmount = @Total_ThanhTien
 	SET @TotalSalary = @_TotalSalary
 ----SElect @TotalAmount =Sum(TotalAmount),@TotalSalary =Sum(TotalSalary)
 ----From (
	----		----Group by odd.Form
	----		SElect CAST(SUM(odd.ThanhTien - ((dbo.func_GetCastPromotionOnOnceProduct(@Order_ID) )* odd.Quantity)) as decimal(13,0)) as TotalAmount
	----		,CAST(SUM(((odd.ThanhTien - ((dbo.func_GetCastPromotionOnOnceProduct(@Order_ID) )* odd.Quantity)) * ISNULL(odd.PercentSalary,'0')) / 100.00 ) as decimal(13,0)) as TotalSalary 

	----		From tbl_Orders od, tbl_OrderDetails odd,tbl_Customers cust, tbl_Employees emp
	----		Where od.Order_ID   =@Order_ID
	----		And  od.Order_ID   = odd.Order_ID
	----		And od.Cust_ID   = cust.Cust_ID
	----		And  od.Emp_ID   = emp.Emp_ID
	----		and odd.Quantity > 0
 ----) XX
-- Tính xem số tiền trả chiếm bao nhiu % của số tiền tổng
 Declare @Percent Decimal(15,5)
 Set @Percent= @Amount/@TotalAmount * 100.00
-- Tính ra số lương sẽ dc nhận trong lần chi trả này
 Declare @Salary Decimal(15,5)
 Set @Salary=Round(@TotalSalary * @Percent / 100.00,0)
-- Update bảng lương
 -- start NguyenQuoc update 18-11-2012
 
 if(@CheckInsertSalaries = 1)--@CheckInsertSalaries = 1 là cập nhật lại! còn = 0 thì insert moi
	 begin
		 -- cap nhat lai Tong Luong cua 1 hoa don ban ra
		  Update tbl_Salaries 
		  Set TotalSalary = @Salary
		  Where Emp_ID in (SElect Emp_ID From tbl_Orders where Order_ID=@Order_ID)
		   and Order_ID = @Order_ID
		  
		  -- tinh tong luong cua nhan vien
		  select @TotalSalaryEmp = SUM(TotalSalary) from tbl_Salaries where Emp_ID = @intEmp_ID
		  
		  -- validation xem co insert vao ban tbl_TotalSalary hay chua ?
		  -- neu co thi update
		  select @iExist = COUNT (*) from tbl_TotalSalary where Emp_ID = @intEmp_ID
		  if(@iExist = 1)
		  begin
		   Update tbl_TotalSalary set TotalSalary = @TotalSalaryEmp where Emp_ID = @intEmp_ID
		  end
		  else
		  begin
		   insert into tbl_TotalSalary(Emp_ID,TotalSalary)values(@intEmp_ID,@TotalSalaryEmp)
		  end
	 End
 if(@CheckInsertSalaries = 0)
	 begin
		  -- insert them dong tra tien lan thu N
		  Insert into tbl_PaymentOrders (Order_ID, PaymentOrderDate, PaymentAmount,Note)
		  Values (@Order_ID,@OrderDate, @Amount,@Note)
		  
		  insert into tbl_Salaries(Emp_ID,TotalSalary,Order_ID) values(@intEmp_ID,@Salary,@Order_ID)
		  -- tinh tong luong cua nhan vien
		  select @TotalSalaryEmp = SUM(TotalSalary) from tbl_Salaries where Emp_ID = @intEmp_ID
		  
		  -- validation xem co insert vao ban tbl_TotalSalary hay chua ?
		  -- neu co thi update
		  select @iExist = COUNT (*) from tbl_TotalSalary where Emp_ID = @intEmp_ID
		  if(@iExist = 1)
		  begin
		   Update tbl_TotalSalary set TotalSalary = @TotalSalaryEmp where Emp_ID = @intEmp_ID
		  end
		  else
		  begin
		   insert into tbl_TotalSalary(Emp_ID,TotalSalary)values(@intEmp_ID,@TotalSalaryEmp)
		  end
		  
		  Declare @TotalPayment Decimal(15,5)
		  SElect @TotalPayment= Sum(PaymentAmount)From tbl_PaymentOrders Where Order_ID=@Order_ID
		  -- Nếu số tiền trả bằng số tiền tổng thì khóa hóa đơn lại
		  If @TotalPayment=@TotalAmount Begin
		  Update tbl_Orders Set IsLock=1 Where Order_ID=@Order_ID
		  End
	 End
 if(@CheckInsertSalaries = 2) -- action form khi Change product
	begin
		delete From tbl_PaymentOrders Where Order_ID=@Order_ID
		Insert into tbl_PaymentOrders (Order_ID, PaymentOrderDate, PaymentAmount,Note)
		Values (@Order_ID,@OrderDate, @Amount,@Note)

		delete From tbl_Salaries Where Order_ID=@Order_ID
		insert into tbl_Salaries(Emp_ID,TotalSalary,Order_ID) values(@intEmp_ID,@Salary,@Order_ID)

		-- tinh tong luong cua nhan vien
		select @TotalSalaryEmp = SUM(TotalSalary) from tbl_Salaries where Emp_ID = @intEmp_ID

		-- validation xem co insert vao ban tbl_TotalSalary hay chua ?
		-- neu co thi update
		select @iExist = COUNT (*) from tbl_TotalSalary where Emp_ID = @intEmp_ID
		if(@iExist = 1)
		  begin
		   Update tbl_TotalSalary set TotalSalary = @TotalSalaryEmp where Emp_ID = @intEmp_ID
		  end
		else
		  begin
		   insert into tbl_TotalSalary(Emp_ID,TotalSalary)values(@intEmp_ID,@TotalSalaryEmp)
		  end
	end
 
 -- check khoa hoa don
 Declare @TotalMoneyOrder Decimal(15,2)
 Declare @tbl_Salaries_TotalMoneyOrder Decimal(15,2)
	select @TotalMoneyOrder = SUM(ThanhTien ) - OD.CastPromotion
	from tbl_OrderDetails  ODD, tbl_Orders OD
	where ODD.Order_ID = @Order_ID
		and  ODD.Order_ID =  OD.Order_ID
	group by OD.CastPromotion
	 
 select @tbl_Salaries_TotalMoneyOrder = SUM(PaymentAmount ) from tbl_PaymentOrders  where Order_ID = @Order_ID
 if(@TotalMoneyOrder = @tbl_Salaries_TotalMoneyOrder)
 begin
  Update tbl_Orders Set IsLock=1 Where Order_ID=@Order_ID
 end
END