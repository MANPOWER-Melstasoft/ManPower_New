using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
	public interface TransfersRetirementResignationMainDocumentDAO
	{
		int saveAll(int TransfersRetirementResignationMainId, string DocName, DBConnection dbConnection);
	}

	public class TransfersRetirementResignationMainDocumentDAOSqlImpl : TransfersRetirementResignationMainDocumentDAO
	{
		public int saveAll(int TransfersRetirementResignationMainId, string DocName, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "INSERT INTO Transfers_Retirement_Resignation_Main_Documents(Transfers_Retirement_Resignation_Main_Id,Document_Name) " +
											"Values(@Transfers_Retirement_Resignation_Main_Id, @Document_Name)";


			dbConnection.cmd.Parameters.AddWithValue("@Transfers_Retirement_Resignation_Main_Id", TransfersRetirementResignationMainId);
			dbConnection.cmd.Parameters.AddWithValue("@Document_Name", DocName);


			dbConnection.cmd.ExecuteNonQuery();

			return 1;
		}
	}
}

