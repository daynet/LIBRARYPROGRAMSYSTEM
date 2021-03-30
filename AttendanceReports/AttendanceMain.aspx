<%@ Page Title="" Language="C#" MasterPageFile="../Main.master" AutoEventWireup="true"
    CodeFile="AttendanceMain.aspx.cs" Inherits="Pages_AttendanceMain" %>
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                 <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
               <h2>Attendance - You can change the DATE also followed by CLICK GO BUTTON</h2>
            </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9" style="width: 97%">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                   <%-- <fieldset>
                        <legend><span style="font-size: 11px; font-weight: bold;">Attendance Details </span>
                        </legend>--%>
                        <table style="width: 100%">
                            
                            <tr>
                           
                                <td style="width: 100px; padding-left: 3px; padding-top: 3px;">
                                    Attendance Date
                                </td>
                                <td style="padding-left: 3px; padding-top: 3px;">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textBox1"  ></asp:TextBox>
                                     <ajax:CalendarExtender ID="calS3" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDate"
                                    CssClass="MyCalendar">
                                </ajax:CalendarExtender>
                                </td>
                                 <td style="padding-left: 3px; padding-top: 3px;">
                                    <asp:Button ID="btngo" runat="server" Text="Go" CssClass="" OnClick="btngo_Click" />
                                </td>
                            </tr>
                        </table>
                    <%--</fieldset>--%>
                   
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



    <asp:Panel ID="pnlMyClass" runat="server" Visible="false">

        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                      Batch  Attendance  List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner" style="width: 97%">
                        <asp:GridView ID="gvStayBackReason" runat="server" Width="100%" Font-Size="X-Small"
                            AutoGenerateColumns="False" OnRowCommand="gvStayBackReason_RowCommand" CssClass="grid-view"
                            OnRowUpdating="gvStayBackReason_RowUpdating" AllowPaging="true" PageSize="25" 
                            EmptyDataText="There are no records to display" 
                            OnRowDataBound="gvStayBackReason_RowDataBound"  OnPageIndexChanging="OnPaging">
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle   Width="10px"   />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.N." Visible="true" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSN" runat="server" Text='<%#Eval("sno")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch Code">
                                     <ItemTemplate>
                                        <asp:LinkButton ID="lnkclass" runat="server" Text='<%#Eval("ClassName")%>' CommandArgument='<%#Eval("class_id")%>' CommandName="View" ></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch/Section" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivisionName" runat="server"><%#Eval("DivisionName")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course Name" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblClassRoom" runat="server"><%#Eval("ClassRoom")%></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Present (%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpresentavg" runat="server"><%#Eval("presentavg")%></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Absent (%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblabsentcountavg" runat="server"><%#Eval("absentcountavg")%></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                         

                                <asp:TemplateField HeaderText="Total Student">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalStudent" runat="server"><%#Eval("TotalStudent")%></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Blocked">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBlocked" runat="server"><%#Eval("Blocked")%></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Att. Status">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="lnkAttStatus" runat="server" Text='<%#Eval("AttStatus")%>' CommandName="Update"
                                        CommandArgument='<%#Eval("class_id")%>'></asp:LinkButton>--%>
                                        <asp:ImageButton ID="ImgAttStatus" runat="server" CommandName='<%#Eval("AttStatus")%>'
                                            CommandArgument='<%#Eval("class_id")%>' ImageUrl='<%#Eval("AttStatus")%>' Width="20px"
                                            Height="20px" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="1" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                    <!--Ended Div of form fieldset wrapper middle part of left and right border-->
                </div>
                <div class="form-fieldset-wrapper-bottom">
                </div>
                <!--Div started for the form fieldset wrapper bottom founded-->
            </div>
            <!--ended Div of Wrapping Form Fields Set-->
        </div>
    </asp:Panel>
     <asp:Panel ID="pnlSearch" runat="server" Style="display: none;"  BorderColor="Black" BorderWidth="1px" Visible="true">
        <div style="background-color: #E3E2E3 !important; padding-left: 7px; padding-top: 7px;
            float: left; width: 480px;">
            <table width="100%"><tr><td></td><td></td><td width="40%" align="right"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/cross.png" CausesValidation="false"
                OnClick="btnClose_click" Style="float: left" /></td></tr></table>
            
            <div id="Div2">
                <!--Div Started to Wrapping all Forms Fields-->
                <div class="form-fieldset-wrapper">
                    <!--Start Div To Wrapping Form Fields Set-->
                    <div class="form-fieldset-wrapper-top-small">
                        <!--Div for the form fieldset wrapper top rounded part-->
                        <h2>
                            Batch Wise Status
                        </h2>
                    </div>
                    <!--ended Div of Form fieldset wrapper top rounded part-->
                    <div class="form-fieldset-wrapper-mid-small">
                        <!--Div for the form fieldset wrapper middle part for the left and right border-->
                        <div class="form-fieldset-wrapper-mid-inner" style="height: 250px; overflow: scroll;">
                            <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                            <asp:GridView ID="gridView" AutoGenerateColumns="False" runat="server" Style="margin-left: 5px;
                                margin-bottom: 10px" Width="100%" EmptyDataText="No Records Found">
                                <FooterStyle CssClass="GridFooter" />
                                <RowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" Text='<%#Eval("Edate")%>' Width="40px" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Session">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsess" Text='<%#Eval("Session")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Present">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPres" Text='<%#Eval("Present")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Absent">
                                        <ItemTemplate>
                                            <asp:Label ID="lblabs" Text='<%#Eval("Absent")%>' runat="server"></asp:Label>
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
                <!--ended Div of Wrapping Form Fields Set-->
            </div>
        </div>
    </asp:Panel>
      <div  style ="font-size:smaller; font-family:Verdana; color:black;" >
                <!--Div for the form fieldset wrapper top rounded part-->
                   Note:<br /> 
    1. Click <span style="color:Blue;" ><u>Batch Code </u></span>to view the previously marked attendance.<br/>
    2. Click Att Status <span style="color:Red;" >(Red Dot)</span> to mark attendance
    </div>
        <asp:HiddenField ID="hdDummy" runat="server" />
    <ajax:ModalPopupExtender ID="ME1" runat="server" BehaviorID="ModalPopupExtenderBehavior"
        TargetControlID="hdDummy" PopupControlID="pnlSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
        BackgroundCssClass="modalBackground" X="520" Y="220">
    </ajax:ModalPopupExtender>
</asp:Content>
