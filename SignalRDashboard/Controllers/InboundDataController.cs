using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace SignalRDashboard.Controllers
{
	[RoutePrefix("api/data")]
    public class InboundDataController : ApiController
    {
		[HttpPost]
		[Route("")]
		public IHttpActionResult PostData([FromBody] double[] data)
		{
			// Check the data
			if(data == null || data.Length == 0)
			{
				return BadRequest();
			}

			// Get the context to talk to our clients
			IHubContext dataHubContext = GlobalHost.ConnectionManager.GetHubContext<DataHub>();

			// Send out data via 'SendData'
			dataHubContext.Clients.All.SendData(data);

			return Ok();
		}
    }
}
