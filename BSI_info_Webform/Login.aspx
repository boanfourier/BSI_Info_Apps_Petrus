<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BSI_info_Webform.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/assets/logo.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Login Page</title>
    <meta charset="utf-8" />
    <style>
        .gradient-custom-2 {
            /* fallback for old browsers */
            background: #fccb90;
            /* Chrome 10-25, Safari 5.1-6 */
            background: -webkit-linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593);
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            background: linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593);
        }

        @media (min-width: 768px) {
            .gradient-form {
                height: 100vh !important;
            }
        }

        @media (min-width: 769px) {
            .gradient-custom-2 {
                border-top-right-radius: .3rem;
                border-bottom-right-radius: .3rem;
            }
        }

        #logo {
            max-width: 150px;
        }
    </style>
</head>
<body>
    <section class="h-100 gradient-form" style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-xl-10">
                    <div class="card rounded-3 text-black">
                        <div class="row g-0">
                            <div class="col-lg-6">
                                <div class="card-body p-md-5 mx-md-4">

                                    <div class="text-center">
                                        <img id="logo" src="/assets/Logo.png"  style="width: 185px;"alt="Logo" />
                                        <h4 class="mt-1 mb-5 pb-1">BSI INFO</h4>
                                    </div>

                                    <form id="form1" runat="server">
                                        <p>Please login to your account</p>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                            <asp:Label AssociatedControlID="txtUsername" CssClass="form-label" runat="server">Username</asp:Label>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            <asp:Label AssociatedControlID="txtPassword" CssClass="form-label" runat="server">Password</asp:Label>
                                        </div>

                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" Text="Login" OnClick="btnLogin_Click" />
                                        </div>

                                        <div class="d-flex align-items-center justify-content-center pb-4">
                                            <p class="mb-0 me-2">Don't have an account?</p>
                                            <a id="registerLink" href="Register.aspx">Register here!</a>
                                        </div>

                                    </form>

                                </div>
                            </div>
                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2">
                                <div class="text-white px-3 py-4 p-md-5 mx-md-4">
                                    <h4 class="mb-4">We are more than just a company</h4>
                                    <p class="small mb-0">Welcome to BSI INFO, the leading information and coordination center for all your activities and events! 
                                        We are proud to provide the best service in managing and organizing various events, from seminars to conferences, exhibitions 
                                        and other special events.BSI INFO is here to bridge your needs in planning and implementing a successful event. Our professional 
                                        team not only has extensive experience in the industry, but is also committed to ensuring every detail is arranged perfectly 
                                        according to your vision and goals.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</body>
</html>
