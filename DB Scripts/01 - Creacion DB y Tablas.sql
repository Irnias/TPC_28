CREATE DATABASE Catalogo_Articulos
GO

USE Catalogo_Articulos
GO

select * from usuarios

Create Table Marcas(
	IdMarca int not null primary key identity (1,1),
	Descripcion varchar (50)
)
GO

Create Table Categorias(
	IdCategoria int not null primary key identity (1,1),
	Descripcion varchar (50)
)
GO

Create Table Imagenes(
	IdImagenes int not null primary key identity(1,1),
	IdArt int not null,
	ImagenUrl varchar(1000) not null
)
GO
	

Create Table Usuarios(
	UserId int not null primary key identity(1,1),
	Nombre varchar(50),
	Apellido varchar(50),
	Mail varchar(60),
	Contrasenia varchar(30),
)
GO 

Create Table Calificaciones(
	IdCalificacion int not null primary key identity (1,1),
	IdArt int not null,
	Calificacion int not null,
	IdUsuario int  null foreign key references Usuarios(UserId)
)
GO

Create Table Articulos(
	IdArticulo int not null primary key identity (1,1),
	Nombre varchar(50),
	Descripcion varchar(150),
	DescripcionLarga varchar(1000),
	IdMarca int not null foreign key references Marcas(IdMarca),
	IdCategoria int not null foreign key references Categorias(IdCategoria),
	Precio money not null,
	IdCalificacion int  null foreign key references Calificaciones(IdCalificacion)
)
GO

CREATE PROCEDURE SP_AltaArticulos
	@Nombre varchar(50),
	@Descripcion varchar(150),
	@DescripcionLarga varchar(300),
	@IdMarca int,
	@IdCategoria int,
	@ImagenUrl varchar(1000),
	@Precio money	
AS
BEGIN
	DECLARE @tempId int;

	INSERT INTO Articulos (Nombre, Descripcion, DescripcionLarga, IdMarca, IdCategoria, Precio)
	VALUES (@Nombre, @Descripcion, @DescripcionLarga, @IdMarca, @IdCategoria, @Precio);

	SET @tempId = SCOPE_IDENTITY();

	INSERT INTO Imagenes (IdArt, ImagenUrl)
	VALUES (@tempId, @ImagenUrl);
END
go

CREATE PROCEDURE SP_ModificarArticulos
	@Nombre varchar(50),
	@Descripcion varchar (150),
	@DescripcionLarga varchar (300),
	@IdMarca int,
	@IdCategoria int,
	@ImagenUrl varchar(1000),
	@Precio money,
	@id int
as
BEGIN
	UPDATE Articulos set Nombre = @Nombre, Descripcion = @Descripcion, DescripcionLarga = @DescripcionLarga, 
	IdMarca = @IdMarca, IdCategoria= @IdCategoria, Precio = @Precio
	WHERE IdArticulo = @id ;
	UPDATE Imagenes set ImagenUrl = @ImagenUrl WHERE IdArt = @id
END
GO

CREATE PROCEDURE SP_EliminarArticulos
	@id int
as
	DELETE FROM Articulos WHERE IdArticulo = @id 
GO

ALTER TABLE Usuarios
ADD TipoUsuario INT;

GO
CREATE TABLE TipoEnvios (
    IdTipoEnvio int not null primary key identity (1,1),
    Descripcion varchar(50)
);

CREATE TABLE TipoPagos (
    IdTipoPago int not null primary key identity (1,1),
    Descripcion varchar(50)
);

CREATE TABLE DireccionEnvio (
    IdDireccionEnvio int not null primary key identity (1,1),
    Usuario int null foreign key references Usuarios(UserId),
    Descripcion varchar(50) null,
    Calle varchar(50) not null,
    Numero int not null,
    Piso int null,
    Departamento varchar(6) null,
    CodigoPostal varchar(6) not null,
    Ciudad varchar(50) not null,
    Pais varchar(50) not null
);

CREATE TABLE Envios (
    IdEnvio int not null primary key identity (1,1),
    CodigoEnvio varchar(5),
    TipoEnvio int not null foreign key references TipoEnvios(IdTipoEnvio),
    DireccionEnvio int not null foreign key references DireccionEnvio(IdDireccionEnvio),
    Usuario int null foreign key references Usuarios(UserId),
    Estado varchar(50)
);

CREATE TABLE Pagos (
    IdPago int not null primary key identity (1,1),
    TipoPago int not null foreign key references TipoPagos(IdTipoPago),
    Estado varchar(50)
);

CREATE TABLE Compras (
    IdCompra int not null primary key identity (1,1),
    InfoExtra varchar(150),
    Envio int null foreign key references Envios(IdEnvio),
    Pago int null foreign key references Pagos(IdPago),
    Usuario int null foreign key references Usuarios(UserId),
    PrecioTotal money not null,
    Estado varchar(50)
);
select * from Compras 

insert into Compras(Envio,Pago,Usuario,PrecioTotal,Estado)

SELECT  C.IdCompra as Id, C.PrecioTotal as PrecioTotal, C.Estado AS EstadoCompra, E.CodigoEnvio, E.DireccionEnvio AS IdDireccionEnvio, P.TipoPago, U.UserId as IdUsuario, U.Nombre, U.Mail FROM Compras C LEFT JOIN Envios E ON C.Envio = E.IdEnvio LEFT JOIN Pagos P ON C.Pago = P.IdPago LEFT JOIN Usuarios U on U.UserId = C.Usuario
select * from Envios
select * from TipoEnvios

select * from TipoPagos

select * from Usuarios

SELECT C.IdCompra as Id, C.PrecioTotal as PrecioTotal, C.Estado AS EstadoCompra, E.CodigoEnvio,  DE.Calle, DE.Numero, Tp.Descripcion, U.UserId as IdUsuario, U.Nombre, U.Mail
FROM Compras C LEFT JOIN Envios E ON C.Envio = E.IdEnvio LEFT JOIN DireccionEnvio DE ON E.DireccionEnvio = DE.IdDireccionEnvio LEFT JOIN Pagos P ON C.Pago = P.IdPago
LEFT JOIN TipoPagos Tp on Tp.IdTipoPago = P.TipoPago
LEFT JOIN Usuarios U ON U.UserId = C.Usuario


insert into Compras(Usuario,PrecioTotal)
VALUES(2,10)


insert into Compras (PrecioTotal)
values(1)

CREATE TABLE ProductosCompra (
    IdProductosCompra int not null primary key identity (1,1),
    Compra int null foreign key references Compras(IdCompra),
    Articulo int null foreign key references Articulos(IdArticulo),
    Cant int NOT NULL,
    PrecioCobrado money NOT NULL
);
