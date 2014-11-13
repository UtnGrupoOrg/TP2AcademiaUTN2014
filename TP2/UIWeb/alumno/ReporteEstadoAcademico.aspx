<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteEstadoAcademico.aspx.cs" Inherits="UIWeb.alumno.ReporteEstadoAcademico" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Reporting\Reportes\ReporteEstadoAcademico.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsEstadoAcademico" Name="estadoAcademico" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsEstadoAcademico" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="UIWeb.Reporting.DataSet.dsReportesTableAdapters.estadoAcademicoTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="idAlumno" SessionField="idAlumno" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
