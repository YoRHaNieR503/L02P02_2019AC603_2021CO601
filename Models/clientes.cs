using System.ComponentModel.DataAnnotations;

namespace L02P02_2019AC603_2021CO601.Models
{
    public class clientes
    {
        [Key]
        public int id { get; set; }
        public int nombre { get; set; }
        public int apellido { get; set; }
        public int email { get; set; }
        public int direccion { get; set; }
        public int created_at { get; set; }
    }
}
