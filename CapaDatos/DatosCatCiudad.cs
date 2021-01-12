using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosCatCiudad
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_CIUDAD datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_CIUDAD busqueda = modelBaseDato.CAT_CIUDAD.FirstOrDefault(
                                   x => x.ID_CIUDAD == datos.ID_CIUDAD);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_CIUDAD.Add(datos);
                }
                else
                {
                    //CAT_CIUDAD busqueda = modelBaseDato.CAT_CIUDAD.FirstOrDefault(
                    //               x => x.ID_CIUDAD == datos.ID_CIUDAD);
                    busqueda.NOMBRE_CIUDAD = datos.NOMBRE_CIUDAD;
                    busqueda.ID_DEPARTAMENTO_CIUDAD = datos.ID_DEPARTAMENTO_CIUDAD;
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
        public CAT_CIUDAD metodoSeleccion(string nombreCiudad)
        {
            CAT_CIUDAD DatoEncontrado = modelBaseDato.CAT_CIUDAD.FirstOrDefault(
                                    x => x.NOMBRE_CIUDAD == nombreCiudad);
            return DatoEncontrado;
        }
        public CAT_CIUDAD metodoSeleccion(int codigo)
        {
            CAT_CIUDAD DatoEncontrado = modelBaseDato.CAT_CIUDAD.FirstOrDefault(
                                    x => x.ID_CIUDAD == codigo);
            return DatoEncontrado;
        }


        public bool metodoBusca(string nombre)
        {
            CAT_CIUDAD DatoEncontrado = modelBaseDato.CAT_CIUDAD.FirstOrDefault(
                                    x => x.NOMBRE_CIUDAD == nombre);
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
                CAT_CIUDAD DatoEncontrado = modelBaseDato.CAT_CIUDAD.FirstOrDefault(
                                  x => x.ID_CIUDAD == codigo);
                modelBaseDato.CAT_CIUDAD.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
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
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_CIUDAD
                            join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                            on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoCiudad
                            {
                                IdCiudad = variableAlmacenado.ID_CIUDAD,
                                NombreCiudad = variableAlmacenado.NOMBRE_CIUDAD,
                                IdDepartamento = variableDepartamento.ID_DEPARTAMENTO,
                                NombreDepartamento = variableDepartamento.NOMBRE_DEPARTAMENTO
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        public List<CAT_DEPARTAMENTO> traerDepartamentos()
        {
            return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        }
    }

    public class ObjetoCiudad
    {
        //propiedades
        public int IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public int? IdDepartamento { get; set; }

        public string NombreDepartamento { get; set; }

    }
}

