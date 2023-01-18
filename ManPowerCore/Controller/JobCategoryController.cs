using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface JobCategoryController
    {
        List<JobCategory> GetAllJobCategory();
    }

    public class JobCategoryControllerImpl : JobCategoryController
    {
        DBConnection dBConnection;
        JobCategoryDAO jobCategory = DAOFactory.CreateJobCategoryDAO();

        public List<JobCategory> GetAllJobCategory()
        {
            try
            {
                dBConnection = new DBConnection();
                List<JobCategory> list = jobCategory.GetAllJobCategory(dBConnection);

                return list;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }
    }
}
