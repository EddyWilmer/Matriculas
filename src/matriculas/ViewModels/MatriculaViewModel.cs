﻿using Matriculas.Models;
using Matriculas.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriculas.ViewModels
{
    /// <author>Eddy Wilmer Canaza Tito</author>
    /// <summary>
    /// Clase para definir la entidad Matrícula que se mostrará en la vista.
    /// </summary>
    public class MatriculaViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }


        [Required, ValidateObject]
        public virtual AlumnoViewModel Alumno { get; set; }

        [Required]
        public virtual Grado Grado { get; set; }

        public virtual Seccion Seccion { get; set; }

        public virtual Colaborador Registrador { get; set; }

        public virtual AnioAcademico AnioAcademico{ get; set; }
    }
}
