using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FrmBookReview : System.Web.UI.Page
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
            TxtStudentName.Text = StudentId[2].ToString();
        }

    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Processing P = new Processing();
        DataTable Dt = P.SP_Faculty_review(0, txtStudentId.Text, TxtTitle.Text, TxtAuthor.Text, TxtPublisher.Text, TxtISBN.Text, TxtLo.Text, TxtKnowledge.Text, TxtSkills.Text, TxtCompetency.Text, TxtSyllabus.Text, 0, "INSERT");
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Saved Successfully');", true);
        ClearData();
        DisplayData();
    }
    public void DisplayData()
    {
        Processing P = new Processing();
        DataTable Dt = P.SP_Faculty_review(0, txtStudentId.Text, TxtTitle.Text, TxtAuthor.Text, TxtPublisher.Text, TxtISBN.Text, TxtLo.Text, TxtKnowledge.Text, TxtSkills.Text, TxtCompetency.Text, TxtSyllabus.Text, 0, "EDIT");
        GrdConferenceRoom.DataSource = Dt;
        GrdConferenceRoom.DataBind();
    }

    public void ClearData()
    {
        txtStudentId.Text = "";
        TxtTitle.Text = "";
        TxtAuthor.Text = "";
        TxtPublisher.Text = "";
        TxtISBN.Text = "";
        TxtLo.Text = "";
        TxtKnowledge.Text = "";
        TxtSkills.Text = "";
        TxtCompetency.Text = "";
        TxtSyllabus.Text = "";

    }
}