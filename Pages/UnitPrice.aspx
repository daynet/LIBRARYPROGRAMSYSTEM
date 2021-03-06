<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UnitPrice.aspx.cs" Inherits="Pages_UnitPrice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
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
                BOOK UNIT PRICE
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
                <td>
                Price
                </td>
                <td>
                <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="TxtPrice" runat="server"  Width="100px"></asp:TextBox>
                </td>
                <td>
                Effective Date
                </td>
                 <td>
                   <asp:TextBox ID="TxtDate" runat="server" CssClass="textBox1"  Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtDateCalendarExtender" CssClass="MyCalendar" TargetControlID="TxtDate"
                    Format="dd/MM/yyyy" runat="server"></cc1:CalendarExtender>
                   </td>
                </tr>
              <tr>
              <td>
                <asp:Button ID="BtnSave" runat="server"  Text="SAVE" onclick="BtnSave_Click"  />
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
                            Width="100%"  OnRowCommand="GrvDetails_RowCommand" AutoGenerateColumns="false" >
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
                                 <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Effective Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEffeciveDate" runat="server" Text='<%#Eval("EffectiveDate","{0:dd/MMM/yyyy}")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
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

