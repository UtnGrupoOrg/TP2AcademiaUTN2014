<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportePersonasxEspecialidad.aspx.cs" Inherits="UIWeb.admin.ReportePersonasxEspecialidad" %>

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
            <LocalReport ReportPath="Reporting\Reportes\ReportePersonasxEspecialidad.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsPersonasxEspecialidad" Name="personasxEspecialidad" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsPersonasxEspecialidad" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="UIWeb.Reporting.DataSet.dsReportesTableAdapters.personasxEspecialidadTableAdapter"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
