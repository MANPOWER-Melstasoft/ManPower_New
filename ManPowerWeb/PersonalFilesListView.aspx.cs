using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
		int DGMUser = 0;

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
		List<ServiceType> serviceTypeList = new List<ServiceType>();



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


			/*EducationTypeController et = ControllerFactory.CreateEducationTypeController();
			educationTypes = et.GetAllEducationType();
			ddlEducation.DataSource = educationTypes;
			ddlEducation.DataValueField = "EducationTypeId";
			ddlEducation.DataTextField = "EducationTypeName";
			ddlEducation.DataBind();*/

			/*EducationDetailsController educationDetailsController = ControllerFactory.CreateEducationDetailsController();
			educationDetails = educationDetailsController.GetEducationDetailsByEmpId(Convert.ToInt32(EmployeeId));
			ddlEducationDetailsList.DataSource = educationDetails;
			ddlEducationDetailsList.DataValueField = "EducationDetailsId";
			ddlEducationDetailsList.DataTextField = "ExamIndex";
			ddlEducationDetailsList.DataBind();
			ddlEducationDetailsList.Items.Insert(0, new ListItem("- Select -", ""));*/

			EducationDetailsController educationDetailsController = ControllerFactory.CreateEducationDetailsController();
			educationDetails = educationDetailsController.GetEducationDetailsByEmpId(Convert.ToInt32(EmployeeId));
			ddlEducationDetailsList.DataSource = educationDetails;
			ddlEducationDetailsList.DataValueField = "EducationTypeId";
			ddlEducationDetailsList.DataTextField = "EducationType";
			ddlEducationDetailsList.DataBind();
			ddlEducationDetailsList.Items.Insert(0, new ListItem("- Select -", ""));

			ServiceTypeController stc = ControllerFactory.CreateServiceTypeController();
			serviceTypeList = stc.GetAllServiceType();
			ddlService.DataSource = serviceTypeList;
			ddlService.DataValueField = "ServiceTypeId";
			ddlService.DataTextField = "ServiceTypeName";
			ddlService.DataBind();
		}

		private void BindEmpData()
		{
			EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
			Employee employee = employeeController.GetEmployeeById(Convert.ToInt32(EmployeeId));

			ddlMR.SelectedValue = employee.Title;
			ddlGender.SelectedValue = employee.EmpGender;
			ddlMaritalStatus.SelectedValue = employee.MaritalStatus;
			fileNo.Text = employee.FileNo;
			nameOfInitials.Text = employee.NameWithInitials;
			initial.Text = employee.EmpInitials;
			lname.Text = employee.LastName;
			dob.Text = employee.DOB.ToString("yyyy-MM-dd");
			nic.Text = employee.EmployeeNIC;
			ddlEmpDesignation.SelectedValue = employee.DesignationId.ToString();
			ddlDistrict.SelectedValue = employee.DistrictId.ToString();
			//txtEDComDate.Text = employee.EDCompletionDate.ToString("yyyy-MM-dd");
			txtSalaryNum.Text = employee.SalaryNo;
			vnop.Text = employee.VNOPNo;
			appointmenLetterNo.Text = employee.AppointmentNo;
			empPassport.Text = employee.EmployeePassportNumber;

			if (employee.NicIssueDate.ToString("yyyy-MM-dd") != "0001-01-01")
			{
				nicIssuedDate.Text = employee.NicIssueDate.ToString("yyyy-MM-dd");
			}

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
				foreach (var i in edu.Where(u => u.EducationTypeId == int.Parse(ddlEducationDetailsList.SelectedValue)))
				{
					ddlEducationDetailsList.SelectedValue = i.EducationTypeId.ToString();
					uni.Text = i.StudiedInstitute;
					index.Text = i.ExamIndex;
					year.Text = i.ExamYear.ToString();
					attempt.Text = i.NoOfAttempts.ToString();
					sub.Text = i.ExamSubject;
					stream.Text = i.ExamStream;
					grade.Text = i.ExamGrade;
					status.Text = i.ExamStatus;
					//lblfileUpload.Text = i.Attachment;
					if (!string.IsNullOrEmpty(i.Attachment))
					{
						string filePath = "/SystemDocuments/EducationResources/" + i.Attachment;
						lblfileUpload.Text = "<a href='" + filePath + "' download>Download Document</a>";
					}

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
			employee.FileNo = fileNo.Text;
			employee.NameWithInitials = nameOfInitials.Text;
			employee.EmpInitials = initial.Text;
			employee.LastName = lname.Text;
			employee.DOB = Convert.ToDateTime(dob.Text);
			employee.EmployeeNIC = nic.Text;
			employee.DesignationId = int.Parse(ddlEmpDesignation.SelectedValue);
			employee.DistrictId = int.Parse(ddlDistrict.SelectedValue);
			employee.EmployeePassportNumber = empPassport.Text;
			employee.SalaryNo = txtSalaryNum.Text;
			employee.VNOPNo = vnop.Text;
			employee.AppointmentNo = appointmenLetterNo.Text;
			employee.PensionDate = Convert.ToDateTime(dob.Text).AddYears(60);

			if (nicIssuedDate.Text != "")
			{
				employee.NicIssueDate = Convert.ToDateTime(nicIssuedDate.Text);
			}

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


			int depChangeFlag = 0;
			int depChangeSuccessFlag = 0;
			int depId;
			if (employee.DSDivisionId == 0)
			{
				depId = employee.DistrictId;
			}
			else
			{
				depId = employee.DSDivisionId;
			}

			//-------------get system user ID --------------------------
			DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
			SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
			SystemUser systemUser = systemUserController.CheckEmpNumberExists(employee.EmployeeId);

            if (systemUser.SystemUserId != 0)
            {
                //--------------check if department has changed ---------------------------------
                Employee employeeOld = employeeController.GetEmployeeById(employee.EmployeeId);
                DepartmentUnitPositions departmentUnitPositions = departmentUnitPositionsController.GetAllDepartmentUnitPositionsBySystemUserId(systemUser.SystemUserId, false);


				if (employeeOld.UnitType != employee.UnitType || employeeOld.DistrictId != employee.DistrictId || employeeOld.DSDivisionId != employee.DSDivisionId)
				{
					depChangeFlag = 1;
					if (CheckDistricSD(systemUser.UserTypeId, employee.UnitType) && CheckExistsRegUSer(systemUser.UserTypeId, depId))
					{
						int parentId = GetParentId(systemUser.UserTypeId, depId);
						if (parentId != 0 || DGMUser == 1)
						{
							departmentUnitPositions.ParentId = parentId;
							departmentUnitPositions.DepartmentUnitId = depId;

							depChangeSuccessFlag = departmentUnitPositionsController.UpdateDepartmentUnitPositions(departmentUnitPositions);
						}
					}
				}
			}

			if ((depChangeFlag == 0) || (depChangeSuccessFlag == 1 && depChangeSuccessFlag == 1))
			{
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

		private bool CheckDistricSD(int userType, int DeptypeId)
		{
			int userTypeId = userType;
			int depType = DeptypeId;

			if (userTypeId == 6 || userTypeId == 7)
			{
				if (depType == 3)
				{
					return true;
				}
				else
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'This User Can Only Assign to DS Division!', 'error');", true);
					return false;
				}
			}
			else if (userTypeId == 8 || userTypeId == 9)
			{
				if (depType == 2)
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
				if (depType == 1)
				//if (userTypeId == 1 || userTypeId == 2 || userTypeId == 3 || userTypeId == 4 || userTypeId == 5 ||
				//userTypeId == 10 || userTypeId == 11 || userTypeId == 12 || userTypeId == 13 || userTypeId == 14)
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

		private bool CheckExistsRegUSer(int userTypeId, int dep)
		{
			DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
			List<DepartmentUnitPositions> departmentUnitPositionsList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

			int flag;
			int depId = dep;
			int userType = userTypeId;

			//---------------- For Division Head --------------------
			if (userType == 6)
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
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'This Division Already Has Division Head Account!', 'error');", true);
					return false;
				}
				else
				{
					return true;
				}
			}

			//---------------- For District Head --------------------
			if (userType == 8)
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
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'This District Already Has District Head Account!', 'error');", true);
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

		private int GetParentId(int userTypeId, int dep)
		{
			int parentId = 0;
			int DGMparentId = 0;
			int userType = userTypeId;
			int depId = dep;

			DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
			List<DepartmentUnitPositions> departmentUnitPositionsList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

			//---------------- For DGM ---------------------
			if (userType == 5)
			{
				DGMUser = 1;
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
					return 0;
				}
			}
		}


	}
}