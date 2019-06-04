<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="employeePaySlipList.aspx.cs" Inherits="admin_employeePaySlipList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Payslip List</div>
                </div>
                <div class="form-horizontal">
                    <div class="paneldiv-border">
                                <div class="form-group">
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control"
                                                AutoPostBack="true">
                                                <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                <asp:ListItem Value="100">100</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-2">
                                            <label class="control-label">
                                                Records per page</label>
                                        </div>
                                        <div class="col-sm-4">
                                        </div>
                                        <div class="col-sm-1">
                                            <label class="control-label">Search</label>
                                        </div>
                                     <div class="col-sm-3">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-control"> </asp:TextBox>
                                                <span class="input-group-btn">
                                                     <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" Height="30" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    <asp:GridView ID="gvEmployeePaySlip" runat="server" Width="100%" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvEmployeePaySlip_PageIndexChanging"
                        AutoGenerateColumns="False" DataKeyNames="" ShowHeaderWhenEmpty="true" OnRowCommand="gvEmployeePaySlip_RowCommand" CssClass="table table-striped table-bordered">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%#Eval("esm_emp_id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CTC" ControlStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <%#Eval("esm_ctc")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Gross">
                                <ItemTemplate>
                                    <%#Eval("esm_gross")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Basic">
                                <ItemTemplate>
                                    <%#Eval("esm_basic")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="HRA">
                                <ItemTemplate>
                                    <%#Eval("esm_hra")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Conveyance Allowance">
                                <ItemTemplate>
                                    <%#Eval("esm_con_alw")%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Special Allowance">
                                <ItemTemplate>
                                    <%#Eval("esm_special_pay")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Other Earnings">
                                <ItemTemplate>
                                    <%#Eval("esm_other_earnings")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Professional Tax">
                                <ItemTemplate>
                                    <%#Eval("esm_ptax")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Loans">
                                <ItemTemplate>
                                    <%#Eval("esm_loans")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Other Deductions">
                                <ItemTemplate>
                                    <%#Eval("esm_deductions")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Amount Payable">
                                <ItemTemplate>
                                    <%#Eval("esm_total_payable")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit Details" runat="server" ImageUrl="~/admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit" CommandArgument='<%#Eval("esm_emp_id")%>' />
                                                <asp:ImageButton ID="imgpdf" ToolTip="Print Pdf" runat="server" ImageUrl="~/admin/Images/icons/icon-pdf.png" Height="20" Width="20"
                                                    CommandName="printpdf" CommandArgument='<%#Eval("esm_emp_id")%>' target="_blank"/>
                                            </td>
                                        </tr>
                                    </table>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

