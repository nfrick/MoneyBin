USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_AnosMeses]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AnosMeses]
  @Banco	VARCHAR(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
WITH Dates(FormattedDate) AS
(
	SELECT CONVERT(nvarchar(10), Data, 112) AS FormattedDate
	FROM dbo.tblbalance WHERE Banco = @Banco
)

SELECT DISTINCT Left(FormattedDate, 4) AS Ano, Substring(FormattedDate, 5, 2) AS Mes 
FROM Dates ORDER BY Ano Desc, Mes Desc
END
GO
