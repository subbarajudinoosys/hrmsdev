<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpExpDetails.aspx.cs" Inherits="admin_EmpExpDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <link href="css/paging-style.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {


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

    <style>
         .EmpIDLbl
    {
             margin-left:600px;
             font-size:13px;
                 
    }
         .ValidationColor
         {
             color:red;
         }
          .gridheader {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-sm-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title">Experience Details
                         <asp:Label ID="lblEmpIdName" runat="server" ForeColor="White" CssClass="EmpIDLbl" ></asp:Label>
                    </div>
                </div>
                <div class="Paneldiv">

                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" Text="" EnableViewState="false"></asp:Label>
                            </div>
                       
                        <div class="form-group">
                            <div class="col-sm-12">

                                <div class="col-sm-2">
                                    <label class="control-label">From Date<span class="ValidationColor">*</span></label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="From Date" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtFromDate" runat="server" ID="rfvtxtFromDate"
                                        Display="Dynamic" ErrorMessage="Enter From Date." Text="Enter From Date." ValidationGroup="exp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-2">
                                    <label class="control-label">To Date<span class="ValidationColor">*</span></label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" placeholder="To Date" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtToDate" runat="server" ID="rfvtxtToDate"
                                        Display="Dynamic" ErrorMessage="Enter To Date." Text="Enter To Date." ValidationGroup="exp" ForeColor="Red" />
                                    <asp:CompareValidator ID="cmptxtToDate" runat="server" ControlToValidate="txtToDate" ForeColor="Red" ValidationGroup="exp" Display="Dynamic"
                                            ControlToCompare="txtFromDate" Operator="GreaterThanEqual" Type="Date" ErrorMessage="To date  must be greater than or Equal to  from date." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">

                                <div class="col-sm-2">
                                    <label class="control-label">Company Name<span class="ValidationColor">*</span></label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" placeholder="Company Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtCompanyName" runat="server" ID="rfvtxtCompanyName"
                                        Display="Dynamic" ErrorMessage="Enter Company Name." Text="Enter Company Name." ValidationGroup="exp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-2">
                                    <label class="control-label">Designation<span class="ValidationColor">*</span></label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEmpDesignation" CssClass="form-control" runat="server" placeholder="Designation" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmpDesignation" runat="server" ID="rfvtxtEmpDesignation"
                                        Display="Dynamic" ErrorMessage="Enter Designation." Text="Enter Designation." ValidationGroup="exp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-2">
                                    <label class="control-label">Technology</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtTechnology" CssClass="form-control" runat="server" placeholder="Technology" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtTechnology" runat="server" ID="rfvtxtTechnology"
                                        Display="Dynamic" ErrorMessage="Enter Technology." Text="Enter Technology." ValidationGroup="exp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-2">
                                    <label class="control-label">Project Titles</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtProjectDetails" CssClass="form-control" runat="server" placeholder="Project Details" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtProjectDetails" runat="server" ID="rfvtxtProjectDetails"
                                        Display="Dynamic" ErrorMessage="Enter Project Details." Text="Enter Project Details." ValidationGroup="exp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>

                       <%-- <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="exp"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                        </div>--%>

                        <div class="form-group">

                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="exp" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
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
                    <div class="panel-title ">Experience Details List</div>
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
                    <asp:HiddenField ID="hf_S_No" runat="server" Value="0" />
                    <asp:GridView ID="gvEmpExp" runat="server" AllowPaging="true" Width="100%" PageSize="5" HeaderStyle-CssClass="gridheader"
                        AutoGenerateColumns="False" DataKeyNames="S_No" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvEmpExp_RowCommand" OnPageIndexChanging="gvEmpExp_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblS_No" runat="server" CssClass="hidden" Text='<%#Eval("S_No")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Company Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("CompanyName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="From Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("FromDate","{0:dd/MM/yyyy}")%>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="To Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("ToDate","{0:dd/MM/yyyy}")%>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">

                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit Exp" CommandArgument='<%#Eval("S_No") %>' />
                                                <asp:ImageButton ID="imgDelete" ImageUrl="~/Admin/Images/icons/icon-delete.png" runat="server" Width="20px" Height="20px"
                                                    CommandName="Delete Exp" ToolTip="Delete Details" CommandArgument='<%# Eval("S_No") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />
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

