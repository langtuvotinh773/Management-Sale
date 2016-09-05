USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[spReport_InventoryUpdate_16042013]    Script Date: 11/03/2013 19:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[spReport_InventoryUpdate_All] 
	@BeginDate Datetime,
	@EndDate Datetime
AS
BEGIN
	--Khai báo b?ng s? xu?t ra cu?i cùng
	Declare @tbView Table 
			(Company_ID int, ProductName NVarchar(500), Price Decimal(15,5),
			 QuantityFirst Int, QtyPromotionFirst Int, AmountFirst Decimal(15,5),
			 QuantityOut int, QtyPromotionOut Int, AmountOut Float,
			 QuantityIm int, QtyPromotionIm Int, AmountIm Float,
			 QuantityLast Int, QtyPromotionLast Int, AmountLast Float)
	-- Khai bao bang ch?a d? li?u ch?t t?n
	Declare @tbInventory Table
			(Company_ID int, ProductName NVarchar(500), Price Decimal(15,5),
			 Quantity Int, QuantityPromotion Int, ValueInventory Decimal(15,5))
	-- Khai bao bang ch?a d? li?u Nh?p hàng T? ngày ch?t t?n g?n ngày b?t d?u nh?t -> ngày b?t d?u tính (@BeginDate)
	Declare @tbBetweenIm Table
			(Company_ID int, ProductName NVarchar(500), Price Decimal(15,5),
			 Quantity Int, QuantityPromotion Int, Amount Decimal(15,5))
	-- Khai bao bang ch?a d? li?u xu?t hàng T? ngày ch?t t?n g?n ngày b?t d?u nh?t -> ngày b?t d?u tính (@BeginDate)
	Declare @tbBetweenOut Table
			(Company_ID int, ProductName NVarchar(500), Price Decimal(15,5),
			 Quantity Int, QuantityPromotion Int, Amount Decimal(15,5))
	-- Khai bao bang ch?a d? li?u Nh?p t? ngày b?t d?u d?n ngày k?t thúc (@BeginDate -> @EndDate )
	Declare @tbIm Table
			(Company_ID int, ProductName NVarchar(500), Price Decimal(15,5),
			 Quantity Int, QuantityPromotion Int, Amount Float)
	-- Khai bao bang ch?a d? li?u Xu?t t? ngày b?t d?u d?n ngày k?t thúc (@BeginDate -> @EndDate )
	Declare @tbOut Table
			(Company_ID int, ProductName NVarchar(500), Price Decimal(15,5),
			 Quantity Int, QuantityPromotion Int, Amount Float)
	-- L?y ra ngày ch?t g?n v?i ngày b?t d?u nh?t
	Declare @DateMaxInvent DateTime 
	SElect @DateMaxInvent = MAX(DateInventory) 
							From tbl_InventoryDetails 
							Where DateInventory <= @BeginDate 
							
	--L?y ra nh?ng s?n ph?m có trong b?ng ch?t t?n
	Insert Into @tbInventory 
	SElect invent.Company_ID, invent.ProductName, invent.Price ,
			inventdetail.Quantity, inventdetail.QuantityPromotion,
			inventdetail.ValueInventory
	From tbl_Inventories invent, tbl_InventoryDetails inventdetail
	Where inventdetail.DateInventory =@DateMaxInvent
	And inventdetail.Quantity >0
	And invent.Inventory_ID = inventdetail.Inventory_ID
	
	-- insert to
	Insert into @tbBetweenIm 
	SElect pro.Company_ID, pro.ProductName, iod.PriceActual,
			(SUM(iod.Quantity ) + SUM(iod.QuantityPromotion )) as Quantity, 0 as QuantityPromotion ,
			Sum((iod.Quantity * iod.Price)-((iod.Quantity * iod.Price) * (iod.Discount + iod.PercentPromotion)/100.00)) as Amount
	From tbl_Products pro, tbl_ImportOrders [io], tbl_ImportOrderDetails iod
	Where [io].ImportOrderDate between @DateMaxInvent And @BeginDate 
	And pro.Product_ID= iod.Product_ID 
	And [io].ImportOrder_ID=iod.ImportOrder_ID 
	Group by pro.Company_ID, pro.ProductName, iod.PriceActual
	-- inssert to 
	Insert into @tbBetweenOut 
	SElect pro.Company_ID, pro.ProductName, odd.Price_Import,
			(SUM(odd.Quantity ) + SUM(odd.QuantityPromotion )) as Quantity, 0 as QuantityPromotion ,
			Sum(Convert(Float,(odd.Quantity * odd.Price_Import)-((odd.Quantity * odd.Price_Import) * (odd.Discount + odd.PercentPromotion)/100.00)) ) as Amount
	From tbl_Products pro, tbl_Orders ord, tbl_OrderDetails  odd
	Where ord.OrderDate between @DateMaxInvent And @BeginDate 
	And pro.Product_ID= odd.Product_ID 
	And ord.Order_ID=odd.Order_ID 
	Group by pro.Company_ID, pro.ProductName, odd.Price_Import	
	
	-- insert to
	Insert into @tbIm 
	SElect pro.Company_ID, pro.ProductName, iod.PriceActual,
			(SUM(iod.Quantity ) +  SUM(iod.QuantityPromotion )) as Quantity, 0 as QuantityPromotion ,
			Sum(Convert(Float,(iod.Quantity * iod.Price)-((iod.Quantity * iod.Price) * (iod.Discount + iod.PercentPromotion)/100.00))) as Amount
	From tbl_Products pro, tbl_ImportOrders [io], tbl_ImportOrderDetails iod
	Where [io].ImportOrderDate between @BeginDate And @EndDate  
	And pro.Product_ID= iod.Product_ID 
	And [io].ImportOrder_ID=iod.ImportOrder_ID 
	Group by pro.Company_ID, pro.ProductName, iod.PriceActual
	
	-- inssert to 
	Insert into @tbOut 
	SElect pro.Company_ID, pro.ProductName, odd.Price_Import,
			(SUM(odd.Quantity ) + SUM(odd.QuantityPromotion )) as Quantity, 0 as QuantityPromotion ,
			Sum(Convert(Float,(odd.Quantity * odd.Price_Import)-((odd.Quantity * odd.Price_Import) * (odd.Discount + odd.PercentPromotion)/100.00)) ) as Amount
	From tbl_Products pro, tbl_Orders ord, tbl_OrderDetails  odd
	Where ord.OrderDate   between @BeginDate And  @EndDate
	And pro.Product_ID= odd.Product_ID 
	And ord.Order_ID=odd.Order_ID 
	Group by pro.Company_ID, pro.ProductName, odd.Price_Import	
	
	-- L?y ra danh sách s?n ph?m d? múc zo b?ng chính nè
	insert into @tbView 
	SElect Company_ID , ProductName , Price , 0,0,0,0,0,0,0,0,0,0,0,0
	From (
					SElect Company_ID , ProductName , Price 
					From @tbInventory 
			UNION
					SElect Company_ID , ProductName , Price 
					From @tbBetweenIm 
			UNION	
					SElect Company_ID , ProductName , Price 
					From @tbBetweenOut 
			UNION 
					SElect Company_ID , ProductName , Price 
					From @tbIm 
			UNION	
					SElect Company_ID , ProductName , Price 
					From @tbOut
		) XX
	Order by Company_ID , ProductName , Price 	
	
	-- Ðã có su?n r?i thì Update d? li?u Nh?p - Xu?t - T?n nè
	-- C?p nh?t s? t?n d?u
	Update @tbView 
	Set QuantityFirst = X.QuantityFirst ,
		QtyPromotionFirst = X.QtyPromotionFirst 
	From @tbView main,
		 (SElect invent.Company_ID , invent.ProductName , invent.Price,
			   (invent.Quantity + (bwi.Quantity - bwo.Quantity )) as QuantityFirst, 
			   (invent.QuantityPromotion  + (bwi.QuantityPromotion - bwo.QuantityPromotion )) as QtyPromotionFirst
			From @tbBetweenIm bwi, @tbBetweenOut bwo, @tbInventory  invent
			Where invent.Company_ID=bwi.Company_ID 
			And		invent.ProductName=bwi.ProductName 
			And		invent.Price=bwi.Price 
			And		invent.Company_ID=bwo.Company_ID 
			And		invent.ProductName=bwo.ProductName 
			And		invent.Price=bwo.Price
			And  bwo.Company_ID=bwi.Company_ID 
			And		bwo.ProductName=bwi.ProductName 
			And		bwo.Price=bwi.Price  ) X
		 			
	Where main.Company_ID=X.Company_ID 
	And main.ProductName=X.ProductName 
	And main.Price =X.Price 
	-- C?p nh?t nh?p trong kì
	Update @tbView 
	Set QuantityIm  =im.Quantity ,
		QtyPromotionIm =im.QuantityPromotion ,
		AmountIm = im.Amount  
	From @tbView main, @tbIm im
	Where main.Company_ID=im.Company_ID 
	And main.ProductName = im.ProductName 
	and main.Price=im.Price 
	-- c?p nh?t xu?t trong kì 
	Update @tbView 
	Set QuantityOut =tbout.Quantity ,
		QtyPromotionOut=tbout.QuantityPromotion ,
		AmountOut =tbout.Amount 
	From @tbView main, @tbOut tbout
	Where main.Company_ID=tbout.Company_ID 
	And main.ProductName = tbout.ProductName 
	and main.Price=tbout.Price
	
	-- C?p nh?t t?n cu?i và các giá tr? khác
	Update @tbView 
	Set QuantityLast = QuantityFirst + QuantityIm - QuantityOut ,
		QtyPromotionLast = QtyPromotionFirst + QtyPromotionIm - QtyPromotionOut ,
		AmountLast = (QuantityFirst + QuantityIm - QuantityOut) * Price ,
		AmountFirst = QuantityFirst * Price 
		
	-- L?y d? li?u ra thôi:D
	Select tblTemp.Company_ID ,tbl_Companies.CompanyName  as CompanyName,ProductName,Price ,QuantityFirst,QtyPromotionFirst,AmountFirst,
	QuantityOut,QtyPromotionOut,AmountOut,QuantityIm,QtyPromotionIm,AmountIm,
	QuantityLast,QtyPromotionLast,AmountLast
	From @tbView tblTemp ,tbl_Companies
	where tblTemp.Company_ID = tbl_Companies.Company_ID
END
