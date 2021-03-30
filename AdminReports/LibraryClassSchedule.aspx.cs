using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Collections;

public partial class Page_LibraryClassSchedule : System.Web.UI.Page
{
    private string SearchString = "";
    DataTable DtbStudent = new DataTable();
    DBHandler DBH = new DBHandler();
    CBHandler CBH = new CBHandler();
    DataTable DtbStudID = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropdownList();
            RdbStudentClassSection.Checked = true;
            if (RdbStudentClassSection.Checked == true)
            {
                lblStudID.Visible = true;
                txtStud_ID.Visible = true;
                btnSearchStudent.Visible = true;
                BtnDownload.Visible = false;
            }
            else
            {
                lblStudID.Visible = false;
                txtStud_ID.Visible = false;
                btnSearchStudent.Visible = false;
                GrdEnrollmentDetails.Visible = false;
                BtnDownload.Visible = true ;
            }
        }
    }

    protected void BindDropdownList()
    {
        try
        {
            Processing P = new Processing();
            DrpSemester.DataSource = P.BindSem();
            DrpSemester.DataValueField = "Semester_RefID";
            DrpSemester.DataTextField = "Semester_Desc";
            DrpSemester.DataBind();           

            PopulateBatchCode();
           
            populateBatchSession();
        }
        catch (Exception ex)
        {
        }
    }


    protected void DrpSemesterPopUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateBatchGrid();
        ME2.Show();
    }


    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        PopulateSemester();
        PopulateBatchGrid();
        ME2.Show();
    }

    protected void BtnBatchDetailsSearch_Click(object sender, EventArgs e)
    {
        PopulateBatchGrid();
        ME2.Show();
    }

  

    protected void gridStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string BatchCode = Convert.ToString(e.CommandArgument);
        if (e.CommandName == "Select")
        {
          //  DrpBatchCode.SelectedValue = e.CommandArgument.ToString();

        }
    }

    protected void ImgBatchClose_click(object sender, ImageClickEventArgs e)
    {
        ME2.Hide();
    }


    protected void LoadReport_Click(object sender, EventArgs e)
    {

        if (RdbStudentClassSection.Checked)
        {
            Response.Redirect("EnrollmentReport_Viewer.aspx?ID=" + Convert.ToInt32(DrpSemester.SelectedValue) + "&Option=4&StudID=" + txtStud_ID.Text.Trim());
        }
        else
        {
            GrdEnrollmentDetails.Visible = true;
            BindGrid();
        }
        
       
    }

    private void BindGrid()
    {
        DataTable DtbBatch = new DataTable();
        ArrayList pa = new ArrayList();
        ArrayList pv = new ArrayList();
        pa.Add("@semesterid");
        pv.Add(DrpSemester.SelectedValue);
        DBH.AdminCreateDataTable(DtbBatch, "SP_EnrollemtDeatils", true, pa, pv);
        GrdEnrollmentDetails.DataSource = DtbBatch;
        GrdEnrollmentDetails.DataBind();
    }

    protected void PopulateBatchGrid()
    {
        DataTable DtbBatch = new DataTable();
        StringBuilder Condition = new StringBuilder();

        Condition.Append(" Where B.Semester_ID =" + CBH.ItemValue(DrpSemesterPopUp));

        //if (chkBatchCode.Checked == true && txtBatchCodeSearch.Text != "")
        //    Condition.Append(" AND B.BatchCode like '%" + txtBatchCodeSearch.Text.Trim() + "%'");
        //if (ChkCddCode.Checked == true && TxtCddCode.Text != "")
        //    Condition.Append(" AND C.CDD_Code like '%" + TxtCddCode.Text.Trim() + "%'");
        //if (ChkCddDescription.Checked == true && txtCdd_Description.Text != "")
        //    Condition.Append(" AND C.CDD_Description like '%" + txtCdd_Description.Text.Trim() + "%'");

        ArrayList pa = new ArrayList();
        ArrayList pv = new ArrayList();
        pa.Add("@BatchCode");
        pv.Add("");
        pa.Add("@Operation");
        pv.Add("BindBatch");
        pa.Add("@Condition");
        pv.Add(Condition.ToString());
        DBH.AdminCreateDataTable(DtbBatch, "SP_GetBatchDetails", true, pa, pv);

        //if (DtbBatch.Rows.Count != 0)
        //{
        GrvBatch.DataSource = DtbBatch;
        GrvBatch.DataBind();
        ME2.Show();
        //}
    }


    protected void PopulateSemester()
    {
        try
        {
            Processing obj = new Processing();
            DrpSemesterPopUp.DataSource = obj.BindSem();
            DrpSemesterPopUp.DataValueField = "Semester_RefID";
            DrpSemesterPopUp.DataTextField = "Semester_Desc";
            DrpSemesterPopUp.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void RdbStudentClassSection_CheckedChanged(object sender, EventArgs e)
    {
       
        lblStudID.Visible = true;
        txtStud_ID.Visible = true;
        btnSearchStudent.Visible = true;
        GrdEnrollmentDetails.Visible = false;
        BtnDownload.Visible = false;

    }

    protected void RdbStudentClash_CheckedChanged(object sender, EventArgs e)
    {        
        lblStudID.Visible = false;
        txtStud_ID.Visible = false;
        btnSearchStudent.Visible = false;
        BtnDownload.Visible = true ;

    }

    protected void DrpSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateBatchCode();
        populateBatchSession();
    }

    protected void PopulateBatchCode()
    {
        Processing P = new Processing();
        //DrpBatchCode.DataSource = P.BindBatchCode(Convert.ToInt32(DrpSemester.SelectedValue));
        //DrpBatchCode.DataTextField = "BatchCode";
        //DrpBatchCode.DataValueField = "Batch_ID";
        //DrpBatchCode.DataBind();
        //DrpBatchCode.Items.Insert(0, "Select Batch");
    }

    protected void populateBatchSession()
    {
        Processing P = new Processing();
        //DrpSession.DataSource = P.BindBatchSession(Convert.ToInt32(DrpSemester.SelectedValue));
        //DrpSession.DataTextField = "Session_Time";
        //DrpSession.DataValueField = "Session_ID";
        //DrpSession.DataBind();
        //DrpSession.Items.Insert(0, "All");
    }

    protected void BtnLoadReport_Click(object sender, EventArgs e)
    {
        //if (rdbConditional.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=1");
        //}
        //else if (RdbUndrtaking.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=2");
        //}
        //else if (RdbToc.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=3");
        //}
        //else if (RdbEnglish.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=4");
        //}
        //else if (RdbMath.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=5");
        //}
        //else if (RdbMathAwaiting.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=6");
        //}
        //else if (RdbMathYetToapper.Checked)
        //{
        //    Response.Redirect("AdminReports_Viewer.aspx?ID=" + Convert.ToInt32(DrpTerm.SelectedValue) + "&Option=7");

    }

    protected void btnSearchStudent_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ME1.Show();
        }
        catch (Exception Ex)
        {

        }
    }
     protected void btnClose_click(object sender, ImageClickEventArgs e)
    {
        ME1.Hide();
    }

    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
        RegExp.Replace("/", "");
        // Highlight keywords by calling the 
        //delegate each time a keyword is found.
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetails.PageIndex = e.NewPageIndex;
        gvDetails.DataBind();
        ME1.Show();

    }
    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //  Set the value of the SearchString so it gets
        SearchString = txtSearch.Text;
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        txtSearch.Text = "";
        SearchString = "";
        gvDetails.DataBind();
    }

    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                string[] value = Id.Split('#');
                txtStud_ID.Text = value[1];
               
            }
        }
        catch
        {
        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;
        ME1.Show();

    }
    protected void chkall_checkedchanged(object sender, EventArgs e)
    {
        if (chkall.Checked == false)
            Session["EMPID1"] = Session["EMPID"].ToString();
        else
            Session["EMPID1"] = "0";

        //dsDetails.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();
        dsDetails.Update();
        ME1.Show();

    }
    protected void BtnSearchStudent_Click(object sender, EventArgs e)
    {
        ME1.Show();
    }
    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (ChkStudID.Checked == true)
            //{
            //    e.Row.Cells[0].Visible = true;
            //    e.Row.Cells[1].Visible = false;
            //}
            //else if (chkRegisterID.Checked == true)
            //{
            //    e.Row.Cells[1].Visible = true;
            //    e.Row.Cells[0].Visible = false;
            //}
        }

    }
    protected void BtnDownload_Click(object sender, EventArgs e)
    {
        if (RdbStudentClash.Checked == true)
        {
            BindGrid();
            try
            {
                string result = ExcelUtility.ToExcel(GrdEnrollmentDetails.DataSource);
                ExcelUtility.ExportToExcel(result);
            }
            catch
            {
                // lbl_ack.Visible = true;
                // lbl_ack.Text = "Please check Excel configuration !!!";
            }

        }
        else
        {
            
        }
    }
}