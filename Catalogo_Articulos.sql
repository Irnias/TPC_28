CREATE DATABASE Catalogo_Articulos
GO
USE Catalogo_Articulos
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
Create Table Calificaciones(
IdCalificacion int not null primary key identity (1,1),
IdArt int not null,
Calificacion int null,
Usuario varchar(300)
)
GO
Create Table Articulos(
IdArticulo int not null primary key identity (1,1),
Nombre varchar(50),
Descripcion varchar(150),
DescripcionLarga varchar(300),
IdMarca int not null foreign key references Marcas(IdMarca),
IdCategoria int not null foreign key references Categorias(IdCategoria),
IdImagen int not null foreign key references Imagenes(idImagenes),
Precio money not null,
IdCalificacion int not null foreign key references Calificaciones(IdCalificacion)
)

SELECT * FROM Marcas
SELECT* from Articulos