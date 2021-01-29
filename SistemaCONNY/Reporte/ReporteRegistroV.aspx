<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="ReporteRegistroV.aspx.cs" Inherits="SistemaCONNY.Reporte.ReporteRegistroV" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager runat="server"></asp:ScriptManager>

        <div>
            <div class="row center justify-content-center">
                <div style="height: 100%; width: 100%;" class="col-sm-8">

                    <%--<rsweb:reportviewer id="ReportViewer1" width="825px" asyncrendering="true" cssclass="justify-content-center"
                        documentmapwidth="100%" height="500px" runat="server">
                        <rsweb:ReportViewer runat="server"></rsweb:ReportViewer>--%>
                    <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="500px" Width="825px" CssClass="justify-content-center" DocumentMapWidth="100%"></rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

