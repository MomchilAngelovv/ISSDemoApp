using ISSDemoApp.Web.Data;
using ISSDemoApp.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSDemoApp.Web.Services
{
	public class PositionSnapshotsService
	{
		private readonly ApplicationDbContext db;

		public PositionSnapshotsService(ApplicationDbContext db)
		{
			this.db = db;
		}

		public async Task<string> CreatePositionSnapshot(string messsage, long timeStamp, string latitude, string longitute)
		{
			if (!messsage.StartsWith("M"))
			{
				// throw error...
			}

			var positionSnapshot = new PositionSnapshot
			{
				Message = messsage,
				Timestamp = timeStamp,
				Latitude = latitude,
				Longitude = longitute
			};

			await this.db.PositionSnapshots.AddAsync(positionSnapshot);
			await this.db.SaveChangesAsync();

			return positionSnapshot.Id;
		}
	}
}
