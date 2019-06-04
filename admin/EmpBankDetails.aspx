<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpBankDetails.aspx.cs" Inherits="admin_EmpBankDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <style>
         .EmpIDLbl
    {
             margin-left:600px;
             font-size:13px;
                 
    }
          .gridheader {
            text-align: center;
        }
    </style>

    <div class="row">
        <div class="content-box-large">
             <div class="col-md-12 panel-info">
            <div class="panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Bank Details
                         <asp:Label ID="lblEmpIdName" runat="server" ForeColor="White" CssClass="EmpIDLbl" ></asp:Label>
                    </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" runat="server" Text="" EnableViewState="false"> </asp:Label>
                                <asp:HiddenField ID="hf_emp_id" runat="server" Value="0" />
                            </div>
                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Bank Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" placeholder="Bank Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtBankName" runat="server" ID="rfvtxtBankName"
                                        Display="Dynamic" ErrorMessage="Enter Bank Name." Text="Enter Bank Name." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Account No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAccountNo" CssClass="form-control" runat="server" placeholder="Account No" MaxLength="20" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAccountNo" runat="server" ID="rfvtxtAccountNo"
                                        Display="Dynamic" ErrorMessage="Enter Account No." Text="Enter Account No." ValidationGroup="emp" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtAccountNo" runat="server" ForeColor="Red"
                                        ID="revtxtAccountNo" ValidationGroup="emp" ErrorMessage="Enter number only."
                                        Text="Enter number only." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Account Type</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Savings" Value="Savings"></asp:ListItem>
                                        <asp:ListItem Text="Current" Value="Current"></asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlAccountType" runat="server" ID="rfvddlAccountType"
                                        Display="Dynamic" ErrorMessage="Select Account Type." Text="Select Account Type." InitialValue="-1" ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">IFSC Code</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtIFSCCode" CssClass="form-control" runat="server" placeholder="IFSC Code" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtIFSCCode" runat="server" ID="rfvtxtIFSCCode"
                                        Display="Dynamic" ErrorMessage="Enter IFSC Code." Text="Enter IFSC Code." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Branch Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBranchName" CssClass="form-control" runat="server" placeholder="Branch Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtBranchName" runat="server" ID="rfvtxtBranchName"
                                        Display="Dynamic" ErrorMessage="Enter Branch Name." Text="Enter Branch Name." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Bank City</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBankCity" CssClass="form-control" runat="server" placeholder="Bank City" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtBankCity" runat="server" ID="rfvtxtBankCity"
                                        Display="Dynamic" ErrorMessage="Enter Bank City." Text="Enter Bank City." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">PF AccountNo</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPFAccountNo" CssClass="form-control" runat="server" placeholder="PF AccountNo" MaxLength="60" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPFAccountNo" runat="server" ID="rfvtxtPFAccountNo"
                                        Display="Dynamic" ErrorMessage="Enter PF AccountNo." Text="Enter PF AccountNo." ValidationGroup="emp" ForeColor="Red" />

                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">UAN No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtUAN" CssClass="form-control" runat="server" placeholder="UAN No" MaxLength="60" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtUAN" runat="server" ID="rfvtxtUAN"
                                        Display="Dynamic" ErrorMessage="Enter UAN No." Text="Enter UAN No." ValidationGroup="emp" ForeColor="Red" />

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="emp"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
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
    </div>
</asp:Content>

