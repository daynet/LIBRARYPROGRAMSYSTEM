<%@ Page Title="" Language="C#"  MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="RelativeAttendance.aspx.cs" Inherits="Pages_RelativeAttendance" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <style type="text/css">
        .style2
        {
            width: 158px;
        }
        .style4
        {
            width: 161px;
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
                   Attendance Report</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 97%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->

                    <asp:Panel ID="Pnl_Adm" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" >
                            <tr>
                                <td><asp:Label ID="lblYear" runat="server">Academic Year &nbsp;</asp:Label>
                                
                                </td>
                                <td class="style4" >
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="143px" onselectedindexchanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td><asp:Label ID="Label1"   runat="server">Semester &nbsp;&nbsp;&nbsp;</asp:Label>
                                
                                </td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddlSem" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                        Width="140px" onselectedindexchanged="ddlSem_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td><asp:Label ID="Label2"   runat="server">Faculty</asp:Label>
                                
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlFaculty" runat="server" CssClass="textBox11" AutoPostBack ="true"  
                                    onselectedindexchanged="ddlFaculty_SelectedIndexChanged" Width="140px"   >
                                 
                                    </asp:DropDownList>
                                </td>  
                            </tr>
                        </table>
                    </asp:Panel>
                       
                     <table>
                        <tr>
                            <td>
                                Batch </td>
                            <td>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="textBox11" 
                                    Width="143px" >
                                </asp:DropDownList>
                            </td>
                            <td >
                               FromDate
                            </td>
                            <td>
                                <asp:TextBox ID="txtfromDate" runat="server" CssClass="textBox1" Width="140px"></asp:TextBox>
                                <cc1:calendarextender ID="CalendarExtender1" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txtfromDate" Format="yyyy/MM/dd">
                                </cc1:calendarextender>
                            </td>
                             <td>
                                To Date
                            </td>
                            <td  >
                                <asp:TextBox ID="txttodate" runat="server" CssClass="textBox1" Width="140px"></asp:TextBox>
                                <cc1:calendarextender ID="CalendarExtender2" CssClass="MyCalendar" runat="server"
                                    TargetControlID="txttodate" Format="yyyy/MM/dd">
                                </cc1:calendarextender>
                            </td>                            
                        </tr>
                       
                        <tr>                        
                            <td>
                               -Ve (%)  
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNSym" runat="server" CssClass="textBox11" Width="70px">
                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="=" Value="="></asp:ListItem>
                                    <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                                    <asp:ListItem Text=">=" Value=">="></asp:ListItem>                                    
                                </asp:DropDownList>
                                <asp:TextBox ID="txtNatt" runat="server" Width="65px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FteNatt" runat="server" TargetControlID="txtNatt" FilterType="Numbers"></cc1:FilteredTextBoxExtender>                            </td>

                            <td>
                               RATD (%)  
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRSym" runat="server" CssClass="textBox11" Width="70px">
                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="=" Value="="></asp:ListItem>
                                    <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                                    <asp:ListItem Text=">=" Value=">="></asp:ListItem>                                    
                                </asp:DropDownList> 
                                <asp:TextBox ID="txtRatt" runat="server" Width="65px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FteRatt" runat="server" TargetControlID="txtRatt" FilterType="Numbers"></cc1:FilteredTextBoxExtender>                           

                            </td>
                            <td>
                               ATD (%)  
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlASym" runat="server" CssClass="textBox11" Width="70px">
                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="=" Value="="></asp:ListItem>
                                    <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                                    <asp:ListItem Text=">=" Value=">="></asp:ListItem>                                    
                                </asp:DropDownList> 
                                <asp:TextBox ID="txtAtd" runat="server" Width="65px"  ></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FteAtd" runat="server" TargetControlID="txtAtd" FilterType="Numbers"></cc1:FilteredTextBoxExtender>                           
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ChkStudent" runat="server" Text="Student ID" AutoPostBack="true" OnCheckedChanged="ChkStudent_CheckedChanged"/>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtStud" runat="server" Width="140px"  ></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnSearch" runat="server" Text="Load Report" OnClick="btnSearch_Click" />
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
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Width="718px"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
        </asp:Panel>
    </div>
</asp:Content>

