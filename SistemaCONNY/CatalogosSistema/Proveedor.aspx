<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs"
    Inherits="SistemaCONNY.CatalogosSistema.Proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h3>Agregar Proveedor</h3>
                    <p class="card-description">
                        <%-- Add class <code>.table</code>--%>
                    </p>
                    <div class="panel panel-light">
                        <div class="panel-heading">
   <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal"> <i class="fas fa-plus-square"></i> </button>
                            <asp:Literal ID="lb_mensaje" runat="server"></asp:Literal>
                        </div>
                        <div class="panel-body">
                            <div class=""></div>
                            <table id="gridData" class="table table-striped table-bordered" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="width:15%">Id</th>
                                        <th>Proveedor</th>
                                        <th>Encargado</th>
                                        <th>Telefono</th>
                                        <th style="width:15%; text-align:center">Opciones</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                  
                </div>
            </div>
        </div>
    </div>


    <%-- modal para nuevo registro --%>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                        <div class="modal-header">
                              <h4>MISCELANEA CONNY <i class="fas fa-warehouse"></i></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                            <div class="panel-heading">
                        
                            </div>
                            <div class="panel-body">
                                <div hidden class="form-group">
                                    <asp:Label Text="ID_PROVEEDOR" runat="server" />
                                <asp:TextBox ID="txtIdProveedors" runat="server" class="form-control" type="text" Text="-1" placeholder="ID_PRODUCTO"></asp:TextBox>
                                   <%-- <asp:TextBox ID="txtIdProveedor" runat="server"
                                        disabled class="form-control" type="text" placeholder="ID_PROVEEDOR"></asp:TextBox>--%>
                                </div>
                                <div class="form-group">
                                    <asp:Label Text="NOMBRE_PROVEEDOR" runat="server" />
                                    <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control" type="text" placeholder="NOMBRE_PROVEEDOR"></asp:TextBox>
                                 <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" ControlToValidate="txtProveedor" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo es necesario" />
                                </div>
                                  <div class="form-group">
                                    <asp:Label Text="ENCARGADO" runat="server" />
                                    <asp:TextBox ID="txtEncargado" runat="server" CssClass="form-control" type="text" placeholder="ENCARGADO"></asp:TextBox>
                                 <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" ControlToValidate="txtEncargado" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo es necesario" />
                                </div>
                                 <div class="form-group">
                                    <asp:Label Text="Telefono" runat="server" />
                                    <asp:TextBox ID="txtTelefono" TextMode="Number" runat="server" CssClass="form-control" type="text" placeholder="Telefono"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" ControlToValidate="txtTelefono" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo es necesario" />
                                 </div>
                            </div>
                            <%--<input class="form-control" type="text" placeholder="CIUDAD_BODEGA">--%>
                            <%--<input class="form-control" type="text" placeholder="CIUDAD_BODEGA">--%>
                            <asp:Button ID="btnGuardar" ValidationGroup="valGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" runat="server" Text="Guardar" />
                            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                        </div>
                </ContentTemplate>
                          </asp:UpdatePanel>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
            </div>
        </div>
    </div>
    <%-- fin modal para nuevo registro --%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
     <script>    
         var globalDataEdicion;

         function mensajeToast() {
             toastr.success('Operacion realizada', 'Éxito');
         }
         function hideModal() {
             $("#myModal").modal("hide");
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
                 url: "<%= ResolveUrl("Proveedor.aspx/CargarDatos") %>",
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
                            { "data": 'IdProveedor' },
                            { "data": 'NombreProveedor' },
                            { "data": 'Encargado' },
                            { "data": 'Telefono' },
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

         $(document).ready(function () {

            //funcion que permite seleccionar datos de la tabla
             $('#gridData').on('click', '#btnEditar', function () {
                 globalDataEdicion = tablePro.row($(this).parents("tr")).data();
                // console.log(globalDataEdicion);
                 var id = globalDataEdicion.IdProveedor;
                // console.log(id);
                 $('#<%=txtIdProveedors.ClientID%>').val(id);
                 $('#<%=txtTelefono.ClientID%>').val(globalDataEdicion.Telefono);
                 $('#<%=txtProveedor.ClientID%>').val(globalDataEdicion.NombreProveedor);
                 $('#<%=txtEncargado.ClientID%>').val(globalDataEdicion.Encargado);
                <%-- $('#<%=txtCodArticulo.ClientID%>').val(idArticulo);   TextBox1
                  $('#<%=txtArticulo.ClientID%>').val(articulo);--%>
             });
             $('#gridData').on('click', '#btnEliminar', function (e) {
                 var data_form = tablePro.row($(this).parents("tr")).data();
                 var id = data_form.IdProveedor;
                 var isConfirm;
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
                                 data: '{codigo:' + id + '}',
                                 url: "<%= ResolveUrl("Proveedor.aspx/suprData") %>",
                                   contentType: "application/json; charset=utf-8",
                                   dataType: "json",
                                   success: function (response) {
                                       LoadTemp();
                                       $('#<%=txtIdProveedors.ClientID%>').val('-1');
                                       $('#<%=txtTelefono.ClientID%>').val('');
                                       $('#<%=txtProveedor.ClientID%>').val('');
                                       $('#<%=txtEncargado.ClientID%>').val('');
                                       swal("Deleted!", "Your item deleted.", "success");
                                   },
                                   failure: function (response) {
                                       swal("Error!", "Dependencia de datos.", "warning");
                                   }
                               });
                         } else {
                             swal("Cancelado", "Operacion cancelada", "error");
                             $('#<%=txtIdProveedors.ClientID%>').val('-1');
                             $('#<%=txtTelefono.ClientID%>').val('');
                                       $('#<%=txtProveedor.ClientID%>').val('');
                             $('#<%=txtEncargado.ClientID%>').val('');
                         }
                     });
              });
         });
         quitarClases();
         document.getElementById("Proveedor").classList.add("active-page");
         document.getElementById("nav-compra").classList.add("active-page");
         function err() {
             swal('Advertencia!', 'Dato repetido', 'warning')
         }

         function err1() {
             swal('Excelente!', 'Dato Guardado', 'success')
             LoadTemp();
         }
     </script>
</asp:Content>