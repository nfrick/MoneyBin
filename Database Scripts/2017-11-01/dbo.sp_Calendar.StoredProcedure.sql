USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_Calendar]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Calendar]
	   @Year		SMALLINT,
	   @Month		SMALLINT
AS 
BEGIN 
     SET NOCOUNT ON 

     SELECT * FROM dbo.vw_Calendar
	 WHERE [Year] = @Year AND [Month] = @Month
	 ORDER BY [Day], [Group], [Description], [Paid]
END 
GO
