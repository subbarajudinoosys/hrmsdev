<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgot_Password.aspx.cs" Inherits="Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>

    <link href="css/login-style.css" rel="stylesheet" />

</head>
<body>
     <form id="form1" runat="server">
        <div class="login">
            <div class="login-screen">
                <div class="app-title">
                    <img src="images/logo-dinoosys.png" style="width: 90%;" />
                    <h2>Forgot Password</h2>
                </div>
               
                <div class="login-form">
                     <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <div class="control-group">
                        <asp:TextBox ID="txtemailId" runat="server" CssClass="login-field"  placeholder="EMAIL ID" />
                        <label class="login-field-icon fui-user" for="login-name"></label>
                        <div>&nbsp</div>
                        <asp:Label runat="server" ID="lblerror" ForeColor="Red"></asp:Label>
                    </div>                  

                    <%--<a class="btn btn-primary btn-large btn-block" href="#">login</a>--%>
                    <asp:Button ID="btnForgot" CssClass="btn btn-primary btn-large btn-block" runat="server" Text="Forgot Password" OnClick="btnForgot_Click" />
                    <a class="login-link" href="login.aspx">Back to login</a>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
