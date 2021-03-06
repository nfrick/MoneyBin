USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDataMinMax]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE procedure [dbo].[sp_GetDataMinMax]
  @Banco	VARCHAR(3),
  @Max		DATETIME	OUTPUT,
  @Min		DATETIME	OUTPUT

  AS 
BEGIN 
     SET NOCOUNT ON 
SELECT	@Max = Max(Data), 
		@Min = Min(Data) 
 FROM dbo.tblBalance WHERE Banco = @Banco
END

GO
