using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ManPowerCore.Controller
{
    public interface OfficerListController
    {
        List<OfficerList> getOfficerList();
    }
    public class OfficerListControllerImpl : OfficerListController
    {
        DBConnection dBConnection;
        OfficerListDAO officerListDAO = DAOFactory.CreateOfficerListDAO();
        public List<OfficerList> getOfficerList()
        {
            DataTable officerListTable = new DataTable();
            List<OfficerList> officerLists = new List<OfficerList>();
            try
            {
                dBConnection = new DBConnection();
                officerListTable = officerListDAO.getOfficerList(dBConnection);

                foreach (DataRow row in officerListTable.Rows)
                {
                    var values = row.ItemArray;
                    var officerList = new OfficerList()
                    {
                        Name = values[0].ToString(),
                        SystemUserId = Convert.ToInt32(values[1]),
                        UserTypeId = Convert.ToInt32(values[2]),
                        PossitionId = Convert.ToInt32(values[3]),
                        DepartmentUnitId = Convert.ToInt32(values[4]),
                        ParentId = Convert.ToInt32(values[5]),





                    };
                    officerLists.Add(officerList);
                }
                return officerLists;
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}
