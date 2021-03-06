USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_GruposCategorias]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GruposCategorias]
	@Banco	VARCHAR(3) = NULL,
	@Inicio     DATE = NULL,
	@Termino    DATE = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT Grupo, Categoria FROM dbo.tblbalance 
	WHERE 
		(@Banco IS NULL OR Banco = @Banco) AND 
		((@Inicio IS NULL OR @Termino IS NULL) OR (Data BETWEEN @Inicio AND @Termino))
		ORDER BY Grupo, Categoria
	OPTION (RECOMPILE)
END
GO
