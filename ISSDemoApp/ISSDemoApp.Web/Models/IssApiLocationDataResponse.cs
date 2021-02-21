using System.Text.Json.Serialization;

namespace ISSDemoApp.Web.Models
{
	public class IssApiLocationDataResponse
	{
		public long Timestamp { get; set; }
		public string Message { get; set; }
		[JsonPropertyName("iss_position")]
		public IssPositionData IssPosition { get; set; }
	}
}
