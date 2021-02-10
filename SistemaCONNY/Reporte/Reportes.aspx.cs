using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using CapaDatos;
using CapaDatos.ModeloEntity;
using CapaNegocio;

namespace SistemaCONNY.Reporte
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["CodFac"] = "";
                int opc = 0, cod=0;
                string codFac="";
                if (Session["CodFac"] != null)
                {
                    codFac = Session["CodFac"].ToString();
                }
              
                if (codFac!="")
                {
                    cod = Convert.ToInt32(codFac);
                    opc = 1;
                }

                switch (opc)
                {
                    case 1:
                        CargarReporteFactura(cod);
                        break;
                    default:
                        CargarReporte(100);
                        break;
                }
               
            }
        }
        DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

        public void CargarReporteFactura(int codFac)
        {
            
            //limpia report viewer
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource datasource = new ReportDataSource();

            //carga directorio de reporte
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/TicketVenta.rdlc");
            //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
             datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_FACTURA
                                                                            join t2 in contex.TBL_DETALLE_FACT on t1.ID_FACTURA equals t2.ID_FACTURA
                                                                            where t1.ID_FACTURA == codFac
                                                                            select new
                                                                           {
                                                                               ID_FACTURA = t1.ID_FACTURA,
                                                                               FECHA_FACTURA = t1.FECHA_FACTURA,
                                                                                CLIENTE_FACTURA = t1.CLIENTE_FACTURA,
                                                                                Producto = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                                CANTIDAD_PRODUCTOS =t2.CANTIDAD_PRODUCTOS,
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
                case 2: //historico de venta
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
                                                                       TOTAL = t2.SUBTOTAL
                                                                   }));
                    break;
                case 4: // exisitencias
                    //carga directorio de reporte
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/Existencia.rdlc");
                    //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                    datasource = new ReportDataSource("DataSet1", (from variableAlmacenado in contex.TBL_EXITENCIA
                                                                   join pro in contex.TBL_PRODUCTO on variableAlmacenado.ID_PRODUCTO equals pro.ID_PRODUCTO
                                                                   //join u in contex.CAT_UNIDADMEDIDA_ENVASE on variableAlmacenado.ID_UNIDAD_ENVASE equals u.ID_UNIDAD_ENVASE
                                                                   where variableAlmacenado.CANTIDAD_EXISTENCIA > 0
                                                                   select new
                                                                   {

                                                                       ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                                                                       ID_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.ID_MARCA,
                                                                       ID_BODEGA = (int)variableAlmacenado.ID_BODEGA,
                                                                       NOMBRE_PRODUCTO = variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                       NOMBRE_MARCA = variableAlmacenado.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                                                       NOMBRE_BODEGA = variableAlmacenado.CAT_BODEGA.NOMBRE_BODEGA,
                                                                       CANTIDAD_EXISTENCIA = variableAlmacenado.CANTIDAD_EXISTENCIA,
                                                                       PRECIO_VENTA = variableAlmacenado.PRECIO_VENTA,
                                                                       FECHA_ELABORACION_PRODUCTO = variableAlmacenado.FECHA_ELABORACION_PRODUCTO,
                                                                       FECHA_VENCIMIENTO_PRODUCTO = variableAlmacenado.FECHA_VENCIMIENTO_PRODUCTO,
                                                                       IdExistencia = variableAlmacenado.ID_EXISTENCIA,
                                                                       DESCRIPCION_ENVASE_UNIDAD = variableAlmacenado.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,
                                                                       DescripcionProducto = variableAlmacenado.TBL_PRODUCTO.DESCRIPCION_PRODUCTO,

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

        protected void btnVenta_Click(object sender, EventArgs e)
        {
            CargarReporte(2);
        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            CargarReporte(3);
        }

        protected void btnExis_Click(object sender, EventArgs e)
        {
            CargarReporte(4);
        }

        //protected void btnFactura_Click(object sender, EventArgs e)
        //{
        //    if (txtCod.Text == "")
        //    {
        //        return;
        //    }
        //    int codFac = int.Parse(txtCod.Text);

        //    CargarReporteFactura(codFac);
        //}
    }
}