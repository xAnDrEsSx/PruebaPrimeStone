using Common.ApplicationModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Web.Helpers
{
    public class StudentVM
    {

        public int Id { get; set; } = 0;

        [Display(Name = "Ingrese No. documento del Estudiante *")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int DocumentNumber { get; set; }


        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Correo del Estudiante *")]
        [MaxLength(80, ErrorMessage = "La longitud es de máximo 80 caracteres")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre del Estudiante *")]
        [MaxLength(80, ErrorMessage = "La longitud es de máximo 80 caracteres")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Apellido del Estudiante *")]
        [MaxLength(80, ErrorMessage = "La longitud es de máximo 80 caracteres")]
        public string LastName { get; set; }

        public List<StudentAM> StudentAM { get; set; }

    }
}
