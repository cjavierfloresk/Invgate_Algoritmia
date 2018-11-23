using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Enums;

namespace Tamagochi.Interfaces
{
    public interface ITamagochi
    {
		/// <summary>
		/// Debe temerle?
		/// </summary>
		/// <returns></returns>
		bool Temer(Especie e);
		/// <summary>
		/// Devuelve el string correspondiente al ruido a realizar
		/// </summary>
		/// <returns></returns>
		string HacerRuido();
		/// <summary>
		/// Se mueve la cantidad de pasos hacia la direccion establecida
		/// </summary>
		/// <param name="pasos"></param>
		/// <param name="direccion"></param>
		/// <returns></returns>
		bool Moverse(int pasos, DireccionEnum direccion);
		/// <summary>
		/// Despierta si esta dormido
		/// </summary>
		/// <returns></returns>
		bool Despertar();
		/// <summary>
		/// Duerme si esta despierto
		/// </summary>
		/// <returns></returns>
		bool Dormir();
    }
}
