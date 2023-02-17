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
    public interface ProgramController
    {

        int SaveProgram(Program program);

        int UpdateProgram(Program program);

        List<Program> GetAllProgram(bool withOut0, bool withProgramTarget, bool withProgramType);

        Program GetProgram(int id, bool withProgramTarget);
    }

    public class ProgramControllerImpl : ProgramController
    {

        DBConnection dBConnection;
        ProgramDAO programDAO = DAOFactory.CreateProgramDAO();


        public int SaveProgram(Program program)
        {

            try
            {
                dBConnection = new DBConnection();
                return programDAO.SaveProgram(program, dBConnection);
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

        public int UpdateProgram(Program program)
        {


            try
            {
                dBConnection = new DBConnection();
                var programs = programDAO.UpdateProgram(program, dBConnection);
                return programs;
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


        public List<Program> GetAllProgram(bool withOut0, bool withProgramTarget, bool withProgramType)
        {
            try
            {
                dBConnection = new DBConnection();
                List<Program> list = programDAO.GetAllProgram(dBConnection);

                if (withOut0)
                {
                    list = list.Where(x => x.IsActive == 1).ToList();
                }

                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    foreach (var item in list)
                    {
                        item._ProgramTarget = _ProgramTargetDAO.GetAllProgramTargetByProgramId(item.ProgramId, dBConnection);
                    }
                }

                if (withProgramType)
                {
                    ProgramTypeDAO programTypeDAO = DAOFactory.CreateProgramTypeDAO();
                    List<ProgramType> programTypeList = programTypeDAO.GetAllProgramType(dBConnection);

                    foreach (var item in list)
                    {
                        item._ProgramType = programTypeList.Where(x => x.ProgramTypeId == item.ProgramType).Single();
                    }
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

        public Program GetProgram(int id, bool withProgramTarget)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramDAO DAO = DAOFactory.CreateProgramDAO();
                Program program = DAO.GetProgram(id, dbConnection);

                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    program._ProgramTarget = _ProgramTargetDAO.GetAllProgramTargetByProgramId(program.ProgramId, dbConnection);
                }

                return program;
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
