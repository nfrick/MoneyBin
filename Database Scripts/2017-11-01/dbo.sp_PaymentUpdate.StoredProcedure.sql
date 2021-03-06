USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_PaymentUpdate]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PaymentUpdate]
	-- Add the parameters for the stored procedure here
	@ID				INT,
    @Group          NVARCHAR(10), 
    @Description    NVARCHAR(30),
	@Day			TINYINT,
    @Enabled		BIT,
	@Months			SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.tblPayments
	SET
	[Group] =		@Group,      
	[Description] =	@Description,
	[Day] =			@Day,		
	[Enabled] =		@Enabled,	
	[Months] =		@Months		
	
	WHERE dbo.tblPayments.ID = @ID;
END


GO
