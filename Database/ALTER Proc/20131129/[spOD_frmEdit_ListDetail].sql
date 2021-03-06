USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spOD_frmEdit_ListDetail]    Script Date: 11/29/2013 12:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER  Proc [dbo].[spOD_frmEdit_ListDetail]
	@Order_ID int
AS
BEGIN
	SElect (odd.Quantity) as oldQty
			, odd.QuantityPromotion as oldQtyPromotion
			,proPrice.Quantity as QtyRemainder
			,proPrice.QuantityPromotion as QtyPromotionRemainder, od.Order_ID,odd.Product_ID,odd.OrderDetail_ID, pro.ProductName, od.IsLock,
			 odd.Quantity, odd.QuantityPromotion, odd.Discount,odd.Form, odd.PercentPromotion,odd.Price_Import ,odd.Price
			 ,(convert(varchar,odd.Product_ID)+'_'+convert(varchar,convert(decimal,odd.Price)) +'_'+convert(varchar,convert(decimal,odd.Price_Import))) as strDetial_Selected 

			 ,odd.ThanhTien as Amount
	From tbl_OrderDetails odd, tbl_Products pro, tbl_Orders od, tbl_ProductPrices proPrice
	Where od.Order_ID=@Order_ID
	And odd.Order_ID			=	od.Order_ID
	And odd.Product_ID		=	pro.Product_ID
	-- mới add thêm ngày 18-11-2012
	and odd.Product_ID = proPrice.Product_ID
	and odd.Price = proPrice.Price
	and odd.Price_Import = proPrice.PriceActual_Import
	
	Order By pro.ProductName
END
