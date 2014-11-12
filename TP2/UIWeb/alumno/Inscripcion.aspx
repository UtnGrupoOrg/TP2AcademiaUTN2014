<%@ Page Title="Inscripcion" Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.Inscripcion" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server">        
    <script>
        function CloseError_Click() {
            var div = document.getElementById('PageContent_ErrorBox');
            if (div) {
                div.parentNode.removeChild(div);
            }
            var div = document.getElementById('PageContent_MessageBox');
            if (div) {
                div.parentNode.removeChild(div);
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div id="headtit">
        <h1 > Inscripción a Materias </h1>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel visible="false" ID="ErrorBox" CssClass="Box" runat="server">
                    <asp:Label ID="ErrorText" runat="server" ></asp:Label>
                    <img runat="server" src="../Resources/close-button.png" class="Close" onclick="CloseError_Click()"/>       
                </asp:Panel>
                <asp:Panel visible="false" ID="MessageBox" CssClass="Box" runat="server">
                    <asp:Label ID="MessageText" runat="server" ></asp:Label>
                    <img runat="server" src="../Resources/close-button.png" class="Close" onclick="CloseError_Click()"/>       
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>    
    </div>    
    <asp:Panel ID="gridConteniner"  CssClass="centered" runat="server">
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <h2 id="subtit" runat="server" visible="false"> Comisiones </h2>
                <asp:Panel ID="gridMateriasPanel" runat="server">
                    <asp:GridView ID="gridMaterias" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridMaterias_SelectedIndexChanged" OnRowCreated="gridMaterias_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" /> 
                            <asp:BoundField DataField="HSsemanales" HeaderText="Horas Semanales" />
                            <asp:BoundField DataField="Hstotales" HeaderText="Horas Totales" />                           
                        </Columns>
                        <SelectedRowStyle CssClass="rowselected" />
                    </asp:GridView>

                </asp:Panel>
                <asp:Panel ID="gridComisionesPanel" visible="false" runat="server">
                    <asp:GridView ID="gridComisiones" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="id_curso" OnSelectedIndexChanged="gridComisiones_SelectedIndexChanged" OnRowCreated="gridComisiones_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="desc_comision" HeaderText="Descripcion" /> 
                            <asp:BoundField DataField="id_curso"  HeaderText="Curso" Visible="False"/>                           
                        </Columns>
                        <SelectedRowStyle CssClass="rowselected" />
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel> 
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:UpdatePanel ID="UpdatePanelActions" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="lbtnSiguiente" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnSiguiente_Click" >Siguiente</asp:LinkButton>
                    <asp:LinkButton ID="lbtnAtras" Visible="false" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnAtras_Click" >Atras</asp:LinkButton>
                    <asp:LinkButton ID="lbtnInscribirse" Visible="false" CssClass="button formbutton" runat="server" Text="Button" OnClick="lbtnInscribirse_Click" >Inscribirse</asp:LinkButton> 
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="upLoading" runat="server" >
                        <ProgressTemplate>
                            <asp:Image ID="Image1" CssClass="loading" runat="server" ImageUrl="~/Resources/loading2.GIF"/>
                        </ProgressTemplate>
            </asp:UpdateProgress>                                            
         </asp:Panel>
    </asp:Panel> 
</asp:Content>

