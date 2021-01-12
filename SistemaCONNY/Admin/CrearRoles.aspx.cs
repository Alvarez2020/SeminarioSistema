using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SistMoropotenteWS.Administrador.Admin
{
    public partial class CrearRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRolesInGrid();
            }
        }

        private void DisplayRolesInGrid()
        {
            //Cargando Clase predeterminada de roles consulndo la base de dato
           RoleList.DataSource = Roles.GetAllRoles();
           RoleList.DataBind();
        }

        protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Captura el Rol a Eliminar
            Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;
            // Elimina el Rol Seleccionado
            Roles.DeleteRole(RoleNameLabel.Text, false);
            // Recarga la grid
            DisplayRolesInGrid();
        }

        protected void CreateRoleButton_Click(object sender, EventArgs e)
        {
            string newRoleName = RoleName.Text.Trim();
            if (!Roles.RoleExists(newRoleName))
                // Creando el Role
                Roles.CreateRole(newRoleName);
            RoleName.Text = string.Empty;

            //Recargar Grid
            DisplayRolesInGrid();
        }
    }
}