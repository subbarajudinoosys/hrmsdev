<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="OrganisationDetails.aspx.cs" Inherits="admin_OrganisationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Organisation Details </div>
                </div>
              
                        <div class="Paneldiv">
                            <div class="form-horizontal">
                                <div class="form-group"></div>
                                <div class="col-sm-12">
                                    <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>                                   
                                </div>
                               <%-- <div class="col-sm-12">
                                    <asp:Label ID="labelSubmit" class="message" runat="server" EnableViewState="false" ></asp:Label>
                                </div>--%>

                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">Organisation Name</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtOrganisationName" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtOrganisationName" runat="server" ID="rfvtxtOrganisationName"
                                                Display="Dynamic" ErrorMessage="Enter Organisation Name." Text="Enter Organisation Name." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">Tax ID</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtTaxID" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtTaxID" runat="server" ID="rfvtxtTaxID"
                                                Display="Dynamic" ErrorMessage="Enter Tax ID." Text="Enter Tax ID." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">Number Of Employees</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtNumberOfEmployees" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtNumberOfEmployees" runat="server" ID="rfvtxtNumberOfEmployees"
                                                Display="Dynamic" ErrorMessage="Enter Number Of Employees." Text="Enter Number Of Employees." ValidationGroup="orgdet" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ID="revtxtNumberOfEmployees" ControlToValidate="txtNumberOfEmployees" runat="server"
                                                Display="Dynamic" ValidationExpression="^[0-9]*$" ErrorMessage="Enter Number Only." Text="Enter Number Only." ValidationGroup="orgdet" ForeColor="Red" />

                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">Registration Number</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtRegistrationNumber" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtRegistrationNumber" runat="server" ID="rfvtxtRegistrationNumber"
                                                Display="Dynamic" ErrorMessage="Enter Registration Number." Text="Enter Registration Number." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">Phone</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtPhone" runat="server" ID="rfvtxtPhone"
                                                Display="Dynamic" ErrorMessage="Enter Phone Number." Text="Enter Phone Number." ValidationGroup="orgdet" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtPhone" runat="server" ForeColor="Red"
                                        ID="revtxtPhone" ValidationGroup="orgdet" ErrorMessage="Enter Valid Phone No."
                                        Text="Enter Valid Phone No." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">Fax</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtFax" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtFax" runat="server" ID="rfvtxtFax"
                                                Display="Dynamic" ErrorMessage="Enter Fax Number." Text="Enter Fax Number." ValidationGroup="orgdet" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtFax" runat="server" ForeColor="Red"
                                        ID="revtxtFax" ValidationGroup="orgdet" ErrorMessage="Enter Valid Fax No."
                                        Text="Enter Valid Fax No." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">Email</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" ID="rfvtxtEmail"
                                                Display="Dynamic" ErrorMessage="Enter Email." Text="Enter Email." ValidationGroup="orgdet" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ID="revtxtEmail" ControlToValidate="txtEmail" runat="server"
                                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email." Text="Enter Valid Email." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">Address Street 1</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtAddressStreet1" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtAddressStreet1" runat="server" ID="rfvtxtAddressStreet1"
                                                Display="Dynamic" ErrorMessage="Enter Address." Text="Enter Address." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">Address Street 2</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtAddressStreet2" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtAddressStreet2" runat="server" ID="rfvtxtAddressStreet2"
                                                Display="Dynamic" ErrorMessage="Enter Address." Text="Enter Address." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">City</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtCity" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtCity" runat="server" ID="rfvtxtCity"
                                                Display="Dynamic" ErrorMessage="Enter City." Text="Enter City." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">State/Province</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtState" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtState" runat="server" ID="rfvtxtState"
                                                Display="Dynamic" ErrorMessage="Enter State." Text="Enter State." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">Zip/Postal Code</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtZip" CssClass="form-control" runat="server" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtZip" runat="server" ID="rfvtxtZip"
                                                Display="Dynamic" ErrorMessage="Enter Zip Code." Text="Enter Zip Code." ValidationGroup="orgdet" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ID="revtxtZip" ControlToValidate="txtZip" runat="server"
                                                Display="Dynamic" ValidationExpression="^[0-9]*$" ErrorMessage="Enter Number Only." Text="Enter Number Only." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <label class="col-sm-2">Country</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="dropCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="dropCountry" ID="rfvdropCountry" runat="server" ErrorMessage="Select Country" Text="Select Country" ValidationGroup="orgdet" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                                        </div>
                                        <div class="col-sm-1"></div>
                                        <label class="col-sm-2">Note</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" TextMode="MultiLine" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtNote" runat="server" ID="rfvtxtNote"
                                                Display="Dynamic" ErrorMessage="Enter Note." Text="Enter Note." ValidationGroup="orgdet" ForeColor="Red" />
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="orgdet"
                                            ShowSummary="true" ForeColor="Red" HeaderText="Errors List" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12" style="text-align: center;">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="orgdet" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click" />
                                      <%--  <asp:Button ID="btnSubmitt" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="orgdet" " />--%>

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
                    <div class="panel-title ">Organisation Details List</div>
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
                     <asp:HiddenField ID="hf_oim_id" runat="server" Value="0" />
                    <asp:GridView ID="gvOrganisationDetailsList" runat="server" AllowPaging="true" Width="100%" PageSize="2"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvOrganisationDetailsList_RowCommand" OnPageIndexChanging="gvOrganisationDetailsList_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <%-- <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lbloim_id" runat="server" CssClass="hidden" Text='<%#Eval("oim_id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%#Eval("oim_org_name")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <%#Eval("oim_phone")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <%#Eval("oim_city")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit Organisation Details" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit Organisation Details" CommandArgument='<%#Eval("oim_id") %>' />
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
       </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

