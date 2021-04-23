USE [WebApi]
GO

/****** Object:  Table [dbo].[Empleado]    Script Date: 20/04/2021 13:39:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empleado](
	[Id_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Usuario] [nvarchar](100) NULL,
	[Contraseña] [nvarchar](100) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Ultimo_Login] [datetime] NULL,
	[Fecha_Creacion] [datetime] NULL,
	[Fecha_Actualiza] [datetime] NULL,
	[Fecha_Elimina] [datetime] NULL,
	[Id_Rol] [int] NULL,
	[Id_Estado] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


