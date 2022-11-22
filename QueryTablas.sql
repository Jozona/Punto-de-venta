--DROP DATABASE PuntoDeVenta;

--CREATE DATABASE otra;
--use Lab;
CREATE database PuntoDeVenta;
Go
use PuntoDeVenta;

--------------
IF OBJECT_ID('Usuarios') IS NOT NULL
	drop table Usuarios;
CREATE TABLE Usuarios(
    usuario VARCHAR(30) PRIMARY KEY,
    contra VARCHAR(30)  NOT NULL,
	rol TINYINT NOT NULL,
);
If OBJECT_ID('Usuarios') IS NOT NULL
	Print 'Tabla creada: Usuarios'


------------
IF OBJECT_ID('Roles') IS NOT NULL
	drop table Roles;
CREATE TABLE Roles(
    clave_rol TINYINT IDENTITY PRIMARY KEY,
    nombre_rol VARCHAR(30)  NOT NULL,
);
If OBJECT_ID('Roles') IS NOT NULL
	Print 'Tabla creada: Roles'


-----------------
IF OBJECT_ID('Administrador') IS NOT NULL
	drop table Administrador;
CREATE TABLE Administrador(
    id_admin TINYINT IDENTITY(1,1) PRIMARY KEY,  
	usuario VARCHAR(30) UNIQUE
);
If OBJECT_ID('Administrador') IS NOT NULL
	Print 'Tabla creada: Administrador'


--------------------
IF OBJECT_ID('Cajero') IS NOT NULL
	drop table Cajero;
CREATE TABLE Cajero(
    id_cajero TINYINT IDENTITY(1,1) PRIMARY KEY,  
	usuario VARCHAR(30)
);
If OBJECT_ID('Cajero') IS NOT NULL
	Print 'Tabla creada: Cajero'


-----------------------
IF OBJECT_ID('DatosCajero') IS NOT NULL
	drop table DatosCajero;
CREATE TABLE DatosCajero(
    id_datosCajero TINYINT IDENTITY(1,1) PRIMARY KEY,  
	nombre VARCHAR(30) NOT NULL,
	apellido_paterno VARCHAR(30) NOT NULL,
	apellido_materno VARCHAR(30) NOT NULL,
	curp VARCHAR(18) NOT NULL UNIQUE,
	fecha_nacimiento DATE NOT NULL,
	num_nomina VARCHAR(30) UNIQUE NOT NULL,
	email VARCHAR(30) UNIQUE NOT NULL,
	fecha_ingreso DATETIME DEFAULT CURRENT_TIMESTAMP,
	id_cajero TINYINT,
	id_admin TINYINT,
	activo BIT DEFAULT 1
);
If OBJECT_ID('Cajero') IS NOT NULL
	Print 'Tabla creada: DatosCajero'


-------------------
IF OBJECT_ID('Departamento') IS NOT NULL
	drop table Departamento;
CREATE TABLE Departamento(
    clave_departamento VARCHAR(5) PRIMARY KEY,  
	nombre VARCHAR(30) NOT NULL,
	devolucion BIT NOT NULL,
	activo BIT DEFAULT 1,
	id_admin TINYINT
);
If OBJECT_ID('Departamento') IS NOT NULL
	Print 'Tabla creada: Departamento'



-------------------
IF OBJECT_ID('Producto') IS NOT NULL
	drop table Producto;
CREATE TABLE Producto(
    cod_producto INT IDENTITY(1,1) PRIMARY KEY,  
	nombre VARCHAR(50) NOT NULL,
	descripcion VARCHAR(50)NOT NULL,
	costo SMALLMONEY NOT NULL,
	precio_unitario SMALLMONEY NOT NULL,
	existencia DECIMAL(10,2) NOT NULL,
	merma DECIMAL(10,2) DEFAULT 0,
	punto_reorden DECIMAL(10,2) NOT NULL,
	estatus BIT NOT NULL,
	fecha_alta DATETIME DEFAULT CURRENT_TIMESTAMP,
	cve_departamento VARCHAR(5),
	id_unidadMedida TINYINT,
	id_admin TINYINT
);
If OBJECT_ID('Producto') IS NOT NULL
	Print 'Tabla creada: Producto'


-------------------
IF OBJECT_ID('UnidadMedida') IS NOT NULL
	drop table UnidadMedida;
CREATE TABLE UnidadMedida(
    id_unidadMedida TINYINT IDENTITY(1,1) PRIMARY KEY,  
	nombre VARCHAR(20) NOT NULL,	
);
If OBJECT_ID('UnidadMedida') IS NOT NULL
	Print 'Tabla creada: UnidadMedida'


-------------------
IF OBJECT_ID('Caja') IS NOT NULL
	drop table Caja;
CREATE TABLE Caja(
    num_caja TINYINT IDENTITY(1,1) PRIMARY KEY, 
	estatus BIT NOT NULL,
	id_admin TINYINT,
	cajero TINYINT,
);
If OBJECT_ID('Caja') IS NOT NULL
	Print 'Tabla creada: Caja'


-------------------
IF OBJECT_ID('Descuento') IS NOT NULL
	drop table Descuento;
CREATE TABLE Descuento(
    cod_descuento SMALLINT IDENTITY(1,1) PRIMARY KEY, 
	fecha_inicio DATE NOT NULL,
	fecha_final DATE NOT NULL,
	cantidad TINYINT NOT NULL,
	estatus bit NOT NULL,
	cod_producto INT
);
If OBJECT_ID('Descuento') IS NOT NULL
	Print 'Tabla creada: Descuento'


-------------------
IF OBJECT_ID('Modificacion') IS NOT NULL
	drop table Modificacion;
CREATE TABLE Modificacion(
    id_modificacion INT IDENTITY(1,1) PRIMARY KEY, 
	fecha_modificacion DATETIME DEFAULT CURRENT_TIMESTAMP,	
	cod_producto INT,
	id_admin TINYINT,
);
If OBJECT_ID('Modificacion') IS NOT NULL
	Print 'Tabla creada: Modificacion'


-------------------
IF OBJECT_ID('Recibo') IS NOT NULL
	drop table Recibo;
CREATE TABLE Recibo(
    num_recibo INT IDENTITY(1,1) PRIMARY KEY, 
	descuento SMALLMONEY NOT NULL,
	subtotal SMALLMONEY NOT NULL,
	total SMALLMONEY NOT NULL,
	fecha_venta DATETIME DEFAULT CURRENT_TIMESTAMP,
	caja TINYINT NOT NULL,
	cajero TINYINT NOT NULL
);
If OBJECT_ID('Recibo') IS NOT NULL
	Print 'Tabla creada: Recibo'


-------------------
IF OBJECT_ID('MetodosPago') IS NOT NULL
	drop table MetodosPago;
CREATE TABLE MetodosPago(
    id_metodo TINYINT IDENTITY(1,1) PRIMARY KEY, 
	metodo VARCHAR(20) NOT NULL
);
If OBJECT_ID('MetodosPago') IS NOT NULL
	Print 'Tabla creada: MetodosPago'


-------------------
IF OBJECT_ID('Pago') IS NOT NULL
	drop table Pago;
CREATE TABLE Pago(
    id_pago TINYINT IDENTITY(1,1) PRIMARY KEY, 
	num_recibo INT,
	id_metodo TINYINT,
	cantidadPago SMALLMONEY NOT NULL,
);
If OBJECT_ID('Pago') IS NOT NULL
	Print 'Tabla creada: Pago'


-------------------
IF OBJECT_ID('ProductoComprado') IS NOT NULL
	drop table ProductoComprado;
CREATE TABLE ProductoComprado(
    id_productoComprado INT IDENTITY(1,1) PRIMARY KEY, 
	precio_producto SMALLMONEY NOT NULL,
	cantidad DECIMAL(10,2) NOT NULL,
	cod_producto INT,
	num_recibo INT,
);
If OBJECT_ID('ProductoComprado') IS NOT NULL
	Print 'Tabla creada: ProductoComprado'


-------------------
IF OBJECT_ID('NotaCredito') IS NOT NULL
	drop table NotaCredito;
CREATE TABLE NotaCredito(
    id_notaCredito INT IDENTITY(1,1) PRIMARY KEY, 
	fecha_notaCredito DATETIME DEFAULT CURRENT_TIMESTAMP,
	total SMALLMONEY NOT NULL,
	num_recibo INT not null,
	id_admin TINYINT
);
If OBJECT_ID('NotaCredito') IS NOT NULL
	Print 'Tabla creada: NotaCredito'

	-------------------
IF OBJECT_ID('Devolucion') IS NOT NULL
	drop table Devolucion;
CREATE TABLE Devolucion(
    id_devolucion TINYINT IDENTITY(1,1) PRIMARY KEY,  
	id_productoComprado INT,
	id_notaCredito INT,
	total SMALLMONEY NOT NULL,
	cantidad DECIMAL(10,2) NOT NULL
);
If OBJECT_ID('Devolucion') IS NOT NULL
	Print 'Tabla creada: Devolucion'




--------Asignar llaves foraneas a las tablas necesarias---------

------

------
use PuntoDeVenta;
ALTER TABLE Administrador
ADD CONSTRAINT fk_Administradorusuario
FOREIGN KEY (usuario)
REFERENCES Usuarios(usuario);

------
ALTER TABLE Cajero
ADD CONSTRAINT fk_Cajerousuario
FOREIGN KEY (usuario)
REFERENCES Usuarios(usuario);

------
ALTER TABLE DatosCajero
ADD CONSTRAINT fk_DatosCajerocajero
FOREIGN KEY (id_cajero)
REFERENCES Cajero(id_cajero);

ALTER TABLE DatosCajero
ADD CONSTRAINT fk_DatosCajeroadmin
FOREIGN KEY (id_admin)
REFERENCES Administrador(id_admin);

------
ALTER TABLE Departamento
ADD CONSTRAINT fk_Departamentoadmin
FOREIGN KEY (id_admin)
REFERENCES Administrador(id_admin);

------
ALTER TABLE Devolucion
ADD CONSTRAINT fk_DevolucionProducto
FOREIGN KEY (id_productoComprado)
REFERENCES ProductoComprado(id_productoComprado);

ALTER TABLE Devolucion
ADD CONSTRAINT fk_Devolucionnota
FOREIGN KEY (id_notaCredito)
REFERENCES NotaCredito(id_notaCredito);

------
ALTER TABLE Producto
ADD CONSTRAINT fk_ProductounidadMedida
FOREIGN KEY (id_unidadMedida)
REFERENCES UnidadMedida(id_unidadMedida);

ALTER TABLE Producto
ADD CONSTRAINT fk_Productoadmin
FOREIGN KEY (id_admin)
REFERENCES Administrador(id_admin);

ALTER TABLE Producto
ADD CONSTRAINT fk_ProductoDepartamento
FOREIGN KEY (cve_departamento)
REFERENCES Departamento(clave_departamento);

------
ALTER TABLE Caja
ADD CONSTRAINT fk_Cajaadmin
FOREIGN KEY (id_admin)
REFERENCES Administrador(id_admin);

ALTER TABLE Caja
ADD CONSTRAINT fk_Cajacajero
FOREIGN KEY (cajero)
REFERENCES Cajero(id_cajero);

------
ALTER TABLE Pago
ADD CONSTRAINT fk_Pagorecibo
FOREIGN KEY (num_recibo)
REFERENCES Recibo(num_recibo);

ALTER TABLE Pago
ADD CONSTRAINT fk_Pagometodo
FOREIGN KEY (id_metodo)
REFERENCES MetodosPago(id_metodo);

------
ALTER TABLE Recibo
ADD CONSTRAINT fk_CajaAutor
FOREIGN KEY (caja)
REFERENCES Caja(num_caja);

ALTER TABLE Recibo
ADD CONSTRAINT fk_CajeroAutor
FOREIGN KEY (cajero)
REFERENCES Cajero(id_cajero);

------
ALTER TABLE ProductoComprado
ADD CONSTRAINT fk_ProductoCompradoproducto
FOREIGN KEY (cod_producto)
REFERENCES Producto(cod_producto);

ALTER TABLE ProductoComprado
ADD CONSTRAINT fk_ProductoCompradorecibo
FOREIGN KEY (num_recibo)
REFERENCES Recibo(num_recibo);

------

ALTER TABLE NotaCredito
ADD CONSTRAINT fk_NotaCreditoadmin
FOREIGN KEY (id_admin)
REFERENCES Administrador(id_admin);

ALTER TABLE NotaCredito
ADD CONSTRAINT fk_NotaCreditoRecibo
FOREIGN KEY (num_recibo)
REFERENCES Recibo(num_recibo);

------
ALTER TABLE Modificacion
ADD CONSTRAINT fk_ModificacionProducto
FOREIGN KEY (cod_producto)
REFERENCES Producto(cod_producto);

------
ALTER TABLE Descuento
ADD CONSTRAINT fk_DescuentoProducto
FOREIGN KEY (cod_producto)
REFERENCES Producto(cod_producto);

--Ejecutar el script de Descripciones---



