--	USANDO LA BASE DE DATOS PROYECTO TIENDA DE BODEGA 
use Proyecto_Tienda
go

-- CREACION DE PROCEDIMIENTOS ALMACENADOS
--

--
-- CONSULTA VENTA POR SU ID
create or alter procedure usp_consulta_venta
@idVenta int
as
begin
select v.idVenta,
concat(c.nombres,' ',c.apellidos) as Nombres_Clientes,
concat(ve.nombres,' ',ve.apellidos) as Nombre_Vendedor,
v.fechaVenta,dv.idProducto,ca.descripcion,pv.marca,dv.cantidad,dv.precioUnitario,dv.Total
-- TABLA VENTA CON TABLA DETALLE VENTA
from tb_venta v 
inner join tb_detalleVenta dv 
on v.idVenta=dv.idVenta 
-- TABLA CLIENTE CON TABLA VENTA
inner join tb_cliente c 
on v.idCliente=c.idCliente
-- TABLA VENDEDOR CON TABLA VENTA
inner join tb_vendedor ve
on v.idVendedor=ve.idVendedor
-- TABLA PRODUCTO CON TABLA DETALLE VENTA
inner join tb_producto p
on dv.idProducto=p.idProducto
-- TABLA CATEGORIA CON TABLA PRODUCTO
inner join tb_categoria ca
on p.idCategoria=ca.idCategoria
-- TABLA PROVEEDOR CON TABLA PRODUCTO
inner join tb_proveedor pv
on p.idProveedor=pv.idProveedor
where v.idVenta=@idVenta
end
go

-- INICIAR SESION POR CORREO Y CONTRASEÑA
--
create or alter procedure usp_login
@correo varchar(300),
@contraseña varchar(300)
as
begin
select correo,contraseña
from tb_usuario
where correo=@correo and contraseña=@contraseña
end
go

-- REGISTRAR NUEVO PRODUCTO
--
create or alter procedure usp_registrarProducto
@idProv int, @idCateg int, @stock int, @precUni decimal(6,2)
as
begin
insert into tb_producto values(@idProv,@idCateg,@stock,@precUni)
end
go

-- REGISTRAR NUEVO CLIENTE
--
create or alter procedure usp_registrarCliente
@nombre varchar(100),@apellidos varchar(100),@fecNac date,@celular char(9)
as
begin
insert into tb_cliente values(@nombre,@apellidos,@fecNac,@celular)
end
go

-- REGISTRAR NUEVA VENTA O ORDEN DE PAGO 
--
create or alter procedure usp_registrarVenta
@idCli int, @idVend int, @fecVenta date
as
begin 
insert into tb_venta values(@idCli,@idVend,@fecVenta)
end
go

-- REGISTRAR DETALLE A LA VENTA O ORDEN DE PAGO
--
create or alter procedure usp_registrarDetalleVenta
@idVenta int, @idProd int, @cantidad int, @precUni decimal(6,2)
as
begin 
insert into tb_detalleVenta values(@idVenta,@idProd,@cantidad,@precUni)
end
go

-- LISTAR TODOS LOS CLIENTE EN UNA TABLA
--
create or alter procedure usp_listar_clientes
as
begin
select * from tb_cliente
end
go

-- LISTAR TODOS LOS PRODUCTOS EN UN TABLA
--
create or alter procedure usp_listar_productos
as
begin
select * from tb_producto
end
go

-- ACTUALIZAR PRODUCTO POR SU ID
-- SOLO EDITARA LOS CAMPOS STOCK Y PRECIO UNITARIO
--
create or alter procedure usp_actualizar_producto
@idProducto int,
@stock int,
@precioUnitario decimal(6,2)
as
begin
update tb_producto
	set stock=@stock, precioUnitario=@precioUnitario
where idProducto=@idProducto
end
go

-- ACTUALIZAR CLIENTE POR SU ID
-- SOLO EDITARA EL CAMPO CELULAR
--
create or alter procedure usp_actualizar_cliente
@idCliente int,
@celular char(9)
as
begin
update tb_cliente
	set celular=@celular
where idCliente=@idCliente
end
go

-- LISTAR DATOS DE LAS VENTAS EN UN REPORTE
--
create or alter procedure usp_reporte_venta
as
begin
select v.idVenta,
v.fechaVenta,dv.idProducto,ca.descripcion,pv.marca,dv.cantidad,dv.precioUnitario
-- TABLA VENTA CON TABLA DETALLE VENTA
from tb_venta v 
inner join tb_detalleVenta dv 
on v.idVenta=dv.idVenta 
-- TABLA VENDEDOR CON TABLA VENTA
inner join tb_vendedor ve
on v.idVendedor=ve.idVendedor
-- TABLA PRODUCTO CON TABLA DETALLE VENTA
inner join tb_producto p
on dv.idProducto=p.idProducto
-- TABLA CATEGORIA CON TABLA PRODUCTO
inner join tb_categoria ca
on p.idCategoria=ca.idCategoria
-- TABLA PROVEEDOR CON TABLA PRODUCTO
inner join tb_proveedor pv
on p.idProveedor=pv.idProveedor
end
go

-- LISTAR DATOS DE LOS CLIENTES REGISTRADOS EN UN REPORTE
--
create or alter procedure usp_reporte_cliente
as
begin
select * 
from tb_cliente
end
go









