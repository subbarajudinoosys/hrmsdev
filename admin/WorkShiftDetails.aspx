<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="WorkShiftDetails.aspx.cs" Inherits="admin_WorkShiftDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="content-box-large">
            <div class="col-md-12 panel-info">
                 <div class="content-box-header panel-heading">
                    <div class="panel-title ">Work Shift Details </div>
                </div>
                 <div class="Paneldiv">
                    <div class="form-horizontal">
                              <div class="form-group"> </div>
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" EnableViewState="false" Text=""></asp:Label>
                              
                            </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">Shift Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtShiftName" CssClass="form-control" runat="server" placeholder="Shift Name" />
                                    <asp:RequiredFieldValidator ControlToValidate="txtShiftName" runat="server" ID="rfvtxtShiftName"
                                        Display="Dynamic" ErrorMessage="Enter Shift Name." Text="Enter Shift Name." ValidationGroup="shift" ForeColor="Red" />
                                </div>
                                <div class="col-sm-1"></div>
                                <label class="col-sm-2">WorkHours From</label>
                                <div class="col-sm-3">
                                <asp:DropDownList ID="ddlFrom" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="-Select-" Value="0" Selected="True"/>
                                        <asp:ListItem Text="00:30" Value="00:30"/>
                                        <asp:ListItem Text="01:00" Value="01:00"/>
                                        <asp:ListItem Text="01:30" Value="01:30"/>
                                        <asp:ListItem Text="02:00" Value="02:00"/>
                                        <asp:ListItem Text="02:30" Value="02:30<"/>
                                        <asp:ListItem Text="03:00" Value="03:00"/>
                                        <asp:ListItem Text="03:30" Value="03:30"/>
                                        <asp:ListItem Text="04:00" Value="04:00"/>
                                        <asp:ListItem Text="04:30" Value="04:30"/>
                                        <asp:ListItem Text="05:00" Value="05:00"/>
                                        <asp:ListItem Text="05:30" Value="05:30"/>
                                        <asp:ListItem Text="06:00" Value="06:00"/>
                                        <asp:ListItem Text="06:30" Value="06:30"/>
                                        <asp:ListItem Text="07:00" Value="07:00"/>
                                        <asp:ListItem Text="07:30" Value="07:30"/>
                                        <asp:ListItem Text="08:00" Value="08:00"/>
                                        <asp:ListItem Text="08:30" Value="08:30"/>
                                        <asp:ListItem Text="09:00" Value="09:00"/>
                                        <asp:ListItem Text="09:30" Value="09:30"/>
                                        <asp:ListItem Text="10:00" Value="10:00"/>
                                        <asp:ListItem Text="10:30" Value="10:30"/>
                                        <asp:ListItem Text="11:00" Value="11:00"/>
                                        <asp:ListItem Text="11:30" Value="11:30"/>
                                        <asp:ListItem Text="12:00" Value="12:00"/>
                                        <asp:ListItem Text="12:30" Value="12:30"/>
                                        <asp:ListItem Text="13:00" Value="13:00"/>
                                        <asp:ListItem Text="13:30" Value="13:30"/>
                                        <asp:ListItem Text="14:00" Value="14:00"/>
                                        <asp:ListItem Text="14:30" Value="14:30"/>
                                        <asp:ListItem Text="15:00" Value="15:00"/>
                                        <asp:ListItem Text="15:30" Value="15:30"/>
                                        <asp:ListItem Text="16:00" Value="16:00"/>
                                        <asp:ListItem Text="16:30" Value="16:30"/>
                                        <asp:ListItem Text="17:00" Value="17:00"/>
                                        <asp:ListItem Text="17:30" Value="17:30"/>
                                        <asp:ListItem Text="18:00" Value="18:00"/>
                                        <asp:ListItem Text="18:30" Value="18:30"/>
                                        <asp:ListItem Text="19:00" Value="19:00"/>
                                        <asp:ListItem Text="19:30" Value="19:30"/>
                                        <asp:ListItem Text="20:00" Value="20:00"/>
                                        <asp:ListItem Text="20:30" Value="20:30"/>
                                        <asp:ListItem Text="21:00" Value="21:00"/>
                                        <asp:ListItem Text="21:30" Value="21:30"/>
                                        <asp:ListItem Text="22:00" Value="22:00"/>
                                        <asp:ListItem Text="22:30" Value="22:30"/>
                                        <asp:ListItem Text="23:00" Value="23:00"/>
                                        <asp:ListItem Text="23:30" Value="23:30"/>
                                       

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlFrom" ID="rfvddlFrom" runat="server" ErrorMessage="Select Work From." Text="Select Work From."
                                         ValidationGroup="shift" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                            </div>
                                </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-2">WorkHours To</label>
                                 <div class="col-sm-3">
                                <asp:DropDownList ID="ddlTo" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTo_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="-Select-" Value="0" Selected="True"/>
                                        <asp:ListItem Text="00:30" Value="00:30"/>
                                        <asp:ListItem Text="01:00" Value="01:00"/>
                                        <asp:ListItem Text="01:30" Value="01:30"/>
                                        <asp:ListItem Text="02:00" Value="02:00"/>
                                        <asp:ListItem Text="02:30" Value="02:30"/>
                                        <asp:ListItem Text="03:00" Value="03:00"/>
                                        <asp:ListItem Text="03:30" Value="03:30"/>
                                        <asp:ListItem Text="04:00" Value="04:00"/>
                                        <asp:ListItem Text="04:30" Value="04:30"/>
                                        <asp:ListItem Text="05:00" Value="05:00"/>
                                        <asp:ListItem Text="05:30" Value="05:30"/>
                                        <asp:ListItem Text="06:00" Value="06:00"/>
                                        <asp:ListItem Text="06:30" Value="06:30"/>
                                        <asp:ListItem Text="07:00" Value="07:00"/>
                                        <asp:ListItem Text="07:30" Value="07:30"/>
                                        <asp:ListItem Text="08:00" Value="08:00"/>
                                        <asp:ListItem Text="08:30" Value="08:30"/>
                                        <asp:ListItem Text="09:00" Value="09:00"/>
                                        <asp:ListItem Text="09:30" Value="09:30"/>
                                        <asp:ListItem Text="10:00" Value="10:00"/>
                                        <asp:ListItem Text="10:30" Value="10:30"/>
                                        <asp:ListItem Text="11:00" Value="11:00"/>
                                        <asp:ListItem Text="11:30" Value="11:30"/>
                                        <asp:ListItem Text="12:00" Value="12:00"/>
                                        <asp:ListItem Text="12:30" Value="12:30"/>
                                        <asp:ListItem Text="13:00" Value="13:00"/>
                                        <asp:ListItem Text="13:30" Value="13:30"/>
                                        <asp:ListItem Text="14:00" Value="14:00"/>
                                        <asp:ListItem Text="14:30" Value="14:30"/>
                                        <asp:ListItem Text="15:00" Value="15:00"/>
                                        <asp:ListItem Text="15:30" Value="15:30"/>
                                        <asp:ListItem Text="16:00" Value="16:00"/>
                                        <asp:ListItem Text="16:30" Value="16:30"/>
                                        <asp:ListItem Text="17:00" Value="17:00"/>
                                        <asp:ListItem Text="17:30" Value="17:30"/>
                                        <asp:ListItem Text="18:00" Value="18:00"/>
                                        <asp:ListItem Text="18:30" Value="18:30"/>
                                        <asp:ListItem Text="19:00" Value="19:00"/>
                                        <asp:ListItem Text="19:30" Value="19:30"/>
                                        <asp:ListItem Text="20:00" Value="20:00"/>
                                        <asp:ListItem Text="20:30" Value="20:30"/>
                                        <asp:ListItem Text="21:00" Value="21:00"/>
                                        <asp:ListItem Text="21:30" Value="21:30"/>
                                        <asp:ListItem Text="22:00" Value="22:00"/>
                                        <asp:ListItem Text="22:30" Value="22:30"/>
                                        <asp:ListItem Text="23:00" Value="23:00"/>
                                        <asp:ListItem Text="23:30" Value="23:30"/>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlTo" ID="rfvddlTo" runat="server" ErrorMessage="Select Work To ." Text="Select Work To."
                                         ValidationGroup="shift" ForeColor="Red" Display="Dynamic" InitialValue="-1" />
                            </div>
                                <div class="col-sm-1"></div>
                               <label class="col-sm-2">Duration</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server" Enabled="false" />
                                  <%--  <asp:RequiredFieldValidator ControlToValidate="txtDuration" runat="server" ID="rfvtxtDuration"
                                        Display="Dynamic" ErrorMessage="Enter Employee Name." Text="Enter Employee Name." ValidationGroup="user" ForeColor="Red" />--%>
                                </div>
                            </div>
                        </div>
                         
                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="shift"
                                    ShowSummary="true" Display="Dynamic" CssClass="span12 m-wrap" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success btn-sm" ValidationGroup="shift" OnClick="btnSubmit_Click" />
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
                    <div class="panel-title ">WorkShift List</div>
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


                    <asp:HiddenField ID="hf_Shift_Id" Value="0" runat="server"/>
                    <asp:GridView ID="gvWorkShiftList" runat="server" AllowPaging="true" Width="100%" PageSize="2"
                        AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                        OnRowCommand="gvWorkShiftList_RowCommand" OnPageIndexChanging="gvWorkShiftList_PageIndexChanging" ShowHeaderWhenEmpty="true">
                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                        <%-- <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="ShiftId">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:Label ID="lblShift_Id" runat="server" CssClass="hidden" Text='<%#Eval("ShiftId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ShiftName">
                                <ItemTemplate>
                                    <%#Eval("ShiftName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WorkHours From">
                                <ItemTemplate>
                                    <%#Eval("FromDate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WorkHours To">
                                <ItemTemplate>
                                    <%#Eval("ToDate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration">
                                <ItemTemplate>
                                    <%#Eval("Duration") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Edit Work Shift Details" runat="server" ImageUrl="~/Admin/Images/icons/icon-edit.png" Height="20" Width="20"
                                                    CommandName="Edit Work Shift Details" CommandArgument='<%#Eval("ShiftId") %>' />
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
</asp:Content>

