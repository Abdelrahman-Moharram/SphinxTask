// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*function dateStrToObj(dateStr) {
    const [year, month, date] = dateStr.split('-').map(Number)
return new Date(year, month - 1, date)
}

function onChange() {
    const startDateStr = document.querySelector('#startDate').value
const endDateStr = document.querySelector('#endDate').value

if (!startDateStr || !endDateStr) return

const startDate = dateStrToObj(startDateStr)
const endDate = dateStrToObj(endDateStr)
if (endDate.valueOf() < startDate.valueOf()) {
    document.getElementById("endDataErrors").innerHTML += `
                <li>End date is before start date!</li>
        `
        document.getElementById('saveButton').setAttribute('type', 'button')
    }
}


for (const dateInput of document.querySelectorAll('input[type=date]')) {
    dateInput.addEventListener('change', onChange)
}
*/