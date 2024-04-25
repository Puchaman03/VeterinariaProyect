using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.VETE;


namespace DataAccess.VETE
{
    public class VETEDA
    {
        private Conexion _conexion = new Conexion();

        public void Insertar(Dueños dueños)
        {
            //Obtener una instancia de la conexion 

            SqlConnection sqlConn = _conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "InsertarDueño";
                sqlComm.Parameters.Add(new SqlParameter("@Nombre", dueños.Nombre));
                sqlComm.Parameters.Add(new SqlParameter("@Apellido", dueños.Apellido));
                sqlComm.Parameters.Add(new SqlParameter("@Direccion", dueños.Direccion));
                sqlComm.Parameters.Add(new SqlParameter("@Telefono", dueños.Telefono));

                sqlComm.ExecuteNonQuery();

                dueños.Nombre = (string)sqlComm.Parameters[sqlComm.Parameters.IndexOf("@Nombre")].Value;

                sqlConn.Close();
            }
            catch (Exception ex) 
            {
                throw new Exception("VETEDA.Insertar: " + ex.Message);

            }
            finally
            { 
                sqlConn.Dispose(); 
            }


        }
        public void Modificar(Dueños dueños)
        {
            //Obtener una instancia de la conexion 

            SqlConnection sqlConn = _conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ModificarDueño";
                sqlComm.Parameters.Add(new SqlParameter("@IdDueño", dueños.IdDueño));
                sqlComm.Parameters.Add(new SqlParameter("@Nombre", dueños.Nombre));
                sqlComm.Parameters.Add(new SqlParameter("@Apellido", dueños.Apellido));
                sqlComm.Parameters.Add(new SqlParameter("@Direccion", dueños.Direccion));
                sqlComm.Parameters.Add(new SqlParameter("@Telefono", dueños.Telefono));

                if (sqlComm.ExecuteNonQuery() != 1)
                {
                    throw new Exception("VETADA.Modificar: problema al modificar");
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("VETEDA.Modificar: " + ex.Message);

            }
            finally
            {
                sqlConn.Dispose();
            }
        }
        public void Anular(Dueños dueños)
        {
            //Obtener una instancia de la conexion 

            SqlConnection sqlConn = _conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "AnularDueño";
                sqlComm.Parameters.Add(new SqlParameter("@IdDueño", dueños.IdDueño));

                sqlComm.ExecuteNonQuery();
                
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("VETEDA.Anular: " + ex.Message);

            }
            finally
            {
                sqlConn.Dispose();
            }
        }
        public List<Dueños>listar()
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            List<Dueños>? ListarDueños = new List<Dueños>();
            Dueños? dueños;
            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ListarDueños";

                sqlDataRead = sqlComm.ExecuteReader();

                while (sqlDataRead.Read())
                {
                    dueños = new();
                    dueños.IdDueño = (int)sqlDataRead["IdDueño"];
                    dueños.Nombre = sqlDataRead["Nombre"].ToString() ?? string.Empty;
                    dueños.Apellido = sqlDataRead["Apellido"].ToString() ?? string.Empty;
                    dueños.Direccion = sqlDataRead["Direccion"].ToString() ?? string.Empty;
                    dueños.Telefono = sqlDataRead["Telefono"].ToString() ?? string.Empty;

                    ListarDueños.Add(dueños);

                }
                sqlConn.Close();

                return ListarDueños;
            }
            catch (Exception ex)
            {
                throw new Exception("VETEDA.listar: " + ex.Message);

            }
            finally
            {
                sqlConn.Dispose();
            }


        }
        public Dueños BuscarID(int IdDueño)
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            Dueños? dueños = null;
            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "BuscarDueño";
                sqlComm.Parameters.Add(new SqlParameter("@IdDueño", IdDueño));

                sqlDataRead = sqlComm.ExecuteReader();



                while (sqlDataRead.Read())
                {
                    dueños = new();
                    dueños.IdDueño = (int)sqlDataRead["IdDueño"];
                    dueños.Nombre = sqlDataRead["Nombre"].ToString() ?? string.Empty;
                    dueños.Apellido = sqlDataRead["Apellido"].ToString() ?? string.Empty;
                    dueños.Direccion = sqlDataRead["Direccion"].ToString() ?? string.Empty;
                    dueños.Telefono = sqlDataRead["Telefono"].ToString() ?? string.Empty;


                }
                sqlConn.Close();

                if (dueños ==null)
                {
                    throw new Exception("VETADA.BuscarID: El ID de dueño no existe");
                }

                return dueños;
            }
            catch (Exception ex)
            {
                throw new Exception("VETEDA.listar: " + ex.Message);

            }
            finally
            {
                sqlConn.Dispose();
            }
        }

    }
}
