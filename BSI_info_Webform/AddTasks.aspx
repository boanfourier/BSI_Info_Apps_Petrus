<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddTasks.aspx.vb" Inherits="BSI_info_Webform.AddTasks" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add New Tasks</h1>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
   

    <asp:Label ID="lblevent_id" runat="server" Text="Event_ID:"></asp:Label>
    <asp:TextBox ID="txtevent_id" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lbldescription" runat="server" Text="Description:"></asp:Label>
    <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblDeadline" runat="server" Text="Deadline:"></asp:Label>
    <asp:TextBox ID="txtDeadline" runat="server" CssClass="form-control"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="calDeadlineExtender" runat="server" TargetControlID="txtDeadline" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
    <br />

    <asp:Label ID="lblstatus" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="txtstatus" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Button ID="btnAddTasks" runat="server" Text="Add Tasks" OnClick="btnAddTasks_Click" CssClass="btn btn-primary" />
</asp:Content>

