<%@ Page Title="BSI INFO Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="BSI_info_Webform._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .card {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            margin-bottom: 20px;
            background-color: #fff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease-in-out;
            animation: fadeInUp 0.5s ease-in-out;
        }

        .card:hover {
            transform: scale(1.05);
        }

        @keyframes fadeInUp {
            from {
                opacity: 0;
                transform: translateY(20px);
            }
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }
    </style>

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">BSI INFO</h1>
            <p class="lead">BSI INFO is your gateway to the latest information, resources, and events related to BSI.</p>
        </section>

        <div class="row">
            <section class="col-md-4 card" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Location</h2>
                <p>
                    Stay updated with the latest news and announcements from BSI.
                </p>
                <p>
                    <a class="btn btn-default" href="locations.aspx">View All Location &raquo;</a>
                </p>
            </section>
            <section class="col-md-4 card" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Events</h2>
                <p>
                    Explore upcoming events, workshops, and seminars organized by BSI.
                </p>
                <p>
                    <a class="btn btn-default" href="events.aspx">View All Events &raquo;</a>
                </p>
            </section>
            <section class="col-md-4 card" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Task</h2>
                <p>
                    Access a variety of resources including publications, research papers, and educational materials.
                </p>
                <p>
                    <a class="btn btn-default" href="tasks.aspx">View All Task &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
