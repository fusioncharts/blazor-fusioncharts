# Blazor FusionCharts
FusionCharts is a JavaScript charting library providing 100+ charts and 2,000+ maps for your web and mobile applications. All the visualizations are interactive and animated, which are rendered using webview. This plugin provides Flutter interface which integrates with FC Core JavaScript library using webview.
This package also contains FusionTime (timeseries charts), FusionWidgets (gauges, real-time charts), PowerCharts (statistical and advanced charts), and FusionMaps (choropleth geo maps).
- Official Website: [https://www.fusioncharts.com/](https://www.fusioncharts.com/)
- Documentation: [https://www.fusioncharts.com/dev/](https://www.fusioncharts.com/dev/)
- Licensing: [Legal Terms & Customer Agreements](https://www.ideracorp.com/legal/FusionCharts#tabs-2)
- Support: [https://www.fusioncharts.com/contact-support](https://www.fusioncharts.com/contact-support)
## Introduction
Every year, new frameworks emerge in the JavaScript ecosystem. FusionCharts, being a JavaScript library, needs to keep up with these developments to encourage wider adoption. There has been observed an increase in the demand for integration, especially among Blazor developers. As a result, this project focuses on creating an integration specifically tailored for Blazor developer community
## Demo
- Github Repo: [https://github.com/fusioncharts/blazor-fusioncharts](https://github.com/fusioncharts/blazor-fusioncharts)
- Documentation: []()
- Support: []()
- FusionCharts
  - Official Website: [https://www.fusioncharts.com/](https://www.fusioncharts.com/)
  - Official NPM Package: [https://www.npmjs.com/package/fusioncharts](https://www.npmjs.com/package/fusioncharts)
- Issues: []()
  ## Table of Contents
- [Blazor FusionCharts](#blazor-fusioncharts)
  - [Demo](#demo)
  - [Table of Contents](#table-of-contents)
  - [Getting Started](#getting-started)
    - [Requirements](#requirements)
    - [Installation](#installation)
  - [Quick Start](#quick-start)
  - [Working with APIs](#working-with-apis)
  - [Working with Events](#working-with-events)
  - [Fixes](#fixes)
  - [Going Beyond Charts](#going-beyond-charts)
  - [Licensing](#licensing)

## Getting Started
### Requirements
- Visual Studio (Used Community Edition 2022 - 17.6.1)
### Installation
1. Start by referring to the Blazor documentation link for a detailed guide on setting up and installing the necessary dependencies.
2. Clone the code repository from (https://github.com/fusioncharts/blazor-fusioncharts) to your local machine.
3. Windows Installation:
If you're on Windows, ensure that the following workloads are selected during the Visual Studio installation:
- ASP.NET and Web development
- Azure Development
- .NET Desktop
- After installation, launch Visual Studio and choose "Open a project or solution." Navigate to the 'BlazorApp1.sln' file in the
   extracted folder. Run the BlazorApp1 by clicking the run button in the toolbar.
4. MacOS or Linux Installation:
For MacOS or Linux users, run the 'dotnet watch' command from your project directory in the terminal.
5. Open your preferred web browser and navigate to the appropriate address to view and interact with your Blazor app.

## Quick Start
The application's operational flow can be described as follows:
1. It initiates from the entry point of the application, "_Hosts.cshtml" and "Index.razor".
2. Within "Index.razor", the coding resides to facilitate chart rendering.
3. From here it progresses to "FusionChartsService.cs," which serves as the interface between the end-user's Blazor application and the minified FusionCharts library.
4. The flow then extends towards "blazor-fusionCharts.js." This file exposes specific functions for "FusionChartsService.cs" and establishes bindings with Fusioncharts.
5. Ultimately, the sequence culminates in connecting to "fusioncharts.js," which represents the minified Fusioncharts library file.

## Working with APIs

We have to write the logic to render a fusion chart inside the Index.razor file. Inorder to render your own chart, edit this file.\
Here is the code to render a time chart:
```
private async Task renderTimeCharts()
    {
        dynamic myChartConfig = new System.Dynamic.ExpandoObject();
        dynamic myDataSource = new System.Dynamic.ExpandoObject();

        dynamic myChart = new System.Dynamic.ExpandoObject();
        dynamic myEvent = new System.Dynamic.ExpandoObject();
        dynamic myCategories = new System.Dynamic.ExpandoObject();
        dynamic myDataSet = new System.Dynamic.ExpandoObject();

        myChartConfig.id = "stockRealTimeChart";
        myChartConfig.type = "realtimeline";
        myChartConfig.renderAt = "chartContainer4";
        myChartConfig.width = 700;
        myChartConfig.height = 400;
        myChartConfig.dataFormat = "json";

        myChart.caption = "Real-time stock price monitor";
        myChart.subCaption = "Harry's SuperMart";
        myChart.xAxisName = "Time";
        myChart.yAxisName = "Stock Price";
        myChart.refreshinterval = 1;
        myChart.yaxisminvalue = 35;
        myChart.yaxismaxvalue = 36;
        myChart.numdisplaysets = 10;
        myChart.labeldisplay = "rotate";
        myChart.showRealTimeValue = 0;
        myChart.theme = "fusion";

        myCategories = new[] { new { catagory = new[] { new { label = "Day Start" } } } };

        myEvent.initialized = "function() { updateTimeChartData() }";
        myDataSource.chart = myChart;
        myDataSource.dataset = new[] { new { data = new[] { new { value = "35.3" } } } };
        myChartConfig.dataSource = myDataSource;
        myChartConfig.events = myEvent;

        String chartConfig = System.Text.Json.JsonSerializer.Serialize(myChartConfig);
        await fusionChartsService.renderChart(chartConfig);
    }
```

Invoking the generic method from Index.razor file:
```
await fusionChartsService.CallFusionChartsFunction("chartType", "CHART_ID");
```

The above method call is directed to the FusionChartsService.cs file which is a generic method calling another method generic method written in blazor-fusionCharts.js, and its implentation is:
```
public async Task<String> CallFusionChartsFunction(String functionName, String chartId, params object[] args)
        {
           String result = await _jsruntime.InvokeAsync<String>("FusionCharts.invokeChartFunction", functionName, chartId, args);
           return result;
        }
```

The generic method which is used to call any fusion chart methods is embedded inside the blazor-fusioncharts.js file as shown:
```
window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {
    // data is an array
    let currentChart = FusionCharts(chartID), result;
  
    if (args.length > 0 && args[0].type === CALLBACK) {

      let { event, fn } = args[0];
      let callbackFn = parseFunction(null, fn);
      result = currentChart[functionName].call(currentChart, event, callbackFn);

      return String(result);

    } else if (args.length > 0 && args[0].returnType === "NULL") {
      // for functions that return the chart instance object the return type needs to be defined as the
      // object contains circular deps which throws exception in blazor code while serialising and deserialising
      currentChart[functionName].apply(currentChart, userData);
    } else {

      result = currentChart[functionName].apply(currentChart, ...args);

      if (typeof result === "object") {
        // this might fail if object return has circular deps
        // if the user needs this data then it needs to be processes in the JS file only, 
        // it cannot be sent to the razor file
        result = JSON.stringify(result);
      }

      return String(result);
    }
  };
```

## Working with Events

There are two ways to attach event listeners to Fusioncharts:

### 1. Js method as an event listener

To invoke a JavaScript method upon an event trigger, we have to follow the steps below:

1. Generate a JavaScript file within the wwwroot directory that encompasses the implementation of the event handler method.
2. Include the above created file as script tag in the _Hosts.cshtml. Here the created file name is custom.js present in wwwroot folder.
```
<script src="~/custom.js"></script>
```
4. Implement the JavaScript function to activate it when the event is triggered.
5. Execute an anonymous function to invoke the Js method upon event trigger. 
```
   myEvent.dataPlotClick = "function() { randomF();}";
```

### 2. Blazor method as an event listener

To invoke a Blazor method upon an event trigger, we have to follow the steps below:

1. Create an instance inside Index.razor file as shown below.
```
    public static Index _instance;
```
2. Instantiate the instance inside the constructor to refer to Index file.
```
    public Index()
    {
        _instance = this;
    }
```
3. Implement a JSInvokable static method to invoke a non-static method using the instance.
```
    [JSInvokable("ChangeData")]
    public static async Task ChangeData()
    {
        await _instance.NonStaticMethod();
    }
```
4. Code the non-static method to perform any functionality, here we call the generic method to invoke fusion chart methods.
```
   public async Task NonStaticMethod()
    {
        await fusionChartsService.CallFusionChartsFunction("setChartAttribute", "CHART_ID", "caption", "new-caption");
    }
```
5. Now we are writing an anonymous function to call the Blazor method upon event trigger.
```
    myEvent.dataPlotClick = "function() { DotNet.invokeMethodAsync('BlazorApp1', 'ChangeData') }";
```

### Custom Event Handler

The addEventListener method listens to events across all FusionCharts instances on a page and executes custom functions when an event is triggered.

The generic method implemented above can be used to add a custom event listener which invokes a callback method and here it is: 
```
await fusionChartsService.CallFusionChartsFunction("addEventListener", "CHART_ID", "callback", "dataPlotClick", "function() {console.log('Custom method for event handling using generic method')}");
```

Below code snippet demonstrates the callback method implementation upon the event trigger.
```
if (functionName === 'addEventListener' || args[0][0] === "callback") {
    let event = args[0][1]
    let functionAsString = args[0][2];
    let callbackFn = parseFunction(null, functionAsString);
    var result = currentChart[functionName].call(currentChart, event, callbackFn);
    return "Undefined";
  }

```


## Fixes

### Time Series Method
setDataStore() : This mehtod is specific to Time Series Charts which takes data and schema from as input from the external files and creates a data source and a data table so as to render the chart.

Initially an empty data source is created in the Index.razor file as shown:
```
myDataSource.data = new {};
```

Below is the code snippet to read the contents of the external data and schema files. Also the method setDataStore() is invoked:

```
String dataFilePath = "C:/Users/Harsh Jain/Desktop/Blazor FC Integration/blazor-fusioncharts/BlazorApp1/wwwroot/data.json";
String schemeFilePath = "C:/Users/Harsh Jain/Desktop/Blazor FC Integration/blazor-fusioncharts/BlazorApp1/wwwroot/schema.json";
String dataContent = File.ReadAllText(dataFilePath);
String schemaContent = File.ReadAllText(schemeFilePath);

await fusionChartsService.setDataStore("chartId", dataContent, schemaContent1);
```

Upon invoking the setDataStore() method above, it leads to the below code snippet in the FusionChartsService.cs file which in turn invokes another user-defined method in the blazor-fusioncharts.js:
```
public async Task setDataStore(String id, params object[] args){
            await _jsruntime.InvokeVoidAsync("FusionCharts.setDataStore", id, args);
        }
```

Finally, the functionality of setDataStore is implemented in the blazor-fusioncharts.js.\
The code includes the creation of new data store and the parsing of data and schema to json.\
A new data table is created with the data and schema and rendered it to the chart.

```
window.FusionCharts.setDataStore = (id, args) =>  {

    let currentChart = FusionCharts(id);
    let fusionDataStore = new FusionCharts.DataStore();
    
    let data = JSON.parse(args[0]);
    let schema = JSON.parse(args[1]);

    let fusionTable = fusionDataStore.createDataTable(data, schema);

    currentChart.setChartData({data: fusionTable});
};
```

### Resize Method

resizeTo() : Resizes the chart to the specified width and height. While invoking the method there is a circular json object exception due to which it will not be stringified inside the generic method. Inorder to resolve this we implemented a user-defined method which will not return any data.

This method is invoked in the Index.razor file directly as below:
```
await fusionChartsService.resizeTo("chartId", 450, 500);
```
It then leads to the FusionChartsService.cs file where inturn invokes the method which will not return anything as returned object json is having circular references.
```
public async Task resizeTo(String id, params object[] args){
            await _jsruntime.InvokeVoidAsync("FusionCharts.resizeTo", id, args);
        }
```

The actual implementation is in the blazor-fusioncharts.js file which invokes the resizeTo method with the height and width parameters.
```
window.FusionCharts.resizeTo = (id, args) => {
  let currentChart = FusionCharts(id);
  currentChart.resizeTo(args[0], args[1]);
};
```

### Annotations

Annotations are user-defined objects or shapes drawn on a chart. They are used to increase the visual appeal of our charts and make them more informative. Annotations help end users interpret charts better.

Annotations are defined inside the annotations object. This object has an array of groups, and each group element has a unique id. The groups object contains an array of items, each of which contains information on one specific annotation in the chart.

Here we have created an external json file which contains the chart data and we implemented a button when clicked renders the chart with the annotation.

In the Index.razor file, firstly the data is read from the json file and the chart is rendered as follows:
```
string jsonUrl = navigationManager.ToAbsoluteUri("demo1.json").ToString();
dynamic myDataSource = jsonUrl;
await xyz.renderChart(chartConfig);
await xyz.CallFusionChartsFunction("setJSONUrl", "demoId", jsonUrl);
```
Now there is a user-defined method addAnnotaotion() which acts renders the chart by adding an item or a group upon button click. Here is the sample where an item is added:

```
private async Task addAnnotation(){
        await xyz.addAnnotations("addItem", "demoId", "infobar", new {
                id = "label1",
                align= "RiGHT",
                type= "text",
                text= "Messi added{br}roughly 7 Goals from{br}his shot quality",
                fillcolor= "#2F9AC4",
                rotate= "90",
                x= "$dataset.1.set.1.endx+65",
                y= "$dataset.0.set.5.y"
            }, true);
    }
```
The flow leads to FusionChartsService.cs file and its implementation is as follows:
```
public async Task addAnnotations(String functionName, String id, params object[] args){
  await _jsruntime.InvokeVoidAsync("FusionCharts.addAnnotations", functionName, id, args);
}
```
Finally the user-defined addAnnotations() is invoked to add either an item or a group to the rendered chart:

```
window.FusionCharts.addAnnotations = (functionName, id, args) => {
  let annotations = FusionCharts(id).annotations;
  annotations[functionName].apply(annotations, args);
};

```

### Cancel Events 

The functionality to trigger the Cancel Events is implemented in Blazor, which disposes the event that is already triggered on the chart.
In the Index.razor file, the functionality of the event that has to be disposed is as follows:

```
myEvent.dataPlotClick = "function() {DotNet.invokeMethodAsync('BlazorApp2TestQA2', 'ChangeData')}";
myEvent.beforeDispose = "function(e) { console.log(e); e.preventDefault() }"; 
myEvent.disposeCancelled = "function() { console.log('dispose cancelled') }";
```

Upon a button click, the event can be canclelled by invoking the callDispose() method whose implementation is attached below:
```
private async Task callDispose(){
        await xyz.CallFusionChartsFunction("dispose", "demoId");
}
```

In the blazor-fusioncharts.js file, there are multiple methods implemented to handle the multiple events cancellation.\
The method invoked in the Index.razor file recieves a string which is a function with definition hence its necessary to obtain the arguments and the body separately. \
As such there are two methods, one is extractArguments() which is used to extract the function arguments and a extractFunctionBody() method which is used to extract the function body. \
For this purpose we have used the regular expressions to match and split the function string accordingly.
```
function extractArguments(functionString) {
    // regex to extract the function arguments
    const regex = /function\s*\(([^)]*)\)\s*\{/;
    const matches = regex.exec(functionString);

    if (matches && matches.length > 1) {
        const argsString = matches[1];
        const args = argsString.split(',').map(arg => arg.trim());

        if (args.length === 1 && args[0] === "") {
            // No arguments
            return [];
        } else {
            // Multiple arguments
            return args;
        }
    } else {
        // No arguments
        return [];
    }
}

function extractFunctionBody(functionString) {
    //regex to extract the function body
    const regex = /function[^{]*{([\s\S]*)}$/;
    const match = regex.exec(functionString);

    if (match && match.length >= 2) {
        const functionBody = match[1].trim();
        return functionBody;
    } else {
        return null; // Function body not found
    }
}
```

Upon obtaining the function arguments and function body, the reviver function is implemented to parse the function.
```
// reviver function, key is passed by the JSON.parse
function parseFunction(key, value) {
    if (typeof value === "string" && value.match(/function\s*\(([^)]*)\)\s*\{/)) {
        let fnArguments = extractArguments(value);
        let fnBody = extractFunctionBody(value);
        let parsedFn = fnArguments.length > 0 ? new Function(fnArguments, fnBody) : new Function(fnBody);
        return parsedFn;
    }
    return value;
}
```

## Going Beyond Charts

- Explore 20+ pre-built business specific dashboards for different industries like energy and manufacturing to business functions like sales, marketing and operations [here](https://www.fusioncharts.com/explore/dashboards).
- See [Data Stories](https://www.fusioncharts.com/explore/data-stories) built using FusionCharts’ interactive JavaScript visualizations and learn how to communicate real-world narratives through underlying data to tell compelling stories.


## Licensing

There is a license activation mechanism followed by FusionCharts. This means that if you are an active customer then you have to provide license keys in your project to remove the watermark.\
To activate your license follow these steps:
1. Download the latest version of FusionCharts for your prefered framework.
2. Embed the library in your project.
3. Add the license key to your project, especially where you have instantiated FusionCharts.


# Setup steps - Using CLI
1. Download and install long term support version of dotnet from https://dotnet.microsoft.com/en-us/download. ( Version 6.0 was the LTS during the time of research )
2. Navigate to /BlazopApp1 directory and open the terminal (or command prompt).
3. Run `dotnet build` to build the project.
4. Run `dotnet run` to run the project.
