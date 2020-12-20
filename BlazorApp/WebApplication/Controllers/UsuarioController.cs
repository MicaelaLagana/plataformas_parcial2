using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WabApplication.Data;
using Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
     [Route("WebApplication/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ParcialDBContext _context;

        public UsuarioController(ParcialDBContext context)
        {
            _context = context;
        }

       [HttpGet]

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

       
       [HttpGet("{id}")]

       public Usuario Get(int id)
       {
           Usuario usuario =  _context.Usuarios.Where(i => i.Id == id).SingleOrDefault();
           return usuario;
       }

       [HttpPut]
        public Usuario EditUsuario(Usuario value)
       {
           Usuario usuarioedit = _context.Usuarios.Find(value.Id);
            usuarioedit.Clave = value.Clave;
            usuarioedit.User = value.User;
           _context.SaveChanges();
           return value;
       }

        [HttpPost]
        public Usuario CreateUsuario(Usuario value)
        {
            _context.Usuarios.Add(value);
            _context.SaveChanges();
            return value;
        }


        [HttpDelete("{id}")]
        public Usuario DeleteUsuario(int id)
        {
            Usuario usuarioDelete = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioDelete);
            _context.SaveChanges();
            return usuarioDelete;
        }
    }
}
