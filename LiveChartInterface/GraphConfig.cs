using System.Collections.Generic;
using System.Xml.Serialization;


namespace LiveChartInterface
{
    [XmlRoot("Graphs")]
    public class GraphsConfig : List<Graph>
    {

    }

    public class Graph
    {
        public string Name { get; set; }
        public string XAxisTitle { get; set; }
        [XmlElement("YAxes")]
        public List<YAxe> YAxes { get; set; }
        [XmlElement("Series")]
        public List<Serieses> Series { get; set; }

        
        public class Serieses
        {
            public string Name { get; set; }
            public string RawDataPointKey { get; set; }
            public string Color { get; set; }
            public string YAxis { get; set; }
        }
    }

    public class YAxe
    {
        [XmlElement("YAxis")]
        public List<YAxis> YAxis { get; set; }
    }

    public class YAxis
    {
        public string Title { get; set; }
        public string Color { get; set; }
    }
}


