function speedometerdata() {
    var chartRef = FusionCharts("speedometerchart");
    function addLeadingZero(num) {
        return num <= 9 ? "0" + num : num;
    }

    function updateData() {
        var val = Math.floor(Math.random() * 26 + 1),
            strData =
                "&value=" +
                val +
                "&toolText=<b>" +
                val +
                " metric tonnes</b>";
        // Feed it to chart. 
       // console.log(strData);
        chartRef.feedData(strData);
    }

    chartRef.intervalUpdateId = setInterval(updateData, 1000);
}


      