﻿using Microsoft.AspNetCore.Components.RenderTree;
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

        // Method written for charts like time-series charts
        public async Task setDataStore(String id, params object[] args){
            await _jsruntime.InvokeVoidAsync("FusionCharts.setDataStore", id, args);
        }
        
        //Genric Method calling another method generic method written in blazor-fusionCharts.js which is further calling fusion charts method//
        public async Task<String> CallFusionChartsFunction(String functionName, String chartId, params object[] args)
        {
           String result = await _jsruntime.InvokeAsync<String>("FusionCharts.invokeChartFunction", functionName, chartId, args);
           return result;
        }
    }
}