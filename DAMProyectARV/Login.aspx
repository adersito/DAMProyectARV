<%@ Page Title="Bienvenido" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DAMProyectARV.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .contenido {
            background-color: red;
            margin-left: auto; 
            margin-right: auto;
            height: 250px;
            width:350px;
            
        }

        .contenedor {
            background: yellow;
            height: 300px;
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 10%;
            margin-left: 20%;
            margin-right: 20%;
        }
        th{
            height:70px;
            text-align:center;
        }
        td{
            height:25px;
        }
        table{
            margin:auto;
            border: dashed;
            background:green;
            
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="contenedor">
            <div class="contenido" style="">
                <table>
                    <tr><th>Introduce tus credenciales</th></tr>
                    <tr>
                        <td>
                            <asp:Label ID="labelUsuario" runat="server" Text="Usuario: "></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" Height="16px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="labelContraseña" runat="server" Text="Contraseña: "></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server" Height="16px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                            
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
