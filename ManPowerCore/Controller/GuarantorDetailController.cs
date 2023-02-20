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
    public interface GuarantorDetailController
    {
        int Save(GuarantorDetail guarantorDetail);

        int Update(GuarantorDetail guarantorDetail);

        List<GuarantorDetail> GetAllGuarantorDetail();
    }

    public class GuarantorDetailControllerImpl : GuarantorDetailController
    {
        DBConnection dBConnection;
        GuarantorDetailDAO guarantorDetailDAO = DAOFactory.createGuarantorDetailDAO();
        public int Save(GuarantorDetail guarantorDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                return guarantorDetailDAO.Save(guarantorDetail, dBConnection);
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

        public int Update(GuarantorDetail guarantorDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                return guarantorDetailDAO.Update(guarantorDetail, dBConnection);
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

        public List<GuarantorDetail> GetAllGuarantorDetail()
        {
            try
            {
                dBConnection = new DBConnection();
                return guarantorDetailDAO.GetAllGuarantorDetail(dBConnection);
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
