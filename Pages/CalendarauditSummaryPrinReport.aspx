<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="CalendarauditSummaryPrinReport.aspx.cs"
    Inherits="Page_CalendarauditSummaryPrinReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
            PrintMode="ActiveX" EnableDrillDown="False" HasCrystalLogo="False" HasDrilldownTabs="False"
            HasDrillUpButton="False" HasSearchButton="False" HasToggleGroupTreeButton="False"
            HasToggleParameterPanelButton="False" ToolPanelView="None" />
    </div>
    </div>
    </form>
</body>
</html>
