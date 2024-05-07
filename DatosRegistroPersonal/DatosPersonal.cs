using EntidadRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRegistroPersonal
{
    public class DatosPersonal
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public List<EntPersonal> Obtener()
        {
            List<EntPersonal> lista = new List<EntPersonal> ();
            SqlCommand comando = new SqlCommand("spObtenerPersonal", conn);
            comando.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EntPersonal p = new EntPersonal();
                    EntPuestoDeTrabajo pt = new EntPuestoDeTrabajo();
                    EntTurnos t = new EntTurnos();
                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Nombre = reader["Nombre"].ToString();
                    p.Paterno = reader["Paterno"].ToString();
                    p.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    p.PuestoDeTrabajoId = Convert.ToInt32(reader["PuestosDeTrabajoId"]);
                    pt.Id = Convert.ToInt32(reader["IdP"]);
                    pt.Nombre = reader["NombreP"].ToString();
                    pt.Estatus = Convert.ToBoolean(reader["Estatus"]);
                    t.Turno = reader["Turno"].ToString();
                    p.EntPuesto = pt;
                    p.EntityTurnos = t;
                    lista.Add(p);
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

        public EntPersonal Obtener(int id)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonalPorId", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            EntPersonal p = new EntPersonal();
            EntPuestoDeTrabajo pt = new EntPuestoDeTrabajo();
            EntTurnos t = new EntTurnos();
            conn.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {

                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Nombre = reader["Nombre"].ToString();
                    p.Paterno = reader["Paterno"].ToString();
                    p.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    p.PuestoDeTrabajoId = Convert.ToInt32(reader["PuestosDeTrabajoId"]);
                    pt.Id = Convert.ToInt32(reader["IdP"]);
                    pt.Nombre = reader["NombreP"].ToString();
                    pt.Estatus = Convert.ToBoolean(reader["Estatus"]);
                    t.Turno = reader["Turno"].ToString();
                    p.EntPuesto = pt;
                    p.EntityTurnos = t;
                }
                conn.Close();
                return p;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }

        }

        public void Agregar(EntPersonal p)
        {
            SqlCommand comando = new SqlCommand("spAgregarPersonal", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", p.Nombre);
            comando.Parameters.AddWithValue("@paterno", p.Paterno);
            comando.Parameters.AddWithValue("@puestoId", p.PuestoDeTrabajoId);
            comando.Parameters.AddWithValue("@turno", p.Turno);
            conn.Open();
            try
            {
                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public bool ValidarNombre(EntPersonal per)
        {
            bool existe;
            SqlCommand comando = new SqlCommand("ValidarRepetido", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", per.Nombre);
            comando.Parameters.AddWithValue("@paterno", per.Paterno);
            comando.Parameters.Add(new SqlParameter() { ParameterName = "@resultado", SqlDbType= SqlDbType.Bit, Direction = ParameterDirection.Output });
            conn.Open() ;
            try
            {
                comando.ExecuteNonQuery() ;
                existe = Convert.ToBoolean(comando.Parameters["@resultado"].Value);
                conn.Close();
                return existe;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public void Editar(EntPersonal per)
        {
            SqlCommand comando = new SqlCommand("spEditarPersonal", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", per.Nombre);
            comando.Parameters.AddWithValue("@paterno", per.Paterno);
            comando.Parameters.AddWithValue("@puestoId", per.PuestoDeTrabajoId);
            comando.Parameters.AddWithValue("@id", per.Id);
            comando.Parameters.AddWithValue("@turno", per.Turno);
            conn.Open();
            try
            {
                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public void Borrar(EntPersonal per)
        {
            SqlCommand comando = new SqlCommand("spBorrarPersonal", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", per.Id);
            conn.Open();
            try
            {
                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public List<EntPersonal> Buscar(string valor)
        {
            List<EntPersonal> lista = new List<EntPersonal>();
            SqlCommand comando = new SqlCommand("spBuscarPersonal", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@valor", valor);
            conn.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EntPersonal p = new EntPersonal();
                    EntPuestoDeTrabajo pt = new EntPuestoDeTrabajo();
                    EntTurnos t = new EntTurnos();
                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Nombre = reader["Nombre"].ToString();
                    p.Paterno = reader["Paterno"].ToString();
                    p.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    p.PuestoDeTrabajoId = Convert.ToInt32(reader["PuestosDeTrabajoId"]);
                    pt.Id = Convert.ToInt32(reader["IdP"]);
                    pt.Nombre = reader["NombreP"].ToString();
                    pt.Estatus = Convert.ToBoolean(reader["Estatus"]);
                    t.Turno = reader["Turnos"].ToString();
                    p.EntPuesto = pt;
                    p.EntityTurnos = t;
                    lista.Add(p);
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

        public List<EntPersonal> ObtenerPorNombre(string txtBuscar)
        {
            List<EntPersonal> lista = new List<EntPersonal>();
            SqlCommand comando = new SqlCommand("spObtenerPorNombre", conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", txtBuscar);
            conn.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EntPersonal p = new EntPersonal();
                    EntPuestoDeTrabajo pt = new EntPuestoDeTrabajo();
                    EntTurnos t = new EntTurnos();
                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Nombre = reader["Nombre"].ToString();
                    p.Paterno = reader["Paterno"].ToString();
                    p.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    p.PuestoDeTrabajoId = Convert.ToInt32(reader["PuestosDeTrabajoId"]);
                    pt.Id = Convert.ToInt32(reader["IdP"]);
                    pt.Nombre = reader["NombreP"].ToString();
                    pt.Estatus = Convert.ToBoolean(reader["Estatus"]);
                    t.Turno = reader["Turno"].ToString();
                    p.EntPuesto = pt;
                    p.EntityTurnos = t;
                    lista.Add(p);
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
