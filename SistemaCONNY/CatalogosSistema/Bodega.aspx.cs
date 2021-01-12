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
    public partial class Bodega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MultiView1.ActiveViewIndex = 0;
                CargarDatos();
                LlenarDropCiudad();
            }
            //idBodega.Enabled = false;
        }

        //mandar a llamar la clase de bodega negocio para 
        //acceder a  sus metodos y propieades
        NegocioCatBodega metodosNegocio = new NegocioCatBodega();

        //metodo para cargar los datos
        public void LlenarDropCiudad()
        {
            var datos = metodosNegocio.traerCiudades();
            dropCiudad.DataSource = datos;
            dropCiudad.AppendDataBoundItems = true;
            dropCiudad.DataTextField = ("Seleccione");
            dropCiudad.DataTextField = "NOMBRE_CIUDAD";
            dropCiudad.DataValueField = "ID_CIUDAD";
            dropCiudad.DataBind();

        }

        //metodo para cargar los datos
        //metodo para cargar los datos
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarDatos()
        {
            NegocioCatBodega metodosNegocio = new NegocioCatBodega();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(datos);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            //capturar los elementos escrito en texbox del html
            ObjetoBodega objeto = new ObjetoBodega();
            if (txtNombre.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (dropCiudad.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (txtNombre.Text.Trim() == string.Empty)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if(idBodega.Text == "-1")
            {
                bool resp = metodosNegocio.metodoBusca(txtNombre.Text.Trim());

                if (resp == true)
                {
                    //Response.Write("<script>swal.fire('Advertencia!', 'Dato repetido', 'warning')</script>");
                    string script = "err();";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "pop", script, true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err", script, true);

                    return;
                }
            }
            

            if (idBodega.Text != "-1")
            {
                objeto.IdBodega = Convert.ToInt32(idBodega.Text);
            }

            //ojo aca en la base de dato no estaba autonumerico el codigo
            objeto.NombreBodega = txtNombre.Text.ToString().Trim();
            objeto.IdCiudad = Convert.ToInt32(dropCiudad.SelectedValue);            //ojo aca esto se lo estamos pasando generico y establecido 1 como el codigo de ciudad 
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
            // lb_mensaje.Text = "<div class='alert alert-success' role='alert'> Guardado Satisfactoriamente </ div > ";
            limpiar(this);
            EjecutarModalHide();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeToast", "mensajeToast();", true);
            //EjecutarToast();
            CargarDatos();
            idBodega.Text = "-1";
          
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
            idBodega.Text = "-1";
            //MultiView1.ActiveViewIndex = 0;
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
            NegocioCatBodega metodosNegocio = new NegocioCatBodega();
            var resp = metodosNegocio.metodoEliminar(cod);
            return new JavaScriptSerializer().Serialize(resp);
        }

    }
}