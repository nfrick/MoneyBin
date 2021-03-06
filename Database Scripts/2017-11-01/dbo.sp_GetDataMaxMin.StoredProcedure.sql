USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDataMaxMin]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE procedure [dbo].[sp_GetDataMaxMin]
  @Banco	VARCHAR(3),
  @Max		DATETIME	OUTPUT,
  @Min		DATETIME	OUTPUT

  AS 
BEGIN 
     SET NOCOUNT ON 
SELECT	@Max = Max(Data), 
		@Min = Min(Data)
--		SELECT	@Max = COALESCE(Max(Data), NULL, 1900-01-01), 
--		@Min = COALESCE(Min(Data), NULL, 1900-01-01) 
 FROM dbo.tblBalance WHERE Banco = @Banco
END

GO
