using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class TaskAllocation
    {

        [DBField("ID")]
        public int TaskAllocationId { get; set; }

        [DBField("DEPARTMENT_UNIT_POSSITIONS_ID")]
        public int DepartmetUnitPossitionsId { get; set; }

        [DBField("TASK_YEAR_MONTH")]
        public DateTime TaskYearMonth { get; set; }

        [DBField("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [DBField("CREATED_USER")]
        public string CreatedUser { get; set; }

        [DBField("STATUS_ID")]
        public int StatusId { get; set; }

        [DBField("DME21_Recommended_by1")]
        public int DME21RecommendedBy1 { get; set; }

        [DBField("RECOMMENDED_DATE")]
        public DateTime RecommendedDate { get; set; }

        [DBField("DME22_Approved_by")]
        public int DME22_ApprovedBy { get; set; }

        [DBField("APPROVED_DATE")]
        public DateTime ApprovedDate { get; set; }

        [DBField("COMMENTS")]
        public string ApprovalComments { get; set; }

        [DBField("DME21_Recommended_by2")]
        public int DME21RecommendedBy2 { get; set; }

        [DBField("DME21_Approved_by")]
        public int DME21ApprovedBy { get; set; }

        [DBField("DME22_Rec1_By")]
        public int DME22Rec1By { get; set; }

        [DBField("DME22_Rec2_By")]
        public int DME22Rec2By { get; set; }

        public List<TaskAllocationDetail> _TaskAllocationDetail { get; set; } = new List<TaskAllocationDetail>();
        public DepartmentUnitPositions _DepartmentUnitPositions { get; set; } = new DepartmentUnitPositions();
        public ProjectStatus _ProjectStatus { get; set; } = new ProjectStatus();
        public TaskType _TaskType { get; set; } = new TaskType();
        public SystemUser _SystemUser { get; set; } = new SystemUser();

    }
}
