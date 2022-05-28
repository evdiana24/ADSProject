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
    public class ProfesorController : Controller
    {
        private readonly IProfesorRepository profesorRepository;
        private readonly ILogger<EstudianteController> logger;
        public ProfesorController(IProfesorRepository profesorRepository, ILogger<EstudianteController> logger)
        {
            this.profesorRepository = profesorRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = profesorRepository.obtenerProfesores();

                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo index del controlador profesores", ex.Message);
                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idProfesor, Operaciones operaciones)
        {
            try
            {
                var profesor = new ProfesorViewModel();

                if (idProfesor.HasValue)
                {
                    profesor = profesorRepository.obtenerProfesorPorID(idProfesor.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                return View(profesor);

            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo form del controlador profesores", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(ProfesorViewModel profesorViewModel)
        {
            try
            {
                //Se validad que el modelo de datos sea correcto
                if (ModelState.IsValid)
                {
                    //Almacena el ID del registro insertado
                    int id = 0;
                    if (profesorViewModel.idProfesor == 0) // En caso de insertar
                    {
                        profesorRepository.agregarProfesor(profesorViewModel);
                    }
                    else // En caso de actualizar
                    {
                        profesorRepository.actualizarProfesor
                            (profesorViewModel.idProfesor, profesorViewModel);
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
                logger.LogError("Error en el metodo form del controlador profesores", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idProfesor)
        {
            try
            {
                profesorRepository.eliminarProfesor(idProfesor);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo delete del controlador profesores", ex.Message);
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
