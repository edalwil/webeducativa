<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionPeriodos.aspx.cs" Inherits="WebFormEducative.Adminview.GestionPeriodos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="offset-md-3 col-md-6">
            <div class="position-center">
                <asp:Button ID="btnAddPeriodo" Text="Registrar" CssClass="btn-subtle btn-color-especial btn-hover-especial" runat="server" OnClick="btnAddCourse_Click" />
            </div>
            <asp:GridView ID="TABLESTUDENTS" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagerTest" OnRowCommand="TABLESTUDENTS_RowCommand" AutoGenerateColumns="false" CssClass="table-subtle" runat="server" OnPageIndexChanging="TABLESTUDENTS_PageIndexChanging" AllowPaging="true">
                <Columns>
                    <asp:BoundField DataField="pe_init" HeaderText="Inicio" />
                    <asp:BoundField DataField="pe_close" HeaderText="Cierre" />
                    <asp:BoundField DataField="pe_year" HeaderText="Año" />
                    <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:LinkButton CommandArgument='<%#Eval("id_period")+","+Eval("pe_year") %>' Visible='<%#int.Parse(Eval("pe_state").ToString())==1 %>' ID="culminatePeriod" ToolTip="Culminar periodo" runat="server" CommandName="culminatePeriod" Text='<i class="fa fa-times-circle" style="color:white"></i>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
    <div id="ModalDisplayed" class="modal-subtle no-displayed">
        <div class="modal-subtle-content">
            <div class="modal-subtle-header">
                <h5>Periodo para finalizar: <%= PeriodoSelected %> º</h5>
            </div>
            <div class="modal-subtle-body">
                <h5>¿Esta seguro que desea finalizar el periodo?</h5>
            </div>
            <div class="modal-subtle-footer position-rigth" style="justify-content: space-between">
                <asp:Button ID="btnConfirmar" Text="Si" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="Confirmar" runat="server" />
                <asp:Button ID="btnDenegar" Text="No" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="Denied" runat="server" />
            </div>
        </div>
    </div>
    <div id="ModalDisplayedforMonthDivider" class="modal-subtle no-displayed">
        <div class="modal-subtle-content" style="width:600px;margin:5% auto;">
            <div class="modal-subtle-header">
                <h5>Número de notas</h5>
            </div>
            <div class="modal-subtle-body">
                
                <div class="group-form-label">
                    <label class="" for="seccion">Cantidad</label>
                    <asp:TextBox runat="server" ID="Numeronotas" CssClass="form-control" />
                </div>
            </div>
            <p>El numero de notas que se ingrese se tomara como referencia para la cantidad de notas en base al proceso de evaluación de este periodo</p>
            <img src="/assets/img/Example.png" alt="Ejemplo" style="width:350px;height:250px" />
            <div class="modal-subtle-footer position-rigth">
                <asp:Button ID="btnconfirmarProceso" Text="Iniciar" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnconfirmarProceso_Click" runat="server" />
                <asp:Button ID="btnCancelarProceso" Text="Cancelar" CssClass="btn-subtle btn-color-especial btn-hover-especial" OnClick="btnCancelarProceso_Click" runat="server" />
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ClienteEjecutaScript" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
</asp:Content>
