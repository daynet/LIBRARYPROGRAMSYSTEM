<%@ Page Title="" Language="C#"  MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="StudentAttendancePercentageSession.aspx.cs" Inherits="Pages_StudentAttendancePercentage" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 43px;
        }
        .style2
        {
            width: 62px;
        }
        .style4
        {
            width: 66px;
        }
        .style14
        {
            width: 21px;
        }
        .style17
        {
            width: 40px;
        }
        .style21
        {
            width: 68px;
        }
        .style23
        {
            width: 54px;
        }
        .style24
        {
            width: 155px;
        }
        .style25
        {
            width: 57px;
        }
        .style26
        {
            width: 58px;
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
                    Consolidated Attendance Percentage Sessionwise</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 97%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <asp:Panel ID="Pnl_Adm" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td >
                                    Academic Year
                                </td>
                                <td >
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="143px" onselectedindexchanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Semester
                                </td>
                                <td >
                                    <asp:DropDownList ID="ddlSem" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="230px" onselectedindexchanged="ddlSem_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td >
                                    Faculty
                                </td>
                                <td >
                                    <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                    onselectedindexchanged="ddlFaculty_SelectedIndexChanged" Width="240px"   >
                                 
                                    </asp:DropDownList>
                                </td>                          
                            </tr>
                      <%--  </table>
                    
                    <table>--%>
                        <tr>
                            <td>
                                Batch </td>
                            <td>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="textBox11" 
                                    Width="143px" AutoPostBack ="true" 
                                    onselectedindexchanged="ddlClass_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </td>
                            <td >
                               FromDate
                            </td>
                            <td >
                                <asp:TextBox ID="txtfromDate" runat="server" CssClass="textBox1" Width="75px"></asp:TextBox>
                                <cc1:calendarextender ID="CalendarExtender1" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txtfromDate" Format="yyyy/MM/dd">
                                </cc1:calendarextender>
                                 &nbsp; &nbsp;
                                To Date
                                &nbsp; &nbsp;
                                <asp:TextBox ID="txttodate" runat="server" CssClass="textBox1"  Width="75px"></asp:TextBox>
                                <cc1:calendarextender ID="CalendarExtender2" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txttodate" Format="yyyy/MM/dd">
                                </cc1:calendarextender>
                            </td>
                              <td >
                                 Session
                            </td>
                            <td >
                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="textBox11" 
                                    Width="145px" onselectedindexchanged="ddlSession_SelectedIndexChanged"  >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                  <%--  <asp:ListItem Value="1">Session  0%</asp:ListItem>
                                    <asp:ListItem Value="2">Session 1-25% </asp:ListItem>
                                    <asp:ListItem Value="3">Session 26-50%</asp:ListItem>
                                    <asp:ListItem Value="4">Session 51-75%</asp:ListItem>
                                    <asp:ListItem Value="5">Session 76-99%</asp:ListItem>
                                    <asp:ListItem Value="6">Session 100%</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                                           
                        </tr>
                   <%-- </table>
                    <table>--%>
                        <tr>
                         <td>
                                <asp:Button ID="btnSearch" runat="server" Text="LOAD REPORT" OnClick="btnSearch_Click" />
                            </td>   
                     
                            <td ></td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td colspan="2">
                                <asp:Label ID="lbmsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
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
        <asp:Panel ID="pnl" runat="server" ScrollBars="Both" Width="1118px">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Width="1118px"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
        </asp:Panel>
    </div>

</asp:Content>

