<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UIWeb.alumno.EstadoAcademico" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <script src="../Resources/scripts.js"></script> 
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <div id="headtit">  
        <h1 > Estado Academico </h1> 
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
                <asp:Panel ID="gridContainer" runat="server" CssClass="centered">
                    <asp:GridView ID="grdEstadoAcadamico" runat="server" AutoGenerateColumns="False" DataKeyNames="id_alumno" Width="201px">
                        <Columns>
                            <asp:BoundField DataField="materia" HeaderText="Materia" />
                            <asp:BoundField DataField="condicion" HeaderText="Condicion" NullDisplayText="Cursando" />
                            <asp:BoundField DataField="nota" HeaderText="Nota" NullDisplayText="No posee" />
                            <asp:BoundField DataField="anio_calendario" HeaderText="Año" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="lbtnAtras" runat="server" CssClass="button formbutton" OnClick="lbtnAtras_Click">Atras</asp:LinkButton>
                </asp:Panel>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
