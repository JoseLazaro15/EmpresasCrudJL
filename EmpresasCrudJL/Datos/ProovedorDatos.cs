using EmpresasCrudJL.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmpresasCrudJL.Datos
{
    public class ProovedorDatos
    {
        public List<ProovedorModel> Listar()
        {
            var oLista = new List<ProovedorModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarProovedor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProovedorModel()
                        {
                            Clave_P = Convert.ToInt32(dr["Clave_P"]),
                            Nombre = dr["Nombre"].ToString(),
                            RFC = dr["RFC"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        public ProovedorModel Obtener(int Clave_P)
        {

            var oProovedor = new ProovedorModel();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerProovedor", conexion);
                cmd.Parameters.AddWithValue("@Clave_P", Clave_P);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) // Verifica si hay datos
                    {
                        oProovedor.Clave_P = Convert.ToInt32(dr["Clave_P"]);
                        oProovedor.Nombre = dr["Nombre"].ToString();
                        oProovedor.RFC = dr["RFC"].ToString();
                        oProovedor.Ciudad = dr["Ciudad"].ToString();
                        oProovedor.Direccion = dr["Direccion"].ToString();
                    }
                    else
                    {
                        oProovedor = null; // Si no hay datos, asigna null
                    }
                }
            }

            return oProovedor;
        }


        public bool Guardar(ProovedorModel oProovedor)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarProovedor", conexion);
                    cmd.Parameters.AddWithValue("Clave_P", oProovedor.Clave_P);
                    cmd.Parameters.AddWithValue("Nombre", oProovedor.Nombre);
                    cmd.Parameters.AddWithValue("RFC", oProovedor.RFC);
                    cmd.Parameters.AddWithValue("Ciudad", oProovedor.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", oProovedor.Direccion);
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

        public bool Editar(ProovedorModel oProovedor)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarProovedor", conexion);
                    cmd.Parameters.AddWithValue("Clave_", oProovedor.Clave_P);
                    cmd.Parameters.AddWithValue("Nombre", oProovedor.Nombre);
                    cmd.Parameters.AddWithValue("RFC", oProovedor.RFC);
                    cmd.Parameters.AddWithValue("Ciudad", oProovedor.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", oProovedor.Direccion);
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

        public bool Eliminar(int Clave_P)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarProovedor", conexion);
                    cmd.Parameters.AddWithValue("Clave_P", Clave_P);
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
