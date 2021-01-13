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

using CapaNegocio;

namespace SistemaCONNY.Historico
{
    public partial class HistoricoCompra : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/ReporteCompra.rdlc");
            //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
            datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_COMPRA
                                                           join t2 in contex.TBL_DETALLE_COMPRA on t1.ID_COMPRA equals t2.ID_COMPRA
                                                           where t1.ID_COMPRA == codFacC
                                                           select new
                                                           {
                                                               ID_COMPRA = t1.ID_COMPRA,
                                                               FECHA_COMPRA = t1.FECHA_COMPRA,
                                                               //CLIENTE_FACTURA = t1.CLIENTE_FACTURA,
                                                               Producto = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                               CANTIDAD_PRODUCTOS = t2.CANTIDAD_PRODUCTOS,
                                                               PRECIO_VENTA = t2.PRECIO_VENTA,
                                                               PRECIO_COMPRA = t2.PRECIO_COMPRA,
                                                               TOTAL = t2.SUBTOTAL,
                                                               UM_DESCRIPCION = t2.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                                               UNIDADES = t2.CAT_UNIDAD_MEDIDA.UNIDADES,
                                                               DESCRIPCION_ENVASE_UNIDAD = t2.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD
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
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/Compras.rdlc");
                    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                    datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_COMPRA
                                                                   join t2 in contex.TBL_DETALLE_COMPRA on t1.ID_COMPRA equals t2.ID_COMPRA
                                                                   select new
                                                                   {
                                                                       ID_COMPRA = t1.ID_COMPRA,
                                                                       FECHA_COMPRA = t1.FECHA_COMPRA,
                                                                       CANTIDAD_PRODUCTOS = t2.CANTIDAD_PRODUCTOS,
                                                                       PRECIO_COMPRA = t2.PRECIO_COMPRA,
                                                                       TOTAL = t2.SUBTOTAL,
                                                                       NOMBRE_PRODUCTO = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                       UM_DESCRIPCION = t2.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                                                       UNIDADES = t2.CAT_UNIDAD_MEDIDA.UNIDADES
                                                                   }));
                    break;
                case 4: // exisitencias
                    //carga directorio de reporte
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/ReporteRegistroCompra.rdlc");
                    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                    datasource = new ReportDataSource("DataSet1", (from variableAlmacenado in contex.TBL_DETALLE_COMPRA
                                                                   join pro in contex.TBL_PRODUCTO on variableAlmacenado.ID_PRODUCTO equals pro.ID_PRODUCTO
                                                                   //join u in contex.CAT_UNIDADMEDIDA_ENVASE on variableAlmacenado.ID_UNIDAD_ENVASE equals u.ID_UNIDAD_ENVASE
                                                                   
                                                                   select new
                                                                   {

                                                                       ID_COMPRA = variableAlmacenado.ID_COMPRA,
                                                                       ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                                                                       ID_MARCA = variableAlmacenado.TBL_PRODUCTO.ID_MARCA,
                                                                       Producto= variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                       NOMBRE_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                                                       CANTIDAD_PRODUCTOS = variableAlmacenado.CANTIDAD_PRODUCTOS,
                                                                       PRECIO_COMPRA = variableAlmacenado.PRECIO_COMPRA,
                                                                       PRECIO_VENTA = variableAlmacenado.PRECIO_VENTA,
                                                                       TOTAL = variableAlmacenado.SUBTOTAL,
                                                                       ID_UNIDAD_MEDIDA = variableAlmacenado.ID_UNIDAD_MEDIDA,
                                                                       UM_DESCRIPCION = variableAlmacenado.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                                                       UNIDADES = variableAlmacenado.CAT_UNIDAD_MEDIDA.UNIDADES,
                                                                       FECHA_COMPRA = variableAlmacenado.TBL_COMPRA.FECHA_COMPRA,

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

            var consulta = (from variableAlmacenado in contex.TBL_COMPRA
                            join var in contex.TBL_DETALLE_COMPRA on variableAlmacenado.ID_COMPRA equals var.ID_COMPRA
                          
                            select new

                            {

                                ID_Compra = variableAlmacenado.ID_COMPRA,
                                FECHA_COMPRA = variableAlmacenado.FECHA_COMPRA,
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

            var consulta = (from variableAlmacenado in contex.TBL_DETALLE_COMPRA
                            select new 
                            {
                                ID_COMPRA = variableAlmacenado.ID_COMPRA,
                                ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                                ID_MARCA = variableAlmacenado.TBL_PRODUCTO.ID_MARCA,
                                NOMBRE_PRODUCTO = variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                NOMBRE_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                CANTIDAD_PRODUCTO = variableAlmacenado.CANTIDAD_PRODUCTOS,
                                PRECIO_COMPRA = variableAlmacenado.PRECIO_COMPRA,
                                PRECIO_VENTA = variableAlmacenado.PRECIO_VENTA,
                                TOTAL = variableAlmacenado.SUBTOTAL,
                                ID_UNIDAD_MEDIDA = variableAlmacenado.ID_UNIDAD_MEDIDA,
                                UM_DESCRIPCION = variableAlmacenado.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                UNIDADES = variableAlmacenado.CAT_UNIDAD_MEDIDA.UNIDADES,
                                FECHA_COMPRA = variableAlmacenado.TBL_COMPRA.FECHA_COMPRA,


                            }).ToList();

            //gridBodega.DataSource = datos;
            //gridBodega.DataBind();
            return new JavaScriptSerializer().Serialize(consulta);
        }
    }
}