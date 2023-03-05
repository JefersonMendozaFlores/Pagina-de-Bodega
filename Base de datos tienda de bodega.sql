--
-- CREACION DE BASE DE DATOS 
--
create database Proyecto_Tienda
go

--USANDO LA BASE DE DATOS
--
use Proyecto_Tienda
go

--
-- CREACION DE LAS TABLAS
--

-- TABLA USUARIO
-- SERVIRA PARA PODER INICAR SESION A LA PAGINA
--
create table tb_usuario
(
idUsuario int identity(1,1) primary key,
fullNombres varchar(300) not null,
correo varchar(300) not null,
contraseña varchar(300) not null
)
go
-- REGISTRO
insert into tb_usuario values ('Jorge Paredez Maldini','Jorge@gmail.com','ABC987')
go

-- TABLA CLIENTE
--
create table tb_cliente
(
idCliente int identity(1,1) primary key,
nombres varchar(100) not null,
apellidos varchar(100) not null,
fechaNacimiento date not null,
celular char(9) not null
)
go
-- REGISTRO
insert into tb_cliente values ('Jeferson','Mendoza','2004-01-14','96535941');
insert into tb_cliente values ('Marco','Paredez','2002-01-14','953497345')
go

-- TABLA VENDEDOR
--
create table tb_vendedor
(
idVendedor int identity(1,1) primary key,
nombres varchar(100) not null,
apellidos varchar(100) not null,
fechaNacimiento date not null,
celular char(9) not null
)
go
-- REGISTRO
insert into tb_vendedor values ('Fabrizio','Quiroz','2001-01-14','984523098');
insert into tb_vendedor values ('Maria','Rosales','2000-01-14','907645234')
go

-- TABLA PROVEEDOR
--
create table tb_proveedor
(
idProveedor int identity(1,1) primary key,
marca varchar(100) not null
)
go
-- REGISTRO
insert into tb_proveedor values ('Cola Cola');
insert into tb_proveedor values ('Picaras')
go

-- TABLA CATEGORIA
--
create table tb_categoria
(
idCategoria int identity(1,1) primary key,
descripcion varchar(200) not null
)
go
-- REGISTROS
insert into tb_categoria values ('Gaseosa');
insert into tb_categoria values ('Galletas')
go

-- TABLA PRODUCTO
--
create table tb_producto
(
idProducto int identity(1,1) primary key,
idProveedor int not null,
idCategoria int not null,
stock int not null,
precioUnitario decimal(6,2),
--estableciendo llaves foraneas
constraint FK1_producto foreign key (idProveedor) references tb_proveedor(idProveedor),
constraint FK2_producto foreign key (idCategoria) references tb_categoria(idCategoria)
)
go
-- REGISTROS
insert into tb_producto values (1,1,100,3.50);
insert into tb_producto values (2,2,200,2.30)
go

-- TABLA VENTA
--
create table tb_venta
(
idVenta int identity(1,1) primary key,
idCliente int not null,
idVendedor int not null,
fechaVenta date not null,
--estableciendo llaves foraneas
constraint FK1_venta foreign key (idCliente) references tb_cliente(idCliente),
constraint FK2_venta foreign key (idVendedor) references tb_vendedor(idVendedor)
)
go
-- REGISTROS
insert into tb_venta values (1,1,'2023-02-11');
insert into tb_venta values (2,2,'2023-02-11')
go

-- TABLA DETALLE VENTA
--
create table tb_detalleVenta
(
idVenta int not null,
idProducto int not null,
cantidad int not null,
precioUnitario decimal(6,2) not null,
Total as (cantidad * precioUnitario),
--estableciendo llaves foraneas
constraint FK1_detalleVenta foreign key (idVenta) references tb_venta(idVenta),
constraint FK2_detalleVenta foreign key (idProducto) references tb_producto(idProducto)
)
go
-- REGISTROS
insert into tb_detalleVenta values (1,1,3,3.50);
insert into tb_detalleVenta values (2,1,3,3.50)
go

-- CONSULTAS A LAS TABLAS
--
--select * from tb_usuario
--select * from tb_cliente
--select * from tb_vendedor
--select * from tb_proveedor
--select * from tb_categoria
--select * from tb_producto
--select * from tb_venta
--select * from tb_detalleVenta
--go

