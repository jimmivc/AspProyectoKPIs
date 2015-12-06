<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarResultadoEncuestas.aspx.cs" Inherits="AspProyectoKPI.Pages.Encuesta.ConsultarResultadoEncuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Carrera:"></asp:Label>
                    <asp:DropDownList ID="dropCarreras" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem>Desarrollo Diseño Web</asp:ListItem>
                        <asp:ListItem>Desarrollo Software</asp:ListItem>
                        <asp:ListItem>Administracion Sistemas Informaticos</asp:ListItem>
                        <asp:ListItem>Telematica</asp:ListItem>
                        <asp:ListItem>CiberSeguridad</asp:ListItem>
                        <asp:ListItem>Tecnologia Base Datos</asp:ListItem>
                    </asp:DropDownList>
                    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Encuesta:"></asp:Label>
                    <asp:DropDownList ID="dropTipoEncuesta" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control">
                    </asp:DropDownList>
                    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Periodo:"></asp:Label>
                    <asp:DropDownList ID="dropPeriodo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem>PrimerCuatrimestre</asp:ListItem>
                        <asp:ListItem>SegundoCuatrimestre</asp:ListItem>
                        <asp:ListItem>TercerCuatrimestre</asp:ListItem>
                    </asp:DropDownList>
                    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="textFecha" runat="server" Width="146px"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="168px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="719px">
            <Columns>
                <asp:BoundField DataField="carrera" HeaderText="Carrera" />
                <asp:BoundField DataField="Curso" HeaderText="Curso" />
                <asp:BoundField DataField="Profesor" HeaderText="Profesor" />
                <asp:BoundField DataField="Periodo" HeaderText="Periodo" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
        <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
