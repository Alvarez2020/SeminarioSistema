﻿using CapaDatos.ModeloEntity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCONNY.Reporte
{
    public partial class VentasAgru : System.Web.UI.Page
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