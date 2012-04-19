<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div id="header">At The Movies!</div>
    <div id="content">
        <asp:GridView ID="_movieGrid" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="MovieID" 
            DataSourceID="MovieEntityDataSource">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="MovieID" HeaderText="MovieID" ReadOnly="True" 
                    SortExpression="MovieID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="ReleaseDate" HeaderText="ReleaseDate" 
                    SortExpression="ReleaseDate" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="MovieEntityDataSource" runat="server" 
            ConnectionString="name=MovieRepository" DefaultContainerName="MovieRepository" 
            EnableDelete="True" EnableFlattening="False" EnableUpdate="True" 
            EntitySetName="Movies">
        </asp:EntityDataSource>
        <asp:Label runat="server" ID="_topMovie"/>
        <asp:Button runat="server" ID="_updateMovieButton" 
            Text="Update A Movie" OnClick="UpdateMovie" />
        <asp:Button runat="server" ID="_deleteMovieButton" 
            Text="Delete A Movie" OnClick="DeleteMovie" />

        <asp:TextBox runat="server" ID="_logMesssage" 
                  Text="Message" />
        <asp:Button runat="server" ID="_insertLogButton" 
                  Text="Insert A Message" OnClick="InsertMessage" />


    </div>
    </form>
</body>
</html>
