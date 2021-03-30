<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="StudentAttendance.aspx.cs" Inherits="Pages_StudentAttendance" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Consolidated Attendance</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 97%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <asp:Panel ID="Pnl_Adm" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td style="width: 55px">
                                    Academic Year
                                </td>
                                <td style="width: 44px">
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="143px" onselectedindexchanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 40px">
                                    Semester
                                </td>
                                <td style="width: 63px">
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
                            <td style="width: 65px" >
                                Batch
                            </td>
                            <td style="width: 166px" >
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="textBox11" Width="143px">
                                </asp:DropDownList>
                            </td>
                      <%--      <td style="width: 41px">
                                Month
                            </td>
                            <td style="width: 90px">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="textBox11" Width="80px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="2014/01/01">Jan 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/02/01">Feb 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/03/01">Mar 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/04/01">Apr 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/05/01">May 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/06/01">Jun 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/07/01">Jul 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/08/01">Aug 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/09/01">Sep 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/10/01">Oct 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/11/01">Nov 2014</asp:ListItem>
                                    <asp:ListItem Value="2014/12/01">Dec 2014</asp:ListItem>
                                    <asp:ListItem Value="2015/01/01">Jan 2015</asp:ListItem>
                                    <asp:ListItem Value="2015/02/01">Feb 2015</asp:ListItem>
                                    <asp:ListItem Value="2015/03/01">Mar 2015</asp:ListItem>
                                    <asp:ListItem Value="2015/04/01">Apr 2015</asp:ListItem>
                                </asp:DropDownList>
                            </td>--%>
                               <td style="width: 57px" >
                                From Date
                            </td>
                            <td style="width: 163px">
                                <asp:TextBox ID="txtfromDate" runat="server" CssClass="textBox1"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txtfromDate" Format="yyyy/MM/dd">
                                </cc1:CalendarExtender>
                            </td>
                               <td  >
                                To Date
                            </td>
                            <td  >
                                <asp:TextBox ID="txttodate" runat="server" CssClass="textBox1"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txttodate" Format="yyyy/MM/dd">
                                </cc1:CalendarExtender>
                            </td>
                          
                        </tr>
                        <tr>
                        <td style="width: 65px">
                        </td>
                          <td  style="width: 166px">
                                <asp:Button ID="btnSearch" runat="server" Text="Load Report" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 65px">
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
        <asp:Panel ID="pnl" runat="server" ScrollBars="Both" Width="718px">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
        </asp:Panel>
    </div>
</asp:Content>
