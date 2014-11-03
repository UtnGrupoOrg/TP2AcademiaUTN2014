<%@ Page Title="Usuarios" Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.Usuarios" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server">          

        
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>

    </asp:Panel>      

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnEditar" runat="server" Text="Button" OnClick="lbtnEditar_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="lbtnEliminar" runat="server" Text="Button" OnClick="lbtnEliminar_Click" >Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbtnNuevo" runat="server" Text="Button" OnClick="lbtnNuevo_Click" >Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" runat="server" Visible="false">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtNombre" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvApellido" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtApellido" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="cvEmail" ValidateEmptyText="true" ControlToValidate="txtEmail" Display="dynamic" OnServerValidate="validateEmail" Text="El formato del email debe ser usuario@proveedor.algo" runat="server" />
        <br />
        <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="ckxHabilitado" runat="server" />
        <br />
        <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombreUsuario" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtNombreUsuario" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvClave"  Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtClave" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="cvClave" runat="server" Text="Las contraseñas no coinciden. Intenta nuevamente." Display="dynamic" ControlToValidate="txtClave" ControlToCompare="txtRepetirClave" ErrorMessage="CompareValidator"></asp:CompareValidator>
        <br />       
        
        
         <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="lbtnAceptar" runat="server" Text="Button" CausesValidation="false" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lbtnCancelar" runat="server" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>

    

</asp:Content>
