<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="DAMProyectARV.WebForm2" Theme="Tema1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div id="contenido">
        <div id="producto">
            <div id="ventasLabel">
                <asp:Label ID="labelVentas" runat="server" Text="VENTAS"></asp:Label>

            </div>
            <table id="filaVentas">
                <tr>
                    <td>
                        <asp:Label ID="labelCantidad" runat="server" Text="Introduce el código de producto: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtProducto" runat="server" /></td>
                    <td>
                        <asp:Button Text="Añadir" CssClass="botonSimpleSmall" runat="server" OnClick="botonAñadir" /></td>
                </tr>


            </table>
        </div>
        <div id="tablaVentas">
            <asp:GridView ID="Grid_Ventas" CssClass="gridView" Visible="false" runat="server" ShowFooter="true" GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="#C0EDED" />
                <RowStyle Height="30px" />

                <Columns>
                    <asp:BoundField DataField="CODIGO" HeaderText="CODIGO PRODUCTO" Visible="true" />
                    <%--0--%>
                    <asp:TemplateField HeaderText="CANTIDAD"><%--1--%>
                        <ItemTemplate>
                            <asp:Button Text="-" CssClass="botonCantidadModificar" runat="server" OnClick="botonRestar" CommandArgument='<%# Container.DataItemIndex %>' />
                            <asp:Label ID="labelCantidad" runat="server" Text='<%# Bind("CANTIDAD_MOV") %>'></asp:Label>
                            <asp:Button Text="+" CssClass="botonCantidadModificar" runat="server" OnClick="botonSumar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" Visible="true" />
                    <asp:BoundField DataField="PRECIO_SIN_IVA" HeaderText="PRECIO SIN IVA" Visible="true" />
                    <asp:BoundField DataField="PRECIO" HeaderText="PRECIO" Visible="true" />
                    <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD_ALMACEN" Visible="false" />
                    <asp:BoundField DataField="PRECIO_TOTAL" HeaderText="TOTAL" Visible="true" />
                    <%--6--%>
                    <asp:TemplateField HeaderText="ELIMINAR">
                        <ItemTemplate>
                            <asp:Button Text="Eliminar" CssClass="botonSimpleSmall" OnClick="btnEliminar" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center"></RowStyle>
                <FooterStyle CssClass="footerGrid" />
            </asp:GridView>
        </div>




    </div>
</asp:Content>
