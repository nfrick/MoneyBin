USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_RuleUpdate]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_RuleUpdate]
	-- Add the parameters for the stored procedure here
		@ID				INT,
		@Banco			NVARCHAR(3),
		@Historico		NVARCHAR(200),
		@Comparacao		SMALLINT,
		@AfetaSaldo		BIT,
		@Grupo			NCHAR(1),
		@Categoria		NVARCHAR(20) = NULL,
		@SubCategoria	NVARCHAR(30) = NULL,
		@Descricao		NVARCHAR(30) = NULL,
		@NovoGrupo		NVARCHAR(15) = NULL,
		@NovaCategoria		NVARCHAR(20) = NULL,
		@NovaSubCategoria	NVARCHAR(30) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.tblRules
	SET
	Banco =			@Banco,
	Historico =		@Historico,
	Comparacao =	@Comparacao,
	AfetaSaldo =	@AfetaSaldo,
	Grupo = 		@Grupo, 
	Categoria =		@Categoria, 
	SubCategoria =	@SubCategoria,
	Descricao =		@Descricao,
	NovoGrupo=		@NovoGrupo,
	NovaCategoria =	@NovaCategoria,
	NovaSubCategoria = @NovaSubCategoria

	WHERE dbo.tblRules.ID = @ID;
END

GO
