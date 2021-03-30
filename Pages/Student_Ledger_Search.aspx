<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Student_Ledger_Search.aspx.cs" Inherits="Page_Student_Ledger_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

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
    <style>
        .GridHeader th
        {
            padding: 3px;
            padding-top: 3px;
            padding-right-value: 3px;
            padding-bottom: 3px;
            padding-left-value: 3px;
            padding-left-ltr-source: physical;
            padding-left-rtl-source: physical;
            padding-right-ltr-source: physical;
            padding-right-rtl-source: physical;
            text-transform: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <%--<div class="GridviewDiv">--%>
    <div id="Div1">
     <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
            STUDENT LEDGER SEARCH
                </h2>
            </div>
          <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
<table  width="90%">
<tr>
<td>
Search
</td>
<td>

<asp:TextBox ID="txtSearch" runat="server" Width="350" AutoPostBack="true"  Font-Names="tahoma"
        ontextchanged="txtSearch_TextChanged"   />
<%--</td>
  <td> --%>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true" OnCheckedChanged="chkall_checkedchanged" />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <%--</td>
  <td> --%>
<asp:ImageButton ID="btnSearch"  BackColor="ActiveCaption" runat="server" 
        AlternateText="Search" Width="50" CssClass="buttonface" 
Style="top: 5px; position: relative" onclick="btnSearch_Click" 
        ImageUrl="~/Icons/magnify-glass.png" />&nbsp;&nbsp;
<asp:ImageButton ID="btnClear" BackColor="ActiveCaption"  runat="server" 
        AlternateText="Clear" Width="50"  CssClass="buttonface"  Style="top: 5px;
position: relative" onclick="btnClear_Click" ImageUrl="~/Icons/Clear.jpg" /> &nbsp;&nbsp;
<%--</td>--%>
</tr>
</table>
<%--<br />
</p>--%>
  <div  style ="height:100">
<table  width="100%">
<tr>
<td>
<asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
AllowSorting="True" DataSourceID="dsDetails" Width="950px"   OnRowCommand="gvDetails_RowCommand"
       ForeColor="#003964" PageSize="20" >

<%--<HeaderStyle BackColor="#003964" />--%>
 <RowStyle CssClass="GridItem" />
<HeaderStyle CssClass="GridHeader" />
<PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
<SelectedRowStyle CssClass="GridRowOver" />
<EditRowStyle />
<AlternatingRowStyle CssClass="GridAltItem" />
<Columns>
 <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="7%">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
<asp:TemplateField HeaderText="STUDENT ID" ItemStyle-Width="10%">
<ItemTemplate>
<%--<asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Eval("ID") %>' ForeColor="Blue"  Font-Underline="true" Width="90%"
           Text='<%# HighlightText(Eval("Stud_Id").ToString()) %>'> </asp:LinkButton>--%>
  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../Pages/StudentLedger.aspx?id={0}", Eval("Stud_Id")) %>'
                        Text='<%# HighlightText(Eval("Stud_Id").ToString()) %>'   Target="_blank"  ForeColor="Blue"  Font-Underline="true"  />
           

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="FIRST NAME" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lblFirst" Text='<%# HighlightText(Eval("FirstName").ToString()) %>' runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MIDDLE NAME" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lblMiddleName" Text='<%# HighlightText(Eval("MiddleName").ToString()) %>' runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LAST NAME" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lbllastname" Text='<%# HighlightText(Eval("LastName").ToString()) %>' runat="server" />
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="TERM" ItemStyle-Width="10%">
<ItemTemplate>
<asp:Label ID="lblTerm" Text='<%#HighlightText(Eval("TermName").ToString()) %>' runat="server"  CssClass="buttonface"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DEGREE  " ItemStyle-Width="10%">
<ItemTemplate>
<asp:Label ID="lblDeg" Text='<%# HighlightText(Eval("degreeCode").ToString()) %>' runat="server"/>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Shift" ItemStyle-Width="5%">
<ItemTemplate>
<asp:Label ID="lblShift" Text='<%# HighlightText(Eval("shift").ToString()) %>' runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Level" ItemStyle-Width="5%">
<ItemTemplate>
<asp:Label ID="lbllevel" Text='<%# HighlightText(Eval("level_code").ToString()) %>' runat="server" />
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Status" ItemStyle-Width="5%">
<ItemTemplate>
<asp:Label ID="lblStatus" Text='<%# HighlightText(Eval("stud_course_status").ToString()) %>' runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Is Advisory" ItemStyle-Width="45%">
<ItemTemplate>
<asp:label ID="lnkAdvisory" runat="server" 
           Text='<%# HighlightText(Eval("Advisory").ToString()) %>'></asp:label>

</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Debit" ItemStyle-Width="45%">
<ItemTemplate>
<asp:label ID="lnkDebit" runat="server" 
           Text='<%# HighlightText(Eval("debit").ToString()) %>'></asp:label>

</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Credit" ItemStyle-Width="45%">
<ItemTemplate>
<asp:label ID="lnkCredit" runat="server" 
           Text='<%# HighlightText(Eval("Credit").ToString()) %>'></asp:label>

</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Balance" ItemStyle-Width="45%">
<ItemTemplate>
<asp:label ID="lnkBalance" runat="server" 
           Text='<%# HighlightText(Eval("Balance").ToString()) %>'></asp:label>

</ItemTemplate>
</asp:TemplateField>

</Columns>
<RowStyle HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
</td>
</tr>
</table>
</div>
 </div>
          
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

   <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CDBConnectionString2 %>" 
        SelectCommand="sp_displayrecords" SelectCommandType="StoredProcedure" FilterExpression="Name LIKE '%{0}%'">>
        <FilterParameters>
<asp:ControlParameter Name="Name" ControlID="txtSearch" PropertyName="Text" />
</FilterParameters
    </asp:SqlDataSource>--%>

<asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:AdminExam %>" 
SelectCommand="sp_displayrecords_ForStudentLedger"  UpdateCommand="sp_displayrecords_ForStudentLedger" UpdateCommandType="StoredProcedure"
SelectCommandType="StoredProcedure" 
FilterExpression="Stud_Id LIKE '%{0}%' or firstName LIKE '%{0}%' or MiddleName LIKE '%{0}%'  or LastName LIKE '%{0}%' or  Degreecode LIKE '%{0}%' or  TermName LIKE '%{0}%' or shift like '%{0}%' or Level_Code like '%{0}%' or Advisory like '%{0}%' ">
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
<asp:ControlParameter Name="Advisory" ControlID="txtSearch" PropertyName="Text" />
</FilterParameters>
     <SelectParameters>
     <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" /> 
     </SelectParameters>
     <UpdateParameters>
     <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" /> 
     </UpdateParameters>


</asp:SqlDataSource>
</asp:Content>







