using DatosRegistroPersonal;
using EntidadRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioRegistroPersonal
{
    public class NegPersonal
    {
        DatosPersonal datos = new DatosPersonal();

        public List<EntPersonal> Obtener()
        {
            return datos.Obtener();
        }

        public EntPersonal ObtenerPorId(int id)
        {
            return datos.Obtener(id);
        }

        public string Agregar(EntPersonal p)
        {
            bool existe = datos.ValidarNombre(p);
            if (!existe)
            {
                datos.Agregar(p);
                return $"Se agrego a {p.Nombre} {p.Paterno}";
            }
            return $"El nombre: {p.Nombre} {p.Paterno} ya existe...";

        }

        public string Editar(EntPersonal p)
        {
            datos.Editar(p);
            return $"Se edito a {p.Nombre} {p.Paterno}";
        }

        public string Borrar(EntPersonal p)
        {
            datos.Borrar(p);
            return "Se Borro con exito";
        }

        public List<EntPersonal> BuscarPorNombre(string txtBuscar)
        {
            return datos.ObtenerPorNombre(txtBuscar);
        }


    }
}
