using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ADSProject.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoRepository grupoRepository;
        private readonly ICarreraRepository carreraRepository;
        private readonly IMateriaRepository materiaRepository;
        private readonly IProfesorRepository profesorRepository;
        private readonly ILogger<EstudianteController> logger;

        public GrupoController(IGrupoRepository grupoRepository, ICarreraRepository carreraRepository, 
            IMateriaRepository materiaRepository, IProfesorRepository profesorRepository, ILogger<EstudianteController> logger)
        {
            this.grupoRepository = grupoRepository;
            this.carreraRepository = carreraRepository;
            this.materiaRepository = materiaRepository;
            this.profesorRepository = profesorRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                //var item = grupoRepository.obtenerGrupos();

                //Se obtiene el listado de grupos con sus carreras
                var item = grupoRepository.obtenerGrupos(new string[] { "Carreras", "Materias", "Profesores" });

                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo index del controlador grupos", ex.Message);
                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idGrupo, Operaciones operaciones)
        {
            try
            {
                var grupo = new GrupoViewModel();

                if (idGrupo.HasValue)
                {
                    grupo = grupoRepository.obtenerGrupoPorID(idGrupo.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                //Obtener todas las carreras disponibles
                ViewBag.Carreras = carreraRepository.obtenerCarreras();

                //Obtener todas las materias disponibles
                ViewBag.Materias = materiaRepository.obtenerMaterias();

                //Obtener todas los profesores disponibles
                ViewBag.Profesores = profesorRepository.obtenerProfesores();

                return View(grupo);

            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo form del controlador grupos", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(GrupoViewModel grupoViewModel)
        {
            try
            {
                //Se validad que el modelo de datos sea correcto
                if (ModelState.IsValid)
                {
                    //Almacena el ID del registro insertado
                    int id = 0;
                    if (grupoViewModel.idGrupo == 0) // En caso de insertar
                    {
                        grupoRepository.agregarGrupo(grupoViewModel);
                    }
                    else // En caso de actualizar
                    {
                        grupoRepository.actualizarGrupo
                            (grupoViewModel.idGrupo, grupoViewModel);
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
                logger.LogError("Error en el metodo form del controlador grupos", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idGrupo)
        {
            try
            {
                grupoRepository.eliminarGrupo(idGrupo);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en el metodo delete del controlador grupos", ex.Message);
                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult cargarMaterias(int? idCarrera)
        {
            var listadoCarreras = idCarrera == null ? new List<MateriaViewModel>():

            materiaRepository.obtenerMaterias().Where(x => x.idCarrera == idCarrera);

            return StatusCode(StatusCodes.Status200OK, listadoCarreras);
        }
    }
}