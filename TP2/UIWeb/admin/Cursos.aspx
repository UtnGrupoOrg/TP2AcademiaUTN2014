<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UIWeb.admin.Cursos" MasterPageFile="~/Site.Master"%>



<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server"> 
    <div>
        <h1>Cursos</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelGv"  CssClass="centered" runat="server">
                    <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False" EnablePersistedSelection="True" AutoGenerateSelectButton="True" DataKeyNames="id_curso" OnSelectedIndexChanged="gvCursos_SelectedIndexChanged" OnRowCreated="gvCursos_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="id_curso" HeaderText="ID Curso" />
                            <asp:BoundField DataField="cupo" HeaderText="Cupo"/>
                            <asp:BoundField DataField="anio_calendario" HeaderText="Año" />
                            <asp:BoundField DataField="desc_materia" HeaderText="Materia" />
                            <asp:BoundField DataField="desc_comision" HeaderText="Comision" />
                        </Columns>
                        <SelectedRowStyle ForeColor="White" CssClass="rowselected" />
                    </asp:GridView>
                    <asp:Panel ID="gridActionsPanel" runat="server">
                        <asp:LinkButton ID="lbNuevo" runat="server" CssClass="button formbutton" OnClick="lbNuevo_Click">Nuevo</asp:LinkButton>
                        <asp:LinkButton ID="lbEditar" runat="server" CssClass="button formbutton" OnClick="lbEditar_Click">Editar</asp:LinkButton>
                        <asp:LinkButton ID="lbtnEliminar" runat="server" CssClass="button formbutton" OnClick="lbEliminar_Click">Eliminar</asp:LinkButton>
                        
                        <asp:Label ID="lblMensaje" runat="server" Text="Debe seleccionar una fila"></asp:Label>
                    </asp:Panel>
                </asp:Panel>
            <asp:Panel ID="formPanel" CssClass="centered" runat="server">
                
                <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
                <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCupo" Display="Dynamic" ErrorMessage="No puede estar vacio."></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblAnio" runat="server" Text="Año Curso: "></asp:Label>
                <asp:TextBox ID="txtAnioCurso" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un año." MaximumValue="2050" MinimumValue="1960" ControlToValidate="txtAnioCurso"></asp:RangeValidator>
                <asp:Label ID="lblMateria" runat="server" Text="Materia: "></asp:Label>
                <asp:DropDownList ID="ddlMaterias" runat="server" DataSourceID="odsMaterias" DataTextField="Descripcion" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsMaterias" runat="server" SelectMethod="GetAll" TypeName="Data.Database.MateriaAdapter"></asp:ObjectDataSource>

                <asp:Label ID="lblComision" runat="server" Text="Comision: "></asp:Label>
                <asp:DropDownList ID="ddlComisiones" runat="server" DataSourceID="odsComisiones" DataTextField="Descripcion" DataValueField="ID">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsComisiones" runat="server" SelectMethod="GetAll" TypeName="Data.Database.ComisionAdapter"></asp:ObjectDataSource>
                
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
                </asp:Panel>
                
                
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="upLoading" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" CssClass="centered"  ImageUrl="~/Resources/loading.GIF" Height="30px"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>