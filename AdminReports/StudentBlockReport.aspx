<%@ Page Title="" Language="C#" MasterPageFile="../Main.master"  AutoEventWireup="true" CodeFile="StudentBlockReport.aspx.cs" Inherits="Page_StudentBlockReport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
                </h2>
            </div>
            <div class="form-fieldset-wrapper-top-right">
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table>
                        <tr>
                          <td>
                                <asp:Label ID="Label1" runat="server" Text="Departmet"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpDepartment" AutoPostBack="true" runat="server" CssClass="textBox11">
                                <%--  <asp:ListItem Text="Admin"  Value=1 ></asp:ListItem>  
                                  <asp:ListItem Text="Finance" Value=3 ></asp:ListItem>
                                  <asp:ListItem Text="HRD" Value=4 ></asp:ListItem>
                                  <asp:ListItem Text="SSD" Value=2 ></asp:ListItem>
                                  <asp:ListItem Text="Library"  Value=0 ></asp:ListItem> --%>                                                           
                                </asp:DropDownList>
                            </td>
                            <td colspan="4" >
                                <asp:Button ID="Button1" Text="Load Report" runat="server" onclick="btnload_Click" 
                                    />
                                       </td>
                                    <td>
                        <asp:CheckBox ID="ChkExportExcel" runat="server" Text="EXPORT EXCEL" AutoPostBack="true" 
                                            oncheckedchanged="ChkExportExcel_CheckedChanged" />
                        </td>
                        <td>
                        <asp:RadioButtonList ID="RdbExpotexcel" runat="server" Visible="false" Width="200px">
                        <asp:ListItem Text="Statistics" Value="ST"></asp:ListItem>
                         <asp:ListItem Text="Details" Value="DT"></asp:ListItem>
                        </asp:RadioButtonList>
                        </td>

                        </tr>
                       <%-- <tr>
                            <td colspan="4" >
                                <asp:Button ID="btnload" Text="Load Report" runat="server" onclick="btnload_Click" 
                                    />
                            </td>
                        </tr>--%>
                    </table>
                    <asp:GridView ID="GrvGrid" runat="server" BackColor="White" BorderColor="#999999"   
                     BorderStyle="None" font-Size="X-Small" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  Visible="false" >
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle   Width="10px"   />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />  
                               <Columns>
                               <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                <HeaderStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                         </Columns>
                    </asp:GridView>  
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


