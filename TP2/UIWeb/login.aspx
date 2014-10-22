﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UIWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academia - Ingreso</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="loginPanel" runat="server">
            <p class="inputContainer">
                <asp:Label ID="lblUsuario" CssClass="lblLogin" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="txtUsuario" CssClass="txtLogin" runat="server"></asp:TextBox>
            </p>
            <br />
            <p class="inputContainer">
                <asp:Label ID="lblClave" CssClass="lblLogin" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="txtClave" CssClass="txtLogin" runat="server"></asp:TextBox>
            </p>
            <br />
                <asp:LinkButton ID="lnkOlvideClave" runat="server" Text="Olvide mi contraseña"></asp:LinkButton>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"></asp:Button>
            <br />
            <asp:Label ID="respuesta" runat="server" Text=""></asp:Label>
        </asp:Panel>

    </div>
    </form>
</body>
</html>