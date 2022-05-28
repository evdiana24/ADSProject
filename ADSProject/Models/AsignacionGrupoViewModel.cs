using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("AsignacionGrupos")]
    public class AsignacionGrupoViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "idGrupo")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idGrupo { get; set; }
        [Display(Name = "Estudiante")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idEstudiante { get; set; }
        [ForeignKey("idGrupo")]
        public GrupoViewModel Grupos { get; set; }
        [ForeignKey("idEstudiante")]
        public EstudianteViewModel Estudiantes { get; set; }
    }
}
