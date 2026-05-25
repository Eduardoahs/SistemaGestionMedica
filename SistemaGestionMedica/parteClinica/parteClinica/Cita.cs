using System;
using System.Collections.Generic;
using System.Text;

namespace parteClinica
{
    public class Cita
    {
        public string codigoMedico;
        public Paciente pacienteAsignado;
        public Medico medicoAsignado;
        public DateTime fechaCita;
        public string motivoConsulta;
        public bool atendida_Si_o_No = false;
        public string fue_Atendida = "atendida";
        public string no_Fue_Atendida = "pendiente";

        public Cita(string codigoMedico, Paciente pacienteAsignado, Medico medicoAsignado, DateTime fechaCita, string motivoConsulta, string atendida)
        {
            this.codigoMedico = codigoMedico.ToLower();
            this.pacienteAsignado = pacienteAsignado;
            this.medicoAsignado = medicoAsignado;
            this.fechaCita = fechaCita;
            this.motivoConsulta = motivoConsulta;

            if (atendida.ToLower() == "atendida")
            {
                atendida_Si_o_No = true;
            }
        } 

        public override string ToString()
        {
            if (atendida_Si_o_No == true)
            {
                return $"========================================\n" +
                       $"Codigo: {codigoMedico}\n" +
                       $"{pacienteAsignado}\n" +
                       $"{medicoAsignado}\n" +
                       $"Motivo: {motivoConsulta}\n" +
                       $"Estado: {fue_Atendida}\n" +
                       $"========================================\n";
                      
            }
            else
            {
                return $"========================================\n" +
                       $"Codigo: {codigoMedico}\n" +
                       $"{pacienteAsignado}\n" +
                       $"{medicoAsignado}\n" +
                       $"Motivo: {motivoConsulta}\n" +
                       $"Estado: {no_Fue_Atendida}\n"+
                       $"========================================\n";

            }
        } 
    } 
} 
