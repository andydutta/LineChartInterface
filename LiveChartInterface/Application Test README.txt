Task:
Create a multi-line-chart application as a Windows desktop application using LiveCharts and Windows Presentation Foundation (WPF).
Requirements:
•	MVVM Design Pattern
•	Utilize Interfaces for all charting
•	Create Unit Tests (XUnit)
•	Utilize the provided GraphConfig.xml as the configuration of the graph sample
•	Multiple Graphs
•	Single X Axis per graph
•	Multiple lines per graph
•	Multiple Y Axes (for Y values on largely different scales)
•	Data added as x and y values, where X is typically time notation format (1:20.5) and Y is a double
•	Auto Scale X and Y axis as data points are added
•	Zooming and Panning
0

Helper Notes:
    - Use this line to deserialize your graphs:
        var graphs = Xml.Deserialize<Graphs>("GraphConfig.xml", "Graphs");
    
    - Use this line to deserialize your graph data:
        var rawdata = Xml.Deserialize<RawDataPoints>("GraphConfig.xml", "RawDataPoints");
        
    - You can use any resource from the Live Charts Demo Located in the Test Projects Folder
    - Display a grid of undetermined number of graphs with zoom and pan capability. 
    - The graphs are configured from an xml configuration file "GraphConfig.xml"
    - This should be in Model-View-ViewModel structure as much as possible.
    - Create an generalized interface between the xml configuration file and live charts
        