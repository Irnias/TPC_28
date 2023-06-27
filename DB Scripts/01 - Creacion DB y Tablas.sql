CREATE DATABASE Catalogo_Articulos
GO

USE Catalogo_Articulos
GO

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

