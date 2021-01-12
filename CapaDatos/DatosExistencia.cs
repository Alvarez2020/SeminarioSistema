using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosExistencia
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();
        public List<ObjetoExistencia> metodoMostrarListaDatos()
        {

            var consulta = (from variableAlmacenado in modelBaseDato.TBL_EXITENCIA
                            join pro in modelBaseDato.TBL_PRODUCTO on variableAlmacenado.ID_PRODUCTO equals pro.ID_PRODUCTO
                            where variableAlmacenado.CANTIDAD_EXISTENCIA > 0
                            select new ObjetoExistencia
                            {

                                ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                                ID_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.ID_MARCA,
                                ID_BODEGA = (int)variableAlmacenado.ID_BODEGA,
                                NOMBRE_PRODUCTO = variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                NOMBRE_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                NOMBRE_BODEGA = variableAlmacenado.CAT_BODEGA.NOMBRE_BODEGA,
                                CANTIDAD_EXISTENCIA = variableAlmacenado.CANTIDAD_EXISTENCIA,
                                PRECIO_VENTA = variableAlmacenado.PRECIO_VENTA,
                                FECHA_ELABORACION_PRODUCTO = variableAlmacenado.FECHA_ELABORACION_PRODUCTO,
                                FECHA_VENCIMIENTO_PRODUCTO = variableAlmacenado.FECHA_VENCIMIENTO_PRODUCTO,
                                ID_UNIDAD_ENVASE = variableAlmacenado.ID_UNIDAD_ENVASE,
                                DESCRIPCION_ENVASE_UNIDAD = variableAlmacenado.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,
                                IdExistencia = variableAlmacenado.ID_EXISTENCIA,
                                DescripcionProducto = variableAlmacenado.TBL_PRODUCTO.DESCRIPCION_PRODUCTO,
                               
                            }).ToList();
            return consulta;
        }
        public List<ObjetoExistencia> metodoMostrarListaDatos(int ID_BODEGA)
        {

            var consulta = (from variableAlmacenado in modelBaseDato.TBL_EXITENCIA
                            join pro in modelBaseDato.TBL_PRODUCTO on variableAlmacenado.ID_PRODUCTO equals pro.ID_PRODUCTO          
                            where variableAlmacenado.ID_BODEGA == ID_BODEGA
                           select new ObjetoExistencia
                            {
                               ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                               ID_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.ID_MARCA,
                               ID_BODEGA = (int)variableAlmacenado.ID_BODEGA,
                               NOMBRE_PRODUCTO = variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                               NOMBRE_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                               NOMBRE_BODEGA = variableAlmacenado.CAT_BODEGA.NOMBRE_BODEGA,
                               CANTIDAD_EXISTENCIA = variableAlmacenado.CANTIDAD_EXISTENCIA,
                               PRECIO_VENTA = variableAlmacenado.PRECIO_VENTA,
                               FECHA_ELABORACION_PRODUCTO = variableAlmacenado.FECHA_ELABORACION_PRODUCTO,
                               FECHA_VENCIMIENTO_PRODUCTO = variableAlmacenado.FECHA_VENCIMIENTO_PRODUCTO,
                               ID_UNIDAD_ENVASE = variableAlmacenado.ID_UNIDAD_ENVASE,
                               DESCRIPCION_ENVASE_UNIDAD = variableAlmacenado.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,
                               IdExistencia = variableAlmacenado.ID_EXISTENCIA,
                               DescripcionProducto = variableAlmacenado.TBL_PRODUCTO.DESCRIPCION_PRODUCTO,

                           }).ToList();
            return consulta;
        }
    }
    public class ObjetoExistencia
    {
        //propiedades
        public int? ID_PRODUCTO { get; set; }
        public int ID_MARCA { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string NOMBRE_MARCA { get; set; }
        public string NOMBRE_BODEGA { get; set; }
        public Nullable<System.DateTime> FECHA_ELABORACION_PRODUCTO { get; set; }
        public string FECHA_VENCIMIENTO_PRODUCTO { get; set; }
        public Nullable<int> CANTIDAD_EXISTENCIA { get; set; }
        public decimal? PRECIO_VENTA { get; set; }
        public Nullable<int> ID_BODEGA { get; set; }
        public int? ID_UNIDAD_ENVASE { get; set; }
        public string DESCRIPCION_ENVASE_UNIDAD { get; set; }
        public string DescripcionProducto { get; set; }
        public int IdExistencia { get; set; }
       
     

    }
}
