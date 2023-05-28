<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionGrados.aspx.cs" Inherits="WebFormEducative.Adminview.GestionGrados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 px-5">
            <div class="group-form-label">
                <label for="de_description">
                    Número de grado</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="de_description" />
            </div>
            <div class="position-center">
                <asp:Button ID="BTNREGISTRAR" Text="Registrar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnAddDegree_Click" />
                <asp:Button ID="BTNEDITAR" Text="Editar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnEdit_Click" />
                <asp:Button ID="BTNCANCELAR" Text="Cancelar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnCancel_Click" />
            </div>
        </div>
        <div class="col-md-6">
            <asp:GridView ID="TABLESTUDENTS" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" OnRowCommand="TABLESTUDENTS_RowCommand" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging" AllowPaging="true">
                <Columns>
                    <asp:BoundField DataField="id_degrees" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Grados">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# 
                                        Eval("de_description").ToString()+
                                        " º" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sections" HeaderText="Secciones" />
                    <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:LinkButton CommandArgument='<%#Eval("id_degrees") %>' ID="addSection" ToolTip="Añadir Sección" runat="server" CommandName="addSection" Text='<i class="fa fa-circle-plus" style="color:white"></i>' />
                            <asp:LinkButton CommandArgument='<%#Eval("id_degrees") %>' ID="editDegree" ToolTip="Editar" runat="server" CommandName="editDegree" Text='<i class="fa fa-edit" style="color:white"></i>' />
                            <asp:LinkButton CommandArgument='<%#Eval("id_degrees") %>' ID="changeDegree" Visible='<%#ShowButton(Eval("sections").ToString()) %>' ToolTip="Editar Secciones" runat="server" CommandName="changeDegree" Text='<i class="fa fa-list-numeric" style="color:white"></i>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="ModalDisplayed" class="modal-subtle no-displayed">
        <div class="modal-subtle-content">
            <div class="modal-subtle-header">
                <h5>Grado <%= DegreeSelected %> º</h5>
            </div>
            <div class="modal-subtle-body">
                <div class="group-form-label">
                    <label class="" for="seccion">Sección</label>
                    <asp:TextBox runat="server" ID="seccion" CssClass="form-control" />
                </div>
            </div>
            <div class="modal-subtle-footer position-rigth">
                <asp:Button ID="BtnAddSection" Text="Añadir" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="addSection" runat="server" />
            </div>
        </div>
    </div>
    <div id="ModalDisplayedforEditSection" class="modal-subtle no-displayed">
        <div class="modal-subtle-content">
            <div class="modal-subtle-header">
                <h5>Grado: <%=DegreeSelected %></h5>
            </div>
            <div class="modal-subtle-body">
                <label for="SectionEdit">Sección</label>
                <asp:DropDownList CssClass="form-control" ID="SectionEdit" runat="server">
                </asp:DropDownList>
                <label class="" for="Nomenclatura">Sigla nueva</label>
                <asp:TextBox runat="server" ID="Nomenclatura" CssClass="form-control" />
            </div>
            <div class="modal-subtle-footer position-rigth" style="justify-content: space-between">
                <asp:Button ID="btnConfirmar" Text="Si" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnConfirmar_Click" runat="server" />
                <asp:Button ID="btnDenegar" Text="No" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnDenegar_Click" runat="server" />
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ClienteEjecutaScript" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
</asp:Content>
