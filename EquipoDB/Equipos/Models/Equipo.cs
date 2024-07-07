using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipos.Models
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public List<string> Jugadores { get; set; }
        public string Entrenador { get; set; }

        public Equipo(string nombre, string entrenador)
        {
            Nombre = nombre;
            Entrenador = entrenador;
            Jugadores = new List<string>();
        }

        public void AgregarJugador(string jugador)
        {
            Jugadores.Add(jugador);
        }
        public void QuitarJugador(string jugador)
        {
            Jugadores.Remove(jugador);
        }
    }
}
