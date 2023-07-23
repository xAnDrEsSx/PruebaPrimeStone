using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test.Domain.Administration.ApplicationModel;

namespace Test.Web.Helpers.Course
{
    public class CourseVM
    {

        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre del Curso *")]
        [MaxLength(80, ErrorMessage = "La longitud es de máximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Intensidad horaria del Curso *")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Fecha de inicio Curso *")]
        public DateTime StartDate { get; set; }

        public List<CourseAM> CourseAM { get; set; }

    }
}
