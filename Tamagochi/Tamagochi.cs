using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Enums;
using Tamagochi.Interfaces;

namespace Tamagochi
{
	public class Tamagochi : ITamagochi
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public Guid IdEspecie { get; set; }

		[Required]
		public Guid IdTipoRuido { get; set; }

		[Required]
		public string Nombre { get; set; }

		[Required]
		public int CantSegundosRuido { get; set; }

		public int PosicionEjeX { get; set; }
		
		public int PosicionEjeY { get; set; }

		public SentimientoEnum SentimientoActual { get; set; }

		public EstadoEnum EstadoActual { get; set; }

		[ForeignKey("IdEspecie")]
		public Especie Especie { get; set; }

		[ForeignKey("IdTipoRuido")]
		public TipoRuido TipoRuido { get; set; }

		public bool Temer(Especie e)
		{
			return Especie.Id != e.Id;
		}

		public bool Dormir()
		{
			if (EstadoActual == EstadoEnum.Durmiendo) return false;

			EstadoActual = EstadoEnum.Durmiendo;
			return true;
		}

		public bool Despertar()
		{
			if (EstadoActual == EstadoEnum.Despierto) return false;

			EstadoActual = EstadoEnum.Despierto;
			return true;
		}

		public bool Moverse(int pasos, DireccionEnum direccion)
		{
			if (EstadoActual == EstadoEnum.Durmiendo) return false;

			switch (direccion)
			{
				case DireccionEnum.Adelante:
					PosicionEjeY += pasos;
					break;
				case DireccionEnum.Atras:
					PosicionEjeY -= pasos;
					break;
				case DireccionEnum.Derecha:
					PosicionEjeX += pasos;
					break;
				case DireccionEnum.Izquierda:
					PosicionEjeX -= pasos;
					break;
			}

			return true;

		}

		public string HacerRuido()
		{
			if (EstadoActual == EstadoEnum.Durmiendo) return "Ronquido";

			switch (SentimientoActual)
			{
				case SentimientoEnum.Feliz:
					return "Risas";
				case SentimientoEnum.Triste:
					return "Llanto";
				case SentimientoEnum.Hambriento:
					return "Ruido Estomago";
				case SentimientoEnum.Cansado:
					return "Bostezo";
				case SentimientoEnum.Enamorado:
					return "Besos";
			}

			return TipoRuido.Ruido;
		}

	}
}
