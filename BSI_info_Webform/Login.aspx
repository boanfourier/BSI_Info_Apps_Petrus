<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BSI_info_Webform.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/assets/logo.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Login Page</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f8f9fa;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form {
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
        }

        h2 {
            margin-bottom: 20px;
        }

        input {
            width: 100%;
            padding: 10px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #btnLogin {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

            #btnLogin:hover {
                background-color: #45a049;
            }

        #logo {
            max-width: 100px;
            margin-bottom: 20px;
        }

        #registerLink {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
            margin-top: 10px;
            display: inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img id="logo" src="/assets/Logo.png" alt="Logo" />
            <h2>Login Page</h2>
            <asp:TextBox ID="txtname" runat="server" placeholder="Username"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <a>No account?</a>
            <a id="registerLink" href="Register.aspx">Register here!</a>
        </div>
    </form>
</body>
</html>

