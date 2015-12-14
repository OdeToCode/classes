<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Population Statistics</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Highest Male Populations</h1>
        <asp:GridView runat="server" ID="_malePopulation">
        </asp:GridView>
        <br />
        <h1>Lowest Total Populations</h1>
        <asp:GridView runat="server" ID="_lowestTotalPopulation"></asp:GridView>
        <br />
        <h1>Top Increase In Female Population</h1>
        <asp:GridView runat="server" ID="_percentIncrease"></asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
