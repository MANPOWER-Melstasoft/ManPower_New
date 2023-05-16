using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
	public class ApprovedTrainingRequestDocuments
	{
		[DBField("Id")]
		public int Id { get; set; }

		[DBField("Approved_Training_Request_Id")]
		public int ApprovedTrainingRequestId { get; set; }

		[DBField("Documents")]
		public string Docs { get; set; }

		[DBField("Is_Active")]
		public int IsActive { get; set; }

		public TrainingRequests trainingRequests { get; set; }

	}
}
