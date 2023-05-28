<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionCursos.aspx.cs" Inherits="WebFormEducative.Adminview.GestionCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row">
            <div class="col-md-6 px-5">
                <div class="group-form-label">
                    <label for="co_description">
                        Nombre del Curso</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="co_description" />
                </div>
                <div class="position-center">
                    <asp:Button ID="BTNREGISTRAR" Text="Registrar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnAddCourse_Click" />
                    <asp:Button ID="BTNEDITAR" Text="Editar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnEdit_Click" />
                    <asp:Button ID="BTNCANCELAR" Text="Cancelar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnCancel_Click" />
                </div>
            </div>
            <div class="col-md-6">
                <asp:GridView ID="TABLESTUDENTS" OnRowCommand="TABLESTUDENTS_RowCommand" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging" AllowPaging="true">
                    <Columns>
                        <asp:BoundField DataField="id_course" HeaderText="ID" />
                        <asp:BoundField DataField="co_description" HeaderText="Nombre del curso" />
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%#Eval("id_course") %>' ID="editDegree" ToolTip="Editar" runat="server" CommandName="editDegree" Text='<i class="fa fa-edit" style="color:white"></i>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
