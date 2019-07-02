<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="VacancyDetails.aspx.cs" Inherits="admin_VacancyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmanager" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Vacancy Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                        <div class="col-sm-12">
                            <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                        </div>


                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Job Title</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlJobTitle" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlJobTitle" runat="server" ID="rfvddlJobTitle"
                                        Display="Dynamic" Text="Select Job Title." ValidationGroup="vac" InitialValue="-1" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Vacancy Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtVacancyName" CssClass="form-control" runat="server" placeholder="Vacancy Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtVacancyName" runat="server" ID="rfvtxtVacancyName"
                                        Display="Dynamic" Text="Enter Vacancy Name." ValidationGroup="vac" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Hiring Manager</label>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="dropHiringManager" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropHiringManager" runat="server" ID="dropdropHiringManager"
                                        Display="Dynamic"  Text="Select Hiring Manager." ValidationGroup="vac" InitialValue="-1" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">No Of Positions</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPositions" CssClass="form-control" runat="server" placeholder="No Of Positions" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPositions" runat="server" ID="rfvtxtPositions"
                                        Display="Dynamic"  Text="Enter No Of Positions." ValidationGroup="vac" ForeColor="Red" />

                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Description</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" placeholder="Description" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtDescription" runat="server" ID="rfvtxtDescription"
                                        Display="Dynamic"  Text="Enter Description." ValidationGroup="vac" ForeColor="Red" />

                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Active</label>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtActivText" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="chkActive" runat="server" OnCheckedChanged="chkActive_CheckedChanged" AutoPostBack="true" />
                                </div>

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">User Defined</label>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtUserDefined1" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="chkUserDefined1" runat="server" OnCheckedChanged="chkUserDefined1_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <div class="col-sm-1"></div>

                                <label class="col-sm-2">User Defined</label>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtUserDefined2" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="chkUserDefined2" runat="server" OnCheckedChanged="chkUserDefined2_CheckedChanged" AutoPostBack="true" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">User Defined</label>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtUserDefined3" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="chkUserDefined3" runat="server" OnCheckedChanged="chkUserDefined3_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <div class="col-sm-1"></div>

                                <label class="col-sm-2">User Defined</label>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtUserDefined4" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="chkUserDefined4" runat="server" OnCheckedChanged="chkUserDefined4_CheckedChanged" AutoPostBack="true" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="vac"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="vac" OnClick="btnSubmit_Click" />
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
                <div class="content-box-large panel-heading">
                    <div class="panel-title">Certificate Details List</div>
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
                                                     <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" Height="30" OnClick="imgsearch_Click" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    </div>
                    <asp:HiddenField ID="hf_vacancyId" runat="server" Value="0" />
                    <asp:GridView ID="gvVacancy" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                         AutoGenerateColumns="false"  DataKeyNames="" CssClass="table table-striped table-bordered"
                         OnRowCommand="gvVacancy_RowCommand" OnPageIndexChanging="gvVacancy_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <Columns>
                            <asp:TemplateField HeaderText="Vacancy Id">
                                <ItemTemplate>
                               <%#Container.DataItemIndex+1 %>
                                   <asp:Label ID="lblvacancyId" runat="server" CssClass="hidden" Text='<%#Eval("vacancyId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Title">
                                <ItemTemplate>
                                    <%#Eval("Designation") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Vacancy Name">
                                <ItemTemplate>
                                    <%#Eval("VacancyName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Hiring Manager">
                                <ItemTemplate>
                                    <%#Eval("fullname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                             <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Record" CommandArgument='<%#Eval("vacancyId") %>' />
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
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

