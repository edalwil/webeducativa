<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionProfesores.aspx.cs" Inherits="WebFormEducative.Adminview.GestionProfesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
            <div class="col-md-6 px-5">
                <div class="group-form-label">
                    <label for="firstname">
                        Primer Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="firstname" />
                    <%--<asp:TextBox runat="server" CssClass="input-subtle" ID="firstname" />
                    <label class="text-place-holder" for="firstname">
                        Primer Nombre</label>--%>
                </div>
                <div class="group-form-label">
                    <label for="secondname">
                        Segundo Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="secondname" />
                    <%--<asp:TextBox runat="server" CssClass="input-subtle" ID="secondname" />
                    <label class="text-place-holder" for="secondname">
                        Segundo Nombre</label>--%>
                </div>
                <div class="group-form-label">
                    <label  for="surname">
                        Apellido Paterno</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="surname" />
                    <%--<asp:TextBox runat="server" CssClass="input-subtle" ID="surname" />
                    <label class="text-place-holder" for="surname">
                        Apellido Paterno</label>--%>
                </div>
                <div class="group-form-label">
                    <label for="secondsurname">
                        Apellido Materno</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="secondsurname" />
                    <%--<asp:TextBox runat="server" CssClass="input-subtle" ID="secondsurname" />
                    <label class="text-place-holder" for="secondsurname">
                        Apellido Materno</label>--%>
                </div>
                <div class="group-form-label">
                    <label for="contrasena">
                        Contraseña</label>
                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="contrasena" />
                    <%--<asp:TextBox runat="server" type="password" CssClass="input-subtle" ID="contrasena" />
                    <label class="text-place-holder" for="contrasena">
                        Contraseña</label>--%>
                </div>
                <label for="birthdate">Fecha Nacimiento</label>
                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="birthdate" />
                <div class="group-form-label">
                    <label for="doc">
                        Documento Identidad</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="doc" />
                    <%--<asp:TextBox runat="server" CssClass="input-subtle" ID="doc" />
                    <label class="text-place-holder" for="doc">
                        Documento Identidad</label>--%>
                </div>
                <div class="position-center">
                    <asp:Button ID="BTNREGISTRAR" Text="Registrar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btn_RegistrarMaestro" />
                    <asp:Button ID="BTNEDITAR" Text="Editar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnEdit_Click" />
                    <asp:Button ID="BTNCANCELAR" Text="Cancelar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnCancel_Click" />
                </div>
            </div>
            <div class="col-md-6">
                <asp:GridView ID="TABLESTUDENTS" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" OnRowCommand="TABLESTUDENTS_RowCommand" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="id_teacher" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# 
                                        Eval("te_first_name").ToString()+
                                        Eval("te_surname").ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre Completo">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# 
                                        Eval("te_first_name").ToString()+" "+
                                        Eval("te_second_name").ToString()+" "+
                                        Eval("te_surname").ToString()+" "+
                                        Eval("te_second_surname").ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="te_birth_date" HeaderText="Fecha Nacimiento" />
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%#Eval("id_teacher") %>' ID="addCourse" ToolTip="Asignar Cursos" runat="server" CommandName="addCourse" Text='<i class="fa fa-book" style="color:white"></i>' />
                                <asp:LinkButton CommandArgument='<%#Eval("id_teacher") %>' ID="editTeacher" ToolTip="Editar" runat="server" CommandName="editTeacher" Text='<i class="fa fa-edit" style="color:white"></i>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
</asp:Content>
