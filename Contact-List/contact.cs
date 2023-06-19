using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ProyectoAgenda
{
    class Contacto : IComparable<Contacto>
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Contacto() 
        { 
        }   

        public Contacto(string nombre, string email, string telefono)
        {
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
        }

        //Override
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Contacto c = obj as Contacto;
            if (c == null)
            {
                return false;
            }

            return string.Equals(Nombre, c.Nombre) && string.Equals(Telefono, c.Telefono);

        }

        //Devuelve un nº asociado a este obj que va a servir para la comparación con Equals()
        //Usamos las mismas dependencias que tenemos en Equals()
        public override int GetHashCode() 
        {
            unchecked
            {
                int hashNombre = (Nombre != null ? Nombre.GetHashCode() : 0);
                int hashTelefono = (Telefono != null ? Telefono.GetHashCode() : 0); 
                return (hashNombre * 397) ^ (hashTelefono);
            }
        }

        public override string ToString()
        {
            return string.Format("Nombre: {0}\nTeléfono: {1}\nEmail: {2}\n", Nombre, Telefono, Email);
        }

        //implementación vacía creada por la interfaz
        public int CompareTo(Contacto other)
        {
            return Nombre.CompareTo(other.Nombre);
        }
    }
}

