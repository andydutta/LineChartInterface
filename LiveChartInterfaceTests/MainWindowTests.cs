using Xunit;
using LiveChartInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using LiveChartInterface.ViewModel;

//using LiveChartInterface.ViewModel;

namespace LiveChartInterface.Tests
{
    public class MainWindowTests
    {   
        [Fact()]
        public void CheckIfTheChartDataIsPopulated()
        {
            //Arrange
            var viewModel = new ZoomingAndPanningViewModel();

            //Act
            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action) delegate { viewModel.Execute(); });

            //Assert
            Assert.True(viewModel.ChartData.Count > 0);
        }
    }
}