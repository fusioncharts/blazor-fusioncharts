
    function parseFunction(key, value) {
        if (typeof (value) === 'string' && value.includes('function()')) {
            let regEx = new RegExp("{([^}]*)}");
            let func = new Function(value.split("function()")[1]);
            return func;
        }
        return value
    }

    window.FusionCharts.renderChart = (chartConfiguration) => {
        options = JSON.parse(chartConfiguration, this.parseFunction);

        const chart = new FusionCharts(options);
        chart.render();
    };

    window.FusionCharts.changeChartData = (chartID, serializedNewData, dataFormat) => {
        newData = JSON.parse(serializedNewData, this.parseFunction);

        var currentChart = FusionCharts(chartID);
        currentChart.setChartData(newData, dataFormat);
    };


    ////////////////////////Generic Method/////////////////////////////////////

    window.FusionCharts.invokeChartFunction = (functionName, chartID, ...args) => {
        var currentChart = FusionCharts(chartID);
    
        var result =   currentChart[functionName].apply(currentChart, ...args);
        //var result = currentChart[functionName](...args);

        var typeofresult = typeof result;

        if(typeofresult === "number"){
            result = result.toString();
        }
        else if(typeofresult === "object"){
            result = JSON.stringify(result);
        }
        else if(typeofresult === "XML"){
            result = XML.stringify(result);
        }
        else if(typeofresult === "boolean"){
            result = result.toString();
        }

        console.log(result);

        if(typeofresult === "string"){
            return result;
        }

        return "";
    };
