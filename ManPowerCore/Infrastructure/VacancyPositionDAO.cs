using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface VacancyPositionDAO
    {
        int saveVacancyPosition(VacancyPosition vacancyPosition, DBConnection dbConnection);
        List<VacancyPosition> getAllVacancyPosition(DBConnection dbConnection);

        int updateVacancyPosition(int id, VacancyPosition vacancyPosition, DBConnection dbConnection);

        int deletePosition(int id, DBConnection dbConnection);


    }
    public class VacancyPositionDAOImpl : VacancyPositionDAO
    {

        public int saveVacancyPosition(VacancyPosition vacancyPosition, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            dbConnection.cmd.CommandText = "INSERT INTO Company_Vacancy_Position(Position_Category,Position_Name) VALUES(@Category,@PositionName) SELECT SCOPE_IDENTITY() ";

            dbConnection.cmd.Parameters.AddWithValue("@Category", vacancyPosition.VacancyCategory);
            dbConnection.cmd.Parameters.AddWithValue("@PositionName", vacancyPosition.VacancyPositionName);
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

        }

        public List<VacancyPosition> getAllVacancyPosition(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Company_Vacancy_Position";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VacancyPosition>(dbConnection.dr);

        }

        public int updateVacancyPosition(int id, VacancyPosition vacancyPosition, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Company_Vacancy_Position SET Position_Category=@Category,Position_Name=@PositionName WHERE Id=@Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Category", vacancyPosition.VacancyCategory);
            dbConnection.cmd.Parameters.AddWithValue("@PositionName", vacancyPosition.VacancyPositionName);
            dbConnection.cmd.Parameters.AddWithValue("@Id", id);

            return dbConnection.cmd.ExecuteNonQuery();

        }

        public int deletePosition(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Company_Vacancy_Position SET Is_Active = 0 WHERE Id=@Id ";
            dbConnection.cmd.Parameters.AddWithValue("@Id", id);

            return dbConnection.cmd.ExecuteNonQuery();

        }
    }
}
