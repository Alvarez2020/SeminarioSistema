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

namespace SistemaCONNY.HistoricoYExistencia
{
    public partial class Existencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                LlenarBodega();
            }
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
            NegocioExistencia metodosNegocio = new NegocioExistencia();
            var datos = metodosNegocio.metodoMostrarListaDatos();
            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(datos);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarDatos(int id)
        {
            NegocioExistencia metodosNegocio = new NegocioExistencia();
            var datos = metodosNegocio.metodoMostrarListaDatos(id);
            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(datos);
        }

    }
}