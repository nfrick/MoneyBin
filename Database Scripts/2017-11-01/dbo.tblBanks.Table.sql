USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblBanks]    Script Date: 01/11/2017 19:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBanks](
	[Banco] [varchar](3) NOT NULL,
	[Extensao] [varchar](4) NOT NULL,
 CONSTRAINT [PK_tblBancos] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
