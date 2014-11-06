<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UIWeb.admin.Cursos" MasterPageFile="~/Site.Master"%>



<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server"> 
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelGv" runat="server">
                    <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False" CellPadding="4" EnablePersistedSelection="True" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" DataKeyNames="id_curso" OnSelectedIndexChanged="gvCursos_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id_curso" HeaderText="ID Curso" />
                            <asp:BoundField DataField="desc_curso" HeaderText="Curso" />
                            <asp:BoundField DataField="cupo" HeaderText="Cupo" />
                            <asp:BoundField DataField="anio_calendario" HeaderText="Año" />
                            <asp:BoundField DataField="desc_materia" HeaderText="Materia" />
                            <asp:BoundField DataField="desc_comision" HeaderText="Comision" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:Label ID="lblFila" runat="server" Text="Label"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="panelAcciones" runat="server">
                    <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click">Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click">Eliminar</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Text="Debe seleccionar una fila"></asp:Label>
                </asp:Panel>
            <asp:Panel ID="panelAbm" runat="server">
                <br />
                <asp:Label ID="lblDescCurso" runat="server" Text="Desc. Curso: "></asp:Label>
                <asp:TextBox ID="txtDescCurso" runat="server"></asp:TextBox>
                <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
                <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCupo" Display="Dynamic" ErrorMessage="No puede estar vacio."></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblAnio" runat="server" Text="Año Curso: "></asp:Label>
                <asp:TextBox ID="txtAnioCurso" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un año." MaximumValue="2050" MinimumValue="1960" ControlToValidate="txtAnioCurso"></asp:RangeValidator>
                <br />
                <br />
                <asp:Label ID="lblMateria" runat="server" Text="Materia: "></asp:Label>
                <asp:DropDownList ID="ddlMaterias" runat="server" DataSourceID="odsMaterias" DataTextField="Descripcion" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsMaterias" runat="server" SelectMethod="GetAll" TypeName="Data.Database.MateriaAdapter"></asp:ObjectDataSource>
                <br />
                <asp:Label ID="lblComision" runat="server" Text="Comision: "></asp:Label>
                <asp:DropDownList ID="ddlComisiones" runat="server" DataSourceID="odsComisiones" DataTextField="Descripcion" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsComisiones" runat="server" SelectMethod="GetAll" TypeName="Data.Database.ComisionAdapter"></asp:ObjectDataSource>
                <br />
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="Button2_Click" CausesValidation="False" />
                </asp:Panel>
                
                
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server"  ImageUrl="~/Resources/loading.GIF" Height="40px"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>