using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;

[DataObject]
public class FileReportDataSource
{
    public FileReportDataSource()
    {
        _fileName = HttpContext.Current.Server.MapPath("~/App_Data/FileData.xml");
    }

    public IEnumerable<FileStatistic> GetLargestFiles()
    {
        return null;
    }

    string _fileName;
}
