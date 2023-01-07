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
    public interface DistricDsParentController
    {
        int Save(DistricDsParent districDsParent);
        int Update(DistricDsParent districDsParent);
        int Delete(DistricDsParent districDsParent);
        List<DistricDsParent> GetAllDistricDsParent(bool withUser, bool withDepartment);
        DistricDsParent GetDistricDsParent(DistricDsParent districDsParent);
    }

    public class DistricDsParentControllerImpl : DistricDsParentController
    {
        DistricDsParentDAO districDsParentDAO = DAOFactory.CreateDistricDsParentDAO();

        public int Save(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                int output = 0;

                //add parent reference
                DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
                List<DepartmentUnitPositions> departmentUnitPositionList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, false);

                DepartmentUnitPositions departmentUnitPositions = departmentUnitPositionList.Where(x => x.SystemUserId == districDsParent.ParentUserId).Single();
                List<DepartmentUnitPositions> departmentUnitPositionListNew = new List<DepartmentUnitPositions>();

                foreach (var item in departmentUnitPositionList)
                {
                    if (item.DepartmentUnitId == districDsParent.DepartmentId && item._SystemUser.UserTypeId == 2)
                    {
                        item.ParentId = departmentUnitPositions.DepartmetUnitPossitionsId;
                        departmentUnitPositionListNew.Add(item);
                    }
                }
                foreach (var item in departmentUnitPositionListNew)
                {
                    departmentUnitPositionsDAO.UpdateDepartmentUnitPositions(item, dbConnection);
                }



                output = districDsParentDAO.Save(districDsParent, dbConnection);
                return output;
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





        public int Update(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                int output = 0;

                dbConnection = new DBConnection();
                DistricDsParent districDsParentOld = districDsParentDAO.GetDistricDsParentFromId(districDsParent.Id, dbConnection);


                //if user not changed and department changes
                if (districDsParentOld.ParentUserId == districDsParent.ParentUserId && districDsParentOld.DepartmentId != districDsParent.DepartmentId)
                {
                    DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();

                    DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
                    List<DepartmentUnitPositions> departmentUnitPositionList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, false);


                    DepartmentUnitPositions departmentUnitPositions = departmentUnitPositionList.Where(x => x.SystemUserId == districDsParent.ParentUserId).Single();
                    List<DepartmentUnitPositions> departmentUnitPositionListNew = new List<DepartmentUnitPositions>();

                    foreach (var item in departmentUnitPositionList)
                    {
                        if (item.DepartmentUnitId == districDsParent.DepartmentId && item._SystemUser.UserTypeId == 2)
                        {
                            item.ParentId = departmentUnitPositions.DepartmetUnitPossitionsId;
                            departmentUnitPositionListNew.Add(item);
                        }
                    }

                    foreach (var item in departmentUnitPositionListNew)
                    {
                        departmentUnitPositionsDAO.UpdateDepartmentUnitPositions(item, dbConnection);
                    }

                    if (districDsParentOld.Id != 0)
                    {
                        DepartmentUnitPositions departmentUnitPositions0 = departmentUnitPositionList.Where(x => x.SystemUserId == districDsParentOld.ParentUserId).Single();
                        List<DepartmentUnitPositions> departmentUnitPositionListNew0 = new List<DepartmentUnitPositions>();

                        foreach (var item in departmentUnitPositionList)
                        {
                            if (item.DepartmentUnitId == districDsParentOld.DepartmentId && item.ParentId == departmentUnitPositions0.DepartmetUnitPossitionsId)
                            {
                                item.ParentId = 0;
                                departmentUnitPositionListNew0.Add(item);
                            }
                        }

                        foreach (var item in departmentUnitPositionListNew0)
                        {
                            departmentUnitPositionsDAO.UpdateDepartmentUnitPositions(item, dbConnection);
                        }
                    }
                }

                output = districDsParentDAO.Update(districDsParent, dbConnection);

                return output;
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







        public int Delete(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                int output = 0;

                //delete parent reference
                DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
                List<DepartmentUnitPositions> departmentUnitPositionList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, false);

                DepartmentUnitPositions departmentUnitPositions0 = departmentUnitPositionList.Where(x => x.SystemUserId == districDsParent.ParentUserId).Single();
                List<DepartmentUnitPositions> departmentUnitPositionListNew0 = new List<DepartmentUnitPositions>();

                foreach (var item in departmentUnitPositionList)
                {
                    if (item.DepartmentUnitId == districDsParent.DepartmentId && item.ParentId == departmentUnitPositions0.DepartmetUnitPossitionsId)
                    {
                        item.ParentId = 0;
                        departmentUnitPositionListNew0.Add(item);
                    }
                }
                foreach (var item in departmentUnitPositionListNew0)
                {
                    departmentUnitPositionsDAO.UpdateDepartmentUnitPositions(item, dbConnection);
                }



                output = districDsParentDAO.Delete(districDsParent, dbConnection);


                return output;
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

        public List<DistricDsParent> GetAllDistricDsParent(bool withUser, bool withDepartment)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                List<DistricDsParent> districDsParentsList = districDsParentDAO.GetAllDistricDsParent(dbConnection);

                if (withUser)
                {
                    SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();

                    foreach (var item in districDsParentsList)
                    {
                        item.systemUser = systemUserDAO.GetSystemUser(item.ParentUserId, dbConnection);
                    }
                }

                if (withDepartment)
                {
                    DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();

                    foreach (var item in districDsParentsList)
                    {
                        item.departmentUnit = departmentUnitDAO.GetDepartmentUnit(item.DepartmentId, dbConnection);
                    }
                }

                return districDsParentsList;

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

        public DistricDsParent GetDistricDsParent(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return districDsParentDAO.GetDistricDsParent(districDsParent, dbConnection);

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

    }
}
