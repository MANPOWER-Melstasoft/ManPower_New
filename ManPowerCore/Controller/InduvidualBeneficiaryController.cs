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
    public interface InduvidualBeneficiaryController
    {
        int SaveInduvidualBeneficiary(InduvidualBeneficiary induvidualBeneficiary);

        int UpdateInduvidualBeneficiary(InduvidualBeneficiary induvidualBeneficiary);

        int DeleteInduvidualBeneficiary(int id);

        List<InduvidualBeneficiary> GetAllInduvidualBeneficiary();

        List<InduvidualBeneficiary> GetAllInduvidualBeneficiary(string runName);


    }

    public class InduvidualBeneficiaryControllerImpl : InduvidualBeneficiaryController
    {
        DBConnection dBConnection;
        InduvidualBeneficiaryDAO induvidualBeneficiaryDAO = DAOFactory.CreateInduvidualBeneficiaryDAO();


        public int SaveInduvidualBeneficiary(InduvidualBeneficiary induvidualBeneficiary)
        {

            try
            {
                dBConnection = new DBConnection();
                int results = induvidualBeneficiaryDAO.SaveInduvidualBeneficiary(induvidualBeneficiary, dBConnection);
                return results;
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

        public int UpdateInduvidualBeneficiary(InduvidualBeneficiary induvidualBeneficiary)
        {

            try
            {
                dBConnection = new DBConnection();
                int results = induvidualBeneficiaryDAO.UpdateInduvidualBeneficiary(induvidualBeneficiary, dBConnection);
                return results;
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

        public int DeleteInduvidualBeneficiary(int id)
        {

            try
            {
                dBConnection = new DBConnection();
                int results = induvidualBeneficiaryDAO.DeleteInduvidualBeneficiary(id, dBConnection);
                return results;
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

        public List<InduvidualBeneficiary> GetAllInduvidualBeneficiary()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                InduvidualBeneficiaryDAO DAO = DAOFactory.CreateInduvidualBeneficiaryDAO();
                return DAO.GetAllInduvidualBeneficiary(dbConnection);
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }


        }

        public List<InduvidualBeneficiary> GetAllInduvidualBeneficiary(string runName)
        {

            try
            {
                dBConnection = new DBConnection();
                return induvidualBeneficiaryDAO.GetAllInduvidualBeneficiaryFilter(runName, dBConnection);
                //List<InduvidualBeneficiary> list = induvidualBeneficiaryDAO.GetAllInduvidualBeneficiaryFilter(runName, dBConnection);
                //return list;
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
