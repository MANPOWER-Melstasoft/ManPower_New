using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EducationDetailsDAO
    {
        int SaveEducationDetails(EducationDetails educationDetails, DBConnection dbConnection);
    }

    public class EducationDetailsDAOImpl : EducationDetailsDAO
    {
        public int SaveEducationDetails(EducationDetails educationDetails, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO EDUCATION_DETAILS(EMPLOYEE_ID,EDUCATION_TYPE_ID,INSTITUTE,ATTEMPT,YEAR,INDEX_NO,SUBJECT,STREAM,GRADE,STATUS) " +

                                            "VALUES(@EmployeId,@EduTypeId,@Institute,@Attempts,@Year,@Index,@Subject,@Stream,@Grade,@Status) ";



            dbConnection.cmd.Parameters.AddWithValue("@EmployeId", educationDetails.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@EduTypeId", educationDetails.EducationTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@Institute", educationDetails.StudiedInstitute);
            dbConnection.cmd.Parameters.AddWithValue("@Index", educationDetails.ExamIndex);
            dbConnection.cmd.Parameters.AddWithValue("@Attempts", educationDetails.NoOfAttempts);
            dbConnection.cmd.Parameters.AddWithValue("@Year", educationDetails.ExamYear);
            dbConnection.cmd.Parameters.AddWithValue("@Subject", educationDetails.ExamSubject);
            dbConnection.cmd.Parameters.AddWithValue("@Stream", educationDetails.ExamStream);
            dbConnection.cmd.Parameters.AddWithValue("@Grade", educationDetails.ExamGrade);
            dbConnection.cmd.Parameters.AddWithValue("@Status", educationDetails.ExamStatus);


            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }
    }
}
