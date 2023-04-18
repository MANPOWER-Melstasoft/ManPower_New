using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EmployeeServicesDAO
    {
        int SaveEmployeeServices(EmployeeServices empServices, DBConnection dbConnection);

        EmployeeServices GetEmployeeServicesByEmpId(int empId, DBConnection dbConnection);
    }

    public class EmployeeServicesDAOImpl : EmployeeServicesDAO
    {
        public EmployeeServices GetEmployeeServicesByEmpId(int empId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_SERVICES WHERE Employee_ID = " + empId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<EmployeeServices>(dbConnection.dr);
        }

        public int SaveEmployeeServices(EmployeeServices empServices, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO EMPLOYEE_SERVICES(SERVICE_TYPE_ID,EMPLOYEE_ID,APPOINTMENT_DATE,DATE_ASSUMED_DUTY, " +
                "CONFIRMED, Confirmed_Date, EB_Completed_Date_Grade_3, EB_Completed_Date_Grade_2, EB_Completed_Date_Grade_1)" +
                "VALUES(@ServicesTypeId,@EId,@AppointmentDate,@DateAssumedDuty,@ServiceConfirmed,@ServiceConfirmedDate," +
                "@EBCompletedDateGrade1,@EBCompletedDateGrade2,@EBCompletedDateGrade3)";



            dbConnection.cmd.Parameters.AddWithValue("@ServicesTypeId", empServices.ServicesTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@EId", empServices.EmpId);
            dbConnection.cmd.Parameters.AddWithValue("@AppointmentDate", empServices.AppointmentDate);
            dbConnection.cmd.Parameters.AddWithValue("@DateAssumedDuty", empServices.DateAssumedDuty);
            //dbConnection.cmd.Parameters.AddWithValue("@MethodOfRecruitment", empServices.MethodOfRecruitment);
            //dbConnection.cmd.Parameters.AddWithValue("@MediumOfRecruitment", empServices.MediumOfRecruitment);
            dbConnection.cmd.Parameters.AddWithValue("@ServiceConfirmed", empServices.ServiceConfirmed);

            if (empServices.ServiceConfirmedDate.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@ServiceConfirmedDate", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@ServiceConfirmedDate", empServices.ServiceConfirmedDate);
            }

            if (empServices.EBCompletedDateGrade1.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@EBCompletedDateGrade1", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@EBCompletedDateGrade1", empServices.EBCompletedDateGrade1);
            }

            if (empServices.EBCompletedDateGrade2.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@EBCompletedDateGrade2", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@EBCompletedDateGrade2", empServices.EBCompletedDateGrade2);
            }

            if (empServices.EBCompletedDateGrade3.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@EBCompletedDateGrade3", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@EBCompletedDateGrade3", empServices.EBCompletedDateGrade3);
            }



            //dbConnection.cmd.Parameters.AddWithValue("@empGrade", empServices.empGrade);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }
    }

}
