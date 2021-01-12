using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.ModeloEntity;

namespace CapaDatos
{
    public class DatosCatUnidadMedidacs
    {
        DB_MiscelaneaConnyEntities modelBaseDato = new DB_MiscelaneaConnyEntities();

        //metodos para guardar o actualizar un dato CAT_BODEGA
        public bool metodoGuardar(CAT_UNIDAD_MEDIDA datos) // exijidamente true false        //string bool number void
        {               //   null  -  nombre
            try
            {
                // ifiltrar el dato si existe             select * from cat bodega where nombrebodega == 'Bodega 1'
                //comparar el codigo si viene null autogerar si el dato nuevo
                CAT_UNIDAD_MEDIDA busqueda = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                                  x => x.ID_UNIDAD_MEDIDA == datos.ID_UNIDAD_MEDIDA);
                if (busqueda == null)
                {   // si es nulo no exite por lo tanto mandamos a guardar    
                    modelBaseDato.CAT_UNIDAD_MEDIDA.Add(datos);
                }
                else
                {
                    //CAT_UNIDAD_MEDIDA busqueda = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                    //               x => x.ID_UNIDAD_MEDIDA == datos.ID_UNIDAD_MEDIDA);
                    busqueda.UM_DESCRIPCION = datos.UM_DESCRIPCION;
                    busqueda.UNIDADES = datos.UNIDADES;
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
        public CAT_UNIDAD_MEDIDA metodoSeleccion(string umDescripcion)
        {
            CAT_UNIDAD_MEDIDA DatoEncontrado = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                                    x => x.UM_DESCRIPCION == umDescripcion);
            return DatoEncontrado;
        }
        public CAT_UNIDAD_MEDIDA metodoSeleccion1(int? codigo)
        {
            CAT_UNIDAD_MEDIDA DatoEncontrado = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                                    x => x.ID_UNIDAD_MEDIDA == codigo);
            return DatoEncontrado;
        }



        public bool metodoBusca(string nombre)
        {
            CAT_UNIDAD_MEDIDA DatoEncontrado = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                                    x => x.UM_DESCRIPCION == nombre);
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
                CAT_UNIDAD_MEDIDA DatoEncontrado = modelBaseDato.CAT_UNIDAD_MEDIDA.FirstOrDefault(
                                  x => x.ID_UNIDAD_MEDIDA == codigo);
                modelBaseDato.CAT_UNIDAD_MEDIDA.Remove(DatoEncontrado);
                modelBaseDato.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //metodo para mostrar los dados de la tabla   
        public List<ObjetoUnidad> metodoMostrarListaDatos1()
        {
            //consulta en linq que represente la carga de datos como select de sql
            // consulta = select * from cat_bodega join a la tabla ciudad
            var consulta = (from variableAlmacenado in modelBaseDato.CAT_UNIDAD_MEDIDA
                            //join variableDepartamento in modelBaseDato.CAT_DEPARTAMENTO
                            //on variableAlmacenado.ID_DEPARTAMENTO_CIUDAD equals variableDepartamento.ID_DEPARTAMENTO
                            select new ObjetoUnidad
                            {
                                IdUnidadMedida = variableAlmacenado.ID_UNIDAD_MEDIDA,
                                UmDescripcion = variableAlmacenado.UM_DESCRIPCION,
                                Unidades = (int) variableAlmacenado.UNIDADES
                            }).ToList();
            return consulta;
        }

        //metodo para traer Ciudades
        //public List<CAT_DEPARTAMENTO> traerDepartamentos()
        //{
        //    return modelBaseDato.CAT_DEPARTAMENTO.ToList();
        //}
    }

    public class ObjetoUnidad
    {
        //propiedades
        public int IdUnidadMedida { get; set; }
        public int Unidades { get; set; }
        public string UmDescripcion { get; set; }

    }
}
