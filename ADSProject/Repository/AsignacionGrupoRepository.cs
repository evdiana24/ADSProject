using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repository
{
    public class AsignacionGrupoRepository : IAsignacionGrupoRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AsignacionGrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarAsignacionGrupo(GrupoViewModel grupoViewModel)
        {
            try
            {
                ;

                if (grupoViewModel.AsignacionGrupos != null)
                {
                    agregarAsignacionGrupo(grupoViewModel.AsignacionGrupos);

                }

                return grupoViewModel.idGrupo;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Agregar lista de asignacion de grupo
        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel)
        {
            try
            {
                applicationDbContext.AsignacionGrupos.AddRange(asignacionGrupoViewModel);

                applicationDbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int actualizarAsignacionGrupo(int idAGrupo, AsignacionGrupoViewModel asignacionGrupoViewModel)
        {
            try
            {
                var item = applicationDbContext.AsignacionGrupos.SingleOrDefault(x => x.id == idAGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(asignacionGrupoViewModel);
                applicationDbContext.SaveChanges();

                return asignacionGrupoViewModel.id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deleteAsignacionGrupo(int idAGrupo)
        {
            try
            {
                var item = applicationDbContext.AsignacionGrupos.Where(x => x.id == idAGrupo).ToList();

                applicationDbContext.AsignacionGrupos.RemoveRange(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AsignacionGrupoViewModel> obtenerAsignacionesGrupo()
        {
            try
            {
                return applicationDbContext.AsignacionGrupos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AsignacionGrupoViewModel obtenerAsignacionPorID(int idAGrupo)
        {
            try
            {
                return applicationDbContext.AsignacionGrupos.SingleOrDefault(x => x.id == idAGrupo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}