using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class DetalleService
    {

        public Detalle[] GetDatalles()
        {
            var bd = new TareasDbContext();

            var list = bd.Detalle.ToArray();

            return list;

        }

        private TareasDbContext context;

        public DetalleService(TareasDbContext _context)
        {
            context = _context;
        }

        public async Task<Detalle> Get(int id)
        {
            return await context.Detalle.Where(i => i.Id == id).SingleAsync();
        }

        public async Task<List<Detalle>> GetAll()
        {
            return await context.Detalle.ToListAsync();
        }

        public async Task<Detalle> Save(Detalle value)
        {
            if (value.Id == 0)
            {
                await context.Detalle.AddAsync(value);
            }
            else
            {
                context.Detalle.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
        }

        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Detalle.Where(i => i.Id == id).SingleAsync();
            context.Detalle.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }




        /*
        public Detalle [] GetDatallesAsync()
        {
            Detalle[] res = new Detalleo[1];
            res[0] = new Usuario { int Id = 1, User = "U1", Clave = "C1" };
            
            return res;
        }
        */

        public async Task<List<Recurso>> GetRecurso()
        {
            return await context.Recurso.ToListAsync();
        }


        public async Task<List<Tarea>> GetTarea()
        {
            return await context.Tarea.ToListAsync();
        }

    }
}
