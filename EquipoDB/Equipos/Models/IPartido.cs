using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipos.Models
{
    public interface IPartido
    {
        string SimularPartido(Equipo equipo1, Equipo equipo2);
    }
}
