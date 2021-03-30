<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Main.master" CodeFile="KohaReports.aspx.cs"
    Inherits="LibraryReports_KohaReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        (function () {
            changeCursor();
        })();
        function changeCursor() {

         //alert(document.getElementById('<%=DrpReport.ClientID%>').value);
            if (document.getElementById('<%=DDLReport.ClientID%>').value == "OverDueTypes") {
                document.getElementById('<%=LblBookType.ClientID%>').style.display = 'block';
                document.getElementById('<%=DDLBookType.ClientID%>').style.display = 'block';
                document.getElementById('<%=LblLevel.ClientID%>').style.display = 'none';
                document.getElementById('<%=DDLType.ClientID%>').style.display = 'none';

            }
            else if (document.getElementById('<%=DDLReport.ClientID%>').value == "OverDueLevel") {
                document.getElementById('<%=LblLevel.ClientID%>').style.display = 'block';
                document.getElementById('<%=DDLType.ClientID%>').style.display = 'block';
                document.getElementById('<%=LblBookType.ClientID%>').style.display = 'none';
                document.getElementById('<%=DDLBookType.ClientID%>').style.display = 'none';
            }

            else if (document.getElementById('<%=DrpReport.ClientID%>').value == "Semesterwise") {

                document.getElementById('<%=LblAyear.ClientID%>').style.display = 'block';
                document.getElementById('<%=DDLAY.ClientID%>').style.display = 'block';
                document.getElementById('<%=LblSemester.ClientID%>').style.display = 'block';
                document.getElementById('<%=DDLSemester.ClientID%>').style.display = 'block';
            }
            else {
                document.getElementById('<%=LblLevel.ClientID%>').style.display = 'none';
                document.getElementById('<%=DDLType.ClientID%>').style.display = 'none';
                document.getElementById('<%=LblBookType.ClientID%>').style.display = 'none';
                document.getElementById('<%=DDLBookType.ClientID%>').style.display = 'none';
            }


            if (document.getElementById('<%=DrpReport.ClientID%>').value == "Semesterwise"
            || document.getElementById('<%=DrpReport.ClientID%>').value == "Facultywise" ||
            document.getElementById('<%=DrpReport.ClientID%>').value == "StudentWise") 
            {

                document.getElementById('<%=LblAyear.ClientID%>').style.display = 'block';
                document.getElementById('<%=DDLAY.ClientID%>').style.display = 'block';
                document.getElementById('<%=LblSemester.ClientID%>').style.display = 'block';
                document.getElementById('<%=DDLSemester.ClientID%>').style.display = 'block';
            }
            else {

                document.getElementById('<%=LblAyear.ClientID%>').style.display = 'none';
                document.getElementById('<%=DDLAY.ClientID%>').style.display = 'none';
                document.getElementById('<%=LblSemester.ClientID%>').style.display = 'none';
                document.getElementById('<%=DDLSemester.ClientID%>').style.display = 'none';

            }




        }
    </script>
    <style>
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
        .leftpane
        {
            width: 50%;
            height: 1%;
            float: left;
            border-collapse: collapse;
        }
        
        .middlepane
        {
            width: 50%;
            height: 1%;
            float: left;
            border-collapse: collapse;
        }
        
        .rightpane
        {
            width: 25%;
            height: 100%;
            position: relative;
            float: right;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 <div class="leftpane" >
     <div id="Div1">
     <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                 INDIVIDUAL REPORT
                </h2>
            </div>
          <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
            <table>
              
                <tr padding-right="10px">
                    <td>
                        Report Name
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpReport" runat="server" onchange="changeCursor()">
                            <asp:ListItem Text="Semesterwise" Value="Semesterwise"></asp:ListItem>
                            <asp:ListItem Text="Current Book(Total Book)" Value="CurrentBooks"></asp:ListItem>
                            <asp:ListItem Text="OverDue" Value="OverDue"></asp:ListItem>
                            <asp:ListItem Text="Book Return Details " Value="BookreturnDetails"></asp:ListItem>
                            <asp:ListItem Text="Book taken by Faculty-Course wise details" Value="Facultywise"></asp:ListItem>
                             <asp:ListItem Text="Book taken by Student-Course wise details" Value="StudentWise"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="LblBrowwer" Text="Student/Faculty/Staff"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStudentId" runat="server" Height="22px" Width="332px" AutoPostBack="true"
                            OnTextChanged="hdnValue_ValueChanged" onfocus="this.value='';"></asp:TextBox>
                        <asp:Panel runat="server" ID="myPanel" Height="80px" ScrollBars="Horizontal" Style="width: 500px;
                            text-overflow: ellipsis">
                        </asp:Panel>
                        <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                            TargetControlID="txtStudentId" ServicePath="~/Service/AutoComlete.asmx" ServiceMethod="GetBorrowerList"
                            MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="myPanel">
                        </cc1:AutoCompleteExtender>
                        <asp:HiddenField ID="hdnValue" OnValueChanged="hdnValue_ValueChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblAyear" runat="server" Text="AY"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLAY" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLAY_SelectedIndexChanged"
                            onchange="changeCursor()" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblSemester" runat="server" Text="Semester"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLSemester" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="BtnInvReport" Text="Load" runat="server" OnClick="BtnInvReport_Click"
                            OnClientClick="ChangeCursor()" />
                    </td>
                    <td align="center">
                        <asp:Button ID="BtnInvEReport" Text="Download" runat="server" 
                            onclick="BtnInvEReport_Click" />
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
    </div>
        <div class="middlepane" >
         <%--<div id="Div2">--%>
     <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                  BULK REPORT
                </h2>
            </div>
         
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
            <table>
               
                <tr >
                    <td>
                        Report Name
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLReport" runat="server" onchange="changeCursor()">
                            <asp:ListItem Text="OverDue Statistics" Value="OverDueStatistics"></asp:ListItem>
                            <asp:ListItem Text="OverDue Based on Book Type" Value="OverDueTypes"></asp:ListItem>
                            <asp:ListItem Text="OverDue Level Statistics" Value="OverDueLevel"></asp:ListItem>
                            <asp:ListItem Text="Coursewise" Value="Coursewise"></asp:ListItem>
                            <asp:ListItem Text="Books Not Collected" Value="Not Collected"></asp:ListItem>
                            <asp:ListItem Text="Books Not Collected based on Semester" Value="Not Collected Semester"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblBookType" Text="Book Type" runat="server" Style="display: none"></asp:Label>
                        <asp:Label ID="LblLevel" Text="Type" runat="server" Style="display: none"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLBookType" runat="server" Style="display: none">
                            <asp:ListItem Value="CD" Text="CD"></asp:ListItem>
                            <asp:ListItem Value="CG" Text="CITY & GUILDS"></asp:ListItem>
                            <asp:ListItem Value="EM" Text="EBOOKS MBA"></asp:ListItem>
                            <asp:ListItem Value="IS" Text="IELTS BOOK"></asp:ListItem>
                            <asp:ListItem Value="JR" Text="JOURNAL"></asp:ListItem>
                            <asp:ListItem Value="MB" Text="MBA REF BOOKS"></asp:ListItem>
                            <asp:ListItem Value="MN" Text="MAGAZINE"></asp:ListItem>
                            <asp:ListItem Value="RB" Text="REFERENCE BOOK"></asp:ListItem>
                            <asp:ListItem Value="RNTBK" Text="RENTAL BOOK"></asp:ListItem>
                            <asp:ListItem Value="SC" Text="CIMA REF"></asp:ListItem>
                            <asp:ListItem Value="TFLBK" Text="TOEFL Book"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="DDLType" runat="server" Style="display: none">
                            <asp:ListItem Value="FACI" Text="INSTRUCTOR"></asp:ListItem>
                            <asp:ListItem Value="FACP" Text="FACULTY PART TIME"></asp:ListItem>
                            <asp:ListItem Value="FACR" Text="FACULTY FULL TIME"></asp:ListItem>
                            <asp:ListItem Value="STDBAM" Text="BBA-BAM"></asp:ListItem>
                            <asp:ListItem Value="STDBBF" Text="BBA-BBF"></asp:ListItem>
                            <asp:ListItem Value="STDBBI" Text="BBA-BBI"></asp:ListItem>
                            <asp:ListItem Value="STDBBM" Text="BBA-BBM"></asp:ListItem>
                            <asp:ListItem Value="STDBBP" Text="BBA-BBP"></asp:ListItem>
                            <asp:ListItem Value="STDBBT" Text="BBA-BBT"></asp:ListItem>
                            <asp:ListItem Value="STDBIB" Text="BBA-BIB"></asp:ListItem>
                            <asp:ListItem Value="STDBMR" Text="BBA-BMR"></asp:ListItem>
                            <asp:ListItem Value="STDMBE" Text="MBA-MBE"></asp:ListItem>
                            <asp:ListItem Value="STDMBF" Text="MBA-MBF"></asp:ListItem>
                            <asp:ListItem Value="STDMBH" Text="MBA-MBH"></asp:ListItem>
                            <asp:ListItem Value="STDMBM" Text="MBA-MBM"></asp:ListItem>
                            <asp:ListItem Value="STDMBS" Text="MBA-MBS"></asp:ListItem>
                            <asp:ListItem Value="STDMQP" Text="MBA-MQP"></asp:ListItem>
                            <asp:ListItem Value="STDSC" Text="SHORT COURSE"></asp:ListItem>
                            <asp:ListItem Value="STF" Text="STF"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="BtnBlkLoad" Text="Load" runat="server" OnClick="BtnBlkLoad_Click" />
                        <asp:Button ID="BtnBlkDownload" Text="Download" runat="server" 
                            onclick="BtnBlkDownload_Click"  />
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
  <%--  </div>--%>
        </div>
        <div>
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
        <div style="height: 80%; width: 100%; overflow: scroll">
            <asp:GridView ID="GrdInvReport" runat="server" Style="width: 100%;">
                <RowStyle CssClass="GridItem" />
                <HeaderStyle CssClass="GridHeader" />
                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                <SelectedRowStyle CssClass="GridRowOver" />
                <EditRowStyle />
                <AlternatingRowStyle CssClass="GridAltItem" />
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
        <%--  <div class="rightpane" style ="border :2px solid Black">
    <h1>Test Page</h1></div>--%>
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
  <%--  </div>--%>
        </div>
    </div>
</asp:Content>
