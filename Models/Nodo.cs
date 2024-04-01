namespace Listas.Models
{
    // Clase que representa un nodo en una lista enlazada
    public class Nodo
    {
        // Se definen las propiedades de la clase Nodo
        public object? Informacion { get; set; }
        public Nodo? Referencia { get; set; }
        public int Posicion { get; set; }

        // Constructor por defecto de la clase Nodo
        public Nodo()
        {
            Informacion = null;
            Referencia = null;
            Posicion = -1;
        }

        // Constructor de la clase Nodo que recibe la información del nodo
        public Nodo(object? informacion)
        {
            // Asignar la información recibida y la referencia como nulas
            Informacion = informacion;
            Referencia = null;
            // Por defecto, la posición se inicializa como 0
            Posicion = 0;
        }

        // Constructor de la clase Nodo que recibe la información y la referencia del nodo
        public Nodo(object? informacion, Nodo referencia)
        {
            // Asignar la información y la referencia recibidas
            Informacion = informacion;
            Referencia = referencia;
            // Por defecto, la posición se inicializa como 0
            Posicion = 0;
        }

        // Método para obtener la representación en cadena del nodo
        public override string ToString()
        {
            return $"{Informacion}";
        }
    }
}
