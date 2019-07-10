<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpFamilyDetails.aspx.cs" Inherits="admin_EmpFamilyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <link href="css/paging-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
   

    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">

                    

                    <div class="panel-title ">Family Details
                        <asp:Label ID="lblEmpIdName" runat="server" ForeColor="White" CssClass="EmpIDLbl" ></asp:Label>
                    </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" Text="" EnableViewState="false"></asp:Label>
                            </div>
                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label style="margin-bottom: -10px" class="col-sm-3">Relation<span class="ValidationColor">*</span> </label>
                                <label for="txtRelFirstName" style="margin-bottom: -10px" class="col-sm-3">First Name<span class="ValidationColor">*</span></label>
                                <label for="txtRelLastName" style="margin-bottom: -10px" class="col-sm-3">Last Name<span class="ValidationColor">*</span></label>
                             
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropRelationship" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Father" Value="Father"></asp:ListItem>
                                        <asp:ListItem Text="Mother" Value="Mother"></asp:ListItem>
                                        <asp:ListItem Text="Spouse" Value="Spouse"></asp:ListItem>
                                        <asp:ListItem Text="Child" Value="Child"></asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropRelationship" runat="server" ID="rfvdropRelationship"
                                        Display="Dynamic" ErrorMessage="Select RelationShip." Text="Select RelationShip." InitialValue="-1" ValidationGroup="family" ForeColor="Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtRelFirstName" CssClass="form-control" runat="server" placeholder="First Name" ClientIDMode="Static" />

                                    <asp:RequiredFieldValidator ControlToValidate="txtRelFirstName" runat="server" ID="rfvtxtRelFirstName"
                                        Display="Dynamic" ErrorMessage="Enter First Name." Text="Enter First Name." ValidationGroup="family" ForeColor="Red" />
                                </div>

                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtRelLastName" CssClass="form-control" runat="server" placeholder="Last Name" ClientIDMode="Static" />

                                    <asp:RequiredFieldValidator ControlToValidate="txtRelLastName" runat="server" ID="rfvtxtRelLastName"
                                        Display="Dynamic" ErrorMessage="Enter Last Name." Text="Enter Last Name." ValidationGroup="family" ForeColor="Red" />
                                </div>

                          
                        </div>
                            </div>

                          <div class="form-group">
                            <div class="col-sm-12">
                               
                                <label for="txtEmpAge" style="margin-bottom: -10px" class="col-sm-3">Age</label>
                                <label style="margin-bottom: -10px" class="col-sm-3">Employment Status <span class="ValidationColor">*</span></label>
                            </div>
                        </div>

                          <div class="form-group">
                            <div class="col-sm-12">
                           

                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEmpAge" CssClass="form-control" runat="server" placeholder="Age" ClientIDMode="Static" />
                                   <%-- <asp:RequiredFieldValidator ControlToValidate="txtEmpAge" runat="server" ID="rfvtxtEmpAge"
                                        Display="Dynamic" ErrorMessage="Enter Age." Text="Enter Age." ValidationGroup="family" ForeColor="Red" />--%>
                                </div>

                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropEmpStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Employed" Value="Employed"></asp:ListItem>
                                        <asp:ListItem Text="UnEmployed" Value="UnEmployed"></asp:ListItem>
                                        <asp:ListItem Text="SelfEmployed" Value="SelfEmployed"></asp:ListItem>
                                        <asp:ListItem Text="Retired" Value="Retired"></asp:ListItem>
                                        <asp:ListItem Text="None" Value="None"></asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropEmpStatus" runat="server" ID="rfvdropEmpStatus"
                                        Display="Dynamic" ErrorMessage="Select Employment Status." Text="Select Employment Status." InitialValue="-1" ValidationGroup="family" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                            

                        <%--<div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="family"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="family" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
       </div>
        <div class="col-sm-12">&nbsp</div>
   <%-- <div class="row">--%>
        <div class="row">
    <div class="col-md-15 panel-info">
        <div class="content-box-large">
            <div class="col-sm-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Family Details List</div>
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
                                                     <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" Height="30" OnClick="imgsearch_Click" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                    <asp:HiddenField ID="hf_familyId" runat="server" Value="0" />


                    <asp:GridView ID="gvFamilyDetails" runat="server" AllowPaging="true" Width="100%" PageSize="2" HeaderStyle-CssClass="gridheader"
                        AutoGenerateColumns="False" DataKeyNames="S_No" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvFamilyDetails_RowCommand" OnPageIndexChanging="gvFamilyDetails_PageIndexChanging" ShowHeaderWhenEmpty="true" EmptyDataText="No records found">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                      
                      
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblFamily_Id" runat="server" CssClass="hidden" Text='<%#Eval("S_No")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Relation" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("Relationship")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("FirstName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <%#Eval("LastName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridheader">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit Family" CommandArgument='<%#Eval("S_No") %>' />
                                                <asp:ImageButton ID="imgDelete" ImageUrl="~/Admin/Images/icons/icon-delete.png" runat="server" Width="20px" Height="20px"
                                                    CommandName="Delete Family" ToolTip="Delete Family" CommandArgument='<%# Eval("S_No") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />
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
        </div>
  
</asp:Content>

