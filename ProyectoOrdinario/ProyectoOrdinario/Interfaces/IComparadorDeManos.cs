using System;
namespace ProyectoOrdinario.Interfaces
{
	public interface IComparadorDeManos
	{
		List<ICarta> ObtenerManoGanadora(List<List<ICarta>> manosDeCartas);
	}
}

