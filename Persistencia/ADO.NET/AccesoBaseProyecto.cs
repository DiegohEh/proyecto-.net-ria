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
    public class AccesoBaseProyecto : AccesoBase
    {
        public int Create(DTOPersistenciaProyecto proyecto)
        {
            try
            {
                string sql = "insert into proyecto(titulo, visitas, rutaImgPortada, promedioValoraciones, fechaCreado, idCategoria, idUsuario)"
                + " output INSERTED.id"
                + " values (@titulo, @visitas, @rutaImgPortada, @promedioValoraciones, @fechaCreado, @idCategoria, @idUsuario)";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@titulo",
                    SqlDbType = SqlDbType.VarChar,
                    Value = proyecto.Titulo
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@visitas",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.Visitas
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaImgPortada",
                    SqlDbType = SqlDbType.Text,
                    Value = proyecto.RutaImgPortada
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@promedioValoraciones",
                    SqlDbType = SqlDbType.Float,
                    Value = proyecto.PromedioValoraciones
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@fechaCreado",
                    SqlDbType = SqlDbType.DateTime,
                    Value = proyecto.FechaCreado
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.IdCategoria
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.IdUsuario
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                proyecto.Id = (int)this.ExecuteScalar(command);
                //int result = this.InsertLog(proyecto, LogAcciones.Alta);
                this.CommitTransaction();
                this.CloseConnection();
                //Retorna el result envez
                return this.ExecuteNonQuery(command);
            }
            catch (Exception){throw;}
        }
        /*public int InsertLog(DTOPersistenciaProyecto proyecto, string accion)
        {
            string sqlLog = "insert into LogProyectos(Fecha, Accion, IdProyecto, Codigo, Descripcion, Precio)"
             + " values (@fecha, @accion, @idProyecto, @codigo, @descripcion, @precio)";

            SqlCommand commandLog = new SqlCommand(sqlLog);
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@fecha",
                SqlDbType = SqlDbType.DateTime,
                Value = DateTime.Now
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@accion",
                SqlDbType = SqlDbType.VarChar,
                Value = accion
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@idProyecto",
                SqlDbType = SqlDbType.BigInt,
                Value = proyecto.Id
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@codigo",
                SqlDbType = SqlDbType.VarChar,
                Value = proyecto.Codigo
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@descripcion",
                SqlDbType = SqlDbType.VarChar,
                Value = proyecto.Descripcion
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@precio",
                SqlDbType = SqlDbType.Float,
                Value = proyecto.Precio
            });
            commandLog.Transaction = this.GetTransaction();
            return this.ExecuteNonQuery(commandLog);
        }*/

        public List<DTOPersistenciaProyecto> GetAll()
        {
            List<DTOPersistenciaProyecto> proyectos = new List<DTOPersistenciaProyecto>();
            string sql = "select * from proyecto";
            SqlCommand command = new SqlCommand(sql);
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            while (dataReader.Read())
            {
                proyectos.Add(new DTOPersistenciaProyecto()
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    Titulo = dataReader["titulo"].ToString(),
                    Visitas = int.Parse(dataReader["visitas"].ToString()),
                    RutaImgPortada = dataReader["rutaImgPortada"].ToString(),
                    PromedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString()),
                    FechaCreado = DateTime.Parse(dataReader["fechaCreado"].ToString()),
                    IdCategoria = int.Parse(dataReader["idCategoria"].ToString()),
                    IdUsuario = int.Parse(dataReader["idUsuario"].ToString()),
                });
            }
            this.CloseConnection();
            return proyectos;
        }

        public DTOPersistenciaProyecto Get(string email)
        {
            string sql = "select * from proyecto where email = @email";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@email",
                SqlDbType = SqlDbType.VarChar,
                Value = email
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            DTOPersistenciaProyecto proyecto = null;
            if (dataReader.Read())
            {
                proyecto = new DTOPersistenciaProyecto();
                proyecto.Id = int.Parse(dataReader["id"].ToString());
                proyecto.Titulo = dataReader["titulo"].ToString();
                proyecto.Visitas = int.Parse(dataReader["visitas"].ToString());
                proyecto.RutaImgPortada = dataReader["rutaImgPortada"].ToString();
                proyecto.PromedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString());
                proyecto.FechaCreado = DateTime.Parse(dataReader["fechaCreado"].ToString());
                proyecto.IdCategoria = int.Parse(dataReader["idCategoria"].ToString());
                proyecto.IdUsuario = int.Parse(dataReader["idUsuario"].ToString());
            }
            this.CloseConnection();
            return proyecto;
        }

        public DTOPersistenciaProyecto Get(int id)
        {
            string sql = "select * from proyecto where id = @id";
            SqlCommand command = new SqlCommand(sql);

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id
            });

            this.OpenConnetion();

            SqlDataReader dataReader = this.ExecuteReader(command);

            DTOPersistenciaProyecto proyecto = null;

            if (dataReader.Read())
            {
                proyecto = new DTOPersistenciaProyecto();
                proyecto.Id = int.Parse(dataReader["id"].ToString());
                proyecto.Titulo = dataReader["titulo"].ToString();
                proyecto.Visitas = int.Parse(dataReader["visitas"].ToString());
                proyecto.RutaImgPortada = dataReader["rutaImgPortada"].ToString();
                proyecto.PromedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString());
                proyecto.FechaCreado = DateTime.Parse(dataReader["fechaCreado"].ToString());
                proyecto.IdCategoria = int.Parse(dataReader["idCategoria"].ToString());
                proyecto.IdUsuario = int.Parse(dataReader["idUsuario"].ToString());
            }
            this.CloseConnection();
            return proyecto;
        }
        public int Update(DTOPersistenciaProyecto proyecto)
        {
            try
            {
                string sql = "update proyecto set titulo = @titulo, visitas = @visitas, rutaImgPortada = @rutaImgPortada, promedioValoraciones = @promedioValoraciones, "
                + "fechaCreado = @fechaCreado, idCategoria = @idCategoria, idUsuario = @idUsuario"
                + "where id = @id";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@titulo",
                    SqlDbType = SqlDbType.VarChar,
                    Value = proyecto.Titulo
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@visitas",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.Visitas
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaImgPortada",
                    SqlDbType = SqlDbType.Text,
                    Value = proyecto.RutaImgPortada
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@promedioValoraciones",
                    SqlDbType = SqlDbType.Float,
                    Value = proyecto.PromedioValoraciones
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@fechaCreado",
                    SqlDbType = SqlDbType.DateTime,
                    Value = proyecto.FechaCreado
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.IdCategoria
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.IdUsuario
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                int result = this.ExecuteNonQuery(command);
                //this.InsertLog(proyecto, LogAcciones.Edicion);
                this.CommitTransaction();
                this.CloseConnection();
                return result;
            }
            catch (Exception){throw;}
        }
        public int Remove(int id)
        {
            try
            {
                var proyecto = this.Get(id);
                string sql = "delete from proyecto where id = @id";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = id
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                int result = this.ExecuteNonQuery(command);
                //this.InsertLog(proyecto, LogAcciones.Eliminacion);
                this.CommitTransaction();
                this.CloseConnection();
                return result;
            }
            catch (Exception){throw;}
        }
    }
}
