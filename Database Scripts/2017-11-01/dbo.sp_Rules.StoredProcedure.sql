USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_Rules]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Rules]
	-- Add the parameters for the stored procedure here
	@Banco		VARCHAR(3)	= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.tblRules
	WHERE (@Banco IS NULL OR Banco = @Banco)
	ORDER BY Ocorrencias DESC
	OPTION (RECOMPILE)
END


GO
