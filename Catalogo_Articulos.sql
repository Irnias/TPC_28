CREATE DATABASE Catalogo_Articulos
GO
USE Catalogo_Articulos
Go
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

SELECT A.IdArticulo as artId, A.Nombre as Nombre, A.Descripcion as Descrip, A.DescripcionLarga as DescripLarga, 
M.IdMarca as idMarca , M.Descripcion as descripMarca, C.IdCategoria as idCat ,C.Descripcion as descripCat, 
A.Precio as precio,I.IdImagenes as idImagen,  I.ImagenUrl as imgUrl 
FROM Articulos A, Marcas M, Categorias C, Imagenes I 
WHERE A.IdMarca = M.IdMarca and A.IdCategoria = C.IdCategoria and A.IdImagen = I.IdArt

Select * from Imagenes
Select * from Categorias
Select * from Calificaciones
