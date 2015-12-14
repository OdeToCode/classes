<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" />
     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="_mainPanel">
        <ProgressTemplate>
            <img src="wait30trans.gif" />
        </ProgressTemplate>
    </asp:UpdateProgress>   
    <asp:UpdatePanel runat="server" ID="_mainPanel">
        <ContentTemplate>  
            <div>
                Referenced Assemblies:
                <asp:DropDownList runat="server" ID="_assemblySelection" DataSourceID="_assemblyDataSource" AutoPostBack="true" />
                <asp:ObjectDataSource ID="_assemblyDataSource" runat="server" SelectMethod="GetAssemblySelections" TypeName="ReflectiveDataSource" />
                <asp:CheckBox ID="_publicOnly" runat="server" Checked="true" Text="Public types only?" AutoPostBack="true"  />
                <br />
                <h1>Type Statistics</h1>
                <asp:DetailsView ID="_statsView" runat="server" Height="50px" Width="125px" 
                    AutoGenerateRows="False" DataSourceID="_statsDataSource" >
                    <Fields>
                        <asp:BoundField DataField="LongestClassNames" HeaderText="Longest&nbsp;Class&nbsp;Name(s)" 
                            SortExpression="LongestClassNames" />
                        <asp:BoundField DataField="CountOfTypes" HeaderText="Number&nbsp;of&nbsp;Types" 
                            SortExpression="CountOfTypes" />
                        <asp:BoundField DataField="AverageClassNameLength" DataFormatString="{0:n2}" 
                            HeaderText="Avg.&nbsp;Class&nbsp;Name&nbsp;Length" SortExpression="AverageClassNameLength" />
                    </Fields>
                </asp:DetailsView>
                <asp:ObjectDataSource ID="_statsDataSource" runat="server" 
                    SelectMethod="GetTypeStatistics" TypeName="ReflectiveDataSource">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="_assemblySelection" Name="namefilter" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="_publicOnly" Name="publicOnly" 
                            PropertyName="Checked" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />                
                <h1>Types</h1>
                <asp:GridView ID="_typesGrid" runat="server" AutoGenerateColumns="False" 
                              DataSourceID="_typesDataSource" AllowPaging="True" PageSize="20">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                        <asp:BoundField DataField="Namespace" HeaderText="Namespace" ReadOnly="True" SortExpression="Namespace" />
                        <asp:CheckBoxField DataField="IsAbstract" HeaderText="IsAbstract" ReadOnly="True"
                            SortExpression="IsAbstract" />
                        <asp:CheckBoxField DataField="IsSealed" HeaderText="IsSealed" ReadOnly="True" SortExpression="IsSealed" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="_typesDataSource" runat="server" 
                    SelectMethod="GetTypes" TypeName="ReflectiveDataSource" EnablePaging="True" 
                    SelectCountMethod="GetTypesCount">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="_assemblySelection" DefaultValue="" Name="nameFilter" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="_publicOnly" Name="publicOnly" 
                            PropertyName="Checked" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
