USE [WebApi]
GO

/****** Object:  Table [dbo].[Estados]    Script Date: 20/04/2021 13:40:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Estados](
	[Id_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


