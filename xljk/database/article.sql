USE [DB_whut_xljk]
GO

/****** Object:  Table [dbo].[T_stuplazaArticle]    Script Date: 2016/4/8 10:53:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_xljkArticle](
	[C_ArticleId] [char](11) NOT NULL,
	[C_ArticleTitle] [nvarchar](100) NOT NULL,
	[C_ArticleSector] [nvarchar](40) NOT NULL,
	[C_ArticleCategory] [int] NOT NULL DEFAULT ((1)),
	[C_ArticleTopic] [int] NULL,
	[C_ArticleContent] [nvarchar](max) NULL,
	[C_ArticlePostStaff] [nvarchar](20) NOT NULL,
	[C_ArticleAnnexAddr] [nvarchar](200) NULL,
	[C_ArticleTime] [datetime] NULL,
	[C_ArticleColumn] [char](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

