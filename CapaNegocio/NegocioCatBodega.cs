using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
 
    public class NegocioCatBodega
    {
        //agregar la referencia de dato para cat bodega
        DatosCatBodega varBodega = new DatosCatBodega();

        public bool metodoguardarNeg (ObjetoBodega datoCliente)
        {
            try
            {
                CAT_BODEGA modeloTabla = new CAT_BODEGA();

                modeloTabla.ID_BODEGA = datoCliente.IdBodega;
                modeloTabla.NOMBRE_BODEGA = datoCliente.NombreBodega;
                modeloTabla.ID_CIUDAD_BODEGA = datoCliente.IdCiudad;  //le agregue esto debido a la relacion con el catalgo

                varBodega.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoBodega metodoSeleccion(string nombreBodega)
        {
            var datoSeleccionado = varBodega.metodoSeleccion(nombreBodega);

            ObjetoBodega pasaCliente = new ObjetoBodega();
            pasaCliente.IdBodega = datoSeleccionado.ID_BODEGA;
            pasaCliente.NombreBodega = datoSeleccionado.NOMBRE_BODEGA;
            pasaCliente.IdCiudad = datoSeleccionado.ID_CIUDAD_BODEGA;

            return pasaCliente;
        }
        public ObjetoBodega metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varBodega.metodoSeleccion(codigo);

            ObjetoBodega pasaCliente = new ObjetoBodega();
            pasaCliente.IdBodega = datoSeleccionado.ID_BODEGA;
            pasaCliente.NombreBodega = datoSeleccionado.NOMBRE_BODEGA;
            pasaCliente.IdCiudad = datoSeleccionado.ID_CIUDAD_BODEGA;

            return pasaCliente;
        }
        public bool metodoBusca(string nombre)
        {
            return varBodega.metodoBusca(nombre);
        }
        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varBodega.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoBodega> metodoMostrarListaDatos()
        {
            var datos = varBodega.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        public List<CAT_CIUDAD> traerCiudades()
        {
            return varBodega.traerCiudades();
        }
    }
}
