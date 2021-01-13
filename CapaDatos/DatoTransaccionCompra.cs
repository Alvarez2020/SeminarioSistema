 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatoTransaccionCompra
    {
        DB_MiscelaneaConnyEntities db = new DB_MiscelaneaConnyEntities();
        public int FinalizaTransaccion(ObjetoCompra obj, List<ObjetoCompra> lista) //pasa parametro con todos los datos para las 
        {                                       // diferentes tablas que interactuen en la base de dato
                                                //creamos nuestro contexto
                                                //creamos el ámbito de la transacción
            using (TransactionScope scope = new TransactionScope())
            {   // se ejecuta en cola todas las operaciones a realizar durante una compra
                try
                {
                    //Almacenar datos en tabla Compra
                    //convertir valores de obj a tabla compra del modelo
                    var tblCompra = new TBL_COMPRA
                    {
                        ID_COMPRA = 0,
                        FECHA_COMPRA = obj.FECHA_COMPRA,
                        TOTAL = obj.TOTAL,
                        CANTIDAD_PAGO = obj.CANTIDAD_PAGO,
                        CAMBIO = obj.CAMBIO,
                        ID_USUARIO = 1
                    };
                    //Paso 2 - guardar en  tabla compra
                    db.TBL_COMPRA.Add(tblCompra);
                    db.SaveChanges();

                    // Recorrer y obtener la lista de detalle de compra
                    foreach (var item in lista)
                    {
                        
                        
                        // convertir valores de obj a tabla del modelo
                        var tblDetalle = new TBL_DETALLE_COMPRA
                        {
                            ID_COMPRA = tblCompra.ID_COMPRA,
                            ID_PRODUCTO = item.ID_PRODUCTO,
                            CANTIDAD_PRODUCTOS = item.CANTIDAD_PRODUCTOS,
                            PRECIO_COMPRA = item.PRECIO_COMPRA,
                            PRECIO_VENTA = item.PRECIO_VENTA,
                            SUBTOTAL = item.SUBTOTAL,
                            ID_UNIDAD_MEDIDA = (int)item.ID_UNIDAD_MEDIDA,
                            ID_UNIDAD_ENVASE = item.ID_UNIDAD_ENVASE
                        };
                        
                        // guardar en  tabla
                        db.TBL_DETALLE_COMPRA.Add(tblDetalle);
                        db.SaveChanges();
                       
                        var unidad = db.CAT_UNIDAD_MEDIDA.FirstOrDefault(x => x.ID_UNIDAD_MEDIDA == item.ID_UNIDAD_MEDIDA);
                        int? unidades = 0;
                        if (unidad != null)
                        {
                            unidades = unidad.UNIDADES;
                        }

                            // Actualizar o declarar(Agregar) existencia
                            // Filtrar
                            var busca = db.TBL_EXITENCIA.FirstOrDefault(x => x.ID_PRODUCTO == item.ID_PRODUCTO    
                                                                 && x.PRECIO_VENTA == item.PRECIO_VENTA                            
                                                                && x.FECHA_VENCIMIENTO_PRODUCTO == item.FECHA_VENCIMIENTO_PRODUCTO);    
                        if (busca == null) 
                        {                                                                                  
                            // convertir valores de obj a tabla del modelo
                            var tblExistencia = new TBL_EXITENCIA
                            {
                                ID_BODEGA = item.ID_BODEGA,
                                ID_PRODUCTO = item.ID_PRODUCTO,
                                CANTIDAD_DEVOLUCION = 0,
                                CANTIDAD_EXISTENCIA = item.CANTIDAD_PRODUCTOS * unidades, 
                                FECHA_ELABORACION_PRODUCTO = item.FECHA_ELABORACION_PRODUCTO,
                                FECHA_VENCIMIENTO_PRODUCTO = item.FECHA_VENCIMIENTO_PRODUCTO,
                                PRECIO_VENTA = item.PRECIO_VENTA,
                                ID_UNIDAD_ENVASE = item.ID_UNIDAD_ENVASE
                            };
                            //Paso 2 - guardar en  tabla
                            db.TBL_EXITENCIA.Add(tblExistencia);
                          
                        }
                        else 
                        {   
                            busca.CANTIDAD_EXISTENCIA = (item.CANTIDAD_PRODUCTOS * unidades) + busca.CANTIDAD_EXISTENCIA;
                        }
                                           db.SaveChanges();


                        var buscaProvedorProducto = db.PRODUCTO_PROVEEDOR.FirstOrDefault(x => x.ID_PRODUCTO == item.ID_PRODUCTO
                                                              && x.ID_PROVEEDOR == item.ID_PROVEEDOR);
                        if (busca == null) 
                        {
                            // convertir valores de obj a tabla del modelo
                            var tblProveeProducto = new PRODUCTO_PROVEEDOR
                            {
                                ID_PROVEEDOR = item.ID_PROVEEDOR,
                                ID_PRODUCTO = item.ID_PRODUCTO,

                            };
                         
                            db.PRODUCTO_PROVEEDOR.Add(tblProveeProducto);
                            db.SaveChanges();
                        }

                    }
                    //fin de recorrido de lista detalle

                    scope.Complete();
                    ///proceso de finalizacion de la transaccion

                    return tblCompra.ID_COMPRA;
                }
                catch (Exception ex)
                {   //si algo en los procesos falla,  todo se deshace
                    scope.Dispose();
                    return 0;
                }
            }
            // }

        }
    }

    public class ObjetoCompra
    {
        //Propiedades Compra
        public Guid ID { get; set; }
        public int? ID_COMPRA { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string NOMBRE_MARCA { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string ENCARGADO { get; set; }
        public System.DateTime? FECHA_COMPRA { get; set; }
        public int? ID_USUARIO { get; set; }
        public decimal? TOTAL { get; set; }
        public Nullable<decimal> CANTIDAD_PAGO { get; set; }
        public Nullable<decimal> CAMBIO { get; set; }
        public decimal? SUBTOTAL { get; set; }
        //propiedades Detalle Compra
   
        public int ID_PRODUCTO { get; set; }
        public int? CANTIDAD_PRODUCTOS { get; set; }
        public decimal? PRECIO_COMPRA { get; set; }
        public decimal? PRECIO_VENTA { get; set; }
        public Nullable<int> ID_UNIDAD_MEDIDA { get; set; }
        public string UM_DESCRIPCION { get; set; }
        public int UNIDADES { get; set; }
        public Nullable<int> ID_UNIDAD_ENVASE { get; set; }
        public string DESCRIPCION_ENVASE_UNIDAD { get; set; }

        //propiedades para existencia
        public Nullable<System.DateTime> FECHA_ELABORACION_PRODUCTO { get; set; }
        public string FECHA_VENCIMIENTO_PRODUCTO { get; set; }
        public Nullable<int> CANTIDAD_EXISTENCIA { get; set; }
        public Nullable<int> CANTIDAD_DEVOLUCION { get; set; }

        //propiedad para bodega bodega 
        public Nullable<int> ID_BODEGA { get; set; }

      




    }
}
