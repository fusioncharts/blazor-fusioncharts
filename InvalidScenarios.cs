using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Xunit;

namespace Microsoft.FusionChartsInterop.Tests
{ 
   public class ChartsServiceTest
    {
    [Fact]
    public async Task RenderChart_InvalidChartConfig_ThrowsException()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        string invalidChartConfig = null; // Invalid chart config, e.g., null

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => fusionChartsService.renderChart(invalidChartConfig));
        // Add more specific assertions if needed
    }

    [Fact]
    public async Task ActivateLicense_InvalidLicenseKey_ThrowsException()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var invalidLicenseKey = ""; // Invalid license key, e.g., an empty string

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(() => fusionChartsService.activateLicense(invalidLicenseKey));
        // Add more specific assertions if needed
    }

    [Fact]
    public async Task CallFusionChartsFunction_CallsInvokeAsyncWithInvalidArguments()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var functionName = "Function";
        var chartId = "ChartId";
        var invalidArgs = new object[] { null, 42 }; // Example of invalid arguments

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            var result = await fusionChartsService.CallFusionChartsFunction(functionName, chartId, invalidArgs);
        });
    }

    [Fact]
    public async Task CallFusionChartsFunction_InvalidSetChartAttribute_CallsInvokeAsyncWithCorrectArguments()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var functionName = "setChartAttribute";
        var chartId = "ChartId";
        var attributeName = (string)null; // Invalid attribute name
        var attributeValue = "Value";
        var args = new object[] { attributeName, attributeValue };

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
    }

    [Fact]
    public async Task CallFusionChartsFunction_InvalidGetChartAttribute_CallsInvokeAsyncWithCorrectArguments()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var functionName = "getChartAttribute";
        var chartId = "ChartId";
        var attributeName = (string)null; // Invalid attribute name
        var args = new object[] { attributeName };

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
    }

        [Fact]
        public async Task CallFusionChartsFunction_InvalidChartType_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "chartType";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

        [Fact]
    public async Task CallFusionChartsFunction_InvalidSetXMLData_CallsInvokeAsyncWithCorrectArguments()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var functionName = "setXMLData";
        var chartId = "ChartId";
        var xmlData = (string)null; // Invalid XML data
        var args = new object[] { xmlData };

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
    }

        [Fact]
        public async Task CallFusionChartsFunction_InvalidGetXMLData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getXMLData";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

        [Fact]
    public async Task CallFusionChartsFunction_InvalidSetChartData_CallsInvokeAsyncWithCorrectArguments()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var functionName = "setChartData";
        var chartId = "ChartId";
        var data = (object[])null; // Invalid data
        var args = new object[] { data };

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
    }

       [Fact]
        public async Task CallFusionChartsFunction_InvalidGetChartData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getChartData";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

        [Fact]
    public async Task CallFusionChartsFunction_InvalidShowChartMessage_CallsInvokeAsyncWithCorrectArguments()
    {
        // Arrange
        var mockJsRuntime = new MockJSRuntime();
        var fusionChartsService = new FusionChartsService(mockJsRuntime);
        var functionName = "showChartMessage";
        var chartId = "ChartId";
        var message = (string)null; // Invalid message
        var args = new object[] { message };

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
    }
        [Fact]
        public async Task CallFusionChartsFunction_InvalidDispose_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "dispose";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

        [Fact]
        public async Task CallFusionChartsFunction_InvalidGetCSVData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getCSVData";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

        [Fact]
        public async Task CallFusionChartsFunction_InvalidGetDataAsCSV_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getDataAsCSV";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

        [Fact]
        public async Task CallFusionChartsFunction_InvalidGetSVGString_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getSVGString";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                fusionChartsService.CallFusionChartsFunction(functionName, chartId, args));
        }

    }
}
