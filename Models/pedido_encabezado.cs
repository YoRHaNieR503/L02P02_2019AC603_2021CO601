﻿using System.ComponentModel.DataAnnotations;

namespace L02P02_2019AC603_2021CO601.Models
{
    public class pedido_encabezado
    {
        [Key]
        public int id { get; set; }
        public int? id_cliente { get; set; }
        public int? cantidad_libros { get; set; }
        public decimal? total { get; set; }

    }
}
