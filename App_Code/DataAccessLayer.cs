using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

public class DataAccessLayer : Object
{
    private string connection;
    private string AdminExam;
    private string SecurityConnection;
    private string LibraryConnection;
    private string PortalConnection;
    public DataAccessLayer()
    {
        connection = null;
        this.connection = ConfigurationManager.ConnectionStrings["con"].ToString();
        AdminExam = null;
        this.AdminExam = ConfigurationManager.ConnectionStrings["AdminExam"].ToString();
        SecurityConnection = null;
        SecurityConnection = ConfigurationManager.ConnectionStrings["SecurityCon"].ToString();
        LibraryConnection = null;
        LibraryConnection = ConfigurationManager.ConnectionStrings["Library"].ToString();
        PortalConnection = null;
        PortalConnection = ConfigurationManager.ConnectionStrings["Portal"].ToString();
    }
    public bool isInsert(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return false;
    }
    public DataSet getDataByParam(string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }

    public DataSet AdmingetDataByParam(string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.AdminExam);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }

    public DataSet getDataByParam(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.CommandTimeout = 0;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }
    public DataSet LibrarygetDataByParam(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.LibraryConnection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.CommandTimeout = 0;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }
    public DataSet AdmingetDataByParam(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.AdminExam);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.CommandTimeout = 0;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }
    public bool isDelete(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return false;
    }

    public bool isUpdate(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return false;
    }
    public int getResultByParam(SqlParameter[] param, string strStoreProcedure, string strOutput)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        int result = 0;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteScalar();
            result = Convert.ToInt32(cmd.Parameters[strOutput].Value.ToString());
            return result;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return result;
    }
    public Int32 InsertValues(SqlParameter[] param, string Procedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(Procedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            return cmd.ExecuteNonQuery();

        }
        catch (Exception Ex)
        {
            
            return 0;
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }

    }
    //added by muhammed fazeel k on 19/june/2014
    public DataTable CreateDataTable(SqlParameter[] param, string strStoreProcedure, bool isstoredprocedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataTable dt = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            if (isstoredprocedure == true)
            {
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                int i = param.Length;
                for (int j = 0; j < i; j++)
                    dataAdapter.SelectCommand.Parameters.Add(param[j]);
            }
            else
            {
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
            }
            // dataAdapter.SelectCommand.ExecuteNonQuery();
            dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.SelectCommand.Parameters.Clear();
            dataAdapter.Dispose();
            dt.Dispose();
        }
        return null;
    }

    public void CreateDataTableWithParam(DataTable DT, string StrSql, bool IsStoredProcedure = false, ArrayList pa = null, ArrayList pv = null)
    {
        try
        {
            DT.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connection;
            con.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(StrSql, con);
            adaptor.SelectCommand.CommandTimeout = 5000;

            if (IsStoredProcedure == true)
            {
                adaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                for (int count = 0; count < pa.Count; count++)
                {
                    // pa[count] = pv[count];
                    adaptor.SelectCommand.Parameters.AddWithValue(pa[count].ToString(), pv[count]);
                }
            }
            adaptor.Fill(DT);
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet AdminExamgetDataByParam(string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.AdminExam);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }

    public DataSet getDataByParamSecurity(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.SecurityConnection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            //if (!string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["UserId"])))
            //{
            //    Processing p = new Processing();
            //   // p.InsertException(Convert.ToInt32(HttpContext.Current.Session["UserId"]), ex.Message, strStoreProcedure);
            //}
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }

    public DataSet getResult(string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.SecurityConnection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (SqlException e)
        {
            //if (!string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["UserId"])))
            //{
            //    Processing p = new Processing();
            //    p.InsertException(Convert.ToInt32(HttpContext.Current.Session["UserId"]), e.Message, strStoreProcedure);
            //}
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return ds;
    }
    public DataSet getDataByParamPortal(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.PortalConnection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.CommandTimeout = 0;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            //dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }
}

