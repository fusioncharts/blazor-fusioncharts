using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.JSInterop;
using Xunit;

namespace Microsoft.FusionChartsInterop.Tests
{
    public class MockJSRuntime : IJSRuntime
    {
        public List<Tuple<string, object[]>> Invocations { get; } = new List<Tuple<string, object[]>>();

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
        {
            Invocations.Add(Tuple.Create(identifier, args));
            return new ValueTask<TValue>(default(TValue));
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            Invocations.Add(Tuple.Create(identifier, args));
            return new ValueTask<TValue>(default(TValue));
        }
    }

    public class FusionChartsServiceTests
    {
        [Fact]
        public async Task RenderChart_CallsInvokeVoidAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var chartConfig = "ChartConfig";

            // Act
            await fusionChartsService.renderChart(chartConfig);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.renderChart", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { chartConfig }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task ActivateLicense_CallsInvokeVoidAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var licenseKey = "LicenseKey";

            // Act
            await fusionChartsService.activateLicense(licenseKey);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.options.license", mockJsRuntime.Invocations[0].Item1);
            var licenseObject = mockJsRuntime.Invocations[0].Item2[0] as object;
            Assert.NotNull(licenseObject);

            var key = licenseObject.GetType().GetProperty("key")?.GetValue(licenseObject)?.ToString();
            var creditLabel = (bool)licenseObject.GetType().GetProperty("creditLabel")?.GetValue(licenseObject);

            Assert.Equal(licenseKey, key);
            Assert.False(creditLabel);
        }

        [Fact]
        public async Task CallFusionChartsFunction_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "Function";
            var chartId = "ChartId";
            var args = new object[] { 42, "test" };

            // Act
            var result = await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);

            // Add more assertions based on the behavior and expected result of CallFusionChartsFunction
            // For example, you might assert the return value or certain console output.
        }
        [Fact]
        public async Task CallFusionChartsFunction_SetChartAttribute_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "setChartAttribute";
            var chartId = "ChartId";
            var attributeName = "Attribute";
            var attributeValue = "Value";
            var args = new object[] { attributeName, attributeValue };

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_GetChartAttribute_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getChartAttribute";
            var chartId = "ChartId";
            var attributeName = "Attribute";
            var args = new object[] { attributeName };

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_ChartType_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "chartType";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_GetXMLData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getXMLData";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_SetXMLData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "setXMLData";
            var chartId = "ChartId";
            var xmlData = "<chart></chart>";
            var args = new object[] { xmlData };

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_SetChartData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "setChartData";
            var chartId = "ChartId";
            var data = new object[] { 10, 20, 30, 40 };
            var args = new object[] { data };

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_GetChartData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getChartData";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }
        [Fact]
        public async Task CallFusionChartsFunction_ShowChartMessage_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "showChartMessage";
            var chartId = "ChartId";
            var message = "Message";
            var args = new object[] { message };

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_Dispose_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "dispose";
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }
    }
}
