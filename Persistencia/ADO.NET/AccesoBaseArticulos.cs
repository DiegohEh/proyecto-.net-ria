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
    public class AccesoBaseArticulos : AccesoBase
    {

        /// <summary>
        /// Crea un articulo en base de datos
        /// </summary>
        /// <param name="articulo"></param>
        /// <returns></returns>
        public int Create(DTOPersistenciaArticulo articulo)
        {
            try
            {
                string sql = "insert into Articulos(Codigo, Descripcion, Precio)"
                            + " output INSERTED.Id"
                          + " values (@codigo, @descripcion, @precio)";

                SqlCommand command = new SqlCommand(sql);

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@codigo",
                    SqlDbType = SqlDbType.VarChar,
                    Value = articulo.Codigo
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Value = articulo.Descripcion
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@precio",
                    SqlDbType = SqlDbType.Float,
                    Value = articulo.Precio
                });

                this.OpenConnetion();

                command.Transaction = this.GetTransaction();

                articulo.Id = (long)this.ExecuteScalar(command);

                int result = this.InsertLog(articulo, LogAcciones.Alta);

                this.CommitTransaction();

                this.CloseConnection();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int InsertLog(DTOPersistenciaArticulo articulo, string accion)
        {
            string sqlLog = "insert into LogArticulos(Fecha, Accion, IdArticulo, Codigo, Descripcion, Precio)"
             + " values (@fecha, @accion, @idArticulo, @codigo, @descripcion, @precio)";

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
                ParameterName = "@idArticulo",
                SqlDbType = SqlDbType.BigInt,
                Value = articulo.Id
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@codigo",
                SqlDbType = SqlDbType.VarChar,
                Value = articulo.Codigo
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@descripcion",
                SqlDbType = SqlDbType.VarChar,
                Value = articulo.Descripcion
            });
            commandLog.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@precio",
                SqlDbType = SqlDbType.Float,
                Value = articulo.Precio
            });

            commandLog.Transaction = this.GetTransaction();

            return this.ExecuteNonQuery(commandLog);
        }

        /// <summary>
        /// Retorna la lista de todos los articulos disponibles
        /// </summary>
        /// <returns></returns>
        public List<DTOPersistenciaArticulo> GetAll()
        {
            List<DTOPersistenciaArticulo> articulos = new List<DTOPersistenciaArticulo>();

            string sql = "select * from Articulos";

            SqlCommand command = new SqlCommand(sql);

            this.OpenConnetion();

            SqlDataReader dataReader = this.ExecuteReader(command);

            while (dataReader.Read())
            {
                articulos.Add(new DTOPersistenciaArticulo()
                {
                    Id = long.Parse(dataReader["Id"].ToString()),
                    Codigo = dataReader["Codigo"].ToString(),
                    Descripcion = dataReader["Descripcion"].ToString(),
                    Precio = float.Parse(dataReader["Precio"].ToString())
                });
            }

            this.CloseConnection();

            return articulos;
        }

        /// <summary>
        /// Devuelve el articulo encontrado
        /// </summary>
        /// <param name="codigo"> Codigo de articulo a buscar</param>
        /// <returns></returns>
        public DTOPersistenciaArticulo Get(string codigo)
        {

            string sql = "select * from Articulos where Codigo = @codigo";
            SqlCommand command = new SqlCommand(sql);

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@codigo",
                SqlDbType = SqlDbType.VarChar,
                Value = codigo
            });

            this.OpenConnetion();

            SqlDataReader dataReader = this.ExecuteReader(command);

            DTOPersistenciaArticulo articulo = null;

            if (dataReader.Read())
            {
                articulo = new DTOPersistenciaArticulo();

                articulo.Id = long.Parse(dataReader["Id"].ToString());
                articulo.Codigo = dataReader["Codigo"].ToString();
                articulo.Descripcion = dataReader["Descripcion"].ToString();
                articulo.Precio = float.Parse(dataReader["Precio"].ToString());
            }

            this.CloseConnection();

            return articulo;

        }
        /// <summary>
        /// Devuelve el articulo encontrado
        /// </summary>
        /// <param name="id"> Id de articulo a buscar</param>
        /// <returns></returns>
        public DTOPersistenciaArticulo Get(long id)
        {
            string sql = "select * from Articulos where Id = @id";
            SqlCommand command = new SqlCommand(sql);

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.BigInt,
                Value = id
            });

            this.OpenConnetion();

            SqlDataReader dataReader = this.ExecuteReader(command);

            DTOPersistenciaArticulo articulo = null;

            if (dataReader.Read())
            {
                articulo = new DTOPersistenciaArticulo();

                articulo.Id = long.Parse(dataReader["Id"].ToString());
                articulo.Codigo = dataReader["Codigo"].ToString();
                articulo.Descripcion = dataReader["Descripcion"].ToString();
                articulo.Precio = float.Parse(dataReader["Precio"].ToString());
            }

            this.CloseConnection();

            return articulo;

        }

        /// <summary>
        /// Actualiza los campos de un articulo
        /// </summary>
        /// <param name="articulo"> Articulo modificado, Id requerido</param>
        /// <returns></returns>
        public int Update(DTOPersistenciaArticulo articulo)
        {
            try
            {

                string sql = "update Articulos set Codigo = @codigo, Descripcion = @descripcion, Precio = @precio "
                          + "where Id = @id";

                SqlCommand command = new SqlCommand(sql);

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.BigInt,
                    Value = articulo.Id
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@codigo",
                    SqlDbType = SqlDbType.VarChar,
                    Value = articulo.Codigo
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Value = articulo.Descripcion
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@precio",
                    SqlDbType = SqlDbType.Float,
                    Value = articulo.Precio
                });

                this.OpenConnetion();

                command.Transaction = this.GetTransaction();

                int result = this.ExecuteNonQuery(command);

                this.InsertLog(articulo, LogAcciones.Edicion);

                this.CommitTransaction();

                this.CloseConnection();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un articulo en base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(long id)
        {
            try
            {
                var articulo = this.Get(id);

                string sql = "delete from Articulos where Id = @id";

                SqlCommand command = new SqlCommand(sql);

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.BigInt,
                    Value = id
                });

                this.OpenConnetion();

                command.Transaction = this.GetTransaction();

                int result = this.ExecuteNonQuery(command);

                this.InsertLog(articulo, LogAcciones.Eliminacion);

                this.CommitTransaction();

                this.CloseConnection();

                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }


    }

}
