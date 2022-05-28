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
    public class CarreraController : Controller
    {
        private readonly ICarreraRepository carreraRepository;
        private readonly ILogger<EstudianteController> logger;

        public CarreraController(ICarreraRepository carreraRepository, ILogger<EstudianteController> logger)
        {
            this.carreraRepository = carreraRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = carreraRepository.obtenerCarreras();

                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo index del controlador carreras", ex.Message);
                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idCarrera, Operaciones operaciones)
        {
            try
            {
                var carrera = new CarreraViewModel();

                if (idCarrera.HasValue)
                {
                    carrera = carreraRepository.obtenerCarreraPorID(idCarrera.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                return View(carrera);

            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo form del controlador carreras", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(CarreraViewModel carreraViewModel)
        {
            try
            {
                //Se validad que el modelo de datos sea correcto
                if (ModelState.IsValid)
                {
                    //Almacena el ID del registro insertado
                    int id = 0;
                    if (carreraViewModel.idCarrera == 0) // En caso de insertar
                    {
                        carreraRepository.agregarCarrera(carreraViewModel);
                    }
                    else // En caso de actualizar
                    {
                        carreraRepository.actualizarCarrera
                            (carreraViewModel.idCarrera, carreraViewModel);
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
                logger.LogError("Error en el metodo form del controlador carreras", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idCarrera)
        {
            try
            {
                carreraRepository.eliminarCarrera(idCarrera);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo delete del controlador carreras", ex.Message);
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}

