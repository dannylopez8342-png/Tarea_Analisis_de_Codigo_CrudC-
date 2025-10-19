using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace TIENDA_ELECTRONICA
{
    class Ciente
    {
        public void AgregarCliente(string pIdCliente, string pNombre, string pApellido, string pTelefono, string pCorreo, string pDireccion)
        {
            using (SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                mConexion.Open();

                SqlCommand mComando = new SqlCommand("SP_INSERTAR_CLIENTE", mConexion);
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);
                mComando.Parameters.AddWithValue("@P_NOMBRE", pNombre);
                mComando.Parameters.AddWithValue("@P_APELLIDO", pApellido);
                mComando.Parameters.AddWithValue("@P_TELEFONO", pTelefono);
                mComando.Parameters.AddWithValue("@P_CORREO", pCorreo);
                mComando.Parameters.AddWithValue("@P_DIRECCION", pDireccion);
                mComando.ExecuteNonQuery();
            }
        }

        public void ModificarCliente(string pIdCliente, string pNombre, string pApellido, string pTelefono, string pCorreo, string pDireccion)
        {
            using (SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                mConexion.Open();

                SqlCommand mComando = new SqlCommand("SP_MODIFICAR_CLIENTE", mConexion);
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);
                mComando.Parameters.AddWithValue("@P_NOMBRE", pNombre);
                mComando.Parameters.AddWithValue("@P_APELLIDO", pApellido);
                mComando.Parameters.AddWithValue("@P_TELEFONO", pTelefono);
                mComando.Parameters.AddWithValue("@P_CORREO", pCorreo);
                mComando.Parameters.AddWithValue("@P_DIRECCION", pDireccion);
                mComando.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(string pIdCliente)
        {
            using (SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                mConexion.Open();

                SqlCommand mComando = new SqlCommand("SP_ELIMINAR_CLIENTE", mConexion);
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);
                mComando.ExecuteNonQuery();
            }
        }

        public DataTable ListarCliente(string pIdCliente)
        {
            using (SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                mConexion.Open();

                SqlCommand mComando = new SqlCommand("SP_LISTAR_CLIENTE", mConexion);
                mComando.CommandType = CommandType.StoredProcedure;
                mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);

                SqlDataAdapter Adaptador = new SqlDataAdapter(mComando);
                DataTable Datos = new DataTable();

                Adaptador.Fill(Datos);

                return Datos;
            }
        }

        public string GenerarCodigoCliente()
        {
            string nuevoCodigo = "CL001";

            using (SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True"))
            {
                conexion.Open();

                string query = "SELECT MAX(IdCliente) FROM Clientes";
                SqlCommand comando = new SqlCommand(query, conexion);
                object resultado = comando.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    string ultimoCodigo = resultado.ToString().Trim();

                    if (ultimoCodigo.Length >= 5 && ultimoCodigo.StartsWith("CL"))
                    {
                        bool success = int.TryParse(ultimoCodigo.Substring(2), out int numero);
                        if (success)
                        {
                            numero += 1;
                            nuevoCodigo = "CL" + numero.ToString("D3");
                        }
                        else
                        {
                            // Si no puede parsear, iniciar desde CL001
                            nuevoCodigo = "CL001";
                        }
                    }
                    else
                    {
                        // Formato inesperado, iniciar desde CL001
                        nuevoCodigo = "CL001";
                    }
                }
            }

            return nuevoCodigo;
        }



    }
}