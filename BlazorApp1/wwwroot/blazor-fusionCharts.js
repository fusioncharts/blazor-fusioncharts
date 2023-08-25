
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

window.FusionCharts.setDataStore = (id) =>  {

    var currentChart = FusionCharts(id);

    var fusionDataStore = new FusionCharts.DataStore();
    
    var fusionTable = fusionDataStore.createDataTable([["01-Feb-11",8866],["02-Feb-11",2174],["03-Feb-11",2084],["04-Feb-11",1503],["05-Feb-11",4928],["06-Feb-11",4667]], [{
        "name": "Time",
        "type": "date",
        "format": "%d-%b-%y"
      }, {
        "name": "Grocery Sales Value",
        "type": "number"
      }]);

    console.log(typeof fusionTable);
    console.log(fusionTable);

    currentChart.setChartData({data: fusionTable});
};

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
