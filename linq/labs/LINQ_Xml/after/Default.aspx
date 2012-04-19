<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Import Namespace="System.Xml" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Files! Files! Files!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="_fileView" runat="server" DataSourceID="_fileViewDataSource" ExpandDepth="2"
            OnTreeNodeDataBound="OnTreeNodeDataBound">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="File" ToolTipField="Size" TextField="Name" />
                <asp:TreeNodeBinding DataMember="Directory" TextField="Name" />
            </DataBindings>
        </asp:TreeView>
        <asp:XmlDataSource ID="_fileViewDataSource" runat="server" DataFile="~/App_Data/FileData.xml">
        </asp:XmlDataSource>
        <h1>
            Top 10 Largest Files</h1>
        <asp:GridView ID="_largestView" runat="server" AutoGenerateColumns="False" DataSourceID="_largestDataSource">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" DataFormatString="{0:n}" />
                <asp:BoundField DataField="LastAccess" DataFormatString="{0:d}" HeaderText="LastAccess"
                    SortExpression="LastAccess" />
                <asp:BoundField DataField="Directory" HeaderText="Directory" SortExpression="Directory" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="_largestDataSource" runat="server" SelectMethod="GetLargestFiles"
            TypeName="FileReportDataSource" />
    </div>
    </form>
</body>
</html>

<script runat="server">

    // this method ensures that empty directories
    // don't display as leaf level items (that makes them look like files)  
    protected void OnTreeNodeDataBound(object o, TreeNodeEventArgs e)
    {
        XmlLinkedNode node = e.Node.DataItem as XmlLinkedNode;
        if (node != null && node.Name == "Directory")
        {
            e.Node.ImageUrl = ClientScript.GetWebResourceUrl(typeof(TreeView), "TreeView_XP_Explorer_ParentNode.gif");
        }
    }

</script>

