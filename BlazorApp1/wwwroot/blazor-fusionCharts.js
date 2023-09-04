
const FUNCTION_KEYWORD = 'function()';
const CALLBACK = "callback";
const FUNCTION_KEYWORD_WITH_E = 'function(e)';

// reviver function, key is passed by the JSON.parse
function parseFunction(key, value) {
    if (typeof value === "string" && (value.includes(FUNCTION_KEYWORD) || value.includes(FUNCTION_KEYWORD_WITH_E))) {
        let functionParts = value.includes(FUNCTION_KEYWORD) ? value.split("function()") : value.split("function(e)");
        let functionBody = functionParts[1]
        let parsedFn = value.includes(FUNCTION_KEYWORD) ? new Function(functionBody) : new Function('e', functionBody);
        return parsedFn;
    }
    // if the value is not function then return as is
    return value;
}

// Responsible for rendering any chart//
window.FusionCharts.renderChart = (chartConfiguration) => {
  const configAsJSObject = JSON.parse(chartConfiguration, this.parseFunction);
  const chart = new FusionCharts(configAsJSObject);
  chart.render();
};

// Method written for charts like time-series chart
window.FusionCharts.setDataStore = (id, args) =>  {

    let currentChart = FusionCharts(id);
    let fusionDataStore = new FusionCharts.DataStore();
    
    let data = JSON.parse(args[0]);
    let schema = JSON.parse(args[1]);

    let fusionTable = fusionDataStore.createDataTable(data, schema);

    currentChart.setChartData({data: fusionTable});
};

// resizeTo will not return any data due to circular json object
window.FusionCharts.resizeTo = (id, args) => {
    let currentChart = FusionCharts(id);
    currentChart.resizeTo(args[0], args[1]);
}

//To add Annotation items and groups
window.FusionCharts.addAnnotations = (functionName, id, args) => {
  let annotations = FusionCharts(id).annotations;
  annotations[functionName].apply(annotations, args);
}

//Generic Method to call any fusion chart method exluding except above methods//
window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {
    // data is an array
    let currentChart = FusionCharts(chartID), result;
  
    console.log(chartID, currentChart, functionName, args, " <<< invokeChartFunction log");
  
    if (args[0].type === CALLBACK) {

      let { event, fn } = args[0];
      let callbackFn = parseFunction(null, fn);
      result = currentChart[functionName].call(currentChart, event, callbackFn);

      return String(result);

    } else if (args[0].returnType === "NULL") {
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