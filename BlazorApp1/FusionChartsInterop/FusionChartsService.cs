using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.JSInterop;

namespace Microsoft.FusionChartsInterop
{
    public class FusionChartsService
    {
        public readonly IJSRuntime _jsruntime;
        public FusionChartsService(IJSRuntime jSRuntime)
        {
            _jsruntime = jSRuntime;
        }
        public async Task renderChart(String chartConfig)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.renderChart", chartConfig);
        }
        public async Task activateLicense(String licenseKey)
        {
            var licenseObject = new
            {
                key = licenseKey,
                creditLabel = false
            };
            await _jsruntime.InvokeVoidAsync("FusionCharts.options.license", licenseObject);
        }

        public async Task changeChartType(String chartID, string newChartType)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.changeChartType", chartID, newChartType);
        }

        public async Task destroyChart(String chartID)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.destroyChart", chartID);
        }

        public async Task changeChartData(String chartID, String serializedNewData, String dataFormat)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.changeChartData", chartID, serializedNewData, dataFormat);
        }

        public async Task<String> obtainChartData(String chartID)
        {
           String serializedResult = await _jsruntime.InvokeAsync<String>("FusionCharts.obtainChartData", chartID);
            return serializedResult; 
        }
        public async Task changeChartAttribute(String chartID, String attrName, String attrValue)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.changeChartAttribute", chartID, attrName, attrValue);
           
        }

        public async Task<String> obtainChartAttribute(String chartID, String attrName)
        {
            String result = await _jsruntime.InvokeAsync<String>("FusionCharts.obtainChartAttribute", chartID, attrName);
            return result;
        }
    }
}
