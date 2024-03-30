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
    }
}


