<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrjProyecto_Tienda_Bodega.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>

    <title></title>
</head>
<body>

    <style>
        .h1 {
        font-family: Arial;
        }

        .wrapper {
            background-color: #333;
            display: flex;
            align-items: center;
            flex-direction: column;
            justify-content: center;
            width: 100%;
            min-height: 100%;
            padding: 245px;
        }
        #formcontent
        {
            -webkit-border-radius: 10px 10px 10px 10px;
            border-radius: 10px 10px 10px 10px;
            background: #fff;
            padding: 30px;
            width: 90%;
            max-width: 450px;
            position: relative;
            padding: 0px;
            -webkit-box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
            box-shadow: 0 30px 60px 0 rgba(0,0,0,0,.3);
            text-align: center;
        }
    </style>

    <div class="wrapper">
        <div class="formcontent">
            <form id="Formulario_login" runat="server">
                <div class="form-control">
                    <div class="col-md-6 text-center mb-5">
                        <asp:Label class="h1" ID="lblBienvenida" runat="server" Text="Bienvenidos/as Al sistema"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
                        <asp:TextBox ID="tbCorreo" cssClass="form-control" runat="server" placeholder="Correo"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="tbPassword" cssClass="form-control" runat="server" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row">
                        <asp:label runat="server" CssClass="alert-info" ID="lblError"></asp:label>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnIngresar" cssClass="btn btn-dark" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"/>
                    </div>
                </div>
            </form>
        </div>
    </div>

</body>
</html>
