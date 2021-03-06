USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spOD_Detail]    Script Date: 06/21/2014 14:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  Proc [dbo].[spOD_Detail]
@Begin DateTime,
@End	DateTime
AS
BEGIN
	SElect od.Order_ID,odd.OrderDetail_ID, pro.ProductName, od.IsLock,odd.Price_Import,odd.Price,
			 odd.Quantity, odd.QuantityPromotion, odd.Discount, odd.PercentPromotion,odd.PercentSalary,
			Case odd.Form When N'TẶNG SẢN PHẨM' THen
				(Convert(Float,(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount )/100.00)))
 				Else	(Convert(Float,(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount + odd.PercentPromotion)/100.00))) End as Amount
	From tbl_OrderDetails odd, tbl_Products pro, tbl_Orders od
	Where od.OrderDate Between @Begin And @End
	And odd.Order_ID			=	od.Order_ID
	And odd.Product_ID		=	pro.Product_ID
	and od.TypeOption = 1
	Order By pro.ProductName
	
ENd
