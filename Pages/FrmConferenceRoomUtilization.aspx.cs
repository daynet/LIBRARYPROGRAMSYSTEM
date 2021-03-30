using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FrmConferenceRoomUtilization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            DisplayData();

        }
    }

    protected void hdnValue_ValueChanged(object sender, EventArgs e)
    {
        if (txtStudentId.Text.ToString().Contains("-") == true)
        {
            string[] StudentId = new string[2];
            StudentId = txtStudentId.Text.ToString().Split('-');
            txtStudentId.Text = StudentId[1].ToString();
            TxtStudentName.Text  = StudentId[2].ToString();
        }

    }

    protected void btn_Summary_Click(object sender, EventArgs e)
    {
        Processing P = new Processing();
        DataTable Dt = P.SP_Conference_Room_request(txtStudentId.Text, DateTime.Parse(TxtDate.Text), TxtRequestedTime.Text, Convert.ToInt32(Session["UserId"]), "INSERT");
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Saved Successfully');", true);
        txtStudentId.Text = "";
        TxtStudentName.Text = "";
        TxtRequestedTime.Text = "";
        DisplayData();
    }


    public void DisplayData()
    {
        Processing P = new Processing();
        DataTable Dt = P.SP_Conference_Room_request("", DateTime.Now , "", Convert.ToInt32(Session["UserId"]), "SELECT");

        GrdConferenceRoom.DataSource = Dt;
        GrdConferenceRoom.DataBind();
    }
}