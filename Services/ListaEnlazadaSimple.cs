using Listas.Models;
using System;
using System.Collections;

namespace Listas.Services
{
	public class ListaEnlazadaSimple
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

		// Método para agregar un nodo al inicio de la lista
		public string AgregarAlInicio(string valor)
		{
			Nodo nuevoNodo = new(valor);

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

		// Método para agregar un nodo al final de la lista
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

		// Método para Agregar un nodo en una posición específica
		public string AgregarNodoEnPosicion(dynamic nuevoNodo, int posicion)
		{
			if (posicion < 1)
			{
				return "La posición debe ser un número positivo mayor o igual a 1.";
			}

			Nodo? nodoActual = PrimerNodo;
			Nodo? nodoAnterior = null;
			int contador = 1; // Comenzar el contador en 1

			// Encontrar el nodo en la posición especificada
			while (nodoActual != null && contador < posicion)
			{
				nodoAnterior = nodoActual;
				nodoActual = nodoActual.Referencia;
				contador++;
			}

			// Verificar si el nodo anterior es null, lo que indica que no hay nodos en las posiciones anteriores
			if (nodoAnterior == null && contador > 1)
			{
				return $"No es posible agregar un nodo en la posición {posicion} porque no hay nodos en las posiciones anteriores.";
			}

			// Si el nodo en la posición especificada no existe, agregar el nuevo nodo al final
			if (nodoActual == null && contador < posicion)
			{
				return $"No es posible agregar un nodo en la posición {posicion} porque la lista es demasiado corta.";
			}

			//Verificar
			// Si el nodo en la posición especificada no existe, agregar el nuevo nodo al final
			if (nodoActual == null && contador == posicion)
			{
				AgregarNodoAlFinal((Nodo)nuevoNodo.Informacion);
				return $"Nodo agregado al final de la lista.";
			}

			// Si el nodo en la posición especificada existe, insertar el nuevo nodo antes de él
			if (nodoAnterior != null)
			{
				nodoAnterior.Referencia = nuevoNodo;
			}
			else
			{
				PrimerNodo = nuevoNodo;
			}

			nuevoNodo.Referencia = nodoActual;

			return $"Nodo agregado en la posición: {posicion}.";
		}

		// Metodo para agregar un nodo antes de una posicion especifica
		public string AgregarNodoAntesPosicion(Nodo nuevoNodo, int posicion)
		{
			if (posicion <= 0)
			{
				return "La posición especificada debe ser un número mayor que cero";
			}

			// Se inicializan las variables auxiliares y el índice de posición
			Nodo? nodoActual = PrimerNodo;
			Nodo? nodoAnterior = null;
			int index = 2;

			// Recorre la lista hasta encontrar la posición especificada o hasta el final de la lista
			while (nodoActual != null && index < posicion)
			{
				nodoAnterior = nodoActual;
				nodoActual = nodoActual.Referencia; // Avanza al siguiente nodo en la lista
				index++; // Incrementa el índice de posición
			}

			// Verifica si la posición especificada está fuera de rango
			if (nodoActual == null)
			{
				return "La posición especificada está fuera de rango";
			}

			// Inserta el nuevo nodo antes del nodo actual
			if (nodoAnterior != null)
			{
				nodoAnterior.Referencia = nuevoNodo;
			}
			else
			{
				PrimerNodo = nuevoNodo;
			}

			nuevoNodo.Referencia = nodoActual;

			// Retorna un mensaje indicando que se ha agregado el nodo antes de la posición especificada
			return $"Nodo agregado el nodo antes de la posición: {posicion}.";
		}

		// Método para Agregar un nodo después de una posición específica
		public string AgregarNodoDespuesPosicion(Nodo nuevoNodo, int posicion)
		{
			if (posicion <= 0)
			{
				return "La posición especificada debe ser un número positivo y mayor que cero";
			}

			// Se declaran e inicializa la variable auxiliar y el índice de posición
			Nodo? nodoActual = PrimerNodo;
			int index = 1;

			// Recorre la lista hasta encontrar la posición especificada o hasta el final de la lista
			while (nodoActual != null && index < posicion)
			{
				nodoActual = nodoActual.Referencia; // Avanza al siguiente nodo en la lista
				index++; // Incrementa el índice de posición
			}

			// Verifica si la posición especificada está fuera de rango
			if (nodoActual == null)
			{
				return "La posición especificada está fuera de rango";
			}

			// Inserta el nuevo nodo después del nodo actual
			nuevoNodo.Referencia = nodoActual.Referencia;
			nodoActual.Referencia = nuevoNodo;

			// Actualiza el último nodo si el nodo actual era el último de la lista
			if (nodoActual == UltimoNodo)
			{
				UltimoNodo = nuevoNodo;
			}

			// Retorna un mensaje indicando que se ha agregado el nodo después de la posición especificada
			return $"Nodo agregado el nodo después de la posición: {posicion}.";
		}

		// Método para Eliminar un nodo en una posición específica
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
			Nodo? nodoActual = PrimerNodo;  // Nodo actual iniciado desde el primer nodo
			Nodo? nodoAnterior = null;      // Nodo anterior inicializado como nulo, se usará para mantener la referencia al nodo anterior durante el recorrido
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

		//Metodo para buscar un nodo por su valor en una lista enlazada simple desordenada
		public Nodo? BuscarNodoPorValor(string elemento)
		{
			// Se declara e inicializa la variable auxiliar y el índice de posición
			dynamic? nodoActual = PrimerNodo;
			int index = 1;
			
			// Recorre la lista hasta encontrar el nodo con el valor especificado o hasta el final de la lista
			while (nodoActual != null)
			{
				if (nodoActual.Informacion.ToString() == elemento)
				{
					nodoActual.Posicion = index;
					return nodoActual;
				}

				nodoActual = nodoActual.Referencia;
				index++;
			}

			return null;
		}

		// Metodo para ordenar en orden alfabetico la lista
		public string OrdenarLista()
		{

			try
			{
				// Se verifica si la lista está vacía
				if (ListaVacia())
				{
					return "La lista está vacía";

				}
				// Se verifica si la lista tiene un solo nodo
				else if (PrimerNodo?.Referencia == null)
				{
					return "La lista tiene un solo nodo, no hay suficientes datos para ordenar";
				}

				// Se inicializan los nodos auxiliares
				Nodo? nodoActual = PrimerNodo;
				Nodo? nodoSiguiente = null;
				// Se inicializa una variable temporal de tipo object ya que la lista puede contener cualquier tipo de dato
				object? temp;

				// Se recorre verificando si el nodo actual es diferente de nulo, asi se cambia solo la informacion del primer nodo sin cambiar la referencia
				while (nodoActual != null)
				{
					// Se asigna el nodo siguiente del nodo actual a la variable nodoSiguiente
					nodoSiguiente = nodoActual.Referencia;

					// Se recorre verificando si el nodo siguiente es diferente de nulo, asi hasta llegar al ultimo nodo y guardar la informacion menor en el primer nodo sin cambiar su referencia 
					while (nodoSiguiente != null)
					{
						// Se compara si el valor del nodo actual es mayor al valor del nodo siguiente para intercambiarlos
						if (String.Compare(nodoActual.Informacion?.ToString(), nodoSiguiente.Informacion?.ToString()) > 0)
						{
							// Se intercambian los valores de los nodos actual y siguiente
							temp = nodoActual.Informacion;
							// Se asigna el valor del nodo siguiente al nodo actual
							nodoActual.Informacion = nodoSiguiente.Informacion;
							// Se asigna el valor del nodo actual al nodo siguiente
							nodoSiguiente.Informacion = temp;
						}

						// Se asigna el nodo siguiente al siguiente nodo para seguir recorriendo la lista
						nodoSiguiente = nodoSiguiente.Referencia;
					}

					// Se asigna al nodoActual el siguiente nodo para seguir recorriendo la lista, para pasar al siguiente nodo y asi guardar la informacion menor en el segundo nodo sin cambiar su referencia
					nodoActual = nodoActual.Referencia;
				}
			}
			catch (Exception e)
			{
				return ("Error: " + e.Message);
			}

			// Se retorna un mensaje indicando que la lista ha sido ordenada correctamente
			return "La lista ha sido ordenada correctamente";

		}

	// Metodo para recorrer la lista recursivamente
	public static void RecorrerRecursivamente(Nodo? nodo, List<Nodo> nodos)
		{
			if (nodo != null)
			{
				nodos.Add(nodo); // Agregar el nodo a la lista
				RecorrerRecursivamente(nodo.Referencia, nodos); // Llamada recursiva
			}
		}

	}
}
