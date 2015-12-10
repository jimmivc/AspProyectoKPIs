<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crearKPI.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.crearKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel ID="Panel1" runat="server" BorderColor="Transparent" BorderWidth="50px" CssClass="panel panel-default" Font-Bold="True" GroupingText="Crear indicador KPI">
        <asp:Panel ID="Panel3" runat="server" CssClass="panel">
            <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" CssClass="form-inline">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Objetivo"></asp:Label>
                <br />
                <asp:TextBox ID="txtObjetivo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnAceptarObj" runat="server" CssClass="btn btn-default" OnClick="btnAceptarObj_Click" Text="Aceptar" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtObjetivo" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                <asp:DropDownList ID="ddlLimiteInf" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:DropDownList ID="ddlLimiteSup" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlLimiteSup_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" CssClass="form-inline">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>
                <asp:DropDownList ID="ddlFormato" runat="server" CssClass="form-control">
                    <asp:ListItem>123</asp:ListItem>
                    <asp:ListItem>123.4</asp:ListItem>
                    <asp:ListItem>%</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label4" runat="server" Text="Periodicidad"></asp:Label>
                <asp:DropDownList ID="ddlPeriodicidad" runat="server" CssClass="form-control">
                    <asp:ListItem>mensual</asp:ListItem>
                    <asp:ListItem>cuatrimestral</asp:ListItem>
                    <asp:ListItem>anual</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Datos"></asp:Label>
                <asp:DropDownList ID="ddlDatos" runat="server" CssClass="form-control">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Profesores</asp:ListItem>
                    <asp:ListItem>Mercadeo</asp:ListItem>
                </asp:DropDownList>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" CssClass="panel-body" GroupingText="Formula">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Campo"></asp:Label>
                    <asp:DropDownList ID="ddlCampo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Llamadas</asp:ListItem>
                        <asp:ListItem>Llamadas Efectivas</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label6" runat="server" Text="Valor"></asp:Label>
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtValor" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>

                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-default" OnClick="btnAgregar_Click" Text="Agregar" />
                    <asp:Button ID="btnSuma" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="+" />
                    <asp:Button ID="btnResta" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="-" />
                    <asp:Button ID="btnMultiplicacion" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="*" />
                    <asp:Button ID="btnDivision" runat="server" CssClass="btn btn-default" OnClick="btnOperador_Click" Text="/" />
                    <br />
                    <br />
                    <asp:TextBox ID="txtFormula" runat="server" CssClass="form-control" ReadOnly="True" Width="307px"></asp:TextBox>

                    <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-default" Text="Borrar" />

                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="margin-top: 0px" HeaderText="Solo se admiten numeros" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel7" runat="server" CssClass="panel">
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" Text="Crear" OnClick="btnCrear_Click" />
            </asp:Panel>
    </asp:Panel>
    
</asp:Content>
