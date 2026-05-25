using System;
using System.Collections.Generic;

namespace SistemaGestionMedica
{
    public class Medico
    {

        public string CodigoMedico { get; private set; }
        public string NombreCompleto { get; private set; }
        public string Especialidad { get; private set; }
        public bool Disponible { get; set; }
        public List<Paciente> PacientesAtendidos { get; private set; }

        public Medico(string codigoMedico, string nombreCompleto, string especialidad)
        {
            CodigoMedico       = codigoMedico;
            NombreCompleto     = nombreCompleto;
            Especialidad       = especialidad;
            Disponible         = true;             
            PacientesAtendidos = new List<Paciente>(); 
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         INFORMACIÓN DEL MÉDICO         ");
            Console.WriteLine("========================================");
            Console.WriteLine($"  Código         : {CodigoMedico}");
            Console.WriteLine($"  Nombre         : {NombreCompleto}");
            Console.WriteLine($"  Especialidad   : {Especialidad}");
            Console.WriteLine($"  Disponible     : {(Disponible ? "Sí" : "No")}");
            Console.WriteLine($"  Pac. atendidos : {PacientesAtendidos.Count}");
            Console.WriteLine("========================================");
        }


        public void MostrarPacientesAtendidos()
        {
            Console.WriteLine($"\n--- Pacientes atendidos por {NombreCompleto} ---");

            if (PacientesAtendidos.Count == 0)
            {
                Console.WriteLine("  Este médico aún no ha atendido pacientes.");
                return;
            }

            foreach (Paciente paciente in PacientesAtendidos)
            {
                paciente.MostrarInformacion();
            }
        }
    }
}
