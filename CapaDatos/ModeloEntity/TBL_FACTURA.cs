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
    
    public partial class TBL_FACTURA
    {
        public TBL_FACTURA()
        {
            this.TBL_DETALLE_FACT = new HashSet<TBL_DETALLE_FACT>();
        }
    
        public int ID_FACTURA { get; set; }
        public Nullable<System.DateTime> FECHA_FACTURA { get; set; }
        public Nullable<int> ID_BODEGA_FACTURA { get; set; }
        public string CLIENTE_FACTURA { get; set; }
        public Nullable<int> ID_USUARIO_FACTURA { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public Nullable<decimal> CANTIDAD_PAGO { get; set; }
        public Nullable<decimal> CAMBIO { get; set; }
    
        public virtual ICollection<TBL_DETALLE_FACT> TBL_DETALLE_FACT { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
