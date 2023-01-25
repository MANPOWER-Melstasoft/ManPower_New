﻿using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface RequestTypeController
    {
        List<RequestType> GetAllRequestType(bool with0);
    }

    public class RequestTypeControllerSqlImpl : RequestTypeController
    {
        public List<RequestType> GetAllRequestType(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                RequestTypeDAO DAO = DAOFactory.CreateRequestTypeDAO();
                return DAO.GetAllRequestType(with0, dbConnection);
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
