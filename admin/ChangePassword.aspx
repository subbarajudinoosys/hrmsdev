<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="admin_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/login-style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <div class="login-screen">
                <div class="app-title">
                    <img src="../images/logo-dinoosys.png" style="width: 80%;" />
                    
                </div>
    <div class="login-form">
     <asp:Label ID="lblenternewpass" runat="server" Text="New Password"></asp:Label>
        <div class="control-group">
        <asp:TextBox ID="txtnewpass" runat="server" CssClass="login-field" TextMode="Password"></asp:TextBox>
            <label class="login-field-icon fui-user" for="login-name"></label>
        <asp:RequiredFieldValidator ID="rfvnewpass" runat="server" Display="Dynamic" ControlToValidate="txtnewpass" CssClass="login-field"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revnewpass" runat="server" ControlToValidate="txtnewpass" ValidationExpression="^[\s\S]{0,8}$" CssClass="login-field"></asp:RegularExpressionValidator>
    </div>
        </div>
        <div class="login-form">
           
            <asp:Label ID="lblreemterpass" runat="server" Text="Re-Enter Password"></asp:Label>
            <div class="control-group">
            <asp:TextBox ID="txtreenterpass" runat="server" CssClass="login-field" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvrepass" runat="server" Display="Dynamic" ControlToValidate="txtreenterpass" CssClass="login-field"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvpassword" runat="server" ControlToCompare="txtreenterpass" ControlToValidate="txtnewpass" CssClass="login-field"></asp:CompareValidator>
        </div>
                </div>
                <asp:Button ID="confirm" runat="server" CssClass="btn btn-primary btn-large btn-block" OnClick="confirm_Click" Text="confirm Password" />
            </div>
        </div>
        
    </form>
</body>
</html>
