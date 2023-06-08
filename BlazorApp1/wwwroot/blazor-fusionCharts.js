
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
    window.FusionCharts.changeChartType = (chartID, newChartType) => {
        var currentChart = FusionCharts(chartID);
        currentChart.chartType(newChartType);
    };
    window.FusionCharts.destroyChart = (chartID) => {
        var currentChart = FusionCharts(chartID);
        currentChart.dispose();
    };
    window.FusionCharts.changeChartData = (chartID, serializedNewData, dataFormat) => {
        newData = JSON.parse(serializedNewData, this.parseFunction);

        var currentChart = FusionCharts(chartID);
        currentChart.setChartData(newData, dataFormat);
    };
    window.FusionCharts.obtainChartData = (chartID) => {
        var currentChart = FusionCharts(chartID);
        var currentChartData = currentChart.getChartData();

        var serializedChartData = JSON.stringify(currentChartData);
        return serializedChartData;

};
    window.FusionCharts.changeChartAttribute = (chartID, attrName, attrValue) => {
        var currentChart = FusionCharts(chartID);
        currentChart.setChartAttribute(attrName, attrValue);

};
    window.FusionCharts.obtainChartAttribute = (chartID, attrName) => {
        var currentChart = FusionCharts(chartID);
        var attrValue = currentChart.getChartAttribute(attrName);

        return attrValue;

    };