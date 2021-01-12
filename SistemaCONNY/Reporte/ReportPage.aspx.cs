using CapaDatos.ModeloEntity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCONNY.Reporte
{
    public partial class ReportPage : System.Web.UI.Page
    {
        DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.Params["val"]);
                CargarReporteFactura(id);
            }
            
        }

        public void CargarReporteFactura(int codFac)
        {
            try
            {
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
                                                                   NOMBRE_MARCA = t2.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                                                   FECHA_FACTURA = t1.FECHA_FACTURA,
                                                                   CLIENTE_FACTURA = t1.CLIENTE_FACTURA,
                                                                   DESCRIPCION_ENVASE_UNIDAD = t2.TBL_EXITENCIA.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,
                                                                   Producto = t2.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                   CANTIDAD_PRODUCTOS = t2.CANTIDAD_PRODUCTOS,
                                                                   PRECIO_UNIT = t2.PRECIO_UNIT,
                                                                   SUBTOTAL = t2.SUBTOTAL,
                                                                   TOTAL = t1.TOTAL,
                                                                   CANTIDAD_PAGO = t1.CANTIDAD_PAGO,
                                                                   CAMBIO = t1.CAMBIO,
                                                                   FECHA_VENCIMIENTO = t2.TBL_EXITENCIA.FECHA_VENCIMIENTO_PRODUCTO,
                                                               }));

                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.LocalReport.Refresh();

            }
            catch (Exception ex)
            {

                throw;
            }
            //limpia report viewer


        }
    }
}