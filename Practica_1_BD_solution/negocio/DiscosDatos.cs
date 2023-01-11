using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class DiscosDatos
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
           

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, ED.Descripcion TipoEdicion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION ED where E.Id = D.IdEstilo and ED.Id = D.IdTipoEdicion and D.Activo = 1";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantCanciones = lector.GetInt32(2);

                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagenTapa"];

                    aux.Style = new Estilo();
                    aux.Style.Id = (int)lector["IdEstilo"];
                    aux.Style.Descripcion = (string)lector["Estilo"];

                    aux.TipoEdicion = new Edicion();
                    aux.TipoEdicion.Id = (int)lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)lector["TipoEdicion"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
        
        public void Agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento,CantidadCanciones, UrlImagenTapa,IdEstilo, IdTipoEdicion) values ('" + nuevo.Titulo + "', '" + nuevo.FechaLanzamiento.ToString("yyyyMMdd") + "'," + nuevo.CantCanciones + ",@urlImg, @idEstilo, @idTipoEdicion)");
                datos.setearParametros("@idEstilo", nuevo.Style.Id);
                datos.setearParametros("@idTipoEdicion", nuevo.TipoEdicion.Id);
                datos.setearParametros("@urlImg", nuevo.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Disco disco_a_modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @date, CantidadCanciones = @cantCanciones, UrlImagenTapa = @url, IdEstilo = @IdEstilo, IdTipoEdicion = @IdEdicion where Id = @id");
                
                datos.setearParametros("@titulo", disco_a_modificar.Titulo);
                datos.setearParametros("@date", disco_a_modificar.FechaLanzamiento);
                datos.setearParametros("@cantCanciones", disco_a_modificar.CantCanciones);
                datos.setearParametros("@url", disco_a_modificar.UrlImagen);
                datos.setearParametros("@IdEstilo", disco_a_modificar.Style.Id);
                datos.setearParametros("@IdEdicion", disco_a_modificar.TipoEdicion.Id);
                datos.setearParametros("@id", disco_a_modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Eliminar_fisico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from DISCOS where Id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Eliminar_logico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update DISCOS set Activo = 0 where Id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
  
    }
}
