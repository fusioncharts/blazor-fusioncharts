<<<<<<< HEAD
using Microsoft.JSInterop;
=======
﻿using Microsoft.JSInterop;
>>>>>>> 599f4ae7b6a1f4c2405b973ba1c39df8f5f00ed5
using Xunit;

namespace Microsoft.FusionChartsInterop.Tests
{
    public class MockJSRuntime : IJSRuntime
    {
<<<<<<< HEAD
        public List<Tuple<string, object?[]>> Invocations { get; } = new List<Tuple<string, object?[]>>();

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        {
            Invocations.Add(Tuple.Create(identifier, args ?? Array.Empty<object>()));
            return new ValueTask<TValue>(result: default!);
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
        {
            Invocations.Add(Tuple.Create(identifier, args ?? Array.Empty<object>()));
            return new ValueTask<TValue>(result: default!);
=======
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
>>>>>>> 599f4ae7b6a1f4c2405b973ba1c39df8f5f00ed5
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

<<<<<<< HEAD
            var key = licenseObject?.GetType().GetProperty("key")?.GetValue(licenseObject)?.ToString();
            var creditLabel = (bool?)(licenseObject?.GetType().GetProperty("creditLabel")?.GetValue(licenseObject));

            Assert.Equal(licenseKey, key);
            Assert.False(creditLabel ?? false);
=======
            var key = licenseObject.GetType().GetProperty("key")?.GetValue(licenseObject)?.ToString();
            var creditLabel = (bool)licenseObject.GetType().GetProperty("creditLabel")?.GetValue(licenseObject);

            Assert.Equal(licenseKey, key);
            Assert.False(creditLabel);
>>>>>>> 599f4ae7b6a1f4c2405b973ba1c39df8f5f00ed5
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
        }

        [Fact]
        public async Task CallFusionChartsFunctionSetChartAttributeCallsInvokeAsyncWithCorrectArguments()
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
        public async Task CallFusionChartsFunctionGetChartAttributeCallsInvokeAsyncWithCorrectArguments()
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

        [Fact]
        public async Task CallFusionChartsFunction_GetCSVData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getCSVData";
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
        public async Task CallFusionChartsFunction_GetDataAsCSV_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getDataAsCSV";
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
        public async Task CallFusionChartsFunction_SetJSONData_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "setJSONData";
            var chartId = "ChartId";
            var jsonData = "{pie Chart}";
            var args = new object[] { jsonData };

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task CallFusionChartsFunction_GetSVGString_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getSVGString";
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
        public async Task CallFusionChartsFunction_ExportChart_CallsInvokeAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "exportChart";
            var chartId = "ChartId";
            var format = "pdf";
            var args = new object[] { format }; // Wrap format in an array

            // Act
            await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.invokeChartFunction", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { functionName, chartId, args }, mockJsRuntime.Invocations[0].Item2);
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
        public async Task ResizeTo_CallsInvokeVoidAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var chartId = "ChartId";
            var resizeArgs = new object[] { 800, 600 };

            // Act
            await fusionChartsService.resizeTo(chartId, resizeArgs);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.resizeTo", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { chartId, resizeArgs }, mockJsRuntime.Invocations[0].Item2);
        }

        [Fact]
        public async Task SetDataStore_CallsInvokeVoidAsyncWithCorrectArguments()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var chartId = "ChartId";
            var args = Array.Empty<object>();

            // Act
            await fusionChartsService.setDataStore(chartId, args);

            // Assert
            Assert.Single(mockJsRuntime.Invocations);
            Assert.Equal("FusionCharts.setDataStore", mockJsRuntime.Invocations[0].Item1);
            Assert.Equal(new object[] { chartId, args }, mockJsRuntime.Invocations[0].Item2);
        }
    }
}
