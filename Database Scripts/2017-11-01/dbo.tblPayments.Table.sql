USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblPayments]    Script Date: 01/11/2017 19:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Group] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
	[Day] [tinyint] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Months] [int] NOT NULL,
 CONSTRAINT [PK_tblPayments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblPayments] ADD  CONSTRAINT [DF__tblPaymen__Enabl__3335971A]  DEFAULT ((1)) FOR [Enabled]
GO
