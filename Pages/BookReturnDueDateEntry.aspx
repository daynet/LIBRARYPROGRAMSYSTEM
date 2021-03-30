<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="BookReturnDueDateEntry.aspx.cs" Inherits="Pages_BookReturnDueDateEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="all-form-wrap">
     <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
               BOOK RETURN DUE DATE ENTRY
                </h2>
            </div>
          <%--  <div class="form-fieldset-wrapper-top-right">
            </div>--%>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    
                     <table>             
                        <tr>
                            <td style="width: 15%">Semester</td>
                            <td style="width: 20%">
                                <asp:HiddenField ID="HdnID" runat="server" />
                               <asp:DropDownList ID="ddlSemester" runat="server" CssClass="textBox11" Width="100%">                              
                               </asp:DropDownList>
                            </td>
                        
                            <td style="width: 10%">&nbsp;Due Date</td>
                            <td style="width: 65%">
                                 <asp:TextBox ID="TxtDueDate" runat="server" CssClass="textBox1"  Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtDateCalendarExtender" CssClass="MyCalendar" TargetControlID="TxtDueDate"
                                Format="dd/MM/yyyy" runat="server"></cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>Remarks</td>
                            <td>
                                <asp:TextBox ID="TxtRemarks" runat="server" TextMode="MultiLine" Style="width:100%" required="true"></asp:TextBox>
                             </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chkActive" runat="server" Visible="false" Text="Active" checked="true"></asp:CheckBox>
                             </td>
                        </tr>
                        <tr>
                        <td>&nbsp;</td>
                          <td>
                            <asp:Button ID="BtnSave" runat="server"  Text="SAVE" onclick="BtnSave_Click"  />
                            <asp:Button ID="BtnCancel" runat="server"  Text="CANCEL" onclick="BtnCancel_Click"  />
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
               BOOK RETURN DUE DATE ENTRY LIST
                </h2>
            </div>        
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <asp:GridView ID="GrvDetails" runat="server" Style="margin-left: 5px; margin-bottom: 10px;"
                            Width="100%"  OnRowCommand="GrvDetails_RowCommand" EmptyDataText="No Record found.!" AutoGenerateColumns="false" 
                            OnRowDataBound="GrvDetails_RowDataBound" DataKeyNames="ID,SemesterId">
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
                                 <asp:TemplateField HeaderText="Semester">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemester" runat="server" Text='<%#Eval("Semester")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>                                
                                 <asp:TemplateField HeaderText="Due Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDueDate" runat="server" Text='<%#Eval("DueDate","{0:dd/MMM/yyyy}")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Eval("CreatedDate","{0:dd/MMM/yyyy}")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>              
                                   <asp:TemplateField HeaderText="SendMail">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkSendMail" CommandArgument='<%#Eval("ID")%>' Text="Send Mail"
                                            CommandName="SendMail" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>          
                                   <asp:TemplateField HeaderText="EDIT">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkEdit" CommandArgument='<%#Eval("ID")%>' Text="EDIT"
                                            CommandName="EditRow" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
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

</asp:Content>

