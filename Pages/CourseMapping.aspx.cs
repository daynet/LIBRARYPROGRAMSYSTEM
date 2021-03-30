using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_CourseMapping : System.Web.UI.Page
{
    Processing P = new Processing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearData();
          
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        save();
    }
    protected void ClearData()
    {
        HdnID.Value = "0";
        txtKohaCourseCode.Text = "";
        txtErpCourseCode.Text = "";
        BindGrid();
    }
    protected void save()
    {
        DataTable Dtb = new DataTable();

        string[] stringdate1 = new string[3];
        if (TxtDate.Text != "")
            stringdate1 = TxtDate.Text.Split('/');
        else
            stringdate1 = "01/01/1990".Split('/');
        DateTime EffectiveDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));


        if (HdnID.Value=="0")
        {
            Dtb = P.INSERTCOURSEMAPPING("INSERT", Convert.ToInt32(HdnID.Value),Convert.ToInt32(DrpProgram.SelectedValue), txtErpCourseCode.Text.Trim(),txtKohaCourseCode.Text.Trim(),EffectiveDate, Convert.ToInt32(Session["UserId"]));
        }
        else
        {
            Dtb = P.INSERTCOURSEMAPPING("UPDATE", Convert.ToInt32(HdnID.Value),Convert.ToInt32(DrpProgram.SelectedValue), txtErpCourseCode.Text.Trim(),txtKohaCourseCode.Text.Trim(),EffectiveDate, Convert.ToInt32(Session["UserId"]));
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

    }
    protected void GrvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("EditRow"))
            {
                Setdata(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Setdata(int ID)
    {
        DataTable DTB = P.INSERTCOURSEMAPPING("BYID", ID, 0, "","",DateTime.Now, 0);


        if (DTB.Rows.Count > 0)
        {
            HdnID.Value = Convert.ToString(DTB.Rows[0]["ID"]);
            DrpProgram.SelectedValue = DTB.Rows[0]["DegreeTypeID"].ToString();
            txtErpCourseCode.Text = Convert.ToString(DTB.Rows[0]["CDD_CODE"]);
            txtKohaCourseCode.Text = Convert.ToString(DTB.Rows[0]["Koha_CDD_CODE"]);
            TxtDate.Text = Convert.ToDateTime(DTB.Rows[0]["EffectiveStartdate"]).ToString("dd/MM/yyyy");
            BtnSave.Text = "UPDATE";
        }
    }
    public void BindGrid()
    {
        DataTable DTB = P.INSERTCOURSEMAPPING("SELECT", 0, 0, "", "", DateTime.Now, 0);
        GrvDetails.DataSource = DTB;
        GrvDetails.DataBind();
    }
}