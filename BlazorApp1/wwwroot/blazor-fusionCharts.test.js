import './blazor-fusionCharts';

describe('Render Chart', () => {  
    test('Render Chart', () => {
    
        var chartConfigString ='{"type": "pie2d","width": "500","height": "300","dataFormat": "json","dataSource": {"chart": {"caption": "Sample Pie Chart","theme": "fusion"}},"renderAt": "chartContainer1","id": "id"}';

        expect(() => {
            window.FusionCharts.renderChart(chartConfigString);
          }).not.toThrow();
        });
});   
  
describe('get chart Attribute', () => {  
    test('getChartAttribute', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id1"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();         

        var result = window.FusionCharts.invokeChartFunction('getChartAttribute',chart.id, ['caption']);
        expect(result).toBe("Sample Pie Chart");

    });    
});

describe('set chart attribute', () => {  
    test('setChartAttribute', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id2"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();

        window.FusionCharts.invokeChartFunction('setChartAttribute',chart.id, ['caption','New Chart Title']);

        expect(chart.getChartAttribute("caption")).toBe('New Chart Title');

    });    
});


describe('set chart data', () => {  
    test('setChartData', () => {
        const chartConfig = {
            type: "pie2d",
            width: "500",
            height: "300",
            dataFormat: "json",
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart",
                    theme: "fusion",
                }
            },
            renderAt: "chartContainer1",
            id: "id3"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        var newChartData = '{"chart":{"caption":"change chart data","theme":"fusion"}}'
        window.FusionCharts.invokeChartFunction('setChartData',chart.id,[newChartData,'json']);
    
        var expectedOutput = {
            chart: { 
                caption: 'change chart data', 
                theme: 'fusion' 
            } 
        };
        
        expect(chart.getChartData()).toStrictEqual(expectedOutput);
    
    });    
});


describe('get chart Data', () => {  
    test('getchartData', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id4"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        var result = window.FusionCharts.invokeChartFunction('getChartData',chart.id);

        var expectedOutput = '{"chart":{"caption":"Sample Pie Chart","theme":"fusion"}}'
        expect(result).toStrictEqual(expectedOutput);
    });    
});

describe('Destroy chart', () => {  
    test('destroyChart', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id5"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        window.FusionCharts.invokeChartFunction('dispose',chart.id);
        expect(chart.disposed).toBe(true);
    });    
});

describe('change chart type', () => {  
    test('changeChartType', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id6"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
 
        window.FusionCharts.invokeChartFunction('chartType',chart.id,['mscolumn2d'])
        expect(chart.chartType()).toBe('mscolumn2d');
    });    
});

describe('get XML data', () => {  
    test('getXMLData', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id7"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
 
        var result = window.FusionCharts.invokeChartFunction('getXMLData',chart.id)
        var expectedOutput = '<chart caption="Sample Pie Chart" theme="fusion" />'
        
        expect(chart.getXMLData()).toStrictEqual(expectedOutput);
    });    
});

describe('set XML data', () => {  
    test('setXMLData', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id8"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        window.FusionCharts.invokeChartFunction('setXMLData',chart.id,['<chart caption="Changed the caption" theme="fusion" />'])
        
        var expectedOutput = '<chart caption="Changed the caption" theme="fusion" />'
        expect(chart.getXMLData()).toStrictEqual(expectedOutput);
    });    
});

describe('show chart message', () => {  
    test('showChartMessage', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                    message: "This is a sample pie chart showing data distribution.",
                },
            },
            renderAt: "chartContainer1",
            id: "id9"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        var result = window.FusionCharts.invokeChartFunction('showChartMessage',chart.id,['this is chart message','true','true']);
      
        expect(result).toStrictEqual('this is chart message');  
    });    
});

describe('get JSON Data', () => {  
    test('getJSONData', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id10"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        var result = window.FusionCharts.invokeChartFunction('getJSONData',chart.id);

        var expectedOutput = '{"chart":{"caption":"Sample Pie Chart","theme":"fusion"}}'
        expect(result).toStrictEqual(expectedOutput);
    });    
});

describe('set JSON Data', () => {  
    test('setJSONData', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id11"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        window.FusionCharts.invokeChartFunction('setJSONData',chart.id,['{"chart":{"caption":"change chart data","theme":"fusion"}}']);

        var expectedOutput = {"chart":{"caption":"change chart data","theme":"fusion"}}
        expect(chart.getJSONData()).toStrictEqual(expectedOutput);
    });    
});

describe('format number', () => {  
    test('formatNumber', () => {
        var chartConfig = {
            type: "pie2d", 
            width: "500",  
            height: "300", 
            dataFormat: "json", 
            dataSource: {
                chart: {
                    caption: "Sample Pie Chart", 
                    theme: "fusion", 
                },
            },
            renderAt: "chartContainer1",
            id: "id12"
        };
                
        const chart = new FusionCharts(chartConfig);
        chart.render();
        
        var result = window.FusionCharts.invokeChartFunction('formatNumber',chart.id,[1111]);

        expect(result).toBe("1.11K");
    });    
});




