<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaCONNY._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="top-bar clearfix">
        <div class="container-fluid">
            <div class="row gutter">
                <div class="col-md-8 col-sm-6 col-xs-12">
                    <h1 class="page-title">MISCELANEA CONNY 1.0</h1>
                </div>
            </div>
        </div>
    </div>
            <div id="carouselControls" class="carousel slide mt-3 carousel-fade" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="PlantillaStyle/img/imgs1.jpg" class="d-block w-100" alt="Primer Slide">
                </div>
                <div class="carousel-item">
                    <img src="PlantillaStyle/img/imgs2.jpg" class="d-block w-100" alt="Segundo Slide">
                </div>
                <div class="carousel-item">
                    <img src="PlantillaStyle/img/imgs3.jpg" class="d-block w-100" alt="Tercer Slide">
                </div>
                <div class="carousel-item">
                    <img src="PlantillaStyle/img/imgs4.jpg" class="d-block w-100" alt="Cuarto Slide">
                </div>
            </div>
            <a href="#carouselControls" class="carousel-control-prev" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Anterior</span>
            </a>
            <a href="#carouselControls" class="carousel-control-next" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Siguiente</span>
            </a>
        </div>

</asp:Content>
