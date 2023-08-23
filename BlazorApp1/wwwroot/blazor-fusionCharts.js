function parseFunction(key, value) {
        if (typeof (value) === 'string' && value.includes('function()')) {
            let regEx = new RegExp("{([^}]*)}");
            let func = new Function(value.split("function()")[1]);
            console.log(value.split("function()")[1]);
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

        if(functionName === "addEventListener"){
            console.log(args[0][1]);
            let value = args[0][1];
            let funcString = value.split("function() {")[1];
            let func = new Function(funcString.substring(0, funcString.length - 1));
            //let func = new Function(value);
            //let func = new Function(value.split("function()")[1]);
            console.log(func, "this is function");
            console.log(typeof func);

            //console.log(eval(value), "using eval here");

            //var result = currentChart[functionName].apply(currentChart, func);
            var result = currentChart[functionName][func];

            console.log(result);

            return "Undefined";

        }

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