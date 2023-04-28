using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManPowerCore.Infrastructure
{
	public interface EducationDetailsDAO
	{
		int SaveEducationDetails(EducationDetails educationDetails, DBConnection dbConnection);

		List<EducationDetails> GetAllEducationDetails(DBConnection dbConnection);

		EducationDetails GetEducationDetailsById(int id, DBConnection dbConnection);

		int UpdateEducationDetails(EducationDetails educationDetails, DBConnection dbConnection);

		List<EducationDetails> GetEducationDetailsByEmpId(int empId, DBConnection dbConnection);
	}

	public class EducationDetailsDAOImpl : EducationDetailsDAO
	{
		public int SaveEducationDetails(EducationDetails educationDetails, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "INSERT INTO EDUCATION_DETAILS(EMPLOYEE_ID,EDUCATION_TYPE_ID,INSTITUTE,ATTEMPT,YEAR,INDEX_NO,SUBJECT,STREAM,GRADE,STATUS,ATTACHMENT) " +

											"VALUES(@EmployeId,@EduTypeId,@Institute,@Attempts,@Year,@Index,@Subject,@Stream,@Grade,@Status,@Attachment) ";



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
			dbConnection.cmd.Parameters.AddWithValue("@Attachment", educationDetails.Attachment);


			/*dbConnection.cmd.ExecuteNonQuery();
			dbConnection.cmd.Parameters.Clear();
			return 1;*/
			int result = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
			return result;
		}

		public int UpdateEducationDetails(EducationDetails educationDetails, DBConnection dbConnection)
		{
			int output = 0;
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "UPDATE EDUCATION_DETAILS SET EDUCATION_TYPE_ID = @EduTypeId,INSTITUTE = @Institute" +
										   ",ATTEMPT = @Attempts,YEAR = @Year ,INDEX_NO = @Index ,SUBJECT = @Subject" +
										   ",STREAM = @Stream ,GRADE = @Grade ,STATUS = @Status ,ATTACHMENT = @Attachment WHERE ID = @EducationDetailsId";

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
			dbConnection.cmd.Parameters.AddWithValue("@Attachment", educationDetails.Attachment);
			dbConnection.cmd.Parameters.AddWithValue("@EducationDetailsId", educationDetails.EducationDetailsId);

			/*dbConnection.cmd.ExecuteNonQuery();
			dbConnection.cmd.Parameters.Clear();
			return 1;*/
			output = dbConnection.cmd.ExecuteNonQuery();
			return output;
		}

		public List<EducationDetails> GetAllEducationDetails(DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandText = "SELECT * FROM EDUCATION_DETAILS ";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.ReadCollection<EducationDetails>(dbConnection.dr);

		}

		public EducationDetails GetEducationDetailsById(int id, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandText = "SELECT * FROM EDUCATION_DETAILS WHERE ID=" + id + " ";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.GetSingleOject<EducationDetails>(dbConnection.dr);
		}

		public List<EducationDetails> GetEducationDetailsByEmpId(int empId, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandText = /*"SELECT * FROM EDUCATION_DETAILS WHERE EMPLOYEE_ID=" + empId + " ";*/
											" SELECT ED.*,ET.Name AS Education_Type FROM EDUCATION_DETAILS ED " +
											" INNER JOIN(select ID, Name from Education_Type) ET ON ED.Education_Type_Id = ET.ID " +
											" WHERE EMPLOYEE_ID = " + empId + " ";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.ReadCollection<EducationDetails>(dbConnection.dr);
		}
	}
}
