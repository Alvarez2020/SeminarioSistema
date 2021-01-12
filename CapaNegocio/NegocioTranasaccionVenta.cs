using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class NegocioTranasaccionVenta
    {
        public int FinalizaTransaccion(ObjetoVenta obj, List<ObjetoVenta> lista) //pasa parametro con todos los datos para las 
        {
            var metodoDato = new DatosTransaccionVenta();
            return metodoDato.FinalizaTransaccion(obj, lista);
        }
    }
}
