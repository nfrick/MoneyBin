USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblCalendar]    Script Date: 01/11/2017 19:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCalendar](
	[Year] [smallint] NOT NULL,
	[Month] [smallint] NOT NULL,
	[PaymentID] [int] NOT NULL,
	[Paid] [bit] NOT NULL,
 CONSTRAINT [PK_tblCalendar] PRIMARY KEY CLUSTERED 
(
	[Year] DESC,
	[Month] DESC,
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
