<%@ Page Title="" Language="C#"  MasterPageFile="../Main.master"  AutoEventWireup="true" CodeFile="AttendanceSheetBlank.aspx.cs" Inherits="AttendanceSheetBlank" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.min.js"> </script>
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
                    Attendance Details
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style ="width:100%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table id="Table1" runat="server" width="100%">
                        <tr>
                         <td>
                                <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpAcademicYear" AutoPostBack="true" runat="server" CssClass="textBox11"
                                    OnSelectedIndexChanged="DrpAcademicYear_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Term"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpTerm" runat="server" AutoPostBack="true" CssClass="textBox11"
                                    OnSelectedIndexChanged="DrpTerm_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 120px">
                                <asp:Label ID="Label5" runat="server" Text="Faculty"></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="drpFaculty" CssClass="textBox11" AutoPostBack="true" runat="server"
                                    OnSelectedIndexChanged="drpFaculty_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                           
                        </tr>
                        <tr>
                         <td>
                                Batch
                            </td>
                            <td>
                                <asp:DropDownList ID="drp_Batch" CssClass="textBox11" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Button Text="Load Report" runat="server" ID="btnLoad" OnClick="btnLoad_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
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
    </div>
    <div style="display: none;">
        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
            PrintMode="ActiveX" EnableDrillDown="False" HasCrystalLogo="False" HasDrilldownTabs="False"
            HasDrillUpButton="False" HasSearchButton="False" HasToggleGroupTreeButton="False"
            HasToggleParameterPanelButton="False" ToolPanelView="None" />
    </div>
</asp:Content>

