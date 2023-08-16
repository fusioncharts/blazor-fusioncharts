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

        public async Task changeChartData(String chartID, String serializedNewData, String dataFormat)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.changeChartData", chartID, serializedNewData, dataFormat);
        }


        ////////////////////////////////////////Generic Method///////////////////////////////////////

        public async Task<String> CallFusionChartsFunction(String functionName, String chartId, params object[] args)
        {

            Console.WriteLine("I'm in CS file");

           String result = await _jsruntime.InvokeAsync<String>("FusionCharts.invokeChartFunction", functionName, chartId, args);
           return result;
        }

    }
}