USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spIOD_Del]    Script Date: 10/15/2013 21:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER  Proc [dbo].[spIOD_Del]
	@ImportOrderDetail_ID Int
	
AS
BEGIN
	Declare @Qty_TrongKho int
	Declare @QuantityIOD int, @QuantityPromotionIOD Int, @Product_ID Int, @Price Decimal(15,5), @Price_Sale Decimal(15,5), @checkDelete int
	SElect @QuantityIOD=Quantity, @QuantityPromotionIOD=QuantityPromotion, @Product_ID=Product_ID 
			, @Price=PriceActual,@Price_Sale = PriceSell
	From tbl_ImportOrderDetails
	Where ImportOrderDetail_ID=@ImportOrderDetail_ID
-- check xem co trong order detail chua ? neu chua co thi xoa, con co roi thi validation tip
--	select @checkDelete = COUNT(*) from tbl_OrderDetails where Product_ID = @Product_ID and Price_Import = @Price
	-- Set xem so luong trong kho con du de tru hay khong neu ko thi bao loi yeu cau xoa hoa don xuat hang
	select @Qty_TrongKho = Quantity from tbl_ProductPrices where  Product_Id=@Product_ID And Price=@Price_Sale AND PriceActual_Import = @Price
if @Qty_TrongKho >=   (@QuantityIOD + @QuantityPromotionIOD)
	begin
		Update tbl_ProductPrices 
		Set Quantity = @Qty_TrongKho- (@QuantityIOD - @QuantityPromotionIOD)
		Where Product_Id=@Product_ID And Price=@Price_Sale AND PriceActual_Import = @Price
		-------------------------------------------------------------------
		--delete from tbl_ProductPrices Where Product_Id = @Product_ID And Price = @Price 
		-- Delete From ImportDetails
		Delete From  tbl_ImportOrderDetails Where ImportOrderDetail_ID=@ImportOrderDetail_ID
		
		
	end
--else
	--begin
	--declare  @QtyCurrent Decimal(15,5),@QtyPromotionCurrent Decimal(15,5)
		-- Update Product tbl_ProductPrices
		-- check coi so luong con bao nhiu ? nếu số Muốn xóa Hóa đơn Nhập thì số lượng
		--select @QtyCurrent = Quantity ,@QtyPromotionCurrent = QuantityPromotion from tbl_ProductPrices Where Product_Id=@Product_ID And Price=@Price 
		
	
		
	--end


END

