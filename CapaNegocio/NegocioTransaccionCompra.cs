using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioTransaccionCompra
    {
        public int FinalizaTransaccion(ObjetoCompra obj, List<ObjetoCompra> lista) //pasa parametro con todos los datos para las 
        {
            var metodoDato = new DatoTransaccionCompra();
            return metodoDato.FinalizaTransaccion(obj, lista);
        }
    }
}
