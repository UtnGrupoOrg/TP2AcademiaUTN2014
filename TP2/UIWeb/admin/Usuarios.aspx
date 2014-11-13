<%@ Page Title="Usuarios" Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.Usuarios" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server">        
    <script src="../Resources/scripts.js"></script> 
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div id="headtit">  
        <h1 > Usuarios </h1> 
        <asp:UpdateProgress ID="upLoading" runat="server" >
                <ProgressTemplate>
                    <asp:Image ID="Image1" CssClass="loading" runat="server" ImageUrl="~/Resources/loading2.GIF"/>
                </ProgressTemplate>
            </asp:UpdateProgress>  
     </div>   
     <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Panel visible="false" ID="ErrorBox" CssClass="Box" runat="server">
                <asp:Label ID="ErrorText" runat="server" ></asp:Label>
                <img runat="server" src="../Resources/close-button.png" class="Close" onclick="CloseError_Click()"/>       
            </asp:Panel>
            <asp:Panel visible="false" ID="MessageBox" CssClass="Box" runat="server">
                <asp:Label ID="MessageText" runat="server" ></asp:Label>
                <img runat="server" src="../Resources/close-button.png" class="Close" onclick="CloseError_Click()"/>       
            </asp:Panel>    
            <asp:Panel ID="gridConteniner"  CssClass="centered" runat="server">
                <asp:Panel ID="gridPanel" runat="server">
                    <asp:GridView ID="gridView" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowCreated="gridView_RowCreated1">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                        </Columns>
                        <SelectedRowStyle CssClass="rowselected" />
                    </asp:GridView>

                </asp:Panel>      
                
                <asp:Panel ID="gridActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnNuevo" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnNuevo_Click" >Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEditar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEditar_Click" >Editar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEliminar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEliminar_Click" >Eliminar</asp:LinkButton>                    
                </asp:Panel>
                <asp:Panel ID="gridPersonasPanel" runat="server">
                    <asp:GridView ID="gridPersonas" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridPersonas_SelectedIndexChanged" OnRowCreated="gridPersonas_RowCreated1">
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="legajo" HeaderText="Legajo" />
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:BoundField DataField="fechanacimiento" HeaderText="Fecha de Nacimiento" />
                        </Columns>
                        <SelectedRowStyle CssClass="rowselected" />
                    </asp:GridView>
                </asp:Panel>      
            </asp:Panel>
            <asp:Panel CssClass="centered" ID="formPanel" runat="server" Visible="false">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtNombre" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtApellido" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cvEmail" CssClass="error" ValidateEmptyText="true" ControlToValidate="txtEmail" Display="dynamic" OnServerValidate="validateEmail" Text="El formato del email debe ser usuario@proveedor.algo" runat="server" />
                <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
                <asp:CheckBox ID="ckxHabilitado" runat="server" />                
                <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombreUsuario" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtNombreUsuario" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
                <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClave"  CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtClave" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
                <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRepetirClave"  CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtRepetirClave" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvClave" CssClass="error" runat="server" Text="Las contraseñas no coinciden." Display="dynamic" ControlToValidate="txtClave" ControlToCompare="txtRepetirClave" ErrorMessage="CompareValidator"></asp:CompareValidator>
                <asp:RegularExpressionValidator CssClass="error" ID="valPassword" runat="server"
                                               ControlToValidate="txtClave"
                                               Display="dynamic"
                                               ErrorMessage="La clave tiene que ser de por lo menos 8 caracteres"
                                               ValidationExpression=".{8}.*" />  
                <asp:Label ID="lblPersona" runat="server" Text="Persona: "></asp:Label>    
                <asp:TextBox ID="txtPersona" readonly="true" runat="server"></asp:TextBox>
                <asp:LinkButton ID="lbtnAgregarPersona" CausesValidation="false" CssClass="button formbutton" runat="server" OnClick="lbtnAgregarPersona_Click">Agregar</asp:LinkButton>
                <asp:CustomValidator ID="cvPersona" CssClass="error" ValidateEmptyText="true" ControlToValidate="txtPersona" Display="dynamic" OnServerValidate="validatePersona" Text="Se debe agregar una persona" runat="server" /> 
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
        
    

</asp:Content>
