<%@ Page Title="" Language="C#" MasterPageFile="../Main.master"  AutoEventWireup="true" CodeFile="ClassAttendanceVB.aspx.cs" Inherits="Pages_ClassAttendanceVB" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 135px;
        }
        .style2
        {
            width: 51px;
        }
        .style3
        {
            width: 103px;
        }
        .style6
        {
            width: 40px;
        }
        .style7
        {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Batch Attendance</h2>
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
                            <td class="style2">
                                Batch
                            </td>
                            <td class="style1">
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                    Width="143px" onselectedindexchanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td class="style7">
                                &nbsp;&nbsp;&nbsp;
                                Date
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="textBox1"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txtDate" Format="yyyy/MM/dd">
                                </cc1:CalendarExtender>
                            </td>
                            <td class="style6">Session</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="textBox11" 
                                    Width="114px"   >
                                 
                                </asp:DropDownList>
                            </td>

                          
                        </tr>
                        <tr>
                        <td class="style2">
                          <td class="style1">
                                <asp:Button ID="btnSearch" runat="server" Text="Load Report" OnClick="btnSearch_Click" />
                            </td>
                        </td>
                        </tr>
                        <tr>
                            <td class="style2">
                            </td>
                            <td colspan="2">
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
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
    </div>
</asp:Content>