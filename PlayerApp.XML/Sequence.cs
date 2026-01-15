using System.Xml.Serialization;

namespace PlayerApp.XML;

[XmlRoot("sequence", Namespace="http://sequencemovieplayer.antanysavage.it/sequences/schema", IsNullable = false)]
public class Sequence
{
    [XmlAttribute("name")]
    public string Name { get; set; }

}
