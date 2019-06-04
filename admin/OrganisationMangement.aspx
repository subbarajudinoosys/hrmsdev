<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="OrganisationMangement.aspx.cs" Inherits="admin_OrganisationMangement" %>

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
                    <div class="panel-title ">Organisation</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                         <div class="form-group"></div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                
                                    
                             
                                <div class="col-sm-1">
                                <asp:ImageButton ID="imgOrganisationInfo" runat="server" ImageUrl="~/admin/Images/icons/icon-organisation.png" Height="50" Width="50" OnClick="imgOrganisationInfo_Click" ToolTip="Organization Information" />
                                    </div>
                              <a href="OrganisationDetails.aspx"><asp:label runat="server" CssClass="col-sm-2 ImgText">Organisation Details</asp:label> </a>
                                   
                                <div class="col-sm-1"></div>
                               
                                 <div class="col-sm-1">
                                <asp:ImageButton ID="imgLocations" runat="server" ImageUrl="~/admin/Images/icons/icon-location.png" Height="50" Width="50" OnClick="imgLocations_Click" ToolTip="Locations" />
                                    </div>
                                 <a href="LocationDetails.aspx"><asp:label CssClass="col-sm-2 ImgText" runat="server">Locations Details</asp:label> </a>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>

