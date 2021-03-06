USE [Cloud]
GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[Oid] [int] IDENTITY(1000,1) NOT NULL,
	[OwnerID] [varchar](50) NULL,
	[Ownerpwd] [varchar](50) NULL,
	[Ownername] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Dob] [varchar](50) NULL,
	[Mobile] [bigint] NULL,
	[Email] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Photo] [varchar](50) NULL,
 CONSTRAINT [PK_OwnerRegistration] PRIMARY KEY CLUSTERED 
(
	[Oid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TPALogin]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TPALogin](
	[name] [varchar](50) NOT NULL,
	[Pwd] [varchar](50) NOT NULL,
	[Cloud] [tinyint] NOT NULL,
 CONSTRAINT [PK_TPALogin] PRIMARY KEY CLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Uname] [varchar](50) NOT NULL,
	[Pwd] [varchar](50) NOT NULL,
	[Utype] [tinyint] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Uname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KeyGenerate]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyGenerate](
	[Kid] [int] IDENTITY(1,1) NOT NULL,
	[FileKey] [int] NOT NULL,
 CONSTRAINT [PK_KeyGenerate] PRIMARY KEY CLUSTERED 
(
	[Kid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FVerifyHigh]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FVerifyHigh](
	[Fid] [int] NOT NULL,
	[Fverify] [int] NOT NULL,
	[TPA] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fverify_Temp]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fverify_Temp](
	[Fid] [int] NOT NULL,
	[Fverify] [int] NOT NULL,
	[TPA] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fileMetedata]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fileMetedata](
	[fid] [int] NOT NULL,
	[metadata] [varchar](max) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileIndex]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileIndex](
	[Fileid] [int] NOT NULL,
	[Serverid] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[filearchieve]    Script Date: 02/16/2015 23:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[filearchieve](
	[fid] [int] IDENTITY(1000,1) NOT NULL,
	[fsubject] [varchar](50) NOT NULL,
	[filebytes] [varbinary](max) NOT NULL,
	[fext] [varchar](50) NOT NULL,
	[fsizeinkb] [varchar](50) NOT NULL,
	[fdatetime] [varchar](50) NOT NULL,
	[fowner] [varchar](50) NOT NULL,
	[fencryptkey] [int] NOT NULL,
	[fmetadata] [varchar](max) NOT NULL,
	[fverify] [tinyint] NOT NULL,
	[fdownload] [int] NOT NULL,
	[securityOption] [tinyint] NOT NULL,
 CONSTRAINT [PK_filearchieve] PRIMARY KEY CLUSTERED 
(
	[fid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
