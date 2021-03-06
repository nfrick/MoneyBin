USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_BalanceItems]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BalanceItems]
	-- Add the parameters for the stored procedure here
	@Banco		VARCHAR(3)	= NULL,
	@Inicio     DATE		= NULL,
	@Termino    DATE		= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @Banco IS NULL
		BEGIN
			SELECT * FROM dbo.tblBalance ORDER BY ID
		END
	ELSE
		BEGIN
			SET @Termino = ISNULL(@Termino, GETDATE())

			SELECT tblBalance.*, tblGroups.Descricao AS GrupoNome
			FROM dbo.tblBalance INNER JOIN tblGroups ON Grupo = tblGroups.GrupoID 
			WHERE 
				Banco = @Banco AND
				Data BETWEEN @Inicio AND @Termino
			ORDER BY Data DESC, Grupo, Categoria, SubCategoria, Valor ASC
		END
END
GO
