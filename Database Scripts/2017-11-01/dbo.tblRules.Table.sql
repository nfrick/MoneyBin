USE [MoneyBin]
GO
/****** Object:  Table [dbo].[tblRules]    Script Date: 01/11/2017 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRules](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [varchar](3) NOT NULL,
	[Historico] [nvarchar](200) NOT NULL,
	[Comparacao] [int] NOT NULL,
	[AfetaSaldo] [bit] NOT NULL,
	[Grupo] [nchar](1) NULL,
	[Categoria] [nvarchar](20) NULL,
	[SubCategoria] [nvarchar](30) NULL,
	[Descricao] [nvarchar](30) NULL,
	[Ocorrencias] [int] NULL,
	[NovoGrupo] [nvarchar](15) NULL,
	[NovaCategoria] [nvarchar](20) NULL,
	[NovaSubCategoria] [nvarchar](30) NULL,
 CONSTRAINT [PK_tblRules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblRules] ADD  CONSTRAINT [DF__tblCondit__Ocorr__5A846E65]  DEFAULT ((0)) FOR [Ocorrencias]
GO
ALTER TABLE [dbo].[tblRules]  WITH CHECK ADD  CONSTRAINT [FK_tblRules_tblBanks] FOREIGN KEY([Banco])
REFERENCES [dbo].[tblBanks] ([Banco])
GO
ALTER TABLE [dbo].[tblRules] CHECK CONSTRAINT [FK_tblRules_tblBanks]
GO
ALTER TABLE [dbo].[tblRules]  WITH CHECK ADD  CONSTRAINT [CK__tblCondit__Compa__65F62111] CHECK  (([Comparacao]=(4) OR [Comparacao]=(3) OR [Comparacao]=(2) OR [Comparacao]=(1) OR [Comparacao]=(0)))
GO
ALTER TABLE [dbo].[tblRules] CHECK CONSTRAINT [CK__tblCondit__Compa__65F62111]
GO
