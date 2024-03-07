<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logout.aspx.vb" Inherits="BSI_INFO_Webform_New.logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Logging out...

            <script type="text/javascript">
                // Redirect to the login page after a brief delay
                setTimeout(function () {
                    window.location.href = 'Login.aspx';
                }, 2000); // 2000 milliseconds (2 seconds) delay
            </script>
        </div>
    </form>
</body>
</html>