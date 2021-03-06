USE [WebApi]
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleado]    Script Date: 20/04/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Ivan Gomez>
-- Create date: <19-04-2021>
-- Description:	<CRUD>
-- =============================================
ALTER PROCEDURE [dbo].[SP_Empleado]
(	-- Add the parameters for the stored procedure here
	@Id_Empleado int = NULL,
	@Nombre VARCHAR(100) = NULL,
	@Usuario VARCHAR(100) = NULL,
	@Contraseña VARCHAR(100) = NULL,
	@Telefono VARCHAR(50) = NULL,
	@Email VARCHAR(50) = NULL,
	@Ultimo_Login DATETIME = NULL,
	@Fecha_Creacion DATETIME = NULL,
	@Fecha_Actualizacion DATETIME = NULL,
	@Fecha_Elimina DATETIME = NULL,
	@Id_Rol INT = NULL,
	@Id_Estado INT= NULL,

	@Action INT= NULL

)
AS

BEGIN
	IF @Action = 0
	BEGIN
		SELECT --Get
			E.Id_Empleado, 
			E.Nombre, 
			E.Usuario, 
			E.Contraseña, 
			E.Telefono, 
			E.Email, 
			ISNULL(CONVERT(nvarchar,E.Ultimo_Login), '00-00-0000 00:00') AS 'Ultimo_Login',
			ISNULL(CONVERT(nvarchar,E.Fecha_Creacion), '00-00-0000 00:00') AS 'Fecha_Creacion',
			ISNULL(CONVERT(nvarchar,E.Fecha_Actualiza), '00-00-0000 00:00') AS 'Fecha_Actualiza',
			ISNULL(CONVERT(nvarchar,E.Fecha_Elimina), '00-00-0000 00:00') AS 'Fecha_Elimina',

			E.Id_Rol,
			R.Nombre AS 'Rol',
			E.Id_Estado,
			ES.Nombre AS 'Estado'
		FROM 
			WebApi.dbo.Empleado E
			INNER JOIN WebApi.dbo.Roles R ON E.Id_Rol = R.Id_Rol
			INNER JOIN WebApi.dbo.Estados ES ON E.Id_Estado = ES.Id_Estado
		WHERE
			E.Id_Estado != 4
	END

	IF @Action = 1
	BEGIN
		INSERT INTO --Post
            WebApi.dbo.Empleado
            ( 
                Nombre, 
                Usuario, 
                Contraseña, 
                Telefono, 
                Email,
                Fecha_Creacion,
                Id_Rol,
                Id_Estado
            )
        VALUES
            (
				@Nombre, 
				@Usuario, 
				@Contraseña, 
				@Telefono,
				@Email,
				GETDATE(),
				@Id_Rol, 
				@Id_Estado
			)
	END

	IF @Action = 2 --Put
	BEGIN
		UPDATE
            WebApi.dbo.Empleado
        SET
			Nombre = @Nombre, 
			Usuario = @Usuario, 
			Contraseña = @Contraseña, 
			Telefono = @Telefono,
			Email = @Email, 
			Fecha_Actualiza = GETDATE(),
			Id_Rol = @Id_Rol, 
			Id_Estado = @Id_Estado
		WHERE
			Id_Empleado = @Id_Empleado
	END

	IF @Action = 3 --Delete
	BEGIN
		UPDATE
            WebApi.dbo.Empleado
        SET
			Fecha_Elimina = GETDATE(),
			Id_Estado = 4
		WHERE
			Id_Empleado = @Id_Empleado
	END
END
