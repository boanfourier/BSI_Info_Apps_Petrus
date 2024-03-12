<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddNotes.aspx.vb" Inherits="BSI_info_Webform.AddNotes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add New Notes</h1>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <asp:Label ID="lblevent_id" runat="server" Text="Event ID:"></asp:Label>
    <asp:TextBox ID="txtevent_id" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="lblnote_text" runat="server" Text="Note Text:"></asp:Label>
    <asp:TextBox ID="note_text" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="lblcreated_at" runat="server" Text="Created at:"></asp:Label>
    <asp:TextBox ID="txtcreated_at" runat="server" CssClass="form-control"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="calcreated_atExtender" runat="server" TargetControlID="txtcreated_at" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
    <br />

    <asp:Button ID="btnAddNotes" runat="server" Text="Add Notes" OnClick="btnAddNotes_Click" CssClass="btn btn-primary" />
</asp:Content>
