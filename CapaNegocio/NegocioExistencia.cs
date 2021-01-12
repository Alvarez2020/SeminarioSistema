using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;


namespace CapaNegocio
{
    public class NegocioExistencia
    {
        DatosExistencia varExistencia = new DatosExistencia();
        public List<ObjetoExistencia> metodoMostrarListaDatos()
        {
            var datos = varExistencia.metodoMostrarListaDatos();
            return datos;
        }
        public List<ObjetoExistencia> metodoMostrarListaDatos(int ID_BODEGA)
        {
            var datos = varExistencia.metodoMostrarListaDatos(ID_BODEGA);
            return datos;
        }

    }
}
