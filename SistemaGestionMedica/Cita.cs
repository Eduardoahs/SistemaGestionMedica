using SistemaGestionMedica;
using System;
using System.Collections.Generic;
using System.Text;
public class Cita
    {
        public string Codigo { get; private set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime FechaCita { get; set; }
        public string MotivoConsulta { get; set; }
        public bool Atendida { get; set; }

        public Cita(Paciente paciente, Medico medico, DateTime fechaCita, string motivoConsulta)
        {
            Codigo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Paciente = paciente;
            Medico = medico;
            FechaCita = fechaCita;
            MotivoConsulta = motivoConsulta;
            Atendida = false;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Código cita: {Codigo}");
            Console.WriteLine($"Paciente: {Paciente.NombreCompleto}");
            Console.WriteLine($"Médico: {Medico.NombreCompleto} ({Medico.Especialidad})");
            Console.WriteLine($"Fecha: {FechaCita:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Motivo: {MotivoConsulta}");
            Console.WriteLine($"Estado: {(Atendida ? "Atendida" : "Pendiente")}");
        }
    }
