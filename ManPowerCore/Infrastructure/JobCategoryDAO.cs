using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface JobCategoryDAO
    {
        List<JobCategory> GetAllJobCategory(DBConnection dbConnection);
    }

    public class JobCategoryDAOImpl : JobCategoryDAO
    {
        public List<JobCategory> GetAllJobCategory(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM JOB_CATEGORY";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<JobCategory>(dbConnection.dr);

        }
    }
}
