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
    public partial class CompraInd : System.Web.UI.Page
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/CompraIndi.rdlc");
                //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
                datasource = new ReportDataSource("DataSet1", (from t1 in contex.TBL_DETALLE_COMPRA
                                                      
                                                               where t1.idDetalleCompra == codFac
                                                               select new
                                                               {
                                                                   ID_COMPRA = t1.ID_COMPRA,
                                                                   id_detalle_compra = t1.idDetalleCompra,
                                                                   FECHA_COMPRA = t1.TBL_COMPRA.FECHA_COMPRA,
                                                                   NOMBRE_MARCA = t1.TBL_PRODUCTO.TblMarca.NOMBRE_MARCA,
                                                                   Producto = t1.TBL_PRODUCTO.NOMBRE_PRODUCTO,
                                                                   CANTIDAD_PRODUCTOS = t1.CANTIDAD_PRODUCTOS,
                                                                   PRECIO_VENTA = t1.PRECIO_VENTA,
                                                                   PRECIO_COMPRA = t1.PRECIO_COMPRA,
                                                                   //TOTALF = t2.TOTAL,
                                                                   //CANTIDAD_PAGO = t2.CANTIDAD_PAGO,
                                                                   //CAMBIO = t2.CAMBIO,
                                                                   TOTAL = t1.SUBTOTAL,
                                                                   UM_DESCRIPCION = t1.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                                                   UNIDADES = t1.CAT_UNIDAD_MEDIDA.UNIDADES,
                                                                   DESCRIPCION_ENVASE_UNIDAD = t1.CAT_UNIDADMEDIDA_ENVASE.DESCRIPCION_ENVASE_UNIDAD
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