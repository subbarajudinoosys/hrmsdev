<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="admin_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .gridheader {
            text-align: center !important;
        }

       
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <div class="row">

        <div class="content-box-large">
            <div class="panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Employee List</div>
                </div>
                <asp:UpdatePanel ID="pdatepanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-horizontal">
                            <div class="paneldiv-border">
                                <div class="form-group">
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Value="5" Selected="True">5</asp:ListItem>
                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                <asp:ListItem Value="50">50</asp:ListItem>
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
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-control"> </asp:TextBox>
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" CssClass="search-img" OnClick="imgsearch_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hf_emp_id" Value="0" runat="server" />
                            <asp:GridView ID="gvEmployee" runat="server" AllowPaging="true" Width="100%" PageSize="5"
                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
                                OnRowCommand="gvEmployee_RowCommand" OnPageIndexChanging="gvEmployee_PageIndexChanging" ShowHeaderWhenEmpty="true" EmptyDataText="No records found" EmptyDataRowStyle-HorizontalAlign="Center">
                                <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                                <%-- <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                                <Columns>
                                    <asp:TemplateField HeaderText="Emp_ID" ItemStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                          
                                              <%#Eval("emp_id")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                            <%#Eval("emp_firstname")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                            <%#Eval("emp_lastname")%>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                            <%#Eval("Department")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Job Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                            <%#Eval("Designation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Manager" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                            <%#Eval("emp_mgr")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                            CommandName="Edit" CommandArgument='<%#Eval("emp_id")  %>' />

                                                        <asp:ImageButton ID="ImageEduDetails" ToolTip="Education Details" runat="server" ImageUrl="~/Admin/Images/icons/icon-education.png" Height="20" Width="20"
                                                            CommandName="EditEduDetails" CommandArgument='<%#Eval("emp_id") + ","+Eval("emp_firstname") %>' /> 

                                                        <asp:ImageButton ID="imgEditBankDetails" ToolTip="Bank Details" runat="server" ImageUrl="~/admin/Images/icons/icon-bank.png" Height="22" Width="22"
                                                            CommandName="EditBankDetails" CommandArgument='<%#Eval("emp_id") + ","+Eval("emp_firstname") %>' />

                                                        <asp:ImageButton ID="ImageFamDetails" ToolTip="Family Details" runat="server" ImageUrl="~/admin/Images/icons/icon-family.jpg" Height="21" Width="21"
                                                            CommandName="EditFamilyDetails" CommandArgument='<%#Eval("emp_id")  + ","+Eval("emp_firstname") %>' />

                                                        <asp:ImageButton ID="ImageExeDetails" ToolTip="Exeperience Details" runat="server" ImageUrl="~/admin/Images/icons/icon-experience2.png" Height="20" Width="20"
                                                            CommandName="EditExeDetails" CommandArgument='<%#Eval("emp_id")  + ","+Eval("emp_firstname") %>' />
                                                    </td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                            </asp:GridView>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

