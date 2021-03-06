USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSaldo]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE procedure [dbo].[sp_GetSaldo]
  @Banco	VARCHAR(3),
  @Data     DATE

  AS 
BEGIN 
     SET NOCOUNT ON 
SELECT COALESCE(SUM(Valor),0) AS Total FROM dbo.tblBalance 
WHERE Banco = @Banco AND Data <= @Data AND AfetaSaldo = 1
END
GO
