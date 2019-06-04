<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="admin_UserManagement" %>

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
                    <div class="panel-title ">Users</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                         <div class="form-group"></div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                
                                <div class="col-sm-1">
                                <asp:ImageButton ID="imgUsers" runat="server" ImageUrl="~/admin/Images/icons/icon-users.png" Height="50" Width="50" OnClick="imgUsers_Click" ToolTip="User Details"/>
                                </div>
                                
                                <a href="UserDetails.aspx"> <asp:label CssClass="col-sm-2 ImgText" runat="server">Users</asp:label></a>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>

