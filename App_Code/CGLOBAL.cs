using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


/// <summary>
/// Summary description for CGlobal
/// </summary>
public class CGLOBAL
{
    public static string vserver, vUserId, vPassword, vdatabase, vImagePath, vAtt;
    public CGLOBAL()
    {
    }

    public static string getConnectionString()
    {
        return "server=172.16.12.1;database=LPS;User ID=software;Password=DelFirMENA$idea;connect timeout=0";
    }
    public static string getNewConnectionString()
    {

        return "server=172.16.12.1;database=Payroll;User ID=software;Password=DelFirMENA$idea;connect timeout=0";
    }
    public static string getConnectionStringattendance()
    {
        return "server=172.16.12.1;database=Myfence;User ID=software;Password=DelFirMENA$idea;connect timeout=0";
    }

    public static string getAdminexamConnectionString()
    {
        return "server=172.16.12.1;database=Adminexam;User ID=software;Password=DelFirMENA$idea;connect timeout=0";
    }

    static string getProductURL()
    {
        return vImagePath;
    }


    static void getInfo()
    {
        System.Xml.XmlDocument oXML = new System.Xml.XmlDocument();
        //oXML.Load((Application.StartupPath + "\\info.xml"));
        System.Xml.XmlNode oNode = oXML.SelectSingleNode("//image_path");
        vImagePath = oNode.InnerText.ToString();
        oNode = oXML.SelectSingleNode("//server");
        vserver = oNode.InnerText.ToString();
        oNode = oXML.SelectSingleNode("//database");
        vdatabase = oNode.InnerText.ToString();
        oNode = oXML.SelectSingleNode("//userid");
        vUserId = oNode.InnerText.ToString();
        oNode = oXML.SelectSingleNode("//password");
        vPassword = oNode.InnerText.ToString();
        oNode = oXML.SelectSingleNode("//att");
        vAtt = oNode.InnerText.ToString();
    }
}