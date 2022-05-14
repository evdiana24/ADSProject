using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        //private readonly List<EstudianteViewModel> lstEstudiantes;
        private readonly ApplicationDbContext applicationDbContext;

        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            //lstEstudiantes = new List<EstudianteViewModel>
            //{
            //    new EstudianteViewModel{ idEstudiante = 1, nombresEstudiante = "Juan", apellidosEstudiante = "Perez",
            //        codigoEstudiante = "PG16I04002", correoEstudiante = "Juan@usonsonate.edu.sv"}
            //};
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarEstudiante(EstudianteViewModel estudianteViewModel)
        {
            try
            {
                //if(lstEstudiantes.Count > 0)
                //{
                //    estudianteViewModel.idEstudiante = lstEstudiantes.Last().idEstudiante + 1;
                //} else
                //{
                //    estudianteViewModel.idEstudiante = 1;
                //}
                //lstEstudiantes.Add(estudianteViewModel);
                //return estudianteViewModel.idEstudiante;

                applicationDbContext.Estudiantes.Add(estudianteViewModel);
                applicationDbContext.SaveChanges();

                return estudianteViewModel.idEstudiante;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarEstudiante(int idEstudiante, EstudianteViewModel estudianteViewModel)
        {
            try
            {
                //lstEstudiantes[lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante)] = estudianteViewModel;

                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.idEstudiante == idEstudiante);

                applicationDbContext.Entry(item).CurrentValues.SetValues(estudianteViewModel);

                applicationDbContext.SaveChanges();

                return estudianteViewModel.idEstudiante;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarEstudiante(int idEstudiante)
        {
            try
            {
                //lstEstudiantes.RemoveAt(lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante));
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.idEstudiante == idEstudiante);

                //Borrar regristro por completo
                //applicationDbContext.Estudiantes.Remove(item);

                item.estado = false;

                applicationDbContext.Attach(item);
                
                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;

                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EstudianteViewModel obtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                //var item = lstEstudiantes.Find(x => x.idEstudiante == idEstudiante);
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.idEstudiante == idEstudiante);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EstudianteViewModel> obtenerEstudiantes()
        {
            try
            {
                //Sin filtro
                //return applicationDbContext.Estudiantes.ToList();

                //Con filtro 
                return applicationDbContext.Estudiantes.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
