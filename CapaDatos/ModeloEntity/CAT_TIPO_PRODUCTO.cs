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
    
    public partial class CAT_TIPO_PRODUCTO
    {
        public CAT_TIPO_PRODUCTO()
        {
            this.TBL_PRODUCTO = new HashSet<TBL_PRODUCTO>();
        }
    
        public int ID_TIPO_PRODUCTO { get; set; }
        public string TIPO_PRODUCTO { get; set; }
        public string DESCRIPCION_TIPO_PRODUCTO { get; set; }
    
        public virtual ICollection<TBL_PRODUCTO> TBL_PRODUCTO { get; set; }
    }
}
