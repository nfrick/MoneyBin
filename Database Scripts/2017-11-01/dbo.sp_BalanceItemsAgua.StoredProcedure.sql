USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_BalanceItemsAgua]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nelson Frick
-- Create date: 
-- Description:	Busca pagamentos de água nos extratos do Balance
-- Changed 27/09/2017 - Precisão da pesquisa melhorada com Data no intervalo
--         e Valor tendo que ser múltiplo da cota
-- =============================================
CREATE PROCEDURE [dbo].[sp_BalanceItemsAgua]
	-- Add the parameters for the stored procedure here
	@ID     int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- como usar variáveis: https://stackoverflow.com/questions/4823880/sql-server-select-into-variable

DECLARE @Emissao SMALLDATETIME
DECLARE @ValorBase MONEY

SELECT	@Emissao = Emissao, 
		@ValorBase = Round(Cota*Meses, 0) 
	FROM AguaAraras.dbo.tblRecibos 
	WHERE ID = @ID

SELECT Data, Valor, SubCategoria as Nome
	FROM dbo.tblBalance 
	WHERE Grupo = 'A' AND 
		  Categoria = 'Receita' AND 
		  AfetaSaldo = 1 AND 
		  Data BETWEEN @Emissao AND DATEADD(month, 3, @Emissao)
		  AND ROUND(Valor,0) % @ValorBase = 0
	ORDER BY Data

END
GO
