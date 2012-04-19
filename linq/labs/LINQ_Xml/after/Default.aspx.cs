using System;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var dataSource = new FileReportDataSource();
            dataSource.RefreshFileData();
        }
    }
}
