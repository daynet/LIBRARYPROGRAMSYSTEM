using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


public partial class Page_ExcelExport : System.Web.UI.Page
{
    Processing P = new Processing();
    SqlConnection x;
    SqlCommand y1;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
        {
            var appUrl = VirtualPathUtility.ToAbsolute("~/");
            string path = HttpContext.Current.Request.Url.AbsolutePath.Remove(0, appUrl.Length - 1);
            //if (CommonFunctions.CheckUserAuthentication(Convert.ToInt32(Session["UserId"]), path))
            //{
                if (!Page.IsPostBack)
                {
                    try
                    {
                        if (Convert.ToString(Session["Role"]) == "Admin" || Convert.ToString(Session["Role"]) == "AdminDept" || Convert.ToString(Session["Role"]) == "Examination")
                        {
                            ddl_reportList.DataSource = P.Bind_ExcelReportLIst("Admin");
                            ddl_reportList.DataTextField = "Report_Name";
                            ddl_reportList.DataValueField = "Sp_Query";
                            ddl_reportList.DataBind();
                        }
                        else
                        {
                            ddl_reportList.DataSource = P.Bind_ExcelReportLIst("Faculty");
                            ddl_reportList.DataTextField = "Report_Name";
                            ddl_reportList.DataValueField = "Sp_Query";
                            ddl_reportList.DataBind();
                        }
                    }
                    catch (Exception Ex)
                    {
                    }
                }
            //}
            //else
            //{
            //    Response.Redirect("../Pages/Login.aspx", false);
            //}
        }
        else
        {
            Response.Redirect("../Pages/Login.aspx", false);
        }
    }

    public void BindYear()
    {
        try
        {
            ddl_acYear.DataSource = P.BindERPYEAR();
            ddl_acYear.DataTextField = "AcadYear_Desc";
            ddl_acYear.DataValueField = "AcadYear_ID";           
            ddl_acYear.DataBind();
        }
        catch (Exception Ex) 
        { 
        }
    }

    protected void ddl_acyear_selectedindexchanged(object sender, EventArgs e)
    {
        ddl_semester.DataSource = P.BindERPSemester(Convert.ToString(ddl_acYear.SelectedItem.Text));
        ddl_semester.DataValueField = "Semester_id";
        ddl_semester.DataTextField = "Semester_name";
        ddl_semester.DataBind();
        ddl_semester.Items.Insert(0, "---Select---");
    }   

    protected void ddl_semester_selectindexchanged(object sender, EventArgs e)
    {
        try
        {
            gV_View.DataSource = null;
            gV_View.DataBind();

            int semesterId = Convert.ToInt16(ddl_semester.SelectedItem.Value);
            try
            {
                int id = Convert.ToInt32(Session["UserId"]);
                string role = Convert.ToString(Session["Role"]);

                if (role == "Faculty")
                {
                    ddl_employee.DataSource = P.BindERPFacultyOnly(id, semesterId);
                    ddl_employee.DataTextField = "FACULTY_NAME";
                    ddl_employee.DataValueField = "FACULTY_ID";
                    ddl_employee.DataBind();
                }
                else
                {
                    ddl_employee.DataSource = P.BindERPFacultyOnly(0,semesterId);
                    ddl_employee.DataTextField = "FACULTY_NAME";
                    ddl_employee.DataValueField = "FACULTY_ID";
                    ddl_employee.DataBind();
                    if  (ddl_reportList.SelectedItem.Value == "Sp_StudentContactDetails")
                    ddl_employee.Items.Insert(0, new ListItem("ALL", "0"));
                }
                

                try
                {

                    ddl_batch.DataSource = P.BindERPSemester(semesterId, Convert.ToInt16(ddl_employee.SelectedItem.Value));
                    ddl_batch.DataTextField = "BatchCode";
                    ddl_batch.DataValueField = "Batch_Id";
                    ddl_batch.DataBind();
                    if (ddl_reportList.SelectedItem.Value == "Sp_StudentContactDetails")
                    ddl_batch.Items.Insert(0, new ListItem("ALL", "0"));
                }
                catch
                {
                    ddl_batch.Items.Clear();
                    gV_View.DataSource = null;
                    gV_View.DataBind();

                }
                bindgrid();
            }
            catch (Exception Ex)
            {
            }
        }
        catch
        {

        }
    }


    protected void ddl_Faculty_selectedindexchanged(object sender, EventArgs e)
    {
        int Empid = Convert.ToInt16(ddl_employee.SelectedItem.Value);
        int semesterId = Convert.ToInt16(ddl_semester.SelectedItem.Value);
        try
        {
            ddl_batch.DataSource = P.BindERPSemester(semesterId, Empid);
            ddl_batch.DataTextField = "BatchCode";
            ddl_batch.DataValueField = "Batch_Id";
            ddl_batch.DataBind();
            if  (ddl_reportList.SelectedItem.Value == "Sp_StudentContactDetails")
            ddl_batch.Items.Insert(0, new ListItem("ALL", "0"));
        }
        catch (Exception Ex)
        {
        }

        bindgrid();
    }


    protected void btn_Click_Load_Details(object sender, EventArgs e)
    {
        if (ddl_reportList.SelectedItem.Value == "SP_FACULTY_TURNITIN" || ddl_reportList.SelectedItem.Value == "Sp_StudentContactDetails")
        {
            panelshow1.Visible = true;
            BindYear();
            ddl_semester.DataSource = P.BindERPSemester(Convert.ToString(ddl_acYear.SelectedItem.Text));
            ddl_semester.DataValueField = "Semester_id";
            ddl_semester.DataTextField = "Semester_name";
            ddl_semester.DataBind();
            ddl_semester.Items.Insert(0, "---Select---");
        }

        if (ddl_reportList.SelectedItem.Value == "Sp_FinaltermGradesumery")
        {
            panelshow1.Visible = true;
            BindYear();
            ddl_semester.DataSource = P.BindERPSemester(Convert.ToString(ddl_acYear.SelectedItem.Text));
            ddl_semester.DataValueField = "Semester_id";
            ddl_semester.DataTextField = "Semester_name";
            ddl_semester.DataBind();
            ddl_semester.Items.Insert(0, "---Select---");
        }
    }

    protected void ddl_batch_selectedindex_changed(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void bindgrid()
    {
        int FacultyId = Convert.ToInt32(ddl_employee.SelectedItem.Value);
        int Semester_Id = Convert.ToInt32(ddl_semester.SelectedItem.Value);
        int batchcodeid = Convert.ToInt32(ddl_batch.SelectedItem.Value);

        string Query = "";
        // Query = DBH.GetResult("select sp_query  from adminexam..IT_ADMIN_EXCEL_REPORTS where  ID ='" + ddlReports.SelectedValue + "'").ToString();

        string name = "  " + Convert.ToString(ddl_reportList.SelectedItem.Value);

        // Query = "Exec " + name + " '" + txtfromdate.Text + "','" + txttodate.Text + "' ";

        if (ddl_reportList.SelectedItem.Value == "SP_FACULTY_TURNITIN" || ddl_reportList.SelectedItem.Value == "Sp_StudentContactDetails" )
        {
            Query = "Exec " + name + "  " + FacultyId + "," + Semester_Id + "," + batchcodeid;
        }
        else if (ddl_reportList.SelectedItem.Value == "Sp_FinaltermGradesumery")
        {
            Query = "Exec " + name + " "+ Semester_Id;
        }

        string connection = ConfigurationManager.ConnectionStrings["AdminExam"].ToString(); ;
        x = new SqlConnection(connection);

        x.Open();
        y1 = new SqlCommand();
        y1.Connection = x;
        y1.CommandText = Query;
        //y1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter y = new SqlDataAdapter(y1);
        dt = new DataTable();
        y.Fill(dt);
        gV_View.DataSource = dt;
        gV_View.DataBind();
        x.Close();
    }


    protected void btn_ExportExcel_Click(object sender, EventArgs e)
    {  
        try
        {
            bindgrid();
            try
            {
                string result;
                if (ddl_reportList.SelectedItem.Value == "SP_FACULTY_TURNITIN")
                {
                    result = ExcelUtility.WithoutColumnToExcel(gV_View.DataSource);
                }
                else
                {
                    result = ExcelUtility.ToExcel(gV_View.DataSource);
                }
                ExcelUtility.ExportToExcel(result);
            }
            catch
            {
               // lbl_ack.Visible = true;
               // lbl_ack.Text = "Please check Excel configuration !!!";
            }
        }
        catch
        {
           // lbl_ack.Visible = true;
           // lbl_ack.Text = "Please Select all the values";
        }        
        
    }

}