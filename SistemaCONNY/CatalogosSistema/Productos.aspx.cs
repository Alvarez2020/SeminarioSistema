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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // MultiView1.ActiveViewIndex = 0; 
                CargarProducto();
                LlenardropTipoProducto();
                LlenardropUnidad();
                LlenardropMarca();
            }

        }
        NegocioTblProducto metodosNegocio = new NegocioTblProducto();

        //metodo para cargar los datos
        public void LlenardropTipoProducto()
        {
            var datos = metodosNegocio.traerTipoProducto();
            dropTipoProducto.DataSource = datos;
            dropTipoProducto.AppendDataBoundItems = true;
            dropTipoProducto.DataTextField = ("Seleccione");
            dropTipoProducto.DataTextField = "TIPO_PRODUCTO";
            dropTipoProducto.DataValueField = "ID_TIPO_PRODUCTO";
            dropTipoProducto.DataBind();

        }
        public void LlenardropUnidad()
        {
            var datos = metodosNegocio.traerUnidadMedida();
            dropUnidad.DataSource = datos;
            dropUnidad.AppendDataBoundItems = true;
            dropUnidad.DataTextField = ("Seleccione");
            dropUnidad.DataTextField = "UM_DESCRIPCION";
            dropUnidad.DataValueField = "ID_UNIDAD_MEDIDA";
            dropUnidad.DataBind();

        }
        public void LlenardropMarca()
        {
            var datos = metodosNegocio.traerMarca();
            dropMarca.DataSource = datos;
            dropMarca.AppendDataBoundItems = true;
            dropMarca.DataTextField = ("Seleccione");
            dropMarca.DataTextField = "NOMBRE_MARCA";
            dropMarca.DataValueField = "ID_MARCA";
            dropMarca.DataBind();

        }
        //metodo para cargar los datos
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarProducto()
        {
            NegocioTblProducto metodosNegocio = new NegocioTblProducto();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            // gridProducto.DataSource = datos;
            // gridProducto.DataBind();
            return new JavaScriptSerializer().Serialize(datos);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //capturar los elementos escrito en texbox del html
            ObjetoProducto objeto = new ObjetoProducto();
            if (txtNombre.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (txtNombre.Text.Trim() == string.Empty)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (textDescripcion.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);
               
            }
            if (textDescripcion.Text.Trim() == string.Empty)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (dropTipoProducto.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (dropUnidad.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);

                return;
            }
            if (dropMarca.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);
                
                return;
            }
            if (IdProducto.Text == "0")
            {
                bool resp = metodosNegocio.metodoBusca(txtNombre.Text.Trim(),int.Parse(dropMarca.SelectedValue));

                if (resp == true)
                {
                    //Response.Write("<script>swal.fire('Advertencia!', 'Dato repetido', 'warning')</script>");
                    string script = "err();";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "pop", script, true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err", script, true);

                    return;
                }
            }

          
            if (IdProducto.Text != "0")
            {
                objeto.IdProducto = Convert.ToInt32(IdProducto.Text);
            }

             //ojo aca en la base de dato no estaba autonumerico el codigo
            objeto.NombreProducto = txtNombre.Text.ToString().Trim();
            objeto.DescripcionProducto = textDescripcion.Text.ToString().Trim();
            objeto.IdTipoProducto = Convert.ToInt32(dropTipoProducto.SelectedValue);            //ojo aca esto se lo estamos pasando generico y establecido 1 como el codigo de ciudad 
            objeto.IdUnidadMedida = Convert.ToInt32(dropUnidad.SelectedValue);
            objeto.IdMarca = Convert.ToInt32(dropMarca.SelectedValue);        //esto no deberia ser asi ma;ana lo vemos

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
            CargarProducto();
            IdProducto.Text = "0";
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
            IdProducto.Text = "0";
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
            NegocioTblProducto metodosNegocio = new NegocioTblProducto();
            var resp = metodosNegocio.metodoEliminar(cod);
            return new JavaScriptSerializer().Serialize(resp);
        }

    }
}