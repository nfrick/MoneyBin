USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_AcertosPendentes]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AcertosPendentes] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT	*, 0.0 AS Saldo
	FROM	tblBalance
	WHERE	Banco = 'BB' AND AfetaSaldo = 1 AND Valor < 0 AND 
				(NovoGrupo IN (N'Rio','Araras') AND 
				NovaCategoria IN (N'Casa') AND 
				Data > (SELECT Max(Data) FROM tblBalance 
					WHERE NovoGrupo = 'Rendas' AND NovaCategoria = 'Papai' AND NovaSubCategoria = 'Ajuda'))
	ORDER BY Data
END
GO
