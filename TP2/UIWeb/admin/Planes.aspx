<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UIWeb.admin.Planes" %>

<asp:Content ID="ContentPlanes" ContentPlaceHolderID="PageContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <h1> Planes </h1>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlan" ErrorMessage="El plan no puede estar vacio."></asp:RequiredFieldValidator>
                <br />
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
