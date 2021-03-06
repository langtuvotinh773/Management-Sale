USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spOrder_DeleteAll]    Script Date: 10/18/2013 14:36:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  Proc [dbo].[spOrder_DeleteAll]
	@Order_ID int
AS
BEGIN
	Declare @count_tbl_OrderDetails Int,@count_tbl_PaymentOrders Int
	Declare  @Iter int, @parProduct_ID int,@parOrderDetail_ID int,@parOrder_ID int,@parQuantity int
	,@parQuantityPromotion int,@parPrice_Sell decimal(15,5) ,@parPrice_ActualImport decimal(15,2)
	set @Iter = 1
	
	-- Làm cái gì đây ? Sao minh không hiểu vậy ta ?
	SELECT RowNum = ROW_NUMBER() OVER(ORDER BY OrderDetail_ID),* INTO #tbl_UserForeach FROM tbl_OrderDetails  where Order_ID = @Order_ID

	--Check xem còn Detail nào kko ?
	select @count_tbl_OrderDetails = COUNT(*) from  tbl_OrderDetails  where Order_ID = @Order_ID
	if(@count_tbl_OrderDetails != 0)
	begin
		  --Start update lai so luong cho san pham
		WHILE @Iter <= @count_tbl_OrderDetails
			BEGIN
			SELECT @parProduct_ID = ord.Product_ID, @parOrderDetail_ID = ord.OrderDetail_ID, @parOrder_ID = ord.Order_ID, 
				@parQuantity = ord.Quantity,@parQuantityPromotion =ord.QuantityPromotion, @parPrice_Sell = ord.Price
				,@parPrice_ActualImport = ord.Price_Import
				FROM #tbl_UserForeach ord 
				WHERE Order_ID = @Order_ID and RowNum = @Iter
				-- select * from tbl_ProductPrices
				Update tbl_ProductPrices 
					Set Quantity =  Quantity + (@parQuantity + @parQuantityPromotion)
					--,QuantityPromotion = QuantityPromotion + @parQuantityPromotion 
						,DateEdit = GETDATE()
					Where Product_ID = @parProduct_ID 
							and Price =@parPrice_Sell
							and PriceActual_Import = @parPrice_ActualImport
							
				-- run your operation here
				SET @Iter = @Iter + 1
			END
		end
		 --End update lai so luong cho san pham
		 
		  -- Start Delete tbl_ChangeProducts
		Delete from  tbl_ChangeProducts  where Order_ID = @Order_ID
		 -- Start Delete tbl_ChangeProducts
		 
		 -- Start Delete tbl_PaymentOrders
		Delete from  tbl_OrderDetails  where Order_ID = @Order_ID
		 -- Start Delete tbl_PaymentOrders
		 
		-- Start Delete tbl_PaymentOrders
		select @count_tbl_PaymentOrders = COUNT(*) from  tbl_PaymentOrders  where Order_ID = @Order_ID
		if(@count_tbl_PaymentOrders != 0)
		begin
			delete from tbl_PaymentOrders where Order_ID = @Order_ID
		end
		-- End Delete tbl_PaymentOrders
		Declare @parEmp_ID int
		select @parEmp_ID = Emp_ID  from  tbl_Orders  where Order_ID = @Order_ID
		-- Start Delete tbl_Orders
		delete  from  tbl_Orders  where Order_ID = @Order_ID
		-- End Delete tbl_Orders
		Declare @SalaryOfOrder decimal(17,3)
		select @SalaryOfOrder = TotalSalary  from tbl_Salaries  where Order_ID = @Order_ID
		if(@SalaryOfOrder > 0)
		begin
			Update tbl_TotalSalary set TotalSalary = TotalSalary - @SalaryOfOrder where Emp_ID = @parEmp_ID
		end
		delete from tbl_Salaries where Order_ID = @Order_ID
END
