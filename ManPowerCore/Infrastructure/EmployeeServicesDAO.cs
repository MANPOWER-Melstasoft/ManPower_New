using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EmployeeServicesDAO
    {
        int SaveEmployeeServices(EmployeeServices empServices, DBConnection dbConnection);
    }

    public class EmployeeServicesDAOImpl : EmployeeServicesDAO
    {
        public int SaveEmployeeServices(EmployeeServices empServices, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO EMPLOYEE_SERVICES(SERVICE_TYPE_ID,EMPLOYEE_ID,APPOINTMENT_DATE,DATE_ASSUMED_DUTY, " +
                "METHOD_OF_RECRUITMENT,MEDIUM_OF_RECRUITMENT,CONFIRMED,GRADE)" +
                "VALUES(@ServicesTypeId,@EId,@AppointmentDate,@DateAssumedDuty,@MethodOfRecruitment,@MediumOfRecruitment,@ServiceConfirmed, @empGrade)";



            dbConnection.cmd.Parameters.AddWithValue("@ServicesTypeId", empServices.ServicesTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@EId", empServices.EmpId);
            dbConnection.cmd.Parameters.AddWithValue("@AppointmentDate", empServices.AppointmentDate);
            dbConnection.cmd.Parameters.AddWithValue("@DateAssumedDuty", empServices.DateAssumedDuty);
            dbConnection.cmd.Parameters.AddWithValue("@MethodOfRecruitment", empServices.MethodOfRecruitment);
            dbConnection.cmd.Parameters.AddWithValue("@MediumOfRecruitment", empServices.MediumOfRecruitment);
            dbConnection.cmd.Parameters.AddWithValue("@ServiceConfirmed", empServices.ServiceConfirmed);
            dbConnection.cmd.Parameters.AddWithValue("@empGrade", empServices.empGrade);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }
    }

}
