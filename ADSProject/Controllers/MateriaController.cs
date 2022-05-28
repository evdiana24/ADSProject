using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class MateriaController : Controller
    {
        private readonly IMateriaRepository materiaRepository;
        private readonly ICarreraRepository carreraRepository;
        private readonly ILogger<EstudianteController> logger;

        public MateriaController(IMateriaRepository materiaRepository, ICarreraRepository carreraRepository,
            ILogger<EstudianteController> logger)
        {
            this.materiaRepository = materiaRepository;
            this.carreraRepository = carreraRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = materiaRepository.obtenerMaterias(new string[] { "Carreras" });

                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo index del controlador materias", ex.Message);
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

                //Obteniendo todas las carreras disponibles
                ViewBag.Carreras = carreraRepository.obtenerCarreras();

                return View(materia);

            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo form del controlador materias", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(MateriaViewModel materiaViewModel)
        {
            try
            {
                //Se validad que el modelo de datos sea correcto
                if (ModelState.IsValid)
                {
                    //Almacena el ID del registro insertado
                    int id = 0;
                    if (materiaViewModel.idMateria == 0) // En caso de insertar
                    {
                        materiaRepository.agregarMateria(materiaViewModel);
                    }
                    else // En caso de actualizar
                    {
                        materiaRepository.actualizarMateria
                            (materiaViewModel.idMateria, materiaViewModel);
                    }

                    if (id > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status202Accepted);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo form del controlador materias", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idMateria)
        {
            try
            {
                materiaRepository.eliminarMateria(idMateria);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo delete del controlador materias", ex.Message);
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
