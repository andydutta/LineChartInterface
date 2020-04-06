using System.Collections.Generic;
using System.Xml.Serialization;

namespace LiveChartInterface
{
    public class RawDataPoints : List<RawDataPoint>
    {

    }
    public class RawDataPoint
    {
        public string Key { get; set; }
        public int IntervalMs { get; set; }

        [XmlArray("SampleData"), XmlArrayItem("Data")]
        public List<double> SampleData { get; set; }
    }
}
