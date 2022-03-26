using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class ProfesorViewModel
    {
        [Display(Name = "ID")]
        public int idProfesor { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 3 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombreProfesor { get; set; }

        [Display(Name = "Apellido")]
        public string apellidoProfesor { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "La longitud del campo no debe ser mayor a 70 caracteres ni menor de 3 caracteres.")]
        [Display(Name = "Correo")]
        public string correoProfesor { get; set; }
    }
}
