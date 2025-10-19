using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TIENDA_ELECTRONICA
{
    public class Vendedor
    {
       
        
            private string cadenaConexion = @"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True";

            public void AgregarVendedor(string pIdvendedor, string pNombre, string pApellido, string pTelefono, string pCorreo, DateTime pFechaingreso)
            {
                SqlConnection mConexion = new SqlConnection(cadenaConexion);
                mConexion.Open();

                SqlCommand mComando = new SqlCommand();
                mComando.Connection = mConexion;
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.CommandText = "SP_INSERTARVENDEDOR";
                mComando.Parameters.AddWithValue("@P_IdVendedor", pIdvendedor);
                mComando.Parameters.AddWithValue("@P_Nombre", pNombre);
                mComando.Parameters.AddWithValue("@P_Apellido", pApellido);
                mComando.Parameters.AddWithValue("@P_Telefono", pTelefono);
                mComando.Parameters.AddWithValue("@P_Correo", pCorreo);
                mComando.Parameters.AddWithValue("@P_FechaIngreso", pFechaingreso);
                mComando.ExecuteNonQuery();
            }

            public void ModificarVendedor(string pIdvendedor, string pNombre, string pApellido, string pTelefono, string pCorreo, DateTime pFechaingreso)
            {
                SqlConnection mConexion = new SqlConnection(cadenaConexion);
                mConexion.Open();

                SqlCommand mComando = new SqlCommand();
                mComando.Connection = mConexion;
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.CommandText = "SP_MODIFICARVENDEDOR";
                mComando.Parameters.AddWithValue("@P_IdVendedor", pIdvendedor);
                mComando.Parameters.AddWithValue("@P_Nombre", pNombre);
                mComando.Parameters.AddWithValue("@P_Apellido", pApellido);
                mComando.Parameters.AddWithValue("@P_Telefono", pTelefono);
                mComando.Parameters.AddWithValue("@P_Correo", pCorreo);
                mComando.Parameters.AddWithValue("@P_FechaIngreso", pFechaingreso);
                mComando.ExecuteNonQuery();
            }

            public void EliminarVendedor(string pIdVendedor)
            {
            using (SqlConnection mConexion = new SqlConnection(cadenaConexion))
            {
                mConexion.Open();

                using (SqlCommand mComando = new SqlCommand("SP_ELIMINARVENDEDOR", mConexion)) 
                {
                    mComando.CommandType = CommandType.StoredProcedure;
                    mComando.Parameters.AddWithValue("@PIdVendedor", pIdVendedor);
                    mComando.ExecuteNonQuery();
                }
            }
        }

            public DataTable ListarVendedor(string pIdVendedor)
            {
                SqlConnection mConexion = new SqlConnection(cadenaConexion);
                mConexion.Open();

                SqlCommand mComando = new SqlCommand();
                SqlDataAdapter Adaptador = new SqlDataAdapter();
                DataTable Datos = new DataTable();

                mComando.Connection = mConexion;
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.CommandText = "SP_LISTAR_VENDEDOR";
                mComando.Parameters.AddWithValue("@P_IdVendedor", pIdVendedor);

                Adaptador.SelectCommand = mComando;
                Adaptador.Fill(Datos);

                return Datos;
            }

        public string GenerarIdVendedor()
        {
            string nuevoId = "";

            using (SqlConnection mConexion = new SqlConnection(cadenaConexion))
            {
                mConexion.Open();

                using (SqlCommand mComando = new SqlCommand("SP_GENERARVENDEDOR", mConexion))
                {
                    mComando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader lector = mComando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            nuevoId = lector["NuevoIdVendedor"].ToString();
                        }
                    }
                }
            }

            return nuevoId;
        }
    }
}






