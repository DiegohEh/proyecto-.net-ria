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
        public int CreateSeccion(DTOPersistenciaSeccion seccion, DTOPersistenciaImagen imagen, DTOPersistenciaTexto texto, DTOPersistenciaVideo video)
        {
            try
            {
                string sql = "insert into seccion(idProyecto) values (@idProyecto);"
                           + "insert into imagen(idSeccion, rutaUrl) values ((select IDENT_CURRENT('seccion')), @rutaUrl);"
                           + "insert into texto(idSeccion, contenido) values ((select IDENT_CURRENT('seccion')), @contenido);"
                           + "insert into video(idSeccion, rutaUrl) values ((select IDENT_CURRENT('seccion')), @rutaUrl);";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idProyecto",
                    SqlDbType = SqlDbType.Int,
                    Value = seccion.IdProyecto
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrl",
                    SqlDbType = SqlDbType.Text,
                    Value = imagen.RutaUrl
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenido",
                    SqlDbType = SqlDbType.Text,
                    Value = texto.Contenido
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrl",
                    SqlDbType = SqlDbType.Text,
                    Value = video.RutaUrl
                });

                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                seccion.IdProyecto = (int)this.ExecuteScalar(command);
                this.CommitTransaction();
                this.CloseConnection();
                return this.ExecuteNonQuery(command);
            }
            catch (Exception){throw;}
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

        public int UpdateSeccion(DTOPersistenciaSeccion seccion, DTOPersistenciaImagen imagen, DTOPersistenciaTexto texto, DTOPersistenciaVideo video)
        {
            try
            {
                string sql = "update imagen set rutaUrl = @rutaUrl where idSeccion = @id;" +
                    "update texto set contenido = @contenido where idSeccion = @id;" +
                    "update video set rutaUrl = @rutaUrl where idSeccion = @id;";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = seccion.Id
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrl",
                    SqlDbType = SqlDbType.Text,
                    Value = imagen.RutaUrl
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenido",
                    SqlDbType = SqlDbType.Text,
                    Value = texto.Contenido
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrl",
                    SqlDbType = SqlDbType.Text,
                    Value = video.RutaUrl
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
