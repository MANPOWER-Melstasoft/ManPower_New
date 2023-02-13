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
    public interface VoucherDetailController
    {
        int Save(VoucherDetail voucherDetail);

        int Update(VoucherDetail voucherDetail);

        List<VoucherDetail> GetAllVoucherDetail();
    }

    public class VoucherDetailControllerImpl : VoucherDetailController
    {
        DBConnection dBConnection;
        VoucherDetailDAO voucherDetailDAO = DAOFactory.createVoucherDetailDAO();

        public int Save(VoucherDetail voucherDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                return voucherDetailDAO.Save(voucherDetail, dBConnection);
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

        public int Update(VoucherDetail voucherDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                return voucherDetailDAO.Update(voucherDetail, dBConnection);
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

        public List<VoucherDetail> GetAllVoucherDetail()
        {
            try
            {
                dBConnection = new DBConnection();
                return voucherDetailDAO.GetAllVoucherDetail(dBConnection);
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
