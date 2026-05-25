using System;

namespace parteClinica
{
    class Program
    {
        static void Main(string[] args)
        {
            Clinica sistemaClinica = new Clinica();
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
                        Console.Clear();
                        Console.WriteLine("--- Registrar Nuevo Paciente ---");
                        Console.Write("Nombre Completo: ");
                        string nomPac = Console.ReadLine();
                        Console.Write("Edad: ");
                        string edadPac = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telPac = Console.ReadLine();
                        Console.Write("Cédula (Ej: V-11.222.333): ");
                        string cedPac = Console.ReadLine();

                        sistemaClinica.RegistrarPaciente(nomPac, edadPac, telPac, cedPac);
                        PresioneContinuar();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("--- Registrar Nuevo Médico ---");
                        Console.Write("Código de Médico (Ej: INTER-2026-15): ");
                        string codMed = Console.ReadLine();
                        Console.Write("Nombre Completo: ");
                        string nomMed = Console.ReadLine();
                        Console.Write("Especialidad: ");
                        string espMed = Console.ReadLine();
                        Console.Write("Disponibilidad (Disponible / No disponible): ");
                        string dispMed = Console.ReadLine();

                        sistemaClinica.RegistrarMedico(codMed, nomMed, espMed, dispMed);
                        PresioneContinuar();
                        break;

                    case "3":
                        Console.Clear();
                        sistemaClinica.MostrarPacientes();
                        PresioneContinuar();
                        break;

                    case "4":
                        Console.Clear();
                        sistemaClinica.MostrarTodosLosMedicos();
                        PresioneContinuar();
                        break;

                    case "5":
                        Console.Clear();
                        sistemaClinica.MostrarMedicosDisponibles();
                        PresioneContinuar();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("--- Asignar Nueva Cita ---");
                        Console.Write("Cédula del Paciente: ");
                        string cedAsig = Console.ReadLine();
                        Console.Write("Código del Médico: ");
                        string codMedAsig = Console.ReadLine();
                        Console.Write("Motivo de la Consulta: ");
                        string motivo = Console.ReadLine();

                        sistemaClinica.AsignarCita(cedAsig, codMedAsig, motivo);
                        PresioneContinuar();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("--- Atender Cita Pendiente ---");
                        Console.Write("Cédula del Paciente: ");
                        string cedAtend = Console.ReadLine();
                        Console.Write("Código del Médico: ");
                        string codMedAtend = Console.ReadLine();

                        sistemaClinica.AtenderCita(cedAtend, codMedAtend);
                        PresioneContinuar();
                        break;

                    case "8":
                        Console.Clear();
                        sistemaClinica.MostrarCitasPendientes();
                        PresioneContinuar();
                        break;

                    case "9":
                        Console.Clear();
                        sistemaClinica.MostrarHistorialCitas();
                        PresioneContinuar();
                        break;

                    case "10":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema... ¡Feliz día!");
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida. Intente de nuevo.");
                        PresioneContinuar();
                        break;
                }
            }
        }

        static void PresioneContinuar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}