using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
	public class TipoRuido
	{
		[Key]
		public Guid Id { get; set; } 
		[Required]
		public string Tipo { get; set; }
		[Required]
		public string Ruido { get; set; }
		[Required]
		public double CantDecibeles;
	}
}
