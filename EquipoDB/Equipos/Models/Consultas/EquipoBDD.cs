using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO.Pipes;

namespace Equipos.Models.Consultas
{
    public static class EquipoBDD
    {

        private static string connectionString = "Data Source=DESKTOP-O0OIP5I\\LOCALDB#5EE28CCE;Initial Catalog=EquipoBDD;user=DESKTOP-O0OIP5I\\Maki";

        public static List<string> getEquipo()
        {
            List<string> equipos = new List<string>();

            string query = "select * from equipos";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(1);

                        string equipo = $" - {nombre}.";

                        equipos.Add(equipo);
                    }
                }                  
            }
            return equipos;
        }

        public static List<string> getJugadores()
        {
            List<string> jugadores = new List<string>();

            string query = "SELECT j.id, j.nombre AS nombre_jugador, j.dni, j.fecNac as Fecha_de_nacimiento, e.nombre AS nombre_equipo, l.departamento as localidad, l.provincia\r\nFROM jugadores j\r\nINNER JOIN Equipos e ON j.equipo = e.id\r\ninner join localidad l on j.localidad = l.id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(1);
                        int dni = reader.GetInt32(2);
                        DateTime fecNac = reader.GetDateTime(3);
                        string equipo = reader.GetString(4);
                        string departamento = reader.GetString(5);
                        string provincia = reader.GetString(6);

                        string jugador = $"\n Nombre: {nombre}\n DNI: {dni}\n Fecha de Nacimiento: {fecNac.ToString("yyyy-MM-dd")}" +
                                 $"\n Equipo: {equipo}\n Partido: {departamento.ToLower()}\n Provincia: {provincia}\n";

                        jugadores.Add(jugador);
                        
                    }
                }
            }
            return jugadores;
        }

        public static List<string> getEntrenador()
        {
            List<string> entrenadores = new List<string>();

            string query = "select * from entrenador";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        string nombre = reader.GetString(1);
                        int dni = reader.GetInt32(2);
                        DateTime fecNac = reader.GetDateTime(3);

                        string entrenador = $"\n Nombre: {nombre}\n DNI: {dni}\n Fecha de nacimiento: {fecNac.ToString("yyyy-MM-dd")}\n";

                        entrenadores.Add(entrenador);
                    }
                }
            }
            return entrenadores;
        }
    }
}
