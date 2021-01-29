using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SistemaCONNY
{

    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            {
                RouteTable.Routes.MapPageRoute("Inicio", "Inicio", "~/Default.aspx");
                RouteTable.Routes.MapPageRoute("Bodega", "Bodega", "~/CatalogosSistema/Bodega.aspx");
                RouteTable.Routes.MapPageRoute("Ciudad", "Ciudad", "~/CatalogosSistema/Ciudad.aspx");
                RouteTable.Routes.MapPageRoute("Departamento", "Departamento", "~/CatalogosSistema/Departamento.aspx");
                RouteTable.Routes.MapPageRoute("Marca", "Marca", "~/CatalogosSistema/Marca.aspx");
                RouteTable.Routes.MapPageRoute("Pais", "Pais", "~/CatalogosSistema/Pais.aspx");
                RouteTable.Routes.MapPageRoute("Productos", "Productos", "~/CatalogosSistema/Productos.aspx");
                RouteTable.Routes.MapPageRoute("Proveedor", "Proveedor", "~/CatalogosSistema/Proveedor.aspx");
                RouteTable.Routes.MapPageRoute("Tipo_Producto", "Tipo_Producto", "~/CatalogosSistema/Tipo_Producto.aspx");
                RouteTable.Routes.MapPageRoute("Unidad_Medida", "Unidad_Medida", "~/CatalogosSistema/Unidad_Medida.aspx");
                RouteTable.Routes.MapPageRoute("UnidadEnvase", "UnidadEnvase", "~/CatalogosSistema/UNIDAD_ENVASE.aspx");
                RouteTable.Routes.MapPageRoute("Compra", "Compra", "~/Transaccion/Compra.aspx");
                RouteTable.Routes.MapPageRoute("Venta", "Venta", "~/Transaccion/Venta.aspx");
                RouteTable.Routes.MapPageRoute("HistoricoCompra", "HistoricoCompra", "~/HistoricoYExistencia/HistoricoCompra.aspx");
                RouteTable.Routes.MapPageRoute("Existencia", "Existencia", "~/HistoricoYExistencia/Existencia.aspx");
                RouteTable.Routes.MapPageRoute("Reportes", "Reportes", "~/Reporte/Reportes.aspx");
                RouteTable.Routes.MapPageRoute("HistoricoVenta", "HistoricoVenta", "~/HistoricoYExistencia/HistoricoVenta.aspx");
                RouteTable.Routes.MapPageRoute("Register", "Register", "~/Account/Register.aspx");
            }
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //rutas del sistema
            //RouteTable.Routes.MapPageRoute("Inicio", "Inicio", "~/Default.aspx");
            //RouteTable.Routes.MapPageRoute("Bodega", "Bodega", "~/CatalogosSistema/Bodega.aspx");
            
        }

    }
}