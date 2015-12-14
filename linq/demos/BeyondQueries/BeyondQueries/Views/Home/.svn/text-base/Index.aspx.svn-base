<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BeyondQueries.Models.Data.Movie>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<title>Index</title>
	<script src="../../Scripts/MovieEvaluate.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2 class="header">Movie Evaluator</h2>


	<% using (Html.BeginForm()) {%>

		<fieldset>
			<legend>Fields</legend>
			<p>
				<%= Html.LabelFor(model => model.Title) %>
				<%= Html.TextBoxFor(model => model.Title) %>
				<%= Html.ValidationMessageFor(model => model.Title) %>
			</p>
			<p>
				<%= Html.LabelFor(model => model.Length) %>
				<%= Html.TextBoxFor(model => model.Length) %>
				<%= Html.ValidationMessageFor(model => model.Length) %>
			</p>            
			<p>                				
				<%= Html.LabelFor(model => model.ReleaseDate) %>
				<%= Html.TextBoxFor(model => model.ReleaseDate) %>
				<%= Html.ValidationMessageFor(model => model.ReleaseDate) %>
			</p>
			
			<p>
				<input id="submitMovie" type="submit" value="Create" />
			</p>
		</fieldset>

	<% } %>

	<div>
		<%=Html.ActionLink("Back to List", "Index") %>
	</div>

</asp:Content>

