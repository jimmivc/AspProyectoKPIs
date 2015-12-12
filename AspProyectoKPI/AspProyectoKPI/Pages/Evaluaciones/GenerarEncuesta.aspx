<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarEncuesta.aspx.cs" Inherits="AspProyectoKPI.Pages.Evaluaciones.GenerarEncuesta" %>
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
            <li><a href="#encuestas" aria-controls="encuestas" role="tab" data-toggle="tab">Generar encuestas</a></li>
            <li><a href="#listaencuestas" aria-controls="listaencuestas" role="tab" data-toggle="tab">Listar encuestas generadas</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content" style="padding-top: 20px">
            <div role="tabpanel" class="tab-pane active" id="encuestas">
                <asp:Panel ID="Panel2" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" ForeColor="#733C7A" GroupingText="Generarción de encuestas">
                    <asp:Panel ID="Panel4" runat="server" CssClass="table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <p></p>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-sm-12">
                                <p>
                                    <asp:Label ID="Label1" runat="server" Text="Profesor" Height="32px" Width="217px" style="text-align:center"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="Cuatrimestre" Height="32px" Width="95px" style="text-align:center"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="Año" Height="32px" Width="110px" style="text-align:center"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="Curso" Height="32px" Width="263px" style="text-align:center"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text="Plantilla de encuesta" Height="32px" Width="201px" style="text-align:center"></asp:Label>
                                </p>
                                
                                    <asp:DropDownList ID="ddlProfesor" runat="server" Height="32px" Width="217px"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlCuatrimestre" runat="server" Height="32px" Width="95px"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlAnio" runat="server" Height="32px" Width="110px"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlCurso" runat="server" Height="32px" Width="263px"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlPlantilla" runat="server" Height="32px" Width="201px"></asp:DropDownList>
                                    
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <p>

                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <p>
                                                <asp:Button ID="Button2" runat="server" Text="Generar" CssClass="btn btn-primary bt-md" OnClick="Button2_Click" /></p>
                                        </div>
                                    </div>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                
                            </div>
                        </div>
                        
                    </asp:Panel>
                </asp:Panel>
            </div>
            <div role="tabpanel" class="tab-pane" id="listaencuestas">
                <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-default" BorderColor="Transparent" BorderWidth="50px" ForeColor="#733C7A" GroupingText="Lista de encuestas">
                    <asp:Panel ID="Panel3" runat="server" CssClass="table-responsive">
                        <asp:GridView ID="GridEncuestas" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:BoundField DataField="idEncuesta" HeaderText="ID Encuesta" ItemStyle-Width="90px" />
                                <asp:BoundField DataField="estudiante" HeaderText="Estudiante" ItemStyle-Width="550px" />
                                <asp:BoundField DataField="curso" HeaderText="Curso" ItemStyle-Width="110px" />
                                <asp:BoundField DataField="horario" HeaderText="Horario" ItemStyle-Width="90px" />
                                <asp:BoundField DataField="profesor" HeaderText="Profesor" ItemStyle-Width="550px" />
                                <asp:BoundField DataField="cuatrimestre" HeaderText="Cuatrimestre" ItemStyle-Width="110px" />
                                <asp:BoundField DataField="anio" HeaderText="Año" ItemStyle-Width="110px" />
                            </Columns>
                        </asp:GridView>

                        <div class="row">
                            <div class="col-sm-12">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                            </div>

                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>
