<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Flow.Models.Guest>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sign
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Sign</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
         
        <%: Html.EditorForModel() %>
        <input type="submit" value="Save" />

    <% } %>

    <div>
        <%: Html.ActionLink("Back Home", "Index", "Home") %>
    </div>

</asp:Content>

