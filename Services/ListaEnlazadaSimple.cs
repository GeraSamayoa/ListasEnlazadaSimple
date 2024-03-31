using Listas.Models;
using System;
using System.Collections;

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

        public IEnumerator GetEnumerator()
        {
            Nodo? nodoAuxiliar = PrimerNodo;

            while (nodoAuxiliar != null)
            {
                yield return nodoAuxiliar;
                nodoAuxiliar = nodoAuxiliar.Referencia;
            }
        }

        public string EliminarNodoAntesDe(int posicion)
        {
            if (ListaVacia() || posicion <= 1 || posicion > ContarNodos() + 1)
            {
                return "Operación no válida. La lista está vacía o la posición especificada es inválida.";
            }

            if (posicion == 2)
            {
                PrimerNodo = PrimerNodo?.Referencia;
                if (PrimerNodo == null) UltimoNodo = null; // Si la lista quedó vacía
                ActualizarPosiciones();
                return "El nodo antes de la posición especificada ha sido eliminado.";
            }

            Nodo? nodoActual = PrimerNodo;
            int contador = 1;

            while (nodoActual != null && contador < posicion - 1)
            {
                nodoActual = nodoActual.Referencia;
                contador++;
            }

            if (nodoActual == null || nodoActual.Referencia == null)
            {
                return "Posición especificada no válida.";
            }

            nodoActual.Referencia = nodoActual.Referencia.Referencia;
            if (nodoActual.Referencia == null) UltimoNodo = nodoActual;

            ActualizarPosiciones();

            return "El nodo antes de la posición especificada ha sido eliminado.";
        }

        public int ContarNodos()
        {
            int contador = 0;
            Nodo? nodoActual = PrimerNodo;
            while (nodoActual != null)
            {
                contador++;
                nodoActual = nodoActual.Referencia;
            }
            return contador;
        }

        private void ActualizarPosiciones()
        {
            Nodo? nodoActual = PrimerNodo;
            int contador = 1;
            while (nodoActual != null)
            {
                nodoActual.Posicion = contador;
                nodoActual = nodoActual.Referencia;
                contador++;
            }
        }
        public void EliminarNodoInicio()
        {
            if (ListaVacia())
            {
                // La lista está vacía, no se puede eliminar ningún nodo
                return;
            }

            if (PrimerNodo == UltimoNodo)
            {
                // Solo hay un nodo en la lista, por lo que se elimina PrimerNodo y UltimoNodo
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                // Hay más de un nodo en la lista, por lo que se elimina el PrimerNodo
                PrimerNodo = PrimerNodo.Referencia;
            }
        }

    }
}



