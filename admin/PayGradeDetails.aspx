<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="PayGradeDetails.aspx.cs" Inherits="admin_PayGradeDetails" %>

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
                    <div class="panel-title ">Pay Grade Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                            
                        </div>
                        

                        <div class="form-group">
                            <div class="col-sm-12">
                               
                                <label class="col-sm-2">PayGrade Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPaygradeName" CssClass="form-control" runat="server" placeholder="PayGrade Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPaygradeName" runat="server" ID="rfvtxtPaygradeName"
                                        Display="Dynamic" ErrorMessage="Enter PayGrade Name." Text="Enter PayGrade Name." ValidationGroup="paygrade" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                       

                    
                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="paygrade"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="paygrade" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click" />
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-12">&nbsp</div>
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">PayGrade List</div>
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


                    <asp:HiddenField ID="hf_PayGrade_Id" Value="0" runat="server" />
                    <asp:GridView ID="gvPayGradeList" runat="server" AllowPaging="true" Width="100%" PageSize="2"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvPayGradeList_RowCommand" OnPageIndexChanging="gvPayGradeList_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <%-- <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="PayGradeId">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblPayGrade_Id" runat="server" CssClass="hidden" Text='<%#Eval("PayGradeId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PayGradeName">
                                <ItemTemplate>
                                    <%#Eval("PayGradeName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit PayGrade" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit PayGrade" CommandArgument='<%#Eval("PayGradeId") %>' />
                                            </td>
                                        </tr>
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

