using System.ComponentModel.DataAnnotations;

namespace L02P02_2019AC603_2021CO601.Models
{
    public class libros
    {
        [Key]
        public int id { get; set; }
        public int nombre { get; set; }
        public int descripcion { get; set; }
        public int url_imagen { get; set; }
        public int id_autor { get; set; }
        public int id_categoria { get; set; }
        public int precio { get; set; }
        public int estado { get; set; }
    }
}
