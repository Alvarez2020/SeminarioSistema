using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;

namespace CapaNegocio
{
   public class NegocioHistorico
    {
        DatosHistorico varExistencia = new DatosHistorico();
        public List<ObjetoExistencia1> metodoMostrarListaDatos()
        {
            var datos = varExistencia.metodoMostrarListaDatos();
            return datos;
        }
        
    }
}
