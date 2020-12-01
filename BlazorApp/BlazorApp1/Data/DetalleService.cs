using Model.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorApp1.Data
{
    public class DetalleService
    {
        public async Task<List<Detalle>> GetAllByTaskId(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            return await remoteService.GetAllByTaskId(id);
        }
        public async Task<Detalle> GetById(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            return await remoteService.GetDetalleById(id);
        }

        public async Task<Detalle> Delete(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            return await remoteService.DeleteDetalle(id);
        }

        public async Task<Detalle> Save(Detalle recurso)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44353/api");
            if (recurso.Id == 0)
            {
                return await remoteService.CrearDetalle(recurso);
            }
            else
            {
                return await remoteService.UpdateDetalle(recurso, recurso.Id);
            }
        }
    }
}
