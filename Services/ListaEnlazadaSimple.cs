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
