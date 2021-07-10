using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ADO.NET
{
    public class AccesoBase
    {
        private SqlConnection _conexion;
        private SqlTransaction _transaction;

        private void Connect()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BaseDeDatos"].ToString();
            _conexion = new SqlConnection(connectionString);
        }

        protected void OpenConnetion()
        {
            // Si la conección es null o esta cerrada, intento crear una nueva y abrirla

            if (_conexion == null || _conexion.State == System.Data.ConnectionState.Closed)
            {
                this.Connect();
                _conexion.Open();
            }
        }
        protected void CloseConnection()
        {
            _conexion.Close();
        }
        protected int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = _conexion;
            return command.ExecuteNonQuery();
        }
        protected SqlDataReader ExecuteReader(SqlCommand command)
        {
            command.Connection = _conexion;
            return command.ExecuteReader();
        }
        protected object ExecuteScalar(SqlCommand comando)
        {
            comando.Connection = _conexion;
            return comando.ExecuteScalar();
        }

        protected SqlTransaction BeginTransaction()
        {
            return _conexion.BeginTransaction();
        }
        protected SqlTransaction GetTransaction()
        {
            if (_transaction == null)
                _transaction = this.BeginTransaction();

            return _transaction;
        }
        protected void CommitTransaction()
        {
            _transaction.Commit();
        }

    }
}
