<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="BookReturnDueDateMail.aspx.cs" Inherits="Pages_BookReturnDueDateMail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function ChkSelectallClick(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.GrvDetails.ClientID %>');
            var TargetChildControl = "chkRow";
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    SEND MAIL
                </h2>
            </div>
            <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <table cellpadding="2" cellspacing="2">
                        <tr>
                            <td style="width: 15%">
                                Semester:
                            </td>
                            <td style="width: 10%">
                                <asp:TextBox ID="TxtSemester" runat="server" Enabled="false" Style="width: 333px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; padding-left:10px">
                                Due Date:
                            </td>
                            <td style="width: 65%">
                                <asp:TextBox ID="TxtDueDate" runat="server" Enabled="false" Style="width: 110px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                Email Subject:
                            </td>
                            <td style="width: 100%" colspan="3">
                                <asp:TextBox ID="txtSubject" runat="server" Style="width: 65%" required="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email Content:
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Style="width: 65%;height:100px"
                                    required="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="BtnSend" runat="server" Text="SEND" OnClick="BtnSend_Click" />
                                <asp:Button ID="BtnCancel" runat="server" Text="CANCEL" OnClick="BtnCancel_Click" />
                                <asp:Button ID="BtnBackToMain" runat="server" Text="BACK TO MAIN" OnClick="BackToMain_Click" />
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
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    SEND MAIL LIST
                </h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <div style="overflow-y:auto;max-height:425px;">
                    <div> 
                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="textBox11" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_OnSelectedIndexChanged">   
                        <asp:ListItem Selected= "True" Text = "STUDENT" Value="STUDENT" />
                        <asp:ListItem Text = "STAFF AND FACULTY" Value="STAFFANDFACULTY" />
                        </asp:DropDownList>
                    </div>
                    <asp:GridView ID="GrvDetails" runat="server" Style="margin-left: 5px; margin-bottom: 10px;"
                        Width="100%" OnRowCommand="GrvDetails_RowCommand" EmptyDataText="No Record found.!"
                        AutoGenerateColumns="false">
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
                            <asp:TemplateField HeaderText="StudentID">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                <HeaderStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                                <HeaderStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EMail">
                                <ItemTemplate>
                                    <asp:Label ID="lblEMail" runat="server" Text='<%#Eval("EmailId")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                                <HeaderStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                <HeaderStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox HeaderText="Select" ID="chkAllRow" Text="Select" runat="server" Checked="true"
                                        onclick="javascript:ChkSelectallClick(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" Checked="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
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
</asp:Content>
