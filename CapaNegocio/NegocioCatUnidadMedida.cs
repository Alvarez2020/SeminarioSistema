using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatUnidadMedida
    {
        //agregar la referencia de dato para cat bodega
        DatosCatUnidadMedidacs varUnidad = new DatosCatUnidadMedidacs ();

        public bool metodoguardarNeg(ObjetoUnidad datoCliente)
        {
            try
            {
                CAT_UNIDAD_MEDIDA modeloTabla = new CAT_UNIDAD_MEDIDA();

                modeloTabla.ID_UNIDAD_MEDIDA = datoCliente.IdUnidadMedida;
                modeloTabla.UM_DESCRIPCION = datoCliente.UmDescripcion;
                modeloTabla.UNIDADES = datoCliente.Unidades;  //le agregue esto debido a la relacion con el catalgo

                varUnidad.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoUnidad metodoSeleccion(string umDescripcion)
        {
            var datoSeleccionado = varUnidad.metodoSeleccion(umDescripcion);

            ObjetoUnidad pasaCliente = new ObjetoUnidad();
            pasaCliente.IdUnidadMedida = datoSeleccionado.ID_UNIDAD_MEDIDA;
            pasaCliente.UmDescripcion = datoSeleccionado.UM_DESCRIPCION;
            pasaCliente.Unidades = (int) datoSeleccionado.UNIDADES;

            return pasaCliente;
        }
        public ObjetoUnidad metodoSeleccion1(int? codigo)
        {
            var datoSeleccionado = varUnidad.metodoSeleccion1(codigo);

            ObjetoUnidad pasaCliente = new ObjetoUnidad();
            pasaCliente.IdUnidadMedida = datoSeleccionado.ID_UNIDAD_MEDIDA;
            pasaCliente.UmDescripcion = datoSeleccionado.UM_DESCRIPCION;
            pasaCliente.Unidades = (int)datoSeleccionado.UNIDADES;

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
        public List<ObjetoUnidad> metodoMostrarListaDatos1()
        {
            var datos = varUnidad.metodoMostrarListaDatos1();
            return datos;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return varCiudad.traerDepartamentos();
        //}
    }
}
