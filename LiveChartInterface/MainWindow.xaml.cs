using System;
using System.Windows;
using System.Windows.Controls;
using LiveChartInterface.UserControl;
using LiveChartInterface.ViewModel;

namespace LiveChartInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var gvm = new GraphConfigViewModel();

            gvm.Content= new ZoomingAndPanning();
            DataContext = gvm;
        }
    }
}
