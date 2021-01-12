using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatPais
    {
        //agregar la referencia de dato para cat bodega
        DatosCatPais varPais = new DatosCatPais();

        public bool metodoguardarNeg(ObjetoPais datoCliente)
        {
            try
            {
                CAT_PAIS modeloTabla = new CAT_PAIS();

                modeloTabla.ID_PAIS = datoCliente.IdPais;
                modeloTabla.NOMBRE_PAIS = datoCliente.NombrePais;
                //le agregue esto debido a la relacion con el catalgo

                varPais.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoPais metodoSeleccion(string nombrePais)
        {
            var datoSeleccionado = varPais.metodoSeleccion(nombrePais);

            ObjetoPais pasaCliente = new ObjetoPais();
            pasaCliente.IdPais = datoSeleccionado.ID_PAIS;
            pasaCliente.NombrePais = datoSeleccionado.NOMBRE_PAIS;

            return pasaCliente;
        }
        public ObjetoPais metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varPais.metodoSeleccion(codigo);

            ObjetoPais pasaCliente = new ObjetoPais();
            pasaCliente.IdPais = datoSeleccionado.ID_PAIS;
            pasaCliente.NombrePais = datoSeleccionado.NOMBRE_PAIS;

            return pasaCliente;
        }
        public bool metodoBusca(string nombre)
        {
            return varPais.metodoBusca(nombre);
        }
        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varPais.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoPais> metodoMostrarListaDatos()
        {
            var datos = varPais.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return varCiudad.traerDepartamentos();
        //}
    }
}
