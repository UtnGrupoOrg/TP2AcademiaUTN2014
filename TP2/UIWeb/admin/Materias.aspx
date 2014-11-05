<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UIWeb.admin.Materiass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Height="131px">
        <asp:GridView ID="grdMaterias" runat="server">
        </asp:GridView>
        <br />
    </asp:Panel>
    
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnEditar" runat="server">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbtnEliminar" runat="server">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbtnNuevo" runat="server">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Horas Semanales"></asp:Label>
        <asp:TextBox ID="txtHorasSemanales" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Horas Totales"></asp:Label>
        <asp:TextBox ID="txtHorasTotales" runat="server"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnAceptar" runat="server">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="lbtnCancelar" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>
    
</asp:Content>
