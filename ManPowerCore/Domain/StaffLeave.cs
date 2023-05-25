﻿using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
	[Serializable]
	public class StaffLeave
	{
		[DBField("Id")]
		public int StaffLeaveId { get; set; }

		[DBField("Day_Type_id")]
		public int DayTypeId { get; set; }

		[DBField("Leave_Type_id")]
		public int LeaveTypeId { get; set; }

		[DBField("Employee_ID")]
		public int EmployeeId { get; set; }

		[DBField("Leave_Date")]
		public DateTime LeaveDate { get; set; }

		[DBField("Created_Date")]
		public DateTime CreatedDate { get; set; }

		[DBField("Is_Half_Day")]
		public int IsHalfDay { get; set; }

		[DBField("Leave_Status_Id")]
		public int LeaveStatusId { get; set; }

		[DBField("Recommended_Date")]
		public DateTime RecomennededDate { get; set; }

		[DBField("Recommended_BY")]
		public int RecommendedBy { get; set; }

		[DBField("Approved_Date")]
		public DateTime ApprovedDate { get; set; }

		[DBField("Approved_By")]
		public int ApprovedBy { get; set; }

		[DBField("Reason_For_Leave")]
		public string ReasonForLeave { get; set; }

		[DBField("Resuming_Date")]
		public DateTime ResumingDate { get; set; }

		[DBField("No_Of_Leave")]
		public float NoOfLeaves { get; set; }

		[DBField("Leave_Document")]
		public string LeaveDocument { get; set; }

		[DBField("From_Time")]
		public DateTime FromTime { get; set; }

		[DBField("To_Time")]
		public DateTime ToTime { get; set; }

		[DBField("Reject_Reason")]
		public string RejectReason { get; set; }

		public Employee _EMployeeDetails { get; set; }
		public LeaveType leaveType { get; set; }

		public SystemUser systemUser { get; set; }

		public DepartmentUnit dsDivition { get; set; }

		public DepartmentUnit district { get; set; }

		public List<StaffLeaveDocuments> documents { get; set; }

		public SystemUser recommendUser { get; set; }

		public SystemUser approveUser { get; set; }

	}
}
