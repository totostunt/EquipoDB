using Equipos.Models;
using Equipos.Models.Consultas;
using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0, opcion2 = 0;

        do
        {
            Console.WriteLine("1 - Simular partido");
            Console.WriteLine("2 - Base de datos");
            Console.WriteLine("\n0 - Salir\n");

            Int32.TryParse(Console.ReadLine(), out opcion);
            
            switch (opcion)
            {
                case 1:

                    //Creación de equipos
                    EquipoLocal equipoLocal = new EquipoLocal("Sacado", "Rodriguez");
                    EquipoVisitante equipoVisitante = new EquipoVisitante("Chispaso", "Pepe");

                    //Agregación de los jugadores dentro de los equipos
                    //Equipo local
                    equipoLocal.AgregarJugador("Jugador 1");
                    equipoLocal.AgregarJugador("Jugador 2");
                    //Equipo visitante
                    equipoVisitante.AgregarJugador("Jugador 3");
                    equipoVisitante.AgregarJugador("Jugador 4");

                    string resultado = equipoLocal.SimularPartido(equipoLocal, equipoVisitante);
                    Console.WriteLine($"\nResultado del partido: {resultado}\n");
                    break;

                case 2:

                    do
                    {
                        Console.WriteLine("1 - Ver equipos");
                        Console.WriteLine("2 - Ver jugadores");
                        Console.WriteLine("3 - Ver entrenadores");
                        Console.WriteLine("\n0 - Salir\n");

                        Int32.TryParse(Console.ReadLine(), out opcion2);

                        switch (opcion2)
                        {
                            case 1:    
                                Console.WriteLine("\n");
                                List<string> equipos = EquipoBDD.getEquipo();
                                foreach (string equipo in equipos)
                                {
                                    Console.WriteLine($"{equipo}");
                                }
                                Console.WriteLine("\n");
                                break;

                            case 2:

                                List<string> jugadores = EquipoBDD.getJugadores();
                                foreach (string j in jugadores)
                                {
                                    Console.WriteLine($"{j}");                                    
                                }                                
                                break; 

                            case 3:

                                List<string> entrenadores = EquipoBDD.getEntrenador();
                                foreach (string entrenador in entrenadores)
                                {
                                    Console.WriteLine($"{entrenador}");
                                }
                                break;

                            
                        }
                    } while ( opcion2 != 0 );
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa");
                    break;

                default:
                    Console.WriteLine("intente nuevamente.\n");
                    break;
            }      
            
        }while( opcion != 0 );
    } 
}
