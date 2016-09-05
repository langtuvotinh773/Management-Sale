USE [ConsmeticsManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLogData]    Script Date: 10/09/2013 22:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE   Proc [dbo].[sp_GetPercents]
	@Emp_ID int,
	@Product_ID int
As
BEGIN
select Percents
from dbo.tbl_SalaryPercents
where Emp_ID = @Emp_ID
AND Product_ID = @Product_ID
END