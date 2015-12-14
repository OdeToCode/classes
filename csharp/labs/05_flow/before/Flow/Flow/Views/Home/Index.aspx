<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Flow.Models.Guest>>" %>
<%@ Import Namespace="Flow.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome!</h2>
    <h3>Our guests:</h3>
    <table>
        <% foreach(Guest g in Model) { %>
            <tr>
                <td><%: g.Name %></td>
                <td><%: g.Message %></td>
            </tr>
        <% } %>
    </table>
    <p>
        Sign the guest book here:
        <%: Html.ActionLink("Sign the guest book.", "sign", "guest") %>
    </p>
</asp:Content>
