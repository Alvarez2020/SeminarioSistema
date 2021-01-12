using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
    public class NegocioCatTipoProducto
    {
        //agregar la referencia de dato para cat bodega
        DatosCatTipoProducto varTipoPro = new DatosCatTipoProducto();

        public bool metodoguardarNeg(ObjetoTipoProducto datoCliente)
        {
            try
            {
                CAT_TIPO_PRODUCTO modeloTabla = new CAT_TIPO_PRODUCTO();

                modeloTabla.ID_TIPO_PRODUCTO = datoCliente.IdTipoProducto;
                modeloTabla.TIPO_PRODUCTO = datoCliente.TipoProducto;
                modeloTabla.DESCRIPCION_TIPO_PRODUCTO = datoCliente.DescripcionTipoProducto;  //le agregue esto debido a la relacion con el catalgo

                varTipoPro.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoTipoProducto metodoSeleccion(string tipoProducto)
        {
            var datoSeleccionado = varTipoPro.metodoSeleccion(tipoProducto);

            ObjetoTipoProducto pasaCliente = new ObjetoTipoProducto();
            pasaCliente.IdTipoProducto = datoSeleccionado.ID_TIPO_PRODUCTO;
            pasaCliente.TipoProducto = datoSeleccionado.TIPO_PRODUCTO;
            pasaCliente.DescripcionTipoProducto = datoSeleccionado.DESCRIPCION_TIPO_PRODUCTO;

            return pasaCliente;
        }
        public ObjetoTipoProducto metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varTipoPro.metodoSeleccion(codigo);

            ObjetoTipoProducto pasaCliente = new ObjetoTipoProducto();
            pasaCliente.IdTipoProducto = datoSeleccionado.ID_TIPO_PRODUCTO;
            pasaCliente.TipoProducto = datoSeleccionado.TIPO_PRODUCTO;
            pasaCliente.DescripcionTipoProducto = datoSeleccionado.DESCRIPCION_TIPO_PRODUCTO;

            return pasaCliente;
        }

        public bool metodoBusca(string nombre)
        {
            return varTipoPro.metodoBusca(nombre);
        }
        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varTipoPro.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoTipoProducto> metodoMostrarListaDatos()
        {
            var datos = varTipoPro.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return varCiudad.traerDepartamentos();
        //}
    }
}