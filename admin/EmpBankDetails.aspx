<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmpBankDetails.aspx.cs" Inherits="admin_EmpBankDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="content-box-large">
             <div class="col-md-12 panel-info">
            <div class="panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Bank Details </div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="labelError" runat="server" Text="" EnableViewState="false"> </asp:Label>
                                <asp:HiddenField ID="hf_emp_ID" runat="server" Value="0"/>
                            </div>

                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Bank Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" placeholder="Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtBankName" runat="server" ID="rfvtxtBankName"
                                        Display="Dynamic" ErrorMessage="Enter Bank Name." Text="Enter Bank Name." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Account No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAccountNo" CssClass="form-control" runat="server" placeholder="Account No" MaxLength="20" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAccountNo" runat="server" ID="rfvtxtAccountNo"
                                        Display="Dynamic" Text="Enter Account No." ValidationGroup="emp" ForeColor="Red" />
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
                                        Display="Dynamic" Text="Select Account Type." InitialValue="-1" ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">IFSC Code</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtIFSCCode" CssClass="form-control" runat="server" placeholder="IFSC Code" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtIFSCCode" runat="server" ID="rfvtxtIFSCCode"
                                        Display="Dynamic" Text="Enter IFSC Code." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Branch</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBranchName" CssClass="form-control" runat="server" placeholder="Branch Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtBranchName" runat="server" ID="rfvtxtBranchName"
                                        Display="Dynamic" Text="Enter Branch Name." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">City</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtBankCity" CssClass="form-control" runat="server" placeholder="Bank City" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtBankCity" runat="server" ID="rfvtxtBankCity"
                                        Display="Dynamic" Text="EnterCity." ValidationGroup="emp" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">PF AccountNo</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPFAccountNo" CssClass="form-control" runat="server" placeholder="PF AccountNo" MaxLength="60" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtPFAccountNo" runat="server" ID="rfvtxtPFAccountNo"
                                        Display="Dynamic"  Text="Enter PF AccountNo." ValidationGroup="emp" ForeColor="Red" />

                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">UAN No</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtUAN" CssClass="form-control" runat="server" placeholder="UAN No" MaxLength="60" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtUAN" runat="server" ID="rfvtxtUAN"
                                        Display="Dynamic"  Text="Enter UAN No." ValidationGroup="emp" ForeColor="Red" />

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
    <div class="col-sm-12">&nbsp</div>
        <div class="content-box-large">
            <div class="col-sm-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Bank Details List</div>
                </div>
                <div class="form-horizontal">
                    <div class="paneldiv-border">
                                <div class="form-group">
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
                <asp:GridView ID="gvbankdetailsList" runat="server" AllowPaging="true" Width="100%" PageSize="10"
                        AutoGenerateColumns="False"  CssClass="table table-striped table-bordered" OnRowCommand="gvbank_RowCommand"

                        OnPageIndexChanging="gvbank_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblempid" runat="server" Text='<%#Eval("emp_id")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                       <asp:Label ID="lblS_No" runat="server" Text='<%#Eval("S_No")%>' ></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Primary Account">
                           <ItemTemplate>
                               
                               <asp:RadioButton ID="rbBank" runat="server" Checked='<%#Eval("IsPrimary").ToString().Equals("1") %>' AutoPostBack="true" OnCheckedChanged="rb1_CheckedChanged1" Text='<%#Eval("S_No")%>'  />            
                               <asp:HiddenField ID="hf_emp_id" runat="server" Value='<%#Eval("S_No")%>' Visible="false" /> 
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="BankName">
                            <ItemTemplate>
                               <asp:Label ID="lblname" runat="server" Text= '<%#Eval("emp_bankname")%>'></asp:Label>
                                </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AccountNo">
                            <ItemTemplate>
                                 <asp:Label ID="lblaccNo" runat="server" Text= '<%#Eval("emp_accno")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IFSC code">
                            <ItemTemplate>
                               <asp:Label ID="lblifsccode" runat="server" Text= '<%#Eval("emp_ifsccode")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Type">
                            <ItemTemplate>
                                <asp:Label ID="lbltype" runat="server" Text= '<%#Eval("emp_acctype")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                               <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="EditB" CommandArgument='<%#Eval("S_No") %>' />
                                            <asp:ImageButton ID="imgDelete" ToolTip="Delete Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-delete.png" Height="20" Width="20"
                                                CommandName="Delete Record" CommandArgument='<%#Eval("S_No") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                
</asp:Content>

