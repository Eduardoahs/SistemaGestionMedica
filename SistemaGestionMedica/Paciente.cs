using System;
using System.Collections.Generic;

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

        public Paciente(string cedula, string nombreCompleto, int edad, string telefono)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
            Edad = edad;
            Telefono = telefono;
            HistorialCitas = new List<Cita>(); 
        }



        public void MostrarInformacion()
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
