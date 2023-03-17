using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Commands
{
    public class InsertNewDirector
    {
        public string Nombre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Cantidad_Premios { get; set; }

    }
}
