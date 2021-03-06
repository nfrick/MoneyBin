USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalendarNextPayments]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CalendarNextPayments]
	   @Days	INT
AS 
BEGIN 
     SET NOCOUNT ON 

	 SELECT [Date], [Group], [DaysLate], [Description] FROM
		(SELECT [Date], [Group], [Description], DATEDIFF(day, GETDATE(), [Date]) as [DaysLate], [Paid]
			FROM dbo.vw_Calendar) Calendar
	 WHERE [Paid] = 0 AND [DaysLate] <= @Days
	 ORDER BY [Date], [Group], [Description]
END 
GO
