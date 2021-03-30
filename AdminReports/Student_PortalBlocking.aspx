<%@ Page Title="" Language="C#"  MasterPageFile="../Main.master"  AutoEventWireup="true"
    CodeFile="Student_PortalBlocking.aspx.cs" Inherits="Page_Student_PortalBlocking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function shopPopup() {
            var modalPopupExtender = $find('ModalPopupExtenderBehavior');
            modalPopupExtender.show();
        }
        function hidePopup() {
            var modalPopupExtender = $find('ModalPopupExtenderBehavior');
            modalPopupExtender.hide();
        }

        function ChkSelectallClick(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.GrvExportExcelDetails.ClientID %>');
            var TargetChildControl = "chkSelect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
            CheckBoxCount();
        }


        function CheckBoxCount() {
            return;
        }
    </script>
    <style type="text/css">
    .GridviewDiv {font-size: 11px;  font-weight: normal; font-family: 'tahoma'; color: #303933;}
    Table.Gridview{border:solid 1px #003964;}
    .Gridview th{color:white;border-right-color:#003964;border-bottom-color:#003964;padding:0.5em 0.5em 0.5em 0.5em;text-align:center}  
    .Gridview td{border-bottom-color:#003964;border-right-color:#003964;padding:0.5em 0.5em 0.5em 0.5em;}
    .Gridview tr{color: Black; background-color:#D3D3D3; text-align:left}
    :link,:visited { color: #DF4F13; text-decoration:none }
    .highlight {text-decoration: none;color:black;background:yellow;}
    .buttonface{ text-align:center;}
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent"  runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top-left">
            </div>
            <div class="form-fieldset-wrapper-top-page">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Portal Block Update
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style ="width:100%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
               
                    <table>
                        <tr>
                            <td>
                                Student ID
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStudID" runat="server" Height="17px" Text="" CssClass="textBox1"
                                    OnTextChanged="txtStudID_TextChanged" Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="btnSearchStudent" ImageUrl="~/Icons/search.gif" runat="server"
                                    OnClick="btnSearchStudent_Click" />
                            </td>
                            <td>
                                Login ID
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLogin" runat="server" Height="17px" Text="" Width="100px" CssClass="textBox1"
                                    ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                Student Name
                            </td>
                            <td align="left">
                           
                            <asp:TextBox ID="txtname" runat="server" Height="17px" Text="" Width="300px" CssClass="textBox1"
                                ReadOnly="true"></asp:TextBox> </td>
                           
                        </tr>
                        <tr>
                            <td>
                                Remarks
                            </td>
                            <td colspan="6">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBox11" Width="800px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="5">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="ChkFin" runat="server" Text="FinanceBlock" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkLib" runat="server" Text="LibraryBlock" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkAdm" runat="server" Text="AdminBlock" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkSSD" runat="server" Text="SSDBlock" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkHrd" runat="server" Text="HRDBlock" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                             <td>
                                <asp:Button ID="btnUpdate" runat="server" CssClass="" Text="UPDATE" Width="80px"
                                    OnClick="btnUpdate_Click" />
                            </td>
                        </tr>
                        <tr>
                        <td>
                        <asp:Label ID="lblBlockedReason" runat="server" Text=" Blocked Reason" Visible="false"></asp:Label>
                       
                        </td>
                          <td colspan="6">
                            <asp:TextBox ID="txtReason" runat="server" CssClass="textBox11" Width="800px" TextMode="MultiLine" Enabled="false" Visible="false"></asp:TextBox>
                            </td>
                        <td>
                        
                        </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" style="color:Blue;">
                                Note : If Tick is marked it is blocked, student unable to access portal<br />
                                If Un-tick is marked it is not blocked, student can access the portal services
                            </td>
                            <asp:Panel ID="PnlInstructions" runat="server" Visible="false" >
                            <td rowspan="3" colspan="2"   >
                        <table >
                        <tr>
                         <td  style=" color:Blue;">BULK BLOCKING INSTRUCTIONS FOR USER:</td></tr>
                         <tr> <td style=" color:Blue;">1. Excel file should contain 2 columns only Stud_ID & Remarks.</td></tr>
                         <tr> <td style=" color:Blue;">2. Excel Sheet name must be Sheet1</td> </tr>
                         <tr> <td style=" color:Blue;">3. Stud_ID column must be formatted as text field</td> </tr>
                         <tr> <td style=" color:Blue;">4. Download the sample excel file.
                         <asp:Button ID="BtnDownLoad" runat="server" Text="Download" 
                                 onclick="BtnDownLoad_Click" />
                                 
                                 <asp:GridView ID="GrvGrid" runat="server" BackColor="White" BorderColor="#999999"   
          BorderStyle="None" font-Size="X-Small" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  Visible="false" >
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle   Width="10px"   />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />  
                           
                        </asp:GridView>  
                                 
                                 </td></tr>
                        </table>
                    
                        </td>
                        </asp:Panel>
                        </tr>
                        <tr>
                        <td>
                        <asp:CheckBox ID="ChkIsBulkBlock" runat="server" Text="IS BULK BLOCK" 
                                oncheckedchanged="ChkIsBulkBlock_CheckedChanged" AutoPostBack="true" />
                        </td>
                        </tr>
                         <tr>
                         <asp:Panel ID="PnlBulkBlockDetails" runat="server"  Visible="false">
                          <td>
                     <asp:Label ID="lblUpload" runat="server" Text="File to Upload" ></asp:Label>
                     </td>
                     <td colspan="3">
                      <asp:FileUpload ID="flStudentList" runat="server" />
                     </td>
                         <td>
                        <asp:Button ID="BtnLoad" runat="server" Text="Load Data" onclick="BtnLoad_Click" />
                        </td>
                 </asp:Panel>
                     </tr>
                        <tr>
                            <td colspan="6"  align="center">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
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
    <asp:Panel ID="pnlSearch" runat="server" Style="display: none;" Visible="true">
        <div style="background-color: #E3E2E3 !important; padding-left: 7px; padding-top: 7px;
            float: left; width: 722px;">
            <asp:ImageButton ID="BtnClose" runat="server" ImageUrl="~/images/cross.png" CausesValidation="false"
                OnClick="btnClose_click" Style="float: left" />
            <div id="all-form-wrap2">
                <!--Div Started to Wrapping all Forms Fields-->
                <div class="form-fieldset-wrapper">
                    <!--Start Div To Wrapping Form Fields Set-->
                    <div class="form-fieldset-wrapper-top-small">
                        <!--Div for the form fieldset wrapper top rounded part-->
                        <h2>
                            Search Student
                        </h2>
                    </div>
                    <!--ended Div of Form fieldset wrapper top rounded part-->
                    <div class="form-fieldset-wrapper-mid-small">
                        <!--Div for the form fieldset wrapper middle part for the left and right border-->
                        <div class="form-fieldset-wrapper-mid-inner9">
                            <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                            <%--
<div class="GridviewDiv">--%>
                            <p>
                                <b>Search :</b>
                                <asp:TextBox ID="txtSearch" runat="server" Width="350" AutoPostBack="true" Font-Names="tahoma"
                                    OnTextChanged="txtSearch_TextChanged" />&nbsp;&nbsp;
                                <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true"
                                    OnCheckedChanged="chkall_checkedchanged" />
                                <asp:ImageButton ID="ImageButton1" BackColor="ActiveCaption" runat="server" AlternateText="Search"
                                    Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                                <asp:ImageButton ID="btnClear" BackColor="ActiveCaption" runat="server" AlternateText="Clear"
                                    Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnClear_Click" />
                                &nbsp;&nbsp;
                                <br />
                            </p>
                            <div>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                AllowSorting="True" DataSourceID="dsDetails" Width="700px" OnRowCommand="gvDetails_RowCommand"
                                                CssClass="Gridview" ForeColor="#003964" PageSize="20" OnPageIndexChanging="OnPageIndexChanging">
                                                <HeaderStyle BackColor="#003964" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Student ID" ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkSTud_ID" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Stud_Id") %>'
                                                                ForeColor="Blue" Font-Underline="true" Width="90%" Text='<%# HighlightText(Eval("Stud_Id").ToString()) %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" Text='<%# HighlightText(Eval("Name").ToString()) %>' runat="server"
                                                                Width="90%" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Term Name" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTermName" Text='<%# HighlightText(Eval("TermName").ToString()) %>'
                                                                runat="server" Width="90%" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Degree" ItemStyle-Width="40%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDeg" Text='<%# HighlightText(Eval("degreeCode").ToString()) %>'
                                                                runat="server" Width="90%" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Shift" ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblShiftname" Text='<%# HighlightText(Eval("Shiftname").ToString()) %>'
                                                                runat="server" Width="90%" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--</div>--%>
                            <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CDBConnectionString2 %>" 
        SelectCommand="sp_displayrecords" SelectCommandType="StoredProcedure" FilterExpression="Name LIKE '%{0}%'">>
        <FilterParameters>
<asp:ControlParameter Name="Name" ControlID="txtSearch" PropertyName="Text" />
</FilterParameters
    </asp:SqlDataSource>--%>
                            <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:AdminExam %>"
                                SelectCommand="sp_displayrecords_DebitEntry" UpdateCommand="sp_displayrecords_DebitEntry"
                                UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure" FilterExpression="Stud_Id LIKE '%{0}%' or RegisterID LIKE '%{0}%' or Name LIKE '%{0}%'  or TermName LIKE '%{0}%' or  Degreecode LIKE '%{0}%' or  Shiftname LIKE '%{0}%' ">
                                <FilterParameters>
                                    <asp:ControlParameter Name="Name" ControlID="txtSearch" PropertyName="Text" />
                                    <asp:ControlParameter Name="TermName" ControlID="txtSearch" PropertyName="Text" />
                                    <asp:ControlParameter Name="Degreecode" ControlID="txtSearch" PropertyName="Text" />
                                    <asp:ControlParameter Name="Shiftname" ControlID="txtSearch" PropertyName="Text" />
                                    <asp:ControlParameter Name="RegisterID" ControlID="txtSearch" PropertyName="Text" />
                                    <%--<asp:ControlParameter Name="AttendedBy" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="Emailid" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="LastName" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="CallDate1" ControlID="txtSearch" PropertyName="Text" />--%>
                                </FilterParameters>
                            </asp:SqlDataSource>
                        </div>
                        <!--form fieldset wrapper mid inner ended-->
                    </div>
                    <!--Ended Div of form fieldset wrapper middle part of left and right border-->
                    <div class="form-fieldset-wrapper-bottom-small">
                    </div>
                    <!--Div started for the form fieldset wrapper bottom founded-->
                </div>
                <!--ended Div of Wrapping Form Fields Set-->
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hdDummy" runat="server" />
    <ajax:ModalPopupExtender ID="ME1" runat="server" BehaviorID="ModalPopupExtenderBehavior"
        TargetControlID="hdDummy" PopupControlID="pnlSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
        BackgroundCssClass="modalBackground" X="320" Y="20">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="PnlStudentDetails" runat="server" Visible="false">
    <div id="Div1">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top-left">
            </div>
            <div class="form-fieldset-wrapper-top-page">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Student Details
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <%-- <div style="overflow: auto;  height: 110px; Width:1021px">--%>

                     <asp:GridView ID="GrvExportExcelDetails"  AllowSorting="True" EmptyDataText="No Records Found." 
                        AutoGenerateColumns="False" runat="server" Width="100%" Visible="false"
                       >
                     
                        <RowStyle CssClass="GridItem" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                        <SelectedRowStyle CssClass="GridRowOver" />
                        <EditRowStyle />
                        <AlternatingRowStyle CssClass="GridAltItem" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Stud ID" >
                                <ItemTemplate>
                                    <asp:Label ID="lblStud_ID" runat="server" Text='<%#Eval("Stud_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="login ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblLogin" runat="server" Text='<%#Eval("login_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name" >
                                <ItemTemplate>
                                    <asp:Label ID="lblStudent_Name" runat="server" Text='<%#Eval("Student_Name")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="DegreeCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDegreeCode" runat="server" Text='<%#Eval("DegreeCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Shift" >
                                <ItemTemplate>
                                    <asp:Label ID="lblShift" runat="server" Text='<%#Eval("Shift")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtRemarks"  runat="server" Text='<%#Eval("Remarks")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                              <asp:TemplateField >

                                    <HeaderTemplate>
                                           <asp:CheckBox  HeaderText="Select" ID="chkSelectALL"  Text="Select" runat="server"  Checked="true" onclick="javascript:ChkSelectallClick(this);"  />
                                    </HeaderTemplate> 

                                <ItemTemplate>                                    
                                    <asp:CheckBox ID="chkSelect" runat="server" Checked="true" />
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                              
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
  </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
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
    </asp:Panel>
    <asp:Panel ID="PnlNotUploadedStudents" runat="server" Visible="false">
    <div id="Div4">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top-left">
            </div>
            <div class="form-fieldset-wrapper-top-page">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Not Uploaded From Excel
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <%-- <div style="overflow: auto;  height: 110px; Width:1021px">--%>
                      <asp:GridView ID="GrvNotUploaded" runat="server" Width="914px">
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="GridRowOver" />
                        <AlternatingRowStyle CssClass="GridAltItem" />
                        <PagerStyle CssClass="grid-pagination" />
                    </asp:GridView>

                     </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
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
    </asp:Panel>
</asp:Content>
