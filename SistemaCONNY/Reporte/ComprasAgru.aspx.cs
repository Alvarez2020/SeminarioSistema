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
    public partial class ComprasAgru : System.Web.UI.Page
    {
        DB_MiscelaneaConnyEntities contex = new DB_MiscelaneaConnyEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                CargarReporteFactura(60);
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