using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosCatTipoProducto
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_TIPO_PRODUCTO datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_TIPO_PRODUCTO busqueda = modelBaseDato.CAT_TIPO_PRODUCTO.FirstOrDefault(
                               x => x.ID_TIPO_PRODUCTO == datos.ID_TIPO_PRODUCTO);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_TIPO_PRODUCTO.Add(datos);
                }
                else
                {
                    //CAT_TIPO_PRODUCTO busqueda = modelBaseDato.CAT_TIPO_PRODUCTO.FirstOrDefault(
                    //               x => x.ID_TIPO_PRODUCTO == datos.ID_TIPO_PRODUCTO);
                    busqueda.TIPO_PRODUCTO = datos.TIPO_PRODUCTO;
                    busqueda.DESCRIPCION_TIPO_PRODUCTO = datos.DESCRIPCION_TIPO_PRODUCTO;
                }
                modelBaseDato.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // metododo paras seleccionar un elemento donde sea igual a la variable x      
        // politicia de acceso = public    --- definimo tipo dato retorno CatBodega   ---- nombre metodo 
        public CAT_TIPO_PRODUCTO metodoSeleccion(string tipoProducto)
        {
            CAT_TIPO_PRODUCTO DatoEncontrado = modelBaseDato.CAT_TIPO_PRODUCTO.FirstOrDefault(
                                    x => x.TIPO_PRODUCTO == tipoProducto);
            return DatoEncontrado;
        }
        public CAT_TIPO_PRODUCTO metodoSeleccion(int codigo)
        {
            CAT_TIPO_PRODUCTO DatoEncontrado = modelBaseDato.CAT_TIPO_PRODUCTO.FirstOrDefault(
                                    x => x.ID_TIPO_PRODUCTO == codigo);
            return DatoEncontrado;
        }


        public bool metodoBusca(string nombre)
        {
            CAT_TIPO_PRODUCTO DatoEncontrado = modelBaseDato.CAT_TIPO_PRODUCTO.FirstOrDefault(
                                    x => x.TIPO_PRODUCTO == nombre);
            if (DatoEncontrado == null)
                return false;
            else
                return true;
        }

        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                CAT_TIPO_PRODUCTO DatoEncontrado = modelBaseDato.CAT_TIPO_PRODUCTO.FirstOrDefault(
                                  x => x.ID_TIPO_PRODUCTO == codigo);
                modelBaseDato.CAT_TIPO_PRODUCTO.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
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
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_TIPO_PRODUCTO
                                //join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                                //on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoTipoProducto
                            {
                                IdTipoProducto = variableAlmacenado.ID_TIPO_PRODUCTO,
                               TipoProducto = variableAlmacenado.TIPO_PRODUCTO,
                                DescripcionTipoProducto = variableAlmacenado.DESCRIPCION_TIPO_PRODUCTO                       
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        //}
    }

    public class ObjetoTipoProducto
    {
        //propiedades
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public string DescripcionTipoProducto { get; set; }

    }
}
