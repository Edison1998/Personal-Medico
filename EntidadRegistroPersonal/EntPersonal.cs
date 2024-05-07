using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadRegistroPersonal
{
    public class EntPersonal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int PuestoDeTrabajoId { get; set; }
        public string Turno { get; set; }
        public EntPuestoDeTrabajo EntPuesto { get; set; }//Permite el Inner Join
        public EntTurnos EntityTurnos { get; set; } //Permite el Inner Join con la tabla Turnos
    }
}
