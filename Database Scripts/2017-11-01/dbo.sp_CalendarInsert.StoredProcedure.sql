USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalendarInsert]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CalendarInsert]
	   @Year		SMALLINT,
	   @Month		SMALLINT
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.tblCalendar
          (
		  [Year],
		  [Month],
		  [PaymentID],
		  Paid
          ) 
     SELECT @Year as [Year], @Month as [Month], [ID], 0
	 FROM ifPaymentsMonth(@Month)
	 WHERE ([ID] NOT IN (SELECT PaymentID FROM dbo.vw_Calendar WHERE [Year] = @Year AND [Month] = @Month))
END 


GO
