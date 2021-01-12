using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;


namespace CapaNegocio
{
    public class NegocioTblProducto
    {
        //agregar la referencia de dato para cat bodega
        DatosProducto varProducto = new DatosProducto();

        public bool metodoguardarNeg(ObjetoProducto datoCliente)
        {
            try
            {
                TBL_PRODUCTO modeloTabla = new TBL_PRODUCTO();
                modeloTabla.ID_PRODUCTO = datoCliente.IdProducto;
                modeloTabla.NOMBRE_PRODUCTO = datoCliente.NombreProducto;
                modeloTabla.DESCRIPCION_PRODUCTO = datoCliente.DescripcionProducto;
                modeloTabla.ID_TIPO_PRODUCTO = datoCliente.IdTipoProducto;  //le agregue esto debido a la relacion con el catalgo
                modeloTabla.ID_UNIDAD_MEDIDA = datoCliente.IdUnidadMedida;
                modeloTabla.ID_MARCA = datoCliente.IdMarca;
                

                varProducto.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoProducto metodoSeleccion(string nombreProducto)
        {
            var datoSeleccionado = varProducto.metodoSeleccion(nombreProducto);

            ObjetoProducto pasaCliente = new ObjetoProducto();
            pasaCliente.IdProducto = datoSeleccionado.ID_PRODUCTO;
            pasaCliente.NombreProducto = datoSeleccionado.NOMBRE_PRODUCTO;
            pasaCliente.DescripcionProducto = datoSeleccionado.DESCRIPCION_PRODUCTO;
            pasaCliente.IdTipoProducto = datoSeleccionado.ID_TIPO_PRODUCTO;
            pasaCliente.IdUnidadMedida = (int) datoSeleccionado.ID_UNIDAD_MEDIDA;
            pasaCliente.IdMarca = (int) datoSeleccionado.ID_MARCA;

            return pasaCliente;
        }
        public ObjetoProducto metodoSeleccion(int codigo)
        {
            var datoSeleccionado = varProducto.metodoSeleccion(codigo);

            ObjetoProducto pasaCliente = new ObjetoProducto();
            pasaCliente.IdProducto = datoSeleccionado.ID_PRODUCTO;
            pasaCliente.NombreProducto = datoSeleccionado.NOMBRE_PRODUCTO;
            pasaCliente.DescripcionProducto = datoSeleccionado.DESCRIPCION_PRODUCTO;
            pasaCliente.IdTipoProducto = datoSeleccionado.ID_TIPO_PRODUCTO;
            pasaCliente.IdUnidadMedida = (int)datoSeleccionado.ID_UNIDAD_MEDIDA;
            pasaCliente.IdMarca = (int)datoSeleccionado.ID_MARCA;

            return pasaCliente;
        }
        public bool metodoBusca(string nombre, int codigo)
        {
            return varProducto.metodoBusca(nombre, codigo);
        }
        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varProducto.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoProducto> metodoMostrarListaDatos()
        {
            var datos = varProducto.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        public List<CAT_TIPO_PRODUCTO> traerTipoProducto()
        {
            return varProducto.traerTipoProducto();
        }
        public List<CAT_UNIDAD_MEDIDA> traerUnidadMedida()
        {
            return varProducto.traerUnidadMedida();
        }
        public List<TblMarca> traerMarca()
        {
            return varProducto.traerMarca();
        }
    }
}

