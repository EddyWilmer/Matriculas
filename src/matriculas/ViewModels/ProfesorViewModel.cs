﻿using Matriculas.Models;
using Microsoft.AspNetCore.Mvc;
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
    /// Clase para definir la entidad Profesor que se mostrará en la vista.
    /// </summary>
    public class ProfesorViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[a-zñáéíóúA-ZÑÁÉÍÓÚ ]{2,25}", ErrorMessage = "Este campo debe contener entre 2 y 25 letras.")]
        public string ApellidoPaterno { get; set; }

        [Required (ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[a-zñáéíóúA-ZÑÁÉÍÓÚ ]{2,25}", ErrorMessage = "Este campo debe contener entre 2 y 25 letras.")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[a-zñáéíóúA-ZÑÁÉÍÓÚ ]{2,50}", ErrorMessage = "Este campo debe contener entre 2 y 50 letras.")]
        public string Nombres { get; set; }

        [Remote("IsDniProfesorUnique", "Validator", AdditionalFields = "Id")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("([0-9]{8})", ErrorMessage = "Este campo debe contener 8 números.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("([a-z_.]{5,15})", ErrorMessage = "Este campo debe contener entre 5 y 15 caracteres.")]
        public string Email { get; set; }

        [RegularExpression("([0-9]{9})", ErrorMessage = "Este campo debe contener 9 números.")]
        public string Celular { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }

        public string Estado { get; set; }
    }
}
