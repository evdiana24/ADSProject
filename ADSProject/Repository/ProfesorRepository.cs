using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        //private readonly List<ProfesorViewModel> lstProfesores;
        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            //lstProfesores = new List<ProfesorViewModel>
            //{
            //    new ProfesorViewModel{ idProfesor = 1, nombreProfesor = "Mario", apellidoProfesor = "Torres",
            //    correoProfesor = "Mario@usonsonate.edu.sv"}
            //};

            this.applicationDbContext = applicationDbContext;
        }

        public int agregarProfesor(ProfesorViewModel profesorViewModel)
        {
            try
            {
                //if (lstProfesores.Count > 0)
                //{
                //    profesorViewModel.idProfesor = lstProfesores.Last().idProfesor + 1;
                //}
                //else
                //{
                //    profesorViewModel.idProfesor = 1;
                //}
                //lstProfesores.Add(profesorViewModel);
                //return profesorViewModel.idProfesor;

                applicationDbContext.Profesores.Add(profesorViewModel);
                applicationDbContext.SaveChanges();

                return profesorViewModel.idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarProfesor(int idProfesor, ProfesorViewModel profesorViewModel)
        {
            try
            {
                //lstProfesores[lstProfesores.FindIndex(x => x.idProfesor == idProfesor)] = profesorViewModel;


                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesorViewModel);

                applicationDbContext.SaveChanges();

                return profesorViewModel.idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarProfesor(int idProfesor)
        {
            try
            {
                //lstProfesores.RemoveAt(lstProfesores.FindIndex(x => x.idProfesor == idProfesor));

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                //Borrar regristro por completo
                //applicationDbContext.Profesores.Remove(item);

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

        public ProfesorViewModel obtenerProfesorPorID(int idProfesor)
        {
            try
            {
                //var item = lstProfesores.Find(x => x.idProfesor == idProfesor);
                
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);
                
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProfesorViewModel> obtenerProfesores()
        {
            try
            {
                //Sin filtro
                //return applicationDbContext.Profesores.ToList();

                //Con filtro 
                return applicationDbContext.Profesores.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
