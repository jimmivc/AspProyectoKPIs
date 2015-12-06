 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultarKPI.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.consultarKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" BorderColor="Transparent" BorderWidth="50px" CssClass="panel panel-default" Font-Bold="True" GroupingText="Indicador KPI">
        <asp:Panel ID="Panel3" runat="server" CssClass="panel">
            <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" CssClass="form-inline">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Objetivo"></asp:Label>
                <br />
                <asp:TextBox ID="txtObjetivo" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="rojo" runat="server" CssClass="form-control btn-danger disabled" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="amarillo" runat="server" CssClass="form-control btn-warning disabled" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="verde" runat="server" CssClass="form-control btn-success disabled" ReadOnly="True"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" CssClass="form-inline">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>
                <asp:DropDownList ID="ddlFormato" runat="server" CssClass="form-control" Enabled="False">
                </asp:DropDownList>
                <asp:Label ID="Label4" runat="server" Text="Periodicidad"></asp:Label>
                <asp:DropDownList ID="ddlPeriodicidad" runat="server" CssClass="form-control" Enabled="False">
                </asp:DropDownList>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" CssClass="panel-body" GroupingText="Formula">
            <div class="form-inline">
                <div class="form-group">
                    <asp:TextBox ID="txtFormula" runat="server" CssClass="form-control" ReadOnly="True" Width="307px"></asp:TextBox>
                    <br />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel7" runat="server" CssClass="panel">
                <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" Text="Volver" OnClick="btnCrear_Click" />
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary" OnClick="btnModificar_Click" Text="Modificar" />
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" Visible="False" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
