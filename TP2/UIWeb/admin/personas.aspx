<%@ Page Title="Personas" Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="UIWeb.admin.Personas" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentPersonas" runat="server">        

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <h1> Personas </h1>
            <asp:Panel ID="gridConteniner"  CssClass="centered" runat="server">
                <asp:Panel ID="gridPanel" runat="server">
                    <asp:GridView ID="gridView" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="id_persona" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowCreated="gridView_RowCreated1">
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="legajo" HeaderText="Legajo" />
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" />
                            <asp:BoundField DataField="id_plan" HeaderText="id_plan" Visible="False" />
                            <asp:BoundField DataField="desc_plan" HeaderText="Plan" Visible="False"/>
                        </Columns>
                        <SelectedRowStyle CssClass="rowselected" />
                    </asp:GridView>
                </asp:Panel>      

                <asp:Panel ID="gridActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnNuevo" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnNuevo_Click" >Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEditar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEditar_Click" >Editar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnInscribir" Visible="false" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnInscribir_Click" >Inscribir</asp:LinkButton>   
                    <asp:LinkButton ID="lbtnEliminar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEliminar_Click" >Eliminar</asp:LinkButton>                                     
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="centered" ID="formPanel" runat="server" Visible="false">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtNombre" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtApellido" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegajo" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtLegajo" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>                     
                <asp:RegularExpressionValidator CssClass="error" ID="valLegajo" runat="server" ControlToValidate="txtLegajo" Display="dynamic" ErrorMessage="Debe ingresar sólo numeros" ValidationExpression="\d+" />
                <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="rfvTelefono" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtTelefono" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="error" ID="valTelefono" runat="server" ControlToValidate="txtTelefono" Display="dynamic" ErrorMessage="Debe ingresar sólo numeros" ValidationExpression="\d+" />
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="rfvDireccion" CssClass="error" Text="Debes completar este campo" Display="dynamic" ControlToValidate="txtDireccion" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>  
                <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cvEmail" CssClass="error" ValidateEmptyText="true" ControlToValidate="txtEmail" Display="dynamic" OnServerValidate="validateEmail" Text="El formato del email debe ser usuario@proveedor.algo" runat="server" />
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                <asp:TextBox ID="txtDia" MaxLength="2" CssClass="fecha" placeholder="Dia" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtMes" MaxLength="2" CssClass="fecha" placeholder="Mes" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtAnio" MaxLength="4" CssClass="fecha" placeholder="Año" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cvFecha" CssClass="error" ValidateEmptyText="true" ControlToValidate="txtDia" Display="dynamic" OnServerValidate="validateDate" Text="El formato de la fecha es incorrecta" runat="server" />
                <asp:Label ID="lblPlan" Visible="false" runat="server" Text="Plan: "></asp:Label>
                <asp:DropDownList ID="ddlPlan" Visible="false" runat="server" DataSourceID="odsPlanes" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
        
    

</asp:Content>

