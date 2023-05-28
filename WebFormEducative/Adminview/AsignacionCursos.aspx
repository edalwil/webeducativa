<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AsignacionCursos.aspx.cs" Inherits="WebFormEducative.Adminview.AsignacionCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-3">
                <label for="Curso">Curso</label>
                <asp:DropDownList CssClass="form-control" ID="Curso" runat="server">
                </asp:DropDownList>
                <label for="Grado">Grado</label>
                    <asp:DropDownList AutoPostBack="True" OnSelectedIndexChanged="Grado_SelectedIndexChanged" CssClass="form-control" ID="Grado" runat="server">
                    </asp:DropDownList>
                    <label for="Seccion">Sección</label>
                    <asp:DropDownList CssClass="form-control" ID="Seccion" runat="server">
                    </asp:DropDownList>
                <div class="position-center">
                    <asp:Button ID="BtnAddSection" Text="Añadir" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnAddCourse_Click" runat="server" />
                </div>
            </div>
            <div class="col-md-9">
                <h5 class="position-center">Cursos del profesor: <%=fullName %></h5>
                <asp:GridView ID="TABLESTUDENTS" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" OnRowCommand="TABLESTUDENTS_RowCommand" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging" AllowPaging="true">
                    <Columns>
                        <asp:BoundField DataField="co_description" HeaderText="Cursos Asignados" />
                        <asp:BoundField DataField="de_description" HeaderText="Grado" />
                        <asp:BoundField DataField="se_description" HeaderText="Sección" />
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%#Eval("id_course")+","+Eval("id_degree")+","+Eval("id_section")%>' ID="deteleCourseforTeacher" ToolTip="Eliminar Curso" runat="server" CommandName="deteleCourseforTeacher" Text='<i class="fa fa-times-circle" style="color:white"></i>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="ModalDisplayed" class="modal-subtle no-displayed">
            <div class="modal-subtle-content">
                <div class="modal-subtle-header">
                    <h5>Eliminar asignación de este curso</h5>
                </div>
                <div class="modal-subtle-body">
                    <h5>¿Estas seguro que deseas eliminar?</h5>
                </div>
                <div class="modal-subtle-footer position-rigth" style="justify-content: space-between">
                    <asp:Button ID="btnConfirmar" Text="Si" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnConfirmar_Click" runat="server" />
                    <asp:Button ID="btnDenegar" Text="No" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnDenegar_Click" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>
