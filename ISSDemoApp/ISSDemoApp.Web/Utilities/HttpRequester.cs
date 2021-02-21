using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ISSDemoApp.Web.Utilities
{
	public class HttpRequester
	{
		private readonly HttpClient httpClient;

		public HttpRequester(IHttpClientFactory clientFactory)
		{
			this.httpClient = clientFactory.CreateClient();
		}

		public async Task<T> GetAsync<T>(string url)
		{
			var response = await httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				// LOGIC IF request is not correct
			}

			var responseDataString = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			var data = JsonSerializer.Deserialize<T>(responseDataString, options);

			return data;
		}
	}
}
