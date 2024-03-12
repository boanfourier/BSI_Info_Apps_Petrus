<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Tasks.aspx.vb" Inherits="BSI_info_Webform.Tasks" %>

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
        <h1>Tasks List</h1>
        <asp:HyperLink ID="HyperLinkAddTasks" runat="server" NavigateUrl="~/AddTasks.aspx" Text="Add New Tasks" CssClass="add-tasks-link" />
        <asp:GridView ID="GridViewTasks" runat="server" AutoGenerateColumns="False" CssClass="gridview">
            <Columns>
                <asp:BoundField DataField="task_id" HeaderText="Tasks ID" />
                <asp:BoundField DataField="event_id" HeaderText="Event Name" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="deadline" HeaderText="Deadline" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:HyperLinkField DataNavigateUrlFields="task_id" DataNavigateUrlFormatString="Updatetasks.aspx?ID={0}" Text="Update" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLinkDelete" runat="server" NavigateUrl='<%# Eval("task_id", "Deletetasks.aspx?ID={0}") %>' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
