use PuntoDeVenta;

INSERT INTO Usuarios(usuario, contra, rol) VALUES('admin', 'admin', 1);
INSERT INTO Administrador(usuario) VALUES('admin');


IF OBJECT_ID('sp_Login') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_Login
END
GO
CREATE PROCEDURE sp_Login(
	@usuario varchar(30),
	@contra VARCHAR(30) = NULL
)
AS
BEGIN
			SELECT usuario, rol
			FROM Usuarios 
			WHERE usuario = @usuario AND contra = @contra;

END
GO

EXEC sp_Login @usuario = 'admin2', @contra = 'adminn';
GO

--Gestion de usuarios
IF OBJECT_ID('sp_GestionCajeros') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_GestionCajeros
END
GO
CREATE PROCEDURE sp_GestionCajeros(
	@operacion VARCHAR(2) = NULL,
	@nombre VARCHAR(30) = NULL,
	@apellido_materno VARCHAR(30) = NULL,
	@apellido_paterno VARCHAR(30) = NULL,
	@curp VARCHAR(18) = NULL,
	@fecha_nacimiento DATE = NULL,
	@num_nomina VARCHAR(30) = NULL,
	@email VARCHAR(30) = NULL,
	@id_admin TINYINT = NULL,
	@id_cajero TINYINT = NULL,
	@username VARCHAR(30) = NULL,
	@selectedUser VARCHAR(30) = NULL,
	@password VARCHAR(30) = NULL,
	@status BIT = null,
	@id_userSelected INT = NULL
)
AS
BEGIN
	IF @operacion = 'S'
	BEGIN
			SELECT DatosCajero.nombre, DatosCajero.[apellido_paterno],DatosCajero.[apellido_materno],DatosCajero.[curp],DatosCajero.[fecha_nacimiento],DatosCajero.[num_nomina],DatosCajero.[email],DatosCajero.[id_cajero], DatosCajero.[id_admin], Cajero.usuario, DatosCajero.activo, Usuarios.contra
			FROM DatosCajero
			INNER JOIN Cajero ON DatosCajero.id_cajero=Cajero.id_cajero
			INNER JOIN Usuarios ON Usuarios.usuario=Cajero.usuario
			WHERE DatosCajero.activo = 1;
	END

	IF @operacion = 'CI'
	BEGIN
			SELECT Cajero.id_cajero
			FROM Cajero
			WHERE usuario=@username;
	END

	IF @operacion = 'I'
	BEGIN
			INSERT INTO Usuarios(usuario, contra, rol) VALUES(@username, @password, 2);
			INSERT INTO Cajero(usuario) VALUES (@username);
	END

	IF @operacion = 'I2'
	BEGIN
			INSERT INTO DatosCajero(nombre,apellido_paterno,apellido_materno,curp,fecha_nacimiento,num_nomina,email,id_cajero,id_admin)
			VALUES(@nombre, @apellido_paterno, @apellido_materno, @curp, @fecha_nacimiento, @num_nomina,@email, @id_cajero, @id_admin)
	END

	IF @operacion = 'ED'
	BEGIN
			--Tenemos que cambiar el usuario y la contrase;a del usuario antes que nada
			UPDATE Usuarios
			SET contra=@password
			WHERE usuario=@selectedUser;

			UPDATE DatosCajero
			SET nombre = @nombre, apellido_paterno = @apellido_paterno, apellido_materno = @apellido_materno, curp = @curp, email = @email, num_nomina = @num_nomina, fecha_nacimiento = @fecha_nacimiento
			WHERE id_cajero = @id_userSelected;
	END

	IF @operacion = 'EL'
	BEGIN
			--Tenemos que cambiar el usuario y la contrase;a del usuario antes que nada
			UPDATE DatosCajero
			SET activo = 0 
			WHERE id_cajero=@id_userSelected;

	END
END
GO


-- Obtener id del admin

IF OBJECT_ID('sp_IdAdmin') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_IdAdmin
END
GO

CREATE PROCEDURE sp_IdAdmin(
	@usuario varchar(30)
)
AS
BEGIN

			SELECT Administrador.id_admin
			FROM Administrador
			WHERE usuario=@usuario;
END
GO


---Procedure para obtener las IDs
IF OBJECT_ID('sp_GetIds') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_GetIds
END
GO

CREATE PROCEDURE sp_GetIds(
	@operacion VARCHAR(4) = NULL,
	@nombreUnidadMedida VARCHAR(30) = NULL,
	@nombreDepartamento varchar(30) = NULL

)
AS
BEGIN
		IF @operacion = 'idDp'
			BEGIN	
				SELECT clave_departamento FROM Departamento WHERE nombre = @nombreDepartamento;
		END

		IF @operacion = 'idUn'
		BEGIN	

			IF EXISTS (SELECT * FROM UnidadMedida WHERE nombre = @nombreUnidadMedida) 
			BEGIN
			   SELECT id_unidadMedida FROM UnidadMedida WHERE nombre = @nombreUnidadMedida;
			END
			ELSE
			BEGIN
				INSERT into UnidadMedida(nombre) VALUES (@nombreUnidadMedida);
				SELECT id_unidadMedida FROM UnidadMedida WHERE nombre = @nombreUnidadMedida;
			END
			
			
		END
		

END
GO




--Gestion Departamentos
IF OBJECT_ID('sp_GestionDepartamentos') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_GestionDepartamentos
END
GO
CREATE PROCEDURE sp_GestionDepartamentos(
		@operacion VARCHAR(2) = NULL,
		@nombreDepartamento VARCHAR(30) =NULL,
		@claveDepartamento VARCHAR(5) = NULL,
		@devolucion BIT = NULL,
		@status BIT = NULL,
		@id_admin TINYINT = NULL

)AS
BEGIN
	
	IF @operacion = 'I'
	BEGIN
			INSERT INTO Departamento(clave_departamento, nombre, devolucion, activo, id_admin) VALUES (@claveDepartamento, @nombreDepartamento, @devolucion, @status, @id_admin);
			
	END


	IF @operacion = 'S'
	BEGIN
			SELECT clave_departamento,nombre, devolucion, activo
			FROM Departamento;
			
	END

	IF @operacion = 'U'
	BEGIN
			IF @status = 1
			BEGIN
				UPDATE Departamento 
				SET nombre = @nombreDepartamento, devolucion = @devolucion, activo = @status
				WHERE clave_departamento = @claveDepartamento;
			END
			ELSE
			BEGIN
				IF NOT EXISTS(SELECT D.nombre FROM Departamento D INNER JOIN Producto P ON P.cve_departamento = @claveDepartamento AND P.estatus = 1 WHERE D.clave_departamento = @claveDepartamento )
				BEGIN
					UPDATE Departamento 
					SET nombre = @nombreDepartamento, devolucion = @devolucion, activo = @status
					WHERE clave_departamento = @claveDepartamento;
				END
			END
	END

	IF @operacion = 'D'
	BEGIN
			IF NOT EXISTS(SELECT D.nombre FROM Departamento D INNER JOIN Producto P ON P.cve_departamento = @claveDepartamento AND P.estatus = 1 WHERE D.clave_departamento = @claveDepartamento )
			BEGIN
				UPDATE Departamento 
				SET activo = 0
				WHERE clave_departamento = @claveDepartamento;
			END
			
	END
	
	IF @operacion = 'SA'
	BEGIN
			SELECT nombre
			FROM Departamento;
			
	END

	IF @operacion = 'SN'
	BEGIN
			SELECT nombre
			FROM Departamento
			WHERE clave_departamento = @claveDepartamento;
	END

END
GO

--Gestion Productos

IF OBJECT_ID('sp_GestionProductos') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_GestionProductos
END
GO
CREATE PROCEDURE sp_GestionProductos(
		@operacion VARCHAR(2) = NULL,
		@nombreProd VARCHAR(30) =NULL,
		@descripProd VARCHAR(50) =NULL,
		@costoProd SMALLMONEY = NULL,
		@preciounitarioProd SMALLMONEY = NULL,
		@existencia SMALLINT = NULL,
		@merma TINYINT = NULL,
		@puntoreordenProd TINYINT = NULL,
		@estatusProd BIT = NULL,
		@id_unidadMedida TINYINT = NULL,
		@cve_departamento varchar(5)= NULL,
		@id_admin TINYINT = NULL,
		@codProd INT = NULL

)AS	
BEGIN
	
	IF @operacion = 'I'
	BEGIN
			
			INSERT INTO Producto(nombre,descripcion,costo,precio_unitario,existencia,punto_reorden,estatus,id_admin,id_unidadMedida,cve_departamento) 
			VALUES (@nombreProd,@descripProd,@costoProd,@preciounitarioProd,@existencia,@puntoreordenProd,@estatusProd,@id_admin,@id_unidadMedida,@cve_departamento);
		
	END

	IF @operacion = 'S'
	BEGIN
			SELECT cod_producto,nombre,estatus
			FROM Producto;
			
	END


	IF @operacion = 'SA'
	BEGIN
			SELECT P.nombre,P.descripcion,P.costo,P.precio_unitario,P.existencia,P.punto_reorden,P.estatus, D.nombre nombreDep, U.nombre nombreUnidad
			FROM Producto P
			INNER JOIN Departamento D ON D.clave_departamento = P.cve_departamento
			INNER JOIN UnidadMedida U ON U.id_unidadMedida = P.id_unidadMedida
			WHERE cod_producto = @codProd;	
	END

	IF @operacion = 'U'
	BEGIN
			IF (@estatusProd = 1)
			BEGIN
				IF EXISTS(SELECT nombre FROM Departamento WHERE clave_departamento = @cve_departamento AND activo = 1)
				BEGIN
					UPDATE Producto 
					SET nombre = @nombreProd, descripcion = @descripProd, costo=@costoProd, precio_unitario = @preciounitarioProd, existencia = @existencia, punto_reorden = @puntoreordenProd, estatus = @estatusProd, id_unidadMedida = @id_unidadMedida, cve_departamento = @cve_departamento
					WHERE cod_producto = @codProd; 
				END
			END
			ELSE
			BEGIN
				UPDATE Producto 
				SET nombre = @nombreProd, descripcion = @descripProd, costo=@costoProd, precio_unitario = @preciounitarioProd, existencia = @existencia, punto_reorden = @puntoreordenProd, estatus = @estatusProd, id_unidadMedida = @id_unidadMedida, cve_departamento = @cve_departamento
				WHERE cod_producto = @codProd; 
			END
			
			
	END

	IF @operacion = 'D'
	BEGIN
			UPDATE Producto 
			SET estatus = 0
			WHERE cod_producto = @codProd; 
	END


	--IF @operacion = 'S'
	--BEGIN
	--		SELECT clave_departamento,nombre, devolucion
	--		FROM Departamento
	--		WHERE activo = 1;
	--END

	--IF @operacion = 'U'
	--BEGIN
	--		UPDATE Departamento 
	--		SET nombre = @nombreDepartamento, devolucion = @devolucion
	--		WHERE clave_departamento = @claveDepartamento;
	--END

	--IF @operacion = 'D'
	--BEGIN
	--		UPDATE Departamento 
	--		SET activo = @status
	--		WHERE clave_departamento = @claveDepartamento;
	--END
	
END
GO


--Gestion Cajas
IF OBJECT_ID('sp_GestionCajas') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_GestionCajas
END
GO
CREATE PROCEDURE sp_GestionCajas(
		@operacion VARCHAR(2) = NULL,
		@estatusCaja BIT = NULL,
		@id_admin TINYINT = NULL,
		@id_cajero TINYINT = NULL,
		@num_caja TINYINT = NULL

)AS	
BEGIN
	
	IF @operacion = 'I'
	BEGIN
			
			INSERT INTO Caja(estatus,id_admin) 
			VALUES (@estatusCaja,@id_admin);
		
	END

	IF @operacion = 'SN'
	BEGIN
			SELECT IDENT_CURRENT ('Caja') AS UltimoId; 
			
	END

	IF @operacion = 'S'
	BEGIN
			SELECT num_caja,estatus, cajero FROM Caja ;
			
	END


	IF @operacion = 'U'
	BEGIN
	    UPDATE Caja 
		SET  estatus = @estatusCaja
		WHERE num_caja = @num_caja;	
			
	END

	IF @operacion = 'D'
	BEGIN
			UPDATE Caja 
			SET  estatus = 0
			WHERE num_caja = @num_caja;	
	END

END
GO






--Pruebas 

use PuntoDeVenta;
Select * from Usuarios
Select * from Cajero
Select * from DatosCajero
Select * from Administrador

update Caja set cajero = 1 where num_caja=2;

SELECT IDENT_CURRENT ('Caja') AS UltimoId; 


Truncate table dbo.Caja;

ALTER TABLE Administrador
DROP CONSTRAINT  fk_Administradorusuario;


Truncate table Cajero;
Truncate table Departamento;


use PuntoDeVenta;


INSERT INTO Usuarios(usuario, contra, rol) VALUES('caja1', 'caja', 2);
Select * From Administrador;

INSERT INTO Cajero(usuario) VALUES ('caja1');

USE [PuntoDeVenta]
GO

SELECT Cajero.id_cajero
			FROM Cajero
			WHERE usuario='caja1';

SELECT * FROM Administrador;
--Insert de una cajero
INSERT INTO [dbo].[DatosCajero]([nombre],[apellido_paterno],[apellido_materno],[curp] ,[fecha_nacimiento],[num_nomina],[email],[id_cajero],[id_admin])
     VALUES('pedro', 'hernandez', 'martinez', 'FABM770222MMSJNR00', '1990-07-07', '012115901621788495', 'correo@correo.com', 1, 1)
GO


INSERT INTO Cajero(usuario)
     VALUES('caja1')
GO

--Obtener todos los datos del cajero
SELECT DatosCajero.nombre, DatosCajero.[apellido_paterno],DatosCajero.[apellido_materno],DatosCajero.[curp],DatosCajero.[fecha_nacimiento],DatosCajero.[num_nomina],DatosCajero.[email],DatosCajero.[id_cajero], DatosCajero.[id_admin],Cajero.usuario
FROM DatosCajero
INNER JOIN Cajero ON DatosCajero.id_cajero=Cajero.id_cajero;


INSERT INTO Administrador(usuario) VALUES('admin');

TRUNCATE TABLE Cajero;
TRUNCATE TABLE Cajero;
SELECT * FROM Usuarios;
UPDATE Usuarios
SET rol = 2
WHERE usuario='vxcvxcv';

Select * FROM Usuarios;
SELECT * FROM Roles;
SELECT * FROM DatosCajero
SELECT * FROM Cajero;
SELECT * FROM Administrador;
DROP TABLE Cajero;
DROP TABLE Administrador;
TRUNCATE TABLE Usuarios;
TRUNCATE TABLE Administrador;



TRUNCATE TABLE Usuarios;
TRUNCATE TABLE Administrador;


Go

