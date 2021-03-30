<%@ Page Title="Skyline : Print Offline" Language="C#" 
    AutoEventWireup="true" CodeFile="PrintClient.aspx.cs" Inherits="Pages_PrintClient" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

    <html>
    <head >
    <title></title>
    </head>
    <body >
    <div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                       PrintMode="ActiveX" EnableDrillDown="False" 
           HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False" 
           HasSearchButton="False" HasToggleGroupTreeButton="False" 
           HasToggleParameterPanelButton="False" ToolPanelView="None" />
    </div>
    </body>
    </html>
