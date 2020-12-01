using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ParcialDBContext _context;

        public TareaController(ParcialDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public List<Tarea> GetAllTareas()
        {
            return _context.Tareas.ToList();
        }


        [HttpGet("{id}")]

        public Tarea GetTarea(int id)
        {
            Tarea tarea = _context.Tareas.Where(i => i.Id == id).SingleOrDefault();
            return tarea;
        }

        [HttpPut]
        public Tarea EditTarea(Tarea value)
        {
            Tarea tareaeditar = _context.Tareas.Find(value.Id);
            tareaeditar.Titulo = value.Titulo;
            tareaeditar.Vencimiento = value.Vencimiento;
            tareaeditar.Estimacion = value.Estimacion;
            tareaeditar.ResponsableId = value.ResponsableId;
            tareaeditar.Estado = value.Estado;
            _context.SaveChanges();
            return value;
        }

        [HttpPost]
        public Tarea CreateTarea(Tarea value)
        {
            _context.Tareas.Add(value);
            _context.SaveChanges();
            return value;
        }


        [HttpDelete("{id}")]
        public Tarea DeleteTarea(int id)
        {
            Tarea tareaborrar = _context.Tareas.Find(id);
            _context.Tareas.Remove(tareaborrar);
            _context.SaveChanges();
            return tareaborrar;
        }
    }
}
