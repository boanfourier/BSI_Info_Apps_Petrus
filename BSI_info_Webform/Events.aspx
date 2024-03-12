<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Events.aspx.vb" Inherits="BSI_info_Webform.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

        .gridview th, .gridview td {
            border: 1px solid #dddddd;
            padding: 8px;
            text-align: left;
        }

        .gridview th {
            background-color: #16bdf7;
        }
    </style>

    <div class="container">
        <h1>Event List</h1>
         <asp:HyperLink ID="HyperLinkAddEvent" runat="server" NavigateUrl="~/AddEvents.aspx" Text="Add New Events" CssClass="add-event-link" />
        <asp:GridView ID="GridViewEvents" runat="server" AutoGenerateColumns="False" CssClass="gridview">
    <HeaderStyle BackColor="#3AC0F2" Font-Bold="True" ForeColor="White" />
    <Columns>
        <asp:BoundField DataField="event_name" HeaderText="Event Name" />
        <asp:BoundField DataField="description" HeaderText="Description" />
        <asp:BoundField DataField="start_date" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}" />
        <asp:BoundField DataField="end_date" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}" />
        <asp:BoundField DataField="location_id" HeaderText="Location Name" />
        <asp:BoundField DataField="organizer_id" HeaderText="Organizer Name" />
        
        <asp:HyperLinkField DataNavigateUrlFields="event_id" DataNavigateUrlFormatString="UpdateEvents.aspx?ID={0}" Text="Update" />
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDelete" runat="server" NavigateUrl='<%# Eval("event_id", "DeleteEvents.aspx?ID={0}") %>' Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle BackColor="#3AC0F2" ForeColor="White" HorizontalAlign="Center" />
</asp:GridView>

    </div>
</asp:Content>
