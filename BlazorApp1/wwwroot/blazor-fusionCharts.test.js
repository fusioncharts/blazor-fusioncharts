import './blazor-fusionCharts';

describe('change chart attribute', () => {
  
    window.FusionCharts = {
        FusionCharts: jest.fn(() => ({
            setChartAttribute: jest.fn(),
        })),
        changeChartAttribute: jest.fn((chartID, attrName, attrValue) => {
            var currentChart = new window.FusionCharts.FusionCharts(chartID);
            currentChart.setChartAttribute(attrName, attrValue);
        }),
    };

    
    test('changeChartAttribute', () => {
      window.FusionCharts.changeChartAttribute('chart1', 'caption', 'New Chart Title');
      expect(window.FusionCharts.changeChartAttribute).toHaveBeenCalledWith('chart1', 'caption', 'New Chart Title');
    });

});