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
    
    public partial class CAT_DEPARTAMENTO
    {
        public CAT_DEPARTAMENTO()
        {
            this.CAT_CIUDAD = new HashSet<CAT_CIUDAD>();
        }
    
        public int ID_DEPARTAMENTO { get; set; }
        public string NOMBRE_DEPARTAMENTO { get; set; }
        public Nullable<int> ID_PAIS_DEPARTAMENTO { get; set; }
    
        public virtual ICollection<CAT_CIUDAD> CAT_CIUDAD { get; set; }
        public virtual CAT_PAIS CAT_PAIS { get; set; }
    }
}
