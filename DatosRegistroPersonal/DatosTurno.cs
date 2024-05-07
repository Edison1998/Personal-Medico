using EntidadRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRegistroPersonal
{
    public class DatosTurno
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public List<EntTurnos> Obtener()
        {
            List<EntTurnos> lista = new List<EntTurnos>();
            SqlCommand comando = new SqlCommand("spObtenerTurno", conn);
            comando.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EntTurnos t = new EntTurnos();
                    t.Turno = reader["Turno"].ToString();
                    lista.Add(t);
                }
                conn.Close();
                return lista;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }
    }
}
