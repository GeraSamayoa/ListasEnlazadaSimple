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

        /// <summary>
        /// Elimina un elemento al final de la lista enlazada simple.
        /// </summary>
        /// <returns>
        /// "Nodo eliminado exitosamente" si se eliminó un nodo.
        /// "La lista está vacía" si la lista está vacía.
        /// "No hay nodos para eliminar" si solo hay un nodo en la lista.
        /// </returns>
        public string EliminarNodoAlFinal()
        {
            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
                return "No hay nodos para eliminar";
            }

            Nodo? nodoAuxiliar = PrimerNodo;
            while (nodoAuxiliar.Referencia != UltimoNodo)
            {
                nodoAuxiliar = nodoAuxiliar.Referencia;
            }

            UltimoNodo = nodoAuxiliar;
            UltimoNodo.Referencia = null;

            return "Nodo eliminado exitosamente";
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
