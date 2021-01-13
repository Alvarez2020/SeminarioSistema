using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


using CapaDatos; //objetoCompra 
using CapaNegocio;

namespace SistemaCONNY.Transaccion
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                //LlenardropUnidad();
                LlenarBodega();
                //LlenardropProducto();
                //LlenardropProveedor();
            }
        }

       
        //metodo para cargar los datos
        public void LlenardropUnidad()
        {
            NegocioCatUnidadMedida metodosNegocio = new NegocioCatUnidadMedida();
            var datos = metodosNegocio.metodoMostrarListaDatos1();
            //dropUnidadMedida.DataSource = datos;
            //dropUnidadMedida.AppendDataBoundItems = true;
            //dropUnidadMedida.DataTextField = ("Seleccione");
            //dropUnidadMedida.DataTextField = "UM_DESCRIPCION";
            //dropUnidadMedida.DataValueField = "ID_UNIDAD_MEDIDA";
            //dropUnidadMedida.DataBind();

        }
        public void LlenardropUnidadEnvase()
        {
            NegocioCatUnidadEnvase metodosNegocio = new NegocioCatUnidadEnvase();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            //dropUnidadMedida.DataSource = datos;
            //dropUnidadMedida.AppendDataBoundItems = true;
            //dropUnidadMedida.DataTextField = ("Seleccione");
            //dropUnidadMedida.DataTextField = "UM_DESCRIPCION";
            //dropUnidadMedida.DataValueField = "ID_UNIDAD_MEDIDA";
            //dropUnidadMedida.DataBind();

        }

        public void LlenardropProducto()
        {
            NegocioTblProducto metodosNegocio = new NegocioTblProducto();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            //dropProducto.DataSource = datos;
            //dropProducto.DataTextField = "NombreProducto";
            //dropProducto.DataValueField = "IdProducto";
            //dropProducto.DataBind();

        }

        public void LlenardropProveedor()
        {
            NegocioCatProveedor metodosNegocio = new NegocioCatProveedor();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            //dropProvedor.DataSource = datos;
            //dropProvedor.DataTextField = "NombreProveedor";
            //dropProvedor.DataValueField = "IdProveedor";
            //dropProvedor.DataBind();

        }

        public void LlenarBodega()
        {
            NegocioCatBodega metodosNegocio = new NegocioCatBodega();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            dropBodega.DataSource = datos;
            dropBodega.AppendDataBoundItems = true;
            dropBodega.DataTextField = ("Seleccione");
            dropBodega.DataTextField = "NombreBodega";
            dropBodega.DataValueField = "IdBodega";
            dropBodega.DataBind();
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
        public static List<ObjetoCompra> ListaDetalle = new List<ObjetoCompra>();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarListaDetalleCompra(ObjetoCompra temp)
        {
            decimal total = 0;
            NegocioCatUnidadMedida metodosNegocio = new NegocioCatUnidadMedida();
            int? cod = temp.ID_UNIDAD_MEDIDA;
            var datos = metodosNegocio.metodoSeleccion1(cod);
            temp.SUBTOTAL = (decimal)((temp.CANTIDAD_PRODUCTOS * datos.Unidades) * temp.PRECIO_COMPRA);
            ListaDetalle.Add(new ObjetoCompra
            {
                ID =  Guid.NewGuid(),
                ID_PRODUCTO = temp.ID_PRODUCTO,
                NOMBRE_PRODUCTO = temp.NOMBRE_PRODUCTO,
                NOMBRE_MARCA = temp.NOMBRE_MARCA,
                ID_PROVEEDOR = temp.ID_PROVEEDOR,
                NOMBRE_PROVEEDOR = temp.NOMBRE_PROVEEDOR,
                ID_COMPRA = 0,
                ID_UNIDAD_MEDIDA = temp.ID_UNIDAD_MEDIDA,
                UM_DESCRIPCION = temp.UM_DESCRIPCION,
                ID_UNIDAD_ENVASE = temp.ID_UNIDAD_ENVASE,
                DESCRIPCION_ENVASE_UNIDAD = temp.DESCRIPCION_ENVASE_UNIDAD,
                CANTIDAD_PRODUCTOS = temp.CANTIDAD_PRODUCTOS,
                FECHA_COMPRA = temp.FECHA_COMPRA,
                PRECIO_COMPRA = temp.PRECIO_COMPRA,
                PRECIO_VENTA = temp.PRECIO_VENTA,
                ID_USUARIO = 1,
                SUBTOTAL = temp.SUBTOTAL,
                FECHA_ELABORACION_PRODUCTO = temp.FECHA_ELABORACION_PRODUCTO,
                FECHA_VENCIMIENTO_PRODUCTO = temp.FECHA_VENCIMIENTO_PRODUCTO,
                CANTIDAD_EXISTENCIA = 0,
                CANTIDAD_DEVOLUCION = 0,
                ID_BODEGA = temp.ID_BODEGA
            });
            foreach (var item in ListaDetalle)
            {
                total = (decimal)(total + item.SUBTOTAL);
            }
            var resp = "correcto";
            return new JavaScriptSerializer().Serialize(resp);
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
            ObjetoCompra variable = new ObjetoCompra();
            variable.FECHA_COMPRA = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            variable.CANTIDAD_PAGO = Convert.ToDecimal(txtCantidadPago.Text);
            variable.TOTAL = Convert.ToDecimal(txtTotal.Text);
            variable.CAMBIO = Convert.ToDecimal(txtCambio.Text);
            NegocioTransaccionCompra metodoNeogico = new NegocioTransaccionCompra();
            var result = metodoNeogico.FinalizaTransaccion(variable, ListaDetalle);
            Application["CodFac"] = result;
            Response.Write("<script>");
            Response.Write("window.open('Reporte/ReportPageCompra.aspx?val=" + result + "')");
            Response.Write("</script>");
            //if (result==true)
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