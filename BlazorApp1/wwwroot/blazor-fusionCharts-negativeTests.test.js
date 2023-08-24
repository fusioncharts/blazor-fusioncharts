import './blazor-fusionCharts';

describe('Render Chart', () => {  
    test('rendering chart with invalid config string', () => {
        const invalidChartConfigString = "invalidConfigString";
      
        expect(() => {
          window.FusionCharts.renderChart(invalidChartConfigString);
        }).toThrowError("Unexpected token i in JSON at position 0");
      });

      test('rendering chart with invalid config string', () => {
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
                id: "myid"
            };

            expect(() => {
                window.FusionCharts.renderChart(chartConfig);
            }).toThrowError("Unexpected token o in JSON at position 1");
      });
});
  
describe('get chart Attribute', () => {  
    test('invoking getChartAttribute with invalid chart id', () => {
            
        const invalidChartId = 'invalidChartId';
          
        expect(() => {
            window.FusionCharts.invokeChartFunction('getChartAttribute', invalidChartId, ['subcaption']);
        }).toThrowError("Cannot read properties of undefined (reading 'getChartAttribute')");
    });
});    


describe('set chart attribute', () => {  
    test('invoking setChartAttribute with invalid chart id', () => {

        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('setChartAttribute', invalidChartId, ['caption', 'New Chart Title']);
        }).toThrowError("Cannot read properties of undefined (reading 'setChartAttribute')");
    });        
});

describe('set chart data', () => {  
    test('invoking setChartData with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('setChartData', invalidChartId, ['caption', 'New Chart Title']);
        }).toThrowError("Cannot read properties of undefined (reading 'setChartData')");
      });     
});


describe('get chart Data', () => {  
    test('invoking getChartData with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('getChartData', invalidChartId);
        }).toThrowError("Cannot read properties of undefined (reading 'getChartData')");
      });   
});

describe('Destroy chart', () => {  
    test('invoking dispose with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('dispose', invalidChartId);
        }).toThrowError("Cannot read properties of undefined (reading 'dispose')");
      });
});

describe('change chart type', () => {  
    test('invoking chartType with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('chartType', invalidChartId);
        }).toThrowError("Cannot read properties of undefined (reading 'chartType')");
      });    
});

describe('get XML data', () => {  
    test('invoking getXMLData with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('getXMLData', invalidChartId);
        }).toThrowError("Cannot read properties of undefined (reading 'getXMLData')");
      });   
});

describe('set XML data', () => {  
    test('invoking setXMLData with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('setXMLData', invalidChartId, ['<chart caption="Changed the caption" theme="fusion" />']);
        }).toThrowError("Cannot read properties of undefined (reading 'setXMLData')");
      });   
});

describe('show chart message', () => {  
    test('invoking showChartMessage with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('showChartMessage', invalidChartId, ['this is chart message','true','true']);
        }).toThrowError("Cannot read properties of undefined (reading 'showChartMessage')");
      });   
});

describe('get JSON Data', () => {  
    test('invoking getJSONData with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('getJSONData', invalidChartId);
        }).toThrowError("Cannot read properties of undefined (reading 'getJSONData')");
      });    
});

describe('set JSON Data', () => {  
    test('invoking setJSONData with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('setJSONData', invalidChartId, ['{"chart":{"caption":"change chart data","theme":"fusion"}}']);
        }).toThrowError("Cannot read properties of undefined (reading 'setJSONData')");
      });   
});

describe('format number', () => {  
    test('invoking formatNumber with invalid chart id', () => {
        const invalidChartId = 'invalidChartId';
      
        expect(() => {
          window.FusionCharts.invokeChartFunction('formatNumber', invalidChartId, [1111]);
        }).toThrowError("Cannot read properties of undefined (reading 'formatNumber')");
      });   
});



