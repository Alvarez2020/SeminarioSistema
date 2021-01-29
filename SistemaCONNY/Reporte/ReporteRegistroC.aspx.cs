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
    public partial class ReporteRegistroC : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reporte/ReporteRegistroCompra.rdlc");
            //llena el recurso de dato primero consulta linq y despues pasa el parametro al datasource de report
            datasource = new ReportDataSource("DataSet1", (from variableAlmacenado in contex.TBL_DETALLE_COMPRA
                                                         
                                                           //join u in contex.CAT_UNIDADMEDIDA_ENVASE on variableAlmacenado.ID_UNIDAD_ENVASE equals u.ID_UNIDAD_ENVASE

                                                           select new
                                                           {

                                                               ID_COMPRA = variableAlmacenado.ID_COMPRA,
                                                               id_detalle_compra = variableAlmacenado.idDetalleCompra,
                                                               ID_PRODUCTO = variableAlmacenado.ID_PRODUCTO,
                                                               ID_MARCA = variableAlmacenado.TBL_PRODUCTO.ID_MARCA,
                                                               Producto = variableAlmacenado.TBL_PRODUCTO.NOMBRE_PRODUCTO,
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

            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();


        }
    }
}