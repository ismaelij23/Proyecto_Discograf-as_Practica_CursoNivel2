using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EdicionDatos
    {
       
        public List<Edicion> listar() // <== Creo la función que retorna una lista
        {
            List<Edicion> lista = new List<Edicion>(); // <== Creo una instancia de una clase List<Edicion>
            AccesoDatos datos = new AccesoDatos(); // <== Creo una instancia de una clase AccesoDatos

            try
            {
                datos.setearConsulta("select Id, Descripcion from TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Edicion aux = new Edicion();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
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
    }
}
