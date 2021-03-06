USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblNovosGrupos]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNovosGrupos](
	[GrupoId] [int] IDENTITY(1,1) NOT NULL,
	[NovoGrupo] [nvarchar](15) NOT NULL,
	[NovaCategoria] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblNovosGrupos_1] PRIMARY KEY CLUSTERED 
(
	[GrupoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
