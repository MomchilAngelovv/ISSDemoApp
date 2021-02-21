using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSDemoApp.Web.Data.Models
{
	public interface IEntityMetaData
	{
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
		public string MetaData { get; set; }
	}
}
