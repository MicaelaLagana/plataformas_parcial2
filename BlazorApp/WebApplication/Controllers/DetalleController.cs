using System;
using System.Collections.Generic;
using System.Linq;
using WabApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace WebApplication.Controllers
{
     [Route("WebApplication/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private readonly ParcialDBContext _context;

        public DetalleController(ParcialDBContext context)
        {
            _context = context;
        }

        [HttpGet("TareaId/{id}")]

        public List<Detalle> GetAll(int id)
        {
            return _context.Detalles.Include(i => i.Tarea).Where(i => i.TareaId == id).ToList();
        }

        [HttpGet("{id}")]

        public Detalle GetDetalle(int id)
        {
            Detalle detalle = _context.Detalles.Where(i => i.Id == id).FirstOrDefault();
            return detalle;
        }

        [HttpPut]
        public Detalle EditDetalle(Detalle value)
        {
            Detalle detailedit = _context.Detalles.Find(value.Id);
            detailedit.Fecha = value.Fecha;
            detailedit.Tiempo = value.Tiempo;
            detailedit.RecursoId = value.RecursoId;
            detailedit.TareaId = value.TareaId;
            _context.SaveChanges();
            return value;
        }

        [HttpPost]
        public Detalle CreateDetalle(Detalle value)
        {
            _context.Detalles.Add(value);
            _context.SaveChanges();
            return value;
        }


        [HttpDelete("{id}")]
        public Detalle DeleteDetalle(int id)
        {
            Detalle detaildelete = _context.Detalles.Find(id);
            _context.Detalles.Remove(detaildelete);
            _context.SaveChanges();
            return detaildelete;
        }
    }
}

