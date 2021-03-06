USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_BalanceItemUpdate]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BalanceItemUpdate]
	-- Add the parameters for the stored procedure here
		@ID					INT,
		@AfetaSaldo			BIT,
		@Grupo				NCHAR(1),
		@Categoria			NVARCHAR(20) = NULL,
		@SubCategoria		NVARCHAR(30) = NULL,
		@Descricao			NVARCHAR(200) = NULL,
		@NovoGrupo			NVARCHAR(15) = NULL,
		@NovaCategoria		NVARCHAR(20) = NULL,
		@NovaSubCategoria	NVARCHAR(30) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.tblBalance
	SET
	AfetaSaldo =		@AfetaSaldo,
	Grupo = 			@Grupo, 
	Categoria =			@Categoria, 
	SubCategoria =		@SubCategoria,
	Descricao =			@Descricao,
	NovoGrupo =			@NovoGrupo,
	NovaCategoria =		@NovaCategoria,
	NovaSubCategoria =	@NovaSubCategoria
	WHERE dbo.tblBalance.ID = @ID;
END
GO
