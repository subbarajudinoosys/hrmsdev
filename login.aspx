<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


<html>
<head>
    <meta charset="UTF-8">
    <title>Login Form</title>


    <link href="css/login-style.css" rel="stylesheet" />
   

</head>

<body>
    <form id="form1" runat="server">
        <div class="login">
            <div class="login-screen">
                <div class="app-title">
                    <img src="images/logo-dinoosys.png" style="width: 90%;" />
                    <h2>Employee Login</h2>
                </div>
               
                <div class="login-form">
                     <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <div class="control-group">
                        <asp:TextBox ID="txtuserId" runat="server" CssClass="login-field"  placeholder="username" />
                        <label class="login-field-icon fui-user" for="login-name"></label>
                    </div>

                    <div class="control-group">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="login-field" TextMode="Password" placeholder="password" />
                        <label class="login-field-icon fui-lock" for="login-pass"></label>
                    </div>

                    <%--<a class="btn btn-primary btn-large btn-block" href="#">login</a>--%>
                    <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-large btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    <a class="login-link" href="Forgot_Password.aspx">Lost your password?</a>

                </div>
            </div>
        </div>
    </form>
</body>
</html>

