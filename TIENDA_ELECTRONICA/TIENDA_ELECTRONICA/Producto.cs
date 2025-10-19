using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TIENDA_ELECTRONICA
{
    class Producto
    {
        public void AgregarProducto(string pIdProducto, string pNombre, string pDescripcion, decimal pPrecio, int pStock, string pIdCategoria)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_INSERTARPRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_IdProducto", pIdProducto);
                cmd.Parameters.AddWithValue("@P_Nombre", pNombre);
                cmd.Parameters.AddWithValue("@P_Descripcion", pDescripcion);
                cmd.Parameters.AddWithValue("@P_Precio", pPrecio);
                cmd.Parameters.AddWithValue("@P_Stock", pStock);
                cmd.Parameters.AddWithValue("@P_IdCategoria", pIdCategoria);

                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarProducto(string pIdProducto, string pNombre, string pDescripcion, decimal pPrecio, int pStock, string pIdCategoria)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_MODIFICARPRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_IdProducto", pIdProducto);
                cmd.Parameters.AddWithValue("@P_Nombre", pNombre);
                cmd.Parameters.AddWithValue("@P_Descripcion", pDescripcion);
                cmd.Parameters.AddWithValue("@P_Precio", pPrecio);
                cmd.Parameters.AddWithValue("@P_Stock", pStock);
                cmd.Parameters.AddWithValue("@P_IdCategoria", pIdCategoria);

                cmd.ExecuteNonQuery();
            }


        }
        public void EliminarProducto(string pIdProducto)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_ELIMINARPRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_IdProducto", pIdProducto);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarProducto(string pIdProducto)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_producto", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_IdProducto", pIdProducto);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                return tabla;
            }

        }

        public string GenerarCodigoProducto()
        {
            string nuevoCodigo = "";

            using (SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("SP_GENERAR_CODIGO_PRODUCTO", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.HasRows && lector.Read())
                    {
                        if (!lector.IsDBNull(0))  // Verifica que la columna tenga valor
                        {
                            nuevoCodigo = lector["NuevoIdProducto"].ToString();
                        }
                    }
                }
            }

            return nuevoCodigo;
        }

        public void LlenarComboCategorias(ComboBox combo)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdCategoria, Nombre FROM Categorias", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                combo.DataSource = dt;
                combo.DisplayMember = "Nombre";        // Lo que el usuario ve
                combo.ValueMember = "IdCategoria";     // Lo que realmente se guarda
            }
        }
    }
}
