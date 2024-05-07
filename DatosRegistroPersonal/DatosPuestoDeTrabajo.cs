using EntidadRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRegistroPersonal
{
    public class DatosPuestoDeTrabajo
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public List<EntPuestoDeTrabajo> Obtener()
        {
            List<EntPuestoDeTrabajo> lista = new List<EntPuestoDeTrabajo> ();
            SqlCommand comando = new SqlCommand("spObtenerPuestosDeTrabajo", conn);
            comando.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EntPuestoDeTrabajo pt = new EntPuestoDeTrabajo();
                    pt.Estatus = Convert.ToBoolean(reader["Estatus"]);
                    pt.Id = Convert.ToInt32(reader["ID"]);
                    pt.Nombre = reader["Nombre"].ToString();
                    lista.Add(pt);
                }
                conn.Close();
                return lista;
            }
            catch (Exception )
            {
                conn.Close();
                throw;
            }
        }

    }
}
