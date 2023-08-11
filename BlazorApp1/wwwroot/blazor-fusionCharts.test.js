import './blazor-fusionCharts';
import FusionCharts from 'fusioncharts';

describe('change chart attribute', () => {  
    test('changeChartAttribute', () => {
        var chartConfig = {
            type: "pie2d", // Pie Chart type
            width: "500",  // Chart width
            height: "300", // Chart height
            dataFormat: "json", // Data format
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", // Chart title
                    theme: "fusion", // FusionCharts theme
                },
            },
            renderAt: "chartContainer1",
            id: "myid"
        };
        const chart = new FusionCharts(chartConfig);
        chart.render();
        console.log(chart.getChartAttribute("caption"));
        window.FusionCharts.changeChartAttribute(chart.id, 'caption', 'New Chart Title');
        console.log(chart.getChartAttribute("caption"));
    });

});