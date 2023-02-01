using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface EducationDetailsController
    {
        int SaveEducationDetails(EducationDetails educationDetails);

        List<EducationDetails> GetAllEducationDetails(DBConnection dbConnection);

        EducationDetails GetEducationDetailsById(int id);

        int UpdateEducationDetails(EducationDetails educationDetails);

        List<EducationDetails> GetEducationDetailsByEmpId(int empId);
    }

    public class EducationDetailsControllerImpl : EducationDetailsController
    {
        DBConnection dBConnection;
        EducationDetailsDAO eDetails = DAOFactory.CreateEducationDetailsDAO();

        public int SaveEducationDetails(EducationDetails educationDetails)
        {

            try
            {
                dBConnection = new DBConnection();
                eDetails.SaveEducationDetails(educationDetails, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<EducationDetails> GetAllEducationDetails(DBConnection dbConnection)
        {

            try
            {
                dBConnection = new DBConnection();
                List<EducationDetails> list = eDetails.GetAllEducationDetails(dBConnection);

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
        public List<EducationDetails> GetEducationDetailsByEmpId(int empId)
        {
            try
            {
                dBConnection = new DBConnection();
                List<EducationDetails> List = eDetails.GetEducationDetailsByEmpId(empId, dBConnection);

                return List;
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

        public EducationDetails GetEducationDetailsById(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                EducationDetails educationDetails = eDetails.GetEducationDetailsById(id, dBConnection);

                return educationDetails;
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

        public int UpdateEducationDetails(EducationDetails educationDetails)
        {
            try
            {
                dBConnection = new DBConnection();
                int results = eDetails.UpdateEducationDetails(educationDetails, dBConnection);

                return results;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }
    }
}
