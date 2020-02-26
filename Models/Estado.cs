﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class Estado
    {
        [Key, Required]
        public string Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}