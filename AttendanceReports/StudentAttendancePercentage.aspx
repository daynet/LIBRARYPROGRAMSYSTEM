<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master"   AutoEventWireup="true" CodeFile="StudentAttendancePercentage.aspx.cs" Inherits="Pages_StudentAttendancePercentage" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 44px;
        }
        .style2
        {
            width: 69px;
        }
        .style3
        {
            width: 78px;
        }
        .style4
        {
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Consolidated Attendance Percentage</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 97%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <asp:Panel ID="Pnl_Adm" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td class="style2">
                                    Academic Year
                                </td>
                                <td class="style1">
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="143px" onselectedindexchanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 40px">
                                    Semester
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlSem" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="139px" onselectedindexchanged="ddlSem_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 40px">
                                    Faculty
                                </td>
                                <td style="width: 150px">
                                    <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                    onselectedindexchanged="ddlFaculty_SelectedIndexChanged" Width="140px"   >
                                 
                                    </asp:DropDownList>
                                </td>                          
                            </tr>
                        </table>
                    </asp:Panel>

                    <table>
                        <tr>
                            <td class="style4">
                                Batch
                            </td>
                            <td style="width: 126px">
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="textBox11" Width="143px">
                                </asp:DropDownList>
                            </td>                            
                            <td class="style2" >
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From Date
                            </td>
                            <td style="width: 163px">
                                <asp:TextBox ID="txtfromDate" runat="server" CssClass="textBox1"></asp:TextBox>
                                <cc1:calendarextender ID="CalendarExtender1" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txtfromDate" Format="yyyy/MM/dd">
                                </cc1:calendarextender>
                            </td>
                               <td  >
                                To Date
                            </td>
                            <td  >
                                <asp:TextBox ID="txttodate" runat="server" CssClass="textBox1"></asp:TextBox>
                                <cc1:calendarextender ID="CalendarExtender2" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txttodate" Format="yyyy/MM/dd">
                                </cc1:calendarextender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style4">
                                <asp:Button ID="btnSearch" runat="server" Text="Load Report" OnClick="btnSearch_Click" />
                            </td>
                            <td colspan="2" >
                                <asp:Label ID="lbmsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
        <!--ended Div of Wrapping Form Fields Set-->
    </div>
    <div id="all-form-wrap">
        <asp:Panel ID="pnl" runat="server" ScrollBars="Both" Width="718px">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Width="718px"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
        </asp:Panel>
    </div>
</asp:Content>

