using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatProveedor
    {
        //agregar la referencia de dato para cat bodega
        DatosCatProveedor varProveedor = new DatosCatProveedor();

        public bool metodoguardarNeg(ObjetoProveedor datoCliente)
        {
            try
            {
                CAT_PROVEEDOR modeloTabla = new CAT_PROVEEDOR();

                modeloTabla.ID_PROVEEDOR = datoCliente.IdProveedor;
                modeloTabla.NOMBRE_PROVEEDOR = datoCliente.NombreProveedor;
                modeloTabla.ENCARGADO = datoCliente.Encargado;
                modeloTabla.TELEFONO = datoCliente.Telefono;
                //le agregue esto debido a la relacion con el catalgo

                varProveedor.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoProveedor metodoSeleccion(string nombreProveedor)
        {
            var datoSeleccionado = varProveedor.metodoSeleccion(nombreProveedor);

            ObjetoProveedor pasaCliente = new ObjetoProveedor();
            pasaCliente.IdProveedor = datoSeleccionado.ID_PROVEEDOR;
            pasaCliente.NombreProveedor = datoSeleccionado.NOMBRE_PROVEEDOR;
            pasaCliente.Encargado = datoSeleccionado.ENCARGADO;
            pasaCliente.Telefono = datoSeleccionado.TELEFONO;

            return pasaCliente;
        }
        public ObjetoProveedor metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varProveedor.metodoSeleccion(codigo);

            ObjetoProveedor pasaCliente = new ObjetoProveedor();
            pasaCliente.IdProveedor = datoSeleccionado.ID_PROVEEDOR;
            pasaCliente.NombreProveedor = datoSeleccionado.NOMBRE_PROVEEDOR;
            pasaCliente.Encargado = datoSeleccionado.ENCARGADO;
            pasaCliente.Telefono = datoSeleccionado.TELEFONO;
            return pasaCliente;
        }



        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varProveedor.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoProveedor> metodoMostrarListaDatos()
        {
            var datos = varProveedor.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return varCiudad.traerDepartamentos();
        //}
    }
}
