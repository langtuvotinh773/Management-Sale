SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Proc [dbo].[spImportSalaryPercent]
	
	@Emp_ID int,
	@Product_ID int,
	@Percent smallint,
	@Note nvarchar(100)
AS
BEGIN
	Update tbl_SalaryPercents
	Set Percents =@Percent,
	Note=@Note
	Where  Product_ID = @Product_ID AND Emp_ID = @Emp_ID
	
END

