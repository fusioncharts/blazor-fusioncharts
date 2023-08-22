function parseFunction(key, value) {
        if (typeof (value) === 'string' && value.includes('function()')) {
            let regEx = new RegExp("{([^}]*)}");
            let func = new Function(value.split("function()")[1]);
            return func;
        }
        return value
    }
    // Responsible for rendering any chart//
    window.FusionCharts.renderChart = (chartConfiguration) => {
        options = JSON.parse(chartConfiguration, this.parseFunction);
        const chart = new FusionCharts(options);
        chart.render();
    };
    //Generic Method to call any fusion chart method exluding except above methods//
    window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {
        var currentChart = FusionCharts(chartID);
        var result =   currentChart[functionName].apply(currentChart, ...args);
        var typeofresult = typeof result;
        if(typeofresult === "number" || typeofresult === "boolean"){
            result = result.toString();
        }
        else if(typeofresult === "object"){
            result = JSON.stringify(result);
        }
        else if(typeofresult === "XML"){
            result = XML.stringify(result);
        }
        if(typeofresult === "string"){
            return result;
        }
        return result.toString() || "";
    };