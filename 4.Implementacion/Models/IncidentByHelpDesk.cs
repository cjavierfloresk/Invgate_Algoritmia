using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementacion.Models
{
	public class IncidentByHelpDesk
	{
		public string Status { get; set; }
		public string Info { get; set; }
		public IEnumerable<int> RequestedIds { get; set; }
	}
}
