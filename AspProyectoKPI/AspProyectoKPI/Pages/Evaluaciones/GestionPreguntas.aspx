<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionPreguntas.aspx.cs" Inherits="AspProyectoKPI.Pages.KPIs.GestionPreguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 

   <div class="row">
        <div class="col-sm-12">
            <p>

            </p>
        </div>
    </div>

    

         <div id="Tabs" role="tabpanel">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li><a href="#preguntas" aria-controls="preguntas" role="tab" data-toggle="tab">Gestión de Preguntas
                </a></li>
                <li><a href="#categorias" aria-controls="categorias" role="tab" data-toggle="tab">Gestión de Categorías</a></li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content" style="padding-top: 20px">
                <div role="tabpanel" class="tab-pane active" id="preguntas">
                    <asp:Panel ID="Panel2" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" ForeColor="#733C7A" GroupingText="Preguntas">
                        <asp:Panel ID="Panel4" runat="server" CssClass="table-responsive">
                            <asp:GridView ID="GridListaPreguntas" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False"  OnRowCancelingEdit="GridListaPreguntas_RowCancelingEdit" OnRowDeleting="GridListaPreguntas_RowDeleting" 
                                OnRowEditing="GridListaPreguntas_RowEditing" OnRowUpdating="GridListaPreguntas_RowUpdating" OnSelectedIndexChanged="GridListaPreguntas_SelectedIndexChanged">
                                
                                <Columns>
                                    <asp:BoundField DataField="idPregunta" HeaderText="ID Pregunta" ReadOnly="True" ItemStyle-Width="90px"/>
                                    <asp:BoundField DataField="pregunta" HeaderText="Pregunta" ItemStyle-Width="550px"/>
                                    <asp:BoundField DataField="categoria" HeaderText="Categoría" ItemStyle-Width="110px"/>
                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
                                    <ControlStyle CssClass="btn btn-default btn-sm" />
                                    </asp:CommandField>
                                </Columns>
                                
                            </asp:GridView>

                            <div class="row">
                                <div class="col-sm-12">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-9">
                                    <p>
                                        <asp:TextBox ID="txtPregunta" runat="server" Height="30px" Width="669px" placeholder="Escriba una pregunta nueva."></asp:TextBox>
                                        <asp:DropDownList ID="ddlCategoria" runat="server" Height="30px" Width="201px">
                                        </asp:DropDownList>
                                        <asp:Button ID="Button1" runat="server" Text="Registrar" OnClick="Button1_Click" CssClass="btn btn-primary bt-md" />
                                    </p>
                                </div>
                        </div>
                        </asp:Panel>
                    </asp:Panel>
                </div>
                <div role="tabpanel" class="tab-pane" id="categorias">
                    <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" ForeColor="#733C7A" GroupingText="Categorías">
                        <asp:Panel ID="Panel3" runat="server" CssClass="table-responsive">
                            <asp:GridView ID="GridCategorias" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" 
                                OnRowCancelingEdit="GridCategorias_RowCancelingEdit" OnRowDeleting="GridCategorias_RowDeleting" OnRowEditing="GridCategorias_RowEditing"
                                OnRowUpdating="GridCategorias_RowUpdating" OnSelectedIndexChanged="GridCategorias_SelectedIndexChanged" >
                                <Columns>
                                    <asp:BoundField DataField="idCategoria" HeaderText="ID Categoría"/>
                                    <asp:BoundField DataField="categoria" HeaderText="Categoría" />
                                    <asp:BoundField DataField="minimo" HeaderText="Puntaje mínimo" />
                                    <asp:BoundField DataField="maximo" HeaderText="Puntaje máximo" />
                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" >
                                    <ControlStyle CssClass="btn btn-default btn-sm" />
                                    </asp:CommandField>
                                </Columns>
                               
                            </asp:GridView>

                            <div class="row">
                                <div class="col-sm-12">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>
                                        <asp:TextBox ID="TextCategoria" runat="server" Width="740px" placeholder="Escriba una categoría nueva."></asp:TextBox>
                                        <asp:TextBox ID="TextMinimo" runat="server" Width="740px" placeholder="Escriba el puntaje mínimo."></asp:TextBox>
                                        <asp:TextBox ID="TextMaximo" runat="server" Width="740px" placeholder="Escriba el puntaje máximo."></asp:TextBox>
                                        <asp:Button ID="Button2" Text="Registrar" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" />
                                    </p>
                                </div>

                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <br />
        <br />
       <asp:HiddenField ID="TabName" runat="server" />
   
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "preguntas";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>



</asp:Content>

