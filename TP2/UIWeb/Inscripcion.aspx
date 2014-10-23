<%@ Page Title="Inscripcion" Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.Inscripcion" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentInscripcion" runat="server">    
    <asp:Panel ID="gridPanelMaterias" runat="server">
        <asp:GridView ID="gridViewMaterias" runat="server" OnSelectedIndexChanged="gridViewMaterias_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="descripcion" HeaderText="Nombre" />
                <asp:BoundField DataField="hssemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="hstotales" HeaderText="Horas Totales" />
                <asp:CommandField SelectText="Inscribirse" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>


