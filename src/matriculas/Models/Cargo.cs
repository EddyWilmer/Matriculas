﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriculas.Models
{
    /// <author>Eddy Wilmer Canaza Tito</author>
    /// <summary>
    /// Clase que define la entidad Rol.
    /// </summary>
    public class Cargo
    {
        [DatabaseG‌​enerated(DatabaseGen‌​eratedOption.None)]
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public string Nombre { get; set; }
    }
}
