insert into Categorias (Descripcion)
values ('Alimento Perros'),('Alimento Gatos')

insert into Marcas (Descripcion)
values ('Peedigree'),('Natual Choice'),('Estampa'),('Purina')

insert into Articulos (Nombre,Descripcion,DescripcionLarga,IdMarca,IdCategoria,Precio)
values ('Pedigree','Alimento Perro','Para perritos lindos',1,1,500),
('Natural DOG','Alimento Perro','Para perritos lindos',1,1,1500),
('Estampa pupis','Alimento Perro','Para perritos lindos',1,1,300),
('Purina Excelent','Alimento Michis','Para michis lindos',2,2,750),
('Cat Chow ','Alimento Michis','Para perritos lindos',2,2,500)


insert into Imagenes (IdArt,ImagenUrl)
values 
(1,'https://jumboargentina.vtexassets.com/arquivos/ids/760144/Alimento-Para-Perros-Pedigree-Adulto-15-Kg-1-16855.jpg?v=638048145796470000'),
(1,'https://i5.walmartimages.com.mx/mg/gm/1p/images/product-images/img_large/00750617450347-2l.jpg?odnHeight=612&odnWidth=612&odnBg=FFFFFF'),
(2,'https://delkoalimentos.com.ar/contenido/lineas/1.png'),
(2,'https://vetmarketportal.com.ar/uploads/ckeditor/20200425191309_pag_19.jpg'),
(3,'https://d3ugyf2ht6aenh.cloudfront.net/stores/001/961/189/products/d_858741-mla32272538095_092019-o-4b3adf38dd99cc956f16386572719704-640-0.jpg'),
(3,'https://animall.com.ar/2227-medium_default/estampa-plus-razas-pequenas-x-8-kg.jpg'),
(4,'https://mla-s1-p.mlstatic.com/851749-MLA49052565471_022022-F.jpg'),
(4,'https://nutrican.com.ar/wp-content/uploads/2021/08/7613034742988-2.jpg'),
(5,'https://hiperlibertad.vteximg.com.br/arquivos/ids/193270-600-600/CATCHOW-ADLTPESCX85G-1-7699.jpg?v=637820590240100000'),
(5,'https://elmundodelasmascotas.com.ar/wp-content/uploads/2020/09/CAT-CHOW-PESCADO.png')

USE Catalogo_Articulos

SELECT TOP 1 IdArt, ImagenUrl
FROM Imagenes
WHERE IdArt = 3
GROUP BY IdArt, ImagenUrl
ORDER BY IdArt 

SELECT TOP 1 IdArt, ImagenUrl FROM IMAGENES WHERE IdArt=3



insert into Imagenes (IdArt, ImagenUrl)
values
(1,'https://i5.walmartimages.com.mx/mg/gm/1p/images/product-images/img_large/00750617450347-2l.jpg?odnHeight=612&odnWidth=612&odnBg=FFFFFF'),
(2,'https://vetmarketportal.com.ar/uploads/ckeditor/20200425191309_pag_19.jpg'),
(3,'https://animall.com.ar/2227-medium_default/estampa-plus-razas-pequenas-x-8-kg.jpg'),
(4,'https://nutrican.com.ar/wp-content/uploads/2021/08/7613034742988-2.jpg'),
(5,'https://elmundodelasmascotas.com.ar/wp-content/uploads/2020/09/CAT-CHOW-PESCADO.png')

select * from Imagenes