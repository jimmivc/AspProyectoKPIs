<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEvaluaciones.aspx.cs" Inherits="AspProyectoKPI.Pages.Evaluaciones.GestionEvaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server" GroupingText="Crear Plantilla">
        <asp:GridView ID="dtgPreguntas" runat="server" CssClass="table table-striped table-hover">
            <Columns>
                <asp:TemplateField HeaderText="Agregar">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckBxPreguntas" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Descripción de plantilla"></asp:Label>
        <asp:TextBox ID="txtDescPlantilla" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" CssClass="btn btn-primary section" runat="server" OnClick="Button1_Click" Text="Crear" />
    </asp:Panel>
</asp:Content>
