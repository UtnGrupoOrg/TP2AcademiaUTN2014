<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UIWeb.alumno.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
 <div id="headtit">
        <h1 > Estado Academico </h1>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:Panel ID="gridContainer" runat="server" CssClass="centered">
                    <asp:GridView ID="grdEstadoAcadamico" runat="server" AutoGenerateColumns="False" DataKeyNames="id_alumno" Width="201px">
                        <Columns>
                            <asp:BoundField DataField="materia" HeaderText="Materia" />
                            <asp:BoundField DataField="condicion" HeaderText="Condicion" />
                            <asp:BoundField DataField="nota" HeaderText="Nota" />
                            <asp:BoundField DataField="anio_calendario" HeaderText="Año" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="lbtnAtras" runat="server" CssClass="button formbutton" OnClick="lbtnAtras_Click">Atras</asp:LinkButton>
                </asp:Panel>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>    
    </div>         

</asp:Content>
