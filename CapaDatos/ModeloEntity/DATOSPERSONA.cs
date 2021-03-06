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
    
    public partial class DATOSPERSONA
    {
        public DATOSPERSONA()
        {
            this.CAT_TELEFONO = new HashSet<CAT_TELEFONO>();
        }
    
        public int ID_PERSONA { get; set; }
        public string PRIMER_NOMBRE_PERSONA { get; set; }
        public string SEGUNDO_NOMBRE_PERSONA { get; set; }
        public string PRIMER_APELLIDO_PERSONA { get; set; }
        public string SEGUNDO_APELLIDO_PERSONA { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO_PERSONA { get; set; }
        public string NUMERO_IDENTIDAD_PERSONA { get; set; }
        public string DIRECCION_RESIDENCIA_PERSONA { get; set; }
        public Nullable<int> ID_CIUDAD_RESIDENCIA_PERSONA { get; set; }
        public Nullable<int> ID_SEXO_PERSONA { get; set; }
    
        public virtual CAT_CIUDAD CAT_CIUDAD { get; set; }
        public virtual CAT_SEXO CAT_SEXO { get; set; }
        public virtual ICollection<CAT_TELEFONO> CAT_TELEFONO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
