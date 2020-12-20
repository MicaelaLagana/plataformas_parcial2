using System;
using System.Collections.Generic;
using System.Linq;
using WabApplication.Data;
using Model.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
   [Route("WebApplication/[controller]")]
   [ApiController]
   public class RecursoController : ControllerBase
   {
      private readonly ParcialDBContext _context;

      public RecursoController(ParcialDBContext context)
      {
        _context = context;
      }

      [HttpGet]

      public List<Recurso> GetAll()
      {
        return _context.Recursos.ToList();
      }

      [HttpGet("{id}")]

      public Recurso GetRecurso(int id)
      {
        Recurso recurso = _context.Recursos.Where(i => i.Id == id).SingleOrDefault();
        return recurso;
      }

      [HttpPut]
      public Recurso EditRecurso(Recurso value)
      {
        Recurso recursoedit = _context.Recursos.Find(value.Id);
        recursoedit.Nombre = value.Nombre;
        recursoedit.UsuarioId = value.UsuarioId;
        _context.SaveChanges();
        return value;
      }

      [HttpPost]
      public Recurso CreateTarea(Recurso value)
      {
        _context.Recursos.Add(value);
        _context.SaveChanges();
        return value;
      }


      [HttpDelete("{id}")]
      public Recurso DeleteRecurso(int id)
      {
        Recurso recursoDelete= _context.Recursos.Find(id);
        _context.Recursos.Remove(recursoDelete);
        _context.SaveChanges();
        return recursoDelete;
      }

   }
}

