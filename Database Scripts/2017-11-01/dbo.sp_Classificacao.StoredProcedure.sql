USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_Classificacao]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Classificacao]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT Grupo, Categoria, SubCategoria, COALESCE(Descricao, '') AS Descricao FROM dbo.tblBalance WHERE Grupo <> ''
END
GO
