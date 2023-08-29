
const FUNCTION_KEYWORD = 'function()';

// reviver function, key is passed by the JSON.parse
function parseFunction(key, value) {
  if (typeof value === "string" && value.includes(FUNCTION_KEYWORD)) {
    let functionParts = value.split("function()")
    let functionBody = functionParts[1]
    let parsedFn = new Function(functionBody);
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

    var currentChart = FusionCharts(id);
    var fusionDataStore = new FusionCharts.DataStore();
    
    var data = JSON.parse(args[0]);
    var schema = JSON.parse(args[1]);

    var fusionTable = fusionDataStore.createDataTable(data, schema);

    currentChart.setChartData({data: fusionTable});
};

// resizeTo will not return any data due to circular json object
window.FusionCharts.resizeTo = (id, args) => {
    var currentChart = FusionCharts(id);
    currentChart.resizeTo(args[0], args[1]);
}

//To add Annotation items and groups
window.FusionCharts.addAnnotations = (functionName, id, args) => {
  var annotations = FusionCharts(id).annotations;
  annotations[functionName].apply(annotations, args);
}

//Generic Method to call any fusion chart method exluding except above methods//
window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {

  var currentChart = FusionCharts(chartID);

  if (functionName === 'addEventListener' || (args.length > 0 && args[0][0] === "callback")) {

    let event = args[0][1]
    let functionAsString = args[0][2];
    let callbackFn = parseFunction(null, functionAsString);
    var result = currentChart[functionName].call(currentChart, event, callbackFn);
    
    return String(result);
  }

  var result = currentChart[functionName].apply(currentChart, ...args);
  var typeofresult = typeof result;
  if (typeofresult === "object") {
    result = JSON.stringify(result);
  } else if (typeofresult === "XML") {
    result = XML.stringify(result);
  }
  
  return String(result);
};
