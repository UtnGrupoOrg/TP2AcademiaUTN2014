<%@ Page Title="Especialidades" Language="C#" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.admin.Especialidades" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentEspecialidades" runat="server">        

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <h1> Especialidades </h1>
            <asp:Panel ID="gridConteniner"  CssClass="centered" runat="server">
                <asp:Panel ID="gridPanel" runat="server">
                    <asp:GridView ID="gridView" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowCreated="gridView_RowCreated1">
                        <Columns>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                           
                        </Columns>
                        <SelectedRowStyle ForeColor="White" CssClass="rowselected" />
                    </asp:GridView>

                </asp:Panel>      

                <asp:Panel ID="gridActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnNuevo" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnNuevo_Click" >Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEditar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEditar_Click" >Editar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEliminar" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnEliminar_Click" >Eliminar</asp:LinkButton>                    
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="centered" ID="formPanel" runat="server" Visible="false">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" CssClass="error" Display="Dynamic" ErrorMessage="RequiredFieldValidator">Debes completar este campo</asp:RequiredFieldValidator>
                <br />
                    <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
        
    

</asp:Content>
