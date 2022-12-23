using Antlr.Runtime;
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string[] conformation = { "Yes", "No" };
        string[] isResigned = { "Yes", "No" };
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();

                id1.Visible = true;
                id2.Visible = false;
                id3.Visible = false;
                id4.Visible = false;
                id5.Visible = false;
                id6.Visible = false;
                id7.Visible = false;
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
            designation = d.GetAllDesignation(false, false);

            ServiceTypeController stc = ControllerFactory.CreateServiceTypeController();
            serviceTypeList = stc.GetAllServiceType();

            ddlGender.DataSource = gen;
            ddlGender.DataBind();

            ddlEthnicity.DataSource = ethnicityList;
            ddlEthnicity.DataValueField = "EthnicityId";
            ddlEthnicity.DataTextField = "EthnicityName";
            ddlEthnicity.DataBind();

            ddlReligion.DataSource = religionList;
            ddlReligion.DataValueField = "ReligionId";
            ddlReligion.DataTextField = "ReligionName";
            ddlReligion.DataBind();

            ddlDependant.DataSource = dependantTypes;
            ddlDependant.DataValueField = "DependantTypeId";
            ddlDependant.DataTextField = "DependantTypeName";
            ddlDependant.DataBind();

            ddlMaritalStatus.DataSource = mmStatus;
            ddlMaritalStatus.DataBind();

            ddlEducation.DataSource = educationTypes;
            ddlEducation.DataValueField = "EducationTypeId";
            ddlEducation.DataTextField = "EducationTypeName";
            ddlEducation.DataBind();

            ddlService.DataSource = serviceTypeList;
            ddlService.DataValueField = "ServiceTypeId";
            ddlService.DataTextField = "ServiceTypeName";
            ddlService.DataBind();

            ddContract.DataSource = contractTypes;
            ddContract.DataValueField = "ContractTypeId";
            ddContract.DataTextField = "ContractTypeName";
            ddContract.DataBind();

            ddlDesignation.DataSource = designation;
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataTextField = "DesigntionName";
            ddlDesignation.DataBind();

            ddlAttempt.DataSource = attempt;
            ddlAttempt.DataBind();

            ddlYear.DataSource = yearslist;
            ddlYear.DataBind();

        }

        protected void addDependant(object sender, EventArgs e)
        {
            if (dependant.Count == 0 && ViewState["dependant"] != null)
            {
                dependant = (List<Dependant>)ViewState["dependant"];
            }

            if (int.Parse(ddlDependant.SelectedValue) == 1)
            {
                dependant.Add(new Dependant
                {
                    DependantTypeId = int.Parse(ddlDependant.SelectedValue),
                    FirstName = dependantFname.Text,
                    LastName = dependantLname.Text,
                    DependantNIC = depNic.Text,
                    DependantPassportNo = ppNumber.Text,
                    BirthCertificateNumber = int.Parse(bcNumber.Text),
                    Dob = Convert.ToDateTime(depDob.Text),
                    RelationshipToEmp = dependantRelationship.Text,
                    Remarks = sickness.Text,
                    MarriageDate = Convert.ToDateTime(mDate.Text),
                    MarriageCertificateNo = int.Parse(mCertificateNo.Text),
                    WorkingCompany = workingCompany.Text,
                    City = city.Text
                });
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
                    BirthCertificateNumber = int.Parse(bcNumber.Text),
                    Dob = Convert.ToDateTime(depDob.Text),
                    RelationshipToEmp = dependantRelationship.Text,
                    Remarks = sickness.Text,
                    MarriageDate = DateTime.Today,
                    MarriageCertificateNo = 0,
                    WorkingCompany = "",
                    City = ""
                });
            }

            ViewState["dependant"] = dependant;

            //dependant = (List<Dependant>)ViewState["dependant"];
            dependantGV.DataSource = dependant;
            dependantGV.DataBind();

            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);


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
             
        }

        protected void addEmployment(object sender, EventArgs e)
        {
            if (employmentDetails.Count == 0 && ViewState["employmentDetails"] != null)
            {
                employmentDetails = (List<EmploymentDetails>)ViewState["employmentDetails"];
            }

            employmentDetails.Add(new EmploymentDetails()
            {
                ContractTypeId = int.Parse(ddContract.SelectedValue),
                DesignationId = int.Parse(ddlDesignation.SelectedValue),
                CompanyName = companyName.Text,
                EmpNumber = empNo.Text,
                StartDate = Convert.ToDateTime(sDate.Text),
                EndDate = Convert.ToDateTime(eDate.Text),
                IsResigned = int.Parse(reseg.SelectedValue),
                RetirementDate = Convert.ToDateTime(retiredDate.Text),
                Epf = int.Parse(epf.Text)
            }) ;

            companyName.Text = null;
            empNo.Text = null;
            sDate.Text = null;
            eDate.Text = null;
            retiredDate.Text = null;
            epf.Text = null;


            ViewState["employmentDetails"] = employmentDetails;
            emplDetailsGV.DataSource = employmentDetails;
            emplDetailsGV.DataBind();
        }


        protected void addEducation(object sender, EventArgs e)
        {
            if (educationDetails.Count == 0 && ViewState["educationDetails"] != null)
            {
                educationDetails = (List<EducationDetails>)ViewState["educationDetails"];
            }

            educationDetails.Add(new EducationDetails()
            {
                EducationTypeId = int.Parse(ddlEducation.SelectedValue),
                StudiedInstitute = uni.Text,
                NoOfAttempts = int.Parse (ddlAttempt.SelectedValue),
                ExamYear = int.Parse(ddlYear.SelectedValue),
                ExamIndex = index.Text,
                ExamSubject = sub.Text,
                ExamStream = stream.Text,
                ExamGrade = grade.Text,
                ExamStatus = status.Text
            });


            uni.Text = null;
            index.Text = null;
            sub.Text = null;
            stream.Text = null;
            grade.Text = null;
            status.Text = null;
            
            ViewState["educationDetails"] = educationDetails;
            educationGV.DataSource = educationDetails;
            educationGV.DataBind();
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
                ServiceConfirmed = int.Parse(confirmation.Text)
            });

            appointmentDate.Text = null;
            dateAssumedDuty.Text = null;
            method.Text = null;
            medium.Text = null;

            ViewState["employeeServices"] = employeeServices;
            servicesGV.DataSource = employeeServices;
            servicesGV.DataBind();
        }

        protected void submit(object sender, EventArgs e)
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee emp = new Employee();

            emp.ReligionId = int.Parse(ddlReligion.SelectedValue);
            emp.EthnicityId = int.Parse(ddlEthnicity.SelectedValue);
            emp.EmployeeNIC = nic.Text;
            emp.NicIssueDate = Convert.ToDateTime(nicIssuedDate.Text);
            emp.EmployeePassportNumber = empPassport.Text;
            emp.EmpInitials = initial.Text;
            emp.LastName = lname.Text;
            emp.NameWithInitials = nameOfInitials.Text;
            emp.EmpGender = ddlGender.SelectedValue;
            emp.DOB = Convert.ToDateTime(dob.Text);
            emp.MaritalStatus = ddlMaritalStatus.SelectedValue;
            emp.SupervisorId = 0;
            emp.ManagerId = 0;

            emp._Dependant = (List<Dependant>)ViewState["dependant"];
            emp._EmploymentDetails = (List<EmploymentDetails>)ViewState["employmentDetails"]; ;
            emp._EducationDetails = (List<EducationDetails>)ViewState["educationDetails"];
            emp._EmployeeServices = (List<EmployeeServices>)ViewState["employeeServices"];

            emp._EmergencyContact.Name = ecName.Text;
            emp._EmergencyContact.DependentToEmployee = ecRelationship.Text;
            emp._EmergencyContact.EmgAddress = ecAddress.Text;
            emp._EmergencyContact.EmgTelephone = int.Parse(landLine.Text);
            emp._EmergencyContact.EmgMobile = int.Parse(ecMobile.Text);
            emp._EmergencyContact.OfficePhone = int.Parse(ecOfficePhone.Text);

            int result1 = employeeController.SaveEmployee(emp);

            if (result1 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);

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
            id1.Visible = false;
            id2.Visible = true;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page2PrevClick(object sender, EventArgs e)
        {
            id1.Visible = true;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page2NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page3PrevClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = true;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page3NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = true;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page4PrevClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page4NextClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = true;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page5PrevClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = true;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page5NextClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = true;
            id7.Visible = false;
        }

        protected void page6PrevClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = true;
            id6.Visible = false;
            id7.Visible = false;
        }

        protected void page6NextClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = false;
            id7.Visible = true;
        }

        protected void page7PrevClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id4.Visible = false;
            id5.Visible = false;
            id6.Visible = true;
            id7.Visible = false;
        }

    }
}