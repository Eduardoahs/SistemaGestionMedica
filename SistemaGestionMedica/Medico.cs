using SistemaGestionMedica;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionMedica
{
    public class Medico
    {
        public string CodigoMedico { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }
        public List<Paciente> PacientesAtendidos { get; set; }

        public Medico(string codigoMedico, string nombreCompleto, string especialidad)
        {
            CodigoMedico = codigoMedico;
            NombreCompleto = nombreCompleto;
            Especialidad = especialidad;
            Disponible = true;
            PacientesAtendidos = new List<Paciente>();
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"Código Médico: {CodigoMedico}");
            Console.WriteLine($"Nombre Completo: {NombreCompleto}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Disponible: {(Disponible ? "Sí" : "No")}");
            Console.WriteLine($"Pacientes Atendidos: {PacientesAtendidos.Count}");
        }

        public void MostrarPacientesAtendidos()
        {
            if (PacientesAtendidos.Count == 0)
            {
                Console.WriteLine($"{NombreCompleto} aún no ha atendido ningún paciente.");
                return;
            }

            Console.WriteLine($"--- Pacientes atendidos por {NombreCompleto} ---");
            foreach (var paciente in PacientesAtendidos)
            {
                Console.WriteLine($"- {paciente.NombreCompleto} (Cédula: {paciente.Cedula})");
            }
        }
    }
}
