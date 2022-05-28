using ADSProject.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    public class GrupoViewModel
    {
        [Display(Name = "ID")]
        [Key]
        public int idGrupo { get; set; }

        [Display(Name = "Carrera")]
        public int idCarrera { get; set; }
        [Display(Name = "Materia")]
        public int idMateria { get; set; }
        [Display(Name = "Profesor")]
        public int idProfesor { get; set; }
        [Display(Name = "Ciclo")]
        public string ciclo { get; set; }
        [Display(Name = "Año")]
        public int year { get; set; }
        public bool estado { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]

        [ForeignKey("idCarrera")]

        public CarreraViewModel Carreras { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]

        [ForeignKey("idMateria")]

        public MateriaViewModel Materias { get; set; }

        [Display(Name = "Profesor")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]

        [ForeignKey("idProfesor")]

        public ProfesorViewModel Profesores { get; set; }

        public ICollection<AsignacionGrupoViewModel> AsignacionGrupos { get; set; }
    }
}
