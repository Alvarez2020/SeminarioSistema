using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatCiudad
    {
        //agregar la referencia de dato para cat bodega
        DatosCatCiudad varCiudad = new DatosCatCiudad();

        public bool metodoguardarNeg(ObjetoCiudad datoCliente)
        {
            try
            {
                CAT_CIUDAD modeloTabla = new CAT_CIUDAD();

                modeloTabla.ID_CIUDAD = datoCliente.IdCiudad;
                modeloTabla.NOMBRE_CIUDAD = datoCliente.NombreCiudad;
                modeloTabla.ID_DEPARTAMENTO_CIUDAD = datoCliente.IdDepartamento;  //le agregue esto debido a la relacion con el catalgo

                varCiudad.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoCiudad metodoSeleccion(string nombreCiudad)
        {
            var datoSeleccionado = varCiudad.metodoSeleccion(nombreCiudad);

            ObjetoCiudad pasaCliente = new ObjetoCiudad();
            pasaCliente.IdCiudad = datoSeleccionado.ID_CIUDAD;
            pasaCliente.NombreCiudad = datoSeleccionado.NOMBRE_CIUDAD;
            pasaCliente.IdDepartamento = datoSeleccionado.ID_DEPARTAMENTO_CIUDAD;

            return pasaCliente;
        }
        public ObjetoCiudad metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varCiudad.metodoSeleccion(codigo);

            ObjetoCiudad pasaCliente = new ObjetoCiudad();
            pasaCliente.IdCiudad = datoSeleccionado.ID_CIUDAD;
            pasaCliente.NombreCiudad = datoSeleccionado.NOMBRE_CIUDAD;
            pasaCliente.IdDepartamento = datoSeleccionado.ID_DEPARTAMENTO_CIUDAD;

            return pasaCliente;
        }
        public bool metodoBusca(string nombre)
        {
            return varCiudad.metodoBusca(nombre);
        }
        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varCiudad.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoCiudad> metodoMostrarListaDatos()
        {
            var datos = varCiudad.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        public List<CAT_DEPARTAMENTO> traerDepartamentos()
        {
            return varCiudad.traerDepartamentos();
        }
    }
}

