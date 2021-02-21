using ISSDemoApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using ISSDemoApp.Web.Utilities;
using ISSDemoApp.Web.Services;

namespace ISSDemoApp.Web.Controllers
{
	public class IssController : Controller
	{
		private readonly HttpRequester httpRequester;

		public IssController(HttpRequester httpRequester, PositionSnapshotsService positionSnapshotsService)
		{
			this.httpRequester = httpRequester;
			PositionSnapshotsService = positionSnapshotsService;
		}

		public PositionSnapshotsService PositionSnapshotsService { get; }

		public async Task<IActionResult> Location()
		{
			var issLocationData = await this.httpRequester.GetAsync<IssApiLocationDataResponse>("http://api.open-notify.org/iss-now.json");

			var creadedPositionSnapshot = await this.PositionSnapshotsService.CreatePositionSnapshot(issLocationData.Message, issLocationData.Timestamp, issLocationData.IssPosition.Latitude, issLocationData.IssPosition.Longitude);

			var viewModel = new IssLocationViewModel
			{
				Latitude = issLocationData.IssPosition.Latitude,
				Longitude = issLocationData.IssPosition.Longitude,
				LastCreatedSnapshotId = creadedPositionSnapshot
			};

			return this.View(viewModel);
		}
	}
}
