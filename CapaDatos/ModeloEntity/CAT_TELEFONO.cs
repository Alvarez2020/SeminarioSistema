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
    
    public partial class CAT_TELEFONO
    {
        public int ID_TELEFONO { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<int> ID_TIPO_TELEFONO { get; set; }
        public Nullable<int> ID_PERSONA_TELEFONO { get; set; }
    
        public virtual DATOSPERSONA DATOSPERSONA { get; set; }
        public virtual CAT_TIPO_TELEFONO CAT_TIPO_TELEFONO { get; set; }
    }
}
