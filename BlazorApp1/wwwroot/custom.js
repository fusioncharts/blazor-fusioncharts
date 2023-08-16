// // wwwroot/js/custom.js
// function callChangeDataMethod() {
//     DotNet.invokeMethodAsync('BlazorApp1', 'ChangeData')
//         .then(result => {
//             console.log('ChangeData method called successfully.');
//         })
//         .catch(error => {
//             console.error('Error calling ChangeData method:', error);
//         });
// }


// window.callChangeDataMethod = async function () {
//     await DotNet.invokeMethodAsync('BlazorApp1', 'ChangeData');
// }

// window.randomF = {
//     function () {
//         console.log("Hey! It's me randomF");
//     }
// }

function randomF() {
    console.log("Hey! It's me randomF");
    console.log(DotNet)
    DotNet.invokeMethodAsync('BlazorApp1', 'ChangeData')
    .then(data => {
        console.log(data);
    })
    .catch(err => {
        console.log(err);
    });
}


// window.randomF = {
//     ChangeData: function() {
//         DotNet.invokeMethodAsync('BlazorApp1', 'ChangeData')
//         .then(data => {
//             console.log(data);
//         })
//         .catch(err => {
//             console.log(err);
//         });
//     }
// }