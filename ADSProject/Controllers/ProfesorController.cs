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
    public class ProfesorController : Controller
    {
        private readonly IProfesorRepository profesorRepository;

        public ProfesorController(IProfesorRepository profesorRepository)
        {
            this.profesorRepository = profesorRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = profesorRepository.obtenerProfesores();

                return View(item);
            }
            catch (Exception)
            {

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
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(ProfesorViewModel profesorViewModel)
        {
            try
            {
                if (profesorViewModel.idProfesor == 0) // En caso de insertar
                {
                    profesorRepository.agregarProfesor(profesorViewModel);
                }
                else // En caso de actualizar
                {
                    profesorRepository.actualizarProfesor
                        (profesorViewModel.idProfesor, profesorViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int idProfesor)
        {
            try
            {
                profesorRepository.eliminarProfesor(idProfesor);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
