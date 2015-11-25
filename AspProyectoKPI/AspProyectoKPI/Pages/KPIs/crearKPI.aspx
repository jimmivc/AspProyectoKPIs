<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crearKPI.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.crearKPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel ID="Panel1" runat="server" BorderColor="Transparent" BorderWidth="50px" CssClass="panel panel-default" Font-Bold="True" GroupingText="Crear indicador KPI">
        <asp:Panel ID="Panel3" runat="server" CssClass="panel">
            <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" CssClass="panel">
            <asp:Label ID="Label2" runat="server" Text="Objetivo"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server">
            <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-toggle">
                <asp:ListItem>hello</asp:ListItem>
                <asp:ListItem>noob</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="Periodicidad"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown-toggle">
                <asp:ListItem>see</asp:ListItem>
                <asp:ListItem>you</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
    </asp:Panel>
    
</asp:Content>
