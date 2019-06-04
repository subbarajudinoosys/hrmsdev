<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmployeeKeyPerformance.aspx.cs" Inherits="admin_EmployeeKeyPerformance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css" />
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
   <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
    <div class="row">
    <div class="content-box-large">
      <div class="col-md-12 panel-info">
         <div class="content-box-header panel-heading">
                    <div class="panel-title ">Employee Key Performance Details </div>
         </div>
         
             <div class="Paneldiv">
               <div class="form-horizontal">
                 <div class="form-group"></div>
                   <div class="col-sm-12">
                      <asp:Label ID="labelError" class="message" runat="server" EnableViewState="false"></asp:Label>
                      <asp:HiddenField ID="hf_ekp_id" runat="server" Value="0" />
                   </div>
                   <div class="form-group">
                     <div class="col-sm-12">
                        <label class="col-sm-2">Job Title</label>
                        <div class="col-sm-3">
                           <asp:DropDownList ID="dropJobTitle" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ControlToValidate="dropJobTitle" ID="rfvdropJobTitle" runat="server" ErrorMessage="Select Job Title" Text="Select Job Title" ValidationGroup="empkey" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                        </div>
                        <div class="col-sm-1"></div>
                        <label class="col-sm-2">Key Performance Indicator</label>
                        <div class="col-sm-3">
                           <asp:TextBox ID="txtKeyPerformanceIndicator" CssClass="form-control" runat="server"/>
                           <asp:RequiredFieldValidator ControlToValidate="txtKeyPerformanceIndicator" runat="server" ID="rfvtxtKeyPerformanceIndicator"
                             Display="Dynamic" ErrorMessage="Enter Key Performance Indicator." Text="Enter Key Performance Indicator." ValidationGroup="empkey" ForeColor="Red" />
                        </div>
                     </div>
                   </div>
                   <div class="form-group">
                     <div class="col-sm-12">
                        <label class="col-sm-2">Minimum Rating</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="txtMinimumRating" CssClass="form-control" runat="server"/>
                           <asp:RequiredFieldValidator ControlToValidate="txtMinimumRating" runat="server" ID="rfvtxtMinimumRating"
                             Display="Dynamic" ErrorMessage="Enter Minimum Rating." Text="Enter Minimum Rating." ValidationGroup="empkey" ForeColor="Red" />
                        </div>
                        <div class="col-sm-1"></div>
                        <label class="col-sm-2">Maximum Rating</label>
                        <div class="col-sm-3">
                           <asp:TextBox ID="txtMaximumRating" CssClass="form-control" runat="server"/>
                           <asp:RequiredFieldValidator ControlToValidate="txtMaximumRating" runat="server" ID="rfvtxtMaximumRating"
                             Display="Dynamic" ErrorMessage="Enter Maximum Rating." Text="Enter Maximum Rating." ValidationGroup="empkey" ForeColor="Red" />
                        </div>
                     </div>
                   </div>
                   <div class="form-group">
                       <div class="col-sm-12">
                          <label class="col-sm-2">Make Default Scale</label>
                          <div class="col-sm-3">
                          <asp:CheckBox ID="chkMakeDefaultScale" runat="server"/>
                          </div>
                          </div>
                   </div>
                   <div class="form-group">
                        <div class="col-sm-12">
                               <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="empkey"
                                            ShowSummary="true" ForeColor="Red" HeaderText="Errors List" />
                        </div>
                   </div>
                   <div class="form-group">
                         <div class="col-sm-12" style="text-align: center;">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="empkey" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click"/>
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-sm" OnClick="btnReset_Click"/>
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
                    <div class="panel-title ">KeyPerformance Details List</div>
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
                    <asp:GridView ID="gvPerformanceDetailsList" runat="server" AllowPaging="true" Width="100%" PageSize="2"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvPerformanceDetailsList_RowCommand" OnPageIndexChanging="gvPerformanceDetailsList_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <%-- <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                           <%-- <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="ekp_id" runat="server" CssClass="hidden" Text='<%#Eval("ekp_id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Job Title">
                                <ItemTemplate>
                                    <%#Eval("ekp_job_title")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Key Performance Indicator">
                                <ItemTemplate>
                                    <%#Eval("ekp_key_performance_indicator")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Minimum Rating">
                                <ItemTemplate>
                                    <%#Eval("ekp_min_rating")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Maximum Rating">
                                <ItemTemplate>
                                    <%#Eval("ekp_max_rating")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit Performance Details" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit Performance Details" CommandArgument='<%#Eval("ekp_id") %>' />
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

