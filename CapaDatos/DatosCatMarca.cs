using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosCatMarca
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(TblMarca datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                TblMarca busqueda = modelBaseDato.TblMarca.FirstOrDefault(
                                    x => x.ID_MARCA == datos.ID_MARCA);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.TblMarca.Add(datos);
                }
                else
                {
                    //TblMarca busqueda = modelBaseDato.TblMarca.FirstOrDefault(
                    //                x => x.ID_MARCA == datos.ID_MARCA);      //comparar el mobre

                    busqueda.NOMBRE_MARCA = datos.NOMBRE_MARCA;

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
        public TblMarca metodoSeleccion(string nombreMarca)
        {
            TblMarca DatoEncontrado = modelBaseDato.TblMarca.FirstOrDefault(
                                    x => x.NOMBRE_MARCA == nombreMarca);
            return DatoEncontrado;
        }
        public TblMarca metodoSeleccion(int codigo)
        {
            TblMarca DatoEncontrado = modelBaseDato.TblMarca.FirstOrDefault(
                                    x => x.ID_MARCA == codigo);
            return DatoEncontrado;
        }
        public bool metodoBusca(string nombre)
        {
            TblMarca DatoEncontrado = modelBaseDato.TblMarca.FirstOrDefault(
                                    x => x.NOMBRE_MARCA == nombre);
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
                TblMarca DatoEncontrado = modelBaseDato.TblMarca.FirstOrDefault(
                                  x => x.ID_MARCA == codigo);
                modelBaseDato.TblMarca.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
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
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            
            
            var consulta = (from variableAlmacenado in modelBaseDato.TblMarca
                                //join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                                //on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoMarca
                            {
                                IdMarca = variableAlmacenado.ID_MARCA,
                                NombreMarca = variableAlmacenado.NOMBRE_MARCA,

                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        //}
    }

    public class ObjetoMarca
    {
        //propiedades
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }

    }
}