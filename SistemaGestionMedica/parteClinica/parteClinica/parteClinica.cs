using System;
using System.Collections.Generic;
using System.Linq;

namespace parteClinica
{
    internal class Clinica
    {
        private List<Paciente> pacientesLista;
        private List<Medico> medicosLista;
        private List<Cita> citasLista;

        public Clinica()
        {
            pacientesLista = new List<Paciente>();
            medicosLista = new List<Medico>();
            citasLista = new List<Cita>();

            //--- Pacientes de prueba ---
            pacientesLista.Add(new Paciente("Shadow Ramirez", "26", "04240000000", "V-11.222.333"));
            pacientesLista.Add(new Paciente("Chris Chan", "43", "04240000000", "V-12.555.444"));
            pacientesLista.Add(new Paciente("Papo Salsero", "30", "04240000000", "V-13.777.888"));

            //--- Médicos de prueba ---
            medicosLista.Add(new Medico("INTER-2026-15", "Chisturria Penurias", "Endocrinologia", "No disponible"));
            medicosLista.Add(new Medico("CIRJ-2026-16", "Horriannys Rodriguez", "Cirujia", "Disponible"));
            medicosLista.Add(new Medico("INTER-2026-17", "Valen Mistria", "Medicina Interna", "Disponible"));
        }

        public void RegistrarPaciente(string nombreCompleto, string edad, string telefono, string cedula)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(edad) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(cedula))
            {
                Console.WriteLine("Los datos no pueden estar vacios, por favor intentelo nuevamente.");
                return;
            }

            if (pacientesLista.Any(p => p.cedulaExistente == cedula))
            {
                Console.WriteLine("El paciente ya se encuentra registrado.");
                return;
            }

            pacientesLista.Add(new Paciente(nombreCompleto, edad, telefono, cedula));
            Console.WriteLine("Paciente registrado con exito.");
        }

        public void RegistrarMedico(string codigoMedico, string nombreCompleto, string especialidad, string disponibilidad)
        {
            if (string.IsNullOrWhiteSpace(codigoMedico) || string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(especialidad) || string.IsNullOrWhiteSpace(disponibilidad))
            {
                Console.WriteLine("Todos los campos son obligatorios.");
                return;
            }

            if (medicosLista.Any(m => m.codigoMedico == codigoMedico))
            {
                Console.WriteLine("El médico ya se encuentra registrado.");
                return;
            }

            medicosLista.Add(new Medico(codigoMedico, nombreCompleto, especialidad, disponibilidad));
            Console.WriteLine("Medico registrado con exito.");
        }

        public void AsignarCita(string cedulaAsignar, string codigoMedico, string motivoConsulta)
        {
            Paciente pacienteExistente = pacientesLista.FirstOrDefault(p => p.cedulaExistente == cedulaAsignar);
            Medico medicoExistente = medicosLista.FirstOrDefault(m => m.codigoMedico == codigoMedico);

            if (pacienteExistente == null)
            {
                Console.WriteLine("Los datos no corresponden a ningun paciente.");
                return;
            }

            if (medicoExistente == null)
            {
                Console.WriteLine("Los datos no corresponden a ningun medico.");
                return;
            }

            string codigoDeCitaUnico = "CITA-" + (citasLista.Count + 1);

            // Solución definitiva: Pasamos los datos tal cual los pide el constructor de tu grupo
            citasLista.Add(new Cita(codigoDeCitaUnico, pacienteExistente, medicoExistente, DateTime.Now, motivoConsulta, "pendiente"));
            Console.WriteLine("Cita asignada con exito.");
        }

        public void AtenderCita(string cedulaPendiente, string codigoMedico)
        {
            Cita citaExistente = citasLista.FirstOrDefault(c => c.pacienteAsignado.cedulaExistente == cedulaPendiente && c.medicoAsignado.codigoMedico == codigoMedico);

            if (citaExistente == null)
            {
                Console.WriteLine("Los datos no corresponden a ninguna cita.");
                return;
            }

            citaExistente.atendida_Si_o_No = true ;
            citaExistente.medicoAsignado.disponible_Si_o_No = true;
            Console.WriteLine("Cita atendida con exito.");
        }

        public void MostrarPacientes()
        {
            Console.WriteLine("---Lista de Pacientes---");
            if (pacientesLista.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }
            foreach (var p in pacientesLista)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public void MostrarTodosLosMedicos()
        {
            Console.WriteLine("---Lista de Medicos---");
            if (medicosLista.Count == 0)
            {
                Console.WriteLine("No hay medicos registrados.");
                return;
            }
            foreach (var m in medicosLista)
            {
                Console.WriteLine(m.ToString());
            }
        }

        public void MostrarMedicosDisponibles()
        {
            Console.WriteLine("---Medicos Disponibles---");
            var disponibles = medicosLista.Where(m => m.disponible_Si_o_No).ToList();
            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay medicos disponibles por el momento.");
                return;
            }
            foreach (var m in disponibles)
            {
                Console.WriteLine(m.ToString());
            }
        }

        public void MostrarCitasPendientes()
        {
            Console.WriteLine("---Listado de Citas Pendientes---");
            bool hayPendientes = false;

            foreach (var cita in citasLista)
            {
                // Solución línea 157: Evaluamos de forma segura comparando el texto
                if (cita.atendida_Si_o_No.ToString().ToLower().Contains("pendiente"))
                {
                    hayPendientes = true;
                    Console.WriteLine(cita.ToString());
                }
            }

            if (!hayPendientes)
            {
                Console.WriteLine("No hay citas pendientes.");
            }
        }

        public void MostrarHistorialCitas()
        {
            Console.WriteLine("---Historial de Citas---");
            if (citasLista.Count == 0)
            {
                Console.WriteLine("No hay citas en el historial.");
                return;
            }
            foreach (var cita in citasLista)
            {
                Console.WriteLine(cita.ToString());
            }
        }
    }
}