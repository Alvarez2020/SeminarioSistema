<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="SistemaCONNY.Transaccion.Compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .panel input {
            max-width: 100%;
        }
    </style>
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <%--<h3 class="text-center">Compra<i class="far fa-file-alt nav-icon"></i></h3>--%>
                  
                    <p class="card-description">
                        <%-- Add class <code>.table</code>--%>
                    </p>

                    <div class="panel panel-light">
                        <div class="panel-heading">
                            <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Agregar </button>--%>
                            <div class="row">
                                <div class="col col-md-4">
                                      <h3>Realice una Compra <i class="fas fa-cart-arrow-down"></i></h3>
                                    <%--Primera columna--%>
                                    <div class="form-group">
                                        <asp:Label Text="Fecha"  foreColor="#006600" runat="server" />
                                        <i class="fas fa-calendar-alt"></i>
                                        <asp:TextBox Width="100%" ID="txtFecha" runat="server" class="form-control" type="date" placeholder="00/00/0000 "></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <input type="hidden" style="display: none" id="txtIdProducto" />
                                            <asp:TextBox type="text" runat="server" CssClass="form-control" Enabled="false"
                                                ID="txtProducto" placeholder="Producto/Marca" aria-describedby="basic-addon1">

                                            </asp:TextBox>
                                            <div class="input-group-append">
                                                <button type="button" data-toggle="modal" data-target="#myModal" id="btnAgregarArticulo" class="btn btn-primary"><i class="fas fa-mouse-pointer"></i></button>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label Text="Ingrese Cantidad"  foreColor="#006600" runat="server" />
                                     ;
                                        <asp:TextBox ID="txtCantidad" runat="server" class="form-control" type="number" placeholder="Cantidad" Width="100%"></asp:TextBox>
                                    </div>


                                    <div class="form-group">
                                        <asp:Label Text="Precio Compra"  foreColor="#006600" runat="server" />
                                        <i class="fas fa-money-check-alt"></i>
                                        <asp:TextBox ID="txtPrecioCompra" runat="server" class="form-control " type="number" placeholder="C$" Width="100%"></asp:TextBox>
                                    </div>

                                </div>
                                <%-- fin Primera columna--%>

                                <div class=" col col-md-3 mx-5">
                                    <%--Segunda columna--%>
                                    <div class="form-group">
                                        <asp:Label Text="Precio Venta"  foreColor="#006600" runat="server" />
                                        <i class="fas fa-money-check-alt"></i>
                                        <asp:TextBox ID="txtPrecioVenta" runat="server" class="form-control" type="number" placeholder="C$" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <input type="text" hidden style="display: none" id="txtIdProveedor" />
                                            <asp:Label Text="Seleccione Seleccione Proveedor"  foreColor="#006600" runat="server" />
                                            <i class="fas fa-hand-holding-usd"></i>
                                            <asp:TextBox type="text" Width="70%" Height="40" runat="server" class="form-control"
                                                disabled="disabled" ID="txtProveedor" placeholder="Producto/proveedor" aria-describedby="btnAgregarArticulo2">
                                            </asp:TextBox>
                                            <button type="button" data-toggle="modal" data-target="#myModal1" id="btnAgregarArticulo2" class="btn btn-primary" style="height: 40px;"><i class="fas fa-mouse-pointer"></i></button>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="input-group"> 
                                            <input type="text" hidden style="display: none" id="txtIdUnidadMedida" />
                                            <asp:Label Text="Seleccione Unidad-Compra"  foreColor="#006600" runat="server" />
                                            <i class="fas fa-hand-holding-usd"></i>
                                            <asp:TextBox type="text" Width="70%" Height="40" runat="server" class="form-control"
                                                disabled="disabled" ID="txtUmDescripcion" placeholder="Unidad/Medida" aria-describedby="btnAgregarArticulo3">
                                            </asp:TextBox>
                                            <button type="button" data-toggle="modal" data-target="#myModal2" id="btnAgregarArticulo3" class="btn btn-primary" style="height: 40px;"><i class="fas fa-mouse-pointer"></i></button>
                                        </div>

                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <input type="text" hidden style="display: none" id="txtIdUnidadEnvase" />
                                              <asp:Label Text="Seleccione Contenido-Envase"  foreColor="#006600" runat="server" />
                                            <i class="fas fa-hand-holding-usd"></i>
                                            <asp:TextBox type="text" Width="70%" Height="40" runat="server" class="form-control"
                                                disabled="disabled" ID="txtDescripcionUnidadEnvase" placeholder="Unidad/Envase" aria-describedby="btnAgregarArticulo4">
                                            </asp:TextBox>
                                            <button type="button" data-toggle="modal" data-target="#myModal3" id="btnAgregarArticulo4" class="btn btn-primary" style="height: 40px;"><i class="fas fa-mouse-pointer"></i></button>
                                        </div>
                                    </div>
                                </div>
                                <%--Fin segunda columna--%>

                                <div class=" col col-md-4">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha Elaboracion"  foreColor="#006600" runat="server" />
                                        <i class="fas fa-calendar-alt"></i>
                                        <asp:TextBox ID="txtFechaElaboracion" runat="server" class="form-control" type="date" placeholder="00/00/0000" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label Text="Fecha Vencimiento"   foreColor="#006600" runat="server" />
                                        <i class="fas fa-calendar-alt"></i>
                                        <asp:TextBox ID="txtFechaVencimiento" runat="server" class="form-control" type="date" placeholder="00/00/0000" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label Text="Bodega"  foreColor="#006600" runat="server" />
                                        <i class="fas fa-box-open"></i>
                                        <asp:DropDownList ID="dropBodega" runat="server"
                                            class="form-control" type="text" Width="80%">
                                            <asp:ListItem Value="0"> ("Seleccione una Bodega") </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>


                                    <a onclick="AgregarTempPro(this);" class="btn btn-success" href="#">Agregar Producto <i class="fas fa-cart-plus"></i></a>

                                </div>



                                <%--<a ID="btnAgregar" onclick="AgregarTemp(this);"  class="btn btn-success" >Agregar</a>--%>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <hr />
                                </div>
                                <div class="col-md-12">
                                    <table id="gridData" class="table table-striped table-bordered" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th>idProducto</th>
                                                 <th>idProducto</th>
                                                <th>Producto / Marca</th>
                                                <th>idProveedor</th>
                                                <th>Proveedor / Encargado</th>
                                                <th>Cantidad</th>
                                                <th>Unidades</th>
                                                <th>FechaElaboracion</th>
                                                <th>FechaVencimiento</th>
                                                <th>Precio/Unit</th>
                                                <th>PrecioVenta</th>
                                                <th>Importe</th>
                                                <th text-align: center">opciones</th>
                                            </tr>
                                        </thead>

                                    </table>
                                    <div class="form-group">
                                        <asp:Label Text="total " foreColor="#006600" runat="server" />
                                        <asp:TextBox ID="txtTotal" width="15%" runat="server"  class="form-control" type="number" placeholder="C$"></asp:TextBox>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <asp:Label Text="Cantidad Pago"  foreColor="#006600" runat="server" />
                                                <asp:TextBox ID="txtCantidadPago" width="15%" OnTextChanged="txtCantidadPago_TextChanged" AutoPostBack="true" runat="server" class="form-control txtCantidadPago" type="number" placeholder="C$"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" ControlToValidate="txtCantidadPago" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo es necesario" />
                                            
                                            </div>
                                            <div class="form-group">
                                                <asp:Label Text="Cambio" foreColor="#006600" runat="server" />
                                                <asp:TextBox ID="txtCambio" width="15%" runat="server" class="form-control" type="text" placeholder="Cambio"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <asp:Button ID="GuardarTransac" ValidationGroup="valGuardar" runat="server" class="btn btn-success" Text="GuardarRegistro " OnClick="GuardarTransac_Click" />


                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- modal seleccionar articulos --%>
    <div class="modal fade mbModal" id="myModal" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="proveedor">Seleccionar Producto <i class="fas fa-hand-point-down"></i></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table id="modalproducto" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Producto</th>
                                <th>Descripcion</th>
                                <th>Marca</th>
                                <th>Seleccionar</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar <i class="fas fa-window-close"></i></button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>

    <!-- fin modal seleccion articulo -->
    <div class="modal fade mbModalProv" id="myModal1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="proveedo">Seleccionar Proveedor</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table id="modalproveedor" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Proveedor</th>
                                <th>Encargado</th>
                                <th>Seleccionar</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-light" data-dismiss="modal">Cerrar <i class="fas fa-window-close"></i></button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- modal seleccionar articulos --%>
    <div class="modal fade mbModalunidad" id="myModal2" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="unidad">Seleccionar Unidad Medida</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table id="modalunidad" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>UmDescripcion</th>
                                <th>Unidades</th>
                                <th>Seleccionar</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar <i class="fas fa-window-close"></i></button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade mbModalunidadenvase" id="myModal3" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="unidadenvase">Seleccionar Unidad Envase</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table id="modalunidadenvase" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>DescripcionUnidadEnvase</th>
                                <th>Seleccionar</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar <i class="fas fa-window-close"></i></button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script> 
        LoadProd();
        var dataServer1, tablePro1;
        function LoadProd() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("../CatalogosSistema/Productos.aspx/CargarProducto") %>",
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
                            { "data": 'IdProducto' },
                            { "data": 'NombreProducto' },
                            { "data": 'DescripcionProducto' },
                            { "data": 'NombreMarca' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": false,
                                "searchable": false
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

        LoadProv();
        var dataServer2, tablePro2;
        function LoadProv() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("../CatalogosSistema/Proveedor.aspx/CargarDatos") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        dataServer2 = JSON.parse(item);
                    });
                    tablePro2 = $('#modalproveedor').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer2,
                        "responsive": true,
                        "columns": [
                            { "data": 'IdProveedor' },
                            { "data": 'NombreProveedor' },
                            { "data": 'Encargado' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": true,
                                "searchable": false
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

        Loadunidad();
        var dataServer3, tablePro3;
        function Loadunidad() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("../CatalogosSistema/Unidad_Medida.aspx/CargarDatos") %>",
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
                            { "data": 'IdUnidadMedida' },
                            { "data": 'UmDescripcion' },
                            { "data": 'Unidades' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": true,
                                "searchable": false
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
        LoadProv();
        var dataServer2, tablePro2;
        function LoadProv() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("../CatalogosSistema/Proveedor.aspx/CargarDatos") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        dataServer2 = JSON.parse(item);
                    });
                    tablePro2 = $('#modalproveedor').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer2,
                        "responsive": true,
                        "columns": [
                            { "data": 'IdProveedor' },
                            { "data": 'NombreProveedor' },
                            { "data": 'Encargado' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": true,
                                "searchable": false
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

        Loadunidadenvase();
        var dataServer4, tablePro4;
        function Loadunidadenvase() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("../CatalogosSistema/UNIDAD_ENVASE.aspx/CargarDatos") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        dataServer4 = JSON.parse(item);
                    });
                    tablePro4 = $('#modalunidadenvase').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer4,
                        "responsive": true,
                        "columns": [
                            { "data": 'IdUnidadEnvase' },
                            { "data": 'DescripcionEnvaseUnidad' },
                            { "data": "opcion" }
                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": true,
                                "searchable": false
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


        function AgregarTempPro() {
            //e.preventDefault();
            var cant = parseInt($('#<%=txtCantidad.ClientID %>').val());
            var precio = parseFloat($('#<%=txtPrecioCompra.ClientID %>').val());

            if ($('#<%=txtCantidad.ClientID %>').val() == "") {
                swal("Advertencia!", "Cantidad debe ser mayor a 0", "warning")
                return;
            }
            var ID_PRODUCTO = parseInt($('#txtIdProducto').val());
            if ($('#txtIdProducto').val() == "") {
                swal("Advertencia!", "Seleccione un producto", "warning")
                return;
            }
            var ID_UNIDAD_MEDIDA = parseInt($('#txtIdUnidadMedida').val());
            if ($('#txtIdUnidadMedida').val() == "") {
                swal("Advertencia!", "Seleccione unidad", "warning")
                return;
            }
            if ($('#<%=txtFechaElaboracion.ClientID %>').val() == "") {
                swal("Advertencia!", "Seleccione una fecha", "warning")
                return;
            }
            if ($('#<%=txtFechaVencimiento.ClientID %>').val() == "") {
                swal("Advertencia!", "Seleccione una fecha", "warning")
                return;
            }
            var ID_UNIDAD_ENVASE = parseInt($('#txtIdUnidadEnvase').val());
            if ($('#txtIdUnidadEnvase').val() == "") {
                swal("Advertencia!", "Seleccione Contenido", "warning")
                return;
            }
            var data = {
                ID_PRODUCTO: parseInt($('#txtIdProducto').val()),
                NOMBRE_PRODUCTO: $('#<%=txtProducto.ClientID%>').val(),
                ID_PROVEEDOR: parseInt($('#txtIdProveedor').val()),
                NOMBRE_PROVEEDOR: $('#<%=txtProveedor.ClientID%>').val(),
                ID_UNIDAD_MEDIDA: parseInt($('#txtIdUnidadMedida').val()),
                UM_DESCRIPCION: $('#<%=txtUmDescripcion.ClientID%>').val(),
                ID_UNIDAD_ENVASE: parseInt($('#txtIdUnidadEnvase').val()),
                DESCRIPCION_UNIDAD_ENVASE: $('#<%=txtDescripcionUnidadEnvase.ClientID%>').val(),
                ID_COMPRA: 0,
                CANTIDAD_PRODUCTOS: $('#<%=txtCantidad.ClientID %>').val(),
                FECHA_COMPRA: $('#<%=txtFecha.ClientID %>').val(),
                PRECIO_COMPRA: $('#<%=txtPrecioCompra.ClientID %>').val(),
                PRECIO_VENTA: $('#<%=txtPrecioVenta.ClientID %>').val(),
                ID_USUARIO: 1,
                SUBTOTAL: 0,//arseFloat( cant * precio ),
                FECHA_ELABORACION_PRODUCTO: $('#<%=txtFechaElaboracion.ClientID %>').val(),
                FECHA_VENCIMIENTO_PRODUCTO: $('#<%=txtFechaVencimiento.ClientID %>').val(),
                CANTIDAD_EXISTENCIA: 0,
                CANTIDAD_DEVOLUCION: 0,
                ID_BODEGA: $('#<%=dropBodega.ClientID %> ').val(),
                CANTIDAD_PAGO: $('#<%=txtCantidadPago.ClientID %>').val(),
                CAMBIO: 0
            };

            var json = Sys.Serialization.JavaScriptSerializer.serialize(data);
            console.log('Respuesta success ' + json);
            $.ajax({
                type: "POST",
                data: '{temp:' + json + '}',
                url: "<%= ResolveUrl("Compra.aspx/GuardarListaDetalleCompra") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        console.log(item);
                        $('#<%=txtTotal.ClientID%>').val(item);
                    });

                    LoadTemp();

                    console.log('Respuesta success ' + response);
                    swal("Exelente!", "Operacion realizada!", "success")
                },
                failure: function (response) {
                    console.log('Sucedio un error = ' + response);
                }
            });
        }

        var languaje = {
            "info": "Productos _START_ al _END_ de _TOTAL_ Productos",
            "infoEmpty": "Productos 0 al 0 de 0 Productos",
            "zeroRecords": "No se encontro coincidencias",
            "infoFiltered": "(filtrado de _MAX_ Productos en total)",
            "emptyTable": "No hay Productos buscar..",
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
                url: "<%= ResolveUrl("Compra.aspx/CargarDatos") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var subData = 0;
                    var SubtotalGeneral = 0;
                    $.each(response, function (i, item) {
                        dataServer = JSON.parse(item);
                        $.each(dataServer, function (j, items) {

                            subData = items["SUBTOTAL"];

                            SubtotalGeneral = SubtotalGeneral + subData;
                        });


                    });
                    $('#<%=txtTotal.ClientID%>').val(SubtotalGeneral);
                    tablePro = $('#gridData').DataTable({
                        "dataType": "json",
                        "destroy": true,
                        "aaData": dataServer,
                        "responsive": true,
                        "columns": [
                            { "data": 'ID' }, 
                            { "data": 'ID_PRODUCTO' },
                            { "data": 'ID_UNIDAD_MEDIDA' },
                            { "data": 'NOMBRE_PRODUCTO' },
                            { "data": 'ID_PROVEEDOR' },
                            { "data": 'NOMBRE_PROVEEDOR' },
                            { "data": 'CANTIDAD_PRODUCTOS' },
                            { "data": 'UM_DESCRIPCION' },
                            { "data": 'FECHA_ELABORACION_PRODUCTO' },
                            { "data": 'FECHA_VENCIMIENTO_PRODUCTO' },
                            { "data": 'PRECIO_COMPRA' },
                            { "data": 'PRECIO_VENTA' },
                            { "data": 'SUBTOTAL' },
                            { "data": 'opcion' }

                        ],
                        "columnDefs": [
                            {
                                "targets": [0],
                                "visible": true,
                                "searchable": false
                            },
                            {
                                "targets": [1,,2, 4,5],
                                "visible": false,
                                "searchable": false
                            },
                            {
                                "targets": [8], render: function (data) {
                                    return moment(data).format('DD/MM/YYYY');
                                }
                            },
                            {
                                "targets": -1,
                                "data": null,
                                "className": "text-center",
                                "defaultContent": " <a href='#' class='eliminar' id='btnEliminar'><i class='fas fa-trash'></i></a>"
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
        $("input").on("click", function () {
            $("#log").html($("input:checked").val() + " is checked!");
        });


        $(".txtCantidadPago").change(function () {
            var camb = parseFloat($('#<%=txtCantidadPago.ClientID%>').val());
            var tot = parseFloat($('#<%=txtTotal.ClientID%>').val());

            var vuelto = camb - tot;   //txtCambio

            $('#<%=txtCambio.ClientID%>').val(vuelto);

        });




        //EliminarProbando);
        $('#gridData').on('click', '#btnEliminar', function (e) {
            var data_form = tablePro.row($(this).parents("tr")).data();
            var id = data_form.ID;
            var isConfirm;
            console.log("id " + id);
            var json = Sys.Serialization.JavaScriptSerializer.serialize(id);
            //this.preventDefault();
            e.preventDefault();
            swal({
                title: "Desea eliminar el elemento?",
                text: "Selecciona una accion",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Confirmar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: false,
                closeOnCancel: false
            },
                function (isConfirm) {
                    if (isConfirm) {
                        $.ajax({
                            type: "POST",
                            data: '{codigo:' + json + '}',
                            url: "<%= ResolveUrl("Compra.aspx/EliminarDetalle") %>",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                LoadTemp();
                                $('#<%=txtCantidadPago.ClientID%>').val('');
                                $('#<%=txtCambio.ClientID%>').val('');
                                swal("Deleted!", "Your item deleted.", "success");
                            },
                            failure: function (response) {
                                swal("Error!", "Dependencia de datos.", "warning");
                            }
                        });
                    } else {
                        swal("Cancelado", "Operacion cancelada", "error");
                    }
                });
        });



        $(document).ready(function () {
            $('#modalproducto').on('click', 'tr', function () {
                var p = tablePro1.row(this).data();
                var idproducto = p.IdProducto;
                var producto = 'Producto:' + p.NombreProducto + '  /  ' + 'Marca:' + p.NombreMarca;

                $('#txtIdProducto').val(idproducto);
                $('#<%=txtProducto.ClientID%>').val(producto);

                $('#myModal').modal('hide');
            });

            //$('#btnAgregarArticulo').on('click', function () {
            //    console.log("dany dañoo el modal")
            //    $('.mbModal').modal('show');
            // });

        });

        $(document).ready(function () {
            $('#modalproveedor').on('click', 'tr', function () {
                var p = tablePro2.row(this).data();
                var idProveedor = p.IdProveedor;
                var encargado = 'Proveedor:' + p.NombreProveedor + '  /  ' + 'Encargado:' + p.Encargado;

                $('#txtIdProveedor').val(idProveedor);
                $('#<%=txtProveedor.ClientID%>').val(encargado);

                $('#myModal1').modal('hide');
            });

            //$('#btnAgregarArticulo').on('click', function () {
            //    console.log("dany dañoo el modal")
            //    $('.mbModal').modal('show');
            // });

        });
        $(document).ready(function () {
            $('#modalunidad').on('click', 'tr', function () {
                var p = tablePro3.row(this).data();
                var idUnidadMedida = p.IdUnidadMedida;
                var unidades = 'Contenido:' + p.UmDescripcion + '  /  ' + 'UND:' + p.Unidades;

                $('#txtIdUnidadMedida').val(idUnidadMedida);
                $('#<%=txtUmDescripcion.ClientID%>').val(unidades);

                $('#myModal2').modal('hide');
            });

            //$('#btnAgregarArticulo').on('click', function () {
            //    console.log("dany dañoo el modal")
            //    $('.mbModal').modal('show');
            // });

        });
        $(document).ready(function () {
            $('#modalunidadenvase').on('click', 'tr', function () {
                var p = tablePro4.row(this).data();
                var idUnidadEnvase = p.IdUnidadEnvase;
                var DescripcionEnvase = p.DescripcionEnvaseUnidad;

                $('#txtIdUnidadEnvase').val(idUnidadEnvase);
                $('#<%=txtDescripcionUnidadEnvase.ClientID%>').val(DescripcionEnvase);

                $('#myModal3').modal('hide');
            });

            //$('#btnAgregarArticulo').on('click', function () {
            //    console.log("dany dañoo el modal")
            //    $('.mbModal').modal('show');
            // });

        });
        quitarClases();
        document.getElementById("Compra").classList.add("active-page");
        document.getElementById("nav-compra").classList.add("active-page");
    </script>
</asp:Content>

