using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.NetworkInformation;

public partial class Pages_BookReturnDueDateMail : System.Web.UI.Page
{
    dynamic SQLcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ToString());
    Processing P = new Processing();
    string SemesterId = "";
    Int32 Id = 0;
    string IPAddress ="";   

    protected void Page_Load(object sender, EventArgs e)
    {
        string str1 = GetIPAddress();

        if (Session["IdForEmailData"] != null)
        {
            Id = Convert.ToInt32(Session["IdForEmailData"]);
        }
        else
        {
            Response.Redirect("BookReturnDueDateEntry.aspx");  
        }

        if (!IsPostBack)
        {
            LoadEMailData(Id);
        }
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

    protected void ddlUserType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        LoadEMailData(Id);
    }

    public void LoadEMailData(int Id)
    {
        String DueDateForMail = Session["Duedateforemail"].ToString();
        DataSet Ds = P.LoadEMailData("LoadEMailData", DueDateForMail, Id,ddlUserType.SelectedValue.ToString());

        if(Ds != null && Ds.Tables[0].Rows.Count > 0)
        {
            TxtSemester.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Semester"]);
            TxtDueDate.Text = Convert.ToDateTime(Ds.Tables[0].Rows[0]["DueDate"]).ToString("dd/MM/yyyy");
        }

        if(Ds != null && Ds.Tables[1].Rows.Count > 0)
        {
            GrvDetails.DataSource = Ds.Tables[1];
            GrvDetails.DataBind();
        }
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {       
        //4th Grid
        DataTable DTGrvDetails = new DataTable();
        DTGrvDetails.Columns.Add("ID");
        DTGrvDetails.Columns.Add("Name");
        DTGrvDetails.Columns.Add("EmailId");
        DTGrvDetails.Columns.Add("Semester");
        DTGrvDetails.Columns.Add("DueDate");
        DTGrvDetails.Columns.Add("EmailSubject");
        DTGrvDetails.Columns.Add("EmailContent");
        DTGrvDetails.Columns.Add("CreatedBy");
        DTGrvDetails.Columns.Add("CreatedIP");
       
        foreach (GridViewRow row in GrvDetails.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkRow");
            Label lblStudentID = (Label)row.FindControl("lblStudentID");
            Label lblStudentName = (Label)row.FindControl("lblStudentName");
            Label lblEMail = (Label)row.FindControl("lblEMail");
            
            if (chk.Checked)
            {
                DataRow newCustomersRow = DTGrvDetails.NewRow();
                newCustomersRow["ID"] = lblStudentID.Text;
                newCustomersRow["Name"] = lblStudentName.Text;
                newCustomersRow["EmailId"] = lblEMail.Text;
                newCustomersRow["Semester"] = TxtSemester.Text;
                newCustomersRow["DueDate"] = TxtDueDate.Text;
                newCustomersRow["EmailSubject"] = txtSubject.Text;
                newCustomersRow["EmailContent"] = txtBody.Text;
                newCustomersRow["CreatedBy"] = Session["UserId"];
                newCustomersRow["CreatedIP"] = GetIPAddress();
                DTGrvDetails.Rows.Add(newCustomersRow);
            }
        }

        try
        {
            DataTable Dt = P.InsertEmailData(DTGrvDetails);

            if (Dt.Rows.Count > 0 && Dt.Rows[0][0].ToString() == "1")
            {
                ClearData();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Sent Successfully.!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Send failed.!');", true);
                return;
            }
        }
        catch (Exception Ex)
        {
        } 
    }
    protected void BackToMain_Click(object sender, EventArgs e)
    {
        Session["IdForEmailData"] = null;
        Response.Redirect("BookReturnDueDateEntry.aspx");  
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void ClearData()
    {
        TxtSemester.Text = "";
        TxtDueDate.Text = "";
        txtSubject.Text = "";
        txtSubject.Focus();
        txtBody.Text = "";
        LoadEMailData(Id);
    }

    protected void save()
    {
        DataTable Dtb = new DataTable();
        
        if (Dtb.Rows.Count > 0)
        {
            if (Convert.ToInt32(Dtb.Rows[0][0]) > 0)
            {
                ClearData();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mail Send succesfully!!');", true);
                Session["IdForEmailData"] = null;
            }
        }
    }

    protected void GrvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            
        }
        catch (Exception ex)
        {

        }
    }   

}
