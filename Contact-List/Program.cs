using System;
using System.Text;

namespace ProyectoAgenda
{
    class Program
    {

        static ControlAgenda control = new ControlAgenda(new Agenda());

        static void Main(string[] args)
        {
            string opcion = "";


            do
            {
                Console.Clear();
                Console.WriteLine("Agenda de Contactos");
                PrintMenu();
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        control.ShowContact();
                        break;
                    case "2":
                        control.AddContact();
                        break;
                    case "3":
                        control.RemoveLastContact();
                        break;
                    case "4":
                        control.SearchByName();
                        break;
                    case "5":
                        ControlAgenda.AcercaDe();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                } 
            } while (opcion != "6");
        }

        static void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Ver contactos");
            sb.AppendLine("2. Agregar contacto");
            sb.AppendLine("3. Borrar último contacto");
            sb.AppendLine("4. Buscar Nombre contacto");
            sb.AppendLine("5. Acerca De");
            sb.AppendLine("6. Salir");
            sb.AppendLine("Seleccione una opción");

            Console.Write(sb.ToString());

        }
    }
}
