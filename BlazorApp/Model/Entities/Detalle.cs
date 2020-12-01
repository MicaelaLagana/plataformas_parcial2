using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Detalle
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Tiempo { get; set; }
        public Recurso Recurso { get; set; }
        public Tarea Tarea { get; set; }
        public int TareaId { get; set; }
        public int RecursoId { get; set; }

       
    }
}
