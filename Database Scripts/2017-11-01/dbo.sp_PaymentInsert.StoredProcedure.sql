USE [MoneyBin]
GO
/****** Object:  StoredProcedure [dbo].[sp_PaymentInsert]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PaymentInsert]
       @Group           NVARCHAR(10), 
       @Description     NVARCHAR(30),
	   @Day				TINYINT,
       @Enabled		    BIT,
	   @Months			SMALLINT
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.tblPayments
          (
		  [Group],
		  [Description],
		  [Day],
		  [Enabled],
		  [Months]
          ) 
     VALUES 
          ( 
		  @Group,       
		  @Description, 
		  @Day,			
		  @Enabled,		
		  @Months		
          ) 

END 

GO
