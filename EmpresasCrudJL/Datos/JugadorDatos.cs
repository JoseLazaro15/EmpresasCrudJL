using EmpresasCrudJL.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmpresasCrudJL.Datos
{
    public class JugadorDatos
    {
        public List<JugadorModel> Listar()
        {
            var oLista = new List<JugadorModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarJugador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new JugadorModel()
                        {
                            ID = Convert.ToInt32(dr["Id"]),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Numero = Convert.ToInt32(dr["Numero"]),
                            Equipo = dr["Equipo"].ToString(),
                            Alias = dr["Alias"].ToString(),
                            Estado = dr["Estado"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        public JugadorModel Obtener(int ID)
        {

            var oJugador = new JugadorModel();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerJugador", conexion);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) // Verifica si hay datos
                    {
                        oJugador.ID = Convert.ToInt32(dr["ID"]);
                        oJugador.NombreCompleto = dr["NombreCompleto"].ToString();
                        oJugador.Numero = Convert.ToInt32(dr["Numero"]);
                        oJugador.Equipo = dr["Equipo"].ToString();
                        oJugador.Alias = dr["Alias"].ToString();
                        oJugador.Estado = dr["Estado"].ToString();
                    }
                    else
                    {
                        oJugador = null;
                    }

                }
            }
            return oJugador;
        }

        public bool Guardar(JugadorModel oJugador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarJugador", conexion);
                    cmd.Parameters.AddWithValue("ID", oJugador.ID);
                    cmd.Parameters.AddWithValue("NombreCompleto", oJugador.NombreCompleto);
                    cmd.Parameters.AddWithValue("Numero", oJugador.Numero);
                    cmd.Parameters.AddWithValue("Equipo", oJugador.Equipo);
                    cmd.Parameters.AddWithValue("Alias", oJugador.Alias);
                    cmd.Parameters.AddWithValue("Estado", oJugador.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


        public bool Editar(JugadorModel oJugador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarJugador", conexion);
                    cmd.Parameters.AddWithValue("ID", oJugador.ID);
                    cmd.Parameters.AddWithValue("NombreCompleto", oJugador.NombreCompleto);
                    cmd.Parameters.AddWithValue("Numero", oJugador.Numero);
                    cmd.Parameters.AddWithValue("Equipo", oJugador.Equipo);
                    cmd.Parameters.AddWithValue("Alias", oJugador.Alias);
                    cmd.Parameters.AddWithValue("Estado", oJugador.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int ID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarJugador", conexion);
                    cmd.Parameters.AddWithValue("ID", ID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
