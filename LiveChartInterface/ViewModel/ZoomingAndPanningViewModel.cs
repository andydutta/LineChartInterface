using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using LiveChartInterface.Annotations;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace LiveChartInterface.ViewModel
{
    public class ZoomingAndPanningViewModel:INotifyPropertyChanged
    {
        private ZoomingOptions _zoomingMode;
        private GraphsConfig _chartData;
        private RawDataPoints _rawdata;
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ZoomingAndPanningViewModel()
        {
            Execute();
        }
        
        [STAThread]
        public void Execute()
        {
            _chartData = Xml.Deserialize<GraphsConfig>("GraphConfig.xml", "Graphs");
            _rawdata = Xml.Deserialize<RawDataPoints>("GraphConfig.xml", "RawDataPoints");

            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = GetData(),
                    Fill = gradientBrush,
                    StrokeThickness = 1,
                    PointGeometrySize = 0
                }
            };

            ZoomingMode = ZoomingOptions.X;

            XFormatter = val => new DateTime((long)val).ToString("dd MMM");
            YFormatter = val => val.ToString("C");
        }
        public ZoomingOptions ZoomingMode
        {
            get { return _zoomingMode; }
            set
            {
                _zoomingMode = value;
                OnPropertyChanged();
            }
        }

        public GraphsConfig ChartData
        {
            get { return _chartData; }
            set { _chartData = value; }
        }

        private ChartValues<DateTimePoint> GetData()
        {
            List<double> plotData = new List<double>();
            var r = new Random();
            var trend = 100;
            var values = new ChartValues<DateTimePoint>();

            foreach (var data in ChartData)
            {
                foreach (var series in data.Series)
                {
                    plotData = _rawdata.FirstOrDefault(k =>
                        k.Key.Contains(data.Series.FirstOrDefault(m => m.RawDataPointKey == series.RawDataPointKey)
                            ?.RawDataPointKey))
                        ?.SampleData;
                }
            }

            for (var i = 0; i < plotData.Count; i++)
            {
                var seed = r.NextDouble();
                if (seed > .8) trend += seed > .9 ? 50 : -50;
                values.Add(new DateTimePoint(DateTime.Now.AddDays(i), plotData[i]));
            }
            
            return values;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}