using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TiaDataViewer.Core.Models
{
    [XmlRoot("tiaselectiontool", IsNullable = false)]
    public class TiaSelectionToolModel
    {
        [XmlElement("business", IsNullable = false)]
        public Business Business { get; set; }

        public string FullFilePath { get; set; }
        public string FileName => Path.GetFileName(FullFilePath);
    }

    public class Business
    {
        [XmlElement("graph", IsNullable = false)]
        public Graph Graph { get; set; }
    }

    public class Graph
    {
        [XmlArray("nodes", IsNullable = false)]
        [XmlArrayItem("node", IsNullable = false)]
        public List<NodeModel> Nodes { get; set; }
    }
}
