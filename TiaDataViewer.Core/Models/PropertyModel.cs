using System.Xml.Serialization;

namespace TiaDataViewer.Core.Models
{
    public class PropertyModel
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
