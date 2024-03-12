<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="BSI_info_Webform.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/assets/logo.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Register Page</title>
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

        #btnRegister {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

            #btnRegister:hover {
                background-color: #0056b3;
            }

        #logo {
            max-width: 100px;
            margin-bottom: 20px;
        }

        #LoginLink {
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
            <h2>Register Page</h2>
            <asp:TextBox ID="txtRegisterFirstName" runat="server" placeholder="FirstName" Required="true"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtRegisterLastName" runat="server" placeholder="LastName" Required="true"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtRegisterUsername" runat="server" placeholder="Username" Required="true"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtRegisterPassword" runat="server" TextMode="Password" placeholder="Password" Required="true"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtRegisterEmail" runat="server" type="email" placeholder="Email" Required="true"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtRegisterPhone" runat="server" placeholder="Phone" Required="true"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtRegisterPhone" ValidationExpression="^\d{12}$"
                ErrorMessage="Please enter a valid 12-digit phone number." Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <br />
            <asp:Label ID="lblRegistrationStatus" runat="server" Text="" ForeColor="Green" Visible="False"></asp:Label>
            <br />
            <a>Already have an account? </a>
            <a id="LoginLink" href="Login.aspx">Sign in</a>
        </div>
    </form>
</body>
</html>

