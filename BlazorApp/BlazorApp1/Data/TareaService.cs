using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class TareaService
    {
        public Tarea[] GetTareas()

        {
            var bd = new TareaDbContext();

            var list = bd.Tarea.ToArray();

            return list;
        }




        private TareaDbContext context;

        public TareaService(TareaDbContext _context)
        {
            context = _context;
        }

        public async Task<Tarea> GetTask(int id)
        {
            return await context.Tarea.Where(i => i.Id == id).SingleAsync();
        }

        public async Task<List<Tarea>> GetAllTasks()
        {
            return await context.Tarea.ToListAsync();
        }

        public async Task<Tarea> SaveTask(Tarea value)
        {
            if (value.Id == 0)
            {
                await context.Tarea.AddAsync(value);
            }
            else
            {
                context.Tarea.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
        }

        public async Task<bool> RemoveTask(int id)
        {
            var entidad = await context.Tarea.Where(i => i.Id == id).SingleAsync();
            context.Tarea.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }