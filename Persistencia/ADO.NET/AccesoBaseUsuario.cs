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
    public class AccesoBaseUsuario : AccesoBase
    {
        public int Create(DTOPersistenciaUsuario usuario)
        {
            try
            {
                string sql = "insert into usuario(email, contrasenia, nombre, apellido, fechaNac, pais, ciudad, rutaImgPerfil, profesion, empresa,urlSitioWebProfesional, descripcionPersonal, visitasTotales, promedioValoraciones)"
                + " output INSERTED.id"
                + " values (@email, @contrasenia, @nombre, @apellido, @fechaNac, @pais, @ciudad, @rutaImgPerfil, @profesion, @empresa, @urlSitioWebProfesional, @descripcionPersonal, @visitasTotales, @promedioValoraciones)";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Email
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contrasenia",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Contrasenia
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Nombre
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@apellido",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Apellido
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@fechaNac",
                    SqlDbType = SqlDbType.DateTime,
                    Value = usuario.FechaNac
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@pais",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Pais
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Ciudad
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaImgPerfil",
                    SqlDbType = SqlDbType.Text,
                    Value = usuario.RutaImgPerfil
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@profesion",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Profesion
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@empresa",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Empresa
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@@urlSitioWebProfesional",
                    SqlDbType = SqlDbType.Text,
                    Value = usuario.UrlSitioWebProfesional
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@descripcionPersonal",
                    SqlDbType = SqlDbType.Text,
                    Value = usuario.Descripcion
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@visitasTotales",
                    SqlDbType = SqlDbType.Int,
                    Value = 0
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@promedioValoraciones",
                    SqlDbType = SqlDbType.Float,
                    Value = 0
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                usuario.Id = (int)this.ExecuteScalar(command);
                //int result = this.InsertLog(usuario, LogAcciones.Alta);
                this.CommitTransaction();
                this.CloseConnection();
                return this.ExecuteNonQuery(command);
            }
            catch (Exception){throw;}
        }

        public List<DTOPersistenciaUsuario> GetAll()
        {
            List<DTOPersistenciaUsuario> usuarios = new List<DTOPersistenciaUsuario>();
            string sql = "select * from usuario";
            SqlCommand command = new SqlCommand(sql);
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            while (dataReader.Read())
            {
                usuarios.Add(new DTOPersistenciaUsuario()
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    Email = dataReader["email"].ToString(),
                    Contrasenia = dataReader["contrasenia"].ToString(),
                    Nombre = dataReader["nombre"].ToString(),
                    Apellido = dataReader["apellido"].ToString(),
                    FechaNac = DateTime.Parse(dataReader["fechaNac"].ToString()),
                    Pais = dataReader["pais"].ToString(),
                    Ciudad = dataReader["ciudad"].ToString(),
                    RutaImgPerfil = dataReader["rutaImgPerfil"].ToString(),
                    Profesion = dataReader["profesion"].ToString(),
                    Empresa = dataReader["empresa"].ToString(),
                    UrlSitioWebProfesional = dataReader["urlSitioWebProfesional"].ToString(),
                    Descripcion= dataReader["descripcionPersonal"].ToString(),
                    VisitasTotales = int.Parse(dataReader["visitasTotales"].ToString()),
                    PromedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString()),
                });
            }
            this.CloseConnection();
            return usuarios;
        }

        public DTOPersistenciaUsuario Get(string email)
        {
            string sql = "select * from usuario where email = @email";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@email",
                SqlDbType = SqlDbType.VarChar,
                Value = email
            });
            this.OpenConnetion();
            SqlDataReader dataReader = this.ExecuteReader(command);
            DTOPersistenciaUsuario usuario = null;
            if (dataReader.Read())
            {
                usuario = new DTOPersistenciaUsuario();
                usuario.Id = int.Parse(dataReader["Id"].ToString());
                usuario.Email = dataReader["email"].ToString();
                usuario.Contrasenia = dataReader["contrasenia"].ToString();
                usuario.Nombre = dataReader["nombre"].ToString();
                usuario.Apellido = dataReader["apellido"].ToString();
                usuario.FechaNac = DateTime.Parse(dataReader["fechaNac"].ToString());
                usuario.Pais = dataReader["pais"].ToString();
                usuario.Ciudad = dataReader["ciudad"].ToString();
                usuario.RutaImgPerfil = dataReader["rutaImgPerfil"].ToString();
                usuario.Profesion = dataReader["profesion"].ToString();
                usuario.Empresa = dataReader["empresa"].ToString();
                usuario.UrlSitioWebProfesional = dataReader["urlSitioWebProfesional"].ToString();
                usuario.Descripcion = dataReader["descripcionPersonal"].ToString();
                usuario.VisitasTotales = int.Parse(dataReader["visitasTotales"].ToString());
                usuario.PromedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString());
            }
            this.CloseConnection();
            return usuario;
        }

        public DTOPersistenciaUsuario Get(int id)
        {
            string sql = "select * from usuario where id = @id";
            SqlCommand command = new SqlCommand(sql);

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id
            });

            this.OpenConnetion();

            SqlDataReader dataReader = this.ExecuteReader(command);

            DTOPersistenciaUsuario usuario = null;

            if (dataReader.Read())
            {
                usuario = new DTOPersistenciaUsuario();
                usuario.Id = int.Parse(dataReader["id"].ToString());
                usuario.Email = dataReader["email"].ToString();
                usuario.Contrasenia = dataReader["contrasenia"].ToString();
                usuario.Nombre = dataReader["nombre"].ToString();
                usuario.Apellido = dataReader["apellido"].ToString();
                usuario.FechaNac = DateTime.Parse(dataReader["fechaNac"].ToString());
                usuario.Pais = dataReader["pais"].ToString();
                usuario.Ciudad = dataReader["ciudad"].ToString();
                usuario.RutaImgPerfil = dataReader["rutaImgPerfil"].ToString();
                usuario.Profesion = dataReader["profesion"].ToString();
                usuario.Empresa = dataReader["empresa"].ToString();
                usuario.UrlSitioWebProfesional = dataReader["urlSitioWebProfesional"].ToString();
                usuario.Descripcion = dataReader["descripcionPersonal"].ToString();
                usuario.VisitasTotales = int.Parse(dataReader["visitasTotales"].ToString());
                usuario.PromedioValoraciones = float.Parse(dataReader["promedioValoraciones"].ToString());
            }
            this.CloseConnection();
            return usuario;
        }

        public int Update(DTOPersistenciaUsuario usuario)
        {
            try
            {
                string sql = "update usuario set email = @email, contrasenia = @contrasenia, nombre = @nombre, apellido = @apellido, "
                + "fechaNac = @fechaNac, pais = @pais, ciudad = @ciudad, rutaImgPerfil = @rutaImgPerfil, profesion = @profesion,"
                + "empresa = @empresa, urlSitioWebProfesional = @urlSitioWebProfesional, descripcionPersonal = @descripcionPersonal, "
                + "visitasTotales = @visitasTotales, promedioValoraciones = @promedioValoraciones"
                + "where id = @id";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.Id
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@contrasenia",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Contrasenia
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Nombre
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@apellido",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Apellido
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@fechaNac",
                    SqlDbType = SqlDbType.DateTime,
                    Value = usuario.FechaNac
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@pais",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Pais
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Ciudad
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@rutaImgPerfil",
                    SqlDbType = SqlDbType.Text,
                    Value = usuario.RutaImgPerfil
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@profesion",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Profesion
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@empresa",
                    SqlDbType = SqlDbType.VarChar,
                    Value = usuario.Empresa
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@@urlSitioWebProfesional",
                    SqlDbType = SqlDbType.Text,
                    Value = usuario.UrlSitioWebProfesional
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@descripcionPersonal",
                    SqlDbType = SqlDbType.Text,
                    Value = usuario.Descripcion
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@visitasTotales",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.VisitasTotales
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@promedioValoraciones",
                    SqlDbType = SqlDbType.Float,
                    Value = usuario.PromedioValoraciones
                });
                this.OpenConnetion();
                command.Transaction = this.GetTransaction();
                int result = this.ExecuteNonQuery(command);
                //this.InsertLog(usuario, LogAcciones.Edicion);
                this.CommitTransaction();
                this.CloseConnection();
                return result;
            }
            catch (Exception){throw;}
        }

        public int UpdateValoraciones(DTOPersistenciaUsuario usuario)
        {
            try
            {
                string sql = "update usuario set promedioValoraciones=(select sum(valoracion) from valoracion where idProyecto = " + usuario.Id + ") / (select count(valoracion) from valoracion where idProyecto = " + usuario.Id + ") where id = " + usuario.Id;
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

        public int Remove(int id)
        {
            try
            {
                var usuario = this.Get(id);
                string sql = "delete from usuario where id = @id";
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
                //this.InsertLog(usuario, LogAcciones.Eliminacion);
                this.CommitTransaction();
                this.CloseConnection();
                return result;
            }
            catch (Exception){throw;}
        }
    }
}
