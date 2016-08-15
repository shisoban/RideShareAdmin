var MONTHS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

var $progress = $('#animationProgress');

var config = {
    type: 'line',
    data: {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [{
            label: "Expected ride Count ",
            data: [58, 67, 100, 35, 47, 87, 12],
            borderDash: [5, 5],
        }, {
            label: "Actual ride Count",
            data: [40, 78, 90, 54, 28, 68, 35],
            fill: false
        }]
    },
    options: {
        title: {
            display: true,
            text: "Expected Ride count and Atcual Ride count"
        },
        animation: {
            duration: 1000,
            onProgress: function (animation) {
                $progress.attr({
                    value: animation.animationObject.currentStep / animation.animationObject.numSteps,
                });
            },
            onComplete: function (animation) {
                window.setTimeout(function () {
                    $progress.attr({
                        value: 0
                    });
                }, 1000);
            }
        },
        tooltips: {
            mode: 'label',
        },
        scales: {
            xAxes: [{
                scaleLabel: {
                    show: true,
                    labelString: 'Month'
                }
            }],
            yAxes: [{
                scaleLabel: {
                    show: true,
                    labelString: 'Ride Counts'
                },
            }]
        }
    }
};

$.each(config.data.datasets, function (i, dataset) {
    dataset.borderColor = "#00FF00";

    dataset.pointBorderColor = "#FF0040";
    dataset.pointBackgroundColor = "#81F7D8";
    dataset.pointBorderWidth = 1;
});

window.onload = function () {
    var ctx = document.getElementById("canvas").getContext("2d");
    window.myLine = new Chart(ctx, config);
};