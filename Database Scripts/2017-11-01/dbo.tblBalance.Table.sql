USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblBalance]    Script Date: 01/11/2017 19:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBalance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [varchar](3) NOT NULL,
	[Data] [date] NOT NULL,
	[Historico] [nvarchar](200) NOT NULL,
	[Documento] [nvarchar](50) NULL,
	[Valor] [money] NOT NULL,
	[AfetaSaldo] [bit] NOT NULL,
	[Grupo] [nchar](1) NOT NULL,
	[Categoria] [nvarchar](20) NOT NULL,
	[SubCategoria] [nvarchar](30) NULL,
	[Descricao] [nvarchar](200) NULL,
	[NovoGrupo] [nvarchar](15) NULL,
	[NovaCategoria] [nvarchar](20) NULL,
	[NovaSubCategoria] [nvarchar](30) NULL,
	[GrupoId] [int] NULL,
 CONSTRAINT [PK_tblBalance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblBalance] ADD  CONSTRAINT [DF_tblBalance_Banco]  DEFAULT ('') FOR [Banco]
GO
ALTER TABLE [dbo].[tblBalance]  WITH CHECK ADD  CONSTRAINT [FK_tblBalance_tblNovosGrupos] FOREIGN KEY([GrupoId])
REFERENCES [dbo].[tblNovosGrupos] ([GrupoId])
GO
ALTER TABLE [dbo].[tblBalance] CHECK CONSTRAINT [FK_tblBalance_tblNovosGrupos]
GO
