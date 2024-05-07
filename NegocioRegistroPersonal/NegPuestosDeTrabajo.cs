using DatosRegistroPersonal;
using EntidadRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioRegistroPersonal
{
    public class NegPuestosDeTrabajo
    {
        DatosPuestoDeTrabajo datos = new DatosPuestoDeTrabajo();

        public List<EntPuestoDeTrabajo> Obtener()
        {
            return datos.Obtener();
        }
    }
}
