using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace SistemaCONNY.CatalogosSistema
{
    public partial class Pais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // MultiView1.ActiveViewIndex = 0;
                CargarDatos();
            }
        }

        //mandar a llamar la clase de bodega negocio para 
        //acceder a  sus metodos y propieades
        NegocioCatPais metodosNegocio = new NegocioCatPais();

        //metodo para cargar los datos
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarDatos()
        {
            NegocioCatPais metodosNegocio = new NegocioCatPais();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            //gridPais.DataSource = datos;
            // gridPais.DataBind();
            return new JavaScriptSerializer().Serialize(datos);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //capturar los elementos escrito en texbox del html
            ObjetoPais objeto = new ObjetoPais();
            
            if (txtPais.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            
            if (txtPais.Text.Trim() == string.Empty)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (IdPais.Text == "-1")
            {
                bool resp = metodosNegocio.metodoBusca(txtPais.Text.Trim());

                if (resp == true)
                {
                    //Response.Write("<script>swal.fire('Advertencia!', 'Dato repetido', 'warning')</script>");
                    string script = "err();";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "pop", script, true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err", script, true);

                    return;
                }
            }

            if (IdPais.Text != "-1")
            {
                objeto.IdPais = Convert.ToInt32(IdPais.Text);
            }

            //ojo aca en la base de dato no estaba autonumerico el codigo
            objeto.NombrePais = txtPais.Text.ToString().Trim();
            //ojo aca esto se lo estamos pasando generico y establecido 1 como el codigo de ciudad 
            //esto no deberia ser asi ma;ana lo vemos

            //mandar a guardar o true o false
            var valorRespuesta = metodosNegocio.metodoguardarNeg(objeto);

            //si hubo error
            if (valorRespuesta == false)
            {  //no se guardo
               // lb_mensaje.Text = "<div class='alert alert-danger' role='alert'> No se guardo </ div > ";
            }
            else
            {
                string script = "err1();";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "pop", script, true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err1", script, true);
            }
            //lb_mensaje.Text = "<div class='alert alert-success' role='alert'> Guardado Satisfactoriamente </ div > ";
            limpiar(this);
            EjecutarModalHide();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeToast", "mensajeToast();", true);
            //EjecutarToast();
            CargarDatos();
            IdPais.Text = "-1";
        }


        public void EjecutarModalHide()
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
        }
        public void EjecutarToast()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeToast", "mensajeToast();", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar(this);
            EjecutarModalHide();
            IdPais.Text = "-1";
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string suprData(string codigo)
        {
            int cod = int.Parse(codigo);
            NegocioCatPais metodosNegocio = new NegocioCatPais();
            var resp = metodosNegocio.metodoEliminar(cod);
            return new JavaScriptSerializer().Serialize(resp);
        }

        //protected void gridPais_RowCommand1(object sender, GridViewCommandEventArgs e)
        //    {
        //        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //        int indice = row.RowIndex;
        //        int Codigo = Convert.ToInt32(gridPais.DataKeys[indice].Value);

        //        if (e.CommandName == "cmEditar")
        //        {
        //            var BuscarDato = metodosNegocio.metodoSeleccion(Codigo);
        //            txtPais.Text = BuscarDato.NombrePais;
        //            IdPais.Text = BuscarDato.IdPais.ToString();
        //            btnGuardar.Text = "Actualizar";
        //            MultiView1.ActiveViewIndex = 1;
        //        }
        //        if (e.CommandName == "cmEliminar")
        //        {   //elimnar el codigo del registro seleccionado
        //            metodosNegocio.metodoEliminar(Codigo);
        //            CargarDatos();
        //        }
        //    }
    }
}