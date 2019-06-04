<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="LeaveTypes.aspx.cs" Inherits="admin_LeaveTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="css/paging-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Leave Types</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" ForeColor="#009900" EnableViewState="false" Text=""></asp:Label>
                            </div>
                       
                        <div class="form-group">
                            <div class="col-sm-12">
                              
                                <label class="col-sm-2">Leave Types</label>
                                <div class="col-sm-3">
                                      <asp:TextBox ID="txtLeaveTypes" CssClass="form-control" runat="server" MaxLength="45" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtLeaveTypes" ID="rfvtxtLeaveTypes" runat="server" ErrorMessage="Enter Leave Types" Text="Enter Leave Types" ValidationGroup="leaves" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-1"></div>
                                 <label class="col-sm-2">Available Leaves</label>
                                <div class="col-sm-3">
                                      <asp:TextBox ID="txtAvailableLeaves" CssClass="form-control" runat="server" MaxLength="45" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAvailableLeaves" ID="rfvtxtAvailableLeaves" runat="server" ErrorMessage="Enter Available Leaves" Text="Enter Available Leaves" ValidationGroup="leaves" ForeColor="Red" Display="Dynamic" />
                                </div>

                            </div>
                        </div>
                       
                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="leaves"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="leaves" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
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
                    <div class="panel-title ">Leave Type List</div>
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
                  <asp:HiddenField ID="hf_LeaveTypeId" Value="0" runat="server" />
                    <asp:GridView ID="gvLeaveType" runat="server" AllowPaging="true" Width="100%" PageSize="5"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvLeaveType_RowCommand" OnPageIndexChanging="gvLeaveType_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                       
                        <Columns>
                            <asp:TemplateField HeaderText="LeaveType Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblLeaveTpeId" runat="server" CssClass="hidden" Text='<%#Eval("LeaveTypeId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Leave Type">
                                <ItemTemplate>
                                    <%#Eval("LeaveType")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Available Leaves">
                                <ItemTemplate>
                                    <%#Eval("TotalLeaves")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Leave" CommandArgument='<%#Eval("LeaveTypeId") %>' />
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

