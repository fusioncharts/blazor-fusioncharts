const CALLBACK = 'callback';

function extractArguments(functionString) {
  // regex to extract the function arguments
  const regex = /function\s*\(([^)]*)\)\s*\{/;
  const matches = regex.exec(functionString);

  if (matches && matches.length > 1) {
    const argsString = matches[1];
    const args = argsString.split(',').map((arg) => arg.trim());

    if (args.length === 1 && args[0] === '') {
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

// reviver function, key is passed by the JSON.parse
function parseFunction(key, value) {
  if (typeof value === 'string' && value.match(/function\s*\(([^)]*)\)\s*\{/)) {
    let fnArguments = extractArguments(value);
    let fnBody = extractFunctionBody(value);
    let parsedFn = fnArguments.length > 0 ? new Function(fnArguments, fnBody) : new Function(fnBody);
    return parsedFn;
  }
  return value;
}

// Responsible for rendering any chart//
window.FusionCharts.renderChart = (chartConfiguration) => {
  const configAsJSObject = JSON.parse(chartConfiguration, parseFunction);

  // checking if chart already exists with the same id, and then disposing it//
  if (configAsJSObject && configAsJSObject.id) {
    let checkExistingChart = FusionCharts(configAsJSObject.id);

    if (checkExistingChart) {
      checkExistingChart.dispose();
    }
  }

  const chart = new FusionCharts(configAsJSObject);
  chart.render();
};

// Method written for charts like time-series chart
window.FusionCharts.setDataStore = (id, args) => {
  let currentChart = FusionCharts(id);
  let fusionDataStore = new FusionCharts.DataStore();

  let data = JSON.parse(args[0]);
  let schema = JSON.parse(args[1]);

  let fusionTable = fusionDataStore.createDataTable(data, schema);

  // Get the existing dataSource attached to the chart
  let currentDataSource = currentChart.getJSONData() || {};

  // Assign the fusionTable to the data property of the dataSource
  currentDataSource.data = fusionTable;

  // Set the updated dataSource back to the chart
  currentChart.setChartData(currentDataSource);
};

// resizeTo will return circular json object which cannot be stringified
// and that's why it cannot be called using generic method
window.FusionCharts.resizeTo = (id, args) => {
  let currentChart = FusionCharts(id);
  currentChart.resizeTo(args[0], args[1]);
};

//To add Annotation items and groups
window.FusionCharts.addAnnotations = (functionName, id, args) => {
  let annotations = FusionCharts(id).annotations;
  annotations[functionName].apply(annotations, args);
};

//Generic Method to call any fusion chart method exluding except above methods//
window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {
  // data is an array
  let currentChart = FusionCharts(chartID),
    result;

  if (args.length > 0 && args[0].type === CALLBACK) {
    let { event, fn } = args[0];
    let callbackFn = parseFunction(null, fn);
    result = currentChart[functionName].call(currentChart, event, callbackFn);

    return String(result);
  } else {
    result = currentChart[functionName].apply(currentChart, ...args);

    if (typeof result === 'object') {
      // this might fail if object return has circular deps
      // if the user needs this data then it needs to be processes in the JS file only,
      // it cannot be sent to the razor file
      try {
        result = JSON.stringify(result);
      } catch (error) {
        console.log(error);
      }
    }

    return String(result);
  }
};
