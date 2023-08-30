const FUNCTION_KEYWORD = "function()";
const CALLBACK = "callback";

// Reviver function, key is passed by the JSON.parse
function parseFunction(key, value) {
  if (typeof value === "string" && value.includes(FUNCTION_KEYWORD)) {
    let functionParts = value.split("function()");
    let functionBody = functionParts[1];
    let parsedFn = new Function(functionBody);
    return parsedFn;
  }
  // if the value is not function then return it as-is
  return value;
}

// Responsible for rendering any chart
window.FusionCharts.renderChart = (chartConfiguration) => {
  const configAsJSObject = JSON.parse(chartConfiguration, this.parseFunction);
  const chart = new FusionCharts(configAsJSObject);
  chart.render();
};

//Generic Method to call any fusion chart method exluding except above methods
window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {
  // data is an array
  let currentChart = FusionCharts(chartID),
    result;

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
    } else if (typeof result === "XML") {
      result = XML.stringify(result);
    }
    return String(result);
  }
};
