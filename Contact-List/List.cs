using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProyectoAgenda
{
    class Agenda  
    {
        private const int TAM = 10;
        private Contacto[] _contactos;
        private int _index;

        public int NumContact
        {
            get { return _index; }
        }

        public Agenda()
        {
            _index = 0;
            _contactos = new Contacto[TAM];
        }

        public void AgregarContacto(Contacto contacto)
        {
            if(_index < TAM)
            {
                _contactos[_index] = contacto;
                _index++;
            }
            else
            {
                Console.WriteLine("Agenda Llena");
            }
                                   
        }

        public void BorrarUltimoContacto()
        {
            if (_index > 0)
            {
                _contactos[_index] = null;
                _index--;
            }
            else
            {
                Console.WriteLine("La agenda ya está vacía");
            }
        }

        private bool NoContact()
        {
            if (_index == 0)
            {
                Console.WriteLine("No hay contactos");
                return true;
            }

            return false;
        }

        //validamos
        public void getContact()
        {
            if (NoContact())
            {
                return;
            }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);

            Console.WriteLine(CadenaContactos(ordenados)); //problema -> no se van a mostrar correctamente : SOL CadenaContactos(ordenados)
        }

        public void getContactDesc()
        {
            if (NoContact())
            {
                return;
            }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);
            Array.Reverse(ordenados);

            Console.WriteLine(CadenaContactos(ordenados)); //problema -> no se van a mostrar correctamente : SOL CadenaContactos(ordenados)
        }

        public Contacto SearchByName(string nombre)
        {
            foreach (Contacto contacto in _contactos)
            {
                if(contacto != null && contacto.Nombre == nombre)
                {
                    return contacto;

                    /** a tener en cuenta que para nombres repetidos siempre nos va a mostrar el primero
                     * CORREGIR
                     */
                }
            }

            return null;
        }

        public void GetContacts()
        {
            Console.Write(this);
        }

        public override string ToString()
        {
            return CadenaContactos(_contactos);
        }

        // para override ToString() implementamos la funcion que genera
        // la cadena de contactos
        //asi mostramos los datos
        private string CadenaContactos(Contacto[] contactos)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _index; i++)
            {
                if (_contactos[i] == null) { continue; }

                string dato = string.Format("{0}. {1}", i + 1, contactos[i]);
                sb.AppendLine(dato);
            }

            return sb.ToString();
        }
    }
}
