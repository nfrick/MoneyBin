USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalendarClean]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CalendarClean]
	-- Add the parameters for the stored procedure here
		@Year	SMALLINT,
		@Month	SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.tblCalendar
	WHERE [Year] = @Year AND [Month] = @Month 
		AND PaymentID NOT IN (SELECT ID FROM ifPaymentsMonth(@Month))
END
GO
