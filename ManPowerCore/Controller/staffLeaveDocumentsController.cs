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
    public interface staffLeaveDocumentsController
    {
        int Save(StaffLeaveDocuments staffLeaveDocuments);

        List<StaffLeaveDocuments> GetAllDocuments();
    }

    public class staffLeaveDocumentsControllerImpl : staffLeaveDocumentsController
    {
        DBConnection dBConnection;
        StaffLeaveDocumentsDAO staffLeaveDocumentsDAO = DAOFactory.CreateStaffLeaveDocumentsDAO();

        public List<StaffLeaveDocuments> GetAllDocuments()
        {
            try
            {
                dBConnection = new DBConnection();
                return staffLeaveDocumentsDAO.GetAllDocuments(dBConnection);
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

        public int Save(StaffLeaveDocuments staffLeaveDocuments)
        {
            try
            {
                dBConnection = new DBConnection();
                return staffLeaveDocumentsDAO.Save(staffLeaveDocuments, dBConnection);
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
