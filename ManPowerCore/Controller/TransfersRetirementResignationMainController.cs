using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
	public interface TransfersRetirementResignationMainController
	{
		int Save(TransfersRetirementResignationMain obj);
		int Delete(int id);
		int Update(TransfersRetirementResignationMain obj);
		int Recommend(TransfersRetirementResignationMain obj);
		List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignation(bool with0);

		List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignationwithEmployeeDetails(bool withEmployeeDetails);
		TransfersRetirementResignationMain GetTransfersRetirementResignation(int Id);


	}

	public class TransfersRetirementResignationMainControllerSqlImpl : TransfersRetirementResignationMainController
	{
		TransfersRetirementResignationMainDAO transfersRetirementResignationMainDAO = DAOFactory.CreateTransfersRetirementResignationMainDAO();
		DBConnection dBConnection;

		public int Save(TransfersRetirementResignationMain obj)
		{
			try
			{
				dBConnection = new DBConnection();
				int result = transfersRetirementResignationMainDAO.Save(obj, dBConnection);
				if (result != 0)
				{
					TransfersRetirementResignationMainDocumentDAO transfersRetirementResignationMainDocumentDAO = DAOFactory.CreateTransfersRetirementResignationMainDocumentDAO();
					//return transfersRetirementResignationMainDocumentDAO.saveAll(TransfersRetirementResignationMainId, DocName, dbConnection);
				}
				return result;
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

		public int Update(TransfersRetirementResignationMain obj)
		{
			try
			{
				int output = 0;
				dBConnection = new DBConnection();
				output = transfersRetirementResignationMainDAO.Approve(obj, dBConnection);

				if (output == 1 && obj.RequestTypeId == 1)
				{
					EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
					TransferDAO transferDAO = DAOFactory.CreateTransferDAO();
					DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();
					EmployeePreviousWorkplaceDAO empPreviousWorkplaceDAO = DAOFactory.CreateEmployeePreviousWorkplaceDAO();

					EmployeePreviousWorkplace empPreviousWorkplace = new EmployeePreviousWorkplace();
					empPreviousWorkplace.TransfersRetirementResignationMainId = obj.MainId;
					empPreviousWorkplace.EmployeeId = obj.EmployeeId;


					Employee Employee = employeeDAO.GetEmployeeById(obj.EmployeeId, dBConnection);
					Transfer transfer = transferDAO.GetTransferByMainId(obj.MainId, dBConnection);
					DepartmentUnit departmentUnit = departmentUnitDAO.GetDepartmentUnit(transfer.NextDep, dBConnection);

					if (Employee.UnitType == 3)
					{
						empPreviousWorkplace.PreviousWorkplaceId = Employee.DSDivisionId;
					}
					else
					{
						empPreviousWorkplace.PreviousWorkplaceId = Employee.DistrictId;
					}

					empPreviousWorkplace.CurrentWorkplaceId = transfer.NextDep;

					Employee employee = new Employee();
					employee.EmployeeId = obj.EmployeeId;
					employee.UnitType = departmentUnit.DepartmentUnitTypeId;
					if (departmentUnit.DepartmentUnitTypeId == 3)
					{
						employee.DSDivisionId = departmentUnit.DepartmentUnitId;
						employee.DistrictId = departmentUnit.ParentId;
					}
					else
					{
						employee.DSDivisionId = 0;
						employee.DistrictId = departmentUnit.DepartmentUnitId;
					}

					output = employeeDAO.ChanngeDepartment(employee, dBConnection);
					output = empPreviousWorkplaceDAO.save(empPreviousWorkplace, dBConnection);

				}

				return output;
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

		public int Recommend(TransfersRetirementResignationMain obj)
		{
			try
			{
				dBConnection = new DBConnection();
				return transfersRetirementResignationMainDAO.Recommend(obj, dBConnection);
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

		public int Delete(int id)
		{
			try
			{
				dBConnection = new DBConnection();
				return transfersRetirementResignationMainDAO.Delete(id, dBConnection);
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

		public List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignation(bool with0)
		{
			try
			{
				dBConnection = new DBConnection();
				RetirementTypeDAO DAO = DAOFactory.CreateRetirementTypeDAO();
				List<TransfersRetirementResignationMain> list = transfersRetirementResignationMainDAO.GetAllTransfersRetirementResignation(with0, dBConnection);

				RequestTypeDAO requestTypeDAO = DAOFactory.CreateRequestTypeDAO();
				TransfersRetirementResignationStatusDAO statusDAO = DAOFactory.CreateTransfersRetirementResignationStatusDAO();
				EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();

				foreach (var item in list)
				{
					item.requestType = requestTypeDAO.GetRequestType(item.RequestTypeId, dBConnection);
					item.status = statusDAO.GetStatus(item.StatusId, dBConnection);
					item.employee = employeeDAO.GetEmployeeById(item.EmployeeId, dBConnection);
				}

				return list;
			}
			catch (Exception ex)
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

		public List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignationwithEmployeeDetails(bool withEmployeeDetails)
		{
			try
			{
				dBConnection = new DBConnection();
				RetirementTypeDAO DAO = DAOFactory.CreateRetirementTypeDAO();
				List<TransfersRetirementResignationMain> list = transfersRetirementResignationMainDAO.GetAllTransfersRetirementResignation(false, dBConnection);

				EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
				List<Employee> employees = new List<Employee>();
				employees = employeeDAO.GetAllEmployee(dBConnection);

				foreach (var item in list)
				{
					item.employee = employees.Where(x => x.EmployeeId == item.EmployeeId).Single();
				}

				return list;
			}
			catch (Exception ex)
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

		public TransfersRetirementResignationMain GetTransfersRetirementResignation(int Id)
		{
			try
			{
				dBConnection = new DBConnection();
				EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
				TransfersRetirementResignationStatusDAO trmStatusDAO = DAOFactory.CreateTransfersRetirementResignationStatusDAO();

				TransfersRetirementResignationMain transfersRetirementResignationMain = new TransfersRetirementResignationMain();
				transfersRetirementResignationMain = transfersRetirementResignationMainDAO.GetTransfersRetirementResignation(Id, dBConnection);
				transfersRetirementResignationMain.employee = employeeDAO.GetEmployeeById(transfersRetirementResignationMain.EmployeeId, dBConnection);
				transfersRetirementResignationMain.status = trmStatusDAO.GetStatus(transfersRetirementResignationMain.StatusId, dBConnection);

				return transfersRetirementResignationMain;
			}
			catch (Exception ex)
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
