using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SistMoropotenteWS.Administrador.Admin
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                
                if (!IsPostBack)
                {
                    MultiViewUser.ActiveViewIndex = 0;
                    DisplayRolesInGrid();
                }
        }
        //metodo para limpiar los datos
        public void limpiar(Control control)
        {
            var textbox = control as TextBox;
            if (textbox != null)
                textbox.Text = string.Empty;

            var dropDownList = control as DropDownList;
            if (dropDownList != null)
                dropDownList.SelectedIndex = 0;

            foreach (Control childControl in control.Controls)
            {
                limpiar(childControl);
            }
        }
        private void DisplayRolesInGrid()
        {
            string[] roles = Roles.GetAllRoles();
            DropRoles.DataSource = roles;
            DropRoles.DataBind();

            RoleList.DataSource = roles;
            RoleList.DataBind();
        }

        public string GuardaUsuario()
        {
            string resp = "";
            MembershipCreateStatus createStatus;
            try
            {

                MembershipUser user = Membership.CreateUser(txtNombreUsuario.Text, txtPassword.Text, txtEmail.Text, DropPregunta.SelectedValue,
                        txtRespuesta.Text,
                         true, out createStatus);
                switch (createStatus)
                {
                    case MembershipCreateStatus.Success:
                        resp = "Correcto";
                        Roles.AddUserToRole(txtNombreUsuario.Text, DropRoles.Text);//Agrega el Rol de Estudiante al usuario                         
                        break;
                    // This Case Occured whenver we send duplicate UserName
                    case MembershipCreateStatus.DuplicateUserName:

                        resp = "Un usuario con el mismo nombre ya existe!";
                        break;
                    //This Case Occured whenver we give duplicate mail id
                    case MembershipCreateStatus.DuplicateEmail:

                        resp = "Un usuario con la misma dirección de correo electrónico ya existe!";
                        break;
                    //This Case Occured whenver we send invalid mail format
                    case MembershipCreateStatus.InvalidEmail:

                        resp = "La dirección de correo electrónico que proporcionó no es válido.";
                        break;


                    //This Case Occured whenver we send empty data or Invalid Data
                    case MembershipCreateStatus.InvalidAnswer:

                        resp = "La respuesta de seguridad no es válida.";
                        break;
                    // This Case Occured whenver we supplied weak password
                    case MembershipCreateStatus.InvalidPassword:

                        resp = "La contraseña que ha proporcionado no es válido. Debe ser 7 caracteres de longitud y tener al menos 1 carácter especial";
                        break;
                    default:

                        resp = "Se ha producido un error desconocido: La cuenta de usuario no se ha creado.";
                        break;
                }
                return resp;
            }
            catch (Exception)
            {

                return "Error";
            }
        }

        protected void UserLists_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void DisplayUsersBelongingToRole()
        {
            // Get the selected role
            string selectedRoleName = RoleList.SelectedValue;

            // Get the list of usernames that belong to the role
            string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

            // Bind the list of users to the GridView
            RolesUserList.DataSource = usersBelongingToRole;
            RolesUserList.DataBind();
        }

        private void BindUsersToUserList()
        {
            // Get all of the user accounts
            MembershipUserCollection users = Membership.GetAllUsers();
            UserLists.DataSource = users;
            UserLists.DataBind();
        }

        protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the selected role
            string selectedRoleName = RoleList.SelectedValue;

            // Reference the UserNameLabel
            Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

            // Remove the user from the role
            Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

            // Refresh the GridView
            DisplayUsersBelongingToRole();

        }

        protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayUsersBelongingToRole();
        }

        protected void AddUserToRoleButton_Click(object sender, EventArgs e)
        {
            // Get the selected role and username
            string selectedRoleName = RoleList.SelectedValue;
            string userNameToAddToRole = UserNameToAddToRole.Text;

            // Make sure that a value was entered
            if (userNameToAddToRole.Trim().Length == 0)
            {
                ActionStatus.Text = "Ingrese un nombre de Usuario en la Caja de Texto.";
                return;
            }

            // Make sure that the user exists in the system
            MembershipUser userInfo = Membership.GetUser(userNameToAddToRole);
            if (userInfo == null)
            {
                ActionStatus.Text = string.Format("El Usuario {0} no existe en el Sistema.", userNameToAddToRole);
                return;
            }

            // Make sure that the user doesn't already belong to this role
            if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName))
            {
                ActionStatus.Text = string.Format("Usuario {0} Actualmente es miembro del rol {1}.", userNameToAddToRole, selectedRoleName);
                return;
            }

            // If we reach here, we need to add the user to the role
            Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);

            // Clear out the TextBox
            UserNameToAddToRole.Text = string.Empty;

            // Refresh the GridView
            DisplayUsersBelongingToRole();

            // Display a status message
            ActionStatus.Text = string.Format("Usuario {0} a sido añadido al rol {1}.", userNameToAddToRole, selectedRoleName);

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            GuardaUsuario();
            limpiar(this);
        }

        protected void btnMRoles_Click(object sender, EventArgs e)
        {
            BindUsersToUserList();
            MultiViewUser.ActiveViewIndex = 1;
        }
    }
}