USE [DB_whut_xljk]
GO

/****** Object:  Table [dbo].[T_stuplazaInfoAdmin]    Script Date: 2016/4/8 10:54:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_xljkInfoAdmin](
	[C_InfoAdminAccount] [char](8) NOT NULL,
	[C_InfoAdminPwd] [nvarchar](24) NULL,
	[C_InfoAdminSector] [nvarchar](40) NOT NULL,
	[C_InfoAdminCategory] [int] NULL DEFAULT ((0)),
	[C_InfoAdminName] [nvarchar](20) NOT NULL,
	[C_InfoAdminTel] [char](11) NULL,
	[C_InfoAdminEmail] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[C_InfoAdminAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

