<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenDePago.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID ="PanelPDF" runat="server">

    <h2>Orden de Pago</h2>
    <h3>&nbsp;</h3>
    <p>Código de Multa:
        <asp:Label ID="LabelCod" runat="server" Text="Label"></asp:Label>
    </p>
    <p>Importe: $
        <asp:Label ID="LabelImporte" runat="server" Text="Label"></asp:Label>
    </p>
    <p>Fecha de Pago:
        <asp:Label ID="LabelFecha" runat="server" Text="Label"></asp:Label>
    </p>




        </asp:Panel>
    <p>
            <asp:Button ID="ButtonImprimir" runat="server" Text="Generar PDF" OnClick="ButtonBuscar_Click" />

        </p>
        
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
