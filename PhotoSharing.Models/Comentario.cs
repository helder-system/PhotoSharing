﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public int FotoId { get; set; }
        public virtual Foto Foto { get; set; }
    }
}
