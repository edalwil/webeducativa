<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormEducative.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-login">
        <h1 class="position-center">SIGMA</h1>
        <div class="group-form-subtle">
            <asp:TextBox ID="txtUserMaster" runat="server" type="text" CssClass="input-subtle input-color-especial" />
            <span><i class="fa fa-user-circle"></i></span>
        </div>
        <div class="group-form-subtle">
            <asp:TextBox ID="txtUserMasterPass" runat="server" CssClass="input-subtle input-color-especial" type="password" />
            <span><i class="fa fa-lock"></i></span>
        </div>
        <div class="center">
            <asp:Button Text="iniciar" CssClass="btn-subtle btn-color-especial" OnClick="LoginUserMaster" runat="server" />
        </div>
    </div>
</asp:Content>
