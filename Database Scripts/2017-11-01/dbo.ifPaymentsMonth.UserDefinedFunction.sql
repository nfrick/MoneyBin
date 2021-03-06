USE [MoneyBin]
GO
/****** Object:  UserDefinedFunction [dbo].[ifPaymentsMonth]    Script Date: 01/11/2017 21:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ifPaymentsMonth]
(	
	-- Add the parameters for the function here
	@Month	SMALLINT
)
RETURNS TABLE 
AS
RETURN
(
	-- Returns all payments for a given month
	-- Month: 1=Jan, 2=Feb, 4=Mar, 8=Apr, 16=May, 32=Jun, 64=Jul
	--        128=Aug, 256=Sep, 512=Oct, 1024=Nov, 2048=Dec
	--        4095=All
	SELECT * FROM dbo.tblPayments
	WHERE ([Enabled] = 1)
		AND ([Months] & @Month = @Month)
)
GO
