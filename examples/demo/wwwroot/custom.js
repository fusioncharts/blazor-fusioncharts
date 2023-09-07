//add this function in random.js file. 
//include the path of random.js file in _Host.cshtml

function randomValues() {
    var myVar = setInterval(function () {
        updateData();
    }, 3000);

    function addLeadingZero(num) {
        return (num <= 9) ? ("0" + num) : num;
    }

    function updateData() {
        // Get reference to the chart using its ID
        var chartRef = FusionCharts("RealTimeCharts"),

            // We need to create a querystring format incremental update, containing
            // label in hh:mm:ss format
            // and a value (random).
            currDate = new Date(),
            label = addLeadingZero(currDate.getHours()) + ":" +
                addLeadingZero(currDate.getMinutes()) + ":" +
                addLeadingZero(currDate.getSeconds()),

            // Get random number between 35.25 & 35.75 - rounded to 2 decimal places
            randomValue = Math.floor(Math.random() * 50) / 100 + 35.25,

            // Build Data String in format &label=...&value=...
            strData = "&label=" + label + "&value=" + randomValue;
        //console.log(strData);

        // Feed it to chart.
        chartRef.feedData(strData);
    }


}


