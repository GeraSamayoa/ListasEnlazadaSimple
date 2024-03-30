namespace Listas.Services
{
	public class MensajeValidator
	{
		

		public (string? mensajeError,string valor, int? posicion) MensajeInsertar(string mensaje, string? mensajeError, int? posicion, string valor)
		{
			
			if (mensaje.StartsWith("Nodo agregado"))
			{
				return (null, string.Empty, null);
			}
			else
			{
				return (mensaje, valor, posicion);
			}
        }

		public (string? mensajeError, int? posicion) MensajeEliminar(string Mensaje, string? mensajeError, int? posicion)
		{
			if (Mensaje.StartsWith("¡Nodo eliminado"))
			{
				return (null, null);
			}
			else
			{
				return (Mensaje, posicion);
			}
		}
	}
}
