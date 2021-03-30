using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;


public partial class Page_CalenderAuditReport : System.Web.UI.Page
{
    DBHandler DBH = new DBHandler();
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            DBH.CreateDataTable_TPS(dt, "EXEC SP_LOADTPSDETAILS");

            drpYear.DataSource = dt.DefaultView.ToTable(true, "Year");
            drpYear.DataTextField = "Year";
            drpYear.DataValueField = "Year";
            drpYear.DataBind();
            drpYear.Items.Insert(0, new ListItem("Select", ""));

            drpSem.DataSource = dt.DefaultView.ToTable(true, "Semester");
            drpSem.DataTextField = "Semester";
            drpSem.DataValueField = "Semester";
            drpSem.DataBind();
            drpSem.Items.Insert(0, new ListItem("Select", ""));

            //ddl_types.DataSource = dt.DefaultView.ToTable(true, "Department");
            //ddl_types.DataTextField = "Department";
            //ddl_types.DataValueField = "Department";
            //ddl_types.DataBind();
            //ddl_types.Items.Insert(0, new ListItem("Select", ""));

            Processing P = new Processing();
            ddl_types.DataSource = P.BindCalenderDropdown("CalName", Convert.ToInt32(Session["UserId"]), "",0,"");
            ddl_types.DataTextField = "Cal_Name";
            ddl_types.DataValueField = "Cal_Name";
            ddl_types.DataBind();

            ddl_category.DataSource = dt.DefaultView.ToTable(true, "ItemType");
            ddl_category.DataTextField = "ItemType";
            ddl_category.DataValueField = "ItemType";
            ddl_category.DataBind();
            ddl_category.Items.Insert(0, new ListItem("Select", ""));

        }
    }


    protected void btnviewreport_click(object sender, EventArgs e)
    {
        string url = "";
        url = "../pages/CalendarauditPrintReport.aspx?Department=" + ddl_types.SelectedValue + "&Semester=" + drpSem.SelectedValue + "&Year=" + drpYear.SelectedValue;
        Response.Write("<script> window.open( '" + url + "','_blank' ); </script>");                 
    }


    protected void btn_SummaryClick(object sender, EventArgs e)
    {
        string url = "";
        url = "../pages/CalendarauditSummaryPrinReport.aspx?Type=S&Department=" + ddl_types.SelectedValue + "&Semester=" + drpSem.SelectedValue + "&Year=" + drpYear.SelectedValue + "&ItemType=" + ddl_category.SelectedValue;
        Response.Write("<script> window.open( '" + url + "','_blank' ); </script>");
    }

    protected void btncummulativereport_click(object sender, EventArgs e)
    {
        string url = "";
        url = "../pages/CalendarauditSummaryPrinReport.aspx?Type=C&Department=" + ddl_types.SelectedValue + "&Semester=" + drpSem.SelectedValue + "&Year=" + drpYear.SelectedValue + "&ItemType=" + ddl_category.SelectedValue;
        Response.Write("<script> window.open( '" + url + "','_blank' ); </script>");
    }

    protected void btnDetailsreport_click(object sender, EventArgs e)
    {
        string url = "";
        url = "../pages/CalendarauditSummaryPrinReport.aspx?Type=D&Department=" + ddl_types.SelectedValue + "&Semester=" + drpSem.SelectedValue + "&Year=" + drpYear.SelectedValue + "&ItemType=" + ddl_category.SelectedValue;
        Response.Write("<script> window.open( '" + url + "','_blank' ); </script>");
    }


}