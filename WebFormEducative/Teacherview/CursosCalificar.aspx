<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="CursosCalificar.aspx.cs" Inherits="WebFormEducative.Teacherview.CursosCalificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mx-5 mt-5">
            <div class="col-md-3">
                <label for="Grados">Curso</label>
                <asp:DropDownList ID="Grados" AutoPostBack="true" OnSelectedIndexChanged="Grados_SelectedIndexChanged" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-md-9">
                <asp:GridView ID="TABLESTUDENTS" OnRowDataBound="TABLESTUDENTS_RowDataBound" OnRowCommand="TABLESTUDENTS_RowCommand" AutoGenerateColumns="true" CssClass="table-subtle" runat="server"/>
            </div>
        </div>
</asp:Content>
