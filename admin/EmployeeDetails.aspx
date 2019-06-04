<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="admin_EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />--%>
 <%--   <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>--%>
  


<%--  <script>
      $(function () {
          $("#<%= txtDateOfJoining.ClientID%>").datepicker({
              onSelect: function (selected) {
                  $("#ContentPlaceHolder1_txtDateOfJoining").focus();
              },
              format: 'yyyy-mm-dd',
              startDate: '-9d',
              endDate: '0d',
              autoclose: true

          }).attr('readonly', 'false');;
      });
  </script>--%>


    <script>
        $(function () {
            $("#txtDateOfJoining").datepicker();
            $("#txtDateOfBirth").datepicker();
            $("#txtExpiryDate").datepicker();
        });
  </script>


    <script type="text/javascript">
        $(document).ready(function () {

            $("#ContentPlaceHolder1_txtDateOfJoining").datepicker({

               // numberOfMonths: 1,
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
            }).attr('readonly', 'readonly');

            $("#ContentPlaceHolder1_txtDateOfBirth").datepicker({

                //numberOfMonths: 1,
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
            }).attr('readonly', 'readonly');

            $("#ContentPlaceHolder1_txtExpiryDate").datepicker({

                //numberOfMonths: 1,
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
            }).attr('readonly', 'readonly');
        });
    </script>

    <style>
        .ValidationColor {
            color:red;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Employee Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hf_S_No" runat="server" Value="0" />
                                <asp:HiddenField ID="hf_Department_Id" runat="server" Value="0" />
                            </div>
                       
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2" for="txtEmployeeID" >Employee ID<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEmployeeID" CssClass="form-control" runat="server" placeholder="Employee Code" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmployeeID" runat="server" ID="rfvtxtEmployeeCode"
                                        Display="Dynamic" ErrorMessage="Enter Employee ID." Text="Enter Employee ID." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Date Of Joining<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="txtDateOfJoining" CssClass="form-control" runat="server" placeholder="Date Of Joining"  />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtDateOfJoining" runat="server" ID="rfvtxtDateOfJoining"
                                        Display="Dynamic" ErrorMessage="Enter Date of Joining." Text="Enter Date of Joining." ValidationGroup="emp" CssClass="ValidationColor" />

                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2" for="txtFirstName">First Name<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="First Name" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtFirstName" runat="server" ID="rfvtxtFirstName"
                                        Display="Dynamic" ErrorMessage="Enter First Name." Text="Enter First Name." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2" for="txtMiddleName">Middle Name<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtMiddleName" CssClass="form-control" runat="server" placeholder="Middle Name" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtMiddleName" runat="server" ID="rfvtxtMiddleName"
                                        Display="Dynamic" ErrorMessage="Enter Middle Name." Text="Enter Middle Name." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2" for="txtLastName">Last Name<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtLastName" runat="server" ID="rfvtxtLastName"
                                        Display="Dynamic" ErrorMessage="Enter Last Name." Text="Enter Last Name." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2" >Date Of Birth<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server" placeholder="Date Of Birth"   />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtDateOfBirth" runat="server" ID="rfvtxtDateOfBirth"
                                        Display="Dynamic" ErrorMessage="Enter Date of Birth." Text="Enter Date of Birth." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2" for="txtMobileNo">Mobile No<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" placeholder="Mobile No" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" runat="server" ID="rfvtxtMobileNo"
                                        Display="Dynamic" ErrorMessage="Enter Mobile No." Text="Enter Mobile No." ValidationGroup="emp" CssClass="ValidationColor" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtMobileNo" runat="server" ForeColor="Red"
                                        ID="revtxtMobileNo" ValidationGroup="emp" ErrorMessage="Enter Valid Mobile No."
                                        Text="Enter Valid Mobile No." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2" for="txtEmailId">Email Id<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" placeholder="Email Id" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmailId" runat="server" ID="rfvtxtEmailId"
                                        Display="Dynamic" ErrorMessage="Enter Email Id." Text="Enter Email Id." ValidationGroup="emp" CssClass="ValidationColor" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtEmailId" runat="server"
                                        ID="revtxtEmailId" ValidationGroup="emp" ErrorMessage="Enter Valid Email Id."
                                        Text="Enter Valid Email Id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2" for="ddlDepartment">Department<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" ClientIDMode="Static">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlDepartment" runat="server" ID="rfvddlDepartment"
                                        Display="Dynamic" ErrorMessage="Select Department." Text="Select Department." ValidationGroup="emp" InitialValue="-1" CssClass="ValidationColor" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2" for="ddlDesignation">Designation<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AppendDataBoundItems="true" ClientIDMode="Static">
                                        <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlDesignation" runat="server" ID="rfvddlDesignation"
                                        Display="Dynamic" ErrorMessage="Select Designation." Text="Select Designation." ValidationGroup="emp" InitialValue="-1" CssClass="ValidationColor" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2" for="ddlStatus">Status<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem Text="-Select-" Value="-1">-Select-</asp:ListItem>
                                        <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="0">InActive</asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlStatus" runat="server" ID="rfvddlStatus"
                                        Display="Dynamic" ErrorMessage="Select Status." Text="Select Status." InitialValue="-1" ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2" for="txtPanNo">Pan No<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPanNo" CssClass="form-control" runat="server" placeholder="Pan No" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPanNo" runat="server" ID="rfvtxtPanNo"
                                        Display="Dynamic" ErrorMessage="Enter Pan No." Text="Enter Pan No." ValidationGroup="emp" ForeColor="Red" />
                                </div>

                               <%-- <label class="col-sm-2">Manager</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtManager" CssClass="form-control" runat="server" placeholder="Manager" ReadOnly="true" />
                                </div>--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                
                               
                                <label class="col-sm-2" for="txtAdharNo">Adhar No<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAdharNo" CssClass="form-control" runat="server" placeholder="Adhar No" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAdharNo" runat="server" ID="rfvtxtAdharNo"
                                        Display="Dynamic" ErrorMessage="Enter Adhar No." Text="Enter Adhar No." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                                 <div class="col-sm-1"></div>
                                <label class="col-sm-2" for="txtPassportNo">Passport No<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPassportNo" runat="server" CssClass="form-control" placeholder="Passport No" ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPassportNo" runat="server" ID="rfvtxtPassportNo"
                                        Display="Dynamic" ErrorMessage="Enter Passport No." Text="Enter Passport No." ValidationGroup="emp" CssClass="ValidationColor" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                
                                
                                <label class="col-sm-2" >Expiry Date<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtExpiryDate" CssClass="form-control" runat="server" placeholder="Expiry Date" 
                                          />
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                    <asp:RequiredFieldValidator ControlToValidate="txtExpiryDate" runat="server" ID="rfvtxtExpiryDate"
                                        Display="Dynamic" ErrorMessage="Enter Expiry Date." Text="Enter Expiry Date." ValidationGroup="emp" CssClass="ValidationColor" />
                                      
                                </div>
                                <div class="col-sm-1">
                                </div>
                                <label class="col-sm-2" for="txtAddress">Address<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Address" TextMode="MultiLine" ClientIDMode="Static" />

                                    <asp:RequiredFieldValidator ControlToValidate="txtExpiryDate" runat="server" ID="RequiredFieldValidator1"
                                        Display="Dynamic" ErrorMessage="Enter Expiry Date." Text="Enter Expiry Date." ValidationGroup="emp" CssClass="ValidationColor" />

                                   <%-- <asp:RequiredFieldValidator ControlToValidate="txtAddress" runat="server" ID="rfvtxtAddress" Display="Dynamic" ErrorMessage="Enter Address." Text="Enter Address." ValidationGroup="emp" CssClass="ValidationColor" />--%>
                                    <asp:RegularExpressionValidator ControlToValidate="txtAddress" ID="revtxtAddress"
                                        runat="server" ErrorMessage="Accepts maximum 200 characters."
                                        Text="Accepts maximum 200 characters." Display="Dynamic" ValidationGroup="emp"
                                        ValidationExpression="^[\s\S]{0,200}$" CssClass="ValidationColor" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">

                                
                                 <label class="col-sm-2" for="ddlLocation">Location<span class="ValidationColor">*</span></label>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" AppendDataBoundItems="true" ClientIDMode="Static">
                                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlLocation" runat="server" ID="rfvddlLocation"
                                        Display="Dynamic" ErrorMessage="Select Location." Text="Select Location." ValidationGroup="emp" InitialValue="-1" CssClass="ValidationColor" />

                                </div>
                              
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                
                               
                                 
                                 <label class="col-sm-2">Upload Resume</label>

                                <div class="col-sm-3">
                                    <asp:FileUpload ID="fuResumeImage" runat="server" />                                  
                                    <asp:HiddenField ID="hfResumeFileName" runat="server" />
                                    <%--<asp:Label ID="lblResume" runat="server"></asp:Label>--%>
                                    <a id="pdfView" href="#" target="_blank" runat="server"><asp:Label ID="lblResume" runat="server"></asp:Label></a>
                                    
                                    <asp:RegularExpressionValidator ID="revfuResumeImage" runat="server" ErrorMessage="Only PDF files are allowed!" ValidationExpression="^.*\.(pdf|PDF)$"
                                        ControlToValidate="fuResumeImage" ValidationGroup="emp" CssClass="ValidationColor"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Select Image</label>

                                <div class="col-sm-3">
                                    <asp:FileUpload ID="fuImageFile" runat="server" />
                                   
                                    <asp:HiddenField ID="hf_ImageFile" runat="server" />
                                  
                                    <asp:Label ID="lblImage" runat="server"></asp:Label>
                                    
                                    <asp:RegularExpressionValidator ID="revfuImageFile" runat="server" ErrorMessage="Only JPEG,PNG Files are allowed!" ValidationExpression="^.*\.(jpeg|JPEG|gif|GIF|png|PNG)$"
                                        ControlToValidate="fuImageFile" ValidationGroup="emp" CssClass="ValidationColor"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-1"></div>
                                <%--<label class="col-sm-2">Login Id</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLoginId" CssClass="form-control" runat="server" placeholder="Login Id" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtLoginId" runat="server" ID="rfvtxtLoginId"
                                            Display="Dynamic" ErrorMessage="Enter Login Id." Text="Enter Login Id." ValidationGroup="emp" ForeColor="Red" />
                                    </div>--%>
                            </div>
                        </div>

                        <asp:Panel ID="Panel1" runat="server">
                            <div class="form-group">
                                <div class="col-sm-12">
                                    
                                    <div class="col-sm-1"></div>
                                    <%--<label class="col-sm-2">Password</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" ID="rfvtxtPassword"
                                            Display="Dynamic" ErrorMessage="Enter Password." Text="Enter Password." ValidationGroup="emp" ForeColor="Red" />
                                    </div>--%>
                                </div>
                            </div>
                        </asp:Panel>


                        <div class="form-group">
                            <div class="col-sm-12">
                                <%--<asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="emp"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap"  />--%>
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
    </div>
</asp:Content>

