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
    public partial class VentaInd : System.Web.UI.Page
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/VentaInd.rdlc");
                //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_DETALLE_FACT
                                                             
                                                               where t1.idDetalleFactura == codFac
                                                               select new
                                                               {
                                                                   ID_FACTURA = t1.ID_FACTURA,
                                                                   id_detalle_factura = t1.idDetalleFactura,
                                                                   NOMBRE_MARCA = t1.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                                                   FECHA_FACTURA = t1.TBL_FACTURA.FECHA_FACTURA,
                                                                   CLIENTE_FACTURA = t1.TBL_FACTURA.CLIENTE_FACTURA,
                                                                   DESCRIPCION_ENVASE_UNIDAD = t1.TBL_EXITENCIA.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD,
                                                                   Producto = t1.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                   CANTIDAD_PRODUCTOS = t1.CANTIDAD_PRODUCTOS,
                                                                   PRECIO_UNIT = t1.PRECIO_UNIT,
                                                                   SUBTOTAL = t1.SUBTOTAL,
                                                                   TOTAL = t1.TBL_FACTURA.TOTAL,
                                                                   CANTIDAD_PAGO = t1.TBL_FACTURA.CANTIDAD_PAGO,
                                                                   CAMBIO = t1.TBL_FACTURA.CAMBIO,
                                                                   FECHA_VENCIMIENTO = t1.TBL_EXITENCIA.FECHA_VENCIMIENTO_PRODUCTO,
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