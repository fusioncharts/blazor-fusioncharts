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
            string invalidChartConfig = null;

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => fusionChartsService.renderChart(invalidChartConfig));
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
            string attributeName = null; // Explicitly specifying string type for attributeName
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
            string attributeName = null; // Invalid attribute name
            var args = new object[] { attributeName };

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);
            });
            Assert.Empty(mockJsRuntime.Invocations);
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
            string XMLData = null;
            var args = new object[] { XMLData };

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
            object[] data = null;
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
            string message = null;
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

        [Fact]
        public async Task CallFusionChartsFunction_ExportChart_InvalidArguments_ThrowsException()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "exportChart";
            var chartId = "ChartId";
            var invalidFormat = ""; // Invalid format, e.g., an empty string
            var args = new object[] { invalidFormat }; // Wrap in an array

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);
            });
            Assert.Empty(mockJsRuntime.Invocations);
        }

        [Fact]
        public async Task CallFusionChartsFunction_SetChartAttribute_InvalidValues()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "setChartAttribute";
            var chartId = "ChartId";
            string attributeName = null;
            var attributeValue = "Value";
            var args = new object[] { attributeName, attributeValue };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);
            });
            Assert.Empty(mockJsRuntime.Invocations);
        }

        [Fact]
        public async Task CallFusionChartsFunction_GetChartAttribute_InvalidValues()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var functionName = "getChartAttribute";
            var chartId = "ChartId";
            string attributeName = null; // Explicitly specifying string type
            var args = new object[] { attributeName };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await fusionChartsService.CallFusionChartsFunction(functionName, chartId, args);
            });
            Assert.Empty(mockJsRuntime.Invocations);
        }

        [Fact]
        public async Task ResizeTo_InvalidArguments_ThrowsException()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var chartId = "ChartId";
            var invalidResizeArgs = new object[] { }; // Empty resize arguments

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await fusionChartsService.resizeTo(chartId, invalidResizeArgs);
            });
            Assert.Empty(mockJsRuntime.Invocations);
        }

        [Fact]
        public async Task SetDataStore_InvalidValues()
        {
            // Arrange
            var mockJsRuntime = new MockJSRuntime();
            var fusionChartsService = new FusionChartsService(mockJsRuntime);
            var chartId = "ChartId";
            object[] args = null; // Explicitly specifying object[] type

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await fusionChartsService.setDataStore(chartId, args);
            });
            Assert.Empty(mockJsRuntime.Invocations);
        }
    }
}
