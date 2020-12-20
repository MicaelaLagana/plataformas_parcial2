using Model.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class UsuarioService
    {
        public async Task<List<Usuario>> GetAll()
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            return await remoteService.GetAllUsuario();
        }

        public async Task<Usuario> GetById(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            return await remoteService.GetUsuarioById(id);
        }

        public async Task<Usuario> Delete(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            return await remoteService.DeleteUsuario(id);
        }

        public async Task<Usuario> Save(Usuario usuario)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44303/WebApplication");
            if (usuario.Id == 0)
            {
                return await remoteService.CrearUsuario(usuario);
            }
            else
            {
               return await remoteService.UpdateUsuario(usuario, usuario.Id);
            }
        }
    }
}