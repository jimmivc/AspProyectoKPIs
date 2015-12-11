<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="resultadosKPI.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.resultadosKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="panel" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" Font-Bold="True" ForeColor="#733C7A" GroupingText="Resultados kpi">
            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged">
                <asp:ListItem>Seleccione un Rol</asp:ListItem>
            </asp:DropDownList>

            <asp:Panel ID="Panel4" runat="server" CssClass="table-responsive">
                <asp:GridView ID="dtgResultadosKPI" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" ReadOnly="True" />
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="formato" HeaderText="Formato" />
                        <asp:BoundField DataField="objetivo" HeaderText="Objetivo" />
                        <asp:BoundField DataField="resultado" HeaderText="Resultado" />
                        <asp:BoundField DataField="color" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </asp:Panel>
</asp:Content>
