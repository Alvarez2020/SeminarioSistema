//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos.ModeloEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_EXITENCIA
    {
        public TBL_EXITENCIA()
        {
            this.TBL_DETALLE_FACT = new HashSet<TBL_DETALLE_FACT>();
        }
    
        public int ID_EXISTENCIA { get; set; }
        public Nullable<int> ID_PRODUCTO { get; set; }
        public Nullable<System.DateTime> FECHA_ELABORACION_PRODUCTO { get; set; }
        public string FECHA_VENCIMIENTO_PRODUCTO { get; set; }
        public Nullable<int> ID_BODEGA { get; set; }
        public Nullable<int> CANTIDAD_EXISTENCIA { get; set; }
        public Nullable<int> CANTIDAD_DEVOLUCION { get; set; }
        public Nullable<decimal> PRECIO_VENTA { get; set; }
        public Nullable<int> ID_UNIDAD_ENVASE { get; set; }
    
        public virtual CAT_BODEGA CAT_BODEGA { get; set; }
        public virtual CAT_UNIDADMEDIDA_ENVASE CAT_UNIDADMEDIDA_ENVASE { get; set; }
        public virtual ICollection<TBL_DETALLE_FACT> TBL_DETALLE_FACT { get; set; }
        public virtual TBL_PRODUCTO TBL_PRODUCTO { get; set; }
    }
}
