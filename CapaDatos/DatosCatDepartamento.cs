using System;
using System.Collections.Generic;
using System.Linq;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
   public class DatosCatDepartamento
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_DEPARTAMENTO datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_DEPARTAMENTO busqueda = modelBaseDato.CAT_DEPARTAMENTO.FirstOrDefault(
                                   x => x.ID_DEPARTAMENTO == datos.ID_DEPARTAMENTO);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_DEPARTAMENTO.Add(datos);
                }
                else
                {
                    //CAT_DEPARTAMENTO busqueda = modelBaseDato.CAT_DEPARTAMENTO.FirstOrDefault(
                    //               x => x.ID_DEPARTAMENTO == datos.ID_DEPARTAMENTO);
                    busqueda.NOMBRE_DEPARTAMENTO = datos.NOMBRE_DEPARTAMENTO;
                    busqueda.ID_PAIS_DEPARTAMENTO = datos.ID_PAIS_DEPARTAMENTO;
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
        public CAT_DEPARTAMENTO metodoSeleccion(string nombreDepartamento)
        {
            CAT_DEPARTAMENTO DatoEncontrado = modelBaseDato.CAT_DEPARTAMENTO.FirstOrDefault(
                                    x => x.NOMBRE_DEPARTAMENTO == nombreDepartamento);
            return DatoEncontrado;
        }
        public CAT_DEPARTAMENTO metodoSeleccion(int codigo)
        {
            CAT_DEPARTAMENTO DatoEncontrado = modelBaseDato.CAT_DEPARTAMENTO.FirstOrDefault(
                                    x => x.ID_DEPARTAMENTO == codigo);
            return DatoEncontrado;
        }

        public bool metodoBusca(string nombre)
        {
            CAT_DEPARTAMENTO DatoEncontrado = modelBaseDato.CAT_DEPARTAMENTO.FirstOrDefault(
                                    x => x.NOMBRE_DEPARTAMENTO == nombre);
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
                CAT_DEPARTAMENTO DatoEncontrado = modelBaseDato.CAT_DEPARTAMENTO.FirstOrDefault(
                                  x => x.ID_DEPARTAMENTO == codigo);
                modelBaseDato.CAT_DEPARTAMENTO.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoDepartamento> metodoMostrarListaDatos()
        {
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_DEPARTAMENTO
                            join variablePais in modelBaseDato.CAT_PAIS
                            on variableAlmacenado.ID_PAIS_DEPARTAMENTO equals variablePais.ID_PAIS
                            select new ObjetoDepartamento
                            {
                                IdDepartamento = variableAlmacenado.ID_DEPARTAMENTO,
                                NombreDepartamento = variableAlmacenado.NOMBRE_DEPARTAMENTO,
                                NombrePais = variablePais.NOMBRE_PAIS,
                                IdPais = variablePais.ID_PAIS
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        public List<CAT_PAIS> traerPaises()
        {
            return modelBaseDato.CAT_PAIS.ToList();
        }
    }

    public class ObjetoDepartamento
    {
        //propiedades
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int? IdPais { get; set; }

        public string NombrePais { get; set; }
       
    }
}

