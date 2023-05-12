using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
	public class TransfersRetirementResignationMainDocuments
	{
		[DBField("Id")]
		public int Id { get; set; }

		[DBField("Transfers_Retirement_Resignation_Main_Id")]
		public int TransfersRetirementResignationMainId { get; set; }

		[DBField("Document_Name")]
		public string DocumentName { get; set; }

		[DBField("Is_Active")]
		public int IsActive { get; set; }

		public TransfersRetirementResignationMain transfersRetirementResignationMain { get; set; }

	}
}
