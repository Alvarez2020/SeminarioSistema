<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoricoVenta.aspx.cs" Inherits="SistemaCONNY.HistoricoYExistencia.HistoricoVenta" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @media (min-width: 992px) {
            .modal-lg {
                max-width: 1000px !important;
            }
        }
    </style>


    <div class="row">
        <div class="col-sm-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h3></h3>
                    <p class="card-description">
                        <%-- Add class <code>.table</code>--%>
                    </p>
                    <div class="panel panel-light">
                        <%--div class="panel-heading">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Agregar </button>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>----%>
                        <div class=" justify-content-center">
                            <div class="center">
                                <br />
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <input type="text" hidden style="display: none" id="txtIdUnidadMedida" />
                                            <asp:TextBox type="text" Width="300px" Height="40" runat="server" class="form-control"
                                                disabled="disabled" ID="txtUmDescripcion" placeholder="Registro №Facturas">
                                            </asp:TextBox>
                                        </div>
                                        <button type="button" data-toggle="modal" data-target="#myModal2" id="btnAgregarArticulo3" class="btn btn-primary">...</button>
                                    </div>
                                </div>
                                <div class="center">
                                    <asp:Button type="button" OnClick="btnFactura1_Click" ValidationGroup="valGuardar" ID="btnFactura" runat="server" Text="Factura" CssClass="btn btn-success" />
                                    <asp:TextBox type="text" Width="100px" Height="40" runat="server" class="form-control"
                                        ID="txtCod1" placeholder="№FACTURA"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" ControlToValidate="txtCod1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo es necesario" />
                                </div>

                            </div>
                        </div>
                        <br />
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <input type="text" hidden style="display: none" id="txtIdProducto" />
                                    <asp:TextBox type="text" Width="300px" Height="40" runat="server" class="form-control"
                                        disabled="disabled" ID="txtProducto" placeholder="Registro Compras">
                                    </asp:TextBox>
                                </div>
                                <button type="button" data-toggle="modal" data-target="#myModal" id="btnAgregarArticulo" class="btn btn-primary">...</button>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="">
                            <%-- <table id="gridData" class="table table-striped table-bordered" style="width: 100%">
                                <thead>
                                    <tr>
                                      <th style="width: 15%">ID_Compra</th>
                                       
                                        <th>FechaCompra</th>
                                        <th style="width: 15%; text-align: center">Opciones</th>
                                    </tr>
                                </thead>
                            </table>--%>
                            <div style="height: 100%; width: 100%;" class="col-sm-5 w-100">

                                <rsweb:ReportViewer ID="ReportViewer1" Width="1125px" AsyncRendering="true" CssClass="justify-content-center"
                                    DocumentMapWidth="100%" Height="500px" runat="server">
                                </rsweb:ReportViewer>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
    <%--modal--%>

    <div class="modal fade mbModalunidad" id="myModal2" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">

            <div class="modal-content" style="width: 800px;">
                <div class="modal-header">
                    <h5 class="modal-title" id="unidad">Seleccionar Producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <%--<span aria-hidden="true">&times;</span>--%>
                    </button>
                    <div class="center">


                        <asp:Button type="button" OnClick="btnCompra_Click" ID="Button1" runat="server" Text="Factura" CssClass="btn btn-success" />

                    </div>
                </div>
                <div class="modal-body">
                    <table id="modalunidad" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th style="width: 15%">ID_FACTURA</th>
                                <th>CANTIDAD_PRODUCTO</th>
                                <th>FechaFactura</th>


                                <th style="width: 15%; text-align: center">Opciones</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade mbModal" id="myModal" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">


            <div class="modal-content w-100">
                <div class="modal-header">
                    <h5 class="modal-title" id="proveedor">Seleccionar Producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <%--    <span aria-hidden="true">&times;</span>--%>
                    </button>
                    <div class="center">


                        <asp:Button type="button" OnClick="btnRegistroCompra_Click" ID="Button2" runat="server" Text="Factura" CssClass="btn btn-success" />

                    </div>
                </div>
                <div class="modal-body">
                    <table id="modalproducto" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>IdC</th>
                                <th>IdP</th>
                                <th>IdM</th>
                                <th>Producto</th>
                                <th>Marca</th>
                                <th>contenido</th>
                                <th>Cantidad</th>
                                <th>Precio</th>
                                <th>sub</th>
                                <th>total</th>
                                <th>cantidadPago</th>
                                <th>cambio</th>
                                <th>Fecha</th>
                                <%--  <th>Seleccionar</th>--%>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script>    
        var globalDataEdicion;

        //function mensajeToast() {
        //    toastr.success('Operacion realizada', 'Éxito');
        //}
        //function hideModal() {
        //    $("#myModal").modal("hide");
        //}
        var languaje = {
            "info": "Registro _START_ a _END_ de _TOTAL_ registros",
            "infoEmpty": "Registro 0 a 0 de 0 registros",
            "zeroRecords": "No se encontro coincidencias",
            "infoFiltered": "(filtrado de _MAX_ registros en total)",
            "emptyTable": "No hay registros buscar..",
            "lengthMenu": '_MENU_ ',
            "search": 'Buscar:',
            //"loadingRecords": "Buscando...",
            "processing": "Procesando datos...",
            "paginate": {
                "first": "Primera",
                "last": "Última ",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        };

        LoadTemp();
        var dataServer, tablePro;
        function LoadTemp() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("HistoricoVenta.aspx/CargarDatos") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        dataServer = JSON.parse(item);
                    });
                    tablePro = $('#gridData').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer,
                        "responsive": true,
                        "columns": [
                            { "data": 'ID_FACTURA' },
                            //{ "data": 'ID_MARCA' },
                            //{ "data": 'ID_UNIDAD_MEDIDA' },
                            //{ "data": 'NOMBRE_PRODUCTO' },
                            //{ "data": 'NOMBRE_MARCA' },
                            { "data": 'CANTIDAD_PRODUCTO' },
                            //{ "data": 'UM_DESCRIPCION' },
                            //{ "data": 'UNIDADES' },
                            //{ "data": 'PRECIO_COMPRA' },
                            //{ "data": 'TOTAL' },
                            { "data": 'FECHA_FACTURA' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [

                            {
                                "targets": [2], render: function (data) {
                                    return moment(data).format('DD/MM/YYYY');
                                }
                            },

                            {
                                "targets": -1,
                                "data": null,
                                "className": "text-center",
                                "defaultContent": "<a href='#' data-toggle='modal' data-target='#myModal' id='btnEditar'><i class='fas fa-edit'></i></a> | <a href='#' class='eliminar' id='btnEliminar'><i class='fas fa-trash'></i></a>"
                            }
                        ],
                        "language": languaje
                    });
                },
                failure: function (response) {
                   <%-- //$('#<%=Label1.ClientID%>').val("Error in calling Ajax:" + response.d);--%>
                }
            });
            //$('#mdSeleccionArticulo').modal('show');
        }
        Loadunidad();
        var dataServer3, tablePro3;
        function Loadunidad() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("HistoricoVenta.aspx/CargarDatos") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        dataServer3 = JSON.parse(item);
                    });
                    tablePro3 = $('#modalunidad').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer3,
                        "responsive": true,
                        "columns": [
                            { "data": 'ID_FACTURA' },
                            //{ "data": 'ID_MARCA' },
                            //{ "data": 'ID_UNIDAD_MEDIDA' },
                            //{ "data": 'NOMBRE_PRODUCTO' },
                            //{ "data": 'NOMBRE_MARCA' },
                            { "data": 'CANTIDAD_PRODUCTO' },
                            //{ "data": 'UM_DESCRIPCION' },
                            //{ "data": 'UNIDADES' },
                            //{ "data": 'PRECIO_COMPRA' },
                            //{ "data": 'TOTAL' },
                            { "data": 'FECHA_FACTURA' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [

                            {
                                "targets": [2], render: function (data) {
                                    return moment(data).format('DD/MM/YYYY');
                                }
                            },
                            {
                                "targets": -1,
                                "data": null,
                                "className": "text-center",
                                "defaultContent": "<a href='#' class='seleccionar' id='btnseleccionar'><i class='fas fa-edit'></i></a>"
                            }
                        ],
                        "language": languaje
                    });
                },
                failure: function (response) {
                   <%-- //$('#<%=Label1.ClientID%>').val("Error in calling Ajax:" + response.d);--%>
                }
            });
            //$('#mdSeleccionArticulo').modal('show');
        }

        LoadProd();
        var dataServer1, tablePro1;
        function LoadProd() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("HistoricoVenta.aspx/CargarDatos1") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        dataServer1 = JSON.parse(item);
                    });
                    tablePro1 = $('#modalproducto').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer1,
                        "responsive": true,
                        "columns": [
                            { "data": 'ID_FACTURA' },
                            { "data": 'ID_EXISTENCIA' },
                            { "data": 'ID_MARCA' },
                            { "data": 'NOMBRE_PRODUCTO' },
                            { "data": 'NOMBRE_MARCA' },
                            { "data": 'DESCRIPCION_ENVASE_UNIDAD' },
                            { "data": 'CANTIDAD_PRODUCTO' },
                            { "data": 'PRECIO_UNIT' },
                            { "data": 'SUB_TOTAL' },
                            { "data": 'TOTAL' },
                            { "data": 'CANTIDAD_PAGO' },
                            { "data": 'CAMBIO' },
                            { "data": 'FECHA_FACTURA' },


                            //{ "data": "opcion" }
                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": true,
                                "searchable": false
                            },
                            {
                                "targets": [1, 2],
                                "visible": false,
                                "searchable": false
                            },
                            {
                                "targets": [12], render: function (data) {
                                    return moment(data).format('DD/MM/YYYY');
                                }
                            },
                            //{
                            //    "targets": -1,
                            //    "data": null,
                            //    "className": "text-center",
                            //    "defaultContent": "<a href='#' class='seleccionar' id='btnseleccionar'><i class='fas fa-edit'></i></a>"
                            //}
                        ],
                        "language": languaje
                    });
                },
                failure: function (response) {
                   <%-- //$('#<%=Label1.ClientID%>').val("Error in calling Ajax:" + response.d);--%>
                }
            });
            //$('#mdSeleccionArticulo').modal('show');
        }




        $(document).ready(function () {
            $('#modalunidad').on('click', 'tr', function () {
                var p = tablePro3.row(this).data();
                var idUnidadMedida = p.ID_FACTURA;
                var PRE = p.ID_FACTURA;
                var unidades = p.UmDescripcion;

                $('#txtIdUnidadMedida').val(idUnidadMedida);
                $('#<%=txtUmDescripcion.ClientID%>').val(unidades);
                $('#<%=txtCod1.ClientID%>').val(PRE);

                $('#myModal2').modal('hide');
            });

            //$('#btnAgregarArticulo').on('click', function () {
            //    console.log("dany dañoo el modal")
            //    $('.mbModal').modal('show');
            // });

        });


        quitarClases();
        document.getElementById("HistoricoVenta").classList.add("active-page");
        document.getElementById("nav-venta").classList.add("active-page");
    </script>
</asp:Content>
