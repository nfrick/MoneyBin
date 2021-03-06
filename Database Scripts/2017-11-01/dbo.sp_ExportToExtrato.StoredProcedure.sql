USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_ExportToExtrato]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nelson Frick
-- Create date: 25/09/2017
-- Description:	Exporta diretamente para o antigo programa Extrato
--				sem precisar passar por CSV ou outro formato intermediário
-- How to set permissions:
-- https://www.aspsnippets.com/Articles/The-OLE-DB-provider-Microsoft.Ace.OLEDB.12.0-for-linked-server-null.aspx
-- =============================================
CREATE PROCEDURE [dbo].[sp_ExportToExtrato] 
	-- Add the parameters for the stored procedure here
	@AccessDB NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	DECLARE @sql NVARCHAR(max)

	SET @sql = 
	'DELETE OPENROWSET(''Microsoft.ACE.OLEDB.12.0'', '''
	+ @AccessDB + ''';''admin'';'''', tblExtrato)'
	EXEC(@sql)

	SET @sql = 
	'INSERT INTO OPENROWSET(''Microsoft.ACE.OLEDB.12.0'', '''
	+ @AccessDB + ''';''admin'';'''', tblExtrato)
	SELECT [Banco]
		  ,[Data]
		  ,[Historico]
		  ,[Documento]
		  ,[Valor]
		  ,[AfetaSaldo]
		  ,[Grupo]
		  ,[Categoria]
		  ,[SubCategoria]
		  ,[Descricao]
	  FROM [dbo].[tblBalance] ORDER BY Data, ID'
	  EXEC(@sql)
END
GO
