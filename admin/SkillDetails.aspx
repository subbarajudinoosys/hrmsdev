<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="SkillDetails.aspx.cs" Inherits="admin_SkillDetails" %>

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
                    <div class="panel-title ">Skill Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                                <%--<asp:HiddenField ID="hf_skill_id" runat="server" Value="0" />--%>
                               <%-- <asp:HiddenField ID="hf_Department_Id" runat="server" Value="0" />--%>
                            </div>
                       
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Role Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtRoleName" CssClass="form-control" runat="server" placeholder="Role Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtRoleName" runat="server" ID="rfvtxtRoleName"
                                        Display="Dynamic" ErrorMessage="Enter Role Name." Text="Enter Role Name." ValidationGroup="skill" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Skill Details</label>
                               <div class="col-sm-3">
                                    <asp:TextBox ID="txtSkillDetails" CssClass="form-control" runat="server" placeholder="Skill Details" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtSkillDetails" runat="server" ID="rfvtxtSkillDetails"
                                        Display="Dynamic" ErrorMessage="Enter Skill Details." Text="Enter Skill Details." ValidationGroup="skill" ForeColor="Red" />
                                </div>
                            </div>
                        </div>                   
                                       
                           <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" />
                                   
                                </div>                              
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="skill"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="skill" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">Skill List</div>
                </div>
                <div class="form-horizontal">
                    <div class="paneldiv-border">
                                <div class="form-group">
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                      <%--  <div class="col-sm-2">
                                            <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                <asp:ListItem Value="100">100</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>--%>
                                        <div class="col-sm-2">
                                            <label class="control-label">
                                                Records per page</label>
                                        </div>
                                        <div class="col-sm-4">
                                        </div>
                                        <%--<div class="col-sm-1">
                                            <label class="control-label">Search</label>
                                        </div>--%>
                                    <%-- <div class="col-sm-3">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-control"> </asp:TextBox>
                                                <span class="input-group-btn">
                                                     <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" Height="30" />
                                                </span>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                    <asp:HiddenField ID="hf_skill_id" runat="server" Value="0" />
                    <asp:GridView ID="gvSkillList" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvSkillList_RowCommand" OnPageIndexChanging="gvSkillList_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Skill Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblSkillId" runat="server" CssClass="hidden" Text='<%#Eval("SkillId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Role Name">
                                <ItemTemplate>
                                    <%#Eval("RoleName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Skill Details">
                                <ItemTemplate>
                                    <%#Eval("SkillDetails")%>
                                </ItemTemplate>
                            </asp:TemplateField>                            

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Skill" CommandArgument='<%#Eval("SkillId") %>' />

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

