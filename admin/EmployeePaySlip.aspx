<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmployeePaySlip.aspx.cs" Inherits="admin_EmployeePaySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="content-box-large">
            <div class="panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">PaySlip Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group">  </div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hf_esm_id" runat="server" Value="0" />
                            </div>
                      

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Id</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtId" ID="rfvtxtId" runat="server" ErrorMessage="Enter Id No" Text="Enter Id No" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />
                                    <%--<asp:RegularExpressionValidator ControlToValidate="txtId" ID="revtxtId" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="^[0-9]*$" />--%>
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Appraisal Year</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAppraisalYear" CssClass="form-control" runat="server" MaxLength="4" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAppraisalYear" ID="rfvtxtAppraisalYear" runat="server" ErrorMessage="Enter Appraisal Year" Text="Enter Appraisal Year" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtAppraisalYear" ID="revtxtAppraisalYear" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="^[0-9]*$" />

                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Band</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropBand" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Text="P" Value="P">P</asp:ListItem>
                                        <asp:ListItem Text="M" Value="M">M</asp:ListItem>
                                        <asp:ListItem Text="E" Value="E">E</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropBand" runat="server" ID="rfvdropBand"
                                        Display="Dynamic" ErrorMessage="Select Band." Text="Select Band." InitialValue="-1" ValidationGroup="payslip" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">CTC</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtCtc" CssClass="form-control" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtCtc" ID="rfvtxtCtc" runat="server" ErrorMessage="Enter CTC" Text="Enter CTC" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtCtc" ID="revtxtCtc" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="^[0-9]\d*(\.\d+)?$" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Gross</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtGross" CssClass="form-control" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtGross" ID="rfvtxtGross" runat="server" ErrorMessage="Enter Gross" Text="Enter Gross" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtGross" ID="revtxtGross" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="^[0-9]\d*(\.\d+)?$" />

                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Basic</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBasic" CssClass="form-control" runat="server" ReadOnly="true" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">HRA</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txthra" CssClass="form-control" runat="server" ReadOnly="true" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Conveyance Allowance</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtConveyanceAllowance" CssClass="form-control" runat="server" ReadOnly="true" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Special Pay</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtSpecialPay" CssClass="form-control" runat="server" ReadOnly="true" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Professional Tax</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtProfessionalTax" CssClass="form-control" runat="server" ReadOnly="true" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Deductions</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtDeductions" CssClass="form-control" runat="server" />
                                    <%--<asp:RequiredFieldValidator ControlToValidate="txtDeductions" ID="rfvtxtDeductions" runat="server" ErrorMessage="Enter Deductions" Text="Enter Deductions" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />--%>
                                    <asp:RegularExpressionValidator ControlToValidate="txtDeductions" ID="revtxtDeductions" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="^[0-9]\d*(\.\d+)?$" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Other Earnings</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtOtherEarnings" CssClass="form-control" runat="server" />
                                    <%--<asp:RequiredFieldValidator ControlToValidate="txtOtherEarnings" ID="rfvtxtOtherEarnings" runat="server" ErrorMessage="Enter Other Earnings" Text="Enter Other Earnings" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />--%>
                                    <asp:RegularExpressionValidator ControlToValidate="txtOtherEarnings" ID="revtxtOtherEarnings" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]\d*(\.\d+)?$" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Loans</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtLoans" CssClass="form-control" runat="server" />
                                    <%--<asp:RequiredFieldValidator ControlToValidate="txtLoans" ID="rfvtxtLoans" runat="server" ErrorMessage="Enter Loans" Text="Enter Loans" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" />--%>
                                    <asp:RegularExpressionValidator ControlToValidate="txtLoans" ID="revtxtLoans" runat="server" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payslip" ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]\d*(\.\d+)?$" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Total Amount Payable</label>
                                <div class="col-sm-2" style="padding-right: 0px">
                                    <asp:TextBox ID="txtTotalAmountPayable" CssClass="form-control" runat="server" ReadOnly="true" Width="95%" />
                                </div>

                                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="btn btn-success btn-sm btn-sm" OnClick="btnCalculate_Click" Width="7%" Height="30px" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="payslip"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" HeaderText="Errors List" />
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" OnClick="btnSubmit_Click" ValidationGroup="payslip" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                                 <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

