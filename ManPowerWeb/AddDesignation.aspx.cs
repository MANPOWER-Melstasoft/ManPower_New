using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AddDesignation : System.Web.UI.Page
    {
        static List<Designation> designationList = new List<Designation>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            DesignationController designationController = ControllerFactory.CreateDesignationController();
            designationList = designationController.GetAllDesignation(true, false, false);
            gvPosition.DataSource = designationList;
            gvPosition.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int output;
            DesignationController designationController = ControllerFactory.CreateDesignationController();

            Designation designation = new Designation();
            designation.DesigntionName = txtName.Text;

            if (btnSubmit.Text == "Update")
            {
                designation.DesignationId = Convert.ToInt32(ViewState["desId"]);
                designation.IsActive = 1;
                output = designationController.UpdateDesignation(designation);

                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Designation Updated Succesfully!', 'success')", true);
                    btnSubmit.Text = "Create";
                    Clear();
                    BindDataSource();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Designation Updated Fail!', 'error');", true);
                }
            }
            else
            {
                designation.IsActive = 1;
                output = designationController.SaveDesignation(designation);
                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Designation Created Succesfully!', 'success')", true);
                    btnSubmit.Text = "Create";
                    Clear();
                    BindDataSource();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Designation Created Fail!', 'error');", true);
                }
                //lblSuccessMsg.Text = "Record Updated Successfully!";
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvPosition.PageSize;
            int pageindex = gvPosition.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            Designation designation = designationList[rowIndex];
            txtName.Text = designation.DesigntionName;

            btnSubmit.Text = "Update";
            ViewState["desId"] = designation.DesignationId;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvPosition.PageSize;
            int pageindex = gvPosition.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            Designation possitions = designationList[rowIndex];
            int output;
            DesignationController designationController = ControllerFactory.CreateDesignationController();

            possitions.IsActive = 0;
            output = designationController.UpdateDesignation(possitions);

            if (output == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Program Deleted Succesfully!', 'success')", true);
                BindDataSource();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Program Deleted Fail!', 'error');", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnSubmit.Text = "Create";
            Clear();
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPosition.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}