<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmployeePaymentVoucher.aspx.cs" Inherits="admin_EmployeePaymentVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtDate").datepicker({

                numberOfMonths: 1,
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
            }).attr('readonly', 'readonly');
        });
    </script>
    <style>
        .Paneldiv {
            background-color: #f9f9f9;
            border: 1px solid #e2e2e2;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">

                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Payment Voucher </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group">  </div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hf_epm_id" Value="0" runat="server" />
                            </div>
                      
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Debited From</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropDebit" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1">-Select-</asp:ListItem>
                                        <asp:ListItem Text="DINOOSYS TECHNOLOGIES PVT.LTD." Value="DINOOSYS TECHNOLOGIES PVT.LTD.">DINOOSYS TECHNOLOGIES PVT.LTD.</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropDebit" ID="rfvdropDebit" runat="server" ErrorMessage="Select Debited From" Text="Select Debited From" ValidationGroup="payvoucher" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Paid To</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPaidTo" CssClass="form-control" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPaidTo" ID="rfvtxtPaidTo" runat="server" ErrorMessage="Enter Paid To" Text="Enter Paid To" ValidationGroup="payvoucher" ForeColor="Red" Display="Dynamic" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="col-sm-12">
                                <label class="col-sm-2">Mode Of Payment</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropPaymentMode" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="-Select-" Value="-1">-Select-</asp:ListItem>
                                        <asp:ListItem Text="Cash" Value="Cash">Cash</asp:ListItem>
                                        <asp:ListItem Text="Cheque" Value="Cheque">Cheque</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropPaymentMode" ID="rfvdropPaymentMode" runat="server" ErrorMessage="Select Payment Mode" Text="Select Payment Mode" ValidationGroup="payvoucher" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Amount</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAmount" ID="rfvtxtAmount" runat="server" ErrorMessage="Enter Amount" Text="Enter Amount" ValidationGroup="payvoucher" ForeColor="Red" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtAmount" runat="server" ID="revtxtAmount" ErrorMessage="Enter Number Only" Text="Enter Number Only" ValidationGroup="payvoucher" ForeColor="Red" Display="Dynamic" ValidationExpression="^[0-9]\d*(\.\d+)?$" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Towards</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtTowards" CssClass="form-control" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAmount" ID="rfvtxtTowards" runat="server" ErrorMessage="Enter Towards" Text="Enter Towards" ValidationGroup="payvoucher" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Date</label>
                                <div class="col-sm-3">
                                    <div class="input-append date datepicker span12">
                                        <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" ReadOnly="true" />
                                        <span class="add-on"><i class="icon-calendar"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="payvoucher"
                                    ShowSummary="true" ForeColor="Red" HeaderText="Errors List" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="payvoucher" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

