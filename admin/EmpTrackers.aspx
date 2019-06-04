<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpTrackers.aspx.cs" Inherits="admin_EmpTrackers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
      <link href="css/paging-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Add Performance Tracker</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" ForeColor="#009900" EnableViewState="false" Text=""></asp:Label>
                            </div>
                       
                        <div class="form-group">
                            <div class="col-sm-12">
                              
                                <label class="col-sm-2">Tracker Name</label>
                                <div class="col-sm-3">
                                      <asp:TextBox ID="txtTrackerName" CssClass="form-control" runat="server" MaxLength="45" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtTrackerName" ID="rfvtxtTrackerName" runat="server" ErrorMessage="Enter Tracker Name" Text="Enter Tracker Name" ValidationGroup="track" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-1"></div>
                                 <label class="col-sm-2">Employee Name</label>
                                <div class="col-sm-3">
                                     <asp:DropDownList ID="dropEmployeeName" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropEmployeeName" runat="server" ID="rfvdropEmployeeName"
                                        Display="Dynamic" ErrorMessage="Select Employee Name." Text="Select Employee Name." ValidationGroup="track" InitialValue="-1" ForeColor="Red" />
                                </div>

                            </div>
                       </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                 <label class="col-sm-2">Available Reviewers</label>
                                <div class="col-sm-3">
                                    <asp:ListBox runat="server" ID="listAvailableReview" SelectionMode="Multiple"></asp:ListBox>                                  
                                    <asp:RequiredFieldValidator ControlToValidate="listAvailableReview" runat="server" ID="rfvlistAvailableReview"
                                        Display="Dynamic" ErrorMessage="Select Available Reviewers." Text="Select Available Reviewers." ValidationGroup="track" InitialValue="-1" ForeColor="Red" />
                                </div>

                                <div class="col-sm-1">
                                    <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-info btn-sm"  /> <br />
                                    <br />
                                    <asp:Button runat="server" ID="btnRemove" Text="Remove" OnClick="btnRemove_Click" CssClass="btn btn-info btn-sm" />
                                </div>
                                 <label class="col-sm-2">Assigned Reviewers</label>
                                <div class="col-sm-3">
                                    <asp:ListBox runat="server" ID="listAssignedReview" SelectionMode="Multiple"></asp:ListBox> 
                                    <asp:RequiredFieldValidator ControlToValidate="listAssignedReview" runat="server" ID="rfvlistAssignedReview"
                                        Display="Dynamic" ErrorMessage="Select Assigned Reviewers." Text="Select Assigned Reviewers." ValidationGroup="track" InitialValue="-1" ForeColor="Red" />
                                </div>

                            </div>
                        </div>

                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="track"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-5"></div>

                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">Employee Tracker List</div>
                </div>
                <div class="form-horizontal">
                    <div class="paneldiv-border">
                                <div class="form-group">
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
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
                    <asp:HiddenField ID="hf_track_id" runat="server" Value="0" />
                    <asp:GridView ID="gvTrackerList" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvTrackerList_RowCommand" OnPageIndexChanging="gvTrackerList_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Tracker Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lbl_TrackerId" runat="server" CssClass="hidden" Text='<%#Eval("TrackerId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tracker Name">
                                <ItemTemplate>
                                    <%#Eval("TrackerName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <%#Eval("EmployeeName")%>
                                </ItemTemplate>
                            </asp:TemplateField> 

                              <asp:TemplateField HeaderText="Assigned Reviewers">
                                <ItemTemplate>
                                    <%#Eval("fullname")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                          
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Tracker" CommandArgument='<%#Eval("TrackerId") %>' />

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

