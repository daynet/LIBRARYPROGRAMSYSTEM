using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FromBookRequest_Students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            BindStudyMaterial();
            BindData();
        }
    }

    public void BindStudyMaterial()
    {
      
        Processing P = new Processing();
        ddlMaterial.DataSource = P.BindMaterialData();
        ddlMaterial.DataTextField = "CatTypeName";
        ddlMaterial.DataValueField = "CatTypeID";
        ddlMaterial.DataBind();
       

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
        P.SP_Book_Requisition(0, txtStudentId.Text, TxtTitle.Text, TxtAuthor.Text, TxtPublisher.Text, TxtISBN.Text, Convert.ToInt32(TxtQty.Text), Convert.ToDecimal(TxtUitPrice.Text), Convert.ToInt32(ddlMaterial.SelectedValue), TxtLibRemarks.Text, Convert.ToInt32(0), "INSERT");
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Saved Successfully');", true);
        ClearData();
        BindData();
    }

    public void ClearData()
    {
        txtStudentId.Text = "";
        TxtTitle.Text = "";
        TxtAuthor.Text = "";
        TxtPublisher.Text = "";
        TxtISBN.Text = "";
        TxtQty.Text = "";
        TxtUitPrice.Text = "";
        TxtLibRemarks.Text = "";
        TxtStudentName.Text = "";

    }

    public void BindData()
    {
        Processing P = new Processing();
       GrdConferenceRoom.DataSource = P.SP_Book_Requisition(0, "", "", "", "", "", 0, 0, 0, "", Convert.ToInt32(0), "SELECT");
        GrdConferenceRoom.DataBind();
    }
}