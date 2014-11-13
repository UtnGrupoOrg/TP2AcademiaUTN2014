<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UIWeb.admin.Planes" %>

<asp:Content ID="ContentPlanes" ContentPlaceHolderID="PageContent" runat="server">
    <script src="../Resources/scripts.js"></script> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="headtit">  
        <h1 > Planes </h1> 
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
                    <asp:GridView ID="gridView" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="id_plan" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowCreated="gridView_RowCreated1">
                        
                        <Columns>
                            <asp:BoundField DataField="desc_plan" HeaderText="Plan" />
                            <asp:BoundField DataField="desc_especialidad" HeaderText="Especialidad de Plan" />
                        </Columns>
                        
                        <SelectedRowStyle ForeColor="White" CssClass="rowselected" />
                    </asp:GridView>
                    
                </asp:Panel>      
                <asp:Label ID="lblMensaje" runat="server" Text="Debe seleccionar una fila"></asp:Label>
                <asp:Panel ID="gridActionsPanel" runat="server">
                    
                    <asp:LinkButton ID="lbtnNuevo" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnNuevo_Click" >Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEditar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEditar_Click" >Editar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEliminar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEliminar_Click" >Eliminar</asp:LinkButton>                    
                    
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="centered" ID="formPanel" runat="server" Visible="false">
                
                <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
        
                    <asp:TextBox ID="txtPlan" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" display="Dynamic" runat="server" CssClass="error" ControlToValidate="txtPlan" ErrorMessage="El plan no puede estar vacio."></asp:RequiredFieldValidator>
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad del Plan: "></asp:Label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" DataSourceID="odsEspecialidad" DataTextField="Descripcion" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsEspecialidad" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.EspecialidadLogic"></asp:ObjectDataSource>
        
                    <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
