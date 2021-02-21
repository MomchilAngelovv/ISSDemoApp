using ISSDemoApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using ISSDemoApp.Web.Utilities;

namespace ISSDemoApp.Web.Controllers
{
	public class IssController : Controller
	{
		private readonly HttpRequester httpRequester;

		public IssController(HttpRequester httpRequester)
		{
			this.httpRequester = httpRequester;
		}

		public async Task<IActionResult> Location()
		{
			var issLocationData = await this.httpRequester.GetAsync<IssApiLocationDataResponse>("http://api.open-notify.org/iss-now.json");

			var viewModel = new IssLocationViewModel
			{
				Latitude = issLocationData.IssPosition.Latitude,
				Longitude = issLocationData.IssPosition.Longitude
			};

			return this.View(viewModel);
		}
	}
}
