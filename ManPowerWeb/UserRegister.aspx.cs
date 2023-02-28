using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class UserRegister : System.Web.UI.Page
    {
        UserPrevilage userPrevilage = new UserPrevilage();
        int functionId = 24;
        int parentFlag = 0;
        string ErrorMsg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (userPrevilage.checkPrevilage(Convert.ToInt32(Session["UserId"]), functionId))
            {
                if (!IsPostBack)
                {
                    BindUserTypeList();
                    BindEmpList();
                    BindPositionList();
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (VallidatePassword())
            {
                SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(false, false, false);
                SystemUser systemUserTst = new SystemUser();

                systemUserTst = systemUserList.Where(x => x.UserName.ToLower() == txtUserName.Text.ToLower()).FirstOrDefault();

                if (systemUserTst == null)
                {
                    if (CheckExistsRegUSer() && CheckDistricSD())
                    {
                        if (CheckAvailableEmpNum(Convert.ToInt32(txtEmpNumber.Text)) && CheckExistsEmpNum(Convert.ToInt32(txtEmpNumber.Text), systemUserController))
                        {
                            SystemUser systemUser = new SystemUser();
                            systemUser.Name = ddlUserName.SelectedItem.Text;
                            systemUser.UserName = txtUserName.Text.ToLower();
                            systemUser.Email = txtEmail.Text;
                            systemUser.ContactNumber = txtContactNumber.Text;
                            systemUser.EmpNumber = Convert.ToInt32(txtEmpNumber.Text);
                            systemUser.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                            systemUser.CreatedDate = DateTime.Now;
                            systemUser.CreatedUser = Session["UserId"].ToString();
                            systemUser.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
                            systemUser.UserTypeId = Convert.ToInt32(ddlUserType.SelectedValue);

                            //DepartmentUnitController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitController();
                            //List<DepartmentUnit> departmentUnitList = departmentUnitTypeController.GetAllDepartmentUnit(false, false);
                            //departmentUnitList = departmentUnitList.Where(x => x.DepartmentUnitId == Convert.ToInt32(ddlDepartmentUnit.SelectedValue)).ToList();

                            systemUser.PossitionsId = Convert.ToInt32(ddlPosition.SelectedValue);
                            systemUser.DepartmentUnitId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);
                            systemUser.ParentId = GetParentId();
                            if (systemUser.ParentId != 0)
                            {

                                systemUser.SystemUserId = systemUserController.SaveSystemUser(systemUser);

                                Clear();
                                BindEmpList();

                                lblErrorUser.Text = "";
                                lblSuccessMsg.Text = "Record Updated Successfully!";
                                if (systemUser.SystemUserId > 0)
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'User Registerd Succesfully!', 'success');", true);
                                }
                                else
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

                                }
                            }
                            //else
                            //{
                            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', '" + ErrorMsg + "' , 'error');", true);
                            //}
                        }
                    }
                }
                else
                {
                    lblSuccessMsg.Text = "";
                    lblErrorUser.Text = "Username Already Taken!";
                }
            }

        }

        private int GetParentId()
        {
            int parentId = 0;
            int DGMparentId = 0;
            int userType = Convert.ToInt32(ddlUserType.SelectedValue);
            int depType = Convert.ToInt32(ddlDepartmentType.SelectedValue);
            int depId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);

            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            List<DepartmentUnitPositions> departmentUnitPositionsList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            //---------------- For DGM ---------------------
            if (userType == 5)
            {
                parentFlag = 1;
                return parentId;
            }
            //----------------------------------------------

            else
            {
                //---------------- Get DGM Position Id --------------------
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x._SystemUser.UserTypeId == 5)
                    {
                        DGMparentId = x.DepartmetUnitPossitionsId;
                        break;
                    }
                }
                if (DGMparentId != 0)
                {
                    //--------- For Planning Admin(Head Office) -----------
                    if (userType == 1)
                    {
                        parentId = DGMparentId;
                        return parentId;
                    }
                    //-----------------------------------------------------
                    //--------- For Planning Manager(Head Office) ---------
                    if (userType == 2)
                    {
                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x._SystemUser.UserTypeId == 1)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a Planning Admin Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a Planning Admin Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //--------- For Planning User(Head Office) ------------
                    if (userType == 3)
                    {
                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x._SystemUser.UserTypeId == 2)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a Planning Manager Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a Planning Manager Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //----------------- For ITAdmin -----------------------
                    if (userType == 4)
                    {
                        parentId = DGMparentId;
                        return parentId;
                    }
                    //-----------------------------------------------------
                    //----------------- For Division Head -----------------
                    if (userType == 6)
                    {
                        DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
                        DepartmentUnit departmentUnit = departmentUnitController.GetDepartmentUnit(depId, false, false);

                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x.DepartmentUnitId == departmentUnit.ParentId && x._SystemUser.UserTypeId == 8)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a District Head Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a District Head Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //----------------- For Division User -----------------
                    if (userType == 7)
                    {
                        DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
                        DepartmentUnit departmentUnit = departmentUnitController.GetDepartmentUnit(depId, false, false);

                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x.DepartmentUnitId == departmentUnit.ParentId && x._SystemUser.UserTypeId == 8)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a District Head Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a Division Head Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //----------------- For District Head -----------------
                    if (userType == 8)
                    {
                        DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();
                        List<DistricDsParent> districDsParentList = districDsParentController.GetAllDistricDsParent(false, false);
                        int userId = 0;
                        foreach (var x in districDsParentList)
                        {
                            if (x.DepartmentId == depId)
                            {
                                userId = x.ParentUserId;
                            }
                        }
                        if (userId != 0)
                        {
                            foreach (var x in departmentUnitPositionsList)
                            {
                                if (x.SystemUserId == userId)
                                {
                                    parentId = x.DepartmetUnitPossitionsId;
                                    break;
                                }
                            }
                            if (parentId != 0)
                            {
                                return parentId;
                            }
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Assign User to this District First' , 'error');", true);
                            ErrorMsg = "You Should Assign User to this District First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //----------------- For District User -----------------
                    if (userType == 9)
                    {
                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x.DepartmentUnitId == depId && x._SystemUser.UserTypeId == 8)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a District Head Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a District Head Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //---------------- For Finance Head -------------------
                    if (userType == 10)
                    {
                        parentId = DGMparentId;
                        return parentId;
                    }
                    //-----------------------------------------------------
                    //---------------- For Finance User -------------------
                    if (userType == 11)
                    {
                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x._SystemUser.UserTypeId == 10)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a Finance Head Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a Finance Head Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //---------------- For Procurement Head ---------------
                    if (userType == 12)
                    {
                        parentId = DGMparentId;
                        return parentId;
                    }
                    //---------------- For Procurement User ---------------
                    if (userType == 13)
                    {
                        foreach (var x in departmentUnitPositionsList)
                        {
                            if (x._SystemUser.UserTypeId == 12)
                            {
                                parentId = x.DepartmetUnitPossitionsId;
                                break;
                            }
                        }
                        if (parentId != 0)
                        {
                            return parentId;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a Procurement Head Account First' , 'error');", true);
                            ErrorMsg = "You Should Create a Procurement Head Account First";
                            return 0;
                        }
                    }
                    //-----------------------------------------------------
                    //---------------- For Administrator ------------------
                    if (userType == 14)
                    {
                        parentId = DGMparentId;
                        return parentId;
                    }
                    //-----------------------------------------------------
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'You Should Create a DGM Account First' , 'error');", true);
                    ErrorMsg = "You Should Create a DGM Account First";
                    return 0;
                }
            }

            //if (userType == 1 || (userType == 2 && depType == 1))
            //{
            //    return parentId;
            //}

            //if (userType == 3 && (depType == 1 || depType == 2 || depType == 3))
            //{
            //    foreach (var x in departmentUnitPositionsList)
            //    {
            //        if (x.DepartmentUnitId == depId && x._SystemUser.UserTypeId == 2)
            //        {
            //            parentId = x.DepartmetUnitPossitionsId;
            //            break;
            //        }
            //    }
            //    if (parentId == 0)
            //    {
            //        lblManagerError.Text = "There is no Manager to this Unit!";
            //    }
            //    return parentId;
            //}

            //if (userType == 2 && (depType == 2 || depType == 3))
            //{
            //    DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();
            //    List<DistricDsParent> districDsParentList = districDsParentController.GetAllDistricDsParent(false, false);
            //    int userId = 0;
            //    foreach (var x in districDsParentList)
            //    {
            //        if (x.DepartmentId == depId)
            //        {
            //            userId = x.ParentUserId;
            //        }
            //    }
            //    if (userId != 0)
            //    {
            //        foreach (var x in departmentUnitPositionsList)
            //        {
            //            if (x.SystemUserId == userId)
            //            {
            //                parentId = x.DepartmetUnitPossitionsId;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        lblManagerError.Text = "There is no Manager to this Unit!";
            //    }
            //    return parentId;
            //}
            //return parentId;
        }


        private bool CheckExistsRegUSer()
        {
            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            List<DepartmentUnitPositions> departmentUnitPositionsList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            int flag;
            int depId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);

            //--------- For Planning Admin(Head Office) -----------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 1)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x._SystemUser.UserTypeId == 1)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One Planing Admin Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //--------- For Planning Manager(Head Office) -----------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 2)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x._SystemUser.UserTypeId == 2)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One Planing Manager Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //-------------------- For DGM ------------------------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 5)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x._SystemUser.UserTypeId == 5)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One DGM Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //---------------- For Division Head --------------------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 6)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x.DepartmentUnitId == depId && x._SystemUser.UserTypeId == 6)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One Division Head Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //---------------- For District Head --------------------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 8)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x.DepartmentUnitId == depId && x._SystemUser.UserTypeId == 8)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One District Head Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //---------------- For Finance Head --------------------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 10)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x._SystemUser.UserTypeId == 10)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One Finance Head Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //-------------- For Procurement Head ------------------
            if (Convert.ToInt32(ddlUserType.SelectedValue) == 12)
            {
                flag = 0;
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x._SystemUser.UserTypeId == 12)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Only One Procurement Head Account Can be Created!', 'error');", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            else
            {
                return true;
            }
        }


        private bool CheckDistricSD()
        {
            int userTypeId = Convert.ToInt32(ddlUserType.SelectedValue);
            int depId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);
            int depType = Convert.ToInt32(ddlDepartmentType.SelectedValue);

            if (depType == 3)
            {
                if (userTypeId == 6 || userTypeId == 7)
                {
                    return true;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'This User Can Only Assign to DS Division!', 'error');", true);
                    return false;
                }
            }
            else if (depType == 2)
            {
                if (userTypeId == 8 || userTypeId == 9)
                {
                    return true;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'This User Can Only Assign to District Office!', 'error');", true);
                    return false;
                }
            }
            else
            {
                if (userTypeId == 1 || userTypeId == 2 || userTypeId == 3 || userTypeId == 4 || userTypeId == 5 ||
                    userTypeId == 10 || userTypeId == 11 || userTypeId == 12 || userTypeId == 13 || userTypeId == 14)
                {
                    return true;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'This User Can Only Assign to Head Office!', 'error');", true);
                    return false;
                }
            }


        }


        private bool CheckExistsEmpNum(int Number, SystemUserController s)
        {
            SystemUser systemUser = s.CheckEmpNumberExists(Number);

            if (systemUser.SystemUserId == 0)
            {
                lblEmpNumError.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblSuccessMsg.Text = string.Empty;
                return true;
            }
            else
            {
                lblSuccessMsg.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblEmpNumError.Text = "Already Used!";
                return false;
            }
        }

        private bool CheckAvailableEmpNum(int Number)
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            List<Employee> employeeList = employeeController.GetAllEmployees();
            int flag = 0;
            foreach (var item in employeeList)
            {
                if (item.EmployeeId == Number)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
            {
                lblEmpNumError.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblSuccessMsg.Text = string.Empty;
                return true;
            }
            else
            {
                lblSuccessMsg.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblEmpNumError.Text = "Emp Number does not Exists!";
                return false;
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private bool VallidatePassword()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                lblErrorPassword.Text = "";
                return true;
            }
            else
            {
                lblErrorPassword.Text = "Passwords should be the same";
                return false;
            }

        }

        private void BindUserTypeList()
        {
            UserTypeController userTypeController = ControllerFactory.CreateUserTypeController();
            List<UserType> userTypeList = userTypeController.GetAllUserType(false);


            ddlUserType.DataSource = userTypeList;
            ddlUserType.DataValueField = "UserTypeId";
            ddlUserType.DataTextField = "UserTypeName";
            ddlUserType.DataBind();
            ddlUserType.Items.Insert(0, new ListItem("-- select user type --", ""));

        }

        private void BindEmpList()
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            List<Employee> employeeList = employeeController.GetAllEmployees(true);

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(false, false, false);

            List<Employee> employeeListNew = new List<Employee>();

            foreach (var item in employeeList)
            {
                int flag = 0;
                for (int i = 0; i < systemUserList.Count; i++)
                {
                    if (item.EmployeeId == systemUserList[i].EmpNumber)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    employeeListNew.Add(item);
                }
            }

            ViewState["EmpList"] = employeeListNew;

            ddlUserName.DataSource = employeeListNew;
            ddlUserName.DataValueField = "EmployeeId";
            ddlUserName.DataTextField = "fullName";
            ddlUserName.DataBind();
            ddlUserName.Items.Insert(0, new ListItem("-- select user --", ""));
        }

        private void BindPositionList()
        {
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            List<Possitions> possitionList = possitionsController.GetAllPossitions(false, false);


            ddlPosition.DataSource = possitionList;
            ddlPosition.DataValueField = "PossitionId";
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0, new ListItem("-- select position --", ""));

        }



        protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartmentUnitList();
            BindDesignationList();
        }

        private void BindDepartmentUnitList()
        {

            if (ddlUserName.SelectedValue != "")
            {
                List<Employee> employeeList = (List<Employee>)ViewState["EmpList"];
                Employee employee = employeeList.Where(x => x.EmployeeId == Convert.ToInt32(ddlUserName.SelectedValue)).Single();

                txtEmpNumber.Text = employee.EmployeeId.ToString();


                DepartmentUnitTypeController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
                DepartmentUnitType departmentUnitType = departmentUnitTypeController.GetDepartmentUnitType(employee.UnitType, false);
                List<DepartmentUnitType> departmentUnitTypeList = new List<DepartmentUnitType> { departmentUnitType };

                ddlDepartmentType.DataSource = departmentUnitTypeList;
                ddlDepartmentType.DataValueField = "DepartmentUnitTypeId";
                ddlDepartmentType.DataTextField = "Name";
                ddlDepartmentType.DataBind();



                DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
                DepartmentUnit departmentUnit = new DepartmentUnit();

                if (employee.UnitType == 3)
                    departmentUnit = departmentUnitController.GetDepartmentUnit(employee.DSDivisionId, false, false);
                else
                    departmentUnit = departmentUnitController.GetDepartmentUnit(employee.DistrictId, false, false);

                List<DepartmentUnit> departmentUnitList = new List<DepartmentUnit> { departmentUnit };

                ddlDepartmentUnit.DataSource = departmentUnitList;
                ddlDepartmentUnit.DataValueField = "DepartmentUnitId";
                ddlDepartmentUnit.DataTextField = "Name";
                ddlDepartmentUnit.DataBind();
            }
            else
            {
                ddlDepartmentType.Items.Clear();
                ddlDepartmentUnit.Items.Clear();
            }

        }

        private void BindDesignationList()
        {
            if (ddlUserName.SelectedValue != "")
            {
                List<Employee> employeeList = (List<Employee>)ViewState["EmpList"];
                Employee employee = employeeList.Where(x => x.EmployeeId == Convert.ToInt32(ddlUserName.SelectedValue)).Single();

                DesignationController designationController = ControllerFactory.CreateDesignationController();
                List<Designation> designationList = designationController.GetAllDesignation(true, false, false);

                ddlDesignation.DataSource = designationList.Where(x => x.DesignationId == employee.DesignationId).ToList();
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataTextField = "DesigntionName";
                ddlDesignation.DataBind();
            }
            else
            {
                ddlDesignation.Items.Clear();
            }
        }


        private void Clear()
        {
            //txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmpNumber.Text = string.Empty;
            ddlDesignation.SelectedIndex = 0;
            ddlPosition.SelectedIndex = 0;
            ddlUserType.SelectedIndex = 0;
            ddlDepartmentType.SelectedIndex = 0;
            ddlDepartmentUnit.Items.Clear();
            lblSuccessMsg.Text = string.Empty;
        }

    }
}