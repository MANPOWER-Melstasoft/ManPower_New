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
    public interface DependantController
    {
        int SaveDependant(Dependant dependant);

        List<Dependant> GetAllDependant();

        Dependant GetDependantById(int id);

        int UpdateDependant(Dependant dependant);

        List<Dependant> GetDependantByEmpId(int empId);
    }

    public class DependantControllerImpl : DependantController
    {
        DBConnection dBConnection;
        DependentDAO aa = DAOFactory.CreateDependentDAO();


        public int SaveDependant(Dependant dependant)
        {
            try
            {
                dBConnection = new DBConnection();
                if (dependant.DependantTypeId == 1)
                {
                    aa.SaveDependantSpouse(dependant, dBConnection);
                }
                else
                {
                    aa.SaveDependantOther(dependant, dBConnection);
                }

                return 1;
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

        public List<Dependant> GetAllDependant()
        {

            try
            {
                dBConnection = new DBConnection();
                List<Dependant> employeesList = aa.GetAllDependant(dBConnection);

                return employeesList;
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
        public List<Dependant> GetDependantByEmpId(int empId)
        {
            try
            {
                dBConnection = new DBConnection();
                List<Dependant> List = aa.GetDependantByEmpId(empId, dBConnection);

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

        public Dependant GetDependantById(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                Dependant dependant = aa.GetDependantById(id, dBConnection);

                return dependant;
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

        public int UpdateDependant(Dependant dependant)
        {
            try
            {
                int results;
                dBConnection = new DBConnection();
                if (dependant.DependantTypeId == 1)
                {
                    results = aa.UpdateDependantSpouse(dependant, dBConnection);
                }
                else
                {
                    results = aa.UpdateDependantOther(dependant, dBConnection);
                }


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

