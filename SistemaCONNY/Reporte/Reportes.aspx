<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs"
    Inherits="SistemaCONNY.Reporte.Factura" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row center justify-content-center">
        <div class="col-sm-8 justify-content-center">  
            <div class="center">
                <asp:Button type="button" OnClick="btnVenta_Click" ID="btnVenta" runat="server" Text="Historico venta" CssClass="btn btn-primary" />
                 <asp:Button type="button" OnClick="btnCompra_Click" ID="btnCompra" runat="server" Text="Historico Compra"  CssClass="btn btn-secondary"/>
                 <asp:Button type="button" OnClick="btnExis_Click" ID="btnExis" runat="server" Text="Existencia"  CssClass="btn btn-success"/>
                            <asp:Button type="button" OnClick="btnFactura_Click" ID="btnFactura" runat="server" Text="Factura"  CssClass="btn btn-success"/>
                <asp:TextBox ID="txtCod" runat="server"></asp:TextBox>
                </div>
            <br />
        </div>
        <div style="height: 100%; width: 100%;" class="col-sm-8">
 
                <rsweb:ReportViewer ID="ReportViewer1" Width="1000px" AsyncRendering="true" CssClass="justify-content-center" 
                    DocumentMapWidth="100%" Height="500px" runat="server">
                   
                </rsweb:ReportViewer>
            
        </div>
    </div>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script>  
        quitarClases();
        document.getElementById("Reportes").classList.add("active-page");
        document.getElementById("nav-Reportes").classList.add("active-page");
    </script>
</asp:Content>
