using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace demo.Pages
{
    public class License
    {
        private readonly IJSRuntime _jsRuntime;
        public License(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task ActivateLicense(string licenseKey)
        {
            var licenseObject = new
            {
                key = licenseKey,
                creditLabel = false
            };
            await _jsRuntime.InvokeVoidAsync("console.log", "Activating license key, water mark got removed");
            await _jsRuntime.InvokeVoidAsync("FusionCharts.options.license", licenseObject);
        }
    }
}
