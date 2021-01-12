using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using CapaDatos;
using CapaDatos.ModeloEntity;

namespace SistemaCONNY.HistoricoYExistencia
{
    public partial class HistoricoVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarDatos();
                CargarDatos1();
                //Session["CodFac"] = "";
                int opc = 0, cod = 0;
                string codFacC = "";
                if (Session["codFacC"] != null)
                {
                    codFacC = Session["codFacC"].ToString();
                }

                if (codFacC != "")
                {
                    cod = Convert.ToInt32(codFacC);
                    opc = 1;
                }

                switch (opc)
                {
                    case 1:
                        CargarReporteFactura1(cod);
                        break;
                    default:
                        CargarReporte(100);
                        break;
                }

            }
        }
        DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

        public void CargarReporteFactura1(int codFacC)
        {

            //limpia report viewer
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource datasource = new ReportDataSource();

            //carga directorio de reporte
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/Factura.rdlc");
            //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
            datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_FACTURA
                                                           join t2 in contex.TBL_DETALLE_FACT on t1.ID_FACTURA equals t2.ID_FACTURA
                                                           where t1.ID_FACTURA == codFacC
                                                           select new
                                                           {
                                                               ID_FACTURA = t1.ID_FACTURA,
                                                               FECHA_FACTURA = t1.FECHA_FACTURA,
                                                               CLIENTE_FACTURA = t1.CLIENTE_FACTURA,
                                                               Producto = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                               CANTIDAD_PRODUCTOS = t2.CANTIDAD_PRODUCTOS,
                                                               PRECIO_UNIT = t2.PRECIO_UNIT,
                                                               SUBTOTAL = t2.SUBTOTAL
                                                           }));
  

            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();


        }
        public void CargarReporte(int tipo)
        {

            //limpia report viewer
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource datasource = new ReportDataSource();

            switch (tipo)
            {
                //case 2: //historico de venta
                //    //carga directorio de reporte
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/Ventas.rdlc");
                //    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                //    datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_FACTURA
                //                                                   join t2 in contex.TBL_DETALLE_FACT on t1.ID_FACTURA equals t2.ID_FACTURA
                //                                                   select new
                //                                                   {
                //                                                       ID_FACTURA = t1.ID_FACTURA,
                //                                                       FECHA_FACTURA = t1.FECHA_FACTURA,
                //                                                       CLIENTE_FACTURA = t1.CLIENTE_FACTURA,
                //                                                       Producto = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                //                                                       CANTIDAD_PRODUCTOS = t2.CANTIDAD_PRODUCTOS,
                //                                                       PRECIO_UNIT = t2.PRECIO_UNIT,
                //                                                       SUBTOTAL = t2.SUBTOTAL,
                //                                                       TOTAL = 0,
                //                                                       CANTIDAD_PAGO = 0,
                //                                                       CAMBIO = 0
                //                                                   }));
                //    break;
                case 3: //historico de compra
                    //carga directorio de reporte
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/Ventas.rdlc");
                    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                    datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_FACTURA
                                                                   join t2 in contex.TBL_DETALLE_FACT on t1.ID_FACTURA equals t2.ID_FACTURA
                                                                   select new
                                                                   {
                                                                       ID_FACTURA = t1.ID_FACTURA,
                                                                       FECHA_FACTURA = t1.FECHA_FACTURA,
                                                                       CLIENTE_FACTURA = t1.CLIENTE_FACTURA,
                                                                       Producto = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                       CANTIDAD_PRODUCTOS = t2.CANTIDAD_PRODUCTOS,
                                                                       PRECIO_UNIT = t2.PRECIO_UNIT,
                                                                       SUBTOTAL = t2.SUBTOTAL,
                                                                       TOTAL = 0,
                                                                       CANTIDAD_PAGO = 0,
                                                                       CAMBIO = 0
                                                                   }));
                    break;
                case 4: // exisitencias
                    //carga directorio de reporte
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/ReporteRegistroVenta.rdlc");
                    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                    datasource = new ReportDataSource("DataSet1", (from variableAlmacenado in contex.TBL_DETALLE_FACT
                                                                   join pro in contex.TBL_FACTURA on variableAlmacenado.ID_FACTURA equals pro.ID_FACTURA
                                                                   //join u in contex.CAT_UNIDADMEDIDA_ENVASE on variableAlmacenado.ID_UNIDAD_ENVASE equals u.ID_UNIDAD_ENVASE

                                                                   select new
                                                                   {

                                                                       ID_FACTURA = variableAlmacenado.ID_FACTURA,
                                                                       ID_EXISTENCIA = variableAlmacenado.ID_EXISTENCIA,
                                                                       ID_MARCA = variableAlmacenado.TBL_EXITENCIA.TBL_PRODUCTO.TblMarca.ID_MARCA,
                                                                       Producto = variableAlmacenado.TBL_EXITENCIA.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                       NOMBRE_MARCA = variableAlmacenado.TBL_EXITENCIA.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                                                       CANTIDAD_PRODUCTOS = variableAlmacenado.CANTIDAD_PRODUCTOS,
                                                                       PRECIO_UNIT = variableAlmacenado.PRECIO_UNIT,
                                                                       SUBTOTAL = variableAlmacenado.SUBTOTAL,
                                                                       TOTAL = variableAlmacenado.TBL_FACTURA.TOTAL,
                                                                       CANTIDAD_PAGO = variableAlmacenado.TBL_FACTURA.CANTIDAD_PAGO,
                                                                       CAMBIO = variableAlmacenado.TBL_FACTURA.CAMBIO,
                                                                       DESCRIPCION_ENVASE_UNIDAD = variableAlmacenado.TBL_EXITENCIA.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,


                                                                       FECHA_FACTURA = variableAlmacenado.TBL_FACTURA.FECHA_FACTURA

                                                                   }));
                    break;
                default:
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/Reportes.rdlc");
                    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                    datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_FACTURA select new { }));
                    break;
            }

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();


        }
        protected void btnFactura1_Click(object sender, EventArgs e)
        {
            if (txtCod1.Text == "")
            {
                return;
            }
            int codFacC = int.Parse(txtCod1.Text);

            CargarReporteFactura1(codFacC);

            //if (txtCod1.Text == "")
            //{
            //    return;
            //}
        }
        protected void btnCompra_Click(object sender, EventArgs e)
        {
            CargarReporte(3);
        }
        protected void btnRegistroCompra_Click(object sender, EventArgs e)
        {
            CargarReporte(4);
        }


        //public void LlenarDropCiudad()
        //{
        //    var datos = metodosNegocio.traerCiudades();
        //    dropCiudad.DataSource = datos;
        //    dropCiudad.DataTextField = "NOMBRE_CIUDAD";
        //    dropCiudad.DataValueField = "ID_CIUDAD";
        //    dropCiudad.DataBind();

        //}
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarDatos()
        {
            DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

            var consulta = (from variableAlmacenado in contex.TBL_FACTURA
                            join var in contex.TBL_DETALLE_FACT on variableAlmacenado.ID_FACTURA equals var.ID_FACTURA

                            select new

                            {

                                ID_FACTURA = variableAlmacenado.ID_FACTURA,
                                FECHA_FACTURA = variableAlmacenado.FECHA_FACTURA,
                                CANTIDAD_PRODUCTO = var.CANTIDAD_PRODUCTOS,


                            }).ToList();

            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(consulta);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CargarDatos1()
        {
            DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

            var consulta = (from variableAlmacenado in contex.TBL_DETALLE_FACT
                            select new
                            {
                                ID_FACTURA = variableAlmacenado.ID_FACTURA,
                                ID_EXISTENCIA = variableAlmacenado.ID_EXISTENCIA,
                                ID_MARCA = variableAlmacenado.TBL_EXITENCIA.TBL_PRODUCTO.TblMarca.ID_MARCA,
                                NOMBRE_PRODUCTO = variableAlmacenado.TBL_EXITENCIA.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                NOMBRE_MARCA = variableAlmacenado.TBL_EXITENCIA.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                CANTIDAD_PRODUCTO = variableAlmacenado.CANTIDAD_PRODUCTOS,
                                PRECIO_UNIT = variableAlmacenado.PRECIO_UNIT,
                                SUB_TOTAL = variableAlmacenado.SUBTOTAL,
                                TOTAL = variableAlmacenado.TBL_FACTURA.TOTAL,
                                CANTIDAD_PAGO = variableAlmacenado.TBL_FACTURA.CANTIDAD_PAGO,
                                CAMBIO = variableAlmacenado.TBL_FACTURA.CAMBIO,
                                DESCRIPCION_ENVASE_UNIDAD = variableAlmacenado.TBL_EXITENCIA.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,


                                FECHA_FACTURA = variableAlmacenado.TBL_FACTURA.FECHA_FACTURA


                            }).ToList();

            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(consulta);
        }



    }
}