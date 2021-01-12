using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatUnidadEnvase
    {
        DatosCatUnidadEnvase varUnidad = new DatosCatUnidadEnvase();

        public bool metodoguardarNeg(ObjetoUnidadEnvase datoCliente)
        {
            try
            {
                CAT_UNIDADMEDIDA_ENVASE modeloTabla = new CAT_UNIDADMEDIDA_ENVASE();

                modeloTabla.ID_UNIDAD_ENVASE = datoCliente.IdUnidadEnvase;
                modeloTabla.DESCRIPCION_ENVASE_UNIDAD = datoCliente.DescripcionEnvaseUnidad;
                  //le agregue esto debido a la relacion con el catalgo

                varUnidad.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoUnidadEnvase metodoSeleccion(string DescripcionEnvaseUnida)
        {
            var datoSeleccionado = varUnidad.metodoSeleccion(DescripcionEnvaseUnida);

            ObjetoUnidadEnvase pasaCliente = new ObjetoUnidadEnvase();
            pasaCliente.IdUnidadEnvase = datoSeleccionado.ID_UNIDAD_ENVASE;
            pasaCliente.DescripcionEnvaseUnidad = datoSeleccionado.DESCRIPCION_ENVASE_UNIDAD;
           

            return pasaCliente;
        }
        public ObjetoUnidadEnvase metodoSeleccion(int? codigo)
        {
            var datoSeleccionado = varUnidad.metodoSeleccion(codigo);

            ObjetoUnidadEnvase pasaCliente = new ObjetoUnidadEnvase();
            pasaCliente.IdUnidadEnvase = datoSeleccionado.ID_UNIDAD_ENVASE;
            pasaCliente.DescripcionEnvaseUnidad = datoSeleccionado.DESCRIPCION_ENVASE_UNIDAD;

            return pasaCliente;
        }
        public bool metodoBusca(string nombre)
        {
            return varUnidad.metodoBusca(nombre);
        }

        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varUnidad.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoUnidadEnvase> metodoMostrarListaDatos()
        {
            var datos = varUnidad.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return varCiudad.traerDepartamentos();
        //}
    }
}
