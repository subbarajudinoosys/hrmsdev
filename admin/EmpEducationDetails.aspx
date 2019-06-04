<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpEducationDetails.aspx.cs" Inherits="admin_EmpEducationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <link href="css/paging-style.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {


            $("#ContentPlaceHolder1_txtYearOfPassing").datepicker({

                dateFormat: 'yy',
                changeYear: true,
                yearRange: "-50:-0",
            }).attr('readonly', 'readonly');


        });
    </script>

     <style>
         .EmpIDLbl
    {
             margin-left:600px;
             font-size:13px;
                 
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
                    <div class="panel-title ">Education Details
                         <asp:Label ID="lblEmpIdName" runat="server" ForeColor="White" CssClass="EmpIDLbl" ></asp:Label>
                    </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" runat="server" EnableViewState="false"></asp:Label>
                            </div>
                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Education Type</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">School/College Name</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Board/University Name</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Education Level</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="DropEducationType" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="--Select EducationType--" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Post Graduation" Value="Post Graduation"></asp:ListItem>
                                        <asp:ListItem Text="Graduation" Value="Graduation"></asp:ListItem>
                                        <asp:ListItem Text="Diploma" Value="Diploma"></asp:ListItem>
                                        <asp:ListItem Text="Intermediate" Value="Intermediate"></asp:ListItem>
                                        <asp:ListItem Text="Schooling" Value="Schooling"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="DropEducationType" runat="server" ID="rfvDropEducationType"
                                        Display="Dynamic" ErrorMessage="Select Education Type." Text="Select Education Type." InitialValue="-1" ValidationGroup="educ" ForeColor="Red" />
                                </div>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtSchoolOrCollegeName" runat="server" CssClass="form-control" placeholder="School/College Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtSchoolOrCollegeName" ID="rfvtxtSchoolOrCollegeName" runat="server" ErrorMessage="Enter School/College Name." Text="Enter School/College Name." ValidationGroup="educ" ForeColor="Red" Display="Dynamic" />

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBoardOrUniversityName" runat="server" CssClass="form-control" placeholder="Board/University Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtBoardOrUniversityName" ID="rfvtxtBoardOrUniversityName" runat="server" ErrorMessage="Enter Board/University Name." Text="Enter Board/University Name." ValidationGroup="educ" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="DropEducationLevel" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Education Level--" Value="-1" Selected="True" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="DropEducationLevel" runat="server" ID="rfvDropEducationLevel"
                                        Display="Dynamic" ErrorMessage="Select Education Level." Text="Select Education Level." InitialValue="-1" ValidationGroup="educ" ForeColor="Red" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Specialization</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Year Of Passing</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Percentage</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Category</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Specialization"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtSpecialization" ID="rfvtxtSpecialization" runat="server" ErrorMessage="Enter Specialization." Text="Enter Specialization." ValidationGroup="educ" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="DropYear" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="--Select Year--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="DropYear" runat="server" ID="rfvDropYear"
                                        Display="Dynamic" ErrorMessage="Select Year Of Passing." Text="Select Year Of Passing." InitialValue="-1" ValidationGroup="educ" ForeColor="Red" />

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPercentage" runat="server" CssClass="form-control" placeholder="Percentage"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPercentage" ID="rfvtxtPercentage" runat="server" ErrorMessage="Enter Percentage." Text="Enter Percentage." ValidationGroup="educ" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">

                                        <asp:ListItem Text="--Select Category--" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                                        <asp:ListItem Text="Distance" Value="Distance"></asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlCategory" runat="server" ID="rfvddlCategory"
                                        Display="Dynamic" ErrorMessage="Select Category." Text="Select Category." InitialValue="-1" ValidationGroup="educ" ForeColor="Red" />
                                </div>

                            </div>
                        </div>

                     <div class="form-group">
                            <div class="col-sm-12">
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Start Date</label>
                                <label style="margin-bottom: -10px !important;" class="col-sm-3">Completed On</label>                                 
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtStartDate" CssClass="form-control" runat="server" placeholder="From Date" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtStartDate" runat="server" ID="rfvtxtStartDate"  Display="Dynamic" ErrorMessage="Enter Start Date." Text="Enter Start Date." ValidationGroup="educ" ForeColor="Red" />
                                </div>
                                <div class="col-sm-3">
                                     <asp:TextBox ID="txtCompletedOn" CssClass="form-control" runat="server" placeholder="To Date" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtCompletedOn" runat="server" ID="rfvtxtCompletedOn"
                                        Display="Dynamic" ErrorMessage="Enter Completed On." Text="Enter Completed On." ValidationGroup="exp" ForeColor="Red" />
                                   <%-- <asp:CompareValidator ID="cmptxtCompletedOn" runat="server" ControlToValidate="txtCompletedOn" ForeColor="Red" ValidationGroup="educ" Display="Dynamic"
                                            ControlToCompare="txtStartDate" Operator="GreaterThanEqual" Type="Date" ErrorMessage="To date  must be greater than or Equal to  Start date." />--%>

                                </div>
                             
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="educ"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="educ" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">Education Details List </div>
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
                    <asp:HiddenField ID="hf_Edu_Id" Value="0" runat="server" />
                    <asp:GridView ID="gvEducation" runat="server" AllowPaging="true" Width="100%" PageSize="10" HeaderStyle-CssClass="gridheader"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvEducation_RowCommand" OnPageIndexChanging="gvEducation_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Education Id" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblEdu_Id" runat="server" CssClass="hidden" Text='<%#Eval("Edu_Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Education Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("Edu_Type")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Education Courses" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("Edu_Level")%>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Specialization" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("Specialization")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="StartDate" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("StartDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="CompletedOn" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("CompletedOn")%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Record" CommandArgument='<%#Eval("Edu_Id") %>' />

                                            <asp:ImageButton ID="imgDelete" ToolTip="Delete Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-delete.png" Height="20" Width="20"
                                                CommandName="Delete Record" CommandArgument='<%#Eval("Edu_Id") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />
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

