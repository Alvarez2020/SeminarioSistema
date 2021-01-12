using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosProducto
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(TBL_PRODUCTO datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                TBL_PRODUCTO busqueda = modelBaseDato.TBL_PRODUCTO.FirstOrDefault(
                                   x => x.ID_PRODUCTO == datos.ID_PRODUCTO);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.TBL_PRODUCTO.Add(datos);
                }
                else
                {
                    //TBL_PRODUCTO busqueda = modelBaseDato.TBL_PRODUCTO.FirstOrDefault(
                    //               x => x.ID_PRODUCTO == datos.ID_PRODUCTO);

                    busqueda.NOMBRE_PRODUCTO = datos.NOMBRE_PRODUCTO;
                    busqueda.DESCRIPCION_PRODUCTO = datos.DESCRIPCION_PRODUCTO;
                    busqueda.ID_TIPO_PRODUCTO = datos.ID_TIPO_PRODUCTO;
                    busqueda.ID_UNIDAD_MEDIDA = datos.ID_UNIDAD_MEDIDA;
                    busqueda.ID_MARCA = datos.ID_MARCA;
                   
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
        public TBL_PRODUCTO metodoSeleccion(string nombreProducto)
        {
            TBL_PRODUCTO DatoEncontrado = modelBaseDato.TBL_PRODUCTO.FirstOrDefault(
                                    x => x.NOMBRE_PRODUCTO == nombreProducto);
            return DatoEncontrado;
        }
        public TBL_PRODUCTO metodoSeleccion(int codigo)
        {
            TBL_PRODUCTO DatoEncontrado = modelBaseDato.TBL_PRODUCTO.FirstOrDefault(
                                    x => x.ID_PRODUCTO == codigo);
            return DatoEncontrado;
        }
        public bool metodoBusca(string nombre, int codigo)
        {
            TBL_PRODUCTO DatoEncontrado = modelBaseDato.TBL_PRODUCTO.FirstOrDefault(
                                    x => x.NOMBRE_PRODUCTO == nombre && x.ID_MARCA == codigo);
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
                TBL_PRODUCTO DatoEncontrado = modelBaseDato.TBL_PRODUCTO.FirstOrDefault(
                                  x => x.ID_PRODUCTO == codigo);
                modelBaseDato.TBL_PRODUCTO.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
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
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.TBL_PRODUCTO
                            select new ObjetoProducto
                            {
                                IdProducto= variableAlmacenado.ID_PRODUCTO,
                                NombreProducto = variableAlmacenado.NOMBRE_PRODUCTO,
                                DescripcionProducto =variableAlmacenado.DESCRIPCION_PRODUCTO,
                                TipoProducto = variableAlmacenado.CAT_TIPO_PRODUCTO.TIPO_PRODUCTO,
                                UmDescripcion = variableAlmacenado.CAT_UNIDAD_MEDIDA.UM_DESCRIPCION,
                                NombreMarca = variableAlmacenado.TblMarca.NOMBRE_MARCA,
                                IdMarca = variableAlmacenado.TblMarca.ID_MARCA,
                                IdTipoProducto = variableAlmacenado.CAT_TIPO_PRODUCTO.ID_TIPO_PRODUCTO,
                                IdUnidadMedida = variableAlmacenado.CAT_UNIDAD_MEDIDA.ID_UNIDAD_MEDIDA
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        public List<CAT_TIPO_PRODUCTO> traerTipoProducto()
        {
            return modelBaseDato.CAT_TIPO_PRODUCTO.ToList();
        }
        public List<CAT_UNIDAD_MEDIDA> traerUnidadMedida()
        {
            return modelBaseDato.CAT_UNIDAD_MEDIDA.ToList();
        }
        public List<TblMarca> traerMarca()
        {
            return modelBaseDato.TblMarca.ToList();
        }
    }

    public class ObjetoProducto
    {
        //propiedades
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int? IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public string UmDescripcion { get; set; }
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }


    }
}