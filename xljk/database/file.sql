USE [DB_whut_xljk]
GO

/****** Object:  Table [dbo].[T_stuplazaFile]    Script Date: 2016/4/8 10:54:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_xljkFile](
	[C_FileId] [char](11) NOT NULL,
	[C_FileName] [nvarchar](100) NOT NULL,
	[C_FileTime] [datetime] NULL,
	[C_FileSector] [nvarchar](40) NULL,
	[C_FileSummary] [nvarchar](300) NULL,
	[C_FilePath] [nvarchar](200) NULL,
	[C_FileExt] [nvarchar](20) NULL,
	[C_FileDowNum] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[C_FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

