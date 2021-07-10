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
    public class AccesoBaseComentario : AccesoBase
    {
        public int Create(DTOPersistenciaComentario comentario)
        {
            try
            {
                string sql = "insert into comentario(idProyecto, idUsuario, contenido)"
                + " output INSERTED.id"
                + " values (@idProyecto, @idUsuario, @contenido)";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idProyecto",
                    SqlDbType = SqlDbType.Int,
                    Value = comentario.IdProyecto
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = comentario.IdUsuario
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenido",
                    SqlDbType = SqlDbType.Text,
                    Value = comentario.Contenido
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                comentario.Id = (int)this.ExecuteScalar(command);
                this.CommitTransaction();
                this.CloseConnection();
                return this.ExecuteNonQuery(command);
            }
            catch (Exception) { throw; }
        }

        public List<DTOPersistenciaComentario> GetByProyecto(int idProyecto)
        {
            List<DTOPersistenciaComentario> comentarios = new List<DTOPersistenciaComentario>();
            string sql = "select * from comentario where idProyecto = @idProyecto";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@idProyecto",
                SqlDbType = SqlDbType.Int,
                Value = idProyecto,
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            while (dataReader.Read())
            {
                comentarios.Add(new DTOPersistenciaComentario()
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    IdProyecto = int.Parse(dataReader["idProyecto"].ToString()),
                    IdUsuario = int.Parse(dataReader["idUsuario"].ToString()),
                    Contenido = dataReader["contenido"].ToString(),
                });
            }
            this.CloseConnection();
            return comentarios;
        }


        public DTOPersistenciaComentario Get(int id)
        {
            string sql = "select * from comentario where id = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            DTOPersistenciaComentario comentarios = null;
            if (dataReader.Read())
            {
                comentarios = new DTOPersistenciaComentario();
                comentarios.Id = int.Parse(dataReader["id"].ToString());
                comentarios.IdProyecto = int.Parse(dataReader["idProyecto"].ToString());
                comentarios.IdUsuario = int.Parse(dataReader["idUsuario"].ToString());
                comentarios.Contenido = dataReader["contenido"].ToString();
            }
            this.CloseConnection();
            return comentarios;
        }
    }
}
