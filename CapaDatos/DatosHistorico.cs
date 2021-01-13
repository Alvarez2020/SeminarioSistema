using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosHistorico
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();
        public List<ObjetoExistencia1> metodoMostrarListaDatos()
        {
           
             var consulta = (from variableAlmacenado in modelBaseDato.TBL_DETALLE_COMPRA
                             select new ObjetoExistencia1
                             {
                                 ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                                 ID_MARCA = variableAlmacenado.TBL_PRODUCTO.ID_MARCA,
                                 NOMBRE_PRODUCTO = variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                 NOMBRE_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                 CANTIDAD_PRODUCTO = variableAlmacenado.CANTIDAD_PRODUCTOS,
                                 PRECIO_COMPRA = variableAlmacenado.PRECIO_COMPRA,
                                 PRECIO_VENTA = variableAlmacenado.PRECIO_VENTA,
                                 TOTAL = variableAlmacenado.SUBTOTAL,
                                 ID_UNIDAD_MEDIDA  = variableAlmacenado.ID_UNIDAD_MEDIDA,
                                 UM_DESCRIPCION = variableAlmacenado.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                 UNIDADES = variableAlmacenado.CAT_UNIDAD_MEDIDA.UNIDADES,
                                 FECHA_COMPRA = variableAlmacenado.TBL_COMPRA.FECHA_COMPRA,                                


                             }).ToList();
                  return consulta;
        }
    }
    public class ObjetoExistencia1
    {
        //propiedades
        public int? ID_PRODUCTO { get; set; }
        public int? ID_MARCA { get; set; }
        public int? ID_UNIDAD_MEDIDA { get; set; }
        public string UM_DESCRIPCION { get; set; }
        public int? UNIDADES { get; set; }

        public string NOMBRE_PRODUCTO { get; set; }
        public string NOMBRE_MARCA { get; set; }
        public decimal? PRECIO_COMPRA { get; set; }
        public decimal? PRECIO_VENTA { get; set; }
        public decimal? TOTAL { get; set; }
        public int? CANTIDAD_PRODUCTO { get; set; }
        public System.DateTime? FECHA_COMPRA { get; set; }

    }
}
