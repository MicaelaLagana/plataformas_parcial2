using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Recurso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}
