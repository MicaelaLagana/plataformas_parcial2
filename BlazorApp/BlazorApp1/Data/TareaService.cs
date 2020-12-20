using BlazorApp1.Pages;
using Model.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class TareaService
    {
        public Task<List<Tarea>> GetAll()
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            return remoteService.GetAllTarea();
        }
        public async Task<Tarea> GetById(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            return await remoteService.GetTareaById(id);
        }

        public async Task<Tarea> Delete(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            return await remoteService.DeleteTarea(id);
        }

        public async Task<Tarea> Save(Tarea tarea)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");

            if (tarea.Id == 0)
            {
                return await remoteService.CrearTarea(tarea);
            }
            else
            {
                return await remoteService.UpdateTarea(tarea, tarea.Id);
            }
        }

    }
}