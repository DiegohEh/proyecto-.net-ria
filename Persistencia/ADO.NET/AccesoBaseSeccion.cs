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
    public class AccesoBaseSeccion : AccesoBase
    {
        public int CreateSeccion(DTOPersistenciaSeccion seccion)
        {
            try
            {
                string sql = "insert into seccion(idProyecto,contenidoTexto,rutaUrlImagen,rutaUrlVideo) values (@idProyecto,@contenidoTexto,@rutaUrlImagen,@rutaUrlVideo)";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idProyecto",
                    SqlDbType = SqlDbType.Int,
                    Value = seccion.IdProyecto
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenidoTexto",
                    SqlDbType = SqlDbType.Text,
                    Value = seccion.contenidoTexto
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrlImagen",
                    SqlDbType = SqlDbType.Text,
                    Value = seccion.rutaUrlImagen
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrlVideo",
                    SqlDbType = SqlDbType.Text,
                    Value = seccion.rutaUrlVideo
                });

                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                seccion.IdProyecto = (int)this.ExecuteScalar(command);
                this.CommitTransaction();
                this.CloseConnection();
                return this.ExecuteNonQuery(command);
            }
            catch (Exception) { throw; }
        }

        public DTOPersistenciaSeccion GetSeccion(int id)
        {
            string sql = "select * from seccion where id = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            DTOPersistenciaSeccion seccions = null;
            if (dataReader.Read())
            {
                seccions = new DTOPersistenciaSeccion();
                seccions.Id = int.Parse(dataReader["id"].ToString());
            }
            this.CloseConnection();
            return seccions;
        }

        public int UpdateSeccion(DTOPersistenciaSeccion seccion)
        {
            try
            {
                string sql = "update seccion set contenidoTexto = @contenidoTexto," +
                    " rutaUrlImagen = @rutaUrlImagen," +
                    " rutaUrlVideo = @rutaUrlVideo" +
                    " where idSeccion = @id;";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = seccion.Id
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenidoTexto",
                    SqlDbType = SqlDbType.Text,
                    Value = seccion.contenidoTexto
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrlImagen",
                    SqlDbType = SqlDbType.Text,
                    Value = seccion.rutaUrlImagen
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrlVideo",
                    SqlDbType = SqlDbType.Text,
                    Value = seccion.rutaUrlVideo
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                int result = this.ExecuteNonQuery(command);
                this.CommitTransaction();
                this.CloseConnection();
                return result;
            }
            catch (Exception) { throw; }
        }
    }
}
