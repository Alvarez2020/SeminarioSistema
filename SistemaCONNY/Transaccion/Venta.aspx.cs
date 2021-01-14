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

namespace SistemaCONNY.Transaccion
{
    public partial class Venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarExistencias()
        {
            NegocioExistencia exist = new NegocioExistencia();
            var datos = exist.metodoMostrarListaDatos();
            return new JavaScriptSerializer().Serialize(datos);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarDatos()
        {
            var datos = ListaDetalle.ToList();
            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(datos);
        }

        //declara una lista con las variables del objeto para transaccion de compra
        public static List<ObjetoVenta> ListaDetalle = new List<ObjetoVenta>();
       // public static decimal total = 0;
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarListaDetalleVenta(ObjetoVenta temp)
        {
            decimal total = 0;

            NegocioCatUnidadMedida metodosNegocio = new NegocioCatUnidadMedida();
            int? cod = temp.ID_UNIDAD_MEDIDA;
            var datos = metodosNegocio.metodoSeleccion1(cod);
            temp.SUBTOTAL = (decimal)((temp.CANTIDAD_PRODUCTOS * datos.Unidades) * temp.PRECIO_VENTA);
            ListaDetalle.Add(new ObjetoVenta
            {
                ID = Guid.NewGuid(),
                ID_PRODUCTO = temp.ID_PRODUCTO,
                CLIENTE_FACTURA = temp.CLIENTE_FACTURA,
                NOMBRE_PRODUCTO = temp.NOMBRE_PRODUCTO,
                NOMBRE_MARCA = temp.NOMBRE_MARCA,
                ID_UNIDAD_MEDIDA = temp.ID_UNIDAD_MEDIDA,
                UM_DESCRIPCION = temp.UM_DESCRIPCION,
                CANTIDAD_PRODUCTOS = temp.CANTIDAD_PRODUCTOS,
                CANTIDAD_PAGO = temp.CANTIDAD_PAGO,
                PRECIO_VENTA = temp.PRECIO_VENTA,
                ID_USUARIO = 1,
                SUBTOTAL = temp.SUBTOTAL,
               // CAMBIO = temp.CAMBIO,
                ID_EXISTENCIA = temp.ID_EXISTENCIA,
                ID_BODEGA_FACTURA = temp.ID_BODEGA_FACTURA
            });
          
            //cuando se agregue un produto recorre los subtotales y los suma por cada item
            foreach (var item in ListaDetalle)
            {
                total = (decimal)(total + item.SUBTOTAL);
            }
           
            var resp = "correcto";
            return new JavaScriptSerializer().Serialize(total);
        }

        //Eliminar probando

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string EliminarDetalle(string codigo)
        {
            var obj = ListaDetalle.FirstOrDefault(x => x.ID.ToString() == codigo.ToString());
            ListaDetalle.Remove(obj);
            var resp = "ok";
            return new JavaScriptSerializer().Serialize(resp);
        }


        public void FinalizarTransaccion()
        {
            ObjetoVenta variable = new ObjetoVenta();
            variable.FECHA_FACTURA = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            variable.CANTIDAD_PAGO = Convert.ToDecimal(txtCantidadPago.Text);
            variable.TOTAL = Convert.ToDecimal(txtTotal.Text);
            variable.CAMBIO = Convert.ToDecimal(txtCambio.Text);
            NegocioTranasaccionVenta metodoNeogico = new NegocioTranasaccionVenta();
            var result = metodoNeogico.FinalizaTransaccion(variable, ListaDetalle);
            Application["CodFac"] = result;
            Response.Write("<script>");
            Response.Write("window.open('Reporte/ReportPage.aspx?val=" + result + "')");
            Response.Write("</script>");
            //Response.Redirect("~/Reporte/Reportes.aspx");
            //if (result != 0)
            //{

            //    //mesanje satisfactorio
            //}
            //else
            //{
            //    //mensnaje error
            //}
        }

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

        //protected void btnAgregar_Click(object sender, EventArgs e)
        //{
        //   // GuardarListaDetalleCompra();
        //}

        protected void GuardarTransac_Click(object sender, EventArgs e)
        {
            if (txtCantidadPago.Text == "")
            {
                return;
            }
            FinalizarTransaccion();
            limpiar(this);
            ListaDetalle.Clear();
        }

        protected void txtCantidadPago_TextChanged(object sender, EventArgs e)
        {
            decimal tot = Convert.ToDecimal(txtTotal.Text);
            decimal camb = Convert.ToDecimal(txtCantidadPago.Text);

            decimal cambC = camb - tot;
            txtCambio.Text = cambC.ToString();
        }
    }
}