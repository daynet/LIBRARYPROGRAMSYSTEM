<%@ Page Language="C#" MasterPageFile="../Main.master" AutoEventWireup="true" CodeFile="StudentProfile.aspx.cs"
    Inherits="LibraryReports_StudentProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

<%--<script type="text/jscript" >
    $(document).ready(function () {
        f_color();
        alert("Test D");
    });
</script>--%>
<script type ="text/javascript" >


    window.onload = function () { f_color(); }
   
    
    function f_color() {
    try {


        if (document.getElementById('<%=RbtStudent.ClientID%>').checked) {


            document.getElementById('<%=Student_Id.ClientID%>').innerHTML = 'Student';
            document.getElementById('<%=LblName.ClientID%>').innerHTML = 'Student Name';
            document.getElementById('<%=TxtStaffFacID.ClientID%>').vaue = "";
            document.getElementById('<%=txtStudentId.ClientID%>').vaue = "";
//            alert('Hi');
           
            document.getElementById('<%=TxtStaffFacID.ClientID%>').style.display = 'none';
            document.getElementById('<%=txtStudentId.ClientID%>').style.display = 'block';
        } else {
            document.getElementById('<%=Student_Id.ClientID%>').innerHTML = 'Staff';
            document.getElementById('<%=LblName.ClientID%>').innerHTML = 'Staff/Faculty Name';
            document.getElementById('<%=txtStudentId.ClientID%>').style.display = 'none';
            document.getElementById('<%=TxtStaffFacID.ClientID%>').style.display = 'block';
            document.getElementById('<%=TxtStaffFacID.ClientID%>').vaue = "";
            document.getElementById('<%=txtStudentId.ClientID%>').vaue = "";
            alert(txtStudentId);
            
        }
    }
    catch (err) {
      
    }
    }
  // document.getElementById('ID').onchange = f_color;
</script>

    <style type="text/css">
        .DropDown
        {
            width: 100%;
        }
        tr.spaceUnder > td
        {
            padding-bottom: 1em;
        }
     input:not([type]), input[type="text"]
        {
            height :23px;
        }
        
        .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 0px;
            background-color: White;
            margin-left: 0px;
            z-index: 10;
            position: absolute;
            width: 200px;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
            width: 200px;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }
        #divwidth
        {
            width: 500px !important;
        }
        #divwidth div
        {
            width: 500px !important;
        }
        .modalBackground
        {
            background-color: #E0ECED !important;
            filter: alpha(opacity=70);
            opacity: 1;
        }
        #main-frame1
        {
            width: 350px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED !important;
            border: 1PX solid #9BAEAF;
            z-index: 50000;
        }
        #main-frame1 h1
        {
            color: #374E51;
            margin: 0px 0px 10px 0px;
            font-family: Tahoma;
            font-size: 14px;
            letter-spacing: 1px;
        }
        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .style1
        {
            width: 2%;
        }
        .style2
        {
            width: 131px;
        }
        .style3
        {
            width: 10%;
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
                STUDENT/STAFF PROFILE
                </h2>
            </div>
          <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
    <table>
    <tr>
     <td><asp:RadioButton ID="RbtStudent" Text ="Student"  GroupName ="Profile" runat ="server"   Checked ="true" onClick="f_color()" /></td>
      <td><asp:RadioButton ID="RbtStaffFaculty" Text ="Staff/Faculty"   GroupName ="Profile" runat ="server" onClick="f_color()"/></td>
    </tr>
   
        <tr>
            <td style="padding-left: 3px; padding-top: 3px;">
                <asp:Label ID="Student_Id" runat ="server" Text ="Student ID"></asp:Label>
            </td>
            <td style="padding-left: 3px; padding-top: 3px;">
                                    <asp:TextBox ID="txtStudentId" runat="server" CssClass="textBox1" Width="250px" AutoPostBack ="true" OnTextChanged="hdnValue_ValueChanged"  ></asp:TextBox>
                                      <asp:TextBox ID="TxtStaffFacID" runat="server" CssClass="textBox1" Width="143px" style="display :none " AutoPostBack ="true" OnTextChanged="hdnValue_ValueChanged"></asp:TextBox>
                                    <asp:Panel runat="server" ID="myPanel" Height="80px" ScrollBars="Horizontal" Style="
                                        width: 250px; text-overflow: ellipsis">
                                    </asp:Panel>
                                    <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                                        TargetControlID="txtStudentId" ServicePath="~/Service/AutoComlete.asmx" ServiceMethod="GetCompletionList"
                                        MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="myPanel"
                                      >

                                    </cc1:AutoCompleteExtender>
                                     <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" BehaviorID="autoComplete1"
                                        TargetControlID="TxtStaffFacID" ServicePath="~/Service/AutoComlete.asmx" ServiceMethod="GetEmployeeList"
                                        MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="myPanel"
                                      >

                                    </cc1:AutoCompleteExtender>
                                    <asp:hiddenfield id="hdnValue" onvaluechanged="hdnValue_ValueChanged" runat="server"/>
                               
                                </td>
            <td style="padding-left: 3px; padding-top: 3px;">
              <asp:Label ID="LblName" runat="server" Text="Student Name"></asp:Label>
            </td>
            <td style="padding-left: 3px; padding-top: 3px;">
                <asp:TextBox ID="txtStudentName" runat="server" CssClass="textBox1"  Width="400px"></asp:TextBox>
            </td>
            <td>
            <asp:Button ID="BtnLoad" runat ="server" Text ="Load" onclick="BtnLoad_Click" />
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
</asp:Content>
