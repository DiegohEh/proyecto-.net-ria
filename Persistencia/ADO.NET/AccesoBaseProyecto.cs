using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.ADO.NET.DataTrasnferObjects;
using System.Data;
using System.Data.SqlClient;
using Persistencia.ADO.NET.Constantes;
using Persistencia.Database;


namespace Persistencia.ADO.NET
{
    public class AccesoBaseProyecto : AccesoBase
    {
        public int Create(proyecto pro, tag tag, seccion sec)
        {
            try
            {
                string sql = "insert into proyecto(titulo, visitas, rutaImgPortada, promedioValoraciones, fechaCreado, idCategoria, idUsuario)"
                + " values (@titulo, @visitas, @rutaImgPortada, @promedioValoraciones, @fechaCreado, @idCategoria, @idUsuario);"
                + "insert into tag(idProyecto, nombre)"
                + "values((select MAX(id) from proyecto), @nombre);"
                + "insert into seccion(idProyecto, contenidoTexto, rutaUrlImagen, rutaUrlVideo)"
                + "values((select MAX(id) from proyecto), @contenidoTexto, @rutaUrlImagen, @rutaUrlVideo);";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@titulo",
                    SqlDbType = SqlDbType.VarChar,
                    Value = pro.titulo
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@visitas",
                    SqlDbType = SqlDbType.Int,
                    Value = 0,
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaImgPortada",
                    SqlDbType = SqlDbType.Text,
                    Value = pro.rutaImgPortada
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@promedioValoraciones",
                    SqlDbType = SqlDbType.Float,
                    Value = 0,
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@fechaCreado",
                    SqlDbType = SqlDbType.DateTime,
                    Value = DateTime.Now
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = pro.idCategoria
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = pro.idUsuario
                });
                ////////////////////////////////
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Value = tag.nombre
                });
                ////////////////////////////////
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contenidoTexto",
                    SqlDbType = SqlDbType.Text,
                    Value = sec.contenidoTexto
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrlImagen",
                    SqlDbType = SqlDbType.Text,
                    Value = sec.rutaUrlImagen
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaUrlVideo",
                    SqlDbType = SqlDbType.Text,
                    Value = sec.rutaUrlVideo
                });

                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                pro.id = (int)this.ExecuteScalar(command);
                this.CommitTransaction();
                this.CloseConnection();
                return this.ExecuteNonQuery(command);
            }
            catch (Exception) { throw; }
        }

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

        public List<proyecto> GetBarraDeBusqueda(string busqueda)
        {
            List<proyecto> proyectos = new List<proyecto>();
            string sql = "select proyecto.titulo,proyecto.visitas,proyecto.rutaImgPortada,proyecto.promedioValoraciones,proyecto.fechaCreado" +
                " from ( ( proyecto " +
                " join tag on tag.id = proyecto.id) " +
                " join categoria on categoria.id = proyecto.idCategoria)" +
                " where proyecto.titulo like '%" + busqueda + "%' or tag.nombre like '" + busqueda + "' or categoria.nombre like '" + busqueda + "';";
            SqlCommand command = new SqlCommand(sql);
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            while (dataReader.Read())
            {
                proyectos.Add(new proyecto()
                {
                    titulo = dataReader["titulo"].ToString(),
                    visitas = int.Parse(dataReader["visitas"].ToString()),
                    rutaImgPortada = dataReader["rutaImgPortada"].ToString(),
                    promedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString()),
                    fechaCreado = DateTime.Parse(dataReader["fechaCreado"].ToString()),
                });
            }
            this.CloseConnection();
            return proyectos;
        }

        public DTOPersistenciaProyecto GetByTitulo(string titulo)
        {
            string sql = "update proyecto set visitas = visitas+1 where titulo = @titulo;"
                + "select * from proyecto where titulo = @titulo;";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@titulo",
                SqlDbType = SqlDbType.VarChar,
                Value = titulo
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
            string sql = "update proyecto set visitas = visitas + 1 where id = @id;"
                + "select * from proyecto where id = @id;";
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
                string sql = "update proyecto set titulo = @titulo, rutaImgPortada = @rutaImgPortada,"
                + "idCategoria = @idCategoria"
                + "where id = @id";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.Id
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@titulo",
                    SqlDbType = SqlDbType.VarChar,
                    Value = proyecto.Titulo
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaImgPortada",
                    SqlDbType = SqlDbType.Text,
                    Value = proyecto.RutaImgPortada
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.IdCategoria
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

        public int UpdateVisitas(DTOPersistenciaProyecto proyecto)
        {
            try
            {
                string sql = "update proyecto set visitas = visitas+1 where id = " + proyecto.Id;
                SqlCommand command = new SqlCommand(sql);
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                int result = this.ExecuteNonQuery(command);
                this.CommitTransaction();
                this.CloseConnection();
                return result;
            }
            catch (Exception) { throw; }
        }

        public int UpdateValoraciones(DTOPersistenciaProyecto proyecto, DTOPersistenciaValoracion valoracion)
        {
            try
            {
                string sql = "update valoracion set valor = @valor where idProyecto = @id;"
                    + "update proyecto set promedioValoraciones=(select sum(valoracion) from valoracion where idProyecto = @id) / (select count(valoracion) from valoracion where idProyecto = @id) where id = @id";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = proyecto.Id
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@promedioValoraciones",
                    SqlDbType = SqlDbType.Float,
                    Value = proyecto.PromedioValoraciones
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@valor",
                    SqlDbType = SqlDbType.Float,
                    Value = valoracion.Valor
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

        public int Remove(int id)
        {
            try
            {
                var proyecto = this.Get(id);
                string sql = "delete from seccion where idProyecto = @id;" +
                    "delete from proyecto where id = @id";
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
