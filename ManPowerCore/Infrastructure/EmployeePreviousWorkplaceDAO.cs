using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
	public interface EmployeePreviousWorkplaceDAO
	{
		int save(EmployeePreviousWorkplace obj, DBConnection dbConnection);

		List<EmployeePreviousWorkplace> GetAllEmployeePreviousWorkplaces(bool with0, DBConnection dbConnection);
	}

	public class EmployeePreviousWorkplaceDAOSqlImpl : EmployeePreviousWorkplaceDAO
	{
		public int save(EmployeePreviousWorkplace obj, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "INSERT INTO Employee_Previous_Workplaces(Transfers_Retirement_Resignation_Main_Id,Employee_Id,Previous_workplace_id,Current_workplace_id) " +
											"Values(@Transfers_Retirement_Resignation_Main_Id, @Employee_Id, @Previous_workplace_id, @Current_workplace_id)";


			dbConnection.cmd.Parameters.AddWithValue("@Transfers_Retirement_Resignation_Main_Id", obj.TransfersRetirementResignationMainId);
			dbConnection.cmd.Parameters.AddWithValue("@Employee_Id", obj.EmployeeId);
			dbConnection.cmd.Parameters.AddWithValue("@Previous_workplace_id", obj.PreviousWorkplaceId);
			dbConnection.cmd.Parameters.AddWithValue("@Current_workplace_id", obj.CurrentWorkplaceId);


			dbConnection.cmd.ExecuteNonQuery();

			return 1;
		}

		public List<EmployeePreviousWorkplace> GetAllEmployeePreviousWorkplaces(bool with0, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			if (with0)
				dbConnection.cmd.CommandText = "SELECT * FROM Employee_Previous_Workplaces";
			else
				dbConnection.cmd.CommandText = "SELECT * FROM Employee_Previous_Workplaces WHERE Is_Active = 1";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.ReadCollection<EmployeePreviousWorkplace>(dbConnection.dr);
		}
	}
}
