<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddEvents.aspx.vb" Inherits="BSI_info_Webform.AddEvents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add New Event</h1>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblEventName" runat="server" Text="Event Name:"></asp:Label>
    <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    <br />

    <asp:Label ID="lblStartDate" runat="server" Text="Start Date:"></asp:Label>
    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="calStartDateExtender" runat="server" TargetControlID="txtStartDate" Format="yyyy-MM-dd">
    </ajaxToolkit:CalendarExtender>
    <br />

    <asp:Label ID="lblEndDate" runat="server" Text="End Date:"></asp:Label>
    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="calEndDateExtender" runat="server" TargetControlID="txtEndDate" Format="yyyy-MM-dd">
    </ajaxToolkit:CalendarExtender>
    <br />

    <asp:Label ID="lblLocationId" runat="server" Text="Location ID:"></asp:Label>
    <asp:TextBox ID="txtLocationId" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblOrganizerId" runat="server" Text="Organizer ID:"></asp:Label>
    <asp:TextBox ID="txtOrganizerId" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" OnClick="btnAddEvent_Click" CssClass="btn btn-primary" />
</asp:Content>
