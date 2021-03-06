USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalendarRefresh]    Script Date: 01/11/2017 21:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Atualiza calendário 
-- =============================================
CREATE PROCEDURE [dbo].[sp_CalendarRefresh]
	-- Add the parameters for the stored procedure here
		@Year	SMALLINT,
		@Month	SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Inclui novos pagamentos no calendário
	-- (novos ou marcados como "do mês" após criação do calendário
	INSERT INTO dbo.tblCalendar (
		  [Year],
		  [Month],
		  [PaymentID],
		  Paid) 
	SELECT @Year as [Year], @Month as [Month], [ID], 0
		FROM ifPaymentsMonth(@Month)
		WHERE ([ID] NOT IN (SELECT PaymentID FROM dbo.vw_Calendar WHERE [Year] = @Year AND [Month] = @Month));

	-- Remove pagamentos do calendário
	-- (deletados ou desmarcados como "do mês" após criação do calendário
	DELETE FROM dbo.tblCalendar
		WHERE [Year] = @Year AND [Month] = @Month 
		AND PaymentID NOT IN (SELECT ID FROM ifPaymentsMonth(@Month));

END
GO
