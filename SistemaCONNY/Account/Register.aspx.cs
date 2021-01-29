using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SistemaCONNY.Models;
using CapaDatos.ModeloEntity;

namespace SistemaCONNY.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = new ApplicationDbContext();
                CargarRolesAsp(db);
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //var DB = new defa();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };

            //var VarUserManagertoRol = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>(DB));

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");
                //VarUserManagertoRol.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "Caja");
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void CargarRolesAsp(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var dataRol = roleManager.Roles.ToList();
            dropRole.DataSource = dataRol;
            dropRole.DataTextField = "Name";
            dropRole.DataValueField = "Id";
            dropRole.DataBind();
        }
    }
}