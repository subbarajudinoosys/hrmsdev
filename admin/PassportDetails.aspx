<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="PassportDetails.aspx.cs" Inherits="admin_PassportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

     <script type="text/javascript">
         $(document).ready(function () {

             $("#ContentPlaceHolder1_txtPassportIssuedate").datepicker({

                 numberOfMonths: 1,
                 dateFormat: 'yy-mm-dd',
                 changeMonth: true,
                 changeYear: true,
             }).attr('readonly', 'readonly');

             $("#ContentPlaceHolder1_txtPassportExpirydate").datepicker({

                 numberOfMonths: 1,
                 dateFormat: 'yy-mm-dd',
                 changeMonth: true,
                 changeYear: true,
             }).attr('readonly', 'readonly');

             
         });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Passport Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                                <%--<asp:HiddenField ID="hf_pass_id" runat="server" Value="0" />
                                <asp:HiddenField ID="hf_Department_Id" runat="server" Value="0" />--%>
                            </div>
                       
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Employee Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEmployeeName" CssClass="form-control" runat="server" placeholder="Employee Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmployeeName" runat="server" ID="rfvtxtEmployeeName"
                                        Display="Dynamic" ErrorMessage="Enter Employee Name." Text="Enter Employee Name." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Passport Number</label>
                               <div class="col-sm-3">
                                    <asp:TextBox ID="txtPassportNumber" CssClass="form-control" runat="server" placeholder="Passport Number" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPassportNumber" runat="server" ID="rfvtxtPassportNumber"
                                        Display="Dynamic" ErrorMessage="Enter Passport Number." Text="Enter Passport Number." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                      
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Passport Issue Date</label>
                               <div class="col-sm-3">
                                    <asp:TextBox ID="txtPassportIssuedate" CssClass="form-control" runat="server" placeholder="Passport Issue date" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPassportIssuedate" runat="server" ID="rfvtxtPassportIssuedate"
                                        Display="Dynamic" ErrorMessage="Enter Passport Issue date." Text="Enter Passport Issue date." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Passport Expiry Date</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPassportExpirydate" CssClass="form-control" runat="server" placeholder="Passport Expiry Date" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPassportExpirydate" runat="server" ID="rfvtxtPassportExpirydate"
                                        Display="Dynamic" ErrorMessage="Enter Passport Expiry Date." Text="Enter Passport Expiry Date." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                     
                                                
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Pan No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPanNo" CssClass="form-control" runat="server" placeholder="Pan No" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPanNo" runat="server" ID="rfvtxtPanNo"
                                        Display="Dynamic" ErrorMessage="Enter Pan No." Text="Enter Pan No." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Adhar No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAdharNo" CssClass="form-control" runat="server" placeholder="Adhar No" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAdharNo" runat="server" ID="rfvtxtAdharNo"
                                        Display="Dynamic" ErrorMessage="Enter Adhar No." Text="Enter Adhar No." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>              
                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                 <label class="col-sm-2">Upload Passport Image</label>

                                <div class="col-sm-3">
                                    <asp:FileUpload ID="fuPassportImage" runat="server" />
                                   <%-- <asp:TextBox ID="txtUpload" runat="server"></asp:TextBox>--%>
                                    <asp:HiddenField ID="hfPassportFileName" runat="server" />
                                    <%--<asp:Label ID="lblResume" runat="server"></asp:Label>--%>
                                    <a id="pdfView" href="#" target="_blank" runat="server">
                                    <asp:Label ID="lblPassport" runat="server"></asp:Label></a>
                                    <asp:RegularExpressionValidator ID="revfuPassportImage" runat="server" ErrorMessage="Only PDF files are allowed!" ValidationExpression="^.*\.(pdf|PDF)$"
                                        ControlToValidate="fuPassportImage" ValidationGroup="emp" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                               
                                <div class="col-sm-1"></div>

                              <%--  <label class="col-sm-2">Select Image</label>
                                <div class="col-sm-3">
                                    <asp:FileUpload ID="fuImageFile" runat="server" />                                   
                                    <asp:HiddenField ID="hf_ImageFile" runat="server" />                                  
                                    <asp:Label ID="lblImage" runat="server"></asp:Label>
                                    <asp:RegularExpressionValidator ID="revfuImageFile" runat="server" ErrorMessage="Only JPEG,PNG Files are allowed!" ValidationExpression="^.*\.(jpeg|JPEG|gif|GIF|png|PNG)$"
                                        ControlToValidate="fuImageFile" ValidationGroup="emp" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>--%>
                            </div>
                        </div>

                    


                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="emp"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="emp" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">Passport List</div>
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
                    <asp:HiddenField ID="hf_pass_id" runat="server" Value="0" />
                    <asp:GridView ID="gvPassportList" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvPassportList_RowCommand" OnPageIndexChanging="gvPassportList_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Passport Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblPassportId" runat="server" CssClass="hidden" Text='<%#Eval("PassportId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <%#Eval("EmployeeName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Pasport Number">
                                <ItemTemplate>
                                    <%#Eval("PasportNumber")%>
                                </ItemTemplate>
                            </asp:TemplateField> 

                              <asp:TemplateField HeaderText="Passport Issuedate">
                                <ItemTemplate>
                                    <%#Eval("PassportIssuedate")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Passport ExpiryDate">
                                <ItemTemplate>
                                    <%#Eval("PassportExpiryDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Passport">
                                <ItemTemplate>
                                    <a  href='PassportImages/<%#Eval("ImageFilePath")%>' target="_blank" >
                                        <asp:Label ID="lblPaasport1" runat="server" Text='<%#Eval("ImageUpload")%>'></asp:Label>

                                    </a>
                                 
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Passport" CommandArgument='<%#Eval("PassportId") %>' />

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

