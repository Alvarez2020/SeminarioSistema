using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Transactions;
using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosTransaccionVenta
    {
        DB_MiscelaneaConnyEntities db = new DB_MiscelaneaConnyEntities();
        //metodo que realiza proceso transaccion en multiple tabla
        public int FinalizaTransaccion(ObjetoVenta obj, List<ObjetoVenta> lista) //pasa parametro con todos los datos para las 
        {                                       // diferentes tablas que interactuen en la base de dato
                                                //creamos nuestro contexto
                                                //  using (var db = new DB_MiscelaneaConnyEntities())
                                                // {
                                                //creamos el ámbito de la transacción
            using (TransactionScope scope = new TransactionScope())
            {   //a partir de aca se ejecuta en cola todas las operaciones a realizar durante una compra
                try
                {
                    //proceso N° 1  -> Almacenar datos en tabla Compra
                    //Paso 1 - convertir valores de obj a tabla compra del modelo
                    var tblVenta = new TBL_FACTURA
                    {
                        ID_FACTURA = 0,
                        FECHA_FACTURA = obj.FECHA_FACTURA,
                        CLIENTE_FACTURA = obj.CLIENTE_FACTURA,
                        ID_USUARIO_FACTURA = 1,
                        TOTAL = obj.TOTAL,
                        CANTIDAD_PAGO = obj.CANTIDAD_PAGO,
                        CAMBIO = obj.CAMBIO

                    };
                    //Paso 2 - guardar en  tabla compra
                    db.TBL_FACTURA.Add(tblVenta);
                    db.SaveChanges();

                    //proceso N° 2 -> Recorrer y obtener la lista de detalle de compra
                    foreach (var item in lista)
                    {
                        //Paso 1 - convertir valores de obj a tabla del modelo
                        var tblDetalle = new TBL_DETALLE_FACT
                        {
                            ID_FACTURA = tblVenta.ID_FACTURA,
                            ID_EXISTENCIA = item.ID_EXISTENCIA,
                            ID_PRODUCTO = item.ID_PRODUCTO,
                            CANTIDAD_PRODUCTOS = item.CANTIDAD_PRODUCTOS,
                            PRECIO_UNIT = item.PRECIO_VENTA,
                            SUBTOTAL = item.SUBTOTAL,
                            ID_UNIDAD_MEDIDA = (int)item.ID_UNIDAD_MEDIDA,
                           
                        };
                        //Paso 2 - guardar en  tabla
                        db.TBL_DETALLE_FACT.Add(tblDetalle);
                        db.SaveChanges();

                        var unidad = db.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                            x => x.ID_UNIDAD_MEDIDA == item.ID_UNIDAD_MEDIDA);
                        int? unidades = 0;
                        if (unidad != null)
                        {
                            unidades = unidad.UNIDADES;
                        }

                        //proceso N° 3 -> Actualizar o declarar(Agregar) existencia
                        //Paso 1 - Filtrar
                        var busca = db.TBL_EXITENCIA.FirstOrDefault(
                            x => x.ID_EXISTENCIA == item.ID_EXISTENCIA);    // 150 exixt === 149 obj client
                        if (busca != null) //si no se encuentra lo agrega a exiustencia como nuevo registro   v  2 k  == 1500  /  v 2 k == 1500
                        {                                                                                  // c  2 k  == 1250  /  c 2 k == 1300
                                                                                                           //Paso 1 - convertir valores de obj a tabla del modelo
                            busca.CANTIDAD_EXISTENCIA =
                                busca.CANTIDAD_EXISTENCIA - (item.CANTIDAD_PRODUCTOS * unidades);

                        }
                      
                        db.SaveChanges();


                    }//fin de recorrido de lista detalle

                    scope.Complete();///proceso de finalizacion de la transaccion

                    return tblVenta.ID_FACTURA;
                }
                catch (Exception ex)
                {   //si algo en los procesos falla, tan solo 1 operacion todo se deshace
                    scope.Dispose();
                    return 0;
                }
            }
            // }

        }
    }

    public class ObjetoVenta
    {   //CORREGIR SOLO CAMPOS QUE CORRESPONDEN A VENTA EN TABLA PRINCIPAL Y DETALLE
        //Propiedades Compra
        public Guid ID { get; set; }
        public int? ID_VENTA { get; set; }
        public int ID_FACTURA { get; set; }
        public Nullable<System.DateTime> FECHA_FACTURA { get; set; }
        public Nullable<int> ID_BODEGA_FACTURA { get; set; }
        public string CLIENTE_FACTURA { get; set; }
        public Nullable<int> ID_USUARIO_FACTURA { get; set; }
        public decimal? TOTAL { get; set; }
        public Nullable<decimal> CANTIDAD_PAGO { get; set; }
        public Nullable<decimal> CAMBIO { get; set; }
      

        //Propiedades detalle factura
        public int ID_PRODUCTO { get; set; }
        public int ID_EXISTENCIA { get; set; }
        
        public int? CANTIDAD_PRODUCTOS { get; set; }
        public Nullable<decimal> PRECIO_UNIT { get; set; }
        public Nullable<decimal> PRECIO_VENTA { get; set; }
        public Nullable<decimal> SUBTOTAL { get; set; }
        
   
   
        
        public Nullable<int> ID_UNIDAD_MEDIDA { get; set; }

        public Nullable<int> ID_UNIDAD_ENVASE { get; set; }

        public string DESCRIPCION_ENVASE_UNIDAD { get; set; }

        //propiedades extras
        public string NOMBRE_PRODUCTO { get; set; }
        public string NOMBRE_MARCA { get; set; }
     
        public string ENCARGADO { get; set; }
     
        public int? ID_USUARIO { get; set; }

       
        public string UM_DESCRIPCION { get; set; }
        public int UNIDADES { get; set; }

       

        //propiedad para bodega bodega 
        public Nullable<int> ID_BODEGA { get; set; }



        
    }
}
