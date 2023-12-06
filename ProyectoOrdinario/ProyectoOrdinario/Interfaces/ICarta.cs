using System;
using ProyectoOrdinario.Enumeradores;

namespace ProyectoOrdinario.Interfaces
{
	public interface ICarta
	{
		FigurasCartasEnum Figura { get; }
		ValoresCartasEnum Valor { get; }
	}
}

