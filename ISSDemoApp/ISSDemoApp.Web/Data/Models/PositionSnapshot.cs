using System;

namespace ISSDemoApp.Web.Data.Models
{
	public class PositionSnapshot : IEntityMetaData
	{
		public PositionSnapshot()
		{
			this.Id = Guid.NewGuid().ToString("N");
			this.CreatedOn = DateTime.UtcNow;
		}

		public string Id { get; set; }
		public long Timestamp { get; set; }
		public string Longitude { get; set; }
		public string Latitude { get; set; }
		public string Message { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
		public string MetaData { get; set; }
	}
}
