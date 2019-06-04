<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="JobManagement.aspx.cs" Inherits="admin_JobManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Job</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>

                        <div class="form-group">
                            <div class="col-sm-12">

                                <div class="col-sm-1">
                                    <asp:ImageButton ID="imgJobTitles" runat="server" ImageUrl="~/admin/Images/icons/icon-jobtitles.png" Height="50" Width="50" OnClick="imgJobTitles_Click" ToolTip="JobTitles" />

                                </div>

                                <a href="EmpDesignation.aspx">
                                    <asp:Label CssClass="col-sm-2 ImgText" runat="server">Job Titles</asp:Label></a>

                                <div class="col-sm-1"></div>

                                <div class="col-sm-1">
                                    <asp:ImageButton ID="imgPayGrades" runat="server" ImageUrl="~/admin/Images/icons/icon-paygrade.png" Height="50" Width="50" OnClick="imgPayGrades_Click" ToolTip="Pay Grades" />
                                </div>
                                <a href="PayGradeDetails.aspx">
                                    <asp:Label CssClass="col-sm-2 ImgText" runat="server">Pay Grades</asp:Label></a>


                                <div class="col-sm-1"></div>

                                <div class="col-sm-1">
                                    <asp:ImageButton ID="imgWorkShifts" runat="server" ImageUrl="~/admin/Images/icons/icon-workshift.png" Height="50" Width="50" OnClick="imgWorkShifts_Click" ToolTip="Work Shifts" />
                                </div>
                                <a href="WorkShiftDetails.aspx">
                                   <asp:Label CssClass="col-sm-2 ImgText" runat="server">Work Shifts</asp:Label></a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

