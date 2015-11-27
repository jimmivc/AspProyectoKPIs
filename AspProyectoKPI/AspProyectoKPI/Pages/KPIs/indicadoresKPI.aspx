<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="indicadoresKPI.aspx.cs" Inherits="AspProyectoKPI.Paginas.indicadoresKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" Font-Bold="True" ForeColor="#733C7A" GroupingText="Indicadores KPI">
        <asp:Panel ID="Panel3" runat="server" CssClass="table-responsive">
        <asp:GridView ID="dtgIndicadoresKPI" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" OnRowEditing="dtgIndicadoresKPI_RowEditing" OnRowCancelingEdit="dtgIndicadoresKPI_RowCancelingEdit" OnRowDeleting="dtgIndicadoresKPI_RowDeleting" OnSelectedIndexChanging="dtgIndicadoresKPI_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="descripcion" HeaderText="Descipcion" />
                <asp:BoundField DataField="formato" HeaderText="Formato" />
                <asp:BoundField DataField="objetivo" HeaderText="Objetivo" ReadOnly="True" />
                <asp:BoundField DataField="periodicidad" HeaderText="Periodicidad" />
                <asp:CommandField ShowEditButton="True" ButtonType="Button" DeleteText="Deshabilitar" ShowDeleteButton="True" ShowSelectButton="True" SelectText="Consultar" >
                <ControlStyle CssClass="btn btn-default" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Button ID="btnCrearKPI" runat="server" CssClass="btn btn-primary" Text="Crear KPI" OnClick="btnCrearKPI_Click" />
            <asp:Button ID="btnAsignar" runat="server" CssClass="btn btn-primary" Text="Asignar KPIs" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
