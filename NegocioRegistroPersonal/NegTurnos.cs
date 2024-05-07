using DatosRegistroPersonal;
using EntidadRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioRegistroPersonal
{
    public class NegTurnos
    {
        DatosTurno datos = new DatosTurno();
        public List<EntTurnos> Obtener()
        {
            return datos.Obtener();
        }
    }
}
