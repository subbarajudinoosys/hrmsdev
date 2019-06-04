<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="LocationDetails.aspx.cs" Inherits="admin_LocationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/paging-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Location</div>
                </div>
                <div class="Paneldiv">
                    <div class="form-horizontal">
                        <div class="form-group"></div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" ForeColor="#009900" EnableViewState="false" Text=""></asp:Label>
                            </div>
                        
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Location Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="45" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtName" ID="rfvtxtName" runat="server" ErrorMessage="Enter Name" Text="Enter Name" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Country</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="dropCountry" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dropCountry" ID="rfvdropCountry" runat="server" ErrorMessage="Select Country" Text="Select Country" ValidationGroup="location" ForeColor="Red" Display="Dynamic" InitialValue="-1"/>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                               <label class="col-sm-2">State/Province</label>
                               <div class="col-sm-3">
                                    <asp:TextBox ID="txtState" CssClass="form-control" runat="server" MaxLength="45" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtState" ID="rfvtxtState" runat="server" ErrorMessage="Enter State" Text="Enter State" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">City</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtCity" CssClass="form-control" runat="server" MaxLength="45" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtCity" ID="rfvtxtCity" runat="server" ErrorMessage="Enter City" Text="Enter City" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                               <label class="col-sm-2">Address</label>
                               <div class="col-sm-3">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtAddress" ID="rfvtxtAddress" runat="server" ErrorMessage="Enter Address" Text="Enter Address" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Zip/PostalCode</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtZip" CssClass="form-control" runat="server" MaxLength="10" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtZip" ID="rfvtxtZip" runat="server" ErrorMessage="Enter Zip Code" Text="Enter Zip Code" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="revtxtZip" ControlToValidate="txtZip" runat="server"
                                      Display="Dynamic" ValidationExpression="^[0-9]*$" ErrorMessage="Enter Number Only." Text="Enter Number Only." ValidationGroup="location" ForeColor="Red"/>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                               <label class="col-sm-2">Phone</label>
                               <div class="col-sm-3">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" MaxLength="20"/>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPhone" ID="rfvtxtPhone" runat="server" ErrorMessage="Enter Phone" Text="Enter Phone" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                   <asp:RegularExpressionValidator ControlToValidate="txtPhone" runat="server" ForeColor="Red"
                                        ID="revtxtPhone" ValidationGroup="location" ErrorMessage="Enter Valid Phone No."
                                        Text="Enter Valid Phone No." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">Fax</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtFax" CssClass="form-control" runat="server" MaxLength="20" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtFax" ID="rfvtxtFax" runat="server" ErrorMessage="Enter Fax" Text="Enter Fax" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ControlToValidate="txtFax" runat="server" ForeColor="Red"
                                        ID="revtxtFax" ValidationGroup="location" ErrorMessage="Enter Fax."
                                        Text="Enter Fax." ValidationExpression="^[0-9]{10,15}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        


                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Notes</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtNotes" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine"/>
                                    <asp:RequiredFieldValidator ControlToValidate="txtNotes" ID="rfvtxtNotes" runat="server" ErrorMessage="Enter Notes" Text="Enter Notes" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <%-- <div class="col-sm-1"></div>
                                <label class="col-sm-2">CompanyCode</label>
                                 <div class="col-sm-3">
                                    <asp:TextBox ID="txtCompanyCode" CssClass="form-control" runat="server" MaxLength="200"/>
                                    <%--<asp:RequiredFieldValidator ControlToValidate="txtNotes" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Notes" Text="Enter Notes" ValidationGroup="location" ForeColor="Red" Display="Dynamic" />
                                </div>--%>
                            </div>
                        </div>



                         
                        <div class="form-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="location"
                                ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="location" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                                 <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click" />
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
                    <div class="panel-title ">Location Details List </div>
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
                    <asp:HiddenField ID="hf_LocationId" Value="0" runat="server" />
                    <asp:GridView ID="gvLocation" runat="server" AllowPaging="true" Width="100%" PageSize="5"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvLocation_RowCommand" OnPageIndexChanging="gvLocation_PageIndexChanging">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />

                        <%--  <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Location Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblLocationId" runat="server" CssClass="hidden" Text='<%#Eval("LocationId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <%#Eval("Location")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <%#Eval("City")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <%#Eval("State")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <%#Eval("Country")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr></tr>
                                        <td>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Edit Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                CommandName="Edit Record" CommandArgument='<%#Eval("LocationId") %>' />

                                            <asp:ImageButton ID="imgDelete" ToolTip="Delete Record" runat="server" ImageUrl="~/Admin/Images/icons/icon-delete.png" Height="20" Width="20"
                                                CommandName="Delete Record" CommandArgument='<%#Eval("LocationId") %>' OnClientClick="javascript:return confirm('Are You Sure To Delete Details')" />
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

