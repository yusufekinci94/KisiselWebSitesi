﻿using System.ComponentModel.DataAnnotations;

namespace KisiselWebSitesi.Models.Siniflar
{
    public class Ikonlar
    {
        [Key]
        public int id { get; set; }
        public string ikon { get; set; }
        public string link { get; set; }

    }
}