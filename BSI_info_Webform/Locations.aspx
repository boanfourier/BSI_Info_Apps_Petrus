<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Locations.aspx.vb" Inherits="BSI_info_Webform.Locations" %>

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
                color: white;
            }
    </style>
    <div class="container">
        <h1>Locations List</h1>
        <asp:HyperLink ID="HyperLinkAddLocation" runat="server" NavigateUrl="~/AddLocations.aspx" Text="Add New Locations" CssClass="add-locations-link" />
        <asp:GridView ID="GridViewLocations" runat="server" AutoGenerateColumns="False" CssClass="gridview">
            <Columns>
                <asp:BoundField DataField="location_id" HeaderText="Location ID" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="capacity" HeaderText="Capacity" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:HyperLinkField DataNavigateUrlFields="location_id" DataNavigateUrlFormatString="UpdateLocations.aspx?ID={0}" Text="Update" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLinkDelete" runat="server" NavigateUrl='<%# Eval("location_id", "DeleteLocations.aspx?ID={0}") %>' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
