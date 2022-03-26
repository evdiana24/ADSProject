using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly List<CarreraViewModel> lstCarreras;

        public CarreraRepository()
        {
            lstCarreras = new List<CarreraViewModel>
            {
                new CarreraViewModel{ idCarrera = 1, codigoCarrera = "Ingeniería en Sistemas Computacionales", nombreCarrera = "INGCOMP"}
            };
        }

        public int agregarCarrera(CarreraViewModel carreraViewModel)
        {
            try
            {
                if (lstCarreras.Count > 0)
                {
                    carreraViewModel.idCarrera = lstCarreras.Last().idCarrera + 1;
                }
                else
                {
                    carreraViewModel.idCarrera = 1;
                }
                lstCarreras.Add(carreraViewModel);
                return carreraViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarCarrera(int idCarrera, CarreraViewModel carreraViewModel)
        {
            try
            {
                lstCarreras[lstCarreras.FindIndex(x => x.idCarrera == idCarrera)] = carreraViewModel;
                return carreraViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarCarrera(int idCarrera)
        {
            try
            {
                lstCarreras.RemoveAt(lstCarreras.FindIndex(x => x.idCarrera == idCarrera));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CarreraViewModel obtenerCarreraPorID(int idCarrera)
        {
            try
            {
                var item = lstCarreras.Find(x => x.idCarrera == idCarrera);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CarreraViewModel> obtenerCarreras()
        {
            try
            {
                return lstCarreras;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
