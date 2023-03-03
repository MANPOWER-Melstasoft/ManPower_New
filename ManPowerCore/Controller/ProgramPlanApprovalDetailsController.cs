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
    public interface ProgramPlanApprovalDetailsController
    {
        int Save(ProgramPlanApprovalDetails programPlanApprovalDetails);
        List<ProgramPlanApprovalDetails> GetAll();

    }
    public class ProgramPlanApprovalDetailsControllerImpl : ProgramPlanApprovalDetailsController
    {
        DBConnection dBConnection;
        ProgramPlanApprovalDetailsDAO programPlanApprovalDetailsDAO = DAOFactory.createProgramPlanApprovalDetailsDAO();
        public int Save(ProgramPlanApprovalDetails programPlanApprovalDetails)
        {
            ProgramPlanDAO programPlanDAO = DAOFactory.CreateProgramPlanDAO();
            try
            {
                dBConnection = new DBConnection();

                programPlanApprovalDetailsDAO.Save(programPlanApprovalDetails, dBConnection);

                return programPlanDAO.UpdateProgramPlanComplete(programPlanApprovalDetails.ProjectStatus, programPlanApprovalDetails.ProgramPlanId, dBConnection);
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

        public List<ProgramPlanApprovalDetails> GetAll()
        {
            try
            {
                dBConnection = new DBConnection();

                return programPlanApprovalDetailsDAO.GetAll(dBConnection);

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
