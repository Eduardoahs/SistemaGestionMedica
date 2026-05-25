using System;
using System.Collections.Generic;
using System.Text;

namespace parteClinica
{
    public class Paciente
    {
        public string nombreCompleto;
        public string edad;
        public string telefono;
        public string cedulaExistente;

        public override string ToString()
        {
            return $"Nombre: {nombreCompleto} | Edad: {edad} | Telefono: {telefono}| Cédula: {cedulaExistente}";
        }
        public Paciente(string nombreCompleto, string edad, string telefono, string cedulaExistente)
        {
            this.nombreCompleto = nombreCompleto;
            this.telefono = telefono;
            this.edad = edad;
            this.cedulaExistente = cedulaExistente.ToLower();
        }
    }
}
