<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="VentasAgru.aspx.cs" Inherits="SistemaCONNY.Reporte.VentasAgru" %>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div class="row center justify-content-center">
            
                <div style="height: 100%; width: 100%;" class="col-sm-5 w-100">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="1125px" Height="700px" runat="server" DocumentMapWidth="100%" AsyncRendering="true">
                    </rsweb:ReportViewer>
                </div>
            </div>
               
        </div>
    </form>
</body>
</html>
