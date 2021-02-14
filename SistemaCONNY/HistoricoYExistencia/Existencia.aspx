<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Existencia.aspx.cs" Inherits="SistemaCONNY.HistoricoYExistencia.Existencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h3>EXISTENCIA</h3>
                    <p class="card-description">
                        <%-- Add class <code>.table</code>--%>
                    </p>
                    <div class="panel panel-light">
                         <div class="form-group">
                                        <asp:Label Text="BODEGAS" runat="server" />
                                        <asp:DropDownList ID="dropBodega" runat="server"
                                            class="form-control" type="text" placeholder="Seleccione">
                                             <asp:ListItem Value="0"> ("Seleccione una Bodega") </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                        <div class="panel-body">
                            <div class="col-md-12">
                               <table id="gridData1" class="table table-striped table-bordered" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="width: 15%;">IdProducto</th>
                                        <th style="display:none;">IdMarca</th>
                                         <th style="display:none;">IdBodega</th>
                                       <th style="display:none;">IdUnidadEnvase</th>
                                         <th>NombreProducto</th>
                                         <th>NombreMarca</th>
                                         <th style="display:none;">NombreBodega</th>
                                        <th>DescripcionEnvaseUnidad</th>
                                        <th>PrecioVenta</th>
                                         <th>Existencia</th>
                                       <th style="display:none;">FechaElaboracion</th>
                                         <th>FechaVencimiento</th>
                                         <th style="width: 15%; text-align: center">Opciones</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                 </div>
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
            "info": "Productos _START_ a _END_ de _TOTAL_ Productos",
            "infoEmpty": "Productos 0 a 0 de 0 Productos",
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

        //LoadTemp();
        var dataServer, tablePro;
        function LoadTemp() {
            //e.preventDefault();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("Existencia.aspx/CargarDatos") %>",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {
                     $.each(response, function (i, item) {
                         dataServer = JSON.parse(item);
                     });
                     tablePro = $('#gridData1').DataTable({
                         "dataType": "json",
                         "destroy": true,
                         "aaData": dataServer,
                         "responsive": true,
                         "columns": [
                             { "data": 'ID_PRODUCTO' },
                             { "data": 'ID_MARCA' },
                             { "data": 'ID_BODEGA' },
                             { "data": 'ID_UNIDAD_ENVASE' },
                             { "data": 'NOMBRE_PRODUCTO' },
                             { "data": 'NOMBRE_MARCA' },
                             { "data": 'NOMBRE_BODEGA' },
                             { "data": 'DESCRIPCION_ENVASE_UNIDAD' },
                             { "data": 'PRECIO_VENTA' },
                             { "data": 'CANTIDAD_EXISTENCIA' },
                             { "data": 'FECHA_ELABORACION_PRODUCTO' },
                             { "data": 'FECHA_VENCIMIENTO_PRODUCTO' },
                             { "data": "opcion" }
                         ],
                         "columnDefs": [
                             {
                                 "targets": [0],
                                 "visible": false,
                                 "searchable": false
                             },
                             {
                                 "targets": [1, 2, 3, 6, 10],
                                 "visible": false,
                                 "searchable": false
                             },
                             {
                                 "targets": [10], render: function (data) {
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

       <%-- $(document).ready(function () {

            //funcion que permite seleccionar datos de la tabla
            $('#gridData').on('click', 'tr', function () {
                globalDataEdicion = tablePro.row(this).data();
                // console.log(globalDataEdicion);
                var id = globalDataEdicion.IdBodega;
                // console.log(id);
              <%--  $('#<%=idBodega.ClientID%>').val(id);
                 $('#<%=txtNombre.ClientID%>').val(globalDataEdicion.NombreBodega);
                 $('#<%=dropCiudad.ClientID%>').val(globalDataEdicion.IdCiudad);--%>
                <%-- $('#<%=txtCodArticulo.ClientID%>').val(idArticulo);   TextBox1
                  $('#<%=txtArticulo.ClientID%>').val(articulo);--%>
             //});--%>
             //$('#gridData').on('click', '#btnEliminar', function (e) {
             //    var data_form = tablePro.row($(this).parents("tr")).data();
             //    var id = data_form.IdBodega;
             //    var isConfirm;
             //    //this.preventDefault();
             //    e.preventDefault();
             //    swal({
             //        title: "Desea eliminar el elemento?",
             //        text: "Selecciona una accion",
             //        type: "warning",
             //        showCancelButton: true,
             //        confirmButtonClass: "btn-danger",
             //        confirmButtonText: "Confirmar",
             //        cancelButtonText: "Cancelar",
             //        closeOnConfirm: false,
             //        closeOnCancel: false
             //    },
                    <%-- function (isConfirm) {
                         if (isConfirm) {
                             $.ajax({
                                 type: "POST",
                                 data: '{codigo:' + id + '}',
                                 url: "<%= ResolveUrl("Historico.aspx/suprData") %>",
                                   contentType: "application/json; charset=utf-8",
                                   dataType: "json",
                                   success: function (response) {
                                       LoadTemp();
                                      <%-- $('#<%=idBodega.ClientID%>').val('');
                                       $('#<%=txtNombre.ClientID%>').val('');
                                       $('#<%=dropCiudad.ClientID%>').val('');--%>
                     //                swal("Deleted!", "Your item deleted.", "success");
                     //            },
                     //            failure: function (response) {
                     //                swal("Error!", "Dependencia de datos.", "warning");
                     //            }
                     //        });
                     //    } else {
                     //        swal("Cancelado", "Operacion cancelada", "error");
                     //    }
                     //});
         //    });
         //});--%>
    $(document).on('change', ('#<%=dropBodega.ClientID%>'), function (e) {
        e.preventDefault();
        console.log($(this).val());
        var id = $(this).val();
        $.ajax({
            type: "POST",
            data: '{id:' + id + '}',
            url: "<%= ResolveUrl("Existencia.aspx/CargarDatos") %>",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {
                     $.each(response, function (i, item) {
                         dataServer = JSON.parse(item);
                     });
                     tablePro = $('#gridData1').DataTable({
                         "dataType": "json",
                         "destroy": true,
                         "aaData": dataServer,
                         "responsive": true,
                         "columns": [
                             { "data": 'ID_PRODUCTO' },
                             { "data": 'ID_MARCA' },
                             { "data": 'ID_BODEGA' },
                             { "data": 'ID_UNIDAD_ENVASE' },
                             { "data": 'NOMBRE_PRODUCTO' },
                             { "data": 'NOMBRE_MARCA' },
                             { "data": 'NOMBRE_BODEGA' },
                             { "data": 'DESCRIPCION_ENVASE_UNIDAD' },
                             { "data": 'PRECIO_VENTA' },
                             { "data": 'CANTIDAD_EXISTENCIA' },
                             { "data": 'FECHA_ELABORACION_PRODUCTO' },
                             { "data": 'FECHA_VENCIMIENTO_PRODUCTO' },
                             { "data": "opcion" }
                         ],
                         "columnDefs": [
                             {
                                 "targets": [0],
                                 "visible": false,
                                 "searchable": false
                             },
                             {
                                 "targets": [1, 2, 3, 6, 10],
                                 "visible": false,
                                 "searchable": false
                             },
                             {
                                 "targets": [10], render: function (data) {
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
    });
    quitarClases();
    document.getElementById("Existencia").classList.add("active-page");
    document.getElementById("nav-inv").classList.add("active-page");

</script>
</asp:Content>

