using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace parteClinica
{

    //---Parte interna de la clinica---//
    internal class Clinica
    {
        public static void Main(string[] args)
        {
            Clinica niUnBrilloPelao = new Clinica();

            Console.WriteLine("========================================");
            Console.WriteLine(" ");
            Console.WriteLine(" SISTEMA DE LA CLINICA NIUNBRILLOPELAO");
            Console.WriteLine(" ");
            Console.WriteLine("========================================");
            Console.WriteLine(" ");
            niUnBrilloPelao.MostrarPacientes();
            niUnBrilloPelao.MostrarTodosLosMedicos();
            niUnBrilloPelao.MostrarMedicosDisponibles();
            niUnBrilloPelao.AsignarCita("V-11.222.333", "INTER-2026-17", "Infarto");
            niUnBrilloPelao.MostrarCitasPendientes();
            niUnBrilloPelao.MostrarHistorialCitas();
            Console.WriteLine(" ");

        }

        //---Las listas de las clases---//
        private List<Paciente> pacientesLista;
        private List<Medico> medicosLista;
        private List<Cita> citasLista;

        public Clinica()
        {
            //---Inicializacion de las listas---//
            pacientesLista = new List<Paciente>();
            medicosLista = new List<Medico>();
            citasLista = new List<Cita>();

            //---Paciente prueba---//

            Paciente pacientePrueba1 = new Paciente("Shadow Ramirez", "26", "04240000000", "V-11.222.333");
            Paciente pacientePrueba2 = new Paciente("Chris Chan", "43", "04240000000", "V-12.555.444");
            Paciente pacientePrueba3 = new Paciente("Papo Salsero", "30", "04240000000", "V-13.777.888");

            pacientesLista.Add(pacientePrueba1);
            pacientesLista.Add(pacientePrueba2);
            pacientesLista.Add(pacientePrueba3);

            //---Medico prueba---//

            Medico medicoPrueba1 = new Medico("INTER-2026-15", "Chisturria Penurias", "Endocrinologia", "No disponible");
            Medico medicoPrueba2 = new Medico("CIRJ-2026-16", "Horriannys Rodriguez", "Cirujia", "Disponible");
            Medico medicoPrueba3 = new Medico("INTER-2026-17", "Valen Mistria", "Medicina Interna", "Disponible");

            medicosLista.Add(medicoPrueba1);
            medicosLista.Add(medicoPrueba2);
            medicosLista.Add(medicoPrueba3);
        }

        //---Funcion para asignar las citas necesita la cedula, codigo medico y el motivo de la consulta---//
        public void AsignarCita(string cedulaAsignar, string codigoMedico, string motivoConsulta)
        {
            //---Busqueda del paciente en la lista de pacientes---//
            Paciente pacienteExistente = pacientesLista.FirstOrDefault(paciente => paciente.cedulaExistente == cedulaAsignar.ToLower());

            //---Busqueda del medico en la lista de medicos---//
            Medico medicoExistente = medicosLista.FirstOrDefault(medico => medico.codigoMedico == codigoMedico.ToLower());

            //---Validaciones para saber si el paciente existe---//

            if (pacienteExistente == null)
            {
                Console.WriteLine("Los datos no corresponden a ningun paciente. ");
                return;
            }

            if (medicoExistente == null)
            {
                Console.WriteLine("Los datos no corresponden a ningun medico. ");
                return;
            }

            var citaIngreso = new Cita(codigoMedico, pacienteExistente, medicoExistente, DateTime.Now, motivoConsulta, "pendiente");
            citasLista.Add(citaIngreso);
        }

        //---Funcion para ver las citas pendientes---//

        public void AtenderCita(string cedulaPendiente, string codigoMedico)
        {
            //---Busqueda de la cita en la lista de citas---//
            Cita citaExistente = citasLista.FirstOrDefault(citaCreada => citaCreada.pacienteAsignado.cedulaExistente == cedulaPendiente && citaCreada.medicoAsignado.codigoMedico == codigoMedico);

            if (citaExistente == null)
            {
                Console.WriteLine("Los datos no corresponden a ninguna cita. ");
                return;
            }

            //---cambio de estado citas pendientes---//

            citaExistente.atendida_Si_o_No = true;
            citaExistente.medicoAsignado.disponible_Si_o_No = true;
            Console.WriteLine("Cita atendida con exito. ");

        }

        //------Funcion para registros pacientes-------//

        public void RegistrarPaciente(string nombreCompleto, string edad, string telefono, string cedula)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(edad) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(cedula))
            {
                Console.WriteLine("Los datos no pueden estar vacios, por favor intentelo nuevamente.");
                return;
            }

            if (pacientesLista.Any(pID => pID.cedulaExistente == cedula))
            {
                Console.WriteLine("Los campos son obligatorios");
                return;
            }

            var pacienteIngreso = new Paciente(nombreCompleto, edad, telefono, cedula);
            pacientesLista.Add(pacienteIngreso);
        }

        //------Funcion para registros medicos-------//

        public void RegistrarMedico(string codigoMedico, string nombreCompleto, string especialidad, string disponibilidad)
        {
            if (string.IsNullOrWhiteSpace(codigoMedico) || string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(especialidad) || string.IsNullOrWhiteSpace(disponibilidad))
            {
                Console.WriteLine("Los campos son obligatorios");
                return;
            }

            if (medicosLista.Any(medicoIdRegistro => medicoIdRegistro.codigoMedico == codigoMedico))
            {
                Console.WriteLine("Datos ya existentes.");
                return;
            }

            var medicoIngreso = new Medico(codigoMedico, nombreCompleto, especialidad, disponibilidad.ToLower());
            medicosLista.Add(medicoIngreso);
        }

        //-----Funcion para visualizar las listas------//

        public void MostrarPacientes()
        {
            Console.WriteLine("---Lista de Pacientes---");

            if (pacientesLista.Count == 0)
            {
                Console.WriteLine("No hay pacientes disponibles actualmente");
                return;
            }
            foreach (Paciente i in pacientesLista)
            {
                Console.WriteLine(" ");
                Console.WriteLine(i);
            }
        }

        public void MostrarTodosLosMedicos()
        {
            Console.WriteLine($"========================================\n");
            Console.WriteLine("---Lista de Medicos---");

            if (medicosLista.Count == 0)
            {
                Console.WriteLine("No hay medicos disponibles actualmente");
                return;
            }
            foreach (Medico i in medicosLista)
            {
                Console.WriteLine(" ");
                Console.WriteLine(i);
            }
        }

        public void MostrarMedicosDisponibles()
        {
            Console.WriteLine($"========================================\n");
            Console.WriteLine("---Medicos Disponibles--- ");

            if (medicosLista.Count == 0)
            {
                Console.WriteLine("No hay medicos registrados.");
                return;
            }

            bool estaDisponible = false;

            foreach (Medico i in medicosLista)
            {
                if (i.disponible_Si_o_No == true)
                {
                    estaDisponible = true;
                    Console.WriteLine(" ");
                    Console.WriteLine(i);
                }
            }

            if (estaDisponible == false)
            {
                Console.WriteLine("No hay medicos disponibles por el momento.");
            }
        }

        public void MostrarCitasPendientes()
        {
            Console.WriteLine($"========================================\n");
            Console.WriteLine("---Listado de Citas Pendientes---");
            Console.WriteLine(" ");
            if (citasLista.Count == 0)
            {
                Console.WriteLine("No hay citas disponibles");
                return;
            }

            foreach (Cita citas in citasLista)
            {
                if (citas.atendida_Si_o_No == false)
                {
                    Console.WriteLine(citas);
                }
            }
        }
        public void MostrarHistorialCitas()
        {
            Console.WriteLine("---Historial de Citas---");
            Console.WriteLine(" ");
            if (citasLista.Count == 0)
            {
                Console.WriteLine("No hay citas disponibles");
                return;
            }

            foreach (Cita citas in citasLista)
            {
                Console.WriteLine(citas);
            }
        }
    }
}




