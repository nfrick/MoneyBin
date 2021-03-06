USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_RuleInsert]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_RuleInsert]
       @Banco           NVARCHAR(3), 
       @Historico       NVARCHAR(200),
	   @Comparacao		SMALLINT,
       @AfetaSaldo      BIT,
	   @Grupo			NCHAR(1),
	   @Categoria		NVARCHAR(20),
	   @SubCategoria	NVARCHAR(30),
	   @Descricao		NVARCHAR(30) = NULL,
		@NovoGrupo		NVARCHAR(15) = NULL,
		@NovaCategoria		NVARCHAR(20) = NULL,
		@NovaSubCategoria	NVARCHAR(30) = NULL
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.tblRules
          (
		Banco,
		Historico,
		Comparacao,
		AfetaSaldo,
		Grupo,
		Categoria,
		SubCategoria,
		Descricao,
		NovoGrupo,
		NovaCategoria,
		NovaSubCategoria
          ) 
     VALUES 
          ( 
		@Banco,
		@Historico,
		@Comparacao,
		@AfetaSaldo,
		@Grupo,		
		@Categoria,
		@SubCategoria,
		@Descricao,
		@NovoGrupo,
		@NovaCategoria,
		@NovaSubCategoria
          ) 

END 
GO
