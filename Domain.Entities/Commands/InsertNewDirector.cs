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
        public DateTime FechaNacimiento { get; set; }
        public int CantidadPremios { get; set; }

    }
}
