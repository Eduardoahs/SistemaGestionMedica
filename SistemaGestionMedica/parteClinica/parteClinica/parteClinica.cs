using System;
using System.Collections.Generic;
using System.Linq;
using SistemaGestionMedica;

namespace SistemaGestionMedica
{
    public class parteClinica
    {
        // Listas globales compartidas
        public static List<Paciente> pacientesLista = new List<Paciente>();
        public static List<Medico> medicosLista = new List<Medico>();
        public static List<Cita> citasLista = new List<Cita>();

        public static void CargarDatosIniciales()
        {
            // 1. PACIENTES
            pacientesLista.Add(new Paciente("V-12345678", "Carlos Pérez", "20", "0412-1234567"));
            pacientesLista.Add(new Paciente("V-87654321", "María Rodríguez", "35", "0414-7654321"));
            pacientesLista.Add(new Paciente("V-11223344", "Juan Gómez", "50", "0426-1112233"));

            // 2. MÉDICOS
            medicosLista.Add(new Medico("MED-01", "Dr. Alejandro Flores", "Cardiología"));
            medicosLista.Add(new Medico("MED-02", "Dra. Elena Rostova", "Pediatría"));
            medicosLista.Add(new Medico("MED-03", "Dr. Luis Castillo", "Medicina General"));

            medicosLista[2].Disponible = false;
        }

        public static void RegistrarPaciente()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          REGISTRAR PACIENTE            ");
            Console.WriteLine("========================================");

            // 1. VALIDACIÓN DE CÉDULA
            string cedula = "";
            while (true)
            {
                Console.Write("Ingrese Cédula del Paciente (Ej: V-12345678): ");
                cedula = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(cedula) || cedula.Length < 5)
                {
                    Console.WriteLine("[!] Error: La cédula no es válida o es muy corta.");
                    continue;
                }

                if (pacientesLista.Any(p => p.Cedula == cedula))
                {
                    Console.WriteLine("\n[!] Error: Ya existe un paciente registrado con esa cédula.");
                    Console.WriteLine("\nPresione cualquier tecla para volver...");
                    Console.ReadKey();
                    return;
                }
                break;
            }

            // 2. VALIDACIÓN DE NOMBRE (No permite números ni vacíos)
            string nombreCompleto = "";
            while (true)
            {
                Console.Write("Ingrese Nombre Completo: ");
                nombreCompleto = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(nombreCompleto))
                {
                    Console.WriteLine("[!] Error: El nombre no puede estar vacío.");
                    continue;
                }
                if (nombreCompleto.Any(char.IsDigit))
                {
                    Console.WriteLine("[!] Error: El nombre no puede contener números.");
                    continue;
                }
                break;
            }

            // 3. VALIDACIÓN DE EDAD (No permite letras, ni vacíos, ni números gigantes que rompan)
            string edadStr = "";
            while (true)
            {
                Console.Write("Ingrese Edad (0 - 120): ");
                edadStr = Console.ReadLine().Trim();

                if (!long.TryParse(edadStr, out long edadGrande) || edadGrande < 0 || edadGrande > 120)
                {
                    Console.WriteLine("[!] Error: Ingrese una edad numérica válida entre 0 y 120.");
                    continue;
                }
                break;
            }

            // 4. VALIDACIÓN DE TELÉFONO (No permite letras)
            string telefono = "";
            while (true)
            {
                Console.Write("Ingrese Teléfono: ");
                telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    Console.WriteLine("[!] Error: El teléfono no puede estar vacío.");
                    continue;
                }
                if (telefono.Any(char.IsLetter))
                {
                    Console.WriteLine("[!] Error: El teléfono no puede contener letras.");
                    continue;
                }
                break;
            }

            pacientesLista.Add(new Paciente(cedula, nombreCompleto, edadStr, telefono));
            Console.WriteLine("\n[+] Paciente registrado con éxito.");

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void RegistrarMedico()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("           REGISTRAR MÉDICO             ");
            Console.WriteLine("========================================");

            Console.Write("Ingrese Código de Médico (Ej: MED-04): ");
            string codigo = Console.ReadLine().Trim();

            if (medicosLista.Any(m => m.CodigoMedico == codigo))
            {
                Console.WriteLine("\n[!] Error: Ya existe un médico con ese código.");
                Console.WriteLine("\nPresione cualquier tecla para volver...");
                Console.ReadKey();
                return;
            }

            // VALIDACIÓN DE NOMBRE DE MÉDICO
            string nombre = "";
            while (true)
            {
                Console.Write("Ingrese Nombre del Médico: ");
                nombre = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("[!] Error: El nombre no puede estar vacío.");
                    continue;
                }
                if (nombre.Any(char.IsDigit))
                {
                    Console.WriteLine("[!] Error: El nombre del médico no puede contener números.");
                    continue;
                }
                break;
            }

            // VALIDACIÓN DE ESPECIALIDAD
            string BlackboxEspecialidad = "";
            while (true)
            {
                Console.Write("Ingrese Especialidad: ");
                BlackboxEspecialidad = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(BlackboxEspecialidad))
                {
                    Console.WriteLine("[!] Error: La especialidad no puede estar vacía.");
                    continue;
                }
                if (BlackboxEspecialidad.Any(char.IsDigit))
                {
                    Console.WriteLine("[!] Error: La especialidad no puede contener números.");
                    continue;
                }
                break;
            }

            Medico nuevoMedico = new Medico(codigo, nombre, BlackboxEspecialidad);

            Console.Write("¿Está disponible inicialmente? (si/no): ");
            string disponibleInput = Console.ReadLine().ToLower();
            nuevoMedico.Disponible = (disponibleInput == "si");

            medicosLista.Add(nuevoMedico);
            Console.WriteLine("\n[+] Médico registrado con éxito.");
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void MostrarPacientes()
        {
            Console.Clear();
            if (pacientesLista.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema.");
            }
            else
            {
                foreach (var paciente in pacientesLista)
                {
                    paciente.MostrarInformation();
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void MostrarMedicos()
        {
            Console.Clear();
            if (medicosLista.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados en el sistema.");
            }
            else
            {
                Console.WriteLine("==========================================================================");
                Console.WriteLine("ID\t\tNombre\t\t\tEspecialidad\t\tDisponible");
                Console.WriteLine("==========================================================================");
                foreach (var medico in medicosLista)
                {
                    string estado = medico.Disponible ? "Sí" : "No";
                    Console.WriteLine($"{medico.CodigoMedico}\t\t{medico.NombreCompleto}\t\t{medico.Especialidad}\t\t{estado}");
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void MostrarMedicosDisponibles()
        {
            Console.Clear();
            var disponibles = medicosLista.Where(m => m.Disponible).ToList();

            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay médicos disponibles en este momento.");
            }
            else
            {
                Console.WriteLine("==========================================================================");
                Console.WriteLine("ID\t\tNombre\t\t\tEspecialidad");
                Console.WriteLine("==========================================================================");
                foreach (var medico in disponibles)
                {
                    Console.WriteLine($"{medico.CodigoMedico}\t\t{medico.NombreCompleto}\t\t{medico.Especialidad}");
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void AgendarCita()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          AGENDAR / ASIGNAR CITA        ");
            Console.WriteLine("========================================");

            Console.Write("Ingrese Cédula del Paciente: ");
            string cedulaCita = Console.ReadLine();

            var pacienteExistente = pacientesLista.FirstOrDefault(p => p.Cedula == cedulaCita);
            if (pacienteExistente == null)
            {
                Console.WriteLine("\n[!] Error: El paciente no está registrado.");
                Console.WriteLine("\nPresione cualquier tecla para volver...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese Código del Médico requerido: ");
            string codigoMedicoCita = Console.ReadLine();

            var medicoExistente = medicosLista.FirstOrDefault(m => m.CodigoMedico == codigoMedicoCita);
            if (medicoExistente == null)
            {
                Console.WriteLine("\n[!] Error: El médico especificado no existe.");
                Console.WriteLine("\nPresione cualquier tecla para volver...");
                Console.ReadKey();
                return;
            }

            if (!medicoExistente.Disponible)
            {
                Console.WriteLine($"\n[!] Error: El {medicoExistente.NombreCompleto} no está disponible actualmente.");
                Console.WriteLine("\nPresione cualquier tecla para volver...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese la fecha y hora (Ej: 26/05/2026 09:00 AM): ");
            string fechaInput = Console.ReadLine();

            Console.Write("Ingrese motivo de la consulta: ");
            string motivo = Console.ReadLine();

            try
            {
                DateTime fechaCita = DateTime.Parse(fechaInput);

                Cita nuevaCita = new Cita(pacienteExistente, medicoExistente, fechaCita, motivo);
                citasLista.Add(nuevaCita);

                pacienteExistente.HistorialCitas.Add(nuevaCita);
                medicoExistente.PacientesAtendidos.Add(pacienteExistente);

                Console.WriteLine($"\n[+] Cita agendada con éxito. Código autogenerado: {nuevaCita.Codigo}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n[!] Error: El formato de fecha/hora no es válido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void AtenderCita()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("              ATENDER CITA              ");
            Console.WriteLine("========================================");

            Console.Write("Ingrese Código de la Cita a atender: ");
            string idCita = Console.ReadLine().ToUpper();

            var cita = citasLista.FirstOrDefault(c => c.Codigo == idCita);

            if (cita == null)
            {
                Console.WriteLine("\n[!] Error: La cita no existe.");
            }
            else if (cita.Atendida)
            {
                Console.WriteLine("\n[!] Esta cita ya fue atendida previamente.");
            }
            else
            {
                cita.Atendida = true;
                Console.WriteLine("\n[+] Cita procesada correctamente. Estado cambiado a 'Atendida'.");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void MostrarCitasPendientes()
        {
            Console.Clear();
            var pendientes = citasLista.Where(c => !c.Atendida).ToList();

            if (pendientes.Count == 0)
            {
                Console.WriteLine("No hay citas pendientes por atender.");
            }
            else
            {
                foreach (var cita in pendientes)
                {
                    cita.MostrarInformacion();
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        public static void MostrarHistorialCompleto()
        {
            Console.Clear();
            if (citasLista.Count == 0)
            {
                Console.WriteLine("No hay registros de citas en el sistema.");
            }
            else
            {
                foreach (var cita in citasLista)
                {
                    cita.MostrarInformacion();
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }
    }
}