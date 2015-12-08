<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionPreguntas.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.GestionPreguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
      
        <h2 class="small">Gestión de preguntas para encuesta</h2>
   
    </div>
    <div class="row">
        <div class="col-sm-12">

      </div>
    </div>

        <ul class="nav nav-tabs">
          <li class="active"><a data-toggle="tab" href="#home">Listado de preguntas existentes</a></li>
          <li><a data-toggle="tab" href="#menu1">Edición de preguntas</a></li>
          <li><a data-toggle="tab" href="#menu2">Categorías y asignación de valores</a></li>
        </ul>

        <div class="tab-content">
          <div id="home" class="tab-pane fade in active">
            <h3>Lista de preguntas existentes</h3>
            <p>Some content.</p>
          </div>
          <div id="menu1" class="tab-pane fade">
            <h3>Gestión preguntas</h3>
            <p>Some content in menu 1.</p>
          </div>
          <div id="menu2" class="tab-pane fade">
            <h3>Categorías y asignación de valores</h3>
            <p>Some content in menu 2.</p>
          </div>
            
        </div>





</asp:Content>
