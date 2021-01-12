using CapaDatos.ModeloEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class DatosCatBodega
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA asd
        public bool metodoGuardar(CAT_BODEGA datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre     
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                CAT_BODEGA busqueda = modelBaseDato.CAT_BODEGA.FirstOrDefault(
                                       x => x.ID_BODEGA == datos.ID_BODEGA);
                if (busqueda == null)
                {
                    // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_BODEGA.Add(datos);
                }
                else
                {
                    //CAT_BODEGA busqueda = modelBaseDato.CAT_BODEGA.FirstOrDefault(
                    //                    x => x.ID_BODEGA == datos.ID_BODEGA);
                    busqueda.NOMBRE_BODEGA = datos.NOMBRE_BODEGA;
                    busqueda.ID_CIUDAD_BODEGA = datos.ID_CIUDAD_BODEGA;
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
        public CAT_BODEGA metodoSeleccion(string nombreBodega)
        {
            CAT_BODEGA DatoEncontrado = modelBaseDato.CAT_BODEGA.FirstOrDefault(
                                    x => x.NOMBRE_BODEGA == nombreBodega);
            return DatoEncontrado;
        }
        public CAT_BODEGA metodoSeleccion(int codigo)
        {
            CAT_BODEGA DatoEncontrado = modelBaseDato.CAT_BODEGA.FirstOrDefault(
                                    x => x.ID_BODEGA == codigo);
            return DatoEncontrado;
        }
        public bool metodoBusca(string nombre)
        {
            CAT_BODEGA DatoEncontrado = modelBaseDato.CAT_BODEGA.FirstOrDefault(
                                    x => x.NOMBRE_BODEGA == nombre);
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
                CAT_BODEGA DatoEncontrado = modelBaseDato.CAT_BODEGA.FirstOrDefault(
                                  x => x.ID_BODEGA == codigo);
                modelBaseDato.CAT_BODEGA.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoBodega> metodoMostrarListaDatos()
        {
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_BODEGA
                            join variableCiudad in modelBaseDato.CAT_CIUDAD
                            on variableAlmacenado.ID_CIUDAD_BODEGA equals variableCiudad.ID_CIUDAD
                            select new ObjetoBodega
                            {
                                IdBodega = variableAlmacenado.ID_BODEGA,
                                NombreBodega = variableAlmacenado.NOMBRE_BODEGA,
                                NombreCiudad = variableCiudad.NOMBRE_CIUDAD,
                                IdCiudad = variableCiudad.ID_CIUDAD
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        public List<CAT_CIUDAD> traerCiudades()
        {
            return modelBaseDato.CAT_CIUDAD.ToList();
        }
    }

    public class ObjetoBodega
    {
        //propiedades
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public int? IdCiudad { get; set; }

        public string NombreCiudad { get; set; }
    }

}
