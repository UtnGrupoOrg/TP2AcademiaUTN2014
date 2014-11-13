<%@ Page Title="Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UIWeb.admin.Materiass" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <script src="../Resources/scripts.js"></script> 
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div id="headtit">  
        <h1 > Materias </h1> 
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
            <asp:Panel ID="gridContainer" runat="server"  CssClass="centered">
                <asp:Panel ID="gridPanel" runat="server" >
                    <asp:GridView ID="grdMaterias" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="id_materia" OnRowCreated="grdMaterias_RowCreated" OnSelectedIndexChanged="grdMaterias_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="desc_materia" HeaderText="Descripcion" />
                            <asp:BoundField DataField="hs_semanales" HeaderText="Horas Semanales" />
                            <asp:BoundField DataField="hs_totales" HeaderText="Horas Totales" />
                            <asp:BoundField DataField="desc_plan" HeaderText="Plan" />
                        </Columns>
                        <SelectedRowStyle CssClass="rowselected" />
                    </asp:GridView>
                    <br />
                </asp:Panel>
    
                <asp:Panel ID="gridActionsPanel" runat="server" >
                    <asp:LinkButton ID="lbtnNuevo" runat="server" CssClass="button formbutton" OnClick="lbtnNuevo_Click1">Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click1" CssClass="button formbutton">Editar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click1" CssClass="button formbutton">Eliminar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="formPanel" runat="server" CssClass="centered">
                <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Plan"></asp:Label>
                <asp:DropDownList ID="ddlPlan" runat="server" DataSourceID="odsPlan" DataTextField="Descripcion">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsPlan" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Horas Semanales"></asp:Label>
                <asp:TextBox ID="txtHorasSemanales" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Horas Totales"></asp:Label>
                <asp:TextBox ID="txtHorasTotales" runat="server"></asp:TextBox>
                <asp:Panel ID="formActionsPanel" runat="server" >
                    <asp:LinkButton ID="lbtnAceptar" runat="server" CssClass="button formbutton" OnClick="lbtnAceptar_Click1">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass="button formbutton" OnClick="lbtnCancelar_Click1">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
