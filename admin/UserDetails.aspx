<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="admin_UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                 <div class="content-box-header panel-heading">
                    <div class="panel-title ">User Details </div>
                </div>
                 <div class="Paneldiv">
                    <div class="form-horizontal">
                              <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" EnableViewState="false" Text=""></asp:Label>
                              
                            </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Username</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Username" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtUsername" runat="server" ID="rfvtxtUsername"
                                        Display="Dynamic" ErrorMessage="Enter Username." Text="Enter Username." ValidationGroup="user" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">User Role</label>
                                <div class="col-sm-3">
                                <asp:DropDownList ID="ddlRoleId" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="-Select-" Value="-1"/>
                                        <asp:ListItem Text="Super Admin" Value="Super Admin"/>
                                        <asp:ListItem Text="Admin" Value="Admin"/>
                                        <asp:ListItem Text="Manager" Value="Manager"/>
                                        <asp:ListItem Text="User" Value="User"/>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlRoleid" ID="rfvddlRoleid" runat="server" ErrorMessage="Select Role Id" Text="Select Role Id."
                                         ValidationGroup="user" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                            </div>
                                </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Employee Name</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropEmployeeName" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropEmployeeName" runat="server" ID="rfvdropEmployeeName"
                                        Display="Dynamic" ErrorMessage="Select Employee Name." Text="Select Employee Name." ValidationGroup="user" ForeColor="Red" InitialValue="-1" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Status</label>
                                <div class="col-sm-3">
                                      <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1">-Select-</asp:ListItem>
                                        <asp:ListItem Text="Active" Value="Active">Active</asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="InActive">InActive</asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlStatus" runat="server" ID="rfvddlStatus"
                                        Display="Dynamic" ErrorMessage="Select Status." Text="Select Status." InitialValue="-1" ValidationGroup="user" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                           <asp:Panel ID="Panel1" runat="server">
                        <div class="form-group">
                             <div class="col-sm-12">
                                <label class="col-sm-2">Password</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" ID="rfvtxtPassword"
                                            Display="Dynamic" ErrorMessage="Enter Password." Text="Enter Password." ValidationGroup="user" ForeColor="Red" />
                                    </div>
                            <div class="col-sm-1"></div>
                                <label class="col-sm-2">Confirm Password</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtCnfmPassword" CssClass="form-control" runat="server" placeholder="Confirm Password" TextMode="Password" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtCnfmPassword" runat="server" ID="rfvtxtCnfmPassword"
                                            Display="Dynamic" ErrorMessage="Enter Confirm Password." Text="Enter Confirm Password." ValidationGroup="user" ForeColor="Red" />
                                         <asp:CompareValidator ID="cvtxtCnfmPassword" runat="server" ControlToValidate="txtCnfmPassword"
                        ControlToCompare="txtPassword" Operator="Equal" Type="String" Text="Password must be equal to Confirm Password."
                        ErrorMessage="Password must be equal to Confirm Password." ForeColor="Red"
                        ValidationGroup="user" Display="Dynamic"></asp:CompareValidator>
                                    </div>
                                 </div>
                        </div>
                               </asp:Panel>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="user"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="user" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click"/>
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click"/>
                            </div>
                        </div>
                    </div>
               </div>
            </div>
        </div>

          <div class="col-sm-12">&nbsp</div>
        <div class="content-box-large">
            <div class="col-sm-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">User Details List </div>
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

                    <asp:HiddenField ID="hf_UserId" Value="0" runat="server" />
                    <asp:GridView ID="gvUser" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvUser_RowCommand" OnPageIndexChanging="gvUser_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="User Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblUserId" runat="server" CssClass="hidden" Text='<%#Eval("UserId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Username">
                                <ItemTemplate>
                                    <%#Eval("Username")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UserRole">
                                <ItemTemplate>
                                    <%#Eval("UserRole")%>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="EmployeeName">
                                <ItemTemplate>
                                    <%#Eval("fullname")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <%#Eval("Status")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Record" CommandArgument='<%#Eval("UserId") %>' />

                                     <%--       <asp:ImageButton ID="imgDelete" ToolTip="Delete Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-delete.png" Height="20" Width="20"
                                                CommandName="Delete Record" CommandArgument='<%#Eval("UserId") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />--%>
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

