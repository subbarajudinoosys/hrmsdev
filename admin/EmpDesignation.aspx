<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpDesignation.aspx.cs" Inherits="admin_EmpDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/paging-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Job Titles</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" EnableViewState="false" Text=""></asp:Label>
                               <%-- <asp:HiddenField ID="hf_Designation_Id" Value="0" runat="server" />--%>
                            </div>
                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Department</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlDepartment" runat="server" ID="rfvddlDepartment"
                                        Display="Dynamic" ErrorMessage="Select Department." Text="Select Department." ValidationGroup="designation" InitialValue="-1" ForeColor="Red" />

                                </div>
                                <label class="col-sm-1">Job Title</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" MaxLength="50" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtDesignation" ID="rfvtxtDesignation" runat="server" ErrorMessage="Enter Designation." Text="Enter Designation."
                                         ValidationGroup="designation" ForeColor="Red" Display="Dynamic" />
                                </div>
                                 <label class="col-sm-1">Role Id</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlRoleId" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="-Select-" Value="-1"/>
                                        <asp:ListItem Text="Super Admin" Value="1"/>
                                        <asp:ListItem Text="Admin" Value="2"/>
                                        <asp:ListItem Text="Manager" Value="3"/>
                                        <asp:ListItem Text="User" Value="4"/>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlRoleid" ID="rfvddlRoleid" runat="server" ErrorMessage="Select Role Id" Text="Select Role Id."
                                         ValidationGroup="designation" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="designation"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="designation" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                                 <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
         <div class="col-sm-12">&nbsp</div>
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">JobTitles List </div>
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
                    <asp:HiddenField ID="hf_Designation_Id" Value="0" runat="server" />
                    <asp:GridView ID="gvDesignation" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvDesignation_RowCommand" OnPageIndexChanging="gvDesignation_PageIndexChanging" >
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Job Title Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblDesignation_Id" runat="server" CssClass="hidden" Text='<%#Eval("Designation_Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Departmentdesc">
                                <ItemTemplate>
                                    <%#Eval("Departmentdesc")%>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Job Title">
                                <ItemTemplate>
                                    <%#Eval("Designation")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                          
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Record" CommandArgument='<%#Eval("Designation_Id") %>' />

                                            <asp:ImageButton ID="imgDelete" ToolTip="Delete Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-delete.png" Height="20" Width="20"
                                                CommandName="Delete Record" CommandArgument='<%#Eval("Designation_Id") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />
                                        </td>
                                    </table>
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

