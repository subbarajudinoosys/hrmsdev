<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="DocumentDetails.aspx.cs" Inherits="admin_DocumentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

    <link href="css/paging-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Document Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                                
                        </div>
                        

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Select File</label>

                                <div class="col-sm-3">
                                    <asp:FileUpload ID="fuDocFile" runat="server" />
                                   
                                    <asp:HiddenField ID="hfDocFile" runat="server" />
                                  
                                    <asp:Label ID="lblFile" runat="server"></asp:Label>
                                    <asp:RegularExpressionValidator ID="revfuDocFile" runat="server" ErrorMessage="Only PDF and DOC Files are allowed!" ValidationExpression="^.*\.(pdf|PDF|doc|docx)$"
                                        ControlToValidate="fuDocFile" ValidationGroup="doc" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                               
                                 <div class="col-sm-1"></div>
                                <label class="col-sm-2">Description/Comments</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtComments" CssClass="form-control" runat="server" placeholder="Comments" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtComments" runat="server" ID="rfvtxtComments"
                                        Display="Dynamic" ErrorMessage="Enter Comments." Text="Enter Comments." ValidationGroup="doc" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                       

                    
                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="doc"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="doc" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">List Of Documents</div>
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
                    <asp:HiddenField ID="hf_Document" runat="server" Value="0" />
                    <asp:GridView ID="gvDocumentList" runat="server" AllowPaging="true" Width="100%" PageSize="5"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnPageIndexChanging="gvDocumentList_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Document Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblDocumentId" runat="server" CssClass="hidden" Text='<%#Eval("DocumentId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description/Comments">
                                <ItemTemplate>
                                    <%#Eval("Comments")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="List Of Documents">
                                <ItemTemplate>
                                    <a  href='FilesUpload/<%#Eval("FilePath")%>' target="_blank" >
                                        <asp:Label ID="lblFile1" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>

                                    </a>
                                 
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

