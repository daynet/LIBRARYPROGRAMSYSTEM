<%@ Page Title="" Language="C#" MasterPageFile="../Main.master"  AutoEventWireup="true" 
CodeFile="LibraryClassSchedule.aspx.cs" Inherits="Page_LibraryClassSchedule" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 20px;
        }
        .style2
        {
            width: 148px;
        }
        .style3
        {
            width: 50px;
        }
    </style>
    
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="Div1">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top-left">
            </div>
            <div class="form-fieldset-wrapper-top-page">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                Class Schedule Reports
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table>  
                          <tr>                             
                             <td class="style3">
                                <asp:RadioButton runat="server" ID="RdbStudentClassSection" Text="STUDENT CLASS SCHEDULE" Font-Bold="True"
                                    GroupName="RType"  AutoPostBack="true" oncheckedchanged="RdbStudentClassSection_CheckedChanged" 
                                   />
                            </td>  
                             <td class="style3">
                            <asp:RadioButton runat="server" ID="RdbStudentClash" Text="ENROLLMENT DETAILS" Font-Bold="True"
                                    GroupName="RType"  AutoPostBack="true" oncheckedchanged="RdbStudentClash_CheckedChanged"  />
                            </td>                           
                            </tr>
                          
                   
                            </table>
                            <table>
                            <tr>
                 
                            <td class="style1">
                            Semester 
                            </td>
                            <td  align="left" class="style2">
                            <asp:DropDownList ID="DrpSemester" runat="server" CssClass="textBox11" Width="180px" 
                                    onselectedindexchanged="DrpSemester_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                           
                           
                            </tr>
                         
                            <tr>
                           
                             <td class="style1">
                            <asp:Label ID="lblStudID" Text="Stud ID" runat="server" ></asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txtStud_ID" runat="server" CssClass="textBox1"  Width="110px" ></asp:TextBox>
                                <asp:ImageButton ID="btnSearchStudent" ImageUrl="~/Icons/search.gif" runat="server" OnClick="btnSearchStudent_Click" />
                            </td>
                             
                            </tr>
                            <tr>
                           
                           
                           <td class="style1" rowspan ="2">
                                <asp:Button ID="LoadReport" Text="Load Report" runat="server" onclick="LoadReport_Click"  
                                    />
                                <asp:Button ID="BtnDownload" Text="Download" runat="server" 
                                    onclick="BtnDownload_Click " Visible="False"/>
                            </td>
                            </tr>
                            </table>
                              </div>
              
              <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                   
                <asp:GridView ID="GrdEnrollmentDetails" runat="server" Width="100%" style="height:400px; overflow:scroll;">
                 <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                </asp:GridView>
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
        <!--ended Div of Wrapping Form Fields Set-->
    </div>




    
    <asp:Panel ID="PnlBatchSearch" runat="server" Style="display: none;" Visible="true">
    <div style="background-color: #E3E2E3 !important; padding-left: 7px; padding-top: 7px;
        float: left; width: 922px;">
        <asp:ImageButton ID="ImgBatchClose" runat="server" ImageUrl="~/images/cross.png" CausesValidation="false"
            OnClick="ImgBatchClose_click" Style="float: left" />
        <div id="Div3">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top-small">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Search Batch
                    </h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid-small">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table id="Table2" runat="server" width="100%">
                 
                           <tr>
                           <td>
                           Semester
                           </td>
                           <td>
                              <asp:DropDownList ID="DrpSemesterPopUp" runat="server" CssClass="textBox11" 
                              onselectedindexchanged="DrpSemesterPopUp_SelectedIndexChanged"  AutoPostBack="true">
                            </asp:DropDownList>
                           </td>
                           </tr>
                           <tr>
                           <td></td>
                           </tr>
                          
                         
                           <tr>
                           <td>
                           <asp:Button ID="BtnBatchDetailsSearch" runat="server" Text="Search" OnClick="BtnBatchDetailsSearch_Click" />
                           </td>
                           </tr>
                           </table>
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
                             <div id="Div4" style="width: 922px;">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper" style="width: 900px;">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top-small">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                    </h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid-small" style="width: 900px;">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner" style="height: 400px; overflow: scroll; width: 900px;">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <asp:GridView ID="GrvBatch" AutoGenerateColumns="False" runat="server" Style="margin-left: 5px;
                            margin-bottom: 10px" Width="100%" EmptyDataText="No Records Found" OnRowCommand="gridStudent_RowCommand">
                            <FooterStyle CssClass="GridFooter" />
                            <RowStyle CssClass="GridItem" />
                            <Columns>
                
                                <asp:TemplateField HeaderText="Batch Code" ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBatchCode" CommandArgument='<%#Eval("Batch_ID")%>' Text='<%#Eval("BatchCode")%>'
                                            CommandName="Select" runat="server"></asp:LinkButton>
                                             

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CDD_CODE">
                                    <ItemTemplate>
                                        <asp:Label ID="CDD_CODE" runat="server" Text='<%#Eval("CDD_CODE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CDD Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCDD_Description" runat="server"><%#Eval("CDD_Description")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Room">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoom" runat="server"><%#Eval("Room")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faculty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFaculty" runat="server"><%#Eval("Faculty")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                        </asp:GridView>
                    </div>
                    <!--form fieldset wrapper mid inner ended-->
                </div>
                <!--Ended Div of form fieldset wrapper middle part of left and right border-->
                <div class="form-fieldset-wrapper-bottom-small">
                </div>
                <!--Div started for the form fieldset wrapper bottom founded-->
            </div>
            </div>
            <!--ended Div of Wrapping Form Fields Set-->
        </div>
         
</asp:Panel>
<asp:HiddenField ID="hdDummy1" runat="server" />
<ajax:ModalPopupExtender ID="ME2" runat="server" BehaviorID="ModalPopupExtenderBehavior1"
    TargetControlID="hdDummy1" PopupControlID="PnlBatchSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
    BackgroundCssClass="modalBackground" X="320" Y="120">
</ajax:ModalPopupExtender>



<asp:Panel ID="pnlSearch" runat="server" Style="display: none;" Visible="true">
<div style="background-color: #E3E2E3 !important; padding-left: 7px; padding-top: 7px;
        float: left; width: 722px; ">
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
<asp:TextBox ID="txtSearch" runat="server" Width="350" AutoPostBack="true"  Font-Names="tahoma"
        ontextchanged="txtSearch_TextChanged"   />&nbsp;&nbsp;
      <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true" OnCheckedChanged="chkall_checkedchanged" />


<asp:ImageButton ID="ImageButton1"  BackColor="ActiveCaption" runat="server" AlternateText="Search" Width="50" CssClass="buttonface" 
Style="top: 5px; position: relative" onclick="btnSearch_Click" />&nbsp;&nbsp;
<asp:ImageButton ID="btnClear" BackColor="ActiveCaption"  runat="server" AlternateText="Clear" Width="50"  CssClass="buttonface"  Style="top: 5px;
position: relative" onclick="btnClear_Click" /> &nbsp;&nbsp;

<br />
</p>
  <div >
<table  width="90%">
<tr>
<td>
<asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15"
AllowSorting="True" DataSourceID="dsDetails" Width="700px" OnRowCommand="gvDetails_RowCommand" onrowdatabound="gvDetails_RowDataBound" OnPageIndexChanging="OnPageIndexChanging"
        CssClass="Gridview" ForeColor="#003964"   >
<HeaderStyle BackColor="#003964" />
<Columns>
<asp:TemplateField HeaderText="Student ID" ItemStyle-Width="10%">
<ItemTemplate>
<asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Eval("ID") %>' ForeColor="Blue"  Font-Underline="true" Width="90%"
           Text='<%# HighlightText(Eval("Stud_Id").ToString()) %>'></asp:LinkButton>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="First Name" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lblFirst" Text='<%# HighlightText(Eval("FirstName").ToString()) %>' runat="server" Width="90%"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Middle Name" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lblMiddleName" Text='<%# HighlightText(Eval("MiddleName").ToString()) %>' runat="server" Width="90%"/>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Last Name" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lbllastname" Text='<%# HighlightText(Eval("LastName").ToString()) %>' runat="server" Width="90%"/>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Intake" ItemStyle-Width="10%">
<ItemTemplate>
<asp:Label ID="lblTerm" Text='<%#HighlightText(Eval("TermName").ToString()) %>' runat="server" Width="100%" CssClass="buttonface"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Degree" ItemStyle-Width="10%">
<ItemTemplate>
<asp:Label ID="lblDeg" Text='<%# HighlightText(Eval("degreeCode").ToString()) %>' runat="server" Width="90%"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" ItemStyle-Width="5%">
<ItemTemplate>
<asp:Label ID="lblStatus" Text='<%# HighlightText(Eval("stud_course_status").ToString()) %>' runat="server" Width="90%"/>
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
SelectCommand="sp_displayrecords"  UpdateCommand="sp_displayrecords" UpdateCommandType="StoredProcedure"
SelectCommandType="StoredProcedure" 
FilterExpression="Stud_Id LIKE '%{0}%' or firstName LIKE '%{0}%'  or MiddleName LIKE '%{0}%' OR LastName LIKE '%{0}%' or  Degreecode LIKE '%{0}%' or  TermName LIKE '%{0}%' ">
<FilterParameters>
<asp:ControlParameter Name="firstName" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="TotalFollowUp" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="CallerStatus" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="DegreeCode" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="AttendedBy" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="Emailid" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="LastName" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="CallDate1" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="MiddleName" ControlID="txtSearch" PropertyName="Text" />
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

</asp:Content>

