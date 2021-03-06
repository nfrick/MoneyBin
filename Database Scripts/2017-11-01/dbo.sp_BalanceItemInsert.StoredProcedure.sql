USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_BalanceItemInsert]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BalanceItemInsert]
       @Banco				VARCHAR(3), 
       @Data				DATE, 
       @Historico			NVARCHAR(200), 
       @Documento			NVARCHAR(20) = NULL, 
       @Valor				MONEY, 
       @AfetaSaldo			BIT,
	   @Grupo				NCHAR(1),
	   @Categoria			NVARCHAR(20),
	   @SubCategoria		NVARCHAR(30),
	   @Descricao			NVARCHAR(200) = NULL,
	   @NovoGrupo			NVARCHAR(15) = NULL,
	   @NovaCategoria		NVARCHAR(20) = NULL,
	   @NovaSubCategoria	NVARCHAR(30) = NULL
AS 
BEGIN 
	SET NOCOUNT ON 

	INSERT INTO dbo.tblBalance (
		Banco,
		Data,
		Historico,
		Documento,
		Valor,
		AfetaSaldo,
		Grupo,
		Categoria,
		SubCategoria,
		Descricao,
		NovoGrupo,
		NovaCategoria,
		NovaSubCategoria
	) 
	VALUES ( 
		@Banco,
		@Data,
		@Historico,
		@Documento,
		@Valor,
		@AfetaSaldo,
		@Grupo,		
		@Categoria,
		@SubCategoria,
		@Descricao,
		@NovoGrupo,
		@NovaCategoria,
		@NovaSubCategoria
	)

	SELECT SCOPE_IDENTITY() AS NewID WHERE @@ROWCOUNT > 0

END 
GO
