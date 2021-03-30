using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CSalary
/// </summary>
public class CSalary
{
	public CSalary()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void SaveTempElementsContract(string viPersonId, string viElementId, string viStartDateString, Decimal viValue1, string viRemarks, string viCreatedById, string viVoucher, int viContract)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INS_HR_PersonElements_TempContract";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.VarChar, 20));
            cmd.Parameters["@iPersonId"].Value = viPersonId;
            cmd.Parameters.Add(new SqlParameter("@iElementId", SqlDbType.Int));
            cmd.Parameters["@iElementId"].Value = viElementId;
            cmd.Parameters.Add(new SqlParameter("@iDate", SqlDbType.DateTime));
            cmd.Parameters["@iDate"].Value = viStartDateString;
            cmd.Parameters.Add(new SqlParameter("@iValue1", SqlDbType.Float));
            cmd.Parameters["@iValue1"].Value = viValue1;
            cmd.Parameters.Add(new SqlParameter("@iRemarks", SqlDbType.VarChar, 200));
            cmd.Parameters["@iRemarks"].Value = viRemarks;
            cmd.Parameters.Add(new SqlParameter("@iCreatedById", SqlDbType.VarChar, 20));
            cmd.Parameters["@iCreatedById"].Value = viCreatedById;
            cmd.Parameters.Add(new SqlParameter("@iVoucher", SqlDbType.VarChar, 20));
            cmd.Parameters["@iVoucher"].Value = viVoucher;
            cmd.Parameters.Add(new SqlParameter("@iContract", SqlDbType.Int));
            cmd.Parameters["@iContract"].Value = viContract;
            con.Open();
            cmd.ExecuteNonQuery();
            //  MessageBox.Show("Record Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close();
        }
        catch (Exception ex)
        {

        }
    }
    public static void SaveElements(string viPersonId, DateTime viStartDateString, int viElementId, Decimal viValue1, string viRemarks, int vEMPID)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INS_HR_PersonElements";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.VarChar, 20));
            cmd.Parameters["@iPersonId"].Value = viPersonId;
            cmd.Parameters.Add(new SqlParameter("@iElementId", SqlDbType.Int));
            cmd.Parameters["@iElementId"].Value = viElementId;
            cmd.Parameters.Add(new SqlParameter("@iStartDate", SqlDbType.DateTime));
            cmd.Parameters["@iStartDate"].Value = viStartDateString;
            cmd.Parameters.Add(new SqlParameter("@iValue1", SqlDbType.Float));
            cmd.Parameters["@iValue1"].Value = viValue1;
            cmd.Parameters.Add(new SqlParameter("@iRemarks", SqlDbType.VarChar, 200));
            cmd.Parameters["@iRemarks"].Value = viRemarks;
            cmd.Parameters.Add(new SqlParameter("@iCreatedById", SqlDbType.Int));
            cmd.Parameters["@iCreatedById"].Value = vEMPID;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            
        }
    }

    public static void UpdSaveElements(string viPersonId, string viEndDateString, int viElementId, Decimal viValue1, string viRemarks,int vEMPID)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INS_HR_SalModify";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.VarChar, 20));
            cmd.Parameters["@iPersonId"].Value = viPersonId;
            cmd.Parameters.Add(new SqlParameter("@iElementId", SqlDbType.Int));
            cmd.Parameters["@iElementId"].Value = viElementId;
            cmd.Parameters.Add(new SqlParameter("@iEndDateString", SqlDbType.VarChar, 50));
            cmd.Parameters["@iEndDateString"].Value = viEndDateString;
            cmd.Parameters.Add(new SqlParameter("@iValue1", SqlDbType.Float));
            cmd.Parameters["@iValue1"].Value = viValue1;
            cmd.Parameters.Add(new SqlParameter("@iRemarks", SqlDbType.VarChar, 200));
            cmd.Parameters["@iRemarks"].Value = viRemarks;
            cmd.Parameters.Add(new SqlParameter("@iCreatedById", SqlDbType.Int));
            cmd.Parameters["@iCreatedById"].Value = vEMPID;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
           
        }
    }

    public static void SaveTempElements(string viPersonId, string viElementId, string viStartDateString, Decimal viValue1, string viRemarks, string viCreatedById, string viVoucher, string contractid,Int32 isPrevACyear=0 )
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INS_HR_PersonElements_Temp";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.VarChar, 20));
            cmd.Parameters["@iPersonId"].Value = viPersonId;
            cmd.Parameters.Add(new SqlParameter("@iElementId", SqlDbType.Int));
            cmd.Parameters["@iElementId"].Value = viElementId;
            cmd.Parameters.Add(new SqlParameter("@iDate", SqlDbType.VarChar,200));
            cmd.Parameters["@iDate"].Value = viStartDateString;
            cmd.Parameters.Add(new SqlParameter("@iValue1", SqlDbType.Float));
            cmd.Parameters["@iValue1"].Value = viValue1;
            cmd.Parameters.Add(new SqlParameter("@iRemarks", SqlDbType.VarChar, 200));
            cmd.Parameters["@iRemarks"].Value = viRemarks;
            cmd.Parameters.Add(new SqlParameter("@iCreatedById", SqlDbType.VarChar, 20));
            cmd.Parameters["@iCreatedById"].Value = viCreatedById;
            cmd.Parameters.Add(new SqlParameter("@iVoucher", SqlDbType.VarChar, 20));
            cmd.Parameters["@iVoucher"].Value = viVoucher;
            cmd.Parameters.Add(new SqlParameter("@contractid", SqlDbType.VarChar, 20));
            cmd.Parameters["@contractid"].Value = contractid;
            cmd.Parameters.Add(new SqlParameter("@isPrevACyear", SqlDbType.Int));
            cmd.Parameters["@isPrevACyear"].Value = isPrevACyear;
            con.Open();
            cmd.ExecuteNonQuery();
            //  MessageBox.Show("Record Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close();
        }
        catch (Exception ex)
        {
           
        }
    }

    public static void UpdateTempElements(string viPersonId, string viElementId, string viStartDateString, Decimal viValue1, string viRemarks, string viCreatedById, string viVoucher, string viStatus)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPD_HR_PersonElements_Temp";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.VarChar, 20));
            cmd.Parameters["@iPersonId"].Value = viPersonId;
            cmd.Parameters.Add(new SqlParameter("@iElementId", SqlDbType.Int));
            cmd.Parameters["@iElementId"].Value = viElementId;
            cmd.Parameters.Add(new SqlParameter("@iDate", SqlDbType.VarChar));
            cmd.Parameters["@iDate"].Value = viStartDateString;
            cmd.Parameters.Add(new SqlParameter("@iValue1", SqlDbType.Float));
            cmd.Parameters["@iValue1"].Value = viValue1;
            cmd.Parameters.Add(new SqlParameter("@iRemarks", SqlDbType.VarChar, 200));
            cmd.Parameters["@iRemarks"].Value = viRemarks;
            cmd.Parameters.Add(new SqlParameter("@iCreatedById", SqlDbType.VarChar, 20));
            cmd.Parameters["@iCreatedById"].Value = viCreatedById;
            cmd.Parameters.Add(new SqlParameter("@iVoucher", SqlDbType.VarChar, 20));
            cmd.Parameters["@iVoucher"].Value = viVoucher;
            cmd.Parameters.Add(new SqlParameter("@iVStatus", SqlDbType.VarChar, 10));
            cmd.Parameters["@iVStatus"].Value = viStatus;
            con.Open();
            cmd.ExecuteNonQuery();
            //  MessageBox.Show("Record Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close();
        }
        catch (Exception ex)
        {

        }
    }
   public static void DeleteTempElements(string viVoucher)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DEL_HR_PersonElements_Temp";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iVoucher", SqlDbType.VarChar, 20));
            cmd.Parameters["@iVoucher"].Value = viVoucher;
            con.Open();
            cmd.ExecuteNonQuery();
            //  MessageBox.Show("Record Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close();
        }
        catch (Exception ex)
        {

        }
    }
}