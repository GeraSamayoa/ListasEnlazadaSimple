using Listas.Models;
using System;
using System.Collections;

namespace Listas.Services
{
    public class ListaEnlazadaSimple : IEnumerable
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public ListaEnlazadaSimple()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

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

        // Método para eliminar el último nodo de la lista
        public string EliminarNodoFinal()
        {
            // Verificar si la lista está vacía
            if (ListaVacia())
            {
                return "La lista está vacía, no hay nodos para eliminar.";
            }

            // Si la lista solo tiene un nodo, se elimina y se actualizan los punteros
            if (PrimerNodo.Referencia == null)
            {
                PrimerNodo = null;
                UltimoNodo = null;
                return "El único nodo de la lista ha sido eliminado.";
            }

            // Si la lista tiene más de un nodo, se itera para encontrar el penúltimo nodo
            Nodo? nodoActual = PrimerNodo;
            while (nodoActual.Referencia != UltimoNodo)
            {
                nodoActual = nodoActual.Referencia;
            }

            // Se elimina la referencia al último nodo y se actualiza el puntero del último nodo
            nodoActual.Referencia = null;
            UltimoNodo = nodoActual;

            return "El último nodo ha sido eliminado.";
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
    }
}
