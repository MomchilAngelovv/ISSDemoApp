using ISSDemoApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ISSDemoApp.Web.Controllers
{
	public class IssController : Controller
	{
		private readonly IHttpClientFactory clientFactory;

		public IssController(IHttpClientFactory clientFactory)
		{
			this.clientFactory = clientFactory;
		}

		public async Task<IActionResult> Location()
		{
			var httpClient = this.clientFactory.CreateClient();

			var response = await httpClient.GetAsync("http://api.open-notify.org/iss-now.json");
			var responseDataString = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			var issLocationData = JsonSerializer.Deserialize<IssApiLocationDataResponse>(responseDataString, options);

			var viewModel = new IssLocationViewModel
			{
				Latitude = issLocationData.IssPosition.Latitude,
				Longitude = issLocationData.IssPosition.Longitude
			};

			return this.View(viewModel);
		}
	}
}
