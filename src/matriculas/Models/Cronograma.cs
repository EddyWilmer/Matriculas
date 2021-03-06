﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriculas.Models
{
    /// <author>Luis Fernando Yana Espinoza</author>
    /// <summary>
    /// Clase que describe la entidad CronogramaMatricula (Cronograma de Matrícula).
    /// </summary>
    public class Cronograma
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AnioAcademico")]
        public int AnioAcademicoId { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateTime? FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateTime? FechaFin { get; set; }   
             
        public virtual AnioAcademico AnioAcademico { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }
    }
}
