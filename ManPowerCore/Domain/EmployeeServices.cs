using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class EmployeeServices
    {
        [DBField("ID")]
        public int EmployeeServicesId { get; set; }

        [DBField("SERVICE_TYPE_ID")]
        public int ServicesTypeId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int EmpId { get; set; }

        [DBField("APPOINTMENT_DATE")]
        public DateTime AppointmentDate { get; set; }

        [DBField("DATE_ASSUMED_DUTY")]
        public string DateAssumedDuty { get; set; }

        [DBField("METHOD_OF_RECRUITMENT")]
        public string MethodOfRecruitment { get; set; }

        [DBField("MEDIUM_OF_RECRUITMENT")]
        public string MediumOfRecruitment { get; set; }

        [DBField("CONFIRMED")]
        public int ServiceConfirmed { get; set; }

        [DBField("Confirmed_Date")]
        public DateTime ServiceConfirmedDate { get; set; }

        [DBField("GRADE")]
        public string empGrade { get; set; }

        [DBField("EB_Completed_Date_Grade_1")]
        public DateTime EBCompletedDateGrade1 { get; set; }

        [DBField("EB_Completed_Date_Grade_2")]
        public DateTime EBCompletedDateGrade2 { get; set; }

        [DBField("EB_Completed_Date_Grade_3")]
        public DateTime EBCompletedDateGrade3 { get; set; }

    }
}
