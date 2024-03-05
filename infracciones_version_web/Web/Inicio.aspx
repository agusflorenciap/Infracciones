<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Consulta de Infracciones</h1>
        <p class="lead">Desde aquí podrás consultar e imprimir tus infracciones de tránsito estén vencidas o no.</p>
        <p>Ingrese el dominio de su vehículo&nbsp;&nbsp; <asp:TextBox ID="TextBoxDominio" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="268px">
            <asp:ListBox ID="ListBoxMultas" runat="server" Height="274px" Width="1164px"></asp:ListBox>
            <asp:Button ID="ButtonPago" runat="server" Text="Generar Orden de Pago" OnClick="ButtonPago_Click" />
        </asp:Panel>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>
                <asp:TextBox ID="TextBoxPrueba" runat="server"></asp:TextBox>
            </h2>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>&nbsp;</h2>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salir" />
            </h2>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
