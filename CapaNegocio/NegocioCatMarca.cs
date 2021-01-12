using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatMarca
    {
        //agregar la referencia de dato para cat bodega
        DatosCatMarca varMarca = new DatosCatMarca();

        public bool metodoguardarNeg(ObjetoMarca datoCliente)
        {
            try
            {
                TblMarca modeloTabla = new TblMarca();

                modeloTabla.ID_MARCA =  datoCliente.IdMarca;
                modeloTabla.NOMBRE_MARCA = datoCliente.NombreMarca;
                //le agregue esto debido a la relacion con el catalgo

                varMarca.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoMarca metodoSeleccion(string nombreMarca)
        {
            var datoSeleccionado = varMarca.metodoSeleccion(nombreMarca);

            ObjetoMarca pasaCliente = new ObjetoMarca();
            pasaCliente.IdMarca = datoSeleccionado.ID_MARCA;
            pasaCliente.NombreMarca = datoSeleccionado.NOMBRE_MARCA;

            return pasaCliente;
        }
        public ObjetoMarca metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varMarca.metodoSeleccion(codigo);

            ObjetoMarca pasaCliente = new ObjetoMarca();
            pasaCliente.IdMarca = datoSeleccionado.ID_MARCA;
            pasaCliente.NombreMarca = datoSeleccionado.NOMBRE_MARCA;

            return pasaCliente;
        }
        //metodo para eliminar
        public bool metodoBusca(string nombre)
        {
            return varMarca.metodoBusca(nombre);
        }
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varMarca.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoMarca> metodoMostrarListaDatos()
        {
            var datos = varMarca.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return varCiudad.traerDepartamentos();
        //}
    }
}
