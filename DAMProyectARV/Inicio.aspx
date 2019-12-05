<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="DAMProyectARV.WebForm1" Theme="Tema1" %>




<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link rel="stylesheet" type="text/css" href="theme.css">
    <asp:Label ID="labelUser" runat="server" Text="Bienvenido " Font-Size="Large"></asp:Label>
    <asp:Button Text="Simple Button 1" ID="simplebutton1" CssClass="botonSimple" runat="server" />

    <asp:Button Text="WebForm2.aspx" ID="Button1" OnClick="Button1_Click"  runat="server" />
    <asp:Button Text="+" ID="Button2" CssClass="simplebutton1_short" runat="server" />

    <div id="contenido">
        <div id="producto">

        </div>
        <div id="tabla">

        </div>



    </div>
</asp:Content>
