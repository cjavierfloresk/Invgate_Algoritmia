using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Implementacion.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _4.Implementacion.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		const string apiUserID = "apiuser";
		const string apiUserPwd = "75NwxqPmAAEnebWS6PxJ94MH";

		// GET api/values
		[HttpGet]
		[Route("ByHelpDesk")]
		public async Task<ActionResult<IEnumerable<Incident>>> GetTicketsByHElpDesk(int helpdesk_id, string text_to_search, int detailed)
		{
			HttpClient cons = new HttpClient();
			cons.BaseAddress = new Uri("http://cloud.invgate.net/api/v1/");
			cons.DefaultRequestHeaders.Accept.Clear();
			cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			var byteArray = new UTF8Encoding().GetBytes(String.Format("{0}:{1}", apiUserID, apiUserPwd));
			cons.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			var ret = await cons.GetAsync(String.Format("incidents.by.helpdesk?helpdesk_id={0}", helpdesk_id));

			return JsonConvert.DeserializeObject<List<Incident>>(ret.Content.ToString());
		}
	}
}
