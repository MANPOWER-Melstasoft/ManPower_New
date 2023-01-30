using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class PersonalFilesView : System.Web.UI.Page
    {
        Employee emp = new Employee();
        List<Ethnicity> ethnicities = new List<Ethnicity>();
        List<Religion> religions = new List<Religion>();
        List<DepartmentUnit> departmentUnits = new List<DepartmentUnit>();

        public static string EmployeeId;

        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                BindSources();

                id1.Visible = true;
                id2.Visible = false;
                id3.Visible = false;
                //id4.Visible = false;
                //id5.Visible = false;
                //id6.Visible = false;
                id7.Visible = false;
            }

        }

        protected void BindSources()
        {
            EmployeeId = Request.QueryString["id"];

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            emp = employeeController.GetEmployeeById(int.Parse(EmployeeId));

            EthnicityController ethnicityController = ControllerFactory.CreateEthnicityController();
            ethnicities = ethnicityController.GetAllEthnicity();

            ReligionController religionController = ControllerFactory.CreateReligionController();
            religions = religionController.GetAllReligion();

            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            departmentUnits = departmentUnitController.GetAllDepartmentUnit(false, false);

            idNo.Text = "ID : " + EmployeeId;

            lname.Text = emp.LastName;
            initial.Text = emp.EmpInitials;
            nameOfInitials.Text = emp.NameWithInitials;
            gen.Text = emp.EmpGender;
            dob.Text = emp.DOB.ToString();
            maritalStatus.Text = emp.MaritalStatus;
            nic.Text = emp.EmployeeNIC;
            nicIssuedDate.Text = emp.NicIssueDate.ToString();
            empPassport.Text = emp.EmployeePassportNumber;
            absorb.Text = emp.EpmAbsorb;

            foreach (var i in departmentUnits.Where(u => u.DepartmentUnitId == emp.DistrictId))
            {
                district.Text = i.Name;
            }

            foreach (var i in departmentUnits.Where(u => u.DepartmentUnitId == emp.DSDivisionId))
            {
                dsDivision.Text = i.Name;
            }

            foreach (var i in ethnicities.Where(u => u.EthnicityId == emp.EthnicityId))
            {
                ethnicity.Text = i.EthnicityName;
            }

            foreach (var i in religions.Where(u => u.ReligionId == emp.ReligionId))
            {
                religion.Text = i.ReligionName;
            }

        }

        protected void page1NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = true;
            id3.Visible = false;
            id7.Visible = false;
        }

        protected void page2PrevClick(object sender, EventArgs e)
        {
            id1.Visible = true;
            id2.Visible = false;
            id3.Visible = false;
            id7.Visible = false;
        }

        protected void page2NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            id7.Visible = false;
        }

        protected void page3PrevClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = true;
            id3.Visible = false;
            id7.Visible = false;
        }

        protected void page3NextClick(object sender, EventArgs e)
        {
            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = false;
            id7.Visible = true;
        }

        protected void page4PrevClick(object sender, EventArgs e)
        {

            id1.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            id7.Visible = false;
        }
    }
}