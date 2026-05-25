using System;
using System.Collections.Generic;
using System.Text;

namespace parteClinica
{
    public class Medico
    {
        public string codigoMedico;
        public string nombreCompleto;
        public string especialidad;
        public bool disponible_Si_o_No = false;
        string siDisponible = "disponible";
        string noDisponible = "no disponible"; 

        public Medico(string codigoMedico, string nombreCompleto, string especialidad, string disponibilidad)
        {
            this.codigoMedico = codigoMedico.ToLower();
            this.nombreCompleto = nombreCompleto;
            this.especialidad = especialidad;

            if (disponibilidad.ToLower() == "disponible")
            {
                disponible_Si_o_No = true;
            }
            
        }
        public override string ToString()
        {
            if (disponible_Si_o_No == true)
            {
                return $"Medico: {nombreCompleto} (Cod: {codigoMedico}) |  Especialidad: {especialidad} | Estado: {siDisponible}";
            }
            else
            {
                return $"Medico: {nombreCompleto} (Cod: {codigoMedico}) | Especialidad: {especialidad} | Estado: {noDisponible}";
            }
        }
    }
}
