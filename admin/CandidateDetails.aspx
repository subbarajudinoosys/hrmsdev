<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="CandidateDetails.aspx.cs" Inherits="admin_CandidateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

     <script type="text/javascript">
         $(document).ready(function () {

             $("#ContentPlaceHolder1_txtApplicationDate").datepicker({

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
                    <div class="panel-title ">Candidate Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                              <%--  <asp:HiddenField ID="hf_can_id" runat="server" Value="0" />--%>
                                
                              
                         
                        </div>
                        

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">First Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="First Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtFirstName" runat="server" ID="rfvtxtFirstName"
                                        Display="Dynamic" ErrorMessage="Enter First Name." Text="Enter First Name." ValidationGroup="cand" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Middle Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtMiddleName" CssClass="form-control" runat="server" placeholder="Middle Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtMiddleName" runat="server" ID="rfvtxtMiddleName"
                                        Display="Dynamic" ErrorMessage="Enter Middle Name." Text="Enter Middle Name." ValidationGroup="cand" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Last Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtLastName" runat="server" ID="rfvtxtLastName"
                                        Display="Dynamic" ErrorMessage="Enter Last Name." Text="Enter Last Name." ValidationGroup="cand" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>                
                                <label class="col-sm-2">Email Id</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" placeholder="Email Id" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmailId" runat="server" ID="rfvtxtEmailId"
                                        Display="Dynamic" ErrorMessage="Enter Email Id." Text="Enter Email Id." ValidationGroup="cand" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtEmailId" runat="server"
                                        ID="revtxtEmailId" ValidationGroup="cand" ErrorMessage="Enter Valid Email Id."
                                        Text="Enter Valid Email Id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                         <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Contact No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server" placeholder="Contact No" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtContactNo" runat="server" ID="rfvtxtContactNo"
                                        Display="Dynamic" ErrorMessage="Enter Contact No." Text="Enter Contact No." ValidationGroup="cand" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtContactNo" runat="server" ForeColor="Red"
                                        ID="revtxtContactNo" ValidationGroup="cand" ErrorMessage="Enter Valid Contact No."
                                        Text="Enter Valid Contact No." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-1"></div>      
                                <label class="col-sm-2">Job Vacancy</label>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlJobVacancy" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlJobVacancy" runat="server" ID="rfvddlJobVacancy"
                                        Display="Dynamic" ErrorMessage="Select Job Vacancy." Text="Select Job Vacancy." ValidationGroup="cand" InitialValue="-1" ForeColor="Red" />
                                </div>
                                
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">KeyWords</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtKeyWords" CssClass="form-control" runat="server" placeholder="Keywords" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtKeyWords" runat="server" ID="rfvtxtKeyWords"
                                        Display="Dynamic" ErrorMessage="Enter KeyWords." Text="Enter KeyWords." ValidationGroup="cand" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Comment</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtComment" CssClass="form-control" runat="server" placeholder="Comment" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtComment" runat="server" ID="rfvtxtComment"
                                        Display="Dynamic" ErrorMessage="Enter Comment." Text="Enter Comment." ValidationGroup="cand" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                             
                                <label class="col-sm-2">Date Of Application</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtApplicationDate" CssClass="form-control" runat="server" placeholder="Date Of Application" />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtApplicationDate" runat="server" ID="rfvtxtApplicationDate"
                                        Display="Dynamic" ErrorMessage="Enter Date Of Application." Text="Enter Date Of Application." ValidationGroup="cand" ForeColor="Red" />
                                </div>
                                 <div class="col-sm-1"></div>
                                 <label class="col-sm-2">Upload Resume</label>
                                .
                                <div class="col-sm-3">
                                    <asp:FileUpload ID="fuResumeImage" runat="server" CssClass="file-upload" />
                                    <asp:HiddenField ID="hfResumeFileName" runat="server" />
                                 <%--   <asp:TextBox ID="txtUpload" runat="server"></asp:TextBox>--%>
                                  
                                    <%-- <asp:Label ID="lblResume" runat="server" <a href="ResumeDoc/20170504064344647.pdf" onclick="return redirectMe(this);">A</a>> </asp:Label> --%>
                                   <asp:Label ID="lblResume" runat="server"></asp:Label>
                                    
                                    <asp:RegularExpressionValidator ID="revfuResumeImage" runat="server" ErrorMessage="Only PDF files are allowed!" ValidationExpression="^.*\.(pdf|PDF)$"
                                        ControlToValidate="fuResumeImage" ValidationGroup="emp" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                


                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="cand"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="cand" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">Candidate List</div>
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
                                                     <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" Height="30" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    <asp:HiddenField ID="hf_can_id" runat="server" Value="0" />
                    <asp:GridView ID="gvCandidateList" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvCandidateList_RowCommand" OnPageIndexChanging="gvCandidateList_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Candidate Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblCandidate_id" runat="server" CssClass="hidden" Text='<%#Eval("CandidateId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                    <%#Eval("FirstName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                    <%#Eval("LastName")%>
                                </ItemTemplate>
                            </asp:TemplateField> 

                              <asp:TemplateField HeaderText="Email ID">
                                <ItemTemplate>
                                    <%#Eval("EmailID")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Contact No">
                                <ItemTemplate>
                                    <%#Eval("ContactNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Resume">
                                <ItemTemplate>
                                    <a  href='CandidateResume/<%#Eval("CanResumeFilePath")%>' target="_blank" >
                                        <asp:Label ID="lblResume1" runat="server" Text='<%#Eval("CanResumeUpload")%>'></asp:Label>

                                    </a>
                                 
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Candidate" CommandArgument='<%#Eval("CandidateId") %>' />

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

