﻿using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        class ConsultaMedica
        {
            public string? NombrePaciente { get; set; }
            public DateTime FechaCita { get; set; }
            public string? RazonConsulta { get; set; }
            public double costoConsulta { get; set; }
        }

        private static List<ConsultaMedica> citas = new List<ConsultaMedica>();

        static void Main(string[] args)
        {
            int opción;
            do
            {
                Console.WriteLine("\n---------CITAS PARA CLINIA DENTISTA----------");
                Console.WriteLine("1. Agregar nueva cita");
                Console.WriteLine("2. Mostrar citas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out opción))
                {
                   switch (opción)
                   {
                    case 1:
                        AgregarCita();
                        break;

                    case 2:
                        MostrarCita();
                        break;

                    case 3:
                    Console.WriteLine("\nSaliendo del programa. ¡Hasta luego!\n");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                   }   
                }
                else
                {
                    Console.WriteLine("Ingrese solo númers.");
                }
            
            } while (opción !=3);





        }

        static void AgregarCita()
        {
            ConsultaMedica consulta = new ConsultaMedica();

            Console.WriteLine($"Ingrese los datos para la cita: ");
            Console.Write("Nombre del paciente: ");
            consulta.NombrePaciente = Convert.ToString(Console.ReadLine());

            Console.Write("Fecha de la cita (DD/MM/YYYY HH:MM): ");
            consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Razón de la consulta: ");
            consulta.RazonConsulta  = Convert.ToString(Console.ReadLine());

            Console.Write("Costo de la consulta: ");
            consulta.costoConsulta = Convert.ToDouble(Console.ReadLine());

            citas.Add(consulta);

            //Crear el nombre del archivo según el formato espeificado¿
            string nombreArchivo = $"Cita{citas.Count:D3}_{consulta.NombrePaciente}.txt";
            GuardarConsultaEnArchivo(consulta, nombreArchivo);
        }

        static void GuardarConsultaEnArchivo(ConsultaMedica consulta, string nombreArchivo)
        {
            //Crear el contenido del archivo
            string contenido = $"\nNombre del Paciente: {consulta.NombrePaciente}\n" +
                                $"Fecha de Cita: {consulta.FechaCita}\n" +
                                $"Razón de Consulta: {consulta.RazonConsulta}\n" +
                                $"Costo de Consulta: {consulta.costoConsulta}\n";

            //Guardar el contenido en el archivo
            File.WriteAllText(nombreArchivo, contenido);

            Console.WriteLine($"\nCita guardada en el archivo: {nombreArchivo}");
        }

        static void MostrarCita()
        {
            if (citas.Count == 0)
            {
               Console.WriteLine("No hay citas para mostrar."); 
               return;
            }

            Console.WriteLine("\nLista de Citas:");
            for (int i = 0; i < citas.Count; i++)
            {
               Console.WriteLine($"{i + 1}. {citas[i].NombrePaciente}, {citas[i].FechaCita}"); 
            }

            Console.Write("\nSeleccione el número de la cita para ver detalles: ");
            int Selecion = Convert.ToInt32(Console.ReadLine());

            if (Selecion >= 1 && Selecion <= citas.Count)
            {
                MostrarDetallesCita(citas[Selecion - 1]);
            }
            else
            {
                Console.WriteLine("Número de cita no váñido.");
            }
        }

        static void MostrarDetallesCita(ConsultaMedica cita)
        {
            Console.WriteLine($"\nDetalles de la Cita:");
            Console.WriteLine($"Nombre del Paciente: {cita.NombrePaciente}");
            Console.WriteLine($"Fecha de Cita: {cita.FechaCita}");
            Console.WriteLine($"Razón de Consulta: {cita.RazonConsulta}");
            Console.WriteLine($"Costo de Consulta: ${cita.costoConsulta}\n");
        }
    }

}
