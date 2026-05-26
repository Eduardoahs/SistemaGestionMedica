using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionMedica
{
    public class Paciente
    {
        public string Cedula { get; private set; }
        public string NombreCompleto { get; private set; }
        public int Edad { get; private set; }
        public string Telefono { get; private set; }
        public List<Cita> HistorialCitas { get; private set; }

        public string ObtenerEdad()
        {
            return Edad.ToString();
        }

        public Paciente(string cedula, string nombreCompleto, object edadInput, string telefono)
        {
            string cedulaLimpia = cedula?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(cedulaLimpia) || cedulaLimpia.Length < 3)
            {
                Cedula = "V-00000000";
            }
            else
            {
                Cedula = cedulaLimpia;
            }

            string nombreLimpio = nombreCompleto?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(nombreLimpio) || nombreLimpio.Any(char.IsDigit))
            {
                NombreCompleto = "Paciente No Registrado";
            }
            else
            {
                NombreCompleto = nombreLimpio;
            }

            string edadStr = edadInput?.ToString() ?? "0";
            if (long.TryParse(edadStr, out long edadGrande))
            {
                if (edadGrande < 0 || edadGrande > 120)
                {
                    Edad = 0;
                }
                else
                {
                    Edad = (int)edadGrande;
                }
            }
            else
            {
                Edad = 0;
            }

            string telLimpio = telefono?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(telLimpio) || telLimpio.Any(char.IsLetter))
            {
                Telefono = "Sin Numero";
            }
            else
            {
                Telefono = telLimpio;
            }

            HistorialCitas = new List<Cita>();
        }

        public void MostrarInformation()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         INFORMACIÓN DEL PACIENTE       ");
            Console.WriteLine("========================================");
            Console.WriteLine($"  Cédula         : {Cedula}");
            Console.WriteLine($"  Nombre         : {NombreCompleto}");
            Console.WriteLine($"  Edad           : {Edad} años");
            Console.WriteLine($"  Teléfono       : {Telefono}");
            Console.WriteLine($"  Total de citas : {HistorialCitas.Count}");
            Console.WriteLine("========================================");
        }

        public void MostrarHistorialCitas()
        {
            Console.WriteLine($"\n--- Historial de citas de {NombreCompleto} ---");

            if (HistorialCitas.Count == 0)
            {
                Console.WriteLine("  El paciente no tiene citas registradas.");
                return;
            }

            foreach (Cita cita in HistorialCitas)
            {
                cita.MostrarInformacion();
            }
        }
    }
}