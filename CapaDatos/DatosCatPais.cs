using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosCatPais
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_PAIS datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_PAIS busqueda = modelBaseDato.CAT_PAIS.FirstOrDefault(
                   x => x.ID_PAIS == datos.ID_PAIS);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_PAIS.Add(datos);
                }
                else
                {
                    //CAT_PAIS busqueda = modelBaseDato.CAT_PAIS.FirstOrDefault(
                    //                x => x.ID_PAIS == datos.ID_PAIS);      //comparar el mobre

                    busqueda.NOMBRE_PAIS = datos.NOMBRE_PAIS;

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
        public CAT_PAIS metodoSeleccion(string nombrePais)
        {
            CAT_PAIS DatoEncontrado = modelBaseDato.CAT_PAIS.FirstOrDefault(
                                    x => x.NOMBRE_PAIS == nombrePais);
            return DatoEncontrado;
        }

        public CAT_PAIS metodoSeleccion(int codigo)
        {
            CAT_PAIS DatoEncontrado = modelBaseDato.CAT_PAIS.FirstOrDefault(
                                    x => x.ID_PAIS == codigo);
            return DatoEncontrado;
        }
        public bool metodoEliminar(int codigo)
        {
            try
            {
                CAT_PAIS DatoEncontrado = modelBaseDato.CAT_PAIS.FirstOrDefault(
                                  x => x.ID_PAIS == codigo);
                modelBaseDato.CAT_PAIS.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool metodoBusca(string nombre)
        {
            CAT_PAIS DatoEncontrado = modelBaseDato.CAT_PAIS.FirstOrDefault(
                                    x => x.NOMBRE_PAIS == nombre);
            if (DatoEncontrado == null)
                return false;
            else
                return true;
        }
        //metodo para mostrar los dados de la tabla   
        public List<ObjetoPais> metodoMostrarListaDatos()
        {
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_PAIS
                                //join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                                //on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoPais
                            {
                                IdPais = variableAlmacenado.ID_PAIS,
                                NombrePais = variableAlmacenado.NOMBRE_PAIS,

                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        //}
    }

    public class ObjetoPais
    {
        //propiedades
        public int IdPais { get; set; }
        public string NombrePais { get; set; }

    }
}