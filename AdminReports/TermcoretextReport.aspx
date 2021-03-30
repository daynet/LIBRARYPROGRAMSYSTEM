<%@ Page Title="" Language="C#" MasterPageFile="../Main.master" AutoEventWireup="true" CodeFile="TermcoretextReport.aspx.cs" Inherits="Page_TermcoretextReport" %>
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
                    Core Text and Reference Books Report
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style ="width:100%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table id="Table1" runat="server">
                        <tr>
                         
                            <td>
                                &nbsp;</td>
                         
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Term"></asp:Label>
                            </td>
                            <td>
                                
                                 <asp:DropDownList ID="drp_Semester" runat="server" CssClass="textBox11" 
                                     AppendDataBoundItems="true" Height="20px" Width="80px">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                                                        
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Program"></asp:Label>
                            </td>
                            <td>
                                
                                 <asp:DropDownList ID="Drpdegree" runat="server" CssClass="textBox11" 
                                     AppendDataBoundItems="true" Height="20px" Width="80px">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="BBA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MBA" Value="2"></asp:ListItem>
                                <asp:ListItem Text="SC" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                           <asp:RadioButtonList ID="rdotype" runat="Server" RepeatDirection="Horizontal">
                           <asp:ListItem Text="Core Text" Value="C" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="Reference" Value="T"></asp:ListItem>
                           </asp:RadioButtonList>
                            
                            </td>                            



                             <td align="right">
                                <asp:Button Text="Load Report" runat="server" ID="btnLoad" 
                                     onclick="btnLoad_Click" />
                            </td>
                            <td width="100px"></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
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

