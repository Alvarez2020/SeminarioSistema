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
    
    public partial class TBL_DETALLE_COMPRA
    {
        public int ID_COMPRA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public Nullable<int> CANTIDAD_PRODUCTOS { get; set; }
        public Nullable<decimal> PRECIO_COMPRA { get; set; }
        public Nullable<decimal> PRECIO_VENTA { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public int ID_UNIDAD_MEDIDA { get; set; }
        public Nullable<int> ID_UNIDAD_ENVASE { get; set; }
        public int idDetalleCompra { get; set; }
    
        public virtual CAT_UNIDAD_MEDIDA CAT_UNIDAD_MEDIDA { get; set; }
        public virtual CAT_UNIDADMEDIDA_ENVASE CAT_UNIDADMEDIDA_ENVASE { get; set; }
        public virtual TBL_COMPRA TBL_COMPRA { get; set; }
        public virtual TBL_PRODUCTO TBL_PRODUCTO { get; set; }
    }
}
