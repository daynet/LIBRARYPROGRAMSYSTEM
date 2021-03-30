<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FortNightlyReport.aspx.cs" Inherits="LibraryReports_FortNightlyReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
  <div id="Div1">
     <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                FORTNIGHTLY REPORTS
                </h2>
            </div>
          <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                 <%--  <table>
                   <tr>
                   <td >

                   <asp:RadioButtonList ID="RdbOption"  runat="server" CssClass="RdbClass"   RepeatDirection="Horizontal"  
                   onclick="changeRTR(this);">
                   <asp:ListItem Text="DATE WISE" Value="DATEWISE"></asp:ListItem>
                    <asp:ListItem Text="SEMESTER WISE" Value="SEMESTERWISE"></asp:ListItem>
                   </asp:RadioButtonList>
                 
                   </td>
                  
                   </tr>
                    </table>   --%>
                     <table>
                  <%-- <asp:Panel ID="PnlDate" runat="server" style="display:none">--%>
                  
                  <tr>
                   <td>
                      <asp:Label ID="lblReportOption" runat="server" Text="Report Option" ></asp:Label>
                     </td>
                     <td>
                       <asp:DropDownList ID="DrpReportOption" runat="server"  CssClass="textBox11" Width="200px" onchange="changeCursor()">
                       <asp:ListItem Text="BOOK ISSUANCE" Value="BOOK ISSUANCE"></asp:ListItem>
                       <asp:ListItem Text="BOOKS NOTCOLLECTED" Value="BOOKS NOTCOLLECTED"></asp:ListItem>
                       <asp:ListItem Text="BOOKS RETURN STATUS" Value="BOOKS RETURN STATUS"></asp:ListItem>
                       <asp:ListItem Text="BOOKS NOT RETURNED" Value="BOOKS NOT RETURNED"></asp:ListItem>
                       <asp:ListItem Text="ALL BOOKS UTILIZATION" Value="REFERENCE BOOKS UTILIZATION"></asp:ListItem>
                       <asp:ListItem Text="ALL BOOKS RETURN STATUS" Value="ALL BOOKS RETURN STATUS"></asp:ListItem>
                       <asp:ListItem Text="ALL BOOKS ISSUANCE STATUS" Value="ALL BOOKS ISSUANCE STATUS"></asp:ListItem>
                       <asp:ListItem Text="TRANSACTION DETAILS" Value="TRANSACTION DETAILS"></asp:ListItem>
                       </asp:DropDownList>
                     </td>
                  </tr>
                  <tr>
                   <td>
                      <asp:Label ID="lblProgram" runat="server" Text="Program"  ></asp:Label>
                     </td>
                      <td>
                       <asp:DropDownList ID="DrpProgram" runat="server" CssClass="textBox11" Width="100px">
                       <asp:ListItem Text="BBA" Value="1"></asp:ListItem>
                       <asp:ListItem Text="MBA" Value="6"></asp:ListItem>
                       <asp:ListItem Text="BSIT" Value="13"></asp:ListItem>
                       </asp:DropDownList>
                     </td>
                     <td>
                     <asp:Label ID="lblCurriculum" runat="server" Text="Curriculum"  ></asp:Label>
                     </td>
                     <td>
                     <asp:DropDownList ID="DrpCurriculum" runat="server" CssClass="textbox11"></asp:DropDownList>
                     </td>
                  </tr>
           
               <%--    </table>--%>
                     <%--</asp:Panel>--%>

                  <%-- <asp:Panel ID="PnlAyYear" runat="server" style="display:none">--%>
                  <%-- <table width="90%">--%>

                <tr >
                  <td>
                        <asp:Label ID="LblAyear" runat="server" Text="AC Year"></asp:Label>
                        
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpAyYear" runat="server" AutoPostBack="true"  CssClass="textBox11" Width="150px"
                             OnSelectedIndexChanged="DDLAY_SelectedIndexChanged" />
                    </td>
               
                    <td>
                        <asp:Label ID="LblSemester" runat="server" Text="Semester"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpSemester" runat="server"   CssClass="textBox11" Width="150px"/>
                    </td>
                     </tr>
                     <tr >
                   <td>
                   <asp:Label ID="lblFromdate" runat="server" Text="From Date"></asp:Label>
                   </td>
                   <td>
                   <asp:TextBox ID="TxtFromDate" runat="server" CssClass="textBox1"  Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtFromDateCalendarExtender" CssClass="MyCalendar" TargetControlID="TxtFromDate"
                    Format="dd/MM/yyyy" runat="server"></cc1:CalendarExtender>
                   </td>
                   <td>
                      <asp:Label ID="lblTodate" runat="server" Text="To Date"></asp:Label>
                  
                   </td>
                   <td>
                     <asp:TextBox ID="txtTodate" runat="server"  CssClass="textBox1" Width="100px"></asp:TextBox>
                      <cc1:CalendarExtender ID="txtTodateCalendarExtender1" CssClass="MyCalendar" TargetControlID="txtTodate"
                    Format="dd/MM/yyyy" runat="server"></cc1:CalendarExtender>
                   </td>
                   </tr>
                   <tr>
                   <td>
                    <asp:Label ID="lblUtilizationType" Text="User Type" runat="server"  Style="display: none"></asp:Label>
                   </td>
                   <td>
                    <asp:DropDownList ID="DrpUserType" runat="server"   Style="display: none">
                       <asp:ListItem Value="STUDENT" Text="STUDENT"></asp:ListItem>
                         <asp:ListItem Value="FACULTY" Text="STAFF/FACULTY"></asp:ListItem>
                     </asp:DropDownList>
               
                  </td>
                    <td>
                        <asp:Label ID="LblBookType" Text="Book Type" runat="server"  Style="display: none"></asp:Label>
                    </td>
                    <td>
                       <asp:DropDownList ID="DDLBookType" runat="server"   Style="display: none">
                        <asp:ListItem Value="ALL" Text="ALL"></asp:ListItem>
                         <asp:ListItem Value="RB" Text="REFERENCE BOOK"></asp:ListItem>
                         <asp:ListItem Value="MN" Text="MAGAZINE"></asp:ListItem>
                          <asp:ListItem Value="JR" Text="JOURNAL"></asp:ListItem>
                            <asp:ListItem Value="MB" Text="MBA REF BOOKS"></asp:ListItem>
                            <asp:ListItem Value="CD" Text="CD"></asp:ListItem>
                            <asp:ListItem Value="CG" Text="CITY & GUILDS"></asp:ListItem>
                            <asp:ListItem Value="EM" Text="EBOOKS MBA"></asp:ListItem>
                            <asp:ListItem Value="IS" Text="IELTS BOOK"></asp:ListItem>
                            <asp:ListItem Value="RNTBK" Text="RENTAL BOOK"></asp:ListItem>
                            <asp:ListItem Value="SC" Text="CIMA REF"></asp:ListItem>
                            <asp:ListItem Value="TFLBK" Text="TOEFL Book"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   </tr>
                   <tr>
                   <td>
                   <asp:CheckBox ID="ChkExportExcel" runat="server" Text="EXPORT EXCEL" 
                           AutoPostBack="true" oncheckedchanged="ChkExportExcel_CheckedChanged" />
                   </td>
                   </tr>
                   <tr>
                   <td>
                  <asp:Label ID="LblReportType"  runat="server" Text="Report Type" Visible="false"></asp:Label>
                   </td>
                   <td>
                   <asp:RadioButtonList ID="RdbReportOption" runat="server" RepeatDirection="Horizontal" Visible="false">
                    <asp:ListItem Text="DETAILS" Value="DETAILS"></asp:ListItem>
                   <asp:ListItem Text="STATISTICS" Value="STATISTICS"></asp:ListItem>
                  
                   </asp:RadioButtonList>
                 
                   </td>
                   </tr>
              <%--     </table>--%>
                    <%-- </asp:Panel>--%>
                     <%--<asp:Panel ID="PnlCommon" runat="server" style="display:none">--%>
                   <%--  <table   width="90%">--%>
                     <tr >
                    
                    
                     <td colspan="6">
                     <asp:Button ID="BtnLoad" runat="server"  Text="LOAD" onclick="BtnLoad_Click" OnClientClick="return ValidateField('Report');" />
                      <asp:Button ID="BtnExportExcel" runat="server"  Text="EXPORT EXCEL" OnClientClick="return ValidateField('Excel');"
                             onclick="BtnExportExcel_Click" />

                              <asp:Button ID="BtnExportStudentDetails" runat="server"  Text="EXPORT STUDENT DETAILS"
                               OnClientClick="return ValidateField('Excel');"
                             onclick="BtnExportStudentDetails_Click" />
                     </td>
                     </tr>
                   <%--  </asp:Panel>--%>
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
      <div id="Div2">
     <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
               DETAILS
                </h2>
            </div>
          <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                 <asp:GridView ID="GrvDetails" runat="server" Style="margin-left: 5px; margin-bottom: 10px;"
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
        <script type="text/javascript">

            //     function changeRTR(rbl) {
            //         //Get the selected value from radiobuttonlist
            //         var selectedvalue = $("#" + rbl.id + " input:radio:checked").val();
            //         if (selectedvalue == "DATEWISE") {
            //             //if so then show the controls
            //             document.getElementById('PnlDate').style.display = 'block';
            //             document.getElementById('PnlAyYear').style.display = 'none';
            //             document.getElementById('PnlCommon').style.display = 'block';
            //         }
            //          else if (selectedvalue == "SEMESTERWISE") {
            //             //if not then hide the controls
            //              document.getElementById('PnlDate').style.display = 'none';
            //              document.getElementById('PnlAyYear').style.display = 'block';
            //              document.getElementById('PnlCommon').style.display = 'block';
            //         
            //         }
            //     }

            (function () {
                changeCursor();
            })();
            function changeCursor() {
                var DrpReportOption = document.getElementById('<%=DrpReportOption.ClientID%>');
                if (DrpReportOption != null) {
                    //         alert(document.getElementById('<%=DrpReportOption.ClientID%>'));
                    if ((DrpReportOption.value == "REFERENCE BOOKS UTILIZATION")) 
                     {
                        document.getElementById('<%=lblUtilizationType.ClientID%>').style.display = 'block';
                        document.getElementById('<%=DrpUserType.ClientID%>').style.display = 'block';
                        document.getElementById('<%=LblBookType.ClientID%>').style.display = 'block';
                        document.getElementById('<%=DDLBookType.ClientID%>').style.display = 'block';

                        document.getElementById('<%=lblProgram.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpProgram.ClientID%>').style.display = 'none';
                        document.getElementById('<%=lblCurriculum.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpCurriculum.ClientID%>').style.display = 'none';

                        document.getElementById('<%=LblAyear.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpAyYear.ClientID%>').style.display = 'none';
                        document.getElementById('<%=LblSemester.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpSemester.ClientID%>').style.display = 'none';

                      
                    }
                    else if (DrpReportOption.value == "TRANSACTION DETAILS") 
                    {
                        document.getElementById('<%=lblUtilizationType.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpUserType.ClientID%>').style.display = 'none';
                        document.getElementById('<%=LblBookType.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DDLBookType.ClientID%>').style.display = 'none';

                        document.getElementById('<%=lblProgram.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpProgram.ClientID%>').style.display = 'none';
                        document.getElementById('<%=lblCurriculum.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpCurriculum.ClientID%>').style.display = 'none';

                        document.getElementById('<%=LblAyear.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpAyYear.ClientID%>').style.display = 'none';
                        document.getElementById('<%=LblSemester.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpSemester.ClientID%>').style.display = 'none';

                    }
                    else {
                        document.getElementById('<%=lblUtilizationType.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DrpUserType.ClientID%>').style.display = 'none';
                        document.getElementById('<%=LblBookType.ClientID%>').style.display = 'none';
                        document.getElementById('<%=DDLBookType.ClientID%>').style.display = 'none';

                        document.getElementById('<%=lblProgram.ClientID%>').style.display = 'block';
                        document.getElementById('<%=DrpProgram.ClientID%>').style.display = 'block';
                        document.getElementById('<%=lblCurriculum.ClientID%>').style.display = 'block';
                        document.getElementById('<%=DrpCurriculum.ClientID%>').style.display = 'block';

                        document.getElementById('<%=LblAyear.ClientID%>').style.display = 'block';
                        document.getElementById('<%=DrpAyYear.ClientID%>').style.display = 'block';
                        document.getElementById('<%=LblSemester.ClientID%>').style.display = 'block';
                        document.getElementById('<%=DrpSemester.ClientID%>').style.display = 'block';

                    }
                }


            }

            function ValidateField(type) {
                if (type == 'Report') {
                    if (!document.getElementById('<%=ChkExportExcel.ClientID%>').checked) {
                        return ValidateSpecialReports();
                    }
                }

                var DrpReportOption = document.getElementById('<%=DrpReportOption.ClientID%>');
                if (DrpReportOption != null) {
                    if (DrpReportOption.value == "BOOK ISSUANCE" || DrpReportOption.value == "BOOKS NOTCOLLECTED"
                  || DrpReportOption.value == "BOOKS RETURN STATUS" || DrpReportOption.value == "REFERENCE BOOKS UTILIZATION"
                  || DrpReportOption.value == "BOOKS NOT RETURNED" || DrpReportOption.value == "ALL BOOKS RETURN STATUS"
                  || DrpReportOption.value == "ALL BOOKS ISSUANCE STATUS" || DrpReportOption.value == "TRANSACTION DETAILS") {
                       
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
            function ValidateSpecialReports() {
                var DrpReportOption = document.getElementById('<%=DrpReportOption.ClientID%>');
                if (DrpReportOption != null) {
                    if (DrpReportOption.value == "ALL BOOKS RETURN STATUS") {
                        alert('Excel format is only available.!');
                        return false;
                    }

                    var DrpReportOption = document.getElementById('<%=DrpReportOption.ClientID%>');
                    if (DrpReportOption != null) {
                        if (DrpReportOption.value == "BOOK ISSUANCE" || DrpReportOption.value == "BOOKS NOTCOLLECTED"
                  || DrpReportOption.value == "BOOKS RETURN STATUS" || DrpReportOption.value == "REFERENCE BOOKS UTILIZATION"
                  || DrpReportOption.value == "BOOKS NOT RETURNED" || DrpReportOption.value == "ALL BOOKS RETURN STATUS"
                  || DrpReportOption.value == "ALL BOOKS ISSUANCE STATUS" || DrpReportOption.value == "TRANSACTION DETAILS") {

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
            }
        </script>
</asp:Content>

