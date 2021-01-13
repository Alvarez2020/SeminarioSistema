<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="SistemaCONNY.Transaccion.Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .panel input {
            max-width: 100%;
        }
        .no-visible{
            opacity:0;
        }
        
        @media (min-width: 992px) {
            .modal-lg {
                max-width: 1000px !important;
            }
        }
   
    </style>
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">

                  
                    <p class="card-description">
                        <%-- Add class <code>.table</code>--%>
                    </p>
                    <div class="container ">
                        <div class="row">
                            <div class=" col col-md-5 mx-7">
                                  <h3>Realice una Venta <i class="fas fa-cart-arrow-down"></i></h3>
                                <%--Primera columna--%>
                                <div class="form-group">
                                    <asp:Label Text="Ingrese su nombre" foreColor="#006600" runat="server" />
                                    <i class="fas fa-hand-holding-usd"></i>
                                    <asp:TextBox ID="txtCliente" style="width: 41%" runat="server" class="form-control" type="text" placeholder="NombreCliente"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label Text="Ingrese fecha" foreColor="#006600" runat="server" />
                                    <i class="fas fa-hand-holding-usd"></i>
                                    <asp:TextBox ID="txtFecha" style="width: 41%" runat="server" class="form-control" type="date" placeholder="00/00/0000"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label Text="Ingrese Cantidad a Comprar" foreColor="#006600" runat="server" />
                                    <i class="fas fa-hand-holding-usd"></i>
                                    <asp:TextBox style="width: 41%" Height="2%" ID="txtCantidad" runat="server" class="form-control" type="number" min="1" placeholder="Cantidad"></asp:TextBox>
                                    <label class="col-form-label text-danger no-visible" id="validCantidad">CantidadValida</label>

                                </div>
                                <a onclick="AgregarTempPro(this);" id="btnAgregar" class="btn btn-success" href="#">Agregar Producto <i class="fas fa-cart-plus"></i></a>
                            </div>
                            <%--Fin Primera columna--%>

                            <div class=" col col-md-5 mx-6">
                                <div class="form-group">
                                    <div class="form-inline">

                                        <input type="text" hidden style="display: none" id="txtIdProducto" />
                                        <input type="text" hidden style="display: none" id="txtidExistencia" />
                                        <asp:TextBox type="text" Width="300px" Height="40" runat="server" class="form-control"
                                            disabled="disabled" ID="txtProducto" placeholder="Producto/Marca" aria-describedby="btnAgregarArticulo">
                                        </asp:TextBox>
                                        <button type="button" data-toggle="modal" data-target="#myModal" id="btnAgregarArticulo" class="btn btn-primary" style="height: 40px;">...</button>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <input type="text" hidden style="display: none" id="txtIdUnidadMedida" />
                                            <asp:TextBox type="text" Width="300px" Height="40" runat="server" class="form-control"
                                                disabled="disabled" ID="txtUmDescripcion" placeholder="Unidad/Medida" aria-describedby="btnAgregarArticulo3">
                                            </asp:TextBox>
                                        </div>
                                        <button type="button" data-toggle="modal" data-target="#myModal2" id="btnAgregarArticulo3" class="btn btn-primary" style="height: 40px;">...</button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label Text="Existencia" foreColor="#006600" runat="server" />
                                    <asp:TextBox ID="txtExistencia" style="width: 41%"  runat="server" class="form-control" type="number" placeholder="C$" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label Text="Precio Venta" foreColor="#006600" runat="server" />
                                    <asp:TextBox ID="txtPrecioVenta" style="width: 41%"  runat="server" class="form-control" type="number" placeholder="C$" disabled="disabled" ></asp:TextBox>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="panel panel-light">
                        <div class="panel-heading">
                            <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Agregar </button>--%>
                        </div>



                        <div class="row">
                            <div class="col-md-12">
                                <hr />
                            </div>
                            <div class="col-md-12">
                                <table id="gridData" class="table table-striped table-bordered" style="width: 100%">
                                    <thead>
                                        <tr>
                                            
                                            <th style="width: 5%">Id</th>
                                            <th>Cliente</th>
                                            <%--       <th>idProducto</th>--%>
                                            <%-- <th>Fecha Venta</th>
                                                <th>Cliente</th>--%>
                                            <th>Producto / Marca</th>
                                            <th>Cantidad</th>
                                            <th>Precio Unit</th>
                                            <th>Importe</th>
                                          <th style="width: 5%; text-align: center">opciones</th>
                                        </tr>
                                    </thead>

                                </table>
                                <div class="form-group">
                                    <asp:Label Text="Total" foreColor="#006600" runat="server" />
                                    <asp:TextBox  disabled="disabled" foreColor="#006600" style="width: 15%" Height="2%" ID="txtTotal" runat="server" class="form-control" type="number" placeholder="C$" ></asp:TextBox>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:Label Text="Cantidad Pago" foreColor="#006600" runat="server" />
                                            <asp:TextBox  style="width: 15%" Height="2%" ID="txtCantidadPago" OnTextChanged="txtCantidadPago_TextChanged" AutoPostBack="true" runat="server" class="form-control txtCantidadPago" type="number" placeholder="C$"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label Text="Cambio" foreColor="#006600" runat="server" />
                                            <asp:TextBox disabled="disabled" style="width: 15%" Height="2%" ID="txtCambio" runat="server" class="form-control" type="text" placeholder="Cambio"></asp:TextBox>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <asp:Button ID="GuardarTransac" runat="server" class="btn btn-success" Text="GuardarRegistro" OnClick="GuardarTransac_Click" />

                    </div>
                </div>

            </div>
        </div>
    </div>


    <%-- modal seleccionar articulos --%>
    <div class="modal fade mbModalunidad" id="myModal2" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="unidad">Seleccionar Producto</h5>
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
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <%-- <button type="button" class="btn btn-primary"></button>--%>
                </div>
            </div>
        </div>
    </div>

    <%-- modal seleccionar articulos --%>
    <div class="modal fade mbModal" id="myModal" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content w-100">
                <div class="modal-header">
                    <h5 class="modal-title" id="proveedor">Seleccionar Producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table id="modalproducto" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                   <th>Seleccionar</th>
                                <th>IdE</th>
                                <th>IdP</th>
                                <th>IdEN</th>
                                <th>Producto</th>
                                <th>Descripcion</th>
                                <th>Marca</th>
                                <th>PrecioVenta</th>
                                <th style="width: 5%">EnvaseUnidad</th>
                                <th>Existencia</th>
                                
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
        LoadProd();
        var dataServer1, tablePro1;
        function LoadProd() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("Venta.aspx/CargarExistencias") %>",
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
                            { "data": "opcion" },
                            { "data": 'IdExistencia' },
                            { "data": 'ID_PRODUCTO' },
                            { "data": 'ID_UNIDAD_ENVASE' },
                            { "data": 'NOMBRE_PRODUCTO' },
                            { "data": 'DescripcionProducto' },
                            { "data": 'NOMBRE_MARCA' },
                            { "data": 'PRECIO_VENTA' },
                            { "data": 'DESCRIPCION_ENVASE_UNIDAD' },
                            { "data": 'CANTIDAD_EXISTENCIA' }
                         
                        ],
                        "columnDefs": [
                            {
                                "targets": [1],
                                "visible": true,
                                "searchable": false
                            },
                            {
                                "targets": [2, 3],
                                "visible": false,
                                "searchable": false
                            },
                            {
                                "targets": -0,
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


        function AgregarTempPro() {
            //e.preventDefault();
            var cant = parseInt($('#<%=txtCantidad.ClientID %>').val());
            var precio = parseFloat($('#<%=txtPrecioVenta.ClientID %>').val());
            //debugger;
            if ($('#<%=txtCantidad.ClientID %>').val() == "") {
                swal("Advertencia!", "Cantidad debe ser mayor a 0", "warning")
                return;
            }
            var ID_PRODUCTO = parseInt($('#txtIdProducto').val());
            if ($('#txtIdProducto').val() == "") {
                swal("Advertencia!", "Seleccione un producto", "warning")
                return;
            }
            if ($('#<%=txtFecha.ClientID %>').val() == "") {
                swal("Advertencia!", "Seleccione una fecha", "warning")
                return;
            }
            


            var data = {
                ID_PRODUCTO: parseInt($('#txtIdProducto').val()),
                ID_EXISTENCIA: parseInt($('#txtidExistencia').val()),
                NOMBRE_PRODUCTO: $('#<%=txtProducto.ClientID%>').val(),
                CANTIDAD_EXISTENCIA: $('#<%=txtExistencia.ClientID %>').val(),
                CLIENTE_FACTURA: $('#<%=txtCliente.ClientID%>').val(),
                ID_UNIDAD_MEDIDA: parseInt($('#txtIdUnidadMedida').val()),
                UM_DESCRIPCION: $('#<%=txtUmDescripcion.ClientID%>').val(),
                CANTIDAD_PRODUCTOS: $('#<%=txtCantidad.ClientID %>').val(),
                CANTIDAD_PAGO: $('#<%=txtCantidadPago.ClientID %>').val(),
                FECHA_FACTURA: $('#<%=txtFecha.ClientID %>').val(),
                PRECIO_VENTA: $('#<%=txtPrecioVenta.ClientID %>').val(),
                ID_USUARIO: 1,
                SUBTOTAL: 0,//arseFloat( cant * precio ),
                CAMBIO: 0,

            };
            console.log(data);

            var json = Sys.Serialization.JavaScriptSerializer.serialize(data);


            console.log('Respuesta success ' + json);
            $.ajax({
                type: "POST",
                data: '{temp:' + json + '}',
                url: "<%= ResolveUrl("Venta.aspx/GuardarListaDetalleVenta") %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $.each(response, function (i, item) {
                        console.log(item);
                        $('#<%=txtTotal.ClientID%>').val(item);
                    });

                    LoadTemp();
                    console.log('Respuesta success ' + response);
                    swal("Exelente!", "Producto Añadido!", "success")
                },
                failure: function (response) {
                    console.log('Sucedio un error = ' + response);
                }
            });
        }

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
                url: "<%= ResolveUrl("Venta.aspx/CargarDatos") %>",
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
                            { "data": 'CLIENTE_FACTURA' },
                            { "data": 'NOMBRE_PRODUCTO' },
                            { "data": 'CANTIDAD_PRODUCTOS' },
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
            //console.log("id " + id);
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
                            url: "<%= ResolveUrl("Venta.aspx/EliminarDetalle") %>",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                LoadTemp();
                                swal("Deleted!", "Your item deleted.", "success");
                                $('#<%=txtCantidadPago.ClientID%>').val('');
                                $('#<%=txtCambio.ClientID%>').val('');
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

       $(document).on('keyup', "#<%=txtCantidad.ClientID%>", function (e) {
            validarCantidad();

        });
        $(document).on('click', "#<%=txtCantidad.ClientID%>", function (e) {
            e.preventDefault();
            validarCantidad();

        });

        function validarCantidad() {
            if ($('#<%=txtExistencia.ClientID%>').val() != "") {
                if (parseInt($("#<%=txtCantidad.ClientID%>").val()) > 0 && parseInt($("#<%=txtCantidad.ClientID%>").val()) <= parseInt($("#<%=txtExistencia.ClientID%>").val())) {
                    $("#validCantidad").removeClass("visible").addClass("no-visible");
                    $("#<%=txtCantidad.ClientID%>").css("border-color", "#ced4da");
                    document.getElementById("btnAgregar").removeAttribute("disabled");
                    $("<%=txtCantidad.ClientID%>").css("border-color", "green");
                } else {
                  
                    $("#validCantidad").removeClass("no-visible").addClass("visible");

                    $("#<%=txtCantidad.ClientID%>").css("border-color", "#red");
                    $("#<%=txtCantidad.ClientID%>").val("");
                    document.getElementById("btnAgregar").setAttribute("disabled", true);
                    $("#<%=txtCantidad.ClientID%>").css("border-color", "red");
                }
            }

        }

    
    

        $(document).ready(function () {
            $('#modalproducto').on('click', 'tr', function () {
                var p = tablePro1.row(this).data();
                var idExistencia = p.IdExistencia;
                var idproducto = p.ID_PRODUCTO;
                var PRE = p.PRECIO_VENTA;
                var PREd = p.CANTIDAD_EXISTENCIA;
                var producto = 'Producto:' + p.NOMBRE_PRODUCTO + '  /  ' + 'Marca:' + p.NOMBRE_MARCA + '  /  ' + 'Envase:' + p.DESCRIPCION_ENVASE_UNIDAD;

                $('#txtIdProducto').val(idproducto);
                $('#txtidExistencia').val(idExistencia);
                $('#<%=txtProducto.ClientID%>').val(producto);
                $('#<%=txtPrecioVenta.ClientID%>').val(PRE);
                $('#<%=txtExistencia.ClientID%>').val(PREd);
                $('#myModal').modal('hide');
            });

         

        });

        $(document).ready(function () {
            $('#modalunidad').on('click', 'tr', function () {
                var p = tablePro3.row(this).data();
                var idUnidadMedida = p.IdUnidadMedida;
                var unidades = 'UmDescripcion:' + p.UmDescripcion + '  /  ' + 'Unidades:' + p.Unidades;

                $('#txtIdUnidadMedida').val(idUnidadMedida);
                $('#<%=txtUmDescripcion.ClientID%>').val(unidades);

                $('#myModal2').modal('hide');
            });

          
        });
        quitarClases();
        document.getElementById("Venta").classList.add("active-page");
        document.getElementById("nav-venta").classList.add("active-page");
    </script>
</asp:Content>
