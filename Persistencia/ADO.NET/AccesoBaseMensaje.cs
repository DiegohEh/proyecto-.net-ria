using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.ADO.NET.DataTrasnferObjects;
using System.Data;
using System.Data.SqlClient;
using Persistencia.ADO.NET.Constantes;

namespace Persistencia.ADO.NET
{
    public class AccesoBaseMensaje : AccesoBase
    {
        public int Create(DTOPersistenciaMensaje mensaje)
        {
            try
            {
                string sql = "insert into mensaje(idUsuarioEmisor, idUsuarioReceptor, contenido, leido)"
                + " values (@idUsuarioEmisor, @idUsuarioReceptor, @contenido, @leido)";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idUsuarioEmisor",
                    SqlDbType = SqlDbType.Int,
                    Value = mensaje.IdUsuarioEmisor
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idUsuarioReceptor",
                    SqlDbType = SqlDbType.Int,
                    Value = mensaje.IdUsuarioReceptor
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenido",
                    SqlDbType = SqlDbType.Text,
                    Value = mensaje.Contenido
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@leido",
                    SqlDbType = SqlDbType.Bit,
                    Value = mensaje.Leido
                });
                
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                mensaje.IdUsuarioEmisor = (int)this.ExecuteScalar(command);
                this.CommitTransaction();
                this.CloseConnection();
                return this.ExecuteNonQuery(command);
            }
            catch (Exception){throw;}
        }

        public List<DTOPersistenciaMensaje> GetConversation(int id)
        {
            List<DTOPersistenciaMensaje> mensajes = new List<DTOPersistenciaMensaje>();
            string sql = "select * from mensaje where id = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            while (dataReader.Read())
            {
                mensajes.Add(new DTOPersistenciaMensaje()
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    IdUsuarioEmisor = int.Parse(dataReader["idUsuarioEmisor"].ToString()),
                    IdUsuarioReceptor = int.Parse(dataReader["idUsuarioReceptor"].ToString()),
                    Contenido = dataReader["contenido"].ToString(),
                    Leido = Boolean.Parse(dataReader["leido"].ToString()),
                });
            }
            this.CloseConnection();
            return mensajes;
        }

        public DTOPersistenciaMensaje Get(int id)
        {
            string sql = "select * from mensaje where id = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            DTOPersistenciaMensaje mensajes = null;
            if (dataReader.Read())
            {
                mensajes = new DTOPersistenciaMensaje();
                mensajes.Id = int.Parse(dataReader["id"].ToString());
                mensajes.IdUsuarioEmisor = int.Parse(dataReader["idUsuarioEmisor"].ToString());
                mensajes.IdUsuarioReceptor = int.Parse(dataReader["idUsuarioReceptor"].ToString());
                mensajes.Contenido = dataReader["contenido"].ToString();
                mensajes.Leido = Boolean.Parse(dataReader["leido"].ToString());
            }
            this.CloseConnection();
            return mensajes;
        }
    }
}
