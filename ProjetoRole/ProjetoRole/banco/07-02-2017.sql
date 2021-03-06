USE [ProjetoRole]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAAction]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAAction](
	[pkAction] [int] IDENTITY(1,1) NOT NULL,
	[nomeAction] [varchar](70) NOT NULL,
	[descricaoPagina] [varchar](50) NOT NULL,
	[mostrarMenu] [bit] NOT NULL,
	[ativo] [bit] NOT NULL,
	[icone] [nvarchar](150) NULL,
	[fkController] [int] NULL,
 CONSTRAINT [PK_Paginas] PRIMARY KEY CLUSTERED 
(
	[pkAction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAActionModulo]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAActionModulo](
	[pkModuloAction] [int] IDENTITY(1,1) NOT NULL,
	[fkModulo] [int] NOT NULL,
	[fkAction] [int] NOT NULL,
 CONSTRAINT [PK_CAActionModulo] PRIMARY KEY CLUSTERED 
(
	[pkModuloAction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAAuditoria]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAAuditoria](
	[pkAuditoria] [int] NOT NULL,
	[fkUsuario] [int] NOT NULL,
	[dataHora] [datetime] NOT NULL,
	[fkAction] [int] NULL,
	[url] [nvarchar](150) NULL,
 CONSTRAINT [PK_CAAuditoria] PRIMARY KEY CLUSTERED 
(
	[pkAuditoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAController]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAController](
	[pkController] [int] IDENTITY(1,1) NOT NULL,
	[nomeController] [nvarchar](50) NOT NULL,
	[descricaoController] [nvarchar](250) NULL,
 CONSTRAINT [PK_UsuController] PRIMARY KEY CLUSTERED 
(
	[pkController] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAInstancia]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAInstancia](
	[pkInstancia] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[descricao] [varchar](150) NULL,
 CONSTRAINT [PK__TbObra__3214EC071920BF5C] PRIMARY KEY CLUSTERED 
(
	[pkInstancia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CALogAcesso]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CALogAcesso](
	[pkLogAcesso] [int] IDENTITY(1,1) NOT NULL,
	[fkUsuario] [int] NOT NULL,
	[dataHora] [datetime] NOT NULL,
	[ip] [varchar](15) NOT NULL,
 CONSTRAINT [PK_LogAcesso] PRIMARY KEY CLUSTERED 
(
	[pkLogAcesso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAModulo]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAModulo](
	[pkModulo] [int] IDENTITY(1,1) NOT NULL,
	[nomeModulo] [varchar](50) NOT NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[pkModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAModuloPerfil]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAModuloPerfil](
	[pkModuloPerfil] [int] IDENTITY(1,1) NOT NULL,
	[fkPerfil] [int] NOT NULL,
	[fkModulo] [int] NOT NULL,
 CONSTRAINT [PK_ModuloPerfil] PRIMARY KEY CLUSTERED 
(
	[pkModuloPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAPerfil]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAPerfil](
	[pkPerfil] [int] IDENTITY(1,1) NOT NULL,
	[nomePerfil] [varchar](50) NOT NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[pkPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAUsuario]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAUsuario](
	[pkUsuario] [int] IDENTITY(1,1) NOT NULL,
	[fkPerfil] [int] NOT NULL,
	[fkLocalidade] [int] NULL,
	[fkInstancia] [int] NULL,
	[nome] [varchar](70) NOT NULL,
	[apelido] [nvarchar](100) NULL,
	[email] [varchar](80) NULL,
	[senha] [nvarchar](250) NULL,
	[fone] [varchar](20) NULL,
	[ativo] [bit] NOT NULL,
	[foto] [nvarchar](50) NULL,
	[coordenadas] [geography] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[pkUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[pkCometario] [int] IDENTITY(1,1) NOT NULL,
	[tituloComentario] [nvarchar](100) NULL,
	[comentario] [varchar](250) NULL,
	[ativo] [bit] NULL,
	[fkUsuario] [int] NULL,
	[fkRole] [int] NULL,
	[fkComentario] [int] NULL,
	[dataHora] [datetime] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[pkCometario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Foto]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foto](
	[pkFoto] [int] IDENTITY(1,1) NOT NULL,
	[tituloFoto] [nvarchar](100) NULL,
	[foto] [nvarchar](50) NULL,
	[ativo] [bit] NULL,
	[fkUsuario] [int] NULL,
	[fkRole] [int] NULL,
	[dataHora] [datetime] NULL,
 CONSTRAINT [PK_Foto] PRIMARY KEY CLUSTERED 
(
	[pkFoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Localidade]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidade](
	[pkLocalidade] [int] IDENTITY(1,1) NOT NULL,
	[cidade] [nvarchar](100) NOT NULL,
	[uf] [nvarchar](60) NULL,
	[pais] [nvarchar](40) NULL,
	[idFBLocalidade] [bigint] NULL,
	[nomeCompletoLocal] [nvarchar](200) NULL,
	[coordenadas] [geography] NULL,
 CONSTRAINT [PK_dbo.LCLocalidade] PRIMARY KEY CLUSTERED 
(
	[pkLocalidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marca]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[pkMarca] [int] NOT NULL,
	[DescricaoMarca] [nvarchar](70) NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[pkMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Moto]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moto](
	[pkMoto] [int] IDENTITY(1,1) NOT NULL,
	[nomeMoto] [nvarchar](80) NULL,
	[modeloMoto] [nvarchar](50) NULL,
	[fkMarca] [int] NULL,
	[foto] [nvarchar](150) NULL,
	[ativa] [bit] NULL,
	[fkUsuario] [int] NULL,
 CONSTRAINT [PK_Moto] PRIMARY KEY CLUSTERED 
(
	[pkMoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Participamente]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participamente](
	[pkParticipamento] [int] NOT NULL,
	[fkUsuario] [int] NULL,
	[fkMoto] [int] NULL,
	[fkRole] [int] NULL,
	[participou] [bit] NULL,
	[autorizado] [bit] NULL,
 CONSTRAINT [PK_Participamente] PRIMARY KEY CLUSTERED 
(
	[pkParticipamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[pkRole] [int] IDENTITY(1,1) NOT NULL,
	[fkUsuario] [int] NOT NULL,
	[fkTipoRole] [int] NOT NULL,
	[dataHoraCadastro] [datetime] NOT NULL,
	[titulo] [nvarchar](100) NOT NULL,
	[descricaoRole] [nvarchar](250) NOT NULL,
	[capa] [nvarchar](50) NULL,
	[totalKM] [int] NULL,
	[localPartida] [nvarchar](150) NOT NULL,
	[localDestino] [nvarchar](150) NULL,
	[dataRole] [date] NULL,
	[horaRole] [time](7) NOT NULL,
	[fkLocalidade] [int] NOT NULL,
	[ativo] [bit] NULL,
	[publico] [bit] NULL,
	[realizado] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[pkRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoRole]    Script Date: 2/7/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRole](
	[pkTipoRole] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoRole] PRIMARY KEY CLUSTERED 
(
	[pkTipoRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201701230240148_InitialCreate', N'ProjetoRole.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EDC36107D2FD07F10F4D416CECA9726488DDD04CEDA6E8DC617649DA06F0157E2AED548942A51AE8DA25FD6877E527FA14389BAF1A2CBAEBCBB0E020416393C331C0EC9E170B8FFFDF3EFF8ED83EF19F7388ADD804CCC83D1BE696062078E4B961333A18B17AFCDB76FBEFD667CE6F80FC6A79CEE88D1414B124FCC3B4AC363CB8AED3BECA378E4BB7614C4C1828EECC0B790135887FBFB3F59070716060813B00C63FC2121D4F571FA019FD380D838A409F22E03077B312F879A598A6A5C211FC721B2F1C4BC8982DF310D3E041E1E65D4A671E2B9082499616F611A889080220A721E7F8CF18C460159CE422840DEED6388816E81BC1873F98F4BF2AE5DD93F645DB1CA8639949DC434F07B021E1C71DD5862F395346C16BA03ED9D8196E923EB75AAC18979E1E0B48869CF344486C7532F62C413F3B26071128757988EF286A30CF23C02B83F83E8CBA88AB867746EB757D8D2E1689FFDDB33A6894793084F084E6884BC3DE326997BAEFD2B7EBC0DBE6032393A982F8E5EBF7C859CA3573FE2A397D59E425F81AE560045602A218E4036BC28FA6F1A56BD9D25362C9A55DA645A015B8269611A97E8E13D264B7A0713E6F0B5699CBB0FD8C94BB8717D242ECC226844A3043EAF12CF43730F17F556234FF67F03D7C397AF06E17A85EEDD653AF4027F983811CCAB0FD84B6BE33B37CCA6576DBC3F73B2F328F0D977DDBEB2DACFB320896CD699404B728BA225A675E9C65669BC9D4C9A410D6FD639EAEE9B369354366F2529EBD02A332167B1E9D990CBFBB47C3B5BDC4918C2E0A5A6C534D26470F26635125A832D9434A5E91C74351D025DFA9A57C2331FB9DE004B61072EE0852CDCC8C7452FDF05302688F496F906C531AC04CE2F28BE6B101DFE1C40F419B693080C7446911F3E39B79BBB80E0ABC49F33BBDF1CAFC186E6F6CFE01CD93488CE086BB536DEFBC0FE1224F48C38A788E28FD4CE01D9E7ADEB770718449C13DBC6717C0EC68C9D69004E760E7841E8D1616F38B6406DDB15997AC8F5D5BE88B0947ECE494B7F444D21F9241A32955FD224EAFB60E9926EA2E6A47A51338A565139595F511958374939A55ED094A055CE8C6A304F2F1DA1E15DBD1476F77DBDF5366FDD5A5051E30C5648FC3326388265CCB94194E2889423D065DDD886B3900E1F63FAE47B53CAE913F292A159AD341BD24560F8D990C2EEFE6C48C584E27BD7615E498703504E0CF09DE8D567ABF6392748B6E9E950EBE6A6996F660DD04D9793380E6C379D058AD0170F5CD4E5071FCE688F6264BD112321D0313074976D7950027D3345A3BA26A7D8C3141B2776161A9CA2D8468EAC46E890D343B07C475508564644EAC2FD20F1044BC7116B84D821288699EA122A4F0B97D86E88BC562D092D3B6E61ACEF050FB1E61487983086AD9AE8C25C1D006102147C844169D3D0D8AA585CB3216ABC56DD98B7B9B0E5B84B71898DD8648BEFACB14BEEBF3D8961366B6C03C6D9AC922E02688379DB30507E56E96A00E2C165D70C543831690C94BB541B31D0BAC6B660A075953C3B03CD8EA85DC75F38AFEE9A79D60FCA9BDFD61BD5B505DBACE963C74C33F33DA10D85163892CDF374CE2AF103551CCE404E7E3E8BB9AB2B9A08039F615A0FD994FEAED20FB59A4144236A022C0DAD05945F034A40D284EA215C1ECB6B948E7B113D60F3B85B232C5FFB05D88A0DC8D8D5EBD00AA1FED25434CE4EA78FA26785354846DEE9B050C1511884B878D53BDE4129BAB8ACAC982EBE701F6FB8D2313E180D0A6AF15C354ACA3B33B89672D36CD792CA21EBE392ADA525C17DD26829EFCCE05AE236DAAE248553D0C32D584B45F52D7CA0C996473A8ADDA6A81B5B5996142F185B9A74AAF1250A43972C2BE955BCC49865B955D317B3FE49477E8661D9B122F7A890B6E04483082DB1500BAC41D273378AE929A2688E589C67EAF81299726FD52CFF39CBEAF6290F62BE0FE4D4ECEF227C265EDED7F65AD919E118E7D0439F793469185D31FEEAE6064B77431E8A1491FB69E0253ED13B58FAD6D9FD5DB57D5622238C2D417EC98192B425B9B975D5771A1879520C344885FFB2FA40E92174EACEBDCFAAC2751EA91E250F5055517441ABAD0D9CCE91E93558A28FD87FAC5A119E665EF1C4942A002FEA8951C96D90C02A75DD51EBE92755CC7A4D774421C7A40A2954F590B29A495213B25AB1129E46A36A8AEE1CE4DC912ABA5CDB1D59914552855654AF80AD9059ACEB8EAA4834A9022BAABB63975927E222BAC33B97F6E4B2F2D6951D6ED7DBBB34184FB3220EB3F555EEF0AB4095E29E58FC965E02E3E53B694DDA13DECAD694C534D6B3260D867EE5A9DD7ED7179EC62B7B3D66ED4ABBB6B8375DE9EBF1FAD9EC935A8674C013490AEEC5414F38D08DF9E1AAFD118D74DACA484C2357236CEC8F31C5FE88118C667F7853CFC56C19CF092E11711738A6591A8779B87F7028BCC3D99D3731561C3B9EE270AA7B18531FB30D6464917B14D9772892F323D6783752824AA1E70BE2E08789F957DAEA388D62B0BFD2E23DE322FE48DC3F12A8B88D126CFC2DE77B0E9347DF7CC8DAD1570FDDB57AF1DBE7ACE99E711DC18C3936F6055DAE32C2F5B710BDA4C99AAE21CDCA2F249EEF84AA3D3F50A20A1362F5D70673970EF2D22097F23B1F3D7CDF5734E56B82B510152F0686C21B4485BA1701AB60695F0338F049D3D700FD3AAB7E1DB08A68DA97012EE90F26BE0BE8BE0CE52DB7B8D528CE449B5892523DB7E655AF9564B9EDBD494ABF5E6BA2CB29D63DE0D648A35EC1329E5906F260BBA322C17830EC6D9AF6936715EF4A227199E2B1DDFCE14DA60C375C0B7D5599C23B90DBA6C8D5D97E3EF0A66D4D17C7DDF1A4CA7E59BF3B666C3C836BFBB9BD9B36365D9877C78DAD5706EF8ED9DAB6F6CF2D5B5AE72D74EBF9B8726A91E63E46150B6ECBB7CD02E770C29F0760049947993D935427783525A7B6302C49F44CF59965226369E2487C258A66B6FDFACA37FCC6CE729A66B69A7CCC26DE7CFD6FE4CD699A796BB21CB79129ACCC3354656FB7AC634D4950CF2933B8D6939644F4369FB5F172FD3925020FA294DAECD1DC113F9FBCDF415432E4D4E991E72B5FF7C2DE59F96545D8BF63775942B0DF5924D8AEED9A05CD055904F9E62D48949308119A4B4C91035BEA4944DD05B22954B31873FACE3B8DDBB19B8E39762EC87542C3844297B13FF76A012FE60434F14F9399EB328FAFC3F4274B86E80288E9B2D8FC357997B89E53C87DAE880969209877C123BA6C2C298BEC2E1F0BA4AB807404E2EA2B9CA25BEC871E80C5D76486EEF12AB281F9BDC74B643F9611401D48FB40D4D53E3E75D132427ECC31CAF6F00936ECF80F6FFE0799E06C8760540000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[CAInstancia] ON 

INSERT [dbo].[CAInstancia] ([pkInstancia], [nome], [descricao]) VALUES (1, N'Padrão', N'Padrão')
SET IDENTITY_INSERT [dbo].[CAInstancia] OFF
SET IDENTITY_INSERT [dbo].[CALogAcesso] ON 

INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (1, 1, CAST(N'2017-01-29T00:58:24.207' AS DateTime), N'ROSRVSQL01')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (2, 1, CAST(N'2017-01-29T01:05:59.413' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (3, 1, CAST(N'2017-01-29T01:10:20.290' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (4, 1, CAST(N'2017-01-29T01:11:17.440' AS DateTime), N'192.168.0.14')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (5, 1, CAST(N'2017-02-04T20:10:59.317' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (6, 1, CAST(N'2017-02-04T22:33:03.077' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (7, 1, CAST(N'2017-02-05T11:04:16.913' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (8, 1, CAST(N'2017-02-06T10:25:56.947' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (9, 1, CAST(N'2017-02-07T16:27:46.613' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (10, 1, CAST(N'2017-02-07T16:35:22.120' AS DateTime), N'::1')
INSERT [dbo].[CALogAcesso] ([pkLogAcesso], [fkUsuario], [dataHora], [ip]) VALUES (11, 1, CAST(N'2017-02-07T17:43:49.047' AS DateTime), N'::1')
SET IDENTITY_INSERT [dbo].[CALogAcesso] OFF
SET IDENTITY_INSERT [dbo].[CAPerfil] ON 

INSERT [dbo].[CAPerfil] ([pkPerfil], [nomePerfil], [ativo]) VALUES (1, N'Basico', 1)
INSERT [dbo].[CAPerfil] ([pkPerfil], [nomePerfil], [ativo]) VALUES (2, N'Adm', 1)
SET IDENTITY_INSERT [dbo].[CAPerfil] OFF
SET IDENTITY_INSERT [dbo].[CAUsuario] ON 

INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (1, 1, 1, 1, N'JOSE MARIO FRAGA MIRANDA', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=                                                                                                                                                                                                                                              ', N'69 981147958', 0, N'item_0_7201772017.jpg', 0xE6100000010C97033DD4B68521C0EA69D14C41F34FC0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (2, 1, 1, 1, N'JOSE MARIO', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=', N'699+81147958', 0, NULL, 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (3, 1, 1, 1, N'mario', N'asa', N'aa', N'HXLCz3J4H0k=', N'556981147', 0, NULL, 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (4, 1, 2, 1, N'MRIO', N'ASA', N'aa', N'HXLCz3J4H0k=', N'444', 0, N'item_0_capa guidao.jpg', 0xE6100000010C687583B23A844FC03F75070CEDCF23C0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (5, 1, 1, 1, N'JOSÉ MÁRIO', N'Mário', N'mariofraga@gmail.com', N'HXLCz3J4H0k=', N'69981147958', 0, N'item_0_292017292017.jpg', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (6, 1, 4, 1, N'JOSE MARIO FRAGA MIRANDA', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=                                                                                                                                                                                                                                              ', N'69 981147958', 0, N'item_0_4201742017.jpg', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (7, 1, 5, 1, N'JOSE MARIO FRAGA MIRANDA', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=                                                                                                                                                                                                                                              ', N'69 981147958', 0, N'item_1_4201742017.jpg', 0xE6100000010C97033DD4B68521C0EA69D14C41F34FC0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (8, 1, 6, 1, N'JOSE MARIO FRAGA MIRANDA', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=                                                                                                                                                                                                                                              ', N'69 981147958', 0, N'item_2_4201742017.jpg', 0xE6100000010C97033DD4B68521C0EA69D14C41F34FC0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (9, 1, 7, 1, N'JOSE MARIO FRAGA MIRANDA', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=                                                                                                                                                                                                                                              ', N'69 981147958', 0, N'item_3_4201742017.jpg', 0xE6100000010C97033DD4B68521C0EA69D14C41F34FC0)
INSERT [dbo].[CAUsuario] ([pkUsuario], [fkPerfil], [fkLocalidade], [fkInstancia], [nome], [apelido], [email], [senha], [fone], [ativo], [foto], [coordenadas]) VALUES (10, 1, 8, 1, N'JOSE MARIO FRAGA MIRANDA', N'MARIO', N'mariofraga@gmail.com', N'HXLCz3J4H0k=                                                                                                                                                                                                                                              ', N'69 981147958', 0, N'item_4_4201742017.jpg', 0xE6100000010C97033DD4B68521C0EA69D14C41F34FC0)
SET IDENTITY_INSERT [dbo].[CAUsuario] OFF
SET IDENTITY_INSERT [dbo].[Localidade] ON 

INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (1, N'porto velho', N'ro', N'brasil', NULL, N'Porto Velho - RO, Brasil', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (2, N'ariquemes', N'ro', N'brasil', NULL, N'Ariquemes - RO, Brasil', 0xE6100000010C687583B23A844FC03F75070CEDCF23C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (3, N'humaita', N'am', N'brasil', NULL, N'Humaitá - AM, Brasil', 0xE6100000010C30E1A826D2834FC0313EBB325E111EC0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (4, N'porto velho', N'ro', N'brasil', NULL, N'Porto Velho - RO, Brasil', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (5, N'porto velho', N'ro', N'brasil', NULL, N'Porto Velho - RO, Brasil', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (6, N'porto velho', N'ro', N'brasil', NULL, N'Porto Velho - RO, Brasil', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (7, N'porto velho', N'ro', N'brasil', NULL, N'Porto Velho - RO, Brasil', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (8, N'porto velho', N'ro', N'brasil', NULL, N'Porto Velho - RO, Brasil', 0xE6100000010CE869D14C41F34FC096033DD4B68521C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (9, N'cacoal', N'ro', N'brasil', NULL, N'Cacoal - RO, Brasil', 0xE6100000010CD804ACB074BA4EC0C9D23DA18DDE26C0)
INSERT [dbo].[Localidade] ([pkLocalidade], [cidade], [uf], [pais], [idFBLocalidade], [nomeCompletoLocal], [coordenadas]) VALUES (10, N'jundiai', N'sp', N'brasil', NULL, N'Jundiaí - SP, Brasil', 0xE6100000010CC8D4134CEB7247C0609E84888A2F37C0)
SET IDENTITY_INSERT [dbo].[Localidade] OFF
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (60, N'ADLY')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (61, N'AGRALE')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (62, N'APRILIA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (63, N'ATALA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (64, N'BAJAJ')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (65, N'BETA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (66, N'BIMOTA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (67, N'BMW')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (68, N'BRANDY')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (69, N'byCristo')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (70, N'CAGIVA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (71, N'CALOI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (72, N'DAELIM')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (73, N'DERBI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (74, N'DUCATI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (75, N'EMME')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (76, N'GAS GAS')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (77, N'HARLEY-DAVIDSON')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (78, N'HARTFORD')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (79, N'HERO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (80, N'HONDA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (81, N'HUSABERG')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (82, N'HUSQVARNA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (85, N'KAWASAKI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (86, N'KIMCO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (87, N'KTM')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (88, N'L''AQUILA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (89, N'LAVRALE')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (90, N'MOTO GUZZI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (91, N'MV AGUSTA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (92, N'MVK')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (93, N'ORCA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (94, N'PEUGEOT')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (95, N'PIAGGIO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (96, N'SANYANG')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (97, N'SIAMOTO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (98, N'SUNDOWN')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (99, N'SUZUKI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (100, N'TRIUMPH')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (101, N'YAMAHA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (117, N'BUELL')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (118, N'KASINSKI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (119, N'TRAXX')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (126, N'MIZA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (128, N'FYM')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (129, N'KAHENA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (130, N'BRAVA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (131, N'AMAZONAS')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (132, N'FOX')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (133, N'GREEN')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (134, N'SHINERAY')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (135, N'WUYANG')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (137, N'DAYANG')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (138, N'HAOBAO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (139, N'LERIVO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (141, N'JIAPENG VOLCANO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (142, N'DAYUN')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (143, N'GARINNI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (145, N'DAFRA')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (146, N'Malaguti')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (148, N'Lon-V')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (150, N'BRP')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (151, N'JONNY')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (155, N'BUENO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (158, N'IROS')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (159, N'LANDUM')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (160, N'MRX')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (162, N'Benelli')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (164, N'PEGASSI')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (173, N'REGAL RAPTOR')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (174, N'JOHNNYPAG')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (175, N'MAGRÃO TRICICLOS')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (176, N'TARGOS')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (178, N'LIFAN')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (180, N'VENTO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (187, N'TIGER')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (192, N'Royal Enfield')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (198, N'RIGUETE')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (200, N'MOTORINO')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (201, N'MOTOCAR')
INSERT [dbo].[Marca] ([pkMarca], [DescricaoMarca]) VALUES (202, N'INDIAN')
SET IDENTITY_INSERT [dbo].[Moto] ON 

INSERT [dbo].[Moto] ([pkMoto], [nomeMoto], [modeloMoto], [fkMarca], [foto], [ativa], [fkUsuario]) VALUES (7, N'Judite', N'Iron 883', 77, N'item_2_7201772017.jpg', 1, 1)
SET IDENTITY_INSERT [dbo].[Moto] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (3, 1, 2, CAST(N'2017-01-28T21:23:52.147' AS DateTime), N'1112333', N'111', N'item_2_282017282017.jpg', 111, N'111', N'111', CAST(N'2016-02-01' AS Date), CAST(N'05:00:00' AS Time), 1, 0, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (4, 1, 1, CAST(N'2017-02-05T00:55:00.543' AS DateTime), N'Tetse didooo', N'<p>asdasd as</p><p><span style="font-weight: bold;">asd</span></p><p><span style="font-weight: bold;">a sd</span></p><p><span style="font-weight: bold; font-family: &quot;Arial Black&quot;;">aaaaaa</span></p><p>aaa</p>', N'item_2_5201752017.jpg', 100, N'Partida', N'Destino', CAST(N'2017-10-10' AS Date), CAST(N'17:00:00' AS Time), 1, 0, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (5, 1, 1, CAST(N'2017-02-05T01:27:49.820' AS DateTime), N'Tetse didooo1', N'<p>asdasd as</p><p><span style="font-weight: bold;">asd11</span></p><p><span style="font-weight: bold;">a sd</span></p><p><span style="font-weight: bold; font-family: &quot;Arial Black&quot;;">aaaaaa</span></p><p>aaa</p>', N'item_5_5201752017.jpg', 1001, N'Partida1', N'destinbo1', CAST(N'2017-10-10' AS Date), CAST(N'17:00:00' AS Time), 1, 0, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (6, 1, 4, CAST(N'2017-02-06T10:29:02.137' AS DateTime), N'Trilhas da Amazônia -  Cacheira do Morro #01', N'<p>Salve amigos!<br><br>Ta afim de uma trilha animal??? vem com a gente no dia 25/02/2017.<br>Serão 70 Kms de muita poera e aventura!&nbsp;&nbsp;&nbsp;&nbsp;</p>', N'item_0_6201762017.jpg', 70, N'Praça da Cidade', N'Cachoeira do Morro', CAST(N'2017-02-25' AS Date), CAST(N'07:30:00' AS Time), 9, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (7, 1, 2, CAST(N'2017-02-06T10:35:13.513' AS DateTime), N'Bate e Volta - Porto Velho / Fazendinha', N'Vai passar mais um domingo na frente da TV?<br><br>faz isso não!! vem com a gente nesse passeio Massa!<br><br>Serão algo em torno de 340 Km de BR..<br><br>saída bem cedinho para tomar o café da manha na fazendinha.<br><br>', N'item_1_6201762017.jpg', 340, N'Posto ao Lado da FIMCA', N'Fazendinha', CAST(N'2017-02-14' AS Date), CAST(N'07:30:00' AS Time), 1, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (8, 1, 1, CAST(N'2017-02-06T10:38:26.247' AS DateTime), N'Rolé de Confraternização', N'É isso ai galera,&nbsp;<br>Vamos nos reunir no finalzinho do próximo domingo pra bater papo e dar uma volta pela cidade.<br><br>', N'item_2_6201762017.jpg', 10, N'Posto Ipiranga ao lado do gonçalves', N'Sem destino Defindo rs.', CAST(N'2016-02-15' AS Date), CAST(N'16:30:00' AS Time), 1, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (9, 1, 2, CAST(N'2017-02-06T10:42:38.680' AS DateTime), N'Passeio - Humaitá até Porto velho', N'Que tal passar o domingo em porto velho?<br><br>saida as 08:00 da praça da cidade..<br><br><br>', N'item_3_6201762017.jpg', 400, N'Praça da Cidade', N'Porto velho', CAST(N'2017-02-22' AS Date), CAST(N'08:00:00' AS Time), 3, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (10, 1, 1, CAST(N'2017-02-06T10:44:45.063' AS DateTime), N'Tilha para loucos', N'Ta afim de muita emoção e diversão?&nbsp;<br><br>junte-se aos bons!!', N'item_4_6201762017.jpg', 50, N'Posto Petrona', N'Estrada Sinistra', CAST(N'2017-03-01' AS Date), CAST(N'08:30:00' AS Time), 10, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (11, 1, 1, CAST(N'2017-02-06T10:48:48.740' AS DateTime), N'Bate e Volta - Porto Velho / Jaci - Rolé com Sangue nos olhos!', N'Vamos Circular o óleo no próximo sábado a tarde!<br><br>bate e volta nervosa - Porto velho / Jaci!<br><br>Compartilhe com seu amigos..', N'item_5_6201762017.jpg', 180, N'Posto Ipiranga ao lado do gonçalves', N'Jaci', CAST(N'2017-02-18' AS Date), CAST(N'16:30:00' AS Time), 1, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (12, 1, 2, CAST(N'2017-02-06T10:35:13.513' AS DateTime), N'Bate e Volta - Porto Velho / Fazendinha', N'Vai passar mais um domingo na frente da TV?<br><br>faz isso não!! vem com a gente nesse passeio Massa!<br><br>Serão algo em torno de 340 Km de BR..<br><br>saída bem cedinho para tomar o café da manha na fazendinha.<br><br>', N'item_1_6201762017.jpg', 340, N'Posto ao Lado da FIMCA', N'Fazendinha', CAST(N'2017-02-14' AS Date), CAST(N'07:30:00' AS Time), 1, 1, NULL, NULL)
INSERT [dbo].[Role] ([pkRole], [fkUsuario], [fkTipoRole], [dataHoraCadastro], [titulo], [descricaoRole], [capa], [totalKM], [localPartida], [localDestino], [dataRole], [horaRole], [fkLocalidade], [ativo], [publico], [realizado]) VALUES (13, 1, 1, CAST(N'2017-02-06T10:38:26.247' AS DateTime), N'Rolé de Confraternização', N'É isso ai galera,&nbsp;<br>Vamos nos reunir no finalzinho do próximo domingo pra bater papo e dar uma volta pela cidade.<br><br>', N'item_2_6201762017.jpg', 10, N'Posto Ipiranga ao lado do gonçalves', N'Sem destino Defindo rs.', CAST(N'2016-02-15' AS Date), CAST(N'16:30:00' AS Time), 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[TipoRole] ON 

INSERT [dbo].[TipoRole] ([pkTipoRole], [descricao]) VALUES (1, N'Passeio Urbano')
INSERT [dbo].[TipoRole] ([pkTipoRole], [descricao]) VALUES (2, N'Passeio Rodoviário')
INSERT [dbo].[TipoRole] ([pkTipoRole], [descricao]) VALUES (3, N'Encontro / Evento')
INSERT [dbo].[TipoRole] ([pkTipoRole], [descricao]) VALUES (4, N'Off Road')
SET IDENTITY_INSERT [dbo].[TipoRole] OFF
ALTER TABLE [dbo].[CAInstancia] ADD  CONSTRAINT [DF__TbObra__Contrato__1B0907CE]  DEFAULT (NULL) FOR [descricao]
GO
ALTER TABLE [dbo].[CAAction]  WITH CHECK ADD  CONSTRAINT [FK_UsuPagina_UsuController] FOREIGN KEY([fkController])
REFERENCES [dbo].[CAController] ([pkController])
GO
ALTER TABLE [dbo].[CAAction] CHECK CONSTRAINT [FK_UsuPagina_UsuController]
GO
ALTER TABLE [dbo].[CAActionModulo]  WITH CHECK ADD  CONSTRAINT [FK_CAActionModulo_CAAction] FOREIGN KEY([fkAction])
REFERENCES [dbo].[CAAction] ([pkAction])
GO
ALTER TABLE [dbo].[CAActionModulo] CHECK CONSTRAINT [FK_CAActionModulo_CAAction]
GO
ALTER TABLE [dbo].[CAActionModulo]  WITH CHECK ADD  CONSTRAINT [FK_CAActionModulo_CAModulo] FOREIGN KEY([fkModulo])
REFERENCES [dbo].[CAModulo] ([pkModulo])
GO
ALTER TABLE [dbo].[CAActionModulo] CHECK CONSTRAINT [FK_CAActionModulo_CAModulo]
GO
ALTER TABLE [dbo].[CAAuditoria]  WITH CHECK ADD  CONSTRAINT [FK_CAAuditoria_CAAction] FOREIGN KEY([fkAction])
REFERENCES [dbo].[CAAction] ([pkAction])
GO
ALTER TABLE [dbo].[CAAuditoria] CHECK CONSTRAINT [FK_CAAuditoria_CAAction]
GO
ALTER TABLE [dbo].[CAAuditoria]  WITH CHECK ADD  CONSTRAINT [FK_CAAuditoria_CAUsuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[CAAuditoria] CHECK CONSTRAINT [FK_CAAuditoria_CAUsuario]
GO
ALTER TABLE [dbo].[CALogAcesso]  WITH CHECK ADD  CONSTRAINT [FK_LogAcesso_Usuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[CALogAcesso] CHECK CONSTRAINT [FK_LogAcesso_Usuario]
GO
ALTER TABLE [dbo].[CAModuloPerfil]  WITH CHECK ADD  CONSTRAINT [FK_ModuloPerfil_Modulo] FOREIGN KEY([fkModulo])
REFERENCES [dbo].[CAModulo] ([pkModulo])
GO
ALTER TABLE [dbo].[CAModuloPerfil] CHECK CONSTRAINT [FK_ModuloPerfil_Modulo]
GO
ALTER TABLE [dbo].[CAModuloPerfil]  WITH CHECK ADD  CONSTRAINT [FK_ModuloPerfil_Perfil] FOREIGN KEY([fkPerfil])
REFERENCES [dbo].[CAPerfil] ([pkPerfil])
GO
ALTER TABLE [dbo].[CAModuloPerfil] CHECK CONSTRAINT [FK_ModuloPerfil_Perfil]
GO
ALTER TABLE [dbo].[CAUsuario]  WITH CHECK ADD  CONSTRAINT [FK_CAUsuario_Localidade] FOREIGN KEY([fkLocalidade])
REFERENCES [dbo].[Localidade] ([pkLocalidade])
GO
ALTER TABLE [dbo].[CAUsuario] CHECK CONSTRAINT [FK_CAUsuario_Localidade]
GO
ALTER TABLE [dbo].[CAUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([fkPerfil])
REFERENCES [dbo].[CAPerfil] ([pkPerfil])
GO
ALTER TABLE [dbo].[CAUsuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
ALTER TABLE [dbo].[CAUsuario]  WITH CHECK ADD  CONSTRAINT [FK_UsuUsuario_UsuInstancia] FOREIGN KEY([fkInstancia])
REFERENCES [dbo].[CAInstancia] ([pkInstancia])
GO
ALTER TABLE [dbo].[CAUsuario] CHECK CONSTRAINT [FK_UsuUsuario_UsuInstancia]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_CAUsuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_CAUsuario]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Comentario1] FOREIGN KEY([fkComentario])
REFERENCES [dbo].[Comentario] ([pkCometario])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Comentario1]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Role] FOREIGN KEY([fkRole])
REFERENCES [dbo].[Role] ([pkRole])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Role]
GO
ALTER TABLE [dbo].[Foto]  WITH CHECK ADD  CONSTRAINT [FK_Foto_CAUsuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[Foto] CHECK CONSTRAINT [FK_Foto_CAUsuario]
GO
ALTER TABLE [dbo].[Foto]  WITH CHECK ADD  CONSTRAINT [FK_Foto_Role] FOREIGN KEY([fkRole])
REFERENCES [dbo].[Role] ([pkRole])
GO
ALTER TABLE [dbo].[Foto] CHECK CONSTRAINT [FK_Foto_Role]
GO
ALTER TABLE [dbo].[Moto]  WITH CHECK ADD  CONSTRAINT [FK_Moto_CAUsuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[Moto] CHECK CONSTRAINT [FK_Moto_CAUsuario]
GO
ALTER TABLE [dbo].[Moto]  WITH CHECK ADD  CONSTRAINT [FK_Moto_Moto] FOREIGN KEY([fkMarca])
REFERENCES [dbo].[Marca] ([pkMarca])
GO
ALTER TABLE [dbo].[Moto] CHECK CONSTRAINT [FK_Moto_Moto]
GO
ALTER TABLE [dbo].[Participamente]  WITH CHECK ADD  CONSTRAINT [FK_Participamente_CAUsuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[Participamente] CHECK CONSTRAINT [FK_Participamente_CAUsuario]
GO
ALTER TABLE [dbo].[Participamente]  WITH CHECK ADD  CONSTRAINT [FK_Participamente_Moto] FOREIGN KEY([fkMoto])
REFERENCES [dbo].[Moto] ([pkMoto])
GO
ALTER TABLE [dbo].[Participamente] CHECK CONSTRAINT [FK_Participamente_Moto]
GO
ALTER TABLE [dbo].[Participamente]  WITH CHECK ADD  CONSTRAINT [FK_Participamente_Role] FOREIGN KEY([fkRole])
REFERENCES [dbo].[Role] ([pkRole])
GO
ALTER TABLE [dbo].[Participamente] CHECK CONSTRAINT [FK_Participamente_Role]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_CAUsuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[CAUsuario] ([pkUsuario])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_CAUsuario]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Localidade] FOREIGN KEY([fkLocalidade])
REFERENCES [dbo].[Localidade] ([pkLocalidade])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_Localidade]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_TipoRole] FOREIGN KEY([fkTipoRole])
REFERENCES [dbo].[TipoRole] ([pkTipoRole])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_TipoRole]
GO
