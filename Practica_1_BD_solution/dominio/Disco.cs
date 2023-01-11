using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantCanciones { get; set; }
        public string UrlImagen { get; set; }
       
        [DisplayName("Estilo")]
        public Estilo Style { get; set; }
        public Edicion TipoEdicion { get; set; }
    }
}
