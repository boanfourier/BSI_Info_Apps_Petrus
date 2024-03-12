<%@ Page Title="Notes" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notes.aspx.vb" Inherits="BSI_info_Webform.Notes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <h1>Notes List</h1>
    <asp:HyperLink ID="HyperLinkAddNotes" runat="server" NavigateUrl="~/AddNotes.aspx" Text="Add New Notes" CssClass="add-notes-link" />
    <asp:GridView ID="GridViewNotes" runat="server" AutoGenerateColumns="False" CssClass="gridview">
        <Columns>
            <asp:BoundField DataField="note_id" HeaderText="Notes ID" />
            <asp:BoundField DataField="event_id" HeaderText="Event Name" />
             <asp:BoundField DataField="note_text" HeaderText="Notes Text" />
            <asp:BoundField DataField="created_at" HeaderText="Create At" />
            <asp:HyperLinkField DataNavigateUrlFields="note_id" DataNavigateUrlFormatString="Updatenotes.aspx?ID={0}" Text="Update" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLinkDelete" runat="server" NavigateUrl='<%# Eval("note_id", "Deletenotes.aspx?ID={0}") %>' Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
