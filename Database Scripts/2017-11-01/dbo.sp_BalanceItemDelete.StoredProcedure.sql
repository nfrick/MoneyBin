USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_BalanceItemDelete]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BalanceItemDelete]
	-- Add the parameters for the stored procedure here
		@ID				INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.tblBalance
	WHERE dbo.tblBalance.ID = @ID;
END
GO
