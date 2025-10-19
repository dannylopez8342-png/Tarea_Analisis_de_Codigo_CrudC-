using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TIENDA_ELECTRONICA
{
    class Categoria
    {
        public DataTable ListarCategoria(string pIdCategoria)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_LISTAR_CATEGORIAS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_IdCategoria", string.IsNullOrEmpty(pIdCategoria) ? "" : pIdCategoria);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private string cadenaConexion = @"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True";

        public void AgregarCategoria(string pIdCategoria, string pNombreCategoria, string pDescripcion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_INSERTAR_CATEGORIA", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@P_IdCategoria", pIdCategoria);
                comando.Parameters.AddWithValue("@P_NombreCategoria", pNombreCategoria);
                comando.Parameters.AddWithValue("@P_Descripcion", pDescripcion);
                comando.ExecuteNonQuery();
            }
        }

        public void ModificarCategoria(string pIdCategoria, string pNombreCategoria, string pDescripcion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_MODIFICAR_CATEGORIA", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@P_IdCategoria", pIdCategoria);
                comando.Parameters.AddWithValue("@P_NombreCategoria", pNombreCategoria);
                comando.Parameters.AddWithValue("@P_Descripcion", pDescripcion);
                comando.ExecuteNonQuery();
            }
        }

        public void EliminarCategoria(string pIdCategoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_ELIMINAR_CATEGORIA", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@P_IdCategoria", pIdCategoria);
                comando.ExecuteNonQuery();
            }
        }

        public string GenerarCodigoCategoria()
        {
            string nuevoCodigo = "";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_GENERAR_CATEGORIA", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    nuevoCodigo = reader["NuevoCodigoCategoria"].ToString();
                }
                reader.Close();
            }
            return nuevoCodigo;
        }
    }
}
