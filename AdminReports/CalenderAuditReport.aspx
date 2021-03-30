<%@ Page Title="" Language="C#" MasterPageFile="../Main.master"  AutoEventWireup="true" CodeFile="CalenderAuditReport.aspx.cs" 
 Inherits="Page_CalenderAuditReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="all-form-wrap">
    <!--Div Started to Wrapping all Forms Fields-->
    <div class="form-fieldset-wrapper">
        <!--Start Div To Wrapping Form Fields Set-->
        <div class="form-fieldset-wrapper-top-left">
        </div>
        <div class="form-fieldset-wrapper-top-page">
            <!--Div for the form fieldset wrapper top rounded part-->
            <h2>
                Calender Audit Report
            </h2>
        </div>
        <div class="form-fieldset-wrapper-top-right">
        </div>
        <!--ended Div of Form fieldset wrapper top rounded part-->
        <div class="form-fieldset-wrapper-mid">
            <!--Div for the form fieldset wrapper middle part for the left and right border-->
            <div class="form-fieldset-wrapper-mid-inner9" style ="width:100%">
                <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                
                <table id="Table1" runat="server" width="100%" cellspacing="5" cellpadding="5">
                    <tr>
                    <td>
                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpYear" runat="server" CssClass="textBox11">
                            </asp:DropDownList>
                        </td>      
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Semester"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpSem" runat="server" CssClass="textBox11">
                            </asp:DropDownList>
                        </td>                                        
                    </tr>        
                     <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_types" runat="server" CssClass="textBox11">
                            </asp:DropDownList>
                        </td>                                        
                    </tr>  
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_category" runat="server" CssClass="textBox11">
                            </asp:DropDownList>
                        </td>                                        
                    </tr>                    
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btn_Summary" runat="server" Text="Summary Details"  OnClick="btn_SummaryClick" />                             
                            <asp:Button ID="btncummulative" runat="server" Text="Cummulative Report"  OnClick="btncummulativereport_click" />  
                            <asp:Button ID="btndetails" runat="server" Text="Details Report"  OnClick="btnDetailsreport_click" />
                            <asp:Button ID="btnAcademic" runat="server" Text="View Report"  OnClick="btnviewreport_click" />   
                        </td>                                                
                    </tr>
                </table>
            </div>
            <!--form fieldset wrapper mid inner ended-->
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <div class="form-fieldset-wrapper-bottom-left">
        </div>
        <div class="form-fieldset-wrapper-bottom-page">
        </div>
        <div class="form-fieldset-wrapper-bottom-right">
        </div>
        <!--Div started for the form fieldset wrapper bottom founded-->
    </div>
    <!--ended Div of Wrapping Form Fields Set-->
     <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
        PrintMode="ActiveX" />
    </div>
</asp:Content>

