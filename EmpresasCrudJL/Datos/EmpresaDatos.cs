using EmpresasCrudJL.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmpresasCrudJL.Datos
{
    public class EmpresaDatos
    {

        public List<EmpresaModel> Listar()
        {
            var oLista = new List<EmpresaModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpresaModel()
                        {
                            CIF = Convert.ToInt32(dr["CIF"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            Provincia = dr["Provincia"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        public EmpresaModel Obtener(int CIF)
        {

            var oEmpresa = new EmpresaModel();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("@CIF", CIF);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) // Verifica si hay datos
                    {
                        oEmpresa.CIF = Convert.ToInt32(dr["CIF"]);
                         oEmpresa.Nombre = dr["Nombre"].ToString();
                        oEmpresa.Telefono = dr["Telefono"].ToString();
                        oEmpresa.Localidad = dr["Localidad"].ToString();
                        oEmpresa.Provincia = dr["Provincia"].ToString();
                        oEmpresa.Direccion = dr["Direccion"].ToString();
                    }
                    else
                    {
                        oEmpresa = null; // Si no hay datos, asigna null
                    }
                }
            }

            return oEmpresa;
        }


        public bool Guardar(EmpresaModel oEmpresa)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("CIF", oEmpresa.CIF);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresa.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oEmpresa.Telefono);
                    cmd.Parameters.AddWithValue("Localidad", oEmpresa.Localidad);
                    cmd.Parameters.AddWithValue("Provincia", oEmpresa.Provincia);
                    cmd.Parameters.AddWithValue("Direccion", oEmpresa.Direccion);
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

        public bool Editar(EmpresaModel oEmpresa)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("CIF", oEmpresa.CIF);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresa.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oEmpresa.Telefono);
                    cmd.Parameters.AddWithValue("Localidad", oEmpresa.Localidad);
                    cmd.Parameters.AddWithValue("Provincia", oEmpresa.Provincia);
                    cmd.Parameters.AddWithValue("Direccion", oEmpresa.Direccion);
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

        public bool Eliminar(string CIF)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("CIF", CIF);
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
