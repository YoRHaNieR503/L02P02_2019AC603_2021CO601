using System.ComponentModel.DataAnnotations;

namespace L02P02_2019AC603_2021CO601.Models
{
    public class categorias
    {
        [Key]
        public int id { get; set; }
        public int categoria { get; set; }
    }
}
