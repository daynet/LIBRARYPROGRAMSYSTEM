using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;

public partial class Pages_BookReturnDueDateEntry : System.Web.UI.Page
{
    Processing P = new Processing();
    string IPAddress = ""; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDown();
            ClearData();
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        save();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearData();
        LoadDropDown();
        BindGrid();
    }
    protected void ClearData()
    {
        HdnID.Value = "0";
        ddlSemester.SelectedIndex = -1;
        TxtDueDate.Text = "";
        TxtRemarks.Text = "";
        chkActive.Checked = true;
        BindGrid();
    }
    public string GetIPAddress()
    {
        IPHostEntry Host = default(IPHostEntry);
        string Hostname = null;
        Hostname = System.Environment.MachineName;
        Host = Dns.GetHostEntry(Hostname);
        foreach (IPAddress IP in Host.AddressList)
        {
            if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                IPAddress = Convert.ToString(IP);
            }
        }
        return IPAddress;
    }
    protected void save()
    {
        DataTable Dtb = new DataTable();

        string[] stringdate1 = new string[3];
        if (TxtDueDate.Text != "")
            stringdate1 = TxtDueDate.Text.Split('/');
        else
            stringdate1 = "01/01/1990".Split('/');
        DateTime DueDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));

        bool IsActive = chkActive.Checked == true ? true : false;

        if (HdnID.Value == "0")
        {
            Dtb = P.BookReturnDueDateEntry("INSERT", 0, Convert.ToInt32(ddlSemester.SelectedValue)
                                        , DueDate, TxtRemarks.Text, IsActive, Convert.ToInt32(Session["UserId"]), GetIPAddress());
        }
        else
        {
            Dtb = P.BookReturnDueDateEntry("UPDATE", Convert.ToInt32(HdnID.Value), Convert.ToInt32(ddlSemester.SelectedValue)
                                        , DueDate, TxtRemarks.Text, IsActive, Convert.ToInt32(Session["UserId"]), GetIPAddress());
        }
        if (Dtb.Rows.Count > 0)
        {
            if (Convert.ToInt32(Dtb.Rows[0][0]) > 0)
            {
                ClearData();
                BtnSave.Text = "SAVE";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data saved succesfully!!');", true);
            }
        }

        //Session["Duedateforemail"] = DueDate;

    }
    protected void GrvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            getDueDate();
            if (e.CommandName.Equals("EditRow"))
            {
                Setdata(Convert.ToInt32(e.CommandArgument.ToString()));
            }
            else if (e.CommandName.Equals("SendMail"))
            {
                Session["IdForEmailData"] = null;
                Session["IdForEmailData"] = e.CommandArgument.ToString();

                //int rowIndex = Convert.ToInt32(e.CommandArgument);

                //int dt = Convert.ToInt32(GrvDetails.Rows[rowIndex - 1].Cells[4].Text);

    
                //  Session["DuedateForEmailData"] = Convert.ToDateTime(GrvDetails.Rows[rowIndex  ].Cells[2].Text).ToString("dd/MM/yyyy") ;



                //Response.Redirect("BookReturnDueDateMail.aspx?Id=" + e.CommandArgument.ToString());  

                Response.Redirect("BookReturnDueDateMail.aspx", false);  
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void GrvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Checking the RowType of the Row  
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LnkSendMail = (LinkButton)e.Row.FindControl("LnkSendMail");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            LinkButton LnkEdit = (LinkButton)e.Row.FindControl("LnkEdit");            

            if (lblStatus.Text == "DE-ACTIVE")
            {
                LnkSendMail.Visible = false;
                LnkEdit.Visible = false;
            }

           // var rowIndex = e.Row.Cells[0].FindControl("DueDate");

        
           


        }
    }  
    public void Setdata(int ID)
    {
        DataTable DTB = P.BookReturnDueDateEntry("SelectById", ID);

        if (DTB.Rows.Count > 0)
        {
            HdnID.Value = Convert.ToString(DTB.Rows[0]["ID"]);
            ddlSemester.SelectedValue = DTB.Rows[0]["SemesterId"].ToString();
            TxtDueDate.Text = Convert.ToDateTime(DTB.Rows[0]["DueDate"]).ToString("dd/MM/yyyy");
            TxtRemarks.Text = Convert.ToString(DTB.Rows[0]["Description"]);
            chkActive.Checked = Convert.ToBoolean(DTB.Rows[0]["IsActive"]);
            BtnSave.Text = "UPDATE";
        }
    }

    public void BindGrid()
    {
        DataTable DTB = P.BookReturnDueDateEntry("SelectAll");
        GrvDetails.DataSource = DTB;
        GrvDetails.DataBind();

    }

    public void LoadDropDown()
    {
        DataTable DTB = P.LoadDropDown("LoadSemester");
        ddlSemester.DataSource = DTB;
        ddlSemester.DataTextField = "Semester_Desc";
        ddlSemester.DataValueField = "Semester_RefID";
        ddlSemester.DataBind();
    }


    public void getDueDate()
    {
        DateTime? duedate = null;
        string bbb = "";
        DataTable DTB = P.BookReturnDueDateEntry("SelectAll");
        foreach (DataRow row  in DTB.Rows)
        {
            string Status = row["Status"].ToString().ToLower();

            if(Status == "active")
            {
                duedate = Convert.ToDateTime(row["DueDate"]);
                break;
            }
          //("dd/MM/yyyy");
   


          
        }
        bbb = duedate.Value.ToString("dd MMM yyyy");
        Session["Duedateforemail"] = bbb;
            
        

    }
}