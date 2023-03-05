<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PrjProyecto_Tienda_Bodega.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <style>
        body
        {
            margin: 0;
            background-color: #333;
            font-family: sans-serif;
        }

        .main-menu
        {
            list-style: none;
            margin-top: 0;
            margin-bottom: 0;
            padding-left: 0;

            display: flex;
            flex-direction: column;
            align-items: center;
            background-color: #5168f4;
        }

        @media screen and (min-width: 760px) {
            .main-menu
            {
                flex-direction: row;
            }
        }

        .main-menu_item
        {
            padding: 1em;
        }

        .main-menu_link
        {
            color: white;
            text-transform: uppercase;
            text-decoration: none;
        }
    </style>

    <nav class="main-nav">
        <ul id="main-menu" class="main-menu">
            <li class="main-menu_item">
                <a href="http://localhost:61127/Productos/InsertarProducto" class="main-menu_link">Registrar Producto</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Productos/ListadoProductos" class="main-menu_link">Mantenimiento de Producto</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Clientes/ClienteInsertar" class="main-menu_link">Registrar Cliente</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Clientes/ListadoClientes" class="main-menu_link">Mantenimiento de Cliente</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Ventas/us_consulta_ventas" class="main-menu_link">Consultar Venta</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Ventas/InsertarVenta" class="main-menu_link">Registrar Nueva Venta</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Reportes/ReporteVentas" class="main-menu_link">Reporte de Venta</a>
            </li>
            <li class="main-menu_item">
                <a href="http://localhost:61127/Reportes/ReporteClientes" class="main-menu_link">Reporte de Cliente</a>
            </li>
        </ul>
    </nav>
</body>
</html>
