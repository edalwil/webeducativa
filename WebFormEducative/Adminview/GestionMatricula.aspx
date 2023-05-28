<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionMatricula.aspx.cs" Inherits="WebFormEducative.Adminview.GestionMatricula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-12">
                <h5 class="position-center">Alumnos por matricular en este nuevo periodo escolar</h5>
            </div>
            <div class="col-md-12">
                <asp:GridView ID="TABLESTUDENTS" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" OnRowCommand="TABLESTUDENTS_RowCommand" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging" AllowPaging="true">
                    <Columns>
                        <asp:BoundField DataField="id_student" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Nombre Completo">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# 
                                        Eval("st_first_name").ToString()+" "+
                                        Eval("st_second_name").ToString()+" "+
                                        Eval("st_surname").ToString()+" "+
                                        Eval("st_second_surname").ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%#Eval("id_student")+","+Eval("st_first_name").ToString()+" "+
                                        Eval("st_second_name").ToString()+" "+
                                        Eval("st_surname").ToString()+" "+
                                        Eval("st_second_surname").ToString() %>' ID="addSection" ToolTip="Matricular" runat="server" CommandName="Matricular" Text='<i class="fa fa-check-circle" style="color:white"></i>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
        <div id="ModalDisplayed" class="modal-subtle no-displayed">
            <div class="modal-subtle-content">
                <div class="modal-subtle-header">
                    <h5>Matricula: <%=nameStuendent %></h5>
                </div>
                <div class="modal-subtle-body">
                    <label for="Grado">Grado</label>
                    <asp:DropDownList AutoPostBack="True" OnSelectedIndexChanged="Grado_SelectedIndexChanged" CssClass="form-control" ID="Grado" runat="server">
                    </asp:DropDownList>
                    <label for="Seccion">Sección</label>
                    <asp:DropDownList CssClass="form-control" ID="Seccion" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="modal-subtle-footer position-rigth" style="justify-content: space-between">
                    <asp:Button ID="btnConfirmar" Text="Si" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="Confirmar" runat="server" />
                    <asp:Button ID="btnDenegar" Text="No" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="Denied" runat="server" />
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ClienteEjecutaScript" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
</asp:Content>
