<%@ Page  Language="C#" AutoEventWireup="true" MasterPageFile="../Main.master" 
    CodeFile="ExcelExport.aspx.cs" Inherits="Page_ExcelExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Div1">
        
                    <table border=1  width="50%" >
                        <tr>
                            <td>
                                <b>
                                 <asp:Label Font-Bold="true" ID="lbl_reportlist" runat="server" Text="Report List"></asp:Label>
                                </b>
                            </td>
                            <td width="20%" >
                                <asp:DropDownList ID="ddl_reportList" runat="server" AutoPostBack="true" Width="200px"
                                    Height="25px">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="req_Sem" runat="server" ControlToValidate="ddl_reportList"
                                    ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                             <td   width="20%" align="left">
                                <asp:Button Font-Bold="true"  ID="btn_load" runat="server" Text="Load Details"   ValidationGroup="vgadd"
                                OnClick="btn_Click_Load_Details"  />
                            </td>
                             <td>
                                <asp:Button Font-Bold="true" ID="btn_export" runat="server" Text="Export Details"   ValidationGroup="vgadd2"
                                OnClick="btn_ExportExcel_Click" />
                                <asp:Label ID="lbl_ack" runat="server"  Visible="false" ></asp:Label>
                            </td>
                        </tr>
                    </table>
             
    </div>
    <div id="Div2">
       
                    <asp:Panel ID="panelshow1" runat="server"  Visible="false" >
                        <table   cellpadding="5px">
                            <tr>
                                <td >                                    
                                   <asp:Label Font-Bold="true" ID="lbl_acyear" runat="server" Text="Academic Year"></asp:Label>
                                </td>
                                <td >           
                                    <asp:DropDownList ID="ddl_acYear" runat="server"   OnSelectedIndexChanged="ddl_acyear_selectedindexchanged"  
                                     AutoPostBack="true" Width="100px" Height="25px" CssClass="textBox11">
                                    </asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="Rf_acyear" runat="server" ControlToValidate="ddl_acYear"
                                    ValidationGroup="vgadd2" ErrorMessage="*" InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                 <td >           
                                    <asp:Label Font-Bold="true" ID="lbl_semester" runat="server" Text="Semester"></asp:Label>
                                </td>
                                 <td >           
                                    <asp:DropDownList ID="ddl_semester" OnSelectedIndexChanged = "ddl_semester_selectindexchanged"  
                                    AutoPostBack="true" runat="server" Width="170px" Height="25px" CssClass="textBox11">
                                    </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Rf_sem" runat="server" ControlToValidate="ddl_semester"
                                    ValidationGroup="vgadd2" ErrorMessage="*" InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                                      
                                 <td >                                              
                                    <asp:Label Font-Bold="true" ID="lbl_employee" runat="server" Text="Faculty"></asp:Label>
                                </td>
                                <td >           
                                    <asp:DropDownList ID="ddl_employee" OnSelectedIndexChanged="ddl_Faculty_selectedindexchanged"
                                     AutoPostBack="true"  runat="server" Width="300px" Height="25px" CssClass="textBox11">
                                    </asp:DropDownList>
                                </td>
                                <td >           
                                    <asp:Label Font-Bold="true" ID="lbl_batchName" runat="server" Text="Batch Name "></asp:Label>
                                </td>
                                 <td >           
                                    <asp:DropDownList ID="ddl_batch" runat="server" Width="220px" AutoPostBack="true" 
                                    OnSelectedIndexChanged="ddl_batch_selectedindex_changed" Height="25px" CssClass="textBox11">
                                    </asp:DropDownList>
                                      <%--<asp:RequiredFieldValidator ID="rf_batch" runat="server" ControlToValidate="ddl_batch"
                                    ValidationGroup="vgadd2" ErrorMessage="*" InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </td>
                                </tr>
                            
                        </table>
                    </asp:Panel>
             
    <div align="center">
            
          <asp:GridView ID="gV_View" runat="server" BackColor="White" BorderColor="#999999"   
          BorderStyle="None" font-Size="X-Small" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
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
</asp:Content>
