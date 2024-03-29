﻿using Listas.Models;
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

		public string EliminarAlInicio()
		{
			if(ListaVacia()) 
			{ 
				return "La lista no cuenta con elementos";
			}
			else if(PrimerNodo == UltimoNodo)
			{
				PrimerNodo = null;
				UltimoNodo= null;
			}
			else
			{
                Nodo nodoTemporal;

                nodoTemporal = PrimerNodo;
                PrimerNodo = PrimerNodo.Referencia;
                nodoTemporal = null;
            }
            return "Se ha eliminado el primer nodo de la lista con exito";
        }
	}
}
