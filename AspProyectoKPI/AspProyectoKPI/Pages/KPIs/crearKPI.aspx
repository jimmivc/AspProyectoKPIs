<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crearKPI.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.crearKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel ID="Panel1" runat="server" BorderColor="Transparent" BorderWidth="50px" CssClass="panel panel-default" Font-Bold="True" GroupingText="Crear indicador KPI">
        <asp:Panel ID="Panel3" runat="server" CssClass="panel">
            <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" CssClass="panel">
            <asp:Label ID="Label2" runat="server" Text="Objetivo"></asp:Label>
            <asp:TextBox ID="txtObjetivo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtObjetivo" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

            <br />
            <asp:TextBox ID="txtLimiteInf" runat="server"></asp:TextBox>
            &nbsp;-
            <asp:TextBox ID="txtLimiteSup" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" CssClass="panel">
            <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>
            <asp:DropDownList ID="ddlFormato" runat="server" CssClass="form-control">
                <asp:ListItem>123</asp:ListItem>
                <asp:ListItem>noob</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="Periodicidad"></asp:Label>
            <asp:DropDownList ID="ddlPeriodicidad" runat="server" CssClass="form-control">
                <asp:ListItem>mensual</asp:ListItem>
                <asp:ListItem>you</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" CssClass="panel-body" GroupingText="Formula">

            <asp:Label ID="Label5" runat="server" Text="Campo"></asp:Label>
            <asp:DropDownList ID="ddlCampo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Llamadas</asp:ListItem>
                <asp:ListItem>Llamadas Efectivas</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Text="Valor"></asp:Label>
            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtValor" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>

            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-default" OnClick="btnAgregar_Click" Text="Agregar" />
            <asp:Button ID="btnSuma" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="+" />
            <asp:Button ID="btnResta" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="-" />
            <asp:Button ID="btnMultiplicacion" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="*" />
            <asp:Button ID="btnDivision" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="/" />
            <asp:TextBox ID="txtFormula" runat="server" CssClass="form-control" ReadOnly="True" Width="307px"></asp:TextBox>

            <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-default" Text="Borrar" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" style="margin-top: 0px" HeaderText="Solo se admiten numeros" />
        </asp:Panel>
        <asp:Panel ID="Panel7" runat="server" CssClass="panel">
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" Text="Crear" OnClick="btnCrear_Click" />
            </asp:Panel>
    </asp:Panel>
    
</asp:Content>
