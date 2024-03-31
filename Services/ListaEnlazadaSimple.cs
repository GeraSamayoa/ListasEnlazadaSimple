using Listas.Models;
using System;
using System.Collections;

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

		public string EliminarDespuesDe(int posicion)
		{
			if (ListaVacia())
			{
				// La lista está vacía o la posición es inválida.
				return "la lista esta vacia";
			}

			if (posicion <= 0)
			{
				// La lista está vacía o la posición es inválida.
				return "la Pocision es invalida, ingrese un numero mayor del 0";
			}
			// Se inicia en la cabeza y se recorre la lista hasta la posición especificada.
			Nodo? nodoActual = PrimerNodo;
			for (int i = 1; i < posicion && nodoActual != null; i++)
			{
				// Avanza hasta el nodo en la posición especificada.
				nodoActual = nodoActual.Referencia;
			}
            if (nodoActual?.Referencia == null || nodoActual == null)
            {
				return "Posicion fuera de rango";
            }

            // Si hay un nodo después del actual, se elimina cambiando la referencia Siguiente.
            if (nodoActual?.Referencia != null)
			{
				// El nodo a eliminar es el siguiente del nodo actual.
				nodoActual.Referencia = nodoActual.Referencia.Referencia;
			}

			return "!Nodo eliminado Exitosamente";
		}
	}
}
