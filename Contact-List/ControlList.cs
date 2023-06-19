using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAgenda
{
    class ControlAgenda
    {
        private Agenda _agenda;
        public ControlAgenda(Agenda agenda) 
        {
            _agenda = agenda;
        }

        public void ShowContact()
        {
            Clear();
            ShowMenu(); 
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Contactos Orden Ascendente");
                    _agenda.getContact();
                    break;
                case "2":
                    Console.WriteLine("Contactos Orden Descendente");
                    _agenda.getContactDesc();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

            ToContinue();
        }

        public void AddContact()
        {
            Clear();
            Console.WriteLine("Nuevo Contacto ");
            Contacto contacto = new Contacto();
            Console.WriteLine("Nombre: ");
            contacto.Nombre = Console.ReadLine();
            Console.WriteLine("Teléfono: ");
            contacto.Telefono = Console.ReadLine();
            Console.WriteLine("Email: ");
            contacto.Email = Console.ReadLine();

            _agenda.AgregarContacto(contacto);
            Console.WriteLine("Contacto agregado con éxito.");
            ToContinue();
        }

        public void RemoveLastContact()
        {
            Clear();
            _agenda.BorrarUltimoContacto();
            Console.WriteLine("Contacto eliminado con éxito");
            ToContinue();
        }

        public void SearchByName()
        {
            Clear();
            Console.WriteLine("Buscar contacto");
            Console.WriteLine("Nombre");
            string nombre = Console.ReadLine();

            Contacto contacto = _agenda.SearchByName(nombre);
            if(contacto != null)
            {
                Console.WriteLine("Datos: \n" + contacto);
            }
            else
            {
                Console.WriteLine("Contacto no encontrado");
            }

            ToContinue();
        }

        public static void AcercaDe()
        {
            Clear();
            Console.WriteLine("Nombre: Azahara López");

            ToContinue();
        }

        public void ShowMenu() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Mostrar orden ascendente");
            sb.AppendLine("2. Mostrar orden descendente");
            sb.AppendLine("3. Volver al menú principal");
            sb.Append("Seleccione una opción: ");

            Console.WriteLine(sb.ToString());
        }

        private static void ToContinue()
        {
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
        }

        private static void Clear()
        {
            Console.Clear();
        }
    }
}
