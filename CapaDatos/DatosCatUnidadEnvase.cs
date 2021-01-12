﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
   public class DatosCatUnidadEnvase
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_UNIDADMEDIDA_ENVASE datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_UNIDADMEDIDA_ENVASE busqueda = modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.FirstOrDefault(
                                  x => x.ID_UNIDAD_ENVASE == datos.ID_UNIDAD_ENVASE);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.Add(datos);
                }
                else
                {
                    //CAT_UNIDAD_MEDIDA busqueda = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                    //               x => x.ID_UNIDAD_MEDIDA == datos.ID_UNIDAD_MEDIDA);
                    busqueda.DESCRIPCION_ENVASE_UNIDAD = datos.DESCRIPCION_ENVASE_UNIDAD;
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
        public CAT_UNIDADMEDIDA_ENVASE metodoSeleccion(string DescripcionEnvaseUnidad)
        {
            CAT_UNIDADMEDIDA_ENVASE DatoEncontrado = modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.FirstOrDefault(
                                    x => x.DESCRIPCION_ENVASE_UNIDAD == DescripcionEnvaseUnidad);
            return DatoEncontrado;
        }
        public CAT_UNIDADMEDIDA_ENVASE metodoSeleccion(int? codigo)
        {
            CAT_UNIDADMEDIDA_ENVASE DatoEncontrado = modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.FirstOrDefault(
                                    x => x.ID_UNIDAD_ENVASE == codigo);
            return DatoEncontrado;
        }
        public bool metodoBusca(string nombre)
        {
            CAT_UNIDADMEDIDA_ENVASE DatoEncontrado = modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.FirstOrDefault(
                                    x => x.DESCRIPCION_ENVASE_UNIDAD == nombre);
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
                CAT_UNIDADMEDIDA_ENVASE DatoEncontrado = modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.FirstOrDefault(
                                  x => x.ID_UNIDAD_ENVASE == codigo);
                modelBaseDato.CAT_UNIDADMEDIDA_ENVASE.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //metodo para mostrar los dados de la tabla   
        public List<ObjetoUnidadEnvase> metodoMostrarListaDatos()
        {
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_UNIDADMEDIDA_ENVASE
                                //join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                                //on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoUnidadEnvase
                            {
                                IdUnidadEnvase = variableAlmacenado.ID_UNIDAD_ENVASE,
                                DescripcionEnvaseUnidad = variableAlmacenado.DESCRIPCION_ENVASE_UNIDAD,
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        //}
    }

    public class ObjetoUnidadEnvase
    {
        //propiedades
        public int IdUnidadEnvase { get; set; }
        public string DescripcionEnvaseUnidad { get; set; }

    }
}
