<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionStudent.aspx.cs" Inherits="WebFormEducative.Adminview.GestionStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-6 px-5">
                <div class="group-form-label">
                    <label  for="firstname">
                        Primer Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="firstname" />
                    
                </div>
                <div class="group-form-label">
                    <label  for="secondname">
                        Segundo Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="secondname" />
                    
                </div>
                <div class="group-form-label">
                    <label  for="surname">
                        Apellido Paterno</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="surname" />
                    
                </div>
                <div class="group-form-label">
                    <label  for="secondsurname">
                        Apellido Materno</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="secondsurname" />
                    
                </div>
                <label for="birthdate">Fecha Nacimiento</label>
                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="birthdate" />
                <div class="group-form-label">
                    <label  for="doc">
                        Documento Identidad</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="doc" />
                </div>
                <div class="position-center">
                    <asp:Button ID="BTNREGISTRAR" Text="Registrar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnAddStudent_Click" />
                    <asp:Button ID="BTNEDITAR" Text="Editar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnEdit_Click" />
                    <asp:Button ID="BTNCANCELAR" Text="Cancelar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnCancel_Click" />
                </div>
            </div>
            <div class="col-md-6">
                <asp:GridView ID="TABLESTUDENTS" OnRowCommand="TABLESTUDENTS_RowCommand" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging" AllowPaging="True">
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
                        <asp:BoundField DataField="st_birth_date" HeaderText="Fecha Nacimiento" />
                        <asp:BoundField DataField="doc" HeaderText="Documento" />
                        <asp:BoundField DataField="degree" HeaderText="Grado Cursado" />
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%#Eval("id_student") %>' ID="editStudent" ToolTip="Editar" runat="server" CommandName="editDegree" Text='<i class="fa fa-edit" style="color:white"></i>' />
                                <asp:LinkButton CommandArgument='<%#Eval("id_student") %>' ID="changeDegree" Visible='<%#ShowButton(Eval("degree").ToString()) %>' ToolTip="Cambiar Grado y Sección" runat="server" CommandName="changeDegree" Text='<i class="fa fa-list-numeric" style="color:white"></i>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        <div id="ModalDisplayed" class="modal-subtle no-displayed">
            <div class="modal-subtle-content">
                <div class="modal-subtle-header">
                    <h5>Alumno: <%=nameStuendent %></h5>
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
                    <asp:Button ID="btnConfirmar" Text="Si" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnConfirmar_Click" runat="server" />
                    <asp:Button ID="btnDenegar" Text="No" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnDenegar_Click" runat="server" />
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ClienteEjecutaScript" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        </div>
</asp:Content>
