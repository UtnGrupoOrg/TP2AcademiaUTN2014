﻿<%@ Page Title="Cursos" Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UIWeb.Cursos" %>

<asp:Content ContentPlaceHolderID="PageContent" ID="ContentUsuarios" runat="server">        

    <asp:ScriptManager EnableHistory="true" ID="ScriptManager" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <h1 id="tit" runat="server"> Cursos </h1>


            <asp:Panel ID="gridConteniner"  CssClass="centered" runat="server">
                <asp:Panel ID="gridPanelCursos" runat="server">
                    <asp:GridView ID="gridViewCursos" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="id_curso" OnSelectedIndexChanged="gridViewCursos_SelectedIndexChanged" OnRowCreated="gridViewCursos_RowCreated1">
                        <Columns>
                            <asp:BoundField DataField="id_curso" HeaderText="ID" />
                            <asp:BoundField DataField="desc_materia" HeaderText="Materia" />
                            <asp:BoundField DataField="desc_comision" HeaderText="Comision" />
                            <asp:BoundField DataField="anio_calendario" HeaderText="Año" />
                            <asp:BoundField DataField="cupo" HeaderText="Cupo" />
                        </Columns>
                        <SelectedRowStyle ForeColor="White" CssClass="rowselected" />
                    </asp:GridView>

                </asp:Panel>    
                               
            </asp:Panel>

            <asp:Panel ID="gridPanelInscriptos" CssClass="centered" runat="server">
                <asp:GridView ID="GridViewInscriptos" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="id_inscripcion" runat="server" OnRowCreated="GridViewInscriptos_RowCreated" OnSelectedIndexChanged="GridViewInscriptos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Legajo" DataField="legajo" />
                        <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:BoundField HeaderText="Email" DataField="email" />
                        <asp:BoundField HeaderText="Nota" DataField="nota" NullDisplayText="-" />
                        <asp:BoundField HeaderText="Condicion" DataField="condicion" NullDisplayText="cursando" />
                        <asp:BoundField DataField="id_inscripcion" HeaderText="ID inscripcion" Visible="False" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

            <asp:Panel CssClass="centered" ID="formPanel" runat="server" Visible="false">
                <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>               
                <asp:Label ID="lblCondición" runat="server" Text="Condción: "></asp:Label>
                <asp:DropDownList ID="ddlCondiciones" runat="server">
                    <asp:ListItem Selected="True" Value="regular">Regular</asp:ListItem>
                    <asp:ListItem Value="libre">Libre</asp:ListItem>
                </asp:DropDownList>
        
                    <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbtnAceptar" CssClass="button formbutton" runat="server" Text="Button" CausesValidation="true" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCancelar" CssClass="button formbutton" runat="server" CausesValidation="false" Text="Button" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
        
    

</asp:Content>

