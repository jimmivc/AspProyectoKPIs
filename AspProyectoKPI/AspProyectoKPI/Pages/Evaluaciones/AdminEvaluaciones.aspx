<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminEvaluaciones.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.AdminEvaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
      
        <h2 class="small">Administración de evaluaciones</h2>
   
    </div>
    <div class="row">
        <div class="col-sm-12">

      </div>
    </div>

   <div class="row">
  <div class="col-sm-6"><h3>Mantenimiento de encuestas</h3>
      <p>Gestión de preguntas para encuesta, creación de preguntas, modificación, categorización y asignación de rangos de calificación</p>
      <asp:Button ID="Button1" runat="server" Text="Gestión de preguntas" CssClass="btn btn-default" OnClick="Button1_Click" />

  </div>
  <div class="col-sm-6"><h3>Gestión de encuestas</h3>
      <p>Gestión de encuestas, creación de plantillas, generación de encuestas y envío a estudiantes</p>
      <asp:Button ID="Button2" runat="server" Text="Gestión de encuestas" CssClass="btn btn-default"/>
      
  </div>
  <div class="row">
      <div class="col-sm-12">

      </div>
  </div>

    </div>
</asp:Content>