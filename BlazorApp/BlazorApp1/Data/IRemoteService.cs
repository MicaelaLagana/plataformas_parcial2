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
        public Task<List<Usuario>> GetAllUsuarios();

        [Get("/Usuario/{id}")]
        public Task<Usuario> GetUsuario(int id);
        
        [Delete("/Usuario/{id}")]
        public Task<Usuario> DeleteUsuario(int id);

        [Post("/Usuario")]
        public Task<Usuario> CreateUsuario([Body] Usuario usuario);

        [Put("/Usuario")]
        public Task<Usuario> EditUsuario([Body] Usuario usuario);
        




        [Get("/Tarea")]
        public Task<List<Tarea>> GetAllTareas();

        [Get("/Tarea/{id}")]
        public Task<Tarea> GetTarea(int id);

        [Delete("/Tarea/{id}")]
        public Task<Tarea> DeleteTarea(int id);

        [Post("/Tarea")]
        public Task<Tarea> CreateTarea([Body] Tarea tarea);

        [Put("/Tarea")]
        public Task<Tarea> EditTarea([Body] Tarea tarea);




        [Get("/Recurso")]
        public Task<List<Recurso>> GetAllRecursos();

        [Get("/Recurso/{id}")]
        public Task<Recurso> GetRecurso(int id);

        [Delete("/Recurso/{id}")]
        public Task<Recurso> DeleteRecurso(int id);

        [Post("/Recurso")]
        public Task<Recurso> CreateRecurso([Body] Recurso recurso);

        [Put("/Recurso")]
        public Task<Recurso> EditRecurso([Body] Recurso recurso);





        [Get("/Detalle/TareaId/{id}")]
        public Task<List<Detalle>> GetAllDetalles(int id);

        [Get("/Detalle/{id}")]
        public Task<Detalle> GetDetalle(int id);

        [Delete("/Detalle/{id}")]
        public Task<Detalle> DeleteDetalle(int id);

        [Post("/Detalle")]
        public Task<Detalle> CreateDetalle([Body] Detalle detalle);

        [Put("/Detalle")]
        public Task<Detalle> EditDetalle([Body] Detalle detalle);
    }
}