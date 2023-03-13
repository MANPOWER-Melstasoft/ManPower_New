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
    public interface PaymentVoucherController
    {
        int Save(PaymentVoucher paymentVoucher);

        int Update(PaymentVoucher paymentVoucher);

        int UpdateStatus(int Status, string User, DateTime Date, int Id);

        List<PaymentVoucher> GetAllPaymentVoucher();

        List<PaymentVoucher> GetAllPaymentVoucherWithSupplier(bool withStatus);
    }

    public class PaymentVoucherControllerImpl : PaymentVoucherController
    {
        DBConnection dBConnection;
        PaymentVoucherDAO paymentVoucherDAO = DAOFactory.createPaymentVoucherDAO();

        public int Save(PaymentVoucher paymentVoucher)
        {
            try
            {
                dBConnection = new DBConnection();
                return paymentVoucherDAO.Save(paymentVoucher, dBConnection);
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

        public int Update(PaymentVoucher paymentVoucher)
        {
            try
            {
                dBConnection = new DBConnection();
                return paymentVoucherDAO.Update(paymentVoucher, dBConnection);
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

        public int UpdateStatus(int Status, string User, DateTime Date, int Id)
        {
            try
            {
                dBConnection = new DBConnection();
                return paymentVoucherDAO.UpdateStatus(Status, User, Date, Id, dBConnection);
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

        public List<PaymentVoucher> GetAllPaymentVoucher()
        {
            try
            {
                dBConnection = new DBConnection();
                return paymentVoucherDAO.GetAllPaymentVoucher(dBConnection);
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

        public List<PaymentVoucher> GetAllPaymentVoucherWithSupplier(bool withStatus)
        {
            try
            {
                dBConnection = new DBConnection();

                List<PaymentVoucher> paymentVoucherList = paymentVoucherDAO.GetAllPaymentVoucher(dBConnection);

                SupplierController supplierController = ControllerFactory.CreateSupplierController();
                List<Supplier> supplierList = supplierController.GetAllSupplier();

                foreach (var item in paymentVoucherList)
                {
                    item.Supplier = supplierList.Where(x => x.Id == item.SupplierId).Single();
                }

                if (withStatus)
                {
                    VoucherStatusController voucherStatusController = ControllerFactory.CreateVoucherStatusController();
                    List<VoucherStatus> voucherStatuseList = voucherStatusController.GetAllVoucherStatus();

                    foreach (var item in paymentVoucherList)
                    {
                        item.VoucherStatus = voucherStatuseList.Where(x => x.VoucherStatusId == item.Status).Single();
                    }
                }

                return paymentVoucherList;
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
