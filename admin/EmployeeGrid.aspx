<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="EmployeeGrid.aspx.cs" Inherits="admin_EmployeeGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style>
        .gridheader {
            text-align: center !important;
        }

       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <div class="row">

        <div class="content-box-large">
            <div class="panel-info">
                <div class="content-box-header panel-heading">
                    <div class="panel-title ">Employee List</div>
                </div>
                <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
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
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-control"> </asp:TextBox>
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:ImageButton ID="imgsearch" runat="server" ImageUrl="~/admin/Images/icons/icon-search.png" CssClass="search-img" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hf_empid" Value="0" runat="server" />
                            <asp:GridView ID="gvEmployeelist" runat="server" AllowPaging="true" Width="100%" PageSize="5"
                                AutoGenerateColumns="False" DataKeyNames="" CssClass="table table-striped table-bordered"
                                OnPageIndexChanging="gvEmployeelist_PageIndexChanging" ShowHeaderWhenEmpty="true">
                                <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination1" />
                                <%-- <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />--%>
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblemp_id" runat="server" CssClass="hidden" Text='<%#Eval("emp_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Employee Images">
                                       <ItemTemplate>
                                          <img src='EmployeeImages/<%#Eval("ImageFilePath")%>' style="height:50px; width:50px;" />                                        
                                       </ItemTemplate>
                                        
                                         </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Employee Details">
                                        <ItemTemplate>
                                          <b>  <%#Eval("emp_firstname")%> </b>
                                            <b>   <%#Eval("emp_lastname")%> </b> <br />
                                            <%#Eval("Department")%> <br />
                                            <%#Eval("Designation")%><br />
                                             <%#Eval("emp_mobile")%><br />
                                            <%#Eval("emp_email")%>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   
                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                            </asp:GridView>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

