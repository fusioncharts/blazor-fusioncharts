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
        // Rendering Fusion chart//
        public async Task renderChart(String chartConfig)
        {
            await _jsruntime.InvokeVoidAsync("FusionCharts.renderChart", chartConfig);
        }

        // To activate the valid license//
        public async Task activateLicense(String licenseKey)
        {
            var licenseObject = new
            {
                key = licenseKey,
                creditLabel = false
            };
            await _jsruntime.InvokeVoidAsync("FusionCharts.options.license", licenseObject);
        }

        // resizeTo will not return anything as return object json is having circular references
        public async Task resizeTo(String id, params object[] args){
            await _jsruntime.InvokeVoidAsync("FusionCharts.resizeTo", id, args);
        }

        // Method written for charts like time-series charts
        public async Task setDataStore(String id, params object[] args){
            await _jsruntime.InvokeVoidAsync("FusionCharts.setDataStore", id, args);
        }

        //To add annotations items and groups
        public async Task addAnnotations(String functionName, String id, params object[] args){
            await _jsruntime.InvokeVoidAsync("FusionCharts.addAnnotations", functionName, id, args);
        }
        
        //Genric Method calling another method generic method written in blazor-fusionCharts.js which is further calling fusionCharts method//
        public async Task<String> CallFusionChartsFunction(String functionName, String chartId, params object[] args)
        {
           String result = await _jsruntime.InvokeAsync<String>("FusionCharts.invokeChartFunction", functionName, chartId, args);
           return result;
        }

    }
}