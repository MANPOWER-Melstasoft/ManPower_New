using Antlr.Runtime;
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class PersonalFiles : System.Web.UI.Page
    {
        private int count;
        public int Count { get { return count; } }
        public int thisYear = DateTime.Today.Year;

        string[] gen = { "Male", "Female" };
        string[] mmStatus = { "Married", "Single" };
        int[] attempt = { 1, 2, 3 };
        string[] eduStatus = { "Completed", "Not Completed" };
        string[] isResigned = { "Yes", "No" };
        string[] title = { "Mr", "Mrs", "Ms", "Master", "Other" };
        //string[] absorbStatus = { "Yes", "Not Relevent" };
        int[] yearslist =
        {
            (DateTime.Today.Year),
            (DateTime.Today.Year) - 1,
            (DateTime.Today.Year) - 2,
            (DateTime.Today.Year) - 3,
            (DateTime.Today.Year) - 4,
            (DateTime.Today.Year) - 5,
            (DateTime.Today.Year) - 6,
            (DateTime.Today.Year) - 7,
            (DateTime.Today.Year) - 8,
            (DateTime.Today.Year) - 9,
            (DateTime.Today.Year) - 10,
            (DateTime.Today.Year) - 12,
            (DateTime.Today.Year) - 13,
            (DateTime.Today.Year) - 14,
            (DateTime.Today.Year) - 15,
            (DateTime.Today.Year) - 16,
            (DateTime.Today.Year) - 17,
            (DateTime.Today.Year) - 18,
            (DateTime.Today.Year) - 19,
            (DateTime.Today.Year) - 20,
            (DateTime.Today.Year) - 21,
            (DateTime.Today.Year) - 22,
            (DateTime.Today.Year) - 23,
            (DateTime.Today.Year) - 24,
            (DateTime.Today.Year) - 25,
            (DateTime.Today.Year) - 26,
            (DateTime.Today.Year) - 27,
            (DateTime.Today.Year) - 28,
            (DateTime.Today.Year) - 29,
            (DateTime.Today.Year) - 30,
            (DateTime.Today.Year) - 31,
            (DateTime.Today.Year) - 32,
            (DateTime.Today.Year) - 33,
            (DateTime.Today.Year) - 34,
            (DateTime.Today.Year) - 35,
            (DateTime.Today.Year) - 36,
            (DateTime.Today.Year) - 37,
            (DateTime.Today.Year) - 38
        };


        List<ContactType> contactTypes = new List<ContactType>();
        List<ContractType> contractTypes = new List<ContractType>();
        List<Designation> designation = new List<Designation>();
        List<Ethnicity> ethnicityList = new List<Ethnicity>();
        List<Religion> religionList = new List<Religion>();
        List<EducationType> educationTypes = new List<EducationType>();
        List<DependantType> dependantTypes = new List<DependantType>();
        List<Dependant> dependant = new List<Dependant>();
        List<EmergencyContact> emergencyContact = new List<EmergencyContact>();
        List<EmployeeContact> employeeContact = new List<EmployeeContact>();
        List<EmploymentDetails> employmentDetails = new List<EmploymentDetails>();
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

                    id1.Visible = true;
                    id2.Visible = false;
                    id3.Visible = false;
                    //id4.Visible = false;
                    //id5.Visible = false;
                    //id6.Visible = false;
                    id7.Visible = false;
                }
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

            //DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            listDistrict = departmentUnitController.GetAllDepartmentUnit(false, false).Where(u => u.DepartmentUnitTypeId == 2 || u.DepartmentUnitTypeId == 1).ToList();

            ddlGender.DataSource = gen;
            ddlGender.DataBind();

            ddlMR.DataSource = title;
            ddlMR.DataBind();

            //ddlEducationStatus.DataSource = eduStatus;
            //ddlEducationStatus.DataBind();

            //ddlEthnicity.DataSource = ethnicityList;
            //ddlEthnicity.DataValueField = "EthnicityId";
            //ddlEthnicity.DataTextField = "EthnicityName";
            //ddlEthnicity.DataBind();

            //ddlReligion.DataSource = religionList;
            //ddlReligion.DataValueField = "ReligionId";
            //ddlReligion.DataTextField = "ReligionName";
            //ddlReligion.DataBind();

            //ddlEducation.DataSource = educationTypes;
            //ddlEducation.DataValueField = "EducationTypeId";
            //ddlEducation.DataTextField = "EducationTypeName";
            //ddlEducation.DataBind();

            //ddlAttempt.DataSource = attempt;
            //ddlAttempt.DataBind();

            //ddlYear.DataSource = yearslist;
            //ddlYear.DataBind();

            ddlDependant.DataSource = dependantTypes;
            ddlDependant.DataValueField = "DependantTypeId";
            ddlDependant.DataTextField = "DependantTypeName";
            ddlDependant.DataBind();

            ddlMaritalStatus.DataSource = mmStatus;
            ddlMaritalStatus.DataBind();

            //ddlAbsorb.DataSource = absorbStatus;
            //ddlAbsorb.DataBind();

            ddlService.DataSource = serviceTypeList;
            ddlService.DataValueField = "ServiceTypeId";
            ddlService.DataTextField = "ServiceTypeName";
            ddlService.DataBind();

            ddContract.DataSource = contractTypes;
            ddContract.DataValueField = "ContractTypeId";
            ddContract.DataTextField = "ContractTypeName";
            ddContract.DataBind();

            ddlEmpDesignation.DataSource = designation;
            ddlEmpDesignation.DataValueField = "DesignationId";
            ddlEmpDesignation.DataTextField = "DesigntionName";
            ddlEmpDesignation.DataBind();
            ddlEmpDesignation.Items.Insert(0, new ListItem("-- select designation --", ""));

            ddlDesignation.DataSource = designation;
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataTextField = "DesigntionName";
            ddlDesignation.DataBind();

            ddlDistrict.DataSource = listDistrict;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DepartmentUnitId";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("- Select -", ""));

            ddlDS.DataSource = listDSDivision;
            ddlDS.DataTextField = "Name";
            ddlDS.DataValueField = "DepartmentUnitId";
            ddlDS.DataBind();

        }


        private void bindDSDivision()
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            listDSDivision = departmentUnitController.GetAllDepartmentUnit(false, false).Where(u => u.DepartmentUnitTypeId == 3 && u.ParentId == int.Parse(ddlDistrict.SelectedValue)).ToList();
            if (ddlDistrict.SelectedValue != "")
            {
                ddlDS.DataSource = listDSDivision.Where(u => u.ParentId.ToString() == ddlDistrict.SelectedValue);
                ddlDS.DataTextField = "Name";
                ddlDS.DataValueField = "DepartmentUnitId";
                ddlDS.DataBind();
                ddlDS.Items.Insert(0, new ListItem("- Select -", ""));
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

        protected void addDependant(object sender, EventArgs e)
        {
            if (dependant.Count == 0 && ViewState["dependant"] != null)
            {
                dependant = (List<Dependant>)ViewState["dependant"];
            }

            if (Uploader.HasFile)
            {
                HttpFileCollection uploadFiles = Request.Files;
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile uploadFile = uploadFiles[i];
                    if (uploadFile.ContentLength > 0)
                    {
                        uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/DependantDocuments/") + uploadFile.FileName);
                        lblListOfUploadedFiles.Text += String.Format("{0}<br />", uploadFile.FileName);

                    }
                }
            }

            if (int.Parse(ddlDependant.SelectedValue) == 1)
            {
                if (Convert.ToDateTime(mDate.Text) >= DateTime.Today)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Marriage Date is not a Valid Date!', 'error');", true);
                }
                else if (Convert.ToDateTime(depDob.Text) >= DateTime.Today)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Date of Birth Can not be a Future Date!', 'error');", true);
                }
                else
                {
                    dependant.Add(new Dependant
                    {
                        DependantTypeId = int.Parse(ddlDependant.SelectedValue),
                        FirstName = dependantFname.Text,
                        LastName = dependantLname.Text,
                        DependantNIC = depNic.Text,
                        DependantPassportNo = ppNumber.Text,
                        BirthCertificateNumber = bcNumber.Text,
                        Dob = Convert.ToDateTime(depDob.Text),
                        RelationshipToEmp = dependantRelationship.Text,
                        Remarks = sickness.Text,
                        MarriageDate = Convert.ToDateTime(mDate.Text),
                        MarriageCertificateNo = mCertificateNo.Text,
                        WorkingCompany = workingCompany.Text,
                        City = city.Text,
                        DocumentUploads = Uploader.FileName
                    });
                }
            }
            else
            {
                if (Convert.ToDateTime(depDob.Text) >= DateTime.Today)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Date of Birth Can not be a Future Date!', 'error');", true);
                }
                else
                {
                    dependant.Add(new Dependant
                    {
                        DependantTypeId = int.Parse(ddlDependant.SelectedValue),
                        FirstName = dependantFname.Text,
                        LastName = dependantLname.Text,
                        DependantNIC = depNic.Text,
                        DependantPassportNo = ppNumber.Text,
                        BirthCertificateNumber = bcNumber.Text,
                        Dob = Convert.ToDateTime(depDob.Text),
                        RelationshipToEmp = dependantRelationship.Text,
                        Remarks = sickness.Text,
                        MarriageDate = DateTime.Today,
                        MarriageCertificateNo = "",
                        WorkingCompany = "",
                        City = "",
                        DocumentUploads = Uploader.FileName
                    });
                }
            }




            ViewState["dependant"] = dependant;
            dependantGV.DataSource = dependant;
            dependantGV.DataBind();

            dependantFname.Text = null;
            dependantLname.Text = null;
            depNic.Text = null;
            ppNumber.Text = null;
            bcNumber.Text = null;
            depDob.Text = null;
            dependantRelationship.Text = null;
            sickness.Text = null;
            mDate.Text = null;
            mCertificateNo.Text = null;
            workingCompany.Text = null;
            city.Text = null;
            lblListOfUploadedFiles.Text = null;
        }

        protected void RemoveDependant(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            dependant = (List<Dependant>)ViewState["dependant"];
            dependant.RemoveAt(rowIndex);

            ViewState["dependant"] = dependant;
            dependantGV.DataSource = dependant;
            dependantGV.DataBind();
        }

        protected void addEmployment(object sender, EventArgs e)
        {
            if (employmentDetails.Count == 0 && ViewState["employmentDetails"] != null)
            {
                employmentDetails = (List<EmploymentDetails>)ViewState["employmentDetails"];
            }

            if (ddContract.SelectedValue == "1")
            {
                DateTime calcuatedDate = Convert.ToDateTime(sDate.Text).AddMonths(6);

                if (reseg.SelectedValue == "1")
                {
                    employmentDetails.Add(new EmploymentDetails()
                    {
                        ContractTypeId = int.Parse(ddContract.SelectedValue),
                        DesignationId = int.Parse(ddlDesignation.SelectedValue),
                        CompanyName = companyName.Text,
                        StartDate = Convert.ToDateTime(sDate.Text),
                        EndDate = calcuatedDate,
                        IsResigned = int.Parse(reseg.SelectedValue),
                        RetirementDate = Convert.ToDateTime(retiredDate.Text),

                    });
                }
                else
                {
                    employmentDetails.Add(new EmploymentDetails()
                    {
                        ContractTypeId = int.Parse(ddContract.SelectedValue),
                        DesignationId = int.Parse(ddlDesignation.SelectedValue),
                        CompanyName = companyName.Text,
                        StartDate = Convert.ToDateTime(sDate.Text),
                        EndDate = calcuatedDate,
                        IsResigned = int.Parse(reseg.SelectedValue),
                        RetirementDate = DateTime.Today,

                    });
                }
            }
            else if (ddContract.SelectedValue == "2")
            {
                DateTime calcuatedDate = Convert.ToDateTime(sDate.Text).AddYears(1);

                if (reseg.SelectedValue == "1")
                {
                    employmentDetails.Add(new EmploymentDetails()
                    {
                        ContractTypeId = int.Parse(ddContract.SelectedValue),
                        DesignationId = int.Parse(ddlDesignation.SelectedValue),
                        CompanyName = companyName.Text,
                        StartDate = Convert.ToDateTime(sDate.Text),
                        EndDate = calcuatedDate,
                        IsResigned = int.Parse(reseg.SelectedValue),
                        RetirementDate = Convert.ToDateTime(retiredDate.Text),

                    });
                }
                else
                {
                    employmentDetails.Add(new EmploymentDetails()
                    {
                        ContractTypeId = int.Parse(ddContract.SelectedValue),
                        DesignationId = int.Parse(ddlDesignation.SelectedValue),
                        CompanyName = companyName.Text,
                        StartDate = Convert.ToDateTime(sDate.Text),
                        EndDate = calcuatedDate,
                        IsResigned = int.Parse(reseg.SelectedValue),
                        RetirementDate = DateTime.Today,

                    });
                }
            }
            else
            {
                if (Convert.ToDateTime(eDate.Text) <= Convert.ToDateTime(sDate.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'End Date is not a Valid Date!', 'error');", true);
                }
                else
                {
                    if (reseg.SelectedValue == "1")
                    {
                        employmentDetails.Add(new EmploymentDetails()
                        {
                            ContractTypeId = int.Parse(ddContract.SelectedValue),
                            DesignationId = int.Parse(ddlDesignation.SelectedValue),
                            CompanyName = companyName.Text,
                            StartDate = Convert.ToDateTime(sDate.Text),
                            EndDate = Convert.ToDateTime(eDate.Text),
                            IsResigned = int.Parse(reseg.SelectedValue),
                            RetirementDate = Convert.ToDateTime(retiredDate.Text),

                        });
                    }
                    else
                    {
                        employmentDetails.Add(new EmploymentDetails()
                        {
                            ContractTypeId = int.Parse(ddContract.SelectedValue),
                            DesignationId = int.Parse(ddlDesignation.SelectedValue),
                            CompanyName = companyName.Text,
                            StartDate = Convert.ToDateTime(sDate.Text),
                            EndDate = Convert.ToDateTime(eDate.Text),
                            IsResigned = int.Parse(reseg.SelectedValue),
                            RetirementDate = DateTime.Today,

                        });
                    }
                }
            }


            companyName.Text = null;
            sDate.Text = null;
            eDate.Text = null;
            retiredDate.Text = null;


            ViewState["employmentDetails"] = employmentDetails;
            emplDetailsGV.DataSource = employmentDetails;
            emplDetailsGV.DataBind();
        }

        protected void RemoveEmployDetails(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            employmentDetails = (List<EmploymentDetails>)ViewState["employmentDetails"];
            employmentDetails.RemoveAt(rowIndex);

            ViewState["employmentDetails"] = employmentDetails;
            emplDetailsGV.DataSource = employmentDetails;
            emplDetailsGV.DataBind();
        }

        protected void addServices(object sender, EventArgs e)
        {
            if (employeeServices.Count == 0 && ViewState["employeeServices"] != null)
            {
                employeeServices = (List<EmployeeServices>)ViewState["employeeServices"];
            }

            employeeServices.Add(new EmployeeServices()
            {
                ServicesTypeId = int.Parse(ddlService.SelectedValue),
                AppointmentDate = Convert.ToDateTime(appointmentDate.Text),
                DateAssumedDuty = dateAssumedDuty.Text,
                MethodOfRecruitment = method.Text,
                MediumOfRecruitment = medium.Text,
                ServiceConfirmed = int.Parse(confirmation.Text),
                empGrade = empServicesGrade.Text
            });

            appointmentDate.Text = null;
            dateAssumedDuty.Text = null;
            method.Text = null;
            medium.Text = null;

            ViewState["employeeServices"] = employeeServices;
            servicesGV.DataSource = employeeServices;
            servicesGV.DataBind();
        }

        protected void RemoveServices(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            employeeServices = (List<EmployeeServices>)ViewState["employeeServices"];
            employeeServices.RemoveAt(rowIndex);

            ViewState["employeeServices"] = employeeServices;
            servicesGV.DataSource = employeeServices;
            servicesGV.DataBind();
        }

        protected void submit(object sender, EventArgs e)
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            filter = departmentUnitController.GetAllDepartmentUnit(false, false);

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee emp = new Employee();

            emp.ReligionId = 0;
            emp.EthnicityId = 0;
            emp.EmployeeNIC = nic.Text;
            //emp.NicIssueDate = Convert.ToDateTime(nicIssuedDate.Text);
            //emp.EmployeePassportNumber = empPassport.Text;
            emp.EmployeePassportNumber = "";
            emp.Title = ddlMR.SelectedValue;
            emp.EmpInitials = initial.Text;
            emp.LastName = lname.Text;
            emp.NameWithInitials = nameOfInitials.Text;
            emp.EmpGender = ddlGender.SelectedValue;
            emp.DOB = Convert.ToDateTime(dob.Text);
            emp.MaritalStatus = ddlMaritalStatus.SelectedValue;
            emp.SupervisorId = 0;
            emp.ManagerId = 0;
            emp.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            //emp.EpmAbsorb = ddlAbsorb.SelectedValue;
            emp.PensionDate = Convert.ToDateTime(dob.Text).AddYears(60);
            emp.VNOPNo = int.Parse(vnop.Text);
            emp.FileNo = int.Parse(fileNo.Text);
            emp.AppointmentNo = int.Parse(appointmenLetterNo.Text);
            emp.DesignationId = int.Parse(ddlEmpDesignation.SelectedValue);
            emp.SalaryNo = txtSalaryNum.Text;
            emp.EDCompletionDate = Convert.ToDateTime(txtEDComDate.Text);

            if (ddlDS.SelectedValue != "")
            {
                emp.DSDivisionId = int.Parse(ddlDS.SelectedValue);
                foreach (var i in filter.Where(u => u.DepartmentUnitId == int.Parse(ddlDS.SelectedValue)))
                {
                    emp.UnitType = i.DepartmentUnitTypeId;
                }
            }
            else
            {
                emp.DSDivisionId = 0;
                foreach (var i in filter.Where(u => u.DepartmentUnitId == int.Parse(ddlDistrict.SelectedValue)))
                {
                    emp.UnitType = i.DepartmentUnitTypeId;
                }
            }



            emp._Dependant = (List<Dependant>)ViewState["dependant"];
            emp._EmploymentDetails = (List<EmploymentDetails>)ViewState["employmentDetails"];
            //emp._EducationDetails = (List<EducationDetails>)ViewState["educationDetails"];
            emp._EmployeeServices = (List<EmployeeServices>)ViewState["employeeServices"];

            //emp._EmergencyContact.Name = ecName.Text;
            //emp._EmergencyContact.DependentToEmployee = ecRelationship.Text;
            //emp._EmergencyContact.EmgAddress = ecAddress.Text;
            //emp._EmergencyContact.EmgTelephone = int.Parse(landLine.Text);
            //emp._EmergencyContact.EmgMobile = int.Parse(ecMobile.Text);
            //emp._EmergencyContact.OfficePhone = int.Parse(ecOfficePhone.Text);

            emp._EmployeeContact.EmpAddress = address.Text;
            emp._EmployeeContact.EmpTelephone = telephone.Text;
            emp._EmployeeContact.MobileNumber = EmpMobilePhone.Text;
            emp._EmployeeContact.EmpEmail = email.Text;
            //emp._EmployeeContact.OfficePhone = int.Parse(EmpOfficePhone.Text);
            //emp._EmployeeContact.PostalCode = int.Parse(postalCode.Text);


            int result1 = employeeController.SaveEmployee(emp);

            if (result1 == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='PersonalFiles.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //date.Text = null;
            //address.Text = null;
            //link.Text = null;
            //regNo.Text = null;
            //position.Text = null;
            //salary.Text = null;
            //NoOfVacancy.Text = null;
            //name.Text = null;
            //position.Text = null;
            //contact.Text = null;
            //whatsapp.Text = null;
            //email.Text = null;
            //position.Text = null;
        }




        protected void page1NextClick(object sender, EventArgs e)
        {
            //if (Convert.ToDateTime(nicIssuedDate.Text) >= DateTime.Today)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'NIC Issued Date can not be a Future Date!', 'error');", true);
            //}
            if (Convert.ToDateTime(dob.Text) >= DateTime.Today)
            {
                if (Convert.ToDateTime(txtEDComDate.Text) >= DateTime.Today)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'ED Completion Date is Invaid!', 'error');", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Date of Birth is Invaid!', 'error');", true);
                }
            }
            else
            {
                id1.Visible = false;
                id2.Visible = true;
                id3.Visible = false;
                //id4.Visible = false;
                //id5.Visible = false;
                //id6.Visible = false;
                id7.Visible = false;
            }
        }

        protected void page2PrevClick(object sender, EventArgs e)
        {
            id1.Visible = true;
            id2.Visible = false;
            id3.Visible = false;
            //id4.Visible = false;
            //id5.Visible = false;
            //id6.Visible = false;
            id7.Visible = false;
        }

        protected void page2NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            //id4.Visible = false;
            //id5.Visible = false;
            //id6.Visible = false;
            id7.Visible = false;
        }

        protected void page3PrevClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = true;
            id3.Visible = false;
            //id4.Visible = false;
            //id5.Visible = false;
            //id6.Visible = false;
            id7.Visible = false;
        }

        protected void page3NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            //id4.Visible = true;
            //id5.Visible = false;
            //id6.Visible = false;
            id7.Visible = true;
        }

        protected void page4PrevClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            //id4.Visible = false;
            //id5.Visible = false;
            //id6.Visible = false;
            id7.Visible = false;
        }

        //protected void page4NextClick(object sender, EventArgs e)
        //{

        //    id1.Visible = false;
        //    id2.Visible = false;
        //    id3.Visible = false;
        //    id4.Visible = false;
        //    id5.Visible = true;
        //    id6.Visible = false;
        //    id7.Visible = false;
        //}

        //protected void page5PrevClick(object sender, EventArgs e)
        //{

        //    id1.Visible = false;
        //    id2.Visible = false;
        //    id3.Visible = false;
        //    id4.Visible = true;
        //    id5.Visible = false;
        //    id6.Visible = false;
        //    id7.Visible = false;
        //}

        //protected void page5NextClick(object sender, EventArgs e)
        //{

        //    id1.Visible = false;
        //    id2.Visible = false;
        //    id3.Visible = false;
        //    id4.Visible = false;
        //    id5.Visible = false;
        //    id6.Visible = true;
        //    id7.Visible = false;
        //}

        //protected void page6PrevClick(object sender, EventArgs e)
        //{

        //    id1.Visible = false;
        //    id2.Visible = false;
        //    id3.Visible = false;
        //    id4.Visible = false;
        //    id5.Visible = true;
        //    id6.Visible = false;
        //    id7.Visible = false;
        //}

        //protected void page6NextClick(object sender, EventArgs e)
        //{

        //    id1.Visible = false;
        //    id2.Visible = false;
        //    id3.Visible = false;
        //    id4.Visible = false;
        //    id5.Visible = false;
        //    id6.Visible = false;
        //    id7.Visible = true;
        //}

        //protected void page7PrevClick(object sender, EventArgs e)
        //{

        //    id1.Visible = false;
        //    id2.Visible = false;
        //    id3.Visible = false;
        //    id4.Visible = false;
        //    id5.Visible = false;
        //    id6.Visible = true;
        //    id7.Visible = false;
        //}

        //protected void addEducation(object sender, EventArgs e)
        //{

        //    retiredDate.Text = DateTime.Today.ToString();
        //    if (educationDetails.Count == 0 && ViewState["educationDetails"] != null)
        //    {
        //        educationDetails = (List<EducationDetails>)ViewState["educationDetails"];
        //    }

        //    if (ddlEducation.SelectedValue == "4" || ddlEducation.SelectedValue == "5")
        //    {
        //        educationDetails.Add(new EducationDetails()
        //        {
        //            EducationTypeId = int.Parse(ddlEducation.SelectedValue),
        //            StudiedInstitute = uni.Text,
        //            NoOfAttempts = int.Parse(ddlAttempt.SelectedValue),
        //            ExamYear = int.Parse(ddlYear.SelectedValue),
        //            ExamIndex = index.Text,
        //            ExamSubject = sub.Text,
        //            ExamStream = stream.Text,
        //            ExamGrade = grade.Text,
        //            ExamStatus = ddlEducationStatus.SelectedValue
        //        });
        //    }
        //    else
        //    {
        //        educationDetails.Add(new EducationDetails()
        //        {
        //            EducationTypeId = int.Parse(ddlEducation.SelectedValue),
        //            StudiedInstitute = uni.Text,
        //            NoOfAttempts = 1,
        //            ExamYear = int.Parse(ddlYear.SelectedValue),
        //            ExamIndex = index.Text,
        //            ExamSubject = "",
        //            ExamStream = "",
        //            ExamGrade = "",
        //            ExamStatus = ddlEducationStatus.SelectedValue
        //        });
        //    }


        //    uni.Text = null;
        //    index.Text = null;
        //    sub.Text = null;
        //    stream.Text = null;
        //    grade.Text = null;

        //    ViewState["educationDetails"] = educationDetails;
        //    educationGV.DataSource = educationDetails;
        //    educationGV.DataBind();
        //}

        //protected void RemoveEducation(object sender, EventArgs e)
        //{
        //    GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        //    int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

        //    educationDetails = (List<EducationDetails>)ViewState["educationDetails"];
        //    educationDetails.RemoveAt(rowIndex);

        //    ViewState["educationDetails"] = educationDetails;
        //    educationGV.DataSource = educationDetails;
        //    educationGV.DataBind();
        //}

    }
}