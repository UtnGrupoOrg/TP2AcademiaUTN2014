<%@ Page Title="Cuenta" Language="C#" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.Cuenta" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server">        

    <script src="../Resources/scripts.js"></script> 
    <asp:ScriptManager EnableHistory="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="headtit">  
        <h1 > Cuenta </h1> 
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
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
                        <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                        <asp:TextBox ID="txtLegajo" Enabled="false" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLegajo" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtLegajo" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>                     
                        <asp:RegularExpressionValidator CssClass="error" ID="valLegajo" runat="server" ControlToValidate="txtLegajo" Display="dynamic" ErrorMessage="Debe ingresar sólo numeros" ValidationExpression="\d+" />
                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>  
                        <asp:RequiredFieldValidator ID="rfvTelefono" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtTelefono" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="error" ID="valTelefono" runat="server" ControlToValidate="txtTelefono" Display="dynamic" ErrorMessage="Debe ingresar sólo numeros" ValidationExpression="\d+" />
                        <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
                        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="rfvDireccion" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtDireccion" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>  
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                        <asp:TextBox ID="txtDia" MaxLength="2" CssClass="fecha" placeholder="Dia" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtMes" MaxLength="2" CssClass="fecha" placeholder="Mes" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtAnio" MaxLength="4" CssClass="fecha" placeholder="Año" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="cvFecha" CssClass="error" ValidateEmptyText="true" ControlToValidate="txtDia" Display="dynamic" OnServerValidate="validateDate" Text="El formato de la fecha es incorrecta" runat="server" /><asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
                        <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvClave"  CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtClave" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
                        <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>                
                        <asp:CompareValidator ID="cvClave" CssClass="error" runat="server" Text="Las contraseñas no coinciden." Display="dynamic" ControlToValidate="txtClave" ControlToCompare="txtRepetirClave" ErrorMessage="CompareValidator"></asp:CompareValidator>
                        <asp:RegularExpressionValidator CssClass="error" ID="valPassword" runat="server"
                                                       ControlToValidate="txtClave"
                                                       Display="dynamic"
                                                       ErrorMessage="La clave tiene que ser de por lo menos 8 caracteres"
                                                       ValidationExpression=".{8}.*" />            
                    
                <asp:Panel ID="formActionsPanel" runat="server">
                     <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Guardar</asp:LinkButton> 
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
        
    

</asp:Content>

