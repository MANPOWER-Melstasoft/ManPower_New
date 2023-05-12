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
	public interface EmployeePreviousWorkplaceController
	{
		int save(EmployeePreviousWorkplace obj);

		List<EmployeePreviousWorkplace> GetAllEmployeePreviousWorkplaces(bool with0);
	}
	public class EmployeePreviousWorkplaceControllerImpl : EmployeePreviousWorkplaceController
	{
		DBConnection dBConnection = null;
		EmployeePreviousWorkplaceDAO employeePreviousWorkplaceDAO = DAOFactory.CreateEmployeePreviousWorkplaceDAO();

		public int save(EmployeePreviousWorkplace obj)
		{
			try
			{
				dBConnection = new DBConnection();
				return employeePreviousWorkplaceDAO.save(obj, dBConnection);
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
		public List<EmployeePreviousWorkplace> GetAllEmployeePreviousWorkplaces(bool with0)
		{
			try
			{
				dBConnection = new DBConnection();
				List<EmployeePreviousWorkplace> list = employeePreviousWorkplaceDAO.GetAllEmployeePreviousWorkplaces(with0, dBConnection);

				EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
				DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();

				foreach (var item in list)
				{
					item.employee = employeeDAO.GetEmployeeById(item.EmployeeId, dBConnection);
					item.departmentUnit = departmentUnitDAO.GetDepartmentUnit(item.PreviousWorkplaceId, dBConnection);
					item.departmentUnit2 = departmentUnitDAO.GetDepartmentUnit(item.CurrentWorkplaceId, dBConnection);
				}

				return list;
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
