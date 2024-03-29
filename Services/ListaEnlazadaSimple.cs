using Listas.Models;
using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Listas.Services
{
	public class ListaEnlazadaSimple : IEnumerable
	{

		public Nodo? PrimerNodo { get; set; }
		public Nodo? UltimoNodo { get; set; }



        // Constructor de la clase ListaEnlazadaSimple inicializa los nodos en null porque la lista está vacía
        public ListaEnlazadaSimple()
		{
			PrimerNodo = null;
			UltimoNodo = null;
		}

		// Método para verificar si la lista está vacía
		public bool ListaVacia()
		{
			return PrimerNodo == null;
		}

		public string AgregarNodoAlFinal(Nodo nuevoNodo)
		{
			if (ListaVacia())
			{
				PrimerNodo = nuevoNodo;
				UltimoNodo = nuevoNodo;
			}
			else
			{
				UltimoNodo.Referencia = nuevoNodo;
				UltimoNodo = nuevoNodo;
			}

			return "Se ha agregado el nodo al final";
		}

		public string AgregarNodoAlInicio(Nodo nuevoNodo)
		{
			if (ListaVacia())
			{
				PrimerNodo = nuevoNodo;
				UltimoNodo = nuevoNodo;
			}
			else
			{
				nuevoNodo.Referencia = PrimerNodo;
				PrimerNodo = nuevoNodo;

			}

			return "Se ha agregado el nodo al inicio";
		}

		public IEnumerator GetEnumerator()
		{
			Nodo? nodoAuxiliar = PrimerNodo;

			while (nodoAuxiliar != null)
			{
				yield return nodoAuxiliar;
				nodoAuxiliar = nodoAuxiliar.Referencia;
			}

		}

        public string EliminarNodoEnPosicion(int posicion)
        {
            // Verificar si la lista está vacía
            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            // Verificar si la posición es inválida (menor o igual a cero)
            if (posicion <= 0)
            {
                return "La posición especificada debe ser un número positivo y mayor que cero";
            }

            // Inicializar variables para recorrer la lista
            Nodo nodoActual = PrimerNodo;  // Nodo actual iniciado desde el primer nodo
            Nodo nodoAnterior = null;      // Nodo anterior inicializado como nulo, se usará para mantener la referencia al nodo anterior durante el recorrido
            int index = 1;                 // Índice para mantener el seguimiento de la posición actual en la lista

            // Recorrer la lista hasta encontrar la posición deseada o hasta el final de la lista.
            while (nodoActual != null && index < posicion)
            {
                nodoAnterior = nodoActual;        // Mantener la referencia al nodo anterior
                nodoActual = nodoActual.Referencia;  // Avanzar al siguiente nodo
                index++;                          // Incrementar el índice
            }

            // Si  nodoActual == nulo , significa que la posición especificada está fuera de rango
            if (nodoActual == null)
            {
                return "La posición especificada está fuera de rango";
            }

            // Si  nodoAnterior !=  nulo, significa que no estamos eliminando el primer nodo
            if (nodoAnterior != null)
            {
                nodoAnterior.Referencia = nodoActual.Referencia;  // Eliminar el nodo actual actualizando las referencias del nodo anterior
            }
            else
            {
                // Si  nodoAnterior == nulo, significa que estamos eliminando el primer nodo de la lista
                PrimerNodo = nodoActual.Referencia;  // Actualizar el primer nodo para que apunte al siguiente nodo
            }

            // Si  nodoActual es el último nodo de la lista, actualizar el último nodo
            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nodoAnterior;  // El nodo anterior se convierte en el último nodo
            }

            return "¡Nodo eliminado correctamente!";  
        }


    }
}
	

