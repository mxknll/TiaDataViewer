using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TiaDataViewer.Core.Models
{
    public class NodeModel
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<PropertyModel> Properties { get; set; }

        public int NumberOfProperties => Properties.Count;

        // Title is the value of property of key 'Name' if existant, else of property of key 'Id', else is placeholder
        public string Title => Properties.Count == 0 ? "<Node ist leer>" :
                               Properties.Any(x => x.Key == "Name") ? Properties.First(x => x.Key == "Name").Value : 
                               Properties.Any(x => x.Key == "Id") ? Properties.First(x => x.Key == "Id").Value : "<Titel fehlt>";

    }

}
