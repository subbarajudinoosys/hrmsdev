<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="OtherDetails.aspx.cs" Inherits="admin_OtherDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Other Details</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                         <div class="form-group"></div>

                        <div class="form-group">
                            <div class="col-sm-12">

                                
                                 <div class="col-sm-1">
                                <asp:ImageButton ID="imgDepartment" runat="server" ImageUrl="~/admin/Images/icons/icon-department.png" Height="50" Width="50" OnClick="imgDepartment_Click" ToolTip="Department Details" />
                                    </div>
                               <a href="EmpDepartment.aspx"> <asp:label CssClass="col-sm-2 ImgText" runat="server">Department Details</asp:label> </a>

                                <div class="col-sm-1"></div>
                                
                                <div class="col-sm-1">
                                <asp:ImageButton ID="imgPayRoll" runat="server" ImageUrl="~/admin/Images/icons/icon-payroll.png" Height="50" Width="50" OnClick="imgPayRoll_Click" ToolTip="Payroll Details" />
                                    </div>
                                <a href="EmployeePaySlip.aspx"> <asp:label CssClass="col-sm-2 ImgText" runat="server">PayRoll Details</asp:label> </a>


                                 <div class="col-sm-1"></div>

                                 
                                <div class="col-sm-1">
                                <asp:ImageButton ID="imgMenuaccess" runat="server" ImageUrl="~/admin/Images/icons/icon-menuacees.png" Height="50" Width="50" OnClick="imgMenuaccess_Click" ToolTip="MenuAccess Details" />
                                    </div>
                               <asp:label CssClass="col-sm-2 ImgText" runat="server">Menu Access Details</asp:label>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>

