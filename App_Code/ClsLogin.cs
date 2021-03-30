using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnisHrSystemModel;

/// <summary>
/// Summary description for ClsLogin
/// </summary>
public class ClsLogin
{
	public ClsLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    UnisHrSystemEntities pe = new UnisHrSystemEntities();
    public string _username, _password;
    public string UserName
    {
        get { return _username; }
        set { _username = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public List<EMPLOYEE> Login()
    {
        
        var X = from EMP in pe.EMPLOYEEs where EMP.EMPCODE == UserName select EMP; //new { EMP.PASSWORD, EMP.ROLEID, EMP.PERSON_ID, EMP.EMPCODE };
        List<EMPLOYEE> L1=new List<EMPLOYEE>();
        L1=X.ToList<EMPLOYEE>();
        return L1;
    }
}