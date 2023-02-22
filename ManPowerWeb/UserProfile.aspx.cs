using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class UserProfile : System.Web.UI.Page
    {
        string[] mmStatus = { "Married", "Single" };

        string[] eduStatus = { "Completed", "Not Completed" };
        string[] isResigned = { "Yes", "No" };
        string[] absorbStatus = { "Yes", "Not Relevent" };
        int[] yearslist = { };

        int id = 0;

        List<Ethnicity> ethnicityList = new List<Ethnicity>();
        List<Religion> religionList = new List<Religion>();
        Employee emp = new Employee();
        List<Ethnicity> ethnicities = new List<Ethnicity>();
        List<Religion> religions = new List<Religion>();
        List<DepartmentUnit> departmentUnits = new List<DepartmentUnit>();
        List<ContactType> contactTypes = new List<ContactType>();
        List<ContractType> contractTypes = new List<ContractType>();
        List<Designation> designation = new List<Designation>();
        List<EducationType> educationTypes = new List<EducationType>();
        List<DependantType> dependantTypes = new List<DependantType>();
        List<Dependant> dependant = new List<Dependant>();
        EmergencyContact emergencyContact = new EmergencyContact();
        EmployeeContact employeeContact = new EmployeeContact();
        List<EmploymentDetails> empDetails = new List<EmploymentDetails>();
        List<EducationDetails> educationDetails = new List<EducationDetails>();
        List<EmployeeServices> employeeServices = new List<EmployeeServices>();
        List<ServiceType> serviceTypeList = new List<ServiceType>();
        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnit> listDSDivision = new List<DepartmentUnit>();
        List<DepartmentUnit> filter = new List<DepartmentUnit>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["UserId"] != null)
            {

                if (!IsPostBack)
                {
                    BindDataSource();
                    depRowId.Visible = false;
                    eduRowId.Visible = false;
                    empRowId.Visible = false;
                }

                id = (Convert.ToInt32(Session["EmpNumber"]));
            }
            else
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
                HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
                HttpContext.Current.Response.AddHeader("Expires", "0");
                Response.Redirect("Login.aspx");
            }
        }

        private void BindDataSource()
        {
            EthnicityController aa = ControllerFactory.CreateEthnicityController();
            ethnicityList = aa.GetAllEthnicity();

            ReligionController rc = ControllerFactory.CreateReligionController();
            religionList = rc.GetAllReligion();

            ContactTypeController ct = ControllerFactory.CreateContactTypeController();
            contactTypes = ct.GetAllContactType();

            ContractTypeController ctrType = ControllerFactory.CreateContractTypeController();
            contractTypes = ctrType.GetAllContractType();

            DependantTypeController dt = ControllerFactory.CreateDependantTypeController();
            dependantTypes = dt.GetAllDependantType();

            EducationTypeController et = ControllerFactory.CreateEducationTypeController();
            educationTypes = et.GetAllEducationType();

            DesignationController d = ControllerFactory.CreateDesignationController();
            designation = d.GetAllDesignation(true, false, false);

            ServiceTypeController stc = ControllerFactory.CreateServiceTypeController();
            serviceTypeList = stc.GetAllServiceType();

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            emp = employeeController.GetEmployeeById(Convert.ToInt32(Session["EmpNumber"]));

            EmergencyContactController emergencyContactController = ControllerFactory.CreateEmergencyContactController();
            emergencyContact = emergencyContactController.GetEmergencyContactById(Convert.ToInt32(Session["EmpNumber"]));

            EmployeeContactController employeeContactController = ControllerFactory.CreateEmployeeContactController();
            employeeContact = employeeContactController.GetEmployeeContact(Convert.ToInt32(Session["EmpNumber"]));

            EmploymentDetailsController employmentDetailsController = ControllerFactory.CreateEmploymentDetailsController();
            empDetails = employmentDetailsController.GetEmploymentDetailsByEmpId(Convert.ToInt32(Session["EmpNumber"]));

            DependantController dependantController = ControllerFactory.CreateDependantController();
            dependant = dependantController.GetDependantByEmpId(Convert.ToInt32(Session["EmpNumber"]));

            EducationDetailsController educationDetailsController = ControllerFactory.CreateEducationDetailsController();
            educationDetails = educationDetailsController.GetEducationDetailsByEmpId(Convert.ToInt32(Session["EmpNumber"]));

            EthnicityController ethnicityController = ControllerFactory.CreateEthnicityController();
            ethnicities = ethnicityController.GetAllEthnicity();

            ReligionController religionController = ControllerFactory.CreateReligionController();
            religions = religionController.GetAllReligion();

            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            departmentUnits = departmentUnitController.GetAllDepartmentUnit(false, false);

            ddlEducation.DataSource = educationTypes;
            ddlEducation.DataValueField = "EducationTypeId";
            ddlEducation.DataTextField = "EducationTypeName";
            ddlEducation.DataBind();

            ddlEducationDetailsList.DataSource = educationDetails;
            ddlEducationDetailsList.DataValueField = "EducationDetailsId";
            ddlEducationDetailsList.DataTextField = "ExamIndex";
            ddlEducationDetailsList.DataBind();
            ddlEducationDetailsList.Items.Insert(0, new ListItem("- Select -", ""));

            ddlDependant.DataSource = dependantTypes;
            ddlDependant.DataValueField = "DependantTypeId";
            ddlDependant.DataTextField = "DependantTypeName";
            ddlDependant.DataBind();

            ddlDependantList.DataSource = dependant;
            ddlDependantList.DataValueField = "DependantId";
            ddlDependantList.DataTextField = "FirstName";
            ddlDependantList.DataBind();
            ddlDependantList.Items.Insert(0, new ListItem("- Select -", ""));

            ddlMaritalStatus.DataSource = mmStatus;
            ddlMaritalStatus.DataBind();

            ddContract.DataSource = contractTypes;
            ddContract.DataValueField = "ContractTypeId";
            ddContract.DataTextField = "ContractTypeName";
            ddContract.DataBind();

            ddlEmpDetails.DataSource = empDetails;
            ddlEmpDetails.DataValueField = "EmploymentDetailId";
            ddlEmpDetails.DataTextField = "CompanyName";
            ddlEmpDetails.DataBind();
            ddlEmpDetails.Items.Insert(0, new ListItem("- Select -", ""));

            ddlDesignation.DataSource = designation;
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataTextField = "DesigntionName";
            ddlDesignation.DataBind();

            ddlEthnicity.DataSource = ethnicityList;
            ddlEthnicity.DataValueField = "EthnicityId";
            ddlEthnicity.DataTextField = "EthnicityName";
            ddlEthnicity.DataBind();

            ddlReligion.DataSource = religionList;
            ddlReligion.DataValueField = "ReligionId";
            ddlReligion.DataTextField = "ReligionName";
            ddlReligion.DataBind();

            ddlMaritalStatus.DataSource = mmStatus;
            ddlMaritalStatus.DataBind();

            idNo.Text = Session["EmpNumber"].ToString();

            lname.Text = emp.LastName;
            initial.Text = emp.EmpInitials;
            nameOfInitials.Text = emp.NameWithInitials;
            gen.Text = emp.EmpGender;
            dob.Text = emp.DOB.ToString("yyyy-MM-dd");
            ddlMaritalStatus.SelectedValue = emp.MaritalStatus;
            nic.Text = emp.EmployeeNIC;
            nicIssuedDate.Text = emp.NicIssueDate.ToString("yyyy-MM-dd");
            empPassport.Text = emp.EmployeePassportNumber;
            absorb.Text = emp.EpmAbsorb;
            ddlEthnicity.SelectedIndex = emp.EthnicityId - 1;
            ddlReligion.SelectedIndex = emp.ReligionId - 1;
            vnop.Text = emp.VNOPNo.ToString();
            appointmenLetterNo.Text = emp.AppointmentNo.ToString();
            fileNo.Text = emp.FileNo.ToString();
            pensionDate.Text = emp.PensionDate.ToString();

            foreach (var i in departmentUnits.Where(u => u.DepartmentUnitId == emp.DistrictId))
            {
                district.Text = i.Name;
            }

            foreach (var i in departmentUnits.Where(u => u.DepartmentUnitId == emp.DSDivisionId))
            {
                dsDivision.Text = i.Name;
            }

            //---------------- emergencyContact ---------------------

            ecName.Text = emergencyContact.Name;
            ecRelationship.Text = emergencyContact.DependentToEmployee;
            ecAddress.Text = emergencyContact.EmgAddress;
            landLine.Text = emergencyContact.EmgTelephone.ToString();
            ecMobile.Text = emergencyContact.EmgMobile.ToString();
            ecOfficePhone.Text = emergencyContact.OfficePhone.ToString();

            //---------------- employmentContact --------------------

            address.Text = employeeContact.EmpAddress;
            telephone.Text = employeeContact.EmpTelephone.ToString();
            postalCode.Text = employeeContact.PostalCode.ToString();
            email.Text = employeeContact.EmpEmail;
            EmpOfficePhone.Text = employeeContact.OfficePhone.ToString();
            EmpMobilePhone.Text = employeeContact.MobileNumber.ToString();

        }

        //-------------- dependant details ----------------------

        protected void ddlDependantList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDependantList.SelectedValue != "")
            {
                btnDependant.Text = "Update";
                bindDependant();
            }
            else
            {
                btnDependant.Text = "Add";
                ddlDependant.SelectedIndex = 0;
                dependantRelationship.Text = string.Empty;
                dependantFname.Text = string.Empty;
                dependantLname.Text = string.Empty;
                depDob.Text = string.Empty;
                bcNumber.Text = string.Empty;
                ppNumber.Text = string.Empty;
                sickness.Text = string.Empty;
                mDate.Text = string.Empty;
                mCertificateNo.Text = string.Empty;
                depNic.Text = string.Empty;
                workingCompany.Text = string.Empty;
                city.Text = string.Empty;
                depId.Text = string.Empty;
            }
        }

        private void bindDependant()
        {

            DependantController dependantController = ControllerFactory.CreateDependantController();
            dependant = dependantController.GetDependantByEmpId(Convert.ToInt32(Session["EmpNumber"]));



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

        protected void submitDependant(object sender, EventArgs e)
        {

            DependantController dc = ControllerFactory.CreateDependantController();
            Dependant dependant = new Dependant();
            List<Dependant> dependantList = new List<Dependant>();
            //dependant = dc.GetDependantById(int.Parse(depId.Text));

            dependant.DependantTypeId = int.Parse(ddlDependant.SelectedValue);
            dependant.RelationshipToEmp = dependantRelationship.Text;
            dependant.FirstName = dependantFname.Text;
            dependant.LastName = dependantLname.Text;
            dependant.Dob = Convert.ToDateTime(depDob.Text);
            dependant.BirthCertificateNumber = bcNumber.Text;
            dependant.DependantPassportNo = ppNumber.Text;
            dependant.Remarks = sickness.Text;
            dependant.MarriageCertificateNo = mCertificateNo.Text;

            if (dependant.DependantTypeId == 1)
            {
                dependant.MarriageDate = Convert.ToDateTime(mDate.Text);
            }
            dependant.DependantNIC = depNic.Text;
            dependant.WorkingCompany = workingCompany.Text;
            dependant.City = city.Text;

            int result1;
            if (btnDependant.Text == "Add")
            {
                dependant.EmpId = Convert.ToInt32(Session["EmpNumber"]);
                dependant.DocumentUploads = "";
                result1 = dc.SaveDependant(dependant);
            }
            else
            {
                dependant.DependantId = int.Parse(depId.Text);
                result1 = dc.UpdateDependant(dependant);
            }

            if (result1 == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }

        }



        //-------------- Education details ----------------------

        protected void ddlEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindEducation();
        }

        private void bindEducation()
        {

            EducationDetailsController educationDetailsController = ControllerFactory.CreateEducationDetailsController();
            List<EducationDetails> edu = new List<EducationDetails>();
            edu = educationDetailsController.GetEducationDetailsByEmpId(Convert.ToInt32(Session["EmpNumber"]));

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


        //-------------- employment details ----------------------

        protected void ddlEmpDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindEmploymentDetails();
        }

        private void bindEmploymentDetails()
        {

            EmploymentDetailsController employmentDetailsController = ControllerFactory.CreateEmploymentDetailsController();
            List<EmploymentDetails> emp = new List<EmploymentDetails>();
            emp = employmentDetailsController.GetEmploymentDetailsByEmpId(Convert.ToInt32(Session["EmpNumber"]));



            if (ddlEmpDetails.SelectedValue != "")
            {
                foreach (var i in emp.Where(u => u.EmploymentDetailId == int.Parse(ddlEmpDetails.SelectedValue)))
                {
                    ddContract.SelectedIndex = i.ContractTypeId - 1;
                    ddlDesignation.SelectedIndex = i.DesignationId - 1;
                    companyName.Text = i.CompanyName;
                    sDate.Text = i.StartDate.ToString("yyyy-MM-dd");
                    eDate.Text = i.EndDate.ToString("yyyy-MM-dd");
                    reseg.SelectedIndex = i.IsResigned;

                    if (i.IsResigned == 1)
                    {
                        retiredDate.Text = i.RetirementDate.ToString("yyyy-MM-dd");
                    }

                    empDetailId.Text = i.EmploymentDetailId.ToString();

                }
            }
        }

        protected void submitEmployee(object sender, EventArgs e)
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            filter = departmentUnitController.GetAllDepartmentUnit(false, false);

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee emp = new Employee();

            emp.ReligionId = 0;
            emp.EthnicityId = 0;
            emp.EmployeeNIC = nic.Text;
            emp.NicIssueDate = Convert.ToDateTime(nicIssuedDate.Text);
            emp.EmployeePassportNumber = empPassport.Text;
            emp.EmpInitials = initial.Text;
            emp.LastName = lname.Text;
            emp.NameWithInitials = nameOfInitials.Text;
            emp.MaritalStatus = ddlMaritalStatus.SelectedValue;
            emp.SupervisorId = 0;
            emp.ManagerId = 0;

            //emp._Dependant = (List<Dependant>)ViewState["dependant"];
            //emp._EmploymentDetails = (List<EmploymentDetails>)ViewState["employmentDetails"]; ;
            //emp._EducationDetails = (List<EducationDetails>)ViewState["educationDetails"];
            //emp._EmployeeServices = (List<EmployeeServices>)ViewState["employeeServices"];

            //emp._EmergencyContact.Name = ecName.Text;
            //emp._EmergencyContact.DependentToEmployee = ecRelationship.Text;
            //emp._EmergencyContact.EmgAddress = ecAddress.Text;
            //emp._EmergencyContact.EmgTelephone = int.Parse(landLine.Text);
            //emp._EmergencyContact.EmgMobile = int.Parse(ecMobile.Text);
            //emp._EmergencyContact.OfficePhone = int.Parse(ecOfficePhone.Text);

            //emp._EmployeeContact.EmpAddress = address.Text;
            //emp._EmployeeContact.EmpTelephone = int.Parse(telephone.Text);
            //emp._EmployeeContact.PostalCode = int.Parse(postalCode.Text);
            //emp._EmployeeContact.EmpEmail = email.Text;
            //emp._EmployeeContact.OfficePhone = int.Parse(EmpOfficePhone.Text);
            //emp._EmployeeContact.MobileNumber = int.Parse(EmpMobilePhone.Text);


            int result1 = employeeController.SaveEmployee(emp);

            if (result1 == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='PersonalFiles.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }
        }

        protected void submitContact(object sender, EventArgs e)
        {

            EmployeeContactController ec = ControllerFactory.CreateEmployeeContactController();
            EmployeeContact emp = new EmployeeContact();
            List<EmployeeContact> employeeContacts = new List<EmployeeContact>();
            employeeContacts = ec.GetAllEmployeeContact();

            foreach (var i in employeeContacts)
            {
                if (i != null)
                {
                    emp.EmpAddress = address.Text;
                    emp.EmpTelephone = (int)Convert.ToInt64(telephone.Text);
                    emp.PostalCode = Convert.ToInt32(postalCode.Text);
                    emp.EmpEmail = email.Text;
                    emp.OfficePhone = (int)Convert.ToInt64(EmpOfficePhone.Text);
                    emp.MobileNumber = (int)Convert.ToInt64(EmpMobilePhone.Text);
                    emp.EmpID = Convert.ToInt32(Session["EmpNumber"]);

                    int result1 = ec.UpdateEmployeeContact(emp);

                    if (result1 == 1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},1500);", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

                    }
                }
                else
                {
                    emp.EmpAddress = address.Text;
                    emp.EmpTelephone = int.Parse(telephone.Text);
                    emp.PostalCode = int.Parse(postalCode.Text);
                    emp.EmpEmail = email.Text;
                    emp.OfficePhone = int.Parse(EmpOfficePhone.Text);
                    emp.MobileNumber = int.Parse(EmpMobilePhone.Text);
                    emp.EmpID = Convert.ToInt32(Session["EmpNumber"]);

                    int result1 = ec.SaveEmployeeContact(emp);

                    if (result1 == 1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},2500);", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

                    }
                }

            }


        }

        protected void submitEmergencyContact(object sender, EventArgs e)
        {
            EmergencyContactController ec = ControllerFactory.CreateEmergencyContactController();
            EmergencyContact emp = new EmergencyContact();
            List<EmergencyContact> emergencyContacts = new List<EmergencyContact>();
            emergencyContacts = ec.GetAllEmergencyContact();

            foreach (var i in emergencyContacts.Where(u => u.EmployeeId == Convert.ToInt32(Session["EmpNumber"])))
            {
                if (i != null)
                {
                    emp.Name = ecName.Text;
                    emp.DependentToEmployee = ecRelationship.Text;
                    emp.EmgAddress = ecAddress.Text;
                    emp.EmgTelephone = int.Parse(landLine.Text);
                    emp.EmgMobile = int.Parse(ecMobile.Text);
                    emp.OfficePhone = int.Parse(ecOfficePhone.Text);
                    emp.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);
                    emp.DependantTypeId = i.DependantTypeId;

                    int result1 = ec.UpdateEmergencyContact(emp);

                    if (result1 == 1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},2500);", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

                    }
                }
                else
                {
                    emp.Name = ecName.Text;
                    emp.DependentToEmployee = ecRelationship.Text;
                    emp.EmgAddress = ecAddress.Text;
                    emp.EmgTelephone = int.Parse(landLine.Text);
                    emp.EmgMobile = int.Parse(ecMobile.Text);
                    emp.OfficePhone = int.Parse(ecOfficePhone.Text);
                    emp.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);

                    int result1 = ec.SaveEmergencyContact(emp);

                    if (result1 == 1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},2500);", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

                    }
                }
            }


        }



        protected void submitEducation(object sender, EventArgs e)
        {

            EducationDetailsController ed = ControllerFactory.CreateEducationDetailsController();
            EducationDetails educationDetails = new EducationDetails();
            string id = eduId.Text;
            educationDetails = ed.GetEducationDetailsById(int.Parse(eduId.Text));

            educationDetails.EducationTypeId = int.Parse(ddlEducation.SelectedValue);
            educationDetails.StudiedInstitute = uni.Text;

            if (attempt.Text == "")
            {
                educationDetails.NoOfAttempts = 1;
            }
            else
            {
                educationDetails.NoOfAttempts = int.Parse(attempt.Text);
            }
            educationDetails.ExamYear = int.Parse(year.Text);
            educationDetails.ExamSubject = sub.Text;
            educationDetails.ExamStream = stream.Text;
            educationDetails.ExamGrade = grade.Text;
            educationDetails.ExamStatus = status.Text;

            int result1 = ed.UpdateEducationDetails(educationDetails);

            if (result1 == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }

        }

        protected void submitEmploymentDetails(object sender, EventArgs e)
        {

            EmploymentDetailsController ed = ControllerFactory.CreateEmploymentDetailsController();
            EmploymentDetails employmentDetails = new EmploymentDetails();
            employmentDetails = ed.GetEmploymentDetails(int.Parse(empDetailId.Text));

            employmentDetails.ContractTypeId = int.Parse(ddContract.SelectedValue);
            employmentDetails.DesignationId = int.Parse(ddlDesignation.SelectedValue);
            employmentDetails.CompanyName = companyName.Text;
            employmentDetails.StartDate = Convert.ToDateTime(sDate.Text);
            employmentDetails.EndDate = Convert.ToDateTime(eDate.Text);
            employmentDetails.IsResigned = int.Parse(reseg.SelectedValue);

            if (retiredDate.Text != "")
            {
                employmentDetails.RetirementDate = Convert.ToDateTime(retiredDate.Text);
            }
            employmentDetails.EmploymentDetailId = int.Parse(empDetailId.Text);

            int result1 = ed.UpdateEmploymentDetails(employmentDetails);

            if (result1 == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='UserProfile.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), false, false, false);

            if (systemUser.UserPwd == FormsAuthentication.HashPasswordForStoringInConfigFile(txtCurrentPassword.Text, "SHA1"))
            {
                lblCurPass.Text = string.Empty;

                if (txtNewPasword.Text == txtReNewPasword.Text)
                {
                    int output = 0;
                    lblMisMatchPwd.Text = string.Empty;
                    systemUser.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtReNewPasword.Text, "SHA1");
                    output = systemUserController.ChangePassword(systemUser);

                    if (output == 1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Password Changed Succesfully!', 'success');window.setTimeout(2500);", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Password Changed Fail!', 'error');", true);
                    }
                }
                else
                {
                    lblMisMatchPwd.Text = "Password MissMatch";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Password MissMatch!', 'error');", true);

                }
            }
            else
            {
                lblCurPass.Text = "Incorrect Current Password";
                lblMisMatchPwd.Text = string.Empty;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Incorrect Current Password!', 'error');", true);

            }
        }
    }
}