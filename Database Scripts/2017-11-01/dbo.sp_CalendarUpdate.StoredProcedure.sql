USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalendarUpdate]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CalendarUpdate]
	-- Add the parameters for the stored procedure here
		@Year			SMALLINT,
		@Month			SMALLINT,
		@ID				INT,
		@Paid			BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.tblCalendar
	SET
		[Paid] = @Paid
	WHERE dbo.tblCalendar.[PaymentID] = @ID AND dbo.tblCalendar.[Year] = @Year AND dbo.tblCalendar.[Month] = @Month;
END


GO
