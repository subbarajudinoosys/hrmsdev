<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="apply_leave.aspx.cs"
    Inherits="admin_holiday_list" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>--%>

  <script>
           $(function () {
               $("#txtFromDate").datepicker();
               $("#txtToDate").datepicker();
           });
  </script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$("#ContentPlaceHolder1_txtBookingDate").datepicker();

            $("#ContentPlaceHolder1_txtFromDate").datepicker({
                numberOfMonths: 1,
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
            }).attr('readonly', 'readonly');

            $("#ContentPlaceHolder1_txtToDate").datepicker({

                numberOfMonths: 1,
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
            }).attr('readonly', 'readonly');
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server" />
    <%--  <div class="row">
            <h4 class="page-header">Apply Leave ><a style="font-size: 14px; margin-left: 5px" href="apply_leave.aspx">Add</a></h4>
    </div>--%>

    <div class="row" >
        <div class="content-box-large">
            <div class="col-sm-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Apply Leave </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="divbtn" id="divbtn" runat="server">
                                <asp:Button runat="server" ID="btnApply" CssClass="btn btn-info btn-sm"
                                    OnClick="btnApply_Click" Text="Apply" />
                            </div>
                        </div>
                        <div id="divApplyleave" runat="server" visible="false">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hf_id" runat="server" Value="0" />
                                <asp:HiddenField ID="hf_Emp_id" runat="server" Value="0" />
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="col-sm-2">
                                        <label class="control-label">From Date </label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtFromDate" runat="server" ID="rfvtxtFromDate"
                                            ValidationGroup="hol" ErrorMessage="Enter From Date." Text="Enter From Date." ForeColor="red"
                                            Display="Dynamic" />
                                    </div>
                                    <div class="col-sm-1"></div>
                                    <label class="col-sm-2">To Date </label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" MaxLength="50"  />
                                        <asp:RequiredFieldValidator ControlToValidate="txtToDate" runat="server" ID="rfvtxtToDate" Display="Dynamic"
                                            ValidationGroup="hol" ErrorMessage="Enter Holiday Date." Text="Enter Holiday Date." ForeColor="Red" />
                                        <asp:CompareValidator ID="cmptodate" runat="server" ControlToValidate="txtToDate" ForeColor="Red" ValidationGroup="hol" Display="Dynamic"
                                            ControlToCompare="txtFromDate" Operator="GreaterThanEqual" Type="Date" ErrorMessage="To date  must be greater than or Equal to  from date." />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <label class="col-sm-2">Leave Type </label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="dropleaveType" runat="server" ValidationGroup="hol" CssClass="form-control"
                                            AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1" Text="-- Select --" />
                                           
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="dropleaveType" runat="server" ID="RequiredFieldValidator1"
                                            ValidationGroup="hol" ErrorMessage="Select Leave Type." Text="Select Leave Type." ForeColor="Red"
                                            Display="Dynamic" InitialValue="-1" />
                                    </div>
                                    <div class="col-sm-1"></div>
                                    <label class="col-sm-2">Calendar Year </label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtCalYear" runat="server" CssClass="form-control" ReadOnly="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <label class="col-sm-2">Reason </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="200" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtReason" runat="server" ID="rfvtxtreason" ForeColor="Red"
                                            ValidationGroup="hol" ErrorMessage="Enter Leave Reson." Text="Enter Leave Reson." Display="Dynamic" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12" style="text-align: center;">

                                    <asp:Button runat="server" ID="cmdSave" CssClass="btn btn-success btn-sm" ValidationGroup="hol"
                                        OnClick="cmdSave_Click" Text="Save" />
                                    <asp:Button runat="server" ID="cmdCancel" CssClass="btn btn-danger btn-sm"
                                        OnClick="cmdCancel_Click" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">&nbsp</div>
            <div class="col-sm-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Leave Report</div>
                </div>
                <div class="form-horizontal">
                    <asp:GridView ID="gvRemainingLeaves" runat="server" EmptyDataText="No records found"
                        AutoGenerateColumns="False" CssClass="table table-striped table-bordered" Width="100%">
                        <AlternatingRowStyle CssClass="gridcolor" />
                        <Columns>
                            <asp:TemplateField HeaderText="SN" HeaderStyle-CssClass="panel-heading" ItemStyle-CssClass="gradeC">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave Type" SortExpression="LeaveType">
                                <ItemTemplate>
                                    <%#Eval("LeaveType")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.of Leaves Appllied" SortExpression="no_of_days">
                                <ItemTemplate>
                                    <%#Eval("no_of_days")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available Leaves" SortExpression="TotalLeaves">
                                <ItemTemplate>
                                    <%#Eval("TotalLeaves")%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Balance Leaves" SortExpression="ReaminingLeaves">
                                <ItemTemplate>
                                    <%#Eval("remainingleaves")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="col-sm-12 panel-info">
                        <div class="content-box-header panel-heading">
                            <div class="panel-title ">Leaves List</div>
                        </div>
                        <div class="form-horizontal">
                            <div class="paneldiv-border">
                                <div class="form-group">
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-2" >
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

                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-control"> </asp:TextBox>
                                        </div>
                                         <div class="col-sm-1">
                                            <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" CssClass="search-img" />
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <asp:GridView ID="gvLeaveList" runat="server" AllowPaging="true" EmptyDataText="No records found"
                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnPageIndexChanging="gvLeaveList_PageIndexChanging"
                                Width="100%" PageSize="10" UseCustomPager="true">
                                <PagerSettings Mode="Numeric" />
                                <PagerStyle CssClass="pagination1" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" SortExpression="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date" SortExpression="from_date">
                                        <ItemTemplate>
                                            <%#Eval("from_date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date" SortExpression="to_date">
                                        <ItemTemplate>
                                            <%#Eval("to_date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type" SortExpression="LeaveType">
                                        <ItemTemplate>
                                            <%#Eval("LeaveType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reason" SortExpression="reason">
                                        <ItemTemplate>
                                            <%#Eval("reason")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="No Of Days" SortExpression="no_of_days">
                                        <ItemTemplate>
                                            <%#Eval("no_of_days")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

