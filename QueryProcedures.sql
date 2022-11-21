use PuntoDeVenta;

--use Lab;

INSERT INTO Usuarios(usuario, contra, rol) VALUES('admin', 'admin', 1);
INSERT INTO Administrador(usuario) VALUES('admin');


<<<<<<< Updated upstream
=======
--VIEWS

--View para los productos a vender
IF OBJECT_ID('[Productos para la caja]') IS NOT NULL
	drop view [Productos para la caja];
GO
CREATE VIEW [Productos para la caja] AS
SELECT cod_producto, nombre, costo, precio_unitario
FROM Producto
WHERE existencia > 0 AND estatus = 1;

GO
If OBJECT_ID('[Productos para la caja]') IS NOT NULL
	Print 'View creada: [Productos para la caja]'


--View de reporte de ventas
IF OBJECT_ID('[Reporte de ventas]') IS NOT NULL
	drop view [Reporte de ventas];
GO
CREATE VIEW [Reporte de ventas] AS
	SELECT Recibo.fecha_venta, Departamento.nombre, ProductoComprado.cod_producto, CONVERT(DECIMAL(10,2), ProductoComprado.precio_producto) as Precio_Unitario, ProductoComprado.cantidad, CONVERT(DECIMAL(10,2),Recibo.subtotal) as Subtotal, CONVERT(DECIMAL(10,2),Recibo.descuento) as Descuento, Recibo.num_recibo, CONVERT(DECIMAL(10,2),((ProductoComprado.precio_producto - Producto.costo) * ProductoComprado.cantidad)) as Utilidad, Recibo.caja FROM Recibo
	INNER JOIN ProductoComprado 
	ON Recibo.num_recibo = ProductoComprado.num_recibo
	INNER JOIN Producto 
	ON ProductoComprado.cod_producto = Producto.cod_producto
	INNER JOIN Departamento
	ON Producto.cve_departamento=Departamento.clave_departamento;

GO
If OBJECT_ID('[Reporte de ventas]') IS NOT NULL
	Print 'View creada: [Reporte de ventas]'
GO

	
----Funciones

--Funcion que retorna la cantidad de descuento de un producto para la parte de reporte de cajeros
IF OBJECT_ID (N'getCantidadDescuento',N'FN') IS NOT NULL
    DROP FUNCTION getCantidadDescuento;
GO
CREATE FUNCTION getCantidadDescuento(@codProducto AS int, @fechaVenta AS date)
RETURNS INT
AS
BEGIN
	Declare @cant int;
	
	IF Exists(Select cantidad from Descuento where fecha_inicio <= @fechaVenta and fecha_final >= @fechaVenta and cod_producto = @codProducto)
	Begin
		set @cant = (Select cantidad from Descuento where fecha_inicio <= @fechaVenta and fecha_final >= @fechaVenta and cod_producto = @codProducto)
	End
	Else
	Begin
		set @cant =	(Select 0)
	End

	RETURN @cant
END
GO

--funcion que verifica la cantidad en existencia al comprar
IF OBJECT_ID (N'getProductoVenta',N'FN') IS NOT NULL
    DROP FUNCTION getProductoVenta;
GO
CREATE FUNCTION getProductoVenta(@codProducto AS int, @cantidad AS decimal(10,2))
RETURNS INT
AS
BEGIN
	Declare @resp int;
	
	IF Exists(Select * from Producto where cod_producto = @codProducto and existencia>=@cantidad)
	Begin
		set @resp = (Select 1)
	End
	Else
	Begin
		set @resp =	(Select 0)
	End

	RETURN @resp
END
GO



-- Procedures

>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
EXEC sp_Login @usuario = 'admin2', @contra = 'adminn';
GO
=======


--EXEC sp_Login @usuario = 'admin2', @contra = 'adminn';
--GO
>>>>>>> Stashed changes

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

	-----Reporte Cajeros

	--Nombres de cajeros
	IF @operacion = 'SR'
	BEGIN
			SELECT D.nombre as Cajero
			FROM DatosCajero D
			INNER JOIN Cajero ON D.id_cajero=Cajero.id_cajero
			INNER JOIN Usuarios ON Usuarios.usuario=Cajero.usuario
			WHERE D.activo = 1;
	END

	--
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
		@existencia DECIMAL(10,2) = NULL,
		@merma DECIMAL(10,2) = NULL,
		@puntoreordenProd DECIMAL(10,2) = NULL,
		@estatusProd BIT = NULL,
		@id_unidadMedida TINYINT = NULL,
		@cve_departamento varchar(5)= NULL,
		@id_admin TINYINT = NULL,
		@codProd INT = NULL,
		@FIDepartamento nvarchar(max) = NULL,
		@FIExistencia int = NULL,
		@FIAgotados bit = NULL,
		@FIMerma bit = NULL,
		@DFechaI date = NULL,
		@DFechaF date = NULL,
		@DCantidad TINYINT = NULL,
		@DEstatus bit = NULL

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


<<<<<<< Updated upstream
	--IF @operacion = 'S'
	--BEGIN
	--		SELECT clave_departamento,nombre, devolucion
	--		FROM Departamento
	--		WHERE activo = 1;
	--END
=======
	--Busqueda de productos
	IF @operacion = 'BP'
	BEGIN
			
			SELECT cod_producto, nombre, costo, precio_unitario FROM [Productos para la caja];
		
	END

	-- Producto con codigo
	IF @operacion = 'PC'
	BEGIN

			if(dbo.getProductoVenta(@codProd,@existencia) = 1)
			BEGIN
				SELECT cod_producto, nombre, costo, precio_unitario FROM [Productos para la caja]
				WHERE cod_producto = @codProd;
			END

			
			
		
	END

	--Select Inventario
	IF @operacion = 'SI'
	BEGIN
			Declare @query nvarchar(max)
			Declare @consulta nvarchar(max)
			Declare @params nvarchar(max)
			--Declare @FIDepartament nvarchar(max)
			--Declare @FIExistenci int

			--set @FIDepartament = 'Carniceria'
			--set @FIExistenci = 12

			set @params = '@dep varchar(max), @exist int'
			set @consulta = 'SELECT P.nombre as Nombre, D.nombre as Departamento, U.nombre as UnidadMedida, P.costo as CostoProducto, P.precio_unitario as PrecioUnitario, P.existencia as Existencias, (Select ISNULL(SUM(cantidad),0) From ProductoComprado where cod_producto = P.cod_producto) as UnidadesVendidas, P.merma as Merma
			FROM Producto P
			LEFT JOIN Departamento D On D.clave_departamento = P.cve_departamento
			LEFT JOIN UnidadMedida U On U.id_unidadMedida = P.id_unidadMedida 
			where 1=1 '
>>>>>>> Stashed changes


			IF @FIDepartamento != ''
					SET @consulta = @consulta + 'and D.nombre = @dep ' 

			IF @FIExistencia > 0
					set @consulta = @consulta + 'and P.existencia >= @exist '

			IF @FIAgotados = 1
					set @consulta = @consulta + 'and P.existencia = 0 '

			IF @FIMerma = 1
					set @consulta = @consulta + 'and P.merma > 0 '
			

			Exec sp_executesql @consulta, @params, @dep = @FIDepartamento, @exist = @FIExistencia
	END

	
	--Añadir descuento
	IF @operacion = 'AD'
	BEGIN
			IF NOT EXISTS (SELECT * FROM Descuento WHERE cod_producto = @codProd and (((@DFechaI >= fecha_inicio and @DFechaI <= fecha_final) or (@DFechaI <= fecha_inicio)) and ((@DFechaF >= fecha_inicio and @DFechaF <= fecha_final) or (@DFechaF >= fecha_final))))
			BEGIN
			 INSERT into Descuento(fecha_inicio,fecha_final,cantidad,cod_producto, estatus) VALUES (@DFechaI,@DFechaF,@DCantidad,@codProd, @DEstatus);
			END	
	END
END
GO


<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
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




<<<<<<< Updated upstream
=======
IF OBJECT_ID('sp_GestionRecibos') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_GestionRecibos
END
GO
CREATE PROCEDURE sp_GestionRecibos(
		@operacion VARCHAR(2) = NULL,
		@descuento SMALLMONEY = NULL,
		@subtotal SMALLMONEY = NULL,
		@total SMALLMONEY = NULL,
		@precioProducto SMALLMONEY = NULL,
		@cantidadProducto SMALLMONEY = NULL,
		@codProducto INT = NULL,
		@numRecibo INT = NULL,
		@metodoPago INT = NULL,
		@cantidadPago SMALLMONEY = NULL,
		@idCaja INT = null,
		@idCajero INT = null
)AS	
BEGIN
	DECLARE @Fecha as date
	SET @Fecha = GetDate()
	
	-- Crear el recibo
	IF @operacion = 'I'
	BEGIN
			INSERT INTO Recibo(descuento, subtotal, total, fecha_venta, caja, cajero)
			VALUES(@descuento, @subtotal, @total, @Fecha, @idCaja, @idCajero);

		
	END

	--Obtener el id del ultimo recibo
	IF @operacion = 'ID'
	BEGIN

			SELECT IDENT_CURRENT ('Recibo') AS UltimoId; 
		
	END


	-- Asociar los productos con su recibo
	IF @operacion = 'ID'
	BEGIN

			INSERT INTO ProductoComprado(precio_producto, cantidad, cod_producto, num_recibo)
			VALUES(@precioProducto, @cantidadProducto, @codProducto, @numRecibo);
		
	END

	-- Asociar los pagos con cada recibo
	IF @operacion = 'RP'
	BEGIN

			INSERT INTO Pago(num_recibo, id_metodo, cantidadPago)
			VALUES(@numRecibo, @metodoPago, @cantidadPago);
		
	END

END
GO


--Procedure de reportes
IF OBJECT_ID('sp_Reportes') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_Reportes
END
GO
CREATE PROCEDURE sp_Reportes(
		@operacion VARCHAR(2) = NULL,
		@fechaI DATE = null,
		@fechaF DATE = null,
		@cajero varchar(30) = null,
		@departamento varchar(30) = null
)AS	
BEGIN

	-- Reporte de ventas
	IF @operacion = 'V'
	BEGIN

		SELECT * FROM [Reporte de ventas];
		
	END

	--Reporte de cajero
	IF @operacion = 'RC'
	BEGIN
		Declare @query nvarchar(max)
		Declare @params nvarchar(max)

		set @params = '@dep varchar(max), @caj varchar(max), @fecI DATE, @fecF DATE	'

		set @query = 'SELECT R.fecha_venta, DC.nombre as Cajero , D.nombre as Departamento, PC.cantidad as Cantidad, 
			CONVERT(DECIMAL(10,2),(PC.precio_producto * PC.cantidad) - ((PC.precio_producto * PC.cantidad) * (dbo.getCantidadDescuento(PC.cod_producto,R.fecha_venta) * 0.01))) as Venta,
			CONVERT(DECIMAL(10,2),((PC.precio_producto - P.costo) * PC.cantidad) - ((PC.precio_producto * PC.cantidad) * (dbo.getCantidadDescuento(PC.cod_producto,R.fecha_venta) * 0.01))) as Utilidad 
		FROM Recibo R
		INNER JOIN ProductoComprado PC
		ON R.num_recibo = PC.num_recibo
		INNER JOIN DatosCajero DC
		ON DC.id_cajero = R.cajero
		INNER JOIN Producto P 
		ON PC.cod_producto = P.cod_producto
		INNER JOIN Departamento D
		ON P.cve_departamento=D.clave_departamento where 1=1'

		if @departamento != ''
			set @query = @query + ' and D.nombre = @dep'

		if @fechaI != ''
			set @query = @query + ' and R.fecha_venta >= @fecI'

		if @fechaF != ''
			set @query = @query + ' and R.fecha_venta <= @fecF'

		if @cajero != ''
			set @query = @query + ' and DC.nombre = @caj'
		
		Exec sp_executesql @query, @params, @dep = @departamento, @caj = @cajero, @fecI = @fechaI, @fecF = @fechaF

	END

END
GO


--Devoluciones

IF OBJECT_ID('sp_Devoluciones') IS NOT NULL
BEGIN
	DROP PROCEDURE sp_Devoluciones
END
GO
CREATE PROCEDURE sp_Devoluciones(
		@operacion VARCHAR(3) = NULL,
		@numRecibo INT = null,
		@idNota int = null,
		@totalNota SMALLMONEY = null,
		@id_admin TINYINT = NULL,
		@id_prod INT = NULL,
		@totalProd SMALLMONEY = null,
		@cantidadProd decimal(10,2) = null
)AS	
BEGIN
	-- Obtener productos de un recibo
	IF @operacion = 'SP'
	BEGIN
			Select PC.id_productoComprado as CodProductoVenta, P.nombre as Producto, PC.cantidad as Cantidad, PC.precio_producto as PrecioProducto from ProductoComprado PC 
			LEFT JOIN Producto P on P.cod_producto = PC.cod_producto
			LEFT JOIN Departamento D on P.cve_departamento = D.clave_departamento
			where PC.num_recibo =@numRecibo and D.devolucion = 1; 
		
	END

	--id ultima nota
	IF @operacion = 'IdD'
	BEGIN
			SELECT IDENT_CURRENT ('NotaCredito') AS UltimoId; 
	END

	--insert de las notas
	IF @operacion = 'INo'
	BEGIN
			Insert into NotaCredito(total,id_admin, num_recibo) Values (@totalNota,@id_admin, @numRecibo)	
	END

	--insert de las devoluciones
	IF @operacion = 'IDe'
	BEGIN
			Insert into Devolucion(id_productoComprado,id_notaCredito,total,cantidad) Values (@id_prod,@idNota,@totalProd,@cantidadProd)	
	END

	--Regresamos al inventario la cantidad del producto a existencias
	IF @operacion = 'IPN'
	BEGIN
			Update P set P.existencia = P.existencia + @cantidadProd from Producto P
			inner join ProductoComprado PC on PC.id_productoComprado = @id_prod
			where P.cod_producto = PC.cod_producto
	END

	--Regresamos al inventario la cantidad del producto a merma
	IF @operacion = 'IPM'
	BEGIN
			Update P set P.merma = P.merma + @cantidadProd from Producto P
			inner join ProductoComprado PC on PC.id_productoComprado = @id_prod
			where P.cod_producto = PC.cod_producto
	END
>>>>>>> Stashed changes

END
GO


<<<<<<< Updated upstream
use PuntoDeVenta;
Select * from Usuarios
Select * from Cajero
Select * from DatosCajero
Select * from Administrador
=======
>>>>>>> Stashed changes

INSERT INTO MetodosPago(metodo) VALUES('Efectivo');
INSERT INTO MetodosPago(metodo) VALUES('Tarjeta de debito');
INSERT INTO MetodosPago(metodo) VALUES('Tarjeta de credito');


--update Producto set existencia = CONVERT(decimal(10,2),5.6) where cod_producto = 4;

-----Pruebas-----

--INSERT INTO Recibo(descuento, subtotal, total, fecha_venta)
--			VALUES(2, 2, 2, GetDate());

--			SELECT SCOPE_IDENTITY() as id;


----Pruebas 

--use PuntoDeVenta;
--Select * from Usuarios
--Select * from Cajero
--Select * from DatosCajero
--Select * from Administrador
--SELECT * FROM Recibo;
--SELECT * FROM Producto;
--Select * from Devolucion
--Select * from Recibo
--Select * from ProductoComprado
--SELECT * FROM NotaCredito;
--SELECT * FROM Devolucion;
--update Producto set merma = 0 where cod_producto >0

--update Caja set cajero = 1 where num_caja=2;

--SELECT IDENT_CURRENT ('Caja') AS UltimoId; 


--Truncate table dbo.Caja;

--ALTER TABLE Administrador
--DROP CONSTRAINT  fk_Administradorusuario;


--Truncate table Cajero;
--Truncate table Departamento;


--use PuntoDeVenta;


--INSERT INTO Usuarios(usuario, contra, rol) VALUES('caja1', 'caja', 2);
--Select * From Administrador;

--INSERT INTO Cajero(usuario) VALUES ('caja1');

--USE [PuntoDeVenta]
--GO





<<<<<<< Updated upstream
SELECT Cajero.id_cajero
			FROM Cajero
			WHERE usuario='caja1';
=======
--Correcion de errores 

--UPDATE Caja 
--			SET  cajero = null
--			WHERE num_caja = 1;	


--SELECT * FROM [Productos para la caja];

--SELECT Cajero.id_cajero
--			FROM Cajero
--			WHERE usuario='caja1';

--SELECT * FROM Administrador;
----Insert de una cajero
--INSERT INTO [dbo].[DatosCajero]([nombre],[apellido_paterno],[apellido_materno],[curp] ,[fecha_nacimiento],[num_nomina],[email],[id_cajero],[id_admin])
--     VALUES('pedro', 'hernandez', 'martinez', 'FABM770222MMSJNR00', '1990-07-07', '012115901621788495', 'correo@correo.com', 1, 1)
--GO


--INSERT INTO Cajero(usuario)
--     VALUES('caja1')
--GO

>>>>>>> Stashed changes




--Obtener todos los datos del cajero



<<<<<<< Updated upstream
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
=======


--Pruebas--

--Select dbo.getCantidadDescuento(1,'2022-11-17') * .01
>>>>>>> Stashed changes

--Select * from Devolucion
--Select * from Descuento

--Declare @filtros varchar(255)

--set @filtros = 'Electrónica'

--SELECT P.nombre as Nombre, D.nombre as Departamento, U.nombre as UnidadMedida, P.costo as CostoProducto, P.precio_unitario as PrecioUnitario, P.existencia as Existencias, (Select ISNULL(SUM(cantidad),0) From ProductoComprado where cod_producto = P.cod_producto) as UnidadesVendidas, P.merma as Merma
--			FROM Producto P
--			LEFT JOIN Departamento D On D.clave_departamento = P.cve_departamento
--			LEFT JOIN UnidadMedida U On U.id_unidadMedida = P.id_unidadMedida
--			where P.existencia >= 0 and D.nombre = @filtros

--SELECT * FROM Descuento WHERE cod_producto = 1 and ((('2022-10-01' > fecha_inicio and '2022-10-01' < fecha_final) or ('2022-10-01' < fecha_inicio)) and (('2022-11-06' > fecha_inicio and '2022-11-06' < fecha_final) or ('2022-11-06' > fecha_final)))

