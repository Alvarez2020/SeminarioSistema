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
    public partial class ReporteRegistroV : System.Web.UI.Page
    {
        DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporteFactura(60);
            }
            //int id = int.Parse(Request.Params["val"]);

        }

        public void CargarReporteFactura(int codFac)
        {

            //limpia report viewer
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource datasource = new ReportDataSource();

            //carga directorio de reporte
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/ReporteRegistroVenta.rdlc");
            //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
            datasource = new ReportDataSource("DataSet1", (from variableAlmacenado in contex.TBL_DETALLE_FACT
                                                           join pro in contex.TBL_FACTURA on variableAlmacenado.ID_FACTURA equals pro.ID_FACTURA
                                                           //join u in contex.CAT_UNIDADMEDIDA_ENVASE on variableAlmacenado.ID_UNIDAD_ENVASE equals u.ID_UNIDAD_ENVASE

                                                           select new
                                                           {

                                                               ID_FACTURA = variableAlmacenado.ID_FACTURA,
                                                               id_detalle_factura = variableAlmacenado.idDetalleFactura,
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

            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();


        }
    }
}