using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class MateriaController : Controller
    {
        private readonly IMateriaRepository materiaRepository;

        public MateriaController(IMateriaRepository materiaRepository)
        {
            this.materiaRepository = materiaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = materiaRepository.obtenerMaterias();

                return View(item);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idMateria, Operaciones operaciones)
        {
            try
            {
                var materia = new MateriaViewModel();

                if (idMateria.HasValue)
                {
                    materia = materiaRepository.obtenerMateriaPorID(idMateria.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                return View(materia);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(MateriaViewModel materiaViewModel)
        {
            try
            {
                if (materiaViewModel.idMateria == 0) // En caso de insertar
                {
                    materiaRepository.agregarMateria(materiaViewModel);
                }
                else // En caso de actualizar
                {
                    materiaRepository.actualizarMateria
                        (materiaViewModel.idMateria, materiaViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int idMateria)
        {
            try
            {
                materiaRepository.eliminarMateria(idMateria);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
