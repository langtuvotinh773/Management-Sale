USE [ConsmeticsManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[func_GetCastPromotionOnOnceProduct]    Script Date: 10/18/2013 23:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================================================================
											Nguyễn Phú QUốc
	------------------------------------------------------------------------
									
	------------------------------------------------------------------------
				
=============================================================================*/
ALTER  Function [dbo].[func_GetCastPromotionOnOnceProduct]
(
@Order_ID  int
)
	Returns Decimal(15,2)
As
BEGIN
	Declare @CastPromotion Decimal(15,2)
	SELECT @CastPromotion =  CAST(od.CastPromotion / SUM(Quantity) as decimal(13,2))
	from tbl_OrderDetails ODD, tbl_Orders od
	where od.Order_ID = @Order_ID
		and od.Order_ID = ODD.Order_ID 
	group by od.CastPromotion 
	if (@CastPromotion is null) begin
		Set @CastPromotion=0
	End
return @CastPromotion
END

--Select dbo.func_PaymentAmount(12)
