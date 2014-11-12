<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UIWeb.admin.Comisiones" %>
<asp:Content ID="ContentComisiones" ContentPlaceHolderID="PageContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel" runat="server" OnLoad="UpdatePanel_Load">
        <ContentTemplate>
            <h1> Comisiones </h1>
            <asp:Panel ID="gridConteniner"  CssClass="centered" runat="server">
                <asp:Panel ID="gridPanel" runat="server">
                    <asp:GridView ID="gridView" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="id_comision" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowCreated="gridView_RowCreated1">
                        
                        <Columns>
                            <asp:BoundField DataField="id_comision" HeaderText="ID" />
                            <asp:BoundField DataField="desc_comision" HeaderText="Comision" />
                            <asp:BoundField DataField="desc_plan" HeaderText="Plan" />
                            <asp:BoundField DataField="anio_especialidad" HeaderText="Año" />
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
                
                <asp:Label ID="lblAnioEspecialidad" runat="server" Text="Año Especialidad"></asp:Label>
                <asp:DropDownList ID="ddlAnioCalendario" runat="server">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="Fechas" runat="server"></asp:ObjectDataSource>
                <br />
                <asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label>
                <asp:DropDownList ID="ddlPlanes" runat="server" DataSourceID="odsPlanes" DataTextField="Descripcion">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
                <br />
                <asp:TextBox ID="txtDescripcion" runat="server" Height="61px" Width="161px" TextMode="MultiLine" ToolTip="Descripcion de la comision"></asp:TextBox>
                <br />
        
                    <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

