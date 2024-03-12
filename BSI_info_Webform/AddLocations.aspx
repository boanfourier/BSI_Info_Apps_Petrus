<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddLocations.aspx.vb" Inherits="BSI_info_Webform.AddLocations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add New Locations</h1>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblCapacity" runat="server" Text="Capacity:"></asp:Label>
    <asp:TextBox ID="txtCapacity" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    <br />

    <asp:Button ID="btnAddLocations" runat="server" Text="Add Locations" OnClick="btnAddLocations_Click" CssClass="btn btn-primary" />
</asp:Content>


