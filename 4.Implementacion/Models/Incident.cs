using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementacion.Models
{
	public class Incident
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public int Priority { get; set; }
		public int User_Id { get; set; }
		public int Creator_Id { get; set; }
		public int? Assigned_Id { get; set; }
		public int? Assigned_Group_Id { get; set; }
		public DateTime Date_Ocurred { get; set; }
		public int Source_Id { get; set; }
		public int Status_Id { get; set; }
		public int Type_Id { get; set; }
		public DateTime Created_At { get; set; }
		public DateTime Last_Updated { get; set; }
		public int? Process_Id { get; set; }
		public DateTime? Solved_At { get; set; }
		public DateTime? Closed_At { get; set; }
		public string Closed_Reason { get; set; }
		public string Data_Cleaned { get; set; }
		public IEnumerable<String> Attachments { get; set; }
	}
}
