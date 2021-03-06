USE [ConsmeticsManagement_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[spInsertPromotions]    Script Date: 12/21/2013 17:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spInsertPromotions]
@ProductID int,
@Number_buy int,
@Number_Promotions int,
@Price decimal(15,5),
@PriceActual_Import decimal(15,2),
@Note nvarchar(200)
as
BEGIN
	Declare @iRow int
	select @iRow = COUNT(*) from tbl_Promotions 
	where Product_ID = @ProductID
		And Price = @Price
		And PriceActual_Import = @PriceActual_Import
	If(@iRow > 0)
	Begin
		-- Update 
		Update tbl_Promotions
		set Number_buy = @Number_buy,Number_Promotions = @Number_Promotions
		where Product_ID = @ProductID
		And Price = @Price
		And PriceActual_Import = @PriceActual_Import
	End
	Else
	Begin
		--- Add
		Insert into tbl_Promotions(Product_ID,BeginDate,EndDate,Form,Number_buy,Number_Promotions,Price,PriceActual_Import,Note)
	values(@ProductID,GETDATE(),GETDATE(),N'Tặng SP',@Number_buy,@Number_Promotions,@Price,@PriceActual_Import,@Note)
	End
	
END