<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Master.aspx.cs" Inherits="SistemaCONNY.Reporte.Master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div>
            <div class="row center justify-content-center">
                <div style="height: 100%; width: 100%;" class="col-sm-8">
                    <%--<rsweb:ReportViewer ID="ReportViewer1" Width="825px" Height="500px" runat="server" DocumentMapWidth="100%" AsyncRendering="true">
                    </rsweb:ReportViewer>--%>

                    <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                    </rsweb:ReportViewer>

                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
