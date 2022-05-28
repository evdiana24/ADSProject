using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADSProject.Data;
using ADSProject.Models;
using ADSProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ADSProject.Controllers
{
    public class AsignacionGrupoController : Controller
    {
        private readonly IAsignacionGrupoRepository asignacionGrupoRepository;
        private readonly IEstudianteRepository estudianteRepository;
        private readonly IGrupoRepository grupoRepository;
        private readonly ILogger<EstudianteController> logger;

        public AsignacionGrupoController(IAsignacionGrupoRepository asignacionGrupoRepository, IEstudianteRepository estudianteRepository,
                                        IGrupoRepository grupoRepository, ILogger<EstudianteController> logger)
        {
            this.asignacionGrupoRepository = asignacionGrupoRepository;
            this.estudianteRepository = estudianteRepository;
            this.grupoRepository = grupoRepository;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Form(int idGrupo)
        {
            var estudiantes = estudianteRepository.obtenerEstudiantes();

            estudiantes.ForEach(x => x.nombresEstudiante = x.nombresEstudiante + " " + x.apellidosEstudiante);

            ViewBag.estudiantes = estudiantes;

            var grupos = new GrupoViewModel();


            grupos = grupoRepository.obtenerGrupoPorID(idGrupo, new string[]
            {
                "Carreras", "Profesores", "Materias", "AsignacionGrupos", "AsignacionGrupos.Estudiantes"
            });



            return View(grupos);
        }

        [HttpPost]
        public ActionResult Form(GrupoViewModel grupoViewModel)
        {
            try
            {
                asignacionGrupoRepository.agregarAsignacionGrupo(grupoViewModel);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                /// Se retorna una respuesta Http (en este caso un error interno).

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
