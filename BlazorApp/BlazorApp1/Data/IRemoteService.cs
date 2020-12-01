using Model.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public interface IRemoteService
    {

        [Get("/Usuario")]
        public Task<List<Usuario>> GetAllUsuario();
        [Get("/Usuario/{id}")]
        public Task<Usuario> GetUsuarioById(int id);
        [Delete("/Usuario/{id}")]
        public Task<Usuario> DeleteUsuario(int id);
        [Post("/Usuario")]
        public Task<Usuario> CrearUsuario([Body] Usuario usuario);
        [Put("/Usuario")]
        public Task<Usuario> UpdateUsuario([Body] Usuario usuario, int id);

    
        [Get("/Detalle/Tarea/{id}")]
        Task<List<Detalle>> GetAllByTaskId(int id);
        [Get("/Detalle/{id}")]
        Task<Detalle> GetDetalleById(int id);
        [Delete("/Detalle/{id}")]
        public Task<Detalle> DeleteDetalle(int id);
        [Post("/Detalle")]
        public Task<Detalle> CrearDetalle([Body] Detalle detalle);
        [Put("/Detalle")]
        public Task<Detalle> UpdateDetalle([Body] Detalle detalle, int id);

       
        [Get("/Recurso")]
        public Task<List<Recurso>> GetAllRecurso();
        [Get("/Recurso/{id}")]
        public Task<Recurso> GetRecursoById(int id);
        [Delete("/Recurso/{id}")]
        public Task<Recurso> DeleteRecurso(int id);
        [Post("/Recurso")]
        public Task<Recurso> CrearUsuario([Body] Recurso recurso);
        [Put("/Recurso")]
        public Task<Recurso> UpdateUsuario([Body] Recurso recurso, int id);

     
        [Get("/Tarea")]
        public Task<List<Tarea>> GetAllTarea();
        [Get("/Tarea/{id}")]
        public Task<Tarea> GetTareaById(int id);
        [Delete("/Tarea/{id}")]
        public Task<Tarea> DeleteTarea(int id);
        [Post("/Tarea")]
        public Task<Tarea> CrearTarea([Body] Tarea recurso);
        [Put("/Tarea")]
        public Task<Tarea> UpdateTarea([Body] Tarea recurso, int id);
    }
}