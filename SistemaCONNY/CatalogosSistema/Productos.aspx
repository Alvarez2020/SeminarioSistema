<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="SistemaCONNY.CatalogosSistema.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h3>Agregar Producto</h3>
                    <p class="card-description">
                        <%-- Add class <code>.table</code>--%>
                    </p>
                    <div class="panel panel-light">
                        <div class="panel-heading">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal"> <i class="fas fa-plus-square"></i> </button>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                        <div class="panel-body">
                            <div class=""></div>
                            <table id="gridData" class="table table-striped table-bordered" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="width: 15%">Id</th>
                                        <th>IdMarca</th>
                                         <th>IdTipoProducto</th>
                                         <th>IdUnidadMedida</th>
                                         <th>Producto</th>
                                         <th>Descripcion</th>
                                         <th>Tipo Producto</th>
                                         <th>Unidad Medida</th>
                                         <th>Marca</th>
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

                        <div class="row">
                            <asp:Literal ID="lb_mensaje" runat="server"></asp:Literal>
                        </div>
                        <div hidden class="form-group">
                            <asp:Label Text="ID_PRODUCTO" runat="server" />
                            <asp:TextBox ID="IdProducto" runat="server" class="form-control" type="text" Text="0" placeholder="ID_PRODUCTO"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="NOMBRE_PRODUCTO" runat="server" />
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" type="text" placeholder="NOMBRE_PRODUCTO"></asp:TextBox>
                             <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" ControlToValidate="txtNombre" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo es necesario" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="DESCRIPCION_PRODUCTO" runat="server" />
                            <asp:TextBox ID="textDescripcion" runat="server" CssClass="form-control" type="text" placeholder="DESCRIPCION_PRODUCTO"></asp:TextBox>
                             <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar"  ControlToValidate="textDescripcion" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo es necesario" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="TIPO_PRODUCTO" runat="server" />
                            <asp:DropDownList CssClass="form-control" ID="dropTipoProducto" runat="server">
                                 <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar"  InitialValue="0" ControlToValidate="dropTipoProducto" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo es necesario" />

                        </div>
                        <div class="form-group">
                            <asp:Label Text="UNIDAD_MEDIDA" runat="server" />
                            <asp:DropDownList CssClass="form-control" ID="dropUnidad" runat="server">
                                 <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                           <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar"  InitialValue="0" ControlToValidate="dropUnidad" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo es necesario" />

                        </div>
                        <div class="form-group">
                            <asp:Label Text="MARCA" runat="server" />
                            <asp:DropDownList CssClass="form-control" ID="dropMarca" runat="server">
                                 <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                           <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valGuardar" InitialValue="0" ControlToValidate="dropMarca" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo es necesario" />
                        </div>
                        <asp:Button ID="btnGuardar" ValidationGroup="valGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" runat="server" Text="Guardar" />
                        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                    </div>
                    </div>
                        </ContentTemplate>
                          </asp:UpdatePanel>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    </div>
                  
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
 
         LoadTemp();
         var dataServer, tablePro;
         function LoadTemp() {
             //e.preventDefault();
             $.ajax({
                 type: "POST",
                 url: "<%= ResolveUrl("Productos.aspx/CargarProducto") %>",
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
                            { "data": 'IdProducto' },
                            { "data": 'IdMarca' },
                            { "data": 'IdTipoProducto' },
                            { "data": 'IdUnidadMedida' },
                            { "data": 'NombreProducto' },
                            { "data": 'DescripcionProducto' },
                            { "data": 'TipoProducto' },
                            { "data": 'UmDescripcion' },
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
                                "targets": [1,2,3,7],
                                "visible": false,
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
                 var id = globalDataEdicion.IdProducto;
                // console.log(id);
                 $('#<%=IdProducto.ClientID%>').val(id);
                 $('#<%=txtNombre.ClientID%>').val(globalDataEdicion.NombreProducto);
                 $('#<%=textDescripcion.ClientID%>').val(globalDataEdicion.DescripcionProducto);
                 $('#<%=dropUnidad.ClientID%>').val(globalDataEdicion.IdUnidadMedida);
                 $('#<%=dropTipoProducto.ClientID%>').val(globalDataEdicion.IdTipoProducto);
                 $('#<%=dropMarca.ClientID%>').val(globalDataEdicion.IdMarca);
                <%-- $('#<%=txtCodArticulo.ClientID%>').val(idArticulo);   TextBox1
                  $('#<%=txtArticulo.ClientID%>').val(articulo);--%>
             });
             $('#gridData').on('click', '#btnEliminar', function (e) {
                 var data_form = tablePro.row($(this).parents("tr")).data();
                 var id = data_form.IdProducto;
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
                                 url: "<%= ResolveUrl("Productos.aspx/suprData") %>",
                                   contentType: "application/json; charset=utf-8",
                                   dataType: "json",
                                   success: function (response) {
                                       LoadTemp();
                                       $('#<%=IdProducto.ClientID%>').val('0');
                                       $('#<%=txtNombre.ClientID%>').val('');
                                       $('#<%=textDescripcion.ClientID%>').val('');
                                       $('#<%=dropUnidad.ClientID%>').val('');
                                       $('#<%=dropTipoProducto.ClientID%>').val('');
                                       $('#<%=dropMarca.ClientID%>').val('');
                                       swal("Eliminado!", "El Dato Se Ha Eliminado.", "success");
                                   },
                                   failure: function (response) {
                                       swal("Error!", "Dependencia de datos.", "warning");
                                   }
                               });
                         } else {
                             swal("Cancelado", "Operacion cancelada", "error");
                             $('#<%=IdProducto.ClientID%>').val('0');
                             $('#<%=txtNombre.ClientID%>').val('');
                             $('#<%=textDescripcion.ClientID%>').val('');
                             $('#<%=dropUnidad.ClientID%>').val('');
                             $('#<%=dropTipoProducto.ClientID%>').val('');
                             $('#<%=dropMarca.ClientID%>').val('');
                         }
                     });
              });
         });
         quitarClases();
         document.getElementById("Productos").classList.add("active-page");
         document.getElementById("nav-inv").classList.add("active-page");
         function err() {
             swal('Advertencia!', 'Dato repetido', 'warning')
         }

         function err1() {
             swal('Excelente!', 'Dato Guardado', 'success')
             LoadTemp();
         }
     </script>
</asp:Content>
