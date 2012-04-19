using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;
using System.Text;


[DataObject]
public class FileReportDataSource
{
    public FileReportDataSource()
    {
        _fileName = HttpContext.Current.Server.MapPath("~/App_Data/FileData.xml");
    }

    public void RefreshFileData()
    {
        string path = @"C:\dev\pluralsight\alinq\trunk\labs\LINQ_Xml";

        XElement root = new XElement("Files");
        root.Add(CreateXmlForDirectory(path));
        root.Save(_fileName);
    }

    private static XElement CreateXmlForDirectory(string path)
    {
        var directoryInfo = new DirectoryInfo(path);

        XElement root = new XElement("Directory",
                            new XAttribute("Name", 
                               directoryInfo.Name));

        var directories = directoryInfo.GetDirectories();
        var files = directoryInfo.GetFiles();
        var directoryXml =
                from d in directories
                select CreateXmlForDirectory(d.FullName);
        var fileXml =
            from f in files
            select new
                XElement("File",
                    new XAttribute("Name", f.Name),
                    new XAttribute("Size", f.Length),
                    new XAttribute("LastAccess", f.LastAccessTime));

        root.Add(directoryXml, fileXml);
        return root;
    }

    public IEnumerable<FileStatistic> GetLargestFiles()
    {
        XDocument doc = XDocument.Load(_fileName);

        var query =
             from e in doc.Descendants("File")
             orderby long.Parse(e.Attribute("Size").Value) descending
             select new FileStatistic
             {
                Name = (string)e.Attribute("Name"),
                Size = long.Parse(e.Attribute("Size").Value),
                LastAccess = DateTime.Parse((string)e.Attribute("LastAccess")),
                Directory = CombineParentDirectoryNames(e)
            };

        return query.Take(10);
    }

    string CombineParentDirectoryNames(XElement fileElement)
    {
        var names =  
            from e in fileElement.Ancestors("Directory")
              select e.Attribute("Name").Value;

        return 
            names.Reverse()
                 .Aggregate(
                    new StringBuilder(), 
                    (builder, name) => 
                        builder.Append(
                            String.Format("{0}{1}",
                                Path.DirectorySeparatorChar,
                                name)),
                    builder => builder.ToString());                                      
    }

    string _fileName;
}
