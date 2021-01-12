using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosCatProveedor
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_PROVEEDOR datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_PROVEEDOR busqueda = modelBaseDato.CAT_PROVEEDOR.FirstOrDefault(
                             x => x.ID_PROVEEDOR == datos.ID_PROVEEDOR);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_PROVEEDOR.Add(datos);
                }
                else
                {
                    //CAT_PROVEEDOR busqueda = modelBaseDato.CAT_PROVEEDOR.FirstOrDefault(
                    //               x => x.ID_PROVEEDOR == datos.ID_PROVEEDOR);      //comparar el mobre

                    busqueda.NOMBRE_PROVEEDOR = datos.NOMBRE_PROVEEDOR;
                    busqueda.ENCARGADO = datos.ENCARGADO;
                    busqueda.TELEFONO = datos.TELEFONO;

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
        public CAT_PROVEEDOR metodoSeleccion(string nombreProveedor)
        {
            CAT_PROVEEDOR DatoEncontrado = modelBaseDato.CAT_PROVEEDOR.FirstOrDefault(
                                    x => x.NOMBRE_PROVEEDOR == nombreProveedor);
            return DatoEncontrado;
        }
        public CAT_PROVEEDOR metodoSeleccion(int codigo)
        {
            CAT_PROVEEDOR DatoEncontrado = modelBaseDato.CAT_PROVEEDOR.FirstOrDefault(
                                    x => x.ID_PROVEEDOR == codigo);
            return DatoEncontrado;
        }


        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                CAT_PROVEEDOR DatoEncontrado = modelBaseDato.CAT_PROVEEDOR.FirstOrDefault(
                                  x => x.ID_PROVEEDOR == codigo);
                modelBaseDato.CAT_PROVEEDOR.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
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
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_PROVEEDOR
                                //join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                                //on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoProveedor
                            {
                                IdProveedor = variableAlmacenado.ID_PROVEEDOR,
                               NombreProveedor = variableAlmacenado.NOMBRE_PROVEEDOR,
                               Encargado = variableAlmacenado.ENCARGADO,
                                Telefono = variableAlmacenado.TELEFONO,
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        //}
    }

    public class ObjetoProveedor
    {
        //propiedades
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Encargado { get; set; }
        public string Telefono { get; set; }

    }
}

