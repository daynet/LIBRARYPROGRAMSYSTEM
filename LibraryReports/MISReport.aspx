<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="MISReport.aspx.cs" Inherits="LibraryReports_MISReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<style type="text/css">
.textbox111
{
    background-color: #FFF;
    border: 1px solid #82AFD9;
    font-family: Tahoma;
    font-size: 11px;
    height: 21px;
    width: 250px;
    text-transform: uppercase;
}
</style>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Div1">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    MIS Reports
                </h2>
            </div>
            <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table id="Table1" runat="server" width="100%">
                        <tr>
                        <td style="width:10%"> <asp:Label ID="Label5" runat="server" Text="Report Option: "></asp:Label></td>
                        <td> <asp:DropDownList ID="DrpReportOption" runat="server"  CssClass="textBox11" onchange="HideAndShow()">
                       <asp:ListItem Text="CANCELLED STUDENTS" Selected="True" Value="CANCELLED STUDENTS"></asp:ListItem>
                       <asp:ListItem Text="BOOK VALIDITY" Value="BOOK VALIDITY"></asp:ListItem>  
                       <asp:ListItem Text="BOOK ISSUE SUMMARY" Value="BOOK ISSUE SUMMARY"></asp:ListItem>
                       <asp:ListItem Text="BOOKS NOT COLLECTED STATISTICS" Value="BOOKS NOT COLLECTED STATISTICS"></asp:ListItem>  
                       </asp:DropDownList></td>
                           <%-- <td style="width:15%">
                                <asp:RadioButton ID="RbtCancelledStudent" Text="Cancelled Students" GroupName="MIS"
                                    runat="server" Checked="true" onClick="HideAndShow()" />
                            </td>
                            <td colspan="3">
                                <asp:RadioButton ID="RbtBookValidity" Text="Book Validity" GroupName="MIS" runat="server"
                                    onClick="HideAndShow()" />
                            </td>--%>
                        </tr>
                        </table>

                        <table id="Table2" runat="server" width="100%">
                        <tr>
                            <td style="width:10%">
                                <asp:Label ID="lblSchool" runat="server" Text="School: "></asp:Label>
                                <asp:Label ID="lblSemester" runat="server" Text="Semester: " Style="display:none;"></asp:Label>
                            </td>
                            <td style="padding-left: 8px;">
                                <asp:DropDownList ID="ddlSchools" AutoPostBack="true" runat="server" CssClass="textBox11"
                                    OnSelectedIndexChanged="ddlSchools_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlSemester" runat="server" CssClass="textBox11" Style="display:none;">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 8%;padding-left: 5px;">
                                <asp:Label ID="Label4" runat="server" Text="Program: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDegreeType" AutoPostBack="true" runat="server" CssClass="textBox11" 
                                OnSelectedIndexChanged="ddlDegreeType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 8%;padding-left: 5px;">
                                <asp:Label ID="lblDegreeCode" runat="server" Text="Degree Code: " ></asp:Label>
                                <asp:Label ID="lblCurriculum" runat="server" Text="Curriculum: " Style="display:none;" ></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDegreeCode" runat="server" CssClass="textBox11">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCurriculum" runat="server" CssClass="textbox111" Style="display:none;">
                                </asp:DropDownList>
                            </td>                         
                        </tr> 
                        <tr>
                            <td style="width:10%">
                                <asp:Label ID="lblFromdate" runat="server" Text="From Date: "></asp:Label>
                            </td>
                            <td style="padding-left: 8px;">
                                <asp:TextBox ID="TxtFromDate" runat="server" CssClass="textBox1" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtFromDateCalendarExtender" CssClass="MyCalendar" TargetControlID="TxtFromDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="width: 8%;padding-left: 5px;">
                                <asp:Label ID="lblTodate" runat="server" Text="To Date: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTodate" runat="server" CssClass="textBox1" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtTodateCalendarExtender1" CssClass="MyCalendar" TargetControlID="txtTodate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                            </td>   
                                  
                        </tr>                        
                       </table>
                       <table id="Table3" runat="server" width="100%"  style="display:none">
                        <tr>
                              <td style="width:28%">
                                <asp:Label ID="Label3" runat="server" Text="Copy right: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCopyrightFromDate" runat="server" CssClass="textBox11">
                                </asp:DropDownList>
                            </td> 
                                      
                        </tr>
                       </table>

                       <table id="Table4" runat="server" width="100%">
                        <tr>
                            <td style="width:10%">
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkExportExcel" onClick="LoadOrExcel();" runat="server" Text="EXPORT EXCEL" />
                            </td>                                                  
                        </tr>
                        <tr>
                        <td style="width:10%">
                                &nbsp;
                            </td>
                        <td align="left">
                                <asp:Button Text="Load Report" runat="server" ID="btnLoad" OnClick="btnLoad_Click" OnClientClick="return ValidateField();" />
                                <asp:Button Text="Export Excel" runat="server" ID="btnExcel" style="display:none" OnClick="btnExcel_Click" OnClientClick="return ValidateField();" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:10%">
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
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
    <asp:GridView ID="GrvDetails" runat="server" Visible="false" Style="margin-left: 5px; margin-bottom: 10px;"
                            Width="100%"  >
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# ((GridViewRow)Container).RowIndex + 1%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
    <script type ="text/javascript" >

        function HideAndShow() {

                var DrpReportOption = document.getElementById('<%=DrpReportOption.ClientID%>');
                if (DrpReportOption != null) {
                    if (DrpReportOption.value == "CANCELLED STUDENTS" || DrpReportOption.value == "BOOK ISSUE SUMMARY"
                    || DrpReportOption.value == "BOOKS NOT COLLECTED STATISTICS") {
                        document.getElementById('MainContent_Table2').style.display = 'inline';
                        document.getElementById('MainContent_Table3').style.display = 'none';

                        if (DrpReportOption.value == "CANCELLED STUDENTS") {
                            document.getElementById('MainContent_lblDegreeCode').style.display = 'inline';
                            document.getElementById('MainContent_ddlDegreeCode').style.display = 'inline';
                            document.getElementById('MainContent_lblSchool').style.display = 'inline';
                            document.getElementById('MainContent_ddlSchools').style.display = 'inline';
                            document.getElementById('MainContent_lblCurriculum').style.display = 'none';
                            document.getElementById('MainContent_ddlCurriculum').style.display = 'none';
                            document.getElementById('MainContent_lblSemester').style.display = 'none';
                            document.getElementById('MainContent_ddlSemester').style.display = 'none';
                        }
                        else if (DrpReportOption.value == "BOOK ISSUE SUMMARY" || DrpReportOption.value == "BOOKS NOT COLLECTED STATISTICS"
                         || DrpReportOption.value == "BOOK ISSUANCE") {
                            document.getElementById('MainContent_lblDegreeCode').style.display = 'none';
                            document.getElementById('MainContent_ddlDegreeCode').style.display = 'none';
                            document.getElementById('MainContent_lblCurriculum').style.display = 'inline';
                            document.getElementById('MainContent_ddlCurriculum').style.display = 'inline';
                            document.getElementById('MainContent_lblSchool').style.display = 'inline';
                            document.getElementById('MainContent_ddlSchools').style.display = 'inline';

                           
                            var select = document.getElementById('MainContent_ddlDegreeType');

                            for (i = 0; i < select.length; i++) {
                                if (select.options[i].value == '9') {
                                    select.remove(i);
                                }
                            }
                        }

                    } else {
                        document.getElementById('MainContent_Table2').style.display = 'none';
                        document.getElementById('MainContent_Table3').style.display = 'inline';
                    }
                }
            }

        function LoadOrExcel() {            
                if (document.getElementById('<%=ChkExportExcel.ClientID%>').checked) {
                    document.getElementById('MainContent_btnLoad').style.display = 'none';
                    document.getElementById('MainContent_btnExcel').style.display = 'inline';
                } else {
                    document.getElementById('MainContent_btnLoad').style.display = 'inline';
                    document.getElementById('MainContent_btnExcel').style.display = 'none';
                }                    
        }

        function ValidateField() {
             var DrpReportOption = document.getElementById('<%=DrpReportOption.ClientID%>');
             if (DrpReportOption != null) {
                 if (DrpReportOption.value == "CANCELLED STUDENTS" || DrpReportOption.value == "BOOK ISSUE SUMMARY"
                  || DrpReportOption.value == "BOOKS NOT COLLECTED STATISTICS") {
                     if (document.getElementById('<%=TxtFromDate.ClientID%>').value == "") {
                         alert('Please Select From Date.!');
                         return false;
                     }
                     else if (document.getElementById('<%=txtTodate.ClientID%>').value == "") {
                         alert('Please Select To Date.!');
                         return false;
                     }
                     else {
                         return true;
                     }
                 }
             }
        }
</script>
</asp:Content>
