USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblGroups]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGroups](
	[GrupoID] [nchar](1) NOT NULL,
	[Descricao] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblGrupos] PRIMARY KEY CLUSTERED 
(
	[GrupoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
