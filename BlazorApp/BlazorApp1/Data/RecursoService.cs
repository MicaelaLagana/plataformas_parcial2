using Model.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class RecursoService
    {
        public async Task<List<Recurso>> GetAll()
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            return await remoteService.GetAllRecurso();
        }

        public async Task<Recurso> GetById(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            return await remoteService.GetRecursoById(id);
        }

        public async Task<Recurso> Delete(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            return await remoteService.DeleteRecurso(id);
        }

        public async Task<Recurso> Save(Recurso recurso)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            if (recurso.Id == 0)
            {
                return await remoteService.CrearUsuario(recurso);
            }
            else
            {
                return await remoteService.UpdateUsuario(recurso, recurso.Id);
            }
        }
    }
}