using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text;
using System.Configuration;
using System.IO;

public partial class Page_Student_Ledger_Search : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();

    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //Session["EMPID1"] = "0";

                Session["EMPID1"] = Session["UserId"].ToString();

            }

        }
        catch
        {
            Response.Redirect("../Pages/loginform.aspx");
        }

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
                //string ID = e.CommandArgument.ToString();
                //string[] value = ID.Split('#');
                //Response.Redirect(string.Format("~/Page/StudentLedger.aspx?Stud_Id=" + value[1]), false);
                ////LoadReport(Convert.ToString(value[1]));
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

    }
    protected void chkall_checkedchanged(object sender, EventArgs e)
    {
        if (chkall.Checked == false)
            Session["EMPID1"] = Session["EMPID"].ToString();
        else
            Session["EMPID1"] = "0";

        dsDetails.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();

        dsDetails.Update();

    }

    
}
