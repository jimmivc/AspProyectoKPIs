<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="asignarIndicadoresKPI.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.asignarIndicadoresKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-xs-6">
        <asp:Panel ID="panel" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" Font-Bold="True" ForeColor="#733C7A" GroupingText="KPIs Asignados">
            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged">
                <asp:ListItem>Seleccione un Rol</asp:ListItem>
            </asp:DropDownList>

            <asp:Panel ID="Panel4" runat="server" CssClass="table-responsive">
                <asp:GridView ID="dtgIndicadoresAsignados" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </asp:Panel>
        
    </div>
    <div class="col-xs-6">
        <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" Font-Bold="True" ForeColor="#733C7A" GroupingText="Indicadores KPI">
            <asp:Panel ID="Panel3" runat="server" CssClass="table-responsive">
                <asp:GridView ID="dtgIndicadoresKPI" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" OnSelectedIndexChanging="dtgIndicadoresKPI_SelectedIndexChanging" OnRowDeleting="quitarKPI">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descipcion" />
                        <asp:CommandField ShowSelectButton="True" SelectText="Asignar" DeleteText="Quitar" ShowDeleteButton="True">
                        <ControlStyle CssClass="btn btn-default" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </asp:Panel>
    </div>
    

    <asp:Panel ID="Panel2" runat="server"></asp:Panel>
</asp:Content>
