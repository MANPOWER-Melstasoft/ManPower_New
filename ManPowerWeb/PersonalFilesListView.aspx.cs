using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
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
    public partial class PersonalFilesListView : System.Web.UI.Page
    {
        static string EmployeeId;
        static int ContactFlag = 0;
        string encryptedTicket;

        string[] gen = { "Male", "Female" };
        string[] mmStatus = { "Married", "Single" };
        string[] title = { "Mr", "Mrs", "Ms", "Master", "Other" };

        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnit> listDSDivision = new List<DepartmentUnit>();
        List<Designation> designation = new List<Designation>();

        List<ContractType> contractTypes = new List<ContractType>();
        List<EducationType> educationTypes = new List<EducationType>();
        List<DependantType> dependantTypes = new List<DependantType>();
        List<Dependant> dependant = new List<Dependant>();
        EmergencyContact emergencyContact = new EmergencyContact();
        EmployeeContact employeeContact = new EmployeeContact();
        List<EmploymentDetails> empDetails = new List<EmploymentDetails>();
        List<EducationDetails> educationDetails = new List<EducationDetails>();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                //----------------------- Decrypt URL ---------------------------------------------------
                encryptedTicket = Request.QueryString["Ticket"];
                FormsAuthenticationTicket decryptedTicket = FormsAuthentication.Decrypt(encryptedTicket);
                EmployeeId = HttpUtility.ParseQueryString(decryptedTicket.UserData)["Id"];


                //EmployeeId = Request.QueryString["id"];
                lblEmpNo.Text = "Employee ID : " + EmployeeId;

                BindData();
                BindEmpData();
                bindDSDivision();
                bindEmpEmergencyContact();
            }
        }

        private void BindData()
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            listDistrict = departmentUnitController.GetAllDepartmentUnit(false, false).Where(u => u.DepartmentUnitTypeId == 2 || u.DepartmentUnitTypeId == 1).ToList();
            ddlDistrict.DataSource = listDistrict;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DepartmentUnitId";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("- Select -", ""));

            DesignationController d = ControllerFactory.CreateDesignationController();
            designation = d.GetAllDesignation(true, false, false);
            ddlEmpDesignation.DataSource = designation;
            ddlEmpDesignation.DataValueField = "DesignationId";
            ddlEmpDesignation.DataTextField = "DesigntionName";
            ddlEmpDesignation.DataBind();
            ddlEmpDesignation.Items.Insert(0, new ListItem("-- select designation --", ""));

            ddlDesignation.DataSource = designation;
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataTextField = "DesigntionName";
            ddlDesignation.DataBind();

            EmploymentDetailsController employmentDetailsController = ControllerFactory.CreateEmploymentDetailsController();
            empDetails = employmentDetailsController.GetEmploymentDetailsByEmpId(Convert.ToInt32(EmployeeId));
            ddlEmpDetails.DataSource = empDetails;
            ddlEmpDetails.DataValueField = "EmploymentDetailId";
            ddlEmpDetails.DataTextField = "CompanyName";
            ddlEmpDetails.DataBind();
            ddlEmpDetails.Items.Insert(0, new ListItem("- Select -", ""));

            ddlGender.DataSource = gen;
            ddlGender.DataBind();

            ddlMR.DataSource = title;
            ddlMR.DataBind();

            ddlMaritalStatus.DataSource = mmStatus;
            ddlMaritalStatus.DataBind();

            ContractTypeController ctrType = ControllerFactory.CreateContractTypeController();
            contractTypes = ctrType.GetAllContractType();
            ddContract.DataSource = contractTypes;
            ddContract.DataValueField = "ContractTypeId";
            ddContract.DataTextField = "ContractTypeName";
            ddContract.DataBind();

            DependantTypeController dt = ControllerFactory.CreateDependantTypeController();
            dependantTypes = dt.GetAllDependantType();
            ddlDependant.DataSource = dependantTypes;
            ddlDependant.DataValueField = "DependantTypeId";
            ddlDependant.DataTextField = "DependantTypeName";
            ddlDependant.DataBind();

            DependantController dependantController = ControllerFactory.CreateDependantController();
            dependant = dependantController.GetDependantByEmpId(Convert.ToInt32(EmployeeId));
            ddlDependantList.DataSource = dependant;
            ddlDependantList.DataValueField = "DependantId";
            ddlDependantList.DataTextField = "FirstName";
            ddlDependantList.DataBind();
            ddlDependantList.Items.Insert(0, new ListItem("- Select -", ""));


            EducationTypeController et = ControllerFactory.CreateEducationTypeController();
            educationTypes = et.GetAllEducationType();
            ddlEducation.DataSource = educationTypes;
            ddlEducation.DataValueField = "EducationTypeId";
            ddlEducation.DataTextField = "EducationTypeName";
            ddlEducation.DataBind();

            EducationDetailsController educationDetailsController = ControllerFactory.CreateEducationDetailsController();
            educationDetails = educationDetailsController.GetEducationDetailsByEmpId(Convert.ToInt32(EmployeeId));
            ddlEducationDetailsList.DataSource = educationDetails;
            ddlEducationDetailsList.DataValueField = "EducationDetailsId";
            ddlEducationDetailsList.DataTextField = "ExamIndex";
            ddlEducationDetailsList.DataBind();
            ddlEducationDetailsList.Items.Insert(0, new ListItem("- Select -", ""));
        }

        private void BindEmpData()
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee employee = employeeController.GetEmployeeById(Convert.ToInt32(EmployeeId));

            ddlMR.SelectedValue = employee.Title;
            ddlGender.SelectedValue = employee.EmpGender;
            ddlMaritalStatus.SelectedValue = employee.MaritalStatus;
            fileNo.Text = employee.FileNo.ToString();
            nameOfInitials.Text = employee.NameWithInitials;
            initial.Text = employee.EmpInitials;
            lname.Text = employee.LastName;
            dob.Text = employee.DOB.ToString("yyyy-MM-dd");
            nic.Text = employee.EmployeeNIC;
            ddlEmpDesignation.SelectedValue = employee.DesignationId.ToString();
            ddlDistrict.SelectedValue = employee.DistrictId.ToString();
            txtEDComDate.Text = employee.EDCompletionDate.ToString("yyyy-MM-dd");
            txtSalaryNum.Text = employee.SalaryNo;
            vnop.Text = employee.VNOPNo.ToString();
            appointmenLetterNo.Text = employee.AppointmentNo.ToString();

            if (employee.UnitType == 3)
            {
                DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
                listDSDivision = departmentUnitController.GetAllDepartmentUnit(false, false).Where(u => u.DepartmentUnitTypeId == 3 && u.ParentId == int.Parse(ddlDistrict.SelectedValue)).ToList();

                ddlDS.DataSource = listDSDivision.Where(u => u.ParentId.ToString() == ddlDistrict.SelectedValue);
                ddlDS.DataTextField = "Name";
                ddlDS.DataValueField = "DepartmentUnitId";
                ddlDS.DataBind();
                ddlDS.Items.Insert(0, new ListItem("-- select DS --", ""));

                DsDiv.Visible = true;
                ddlDS.SelectedValue = employee.DSDivisionId.ToString();
            }


            EmployeeContactController employeeContactController = ControllerFactory.CreateEmployeeContactController();
            List<EmployeeContact> employeeContact = employeeContactController.GetAllEmployeeContact();

            foreach (var item in employeeContact)
            {
                if (item.EmpID == Convert.ToInt32(EmployeeId))
                {
                    address.Text = item.EmpAddress;
                    EmpMobilePhone.Text = item.MobileNumber;
                    telephone.Text = item.EmpTelephone;
                    email.Text = item.EmpEmail;
                    postalCode.Text = item.PostalCode;
                    officephone.Text = item.OfficePhone;

                    ContactFlag = 1;
                    break;
                }
            }
            if (employee.IsActive == 0)
            {
                lblstatus.Text = "InActive";
                btnActiveInAc.Text = "Active";
            }
            else
            {
                lblstatus.Text = "Active";
                btnActiveInAc.Text = "InActive";
            }

        }

        private void bindDSDivision()
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            if (ddlDistrict.SelectedValue != "")
            {
                listDSDivision = departmentUnitController.GetAllDepartmentUnit(false, false).Where(u => u.DepartmentUnitTypeId == 3 && u.ParentId == int.Parse(ddlDistrict.SelectedValue)).ToList();

                ddlDS.DataSource = listDSDivision.Where(u => u.ParentId.ToString() == ddlDistrict.SelectedValue);
                ddlDS.DataTextField = "Name";
                ddlDS.DataValueField = "DepartmentUnitId";
                ddlDS.DataBind();
                ddlDS.Items.Insert(0, new ListItem("-- select DS --", ""));
            }
            else
            {
                ddlDS.Items.Clear();
            }

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrict.Text == "1")
            {
                DsDiv.Visible = false;
            }
            else
            {
                DsDiv.Visible = true;
                bindDSDivision();
            }
        }



        //-------------- employment details ----------------------
        protected void ddlEmpDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindEmploymentDetails();
        }

        private void bindEmploymentDetails()
        {

            EmploymentDetailsController employmentDetailsController = ControllerFactory.CreateEmploymentDetailsController();
            List<EmploymentDetails> emp = new List<EmploymentDetails>();
            emp = employmentDetailsController.GetEmploymentDetailsByEmpId(Convert.ToInt32(EmployeeId));

            if (ddlEmpDetails.SelectedValue != "")
            {
                foreach (var i in emp.Where(u => u.EmploymentDetailId == int.Parse(ddlEmpDetails.SelectedValue)))
                {
                    ddContract.SelectedValue = i.ContractTypeId.ToString();
                    ddlDesignation.SelectedValue = i.DesignationId.ToString();
                    sDate.Text = i.StartDate.ToString("yyyy-MM-dd");
                    eDate.Text = i.EndDate.ToString("yyyy-MM-dd");
                    reseg.SelectedIndex = i.IsResigned;

                    if (i.IsResigned == 1)
                    {
                        retiredDate.Text = i.RetirementDate.ToString("yyyy-MM-dd");
                    }

                }
            }
        }
        //------------------------------------------------------


        //-------------- dependant details ----------------------
        protected void ddlDependantList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDependant();
        }

        private void bindDependant()
        {

            DependantController dependantController = ControllerFactory.CreateDependantController();
            List<Dependant> dependant = dependantController.GetDependantByEmpId(Convert.ToInt32(EmployeeId));

            if (ddlDependantList.SelectedValue != "")
            {
                foreach (var i in dependant.Where(u => u.DependantId == int.Parse(ddlDependantList.SelectedValue)))
                {
                    ddlDependant.SelectedIndex = i.DependantTypeId - 1;
                    dependantRelationship.Text = i.RelationshipToEmp;
                    dependantFname.Text = i.FirstName;
                    dependantLname.Text = i.LastName;
                    depDob.Text = i.Dob.ToString("yyyy-MM-dd");
                    bcNumber.Text = i.BirthCertificateNumber;
                    ppNumber.Text = i.DependantPassportNo;
                    sickness.Text = i.Remarks;
                    mDate.Text = i.MarriageDate.ToString("yyyy-MM-dd");
                    mCertificateNo.Text = i.MarriageCertificateNo;
                    depNic.Text = i.DependantNIC;
                    workingCompany.Text = i.WorkingCompany;
                    city.Text = i.City;


                    depId.Text = i.DependantId.ToString();

                }
            }
        }
        //------------------------------------------------------


        //-------------- Education details ----------------------
        protected void ddlEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindEducation();
        }

        private void bindEducation()
        {

            EducationDetailsController educationDetailsController = ControllerFactory.CreateEducationDetailsController();
            List<EducationDetails> edu = new List<EducationDetails>();
            edu = educationDetailsController.GetEducationDetailsByEmpId(Convert.ToInt32(EmployeeId));

            if (ddlEducationDetailsList.SelectedValue != "")
            {
                foreach (var i in edu.Where(u => u.EducationDetailsId == int.Parse(ddlEducationDetailsList.SelectedValue)))
                {
                    ddlEducation.SelectedValue = i.EducationTypeId.ToString();
                    uni.Text = i.StudiedInstitute;
                    index.Text = i.ExamIndex;
                    year.Text = i.ExamYear.ToString();
                    attempt.Text = i.NoOfAttempts.ToString();
                    sub.Text = i.ExamSubject;
                    stream.Text = i.ExamStream;
                    grade.Text = i.ExamGrade;
                    status.Text = i.ExamStatus;


                    eduId.Text = i.EducationDetailsId.ToString();

                }
            }
        }
        //------------------------------------------------------


        //------------ Emergency Contact details --------------
        private void bindEmpEmergencyContact()
        {
            EmergencyContactController emergencyContactController = ControllerFactory.CreateEmergencyContactController();
            emergencyContact = emergencyContactController.GetEmergencyContactById(Convert.ToInt32(EmployeeId));

            ecName.Text = emergencyContact.Name;
            ecRelationship.Text = emergencyContact.DependentToEmployee;
            ecAddress.Text = emergencyContact.EmgAddress;
            landLine.Text = emergencyContact.EmgTelephone;
            ecMobile.Text = emergencyContact.EmgMobile;
            ecOfficePhone.Text = emergencyContact.OfficePhone;
        }
        //----------------------------------------------------


        protected void btnUpdatePersonal_Click(object sender, EventArgs e)
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            List<DepartmentUnit> filter = departmentUnitController.GetAllDepartmentUnit(false, false);
            int output;
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee employee = new Employee();

            employee.EmployeeId = Convert.ToInt32(EmployeeId);
            employee.Title = ddlMR.SelectedValue;
            employee.EmpGender = ddlGender.SelectedValue;
            employee.MaritalStatus = ddlMaritalStatus.SelectedValue;
            employee.FileNo = int.Parse(fileNo.Text);
            employee.NameWithInitials = nameOfInitials.Text;
            employee.EmpInitials = initial.Text;
            employee.LastName = lname.Text;
            employee.DOB = Convert.ToDateTime(dob.Text);
            employee.EmployeeNIC = nic.Text;
            employee.DesignationId = int.Parse(ddlEmpDesignation.SelectedValue);
            employee.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            employee.EDCompletionDate = Convert.ToDateTime(txtEDComDate.Text);
            employee.SalaryNo = txtSalaryNum.Text;
            employee.VNOPNo = int.Parse(vnop.Text);
            employee.AppointmentNo = int.Parse(appointmenLetterNo.Text);
            employee.PensionDate = Convert.ToDateTime(dob.Text).AddYears(60);

            if (ddlDS.SelectedValue != "")
            {
                employee.DSDivisionId = int.Parse(ddlDS.SelectedValue);
                foreach (var i in filter.Where(u => u.DepartmentUnitId == int.Parse(ddlDS.SelectedValue)))
                {
                    employee.UnitType = i.DepartmentUnitTypeId;
                }
            }
            else
            {
                employee.DSDivisionId = 0;
                foreach (var i in filter.Where(u => u.DepartmentUnitId == int.Parse(ddlDistrict.SelectedValue)))
                {
                    employee.UnitType = i.DepartmentUnitTypeId;
                }
            }

            output = employeeController.UpdateEmployee(employee);

            if (output == 1)
            {
                BindEmpData();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }

        }

        protected void btnUpdateContact_Click(object sender, EventArgs e)
        {
            int output;
            EmployeeContactController employeeContactController = ControllerFactory.CreateEmployeeContactController();
            EmployeeContact employeeContact = new EmployeeContact();

            employeeContact.EmpID = Convert.ToInt32(EmployeeId);
            employeeContact.EmpAddress = address.Text;
            employeeContact.EmpTelephone = telephone.Text;
            employeeContact.EmpEmail = email.Text;
            employeeContact.MobileNumber = EmpMobilePhone.Text;
            employeeContact.OfficePhone = officephone.Text;
            employeeContact.PostalCode = postalCode.Text;

            if (ContactFlag == 1)
            {
                output = employeeContactController.UpdateEmployeeContact(employeeContact);
            }
            else
            {
                output = employeeContactController.SaveEmployeeContact(employeeContact);
            }
            if (output == 1)
            {
                BindEmpData();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
        }

        protected void btnActiveInAc_Click(object sender, EventArgs e)
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            int output;
            if (btnActiveInAc.Text == "Active")
            {
                output = employeeController.AcInAcEmployee(Convert.ToInt32(EmployeeId), 1);
            }
            else
            {
                output = employeeController.AcInAcEmployee(Convert.ToInt32(EmployeeId), 0);
            }

            if (output == 1)
            {
                BindEmpData();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalFilesList.aspx");
        }


    }
}