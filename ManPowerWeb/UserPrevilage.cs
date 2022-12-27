using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManPowerWeb
{
    public class UserPrevilage
    {
        public bool checkPrevilage(int userId, int functionId)
        {
            AutUserFunctionController autUserFunctionController = ControllerFactory.CreateAutUserFunctionController();
            AutUserFunction autUserFunction = new AutUserFunction
            {
                AutUserId = userId,
                AutFunctionId = functionId
            };
            autUserFunction = autUserFunctionController.GetAutUserFunction(autUserFunction);
            if (autUserFunction.AutUserId == 0)
            {
                HttpContext.Current.Response.Redirect("401.aspx");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}