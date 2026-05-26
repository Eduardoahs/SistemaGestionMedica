using System;
using SistemaGestionMedica;

namespace SistemaGestionMedica
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Cargamos los datos iniciales de prueba de pacientes y médicos
            parteClinica.CargarDatosIniciales();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   SISTEMA DE GESTIÓN MÉDICA NIUNBRILLOPELAO");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar Paciente");
                Console.WriteLine("2. Registrar Médico");
                Console.WriteLine("3. Mostrar Lista de Pacientes");
                Console.WriteLine("4. Mostrar Todos los Médicos");
                Console.WriteLine("5. Mostrar Médicos Disponibles");
                Console.WriteLine("6. Agendar / Asignar Cita");
                Console.WriteLine("7. Atender Cita");
                Console.WriteLine("8. Mostrar Citas Pendientes");
                Console.WriteLine("9. Mostrar Historial Completo de Citas");
                Console.WriteLine("10. Salir");
                Console.WriteLine("========================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        parteClinica.RegistrarPaciente();
                        break;

                    case "2":
                        parteClinica.RegistrarMedico();
                        break;

                    case "3":
                        parteClinica.MostrarPacientes();
                        break;

                    case "4":
                        parteClinica.MostrarMedicos();
                        break;

                    case "5":
                        parteClinica.MostrarMedicosDisponibles();
                        break;

                    case "6":
                        parteClinica.AgendarCita();
                        break;

                    case "7":
                        parteClinica.AtenderCita();
                        break;

                    case "8":
                        parteClinica.MostrarCitasPendientes();
                        break;

                    case "9":
                        parteClinica.MostrarHistorialCompleto();
                        break;

                    case "10":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema... ¡Feliz día!");
                        break;

                    default:
                        Console.WriteLine("\n[!] Opción inválida. Intente de nuevo.");
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}