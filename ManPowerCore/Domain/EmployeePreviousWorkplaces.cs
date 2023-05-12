using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
	public class EmployeePreviousWorkplace
	{
		[DBField("Id")]
		public int Id { get; set; }

		[DBField("Transfers_Retirement_Resignation_Main_Id")]
		public int TransfersRetirementResignationMainId { get; set; }

		[DBField("Employee_Id")]
		public int EmployeeId { get; set; }

		[DBField("Previous_workplace_id")]
		public int PreviousWorkplaceId { get; set; }

		[DBField("Current_workplace_id")]
		public int CurrentWorkplaceId { get; set; }

		[DBField("Is_Active")]
		public int IsActive { get; set; }

		public Employee employee { get; set; }

		public DepartmentUnit departmentUnit { get; set; }

		public DepartmentUnit departmentUnit2 { get; set; }
	}
}
