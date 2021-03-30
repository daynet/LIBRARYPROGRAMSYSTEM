using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections;
using System.Data.OleDb;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;


public partial class Page_Student_PortalBlocking : System.Web.UI.Page
{
    private string SearchString = "";
    DBHandler DBH = new DBHandler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
            {
                var appUrl = VirtualPathUtility.ToAbsolute("~/");
                string path = HttpContext.Current.Request.Url.AbsolutePath.Remove(0, appUrl.Length - 1);

                //if (CommonFunctions.CheckUserAuthentication(Convert.ToInt32(Session["UserId"]), path))
                //{
                    txtStudID.Text = "";

                    if (Convert.ToString(Session["Role"]) == "Admin" || Convert.ToString(Session["Role"]) == "AdminDept")
                    {
                        ChkAdm.Enabled = true;
                        ChkFin.Enabled = true;
                        ChkLib.Enabled = true;
                        ChkHrd.Enabled = true;
                        ChkSSD.Enabled = true;
                    }
                    else if (Convert.ToString(Session["Role"]) == "Finance")
                    {
                        ChkFin.Enabled = true;
                        ChkAdm.Enabled = false;
                        ChkLib.Enabled = false;
                        ChkHrd.Enabled = false;
                        ChkSSD.Enabled = false;

                    }
                    else if (Convert.ToString(Session["Role"]) == "Lib")
                    {
                        ChkLib.Enabled = true;
                        ChkFin.Enabled = false;
                        ChkAdm.Enabled = false;
                        ChkHrd.Enabled = false;
                        ChkSSD.Enabled = false;

                    }
                    else if (Convert.ToString(Session["Role"]) == "HRD")
                    {
                        ChkHrd.Enabled = true;
                        ChkLib.Enabled = false;
                        ChkFin.Enabled = false;
                        ChkAdm.Enabled = false;
                        
                        ChkSSD.Enabled = false;

                    }
                    else if (Convert.ToString(Session["Role"]) == "SSD")
                    {
                        ChkHrd.Enabled = false;
                        ChkLib.Enabled = false;
                        ChkFin.Enabled = false;
                        ChkAdm.Enabled = false;
                        ChkSSD.Enabled = true;

                    }

                //}
                //else
                //{
                //    Response.Redirect("../Security/Login.aspx", false);
                //    //HTMLHelper.jsAlertAndRedirect(this, "Access Denied", "../Security/Login.aspx?msgshowing=true");
                //}
            }
            else
            {
                Response.Redirect("../Security/Login.aspx", false);
            }
        }

    }

  
    protected void LoadData(string Stud_ID)
    {
        Processing P = new Processing();
        DataTable Dtb = P.BindStudentPortalDetails("LoadData", Stud_ID);
        if (Dtb.Rows.Count != 0)
        {
            txtLogin.Text = Dtb.Rows[0]["Login_ID"].ToString();
            ChkFin.Checked = Convert.ToBoolean(Dtb.Rows[0]["BlockFinance"]);
            ChkLib.Checked = Convert.ToBoolean(Dtb.Rows[0]["LibBlock"]);
            ChkAdm.Checked = Convert.ToBoolean(Dtb.Rows[0]["AdminBlock"]);
            ChkSSD.Checked = Convert.ToBoolean(Dtb.Rows[0]["SSDBlock"]);
            ChkHrd.Checked = Convert.ToBoolean(Dtb.Rows[0]["HrdBlock"]);
            txtname.Text = Dtb.Rows[0]["Student_name"].ToString();
        }
         
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ChkIsBulkBlock.Checked == false)
        {
            if (txtRemarks.Text == "")
            {
                lblMessage.Text = "Please Enter the Remarks.";
                return;
            }
            else
            {
                UpdateSingleStudentBlocking();
            }
        }
        else
        {

           

            if ((ChkFin.Checked == false) && (ChkLib.Checked == false) && (ChkAdm.Checked == false) && (ChkSSD.Checked == false) && (ChkHrd.Checked == false))
            {
                lblMessage.Text = "Please seleck Check box for updating.";
                return;
            }
            SaveBulckBlocking();
        }
    }
    protected void UpdateSingleStudentBlocking()
    {
        try
        {
            Processing P = new Processing();
            DataTable Dtb = P.UPdatePortalBlockDetails(txtLogin.Text.Trim(), txtStudID.Text.Trim(), ChkFin.Checked, ChkLib.Checked, ChkAdm.Checked,
                ChkSSD.Checked, ChkHrd.Checked, Convert.ToInt32(Session["UserId"]),txtRemarks.Text.Trim());
            if (Convert.ToInt32(Dtb.Rows[0][0].ToString()) == 1)
            {
                lblMessage.Text = "Updated Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMessage.Text = Dtb.Rows[0][1].ToString();
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = "Error";
            lblMessage.ForeColor = System.Drawing.Color.Red;
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
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                txtStudID.Text = e.CommandArgument.ToString();
                //Label lblName = (Label)row.FindControl("lblName");
                //txtname.Text = lblName.Text;
                LoadData(txtStudID.Text.Trim());
                GetBlockedReason(txtStudID.Text.Trim());
               
            }

        }
        catch (Exception ex)
        {
            throw ex;
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
    protected void btnSearchStudent_Click(object sender, EventArgs e)
    {
        ME1.Show();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetails.PageIndex = e.NewPageIndex;
        gvDetails.DataBind();
        ME1.Show();

    }
    protected void txtStudID_TextChanged(object sender, EventArgs e)
    {
        LoadData(txtStudID.Text.Trim());
    }

    protected void BtnLoad_Click(object sender, EventArgs e)
    {
        ImportFromExcelNew();
    }
    protected void ChkIsBulkBlock_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkIsBulkBlock.Checked == true)
        {
            PnlBulkBlockDetails.Visible = true;
            PnlInstructions.Visible = true;
        }
        else
        {
            PnlBulkBlockDetails.Visible = false;
            PnlInstructions.Visible = false;
            PnlStudentDetails.Visible = false;
            PnlNotUploadedStudents.Visible = false;
        }
    }
    protected void ImportFromExcelNew()
    {
        try
        {
            lblMessage.Text = "";
            if ((flStudentList.HasFile))
            {
                if (!Convert.IsDBNull(flStudentList.PostedFile) & flStudentList.PostedFile.ContentLength > 0)
                {

                    string saveFolder = @"C:\temp\ExcelUpload";

                    
                    string filePath = Path.Combine(saveFolder, flStudentList.FileName);
                    flStudentList.SaveAs(filePath);



                    DBH.GetResult("exec ExcelExportStudent_Details " + "BulkBlocking");
                    string sCon = ConfigurationManager.ConnectionStrings["AdminExam"].ConnectionString;
                    String ExcelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
                    using (OleDbConnection ExcelConnection = new OleDbConnection(ExcelConnString))
                    {
                        //Create OleDbCommand to fetch data from Excel 
                        using (OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", ExcelConnection))
                        {
                            ExcelConnection.Open();
                            using (OleDbDataReader dReader = cmd.ExecuteReader())
                            {
                                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(sCon))
                                {
                                    //Give your Destination table name 
                                    sqlBulk.DestinationTableName = "tb_tempStudentImport_BulkBlocking";
                                    sqlBulk.WriteToServer(dReader);
                                }
                            }
                            ExcelConnection.Close();

                        }
                    }
                    BindExportedStudentDetails();
                    BindExportedStudentNotUploaded();
                }
            }
            else
            {
                lblMessage.Text = "Please upload file";
            }

        }
        catch (Exception ex)
        {

            lblMessage.Text = ex.Message;
            lblMessage.Attributes.Add("style", "color:red");

        }

    }
    protected void BindExportedStudentDetails()
    {
        PnlStudentDetails.Visible = true;
        GrvExportExcelDetails.Visible = true;
        Processing P = new Processing();
        System.Data.DataTable DtbExport = new System.Data.DataTable();
        DtbExport = P.GetExportedStudentdetails_Blocking("Uploaded");
        GrvExportExcelDetails.DataSource = DtbExport;
        GrvExportExcelDetails.DataBind();
    }

    protected void BindExportedStudentNotUploaded()
    {
        PnlNotUploadedStudents.Visible = true;
        Processing P = new Processing();
        System.Data.DataTable Dtb = new System.Data.DataTable();
        Dtb = P.GetExportedStudentdetails_Blocking("Not Uploaded");
        GrvNotUploaded.DataSource = Dtb;
        GrvNotUploaded.DataBind();
    }

    protected void SaveBulckBlocking()
    {
        try
        {
            int countsave = 0;
            int RemarksCount = validateRemarks();

            if (RemarksCount == 0)
            {
                foreach (GridViewRow row in GrvExportExcelDetails.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    Label Stud_ID = (Label)row.FindControl("lblStud_ID");
                    Label lblLogin = (Label)row.FindControl("lblLogin");
                    TextBox txtRemarks = (TextBox)row.FindControl("TxtRemarks");



                    if (chk.Checked)
                    {
                        Processing P = new Processing();



                        DataTable Dtb = P.UPdatePortalBlockDetails(lblLogin.Text.Trim(), Stud_ID.Text.Trim(),
                            ChkFin.Checked, ChkLib.Checked, ChkAdm.Checked, ChkSSD.Checked, ChkHrd.Checked, Convert.ToInt32(Session["UserId"]), txtRemarks.Text.Trim());
                        countsave++;
                    }
                }
                if (countsave == 0)
                    lblMessage.Text = "Please select data";
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Updated succesfully!!');", true);

                }

            }
            else
            {
                lblMessage.Text = "Please Enter the Remarks for All Checked Students";
            }
        }
       
       
        catch (Exception ex)
        {
            lblMessage.Text = "Please try again !!";
        }
    }

    private int validateRemarks()
    {
        int RemarksCount = 0;

        foreach (GridViewRow row in GrvExportExcelDetails.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            TextBox txtRemarks = (TextBox)row.FindControl("TxtRemarks");
            if (chk.Checked)
            {
                if (txtRemarks.Text == "")
                {
                    RemarksCount++;
                }
            }
        }
        return RemarksCount;
    }
    protected void BtnDownLoad_Click(object sender, EventArgs e)
    {
        DataTable Dtb1 = new DataTable();
        ArrayList Pa = new ArrayList();
        ArrayList Pv = new ArrayList();
        Pa.Add("@Param");
        Pv.Add("Bulk Blocking");
        DBH.CreateDataTable(Dtb1, "SP_DummyExcelSheet", true, Pa, Pv);
        ExportToExcel(Dtb1);
    }

    private void ExportToExcel(DataTable Dtb)
    {

        GrvGrid.DataSource = Dtb;
        GrvGrid.DataBind();

        string result = ExcelUtility.ToExcel(GrvGrid.DataSource);
        DataTable Dt = (DataTable)GrvGrid.DataSource;
        ExcelUtility.ExportToExcel1(Dt);


    }

    protected void GetBlockedReason(string Stud_ID)
    {
        DataTable Dtb1 = new DataTable();
        ArrayList Pa = new ArrayList();
        ArrayList Pv = new ArrayList();
        Pa.Add("@Stud_ID");
        Pv.Add(Stud_ID);
        DBH.CreateDataTable(Dtb1, "SP_GetBlockedRemarks", true, Pa, Pv);

        if (Dtb1 != null && Dtb1.Rows.Count > 0)
        {
            txtReason.Text = Dtb1.Rows[0]["Remarks"].ToString();
            lblBlockedReason.Visible = true;
            txtReason.Visible = true;
        }
    }
}