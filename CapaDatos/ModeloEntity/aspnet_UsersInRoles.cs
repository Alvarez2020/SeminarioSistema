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
    
    public partial class aspnet_UsersInRoles
    {
        public System.Guid UserId { get; set; }
        public System.Guid RoleId { get; set; }
    
        public virtual aspnet_Roles aspnet_Roles { get; set; }
        public virtual aspnet_Roles aspnet_Roles1 { get; set; }
        public virtual aspnet_Users aspnet_Users { get; set; }
        public virtual aspnet_Users aspnet_Users1 { get; set; }
    }
}