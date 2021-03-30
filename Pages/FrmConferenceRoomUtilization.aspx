<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Main.master" CodeFile="FrmConferenceRoomUtilization.aspx.cs" Inherits="Pages_FrmConferenceRoomUtilization" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <style>
        .AutoExtender {
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

        .AutoExtenderList {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
            width: 200px;
        }

        .AutoExtenderHighlight {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }

        #divwidth {
            width: 500px !important;
        }

            #divwidth div {
                width: 500px !important;
            }

        .modalBackground {
            background-color: #E0ECED !important;
            filter: alpha(opacity=70);
            opacity: 1;
        }

        #main-frame1 {
            width: 350px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED !important;
            border: 1PX solid #9BAEAF;
            z-index: 50000;
        }

            #main-frame1 h1 {
                color: #374E51;
                margin: 0px 0px 10px 0px;
                font-family: Tahoma;
                font-size: 14px;
                letter-spacing: 1px;
            }

        .modalBackground {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .leftpane {
            width: 50%;
            height: 1%;
            float: left;
            border-collapse: collapse;
        }

        .middlepane {
            width: 50%;
            height: 1%;
            float: left;
            border-collapse: collapse;
        }

        .rightpane {
            width: 25%;
            height: 100%;
            position: relative;
            float: right;
            border-collapse: collapse;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top-left">
            </div>
            <div class="form-fieldset-wrapper-top-page">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>Conference Room Utilization
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 100%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                 

                    <table id="Table1" runat="server" width="100%" cellspacing="5" cellpadding="5">
                        <tr>

                            


                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Student ID" Enabled ="false"  ></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentId" runat="server"  CssClass="textBox11"  AutoPostBack="true" OnTextChanged="hdnValue_ValueChanged" required="true"></asp:TextBox>
                                <asp:Panel runat="server" ID="myPanel" Height="80px" ScrollBars="Horizontal" Style="width: 250px; text-overflow: ellipsis">
                                </asp:Panel>
                                <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                                    TargetControlID="txtStudentId" ServicePath="~/Service/AutoComlete.asmx" ServiceMethod="GetCompletionList"
                                    MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="myPanel">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td>Student Name</td> 

                            <td><asp:TextBox runat="server" ID="TxtStudentName" CssClass="textBox11" required="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Requested Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" Type="Date" ID="TxtDate" required="true" CssClass="textBox11"  ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Request Time"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtRequestedTime"  CssClass="textBox11" required="true"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btn_Summary" runat="server" Text="Save" OnClick="btn_Summary_Click" />

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

     <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top-left">
            </div>
            <div class="form-fieldset-wrapper-top-page">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>Conference Room Utilization
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 100%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->

                      <asp:GridView ID="GrdConferenceRoom" runat="server"></asp:GridView>
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



</asp:Content>
