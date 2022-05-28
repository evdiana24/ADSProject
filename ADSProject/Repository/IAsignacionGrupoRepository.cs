using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
    public interface IAsignacionGrupoRepository
    {
        public int agregarAsignacionGrupo(GrupoViewModel grupoViewModel);

        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel);

        public int actualizarAsignacionGrupo(int idGrupo, AsignacionGrupoViewModel asignacionGrupoViewModel);

        public bool deleteAsignacionGrupo(int idGrupo);

        public List<AsignacionGrupoViewModel> obtenerAsignacionesGrupo();

        public AsignacionGrupoViewModel obtenerAsignacionPorID(int idGrupo);
    }
}
