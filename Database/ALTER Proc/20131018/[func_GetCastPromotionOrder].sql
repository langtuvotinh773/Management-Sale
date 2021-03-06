USE [ConsmeticsManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[func_GetCastPromotionOnOnceProduct]    Script Date: 10/19/2013 00:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================================================================
											Nguyễn Phú QUốc
	------------------------------------------------------------------------
									
	------------------------------------------------------------------------
				
=============================================================================*/
CREATE  Function [dbo].[func_GetCastPromotionOrder]
(
@Order_ID  int
)
	Returns Decimal(15,2)
As
BEGIN
	Declare @CastPromotion Decimal(15,2)
	SELECT @CastPromotion =  CAST(od.CastPromotion as decimal(13,2))
	from tbl_Orders od
	where od.Order_ID = @Order_ID
	if (@CastPromotion is null) begin
		Set @CastPromotion=0
	End
return @CastPromotion
END

--Select dbo.func_PaymentAmount(12)
