function updateTimeChartData() {
    function addLeadingZero(num) {
        return (num <= 9) ? ("0" + num) : num;
    }

    function updateData() {
        // Get reference to the chart using its ID
        var chartRef = FusionCharts("stockRealTimeChart"),
            // We need to create a querystring format incremental update, containing
            // label in hh:mm:ss format
            // and a value (random).
            currDate = new Date(),
            label = addLeadingZero(currDate.getHours()) + ":" +
                addLeadingZero(currDate.getMinutes()) + ":" +
                addLeadingZero(currDate.getSeconds()),
            // Get random number between 35.25 & 35.75 - rounded to 2 decimal places
            randomValue = Math.floor(Math.random() *
                50) / 100 + 35.25,
            // Build Data String in format &label=...&value=...
            strData = "&label=" + label +
                "&value=" +
                randomValue;
        // Feed it to chart.
        chartRef.feedData(strData);
    }

    var myVar = setInterval(function () {
        updateData();
    }, 2500);
}



// function randomF() {
//     // JSRuntime.InvokeVoidAsync("GLOBAL.SetDotnetReference", lDotNetReference);
//     console.log("Hey! I'm working");
//     DotNet.invokeMethodAsync('BlazorApp1.Pages.Index', 'ChangeData')
//     // DotNet.invokeMethodAsync('BlazorApp1', 'ChangeData')
//     // .then(result => {
//     //     console.log('ChangeData method called successfully.');
//     // })
//     // .catch(error => {
//     //     console.error('Error calling ChangeData method:', error);
//     // });
// }


var GLOBAL = {};
GLOBAL.DotNetReference = null;
GLOBAL.SetDotnetReference = function (pDotNetReference) {
    GLOBAL.DotNetReference = pDotNetReference;
};

(function () {

    // keydown event
    window.addEventListener("keydown", function (e) {
        GLOBAL.DotNetReference.invokeMethodAsync('ChangeData');
    });
})();